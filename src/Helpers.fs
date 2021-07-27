namespace Ionide.VSCode.Helpers

open System
open Fable.Core

module JS =

    [<Emit("($0 != undefined)")>]
    let isDefined (o: obj) : bool = failwith "never"


//---------------------------------------------------
//VS Code Helpers
//---------------------------------------------------
module VSCode =
    open Fable.Import.VSCode.Vscode

    let getPluginPath pluginName =
        extensions.getExtension pluginName
        |> Option.map (fun e -> e.extensionPath)


//---------------------------------------------------
//Process Helpers
//---------------------------------------------------
module Process =
    let splitArgs cmd =
        if cmd = "" then
            [||]
        else
            cmd.Split(' ')
            |> Array.toList
            |> List.fold (fun (quoted : string option,acc) e ->
                if quoted.IsSome then
                    if e.EndsWith "\"" then None, (quoted.Value + " " + e).Replace("\"", "")::acc
                    else Some (quoted.Value + " " + e), acc
                else
                    if e.StartsWith "\"" &&  e.EndsWith "\"" then None, e.Replace("\"", "")::acc
                    elif e.StartsWith "\"" then Some e, acc
                    elif String.IsNullOrEmpty e then None, acc
                    else None, e::acc
            ) (None,[])
            |> snd
            |> List.rev
            |> List.toArray

    open Node
    open Node.ChildProcess
    open Fable.Import.VSCode.Vscode
    open Fable.Core.JsInterop

    module node = Node.Api

    [<Emit("process.platform")>]
    let private platform: string = jsNative

    let isWin () = platform = "win32"
    let isMono () = platform <> "win32"

    let onExit (f : int option -> string option -> unit) (proc : ChildProcess) =
        proc.on("exit", f) |> ignore
        proc

    let onOutput (f : Buffer.Buffer -> _) (proc : ChildProcess) =
        proc.stdout?on $ ("data", f |> unbox) |> ignore
        proc

    let onErrorOutput (f : Buffer.Buffer -> _) (proc : ChildProcess) =
        proc.stderr?on $ ("data", f |> unbox) |> ignore
        proc

    let onError (f: obj -> _) (proc : ChildProcess) =
        proc?on $ ("error", f |> unbox) |> ignore
        proc

    let spawn location linuxCmd (cmd : string) =
        let cmd' = splitArgs cmd |> ResizeArray

        let options =
            createObj [
                "cwd" ==> workspace.rootPath
            ]
        if isWin () || linuxCmd = "" then
            node.childProcess.spawn(location, cmd', options)
        else
            let prms = seq { yield location; yield! cmd'} |> ResizeArray
            node.childProcess.spawn(linuxCmd, prms, options)

    let spawnInDir location linuxCmd (cmd : string) =
        let cmd' = splitArgs cmd |> ResizeArray

        let options =
            createObj [
                "cwd" ==> (node.path.dirname location)
            ]
        if isWin () || linuxCmd = "" then

            node.childProcess.spawn(location, cmd', options)
        else
            let prms = seq { yield location; yield! cmd'} |> ResizeArray
            node.childProcess.spawn(linuxCmd, prms, options)

    let spawnWithShell location linuxCmd (cmd : string) =
        let cmd' =
            if isWin() then
                splitArgs cmd
                |> Seq.map (fun c -> if c.Contains " " then sprintf "\"%s\"" c else c )
                |> ResizeArray
            else
                splitArgs cmd
                |> Seq.toArray
                |> ResizeArray

        if isWin () || linuxCmd = "" then
            window.createTerminal("F# Application", location, U2.Case1 cmd')
        else
            let prms = seq { yield location; yield! cmd'} |> ResizeArray |> U2.Case1
            window.createTerminal("F# Application", linuxCmd, prms)


    let spawnWithNotification location linuxCmd (cmd : string) (outputChannel : OutputChannel) =
        spawn location linuxCmd cmd
        |> onOutput(fun e -> e.toString () |> outputChannel.append)
        |> onError (fun e -> e.ToString () |> outputChannel.append)
        |> onErrorOutput(fun e -> e.toString () |> outputChannel.append)

    let spawnWithNotificationInDir location linuxCmd (cmd : string) (outputChannel : OutputChannel) =
        spawnInDir location linuxCmd cmd
        |> onOutput(fun e -> e.toString () |> outputChannel.append)
        |> onError (fun e -> e.ToString () |> outputChannel.append)
        |> onErrorOutput(fun e -> e.toString () |> outputChannel.append)

    type ChildProcessExit = {
        Code: int option
        Signal: string option
    }

    let toPromise (proc : ChildProcess): JS.Promise<ChildProcessExit> =
        Promise.create (fun resolve _ -> 
            proc
            |> onExit(fun code signal -> { Code = code; Signal = signal } |> Case1 |> unbox resolve )
            |> ignore
        )

    let exec location linuxCmd cmd : JS.Promise<ExecError option * string * string> =
        let options = createEmpty<ExecOptions>
        options.cwd <- workspace.rootPath
        
        Promise.create (fun resolve error ->
            let execCmd =
                if isWin () then location + " " + cmd
                else linuxCmd + " " + location + " " + cmd
            node.childProcess.exec(execCmd, options,
                (fun (e : ExecError option) (i : U2<string, Buffer.Buffer>) (o : U2<string, Buffer.Buffer>) ->
                    // As we don't specify an encoding, the documentation specifies that we'll receive strings
                    // "By default, Node.js will decode the output as UTF-8 and pass strings to the callback"
                    let arg = e, unbox<string> i, unbox<string> o
                    resolve arg)
            ) |> ignore
        )


//---------------------------------------------------
//Settings Helpers
//---------------------------------------------------
module Settings =
    open Fable.Import.VSCode.Vscode
    open Node
    module node =  Node.Api

    module Toml =
        [<Emit("toml.parse($0)")>]
        let parse (str : string) : 'a = failwith "JS"

    type FakeSettings = {
        linuxPrefix : string
        command : string
        build : string
        parameters : string []
        test : string
    }

    type WebPreviewSettings = {
        linuxPrefix : string
        command : string
        host : string
        port : int
        script : string
        build : string
        startString : string
        parameters : string []
        startingPage : string
    }

    type Settings = {
        Fake : FakeSettings
        WebPreview : WebPreviewSettings
    }

    let loadOrDefault<'a> (map : Settings -> 'a)  (def :'a) =
        try
            let path = workspace.rootPath |> Option.map (fun root -> root + "/.ionide")
            let t =
                path
                |> Option.map node.fs.readFileSync
                |> Option.map string
                |> Option.map Toml.parse
                |> Option.map map
            match t with
            | Some t when JS.isDefined t -> t
            | Some t -> def
            | None -> def
        with
        | _ -> def
