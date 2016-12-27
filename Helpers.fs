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

    /// <summary>
    /// Creates new promise.
    /// Constuctor function "body" is called with two arguments:
    /// "resolve" - moves promise to fulfilled state, using provided argument as result
    /// "reject" - moves promise to rejected state
    /// </summary>
    let create (body: ('T->unit) -> (obj->unit) -> unit) =
        Promise.Create(fun (resolverFunc : Func<U2<_, _>, _>) (rejectorFunc : Func<_,_>) ->
            body (fun v -> resolverFunc.Invoke(U2.Case1 v)) (fun e -> rejectorFunc.Invoke e))

    /// <summary>
    /// Standard map implementation.
    /// </summary>
    let map (a : 'T -> 'R) (pr : Promise<'T>) : Promise<'R> =
        pr.``then``(
            unbox<Func<'T, U2<'R, PromiseLike<'R>>>> a,
            unbox<Func<obj,unit>> None
        )

    /// <summary>
    /// Standard bind implementation.
    /// </summary>
    let bind (a : 'T -> Promise<'R>) (pr : Promise<'T>) : Promise<'R> =
        pr.``then``(
            unbox<Func<'T, U2<'R, PromiseLike<'R>>>> a,
            unbox<Func<obj,unit>> None
        )

    /// <summary>
    /// Bind for rejected promise.
    /// </summary>
    let catch (a : obj -> Promise<'R>) (pr : Promise<'T>) : Promise<'R> =
        pr.``then``(
            unbox<Func<'T, U2<'R, PromiseLike<'R>>>> None,
            unbox<Func<obj,U2<'R, PromiseLike<'R>>>> a
        )

    /// <summary>
    /// Combination of bind and catch methods. If promise in fulfilled state - a is bound, if in rejected state - then b.
    /// </summary>
    let either (a : 'T -> Promise<'R>) (b: obj -> Promise<'R>) (pr : Promise<'T>) : Promise<'R> =
        pr.``then``(
            unbox<Func<'T, U2<'R, PromiseLike<'R>>>> a,
            unbox<Func<obj,U2<'R, PromiseLike<'R>>>> b
        )

    /// <summary>
    /// Creates promise (in pending state) from the supplied value.
    /// </summary>
    let lift<'T> (a : 'T) : Promise<'T> =
        Promise.resolve(U2.Case1 a)

    /// <summary>
    /// Creates promise (in rejected state) with supplied reason.
    /// </summary>
    let reject<'T> reason : Promise<'T> =
        Promise.reject<'T> reason

    /// <summary>
    /// Allows handing promise which is in fulfilled state.
    /// Can be used for side-effects.
    /// </summary>
    let onSuccess (a : 'T -> unit) (pr : Promise<'T>) : Promise<'T> =
        pr.``then``(
            unbox<Func<'T, U2<'T, PromiseLike<'T>>>> (fun value -> a value; value),
            unbox<Func<obj,unit>> None
        )

    /// <summary>
    /// Allows handing promise which is in rejected state. Propagates rejected promise, to allow chaining.
    /// Can be used for side-effects.
    /// </summary>
    let onFail (a : obj -> unit) (pr : Promise<'T>) : Promise<'T> =
        pr.catch (unbox<Func<obj, U2<'T, PromiseLike<'T>>>> (fun reason -> a reason |> ignore; reject reason))

    let all (prs : Promise<'T> seq) =
        Promise.all (unbox prs)

    let empty<'T> = lift (unbox<'T>null)

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
                    if e.StartsWith "\"" then Some e, acc
                    else None, e::acc
            ) (None,[])
            |> snd
            |> List.rev
            |> List.toArray

    open Fable.Import.JS
    open Fable.Import.Node
    open Fable.Import.vscode
    open Fable.Core.JsInterop


    let isWin () = ``process``.platform = "win32"
    let isMono () = ``process``.platform <> "win32"

    let onExit (f : obj -> _) (proc : child_process_types.ChildProcess) =
        proc.on("exit", f |> unbox) |> ignore
        proc

    let onOutput (f : obj -> _) (proc : child_process_types.ChildProcess) =
        proc.stdout?on $ ("data", f |> unbox) |> ignore
        proc

    let onErrorOutput (f : obj -> _) (proc : child_process_types.ChildProcess) =
        proc.stderr?on $ ("data", f |> unbox) |> ignore
        proc

    let onError (f: obj -> _) (proc : child_process_types.ChildProcess) =
        proc?on $ ("error", f |> unbox) |> ignore
        proc


    let spawn location linuxCmd (cmd : string) =
        let cmd' = splitArgs cmd |> ResizeArray

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
        |> onErrorOutput(fun e -> e.ToString () |> outputChannel.append)

    let toPromise (proc : child_process_types.ChildProcess) =
        Promise.Create<string>(fun (resolve : Func<U2<string,PromiseLike<string>>,unit>) (error : Func<obj,_>) ->
            proc
            |> onExit(fun (code) -> code.ToString() |> Case1 |> unbox resolve )
            |> ignore
        )


    let exec location linuxCmd cmd : Promise<Error * Buffer *Buffer> =
        let options =
            createObj [
                "cwd" ==> workspace.rootPath
            ]
        Promise.Create<Error * Buffer *Buffer>(fun (resolve : Func<U2<Error * Buffer *Buffer,PromiseLike<Error * Buffer *Buffer>>,_>) (error : Func<obj,_>) ->
            let execCmd =
                if isWin () then location + " " + cmd
                else linuxCmd + " " + location + " " + cmd
            child_process.exec(execCmd, options,
                Func<Error,Buffer,Buffer,unit>(fun (e : Error) (i : Buffer) (o : Buffer) ->
                    let arg = e,i,o
                    resolve.Invoke(U2.Case1 arg))) |> ignore)


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
