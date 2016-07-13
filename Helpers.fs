namespace Ionide.VSCode.Helpers

open System
open Fable.Core

module JS =

    [<Emit("($0 != undefined)")>]
    let isDefined (o: obj) : bool = failwith "never"

//---------------------------------------------------
//PromisesExt (by Dave)
//---------------------------------------------------
module Promise =
    open System
    open Fable.Core
    open Fable.Import
    open Fable.Import.JS

    let success (a : 'T -> 'R) (pr : Promise<'T>) : Promise<'R> =
        pr?``then`` $ a |> unbox

    let bind (a : 'T -> Promise<'R>) (pr : Promise<'T>) : Promise<'R> =
        pr?``then`` $ a |> unbox

    let fail (a : obj -> 'T)  (pr : Promise<'T>) : Promise<'T> =
        pr.catch (unbox<Func<obj, U2<'T, PromiseLike<'T>>>> a)

    let either a  (b: Func<obj, U2<'R, JS.PromiseLike<'R>>>) (pr : Promise<'T>) : Promise<'R> =
        pr.``then``(a, b)

    let lift<'T> (a : 'T) : Promise<'T> =
        Promise.resolve(U2.Case1 a)

    type PromiseBuilder() =
        member inline x.Bind(m,f) = bind f m
        member inline x.Return(a) = lift a
        member inline x.ReturnFrom(a) = a
        member inline x.Zero() = Fable.Import.JS.Promise.resolve()

[<AutoOpen>]
module PromiseBuilderImp =
    let promise = Promise.PromiseBuilder()



//---------------------------------------------------
//VS Code Helpers
//---------------------------------------------------
module VSCode =
    open Fable.Import.vscode

    let getPluginPath pluginName =
        let ext = extensions.getExtension pluginName
        ext.extensionPath

    [<Literal>]
    let FSIPATH_WIN32 = @"C:\Program Files\Microsoft SDKs\F#\4.0\Framework\v4.0\"
    
    [<Literal>]
    let FSIPATH_WIN64 = @"C:\Program Files (x86)\Microsoft SDKs\F#\4.0\Framework\v4.0\"
    
    let getFsiFullPathWin exeName = 
        //first look to see if it exists on path
        let fullExePath = 
            System.Environment.GetEnvironmentVariable("PATH").Split ';'
            |> Array.map (fun s -> System.IO.Path.Combine(s, exeName))
            |> Array.tryFind (fun s -> System.IO.File.Exists(s))
        if fullExePath.IsSome then fullExePath.Value
        else 
            //next look in default fsi install folder
            let fsiInstallPath = 
                if System.Environment.Is64BitOperatingSystem then FSIPATH_WIN64
                else FSIPATH_WIN32
            
            let fullExePath = System.IO.Path.Combine(fsiInstallPath, exeName)
            if System.IO.File.Exists(fullExePath) then fullExePath
            else exeName

//---------------------------------------------------
//Process Helpers
//---------------------------------------------------
module Process =
    open Fable.Import.JS
    open Fable.Import.Node
    open Fable.Import.vscode


    let isWin () = ``process``.platform = "win32"
    let isMono () = ``process``.platform = "win32" |> not

    let onExit (f : obj -> _) (proc : child_process_types.ChildProcess) =
        proc.on("exit", f |> unbox) |> ignore
        proc

    let onOutput (f : obj -> _) (proc : child_process_types.ChildProcess) =
        proc.stdout?on $ ("data", f |> unbox) |> ignore
        proc

    let onError (f : obj -> _) (proc : child_process_types.ChildProcess) =
        proc.stderr?on $ ("data", f |> unbox) |> ignore
        proc

    let spawn location linuxCmd (cmd : string) =
        let cmd' =
            if cmd = "" then [||] else cmd.Split(' ')
            |> ResizeArray
        let options =
            createObj [
                "cwd" ==> workspace.rootPath
            ]
        if isWin () || linuxCmd = "" then

            child_process.spawn(location, cmd', options)
        else
            let prms = seq { yield location; yield! cmd'} |> ResizeArray
            child_process.spawn(linuxCmd, prms, options)

    let spawnWithNotification location linuxCmd (cmd : string) (outputChannel : OutputChannel) =
        spawn location linuxCmd cmd
        |> onOutput(fun e -> e.ToString () |> outputChannel.append)
        |> onError (fun e -> e.ToString () |> outputChannel.append)

    let exec location linuxCmd cmd : Promise<Error * Buffer *Buffer> =
        let options =
            createObj [
                "cwd" ==> workspace.rootPath
            ]
        Promise.Create<Error * Buffer *Buffer>(fun (resolve : Func<U2<Error * Buffer *Buffer,PromiseLike<Error * Buffer *Buffer>>,_>) (error : Func<obj,_>) ->
            if isWin () then
                child_process.exec(location + " " + cmd, options, (fun (e : Error) (i : Buffer) (o : Buffer) ->
                    let arg = e,i,o
                    resolve.Invoke(arg |> unbox)) |> unbox) |> ignore
            else
                child_process.exec(linuxCmd + " " + location + " " + cmd, options, (fun (e : Error) (i : Buffer) (o : Buffer) ->
                    let arg = e,i,o
                    resolve.Invoke(arg |> unbox))|> unbox) |> ignore)


//---------------------------------------------------
//Settings Helpers
//---------------------------------------------------
module Settings =
    open Fable.Import.vscode
    open Fable.Import.Node

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
            let path = workspace.rootPath + "/.ionide"
            let t = fs.readFileSync(path).toString ()
                    |> Toml.parse
                    |> map
            if JS.isDefined t then t else def
        with
        | _ -> def
