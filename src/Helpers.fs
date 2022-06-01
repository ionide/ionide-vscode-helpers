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


module CrossSpawn = 
    open Node.ChildProcess
    type [<AllowNullLiteral>] IExports = 
        abstract spawn: command: string * options: ExecOptions -> ChildProcess
        abstract spawn: command: string * args: ResizeArray<string>  * ?options: ExecOptions -> ChildProcess

    let crossSpawn: IExports = Fable.Core.JsInterop.importAll "cross-spawn"

//---------------------------------------------------
//Process Helpers
//---------------------------------------------------
module Process =

    open Node
    open Node.ChildProcess
    open Fable.Import.VSCode.Vscode
    open Fable.Core.JsInterop
    open CrossSpawn

    module node = Node.Api

    [<Emit("process.platform")>]
    let private platform: string = jsNative

    let isWin () = platform = "win32"
    let isMono () = platform <> "win32"

    let onClose (f : int option -> string option -> unit) (proc : ChildProcess) =
        proc.on("close", f) |> ignore
        proc

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

    /// <summary>
    /// spawns a child process in a directory, using a prefix command on linux if required
    /// </summary>
    /// <param name="dir">the directory to run the command in</param>
    /// <param name="command">the 'base' command to execute</param>
    /// <param name="args">an array of additional CLI args</param>
    /// <returns></returns>
    let spawnInDir dir command args =
        let options = createEmpty<ExecOptions>
        options.cwd <- Some dir
        node.childProcess.spawn(command, args, options)

    /// <summary>
    /// Spawns a child process with a prefix command on linux if required.
    /// </summary>
    /// <param name="command">the 'base' command to execute</param>
    /// <param name="args">an array of additional CLI args</param>
    /// <returns>a node child process</returns>
    let spawn command (args: ResizeArray<string>) =
        let options = createEmpty<ExecOptions>
        options.cwd <- workspace.rootPath
        crossSpawn.spawn(command, args, options)

    /// <summary>
    /// Run a command in a local vscode terminal
    /// </summary>
    /// <param name="command">the 'base' command to execute</param>
    /// <param name="args">an array of additional CLI args</param>
    /// <returns>a vscode terminal</returns>
    let spawnWithShell command (args: ResizeArray<string>) =
        window.createTerminal("F# Application", command, U2.Case1 args)

    /// <summary>
    /// fire off a command in the workspace root and write its output to a channel
    /// </summary>
    /// <param name="command">the 'base' command to execute</param>
    /// <param name="args">an array of additional CLI args</param>
    /// <param name="outputChannel">the output channel to write the stdout/stderr of the process to</param>
    /// <returns></returns>
    let spawnWithNotification command args (outputChannel : OutputChannel) =
        spawn command args
        |> onOutput(fun e -> e.toString () |> outputChannel.append)
        |> onError (fun e -> e.ToString () |> outputChannel.append)
        |> onErrorOutput(fun e -> e.toString () |> outputChannel.append)


    /// <summary>
    /// fire off a command in a directory and write its output to a channel
    /// </summary>
    /// <param name="location">the directory to run the command in</param>
    /// <param name="command">the 'base' command to execute</param>
    /// <param name="args">an array of additional CLI args</param>
    /// <param name="outputChannel">the output channel to write the stdout/stderr of the process to</param>
    /// <returns></returns>
    let spawnWithNotificationInDir location command args (outputChannel : OutputChannel) =
        spawnInDir location command args
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

    /// <summary>
    /// Fire off a command and gather the error, if any, and the stdout and stderr streams.
    /// The command is fired from the workspace's root path.
    /// </summary>
    /// <param name="command">the 'base' command to execute</param>
    /// <param name="args">an array of additional CLI args</param>
    /// <returns></returns>
    let exec command args : JS.Promise<ExecError option * string * string> =
        let options = createEmpty<ExecOptions>
        options.cwd <- workspace.rootPath
        Promise.create (fun resolve reject ->
            let stdout = ResizeArray()
            let stderr = ResizeArray()
            let mutable error = None
            
            crossSpawn.spawn(command, args, options = options)
            |> onOutput (fun e -> stdout.Add(string e))
            |> onError (fun e -> error <- Some e)
            |> onErrorOutput (fun e -> stderr.Add(string e))
            |> onClose (fun code signal ->
                resolve (unbox error, String.concat "\n" stdout, String.concat "\n" stderr)
            )
            |> ignore
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
