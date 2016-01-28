namespace Ionide.VSCode

open System
open FunScript
open FunScript.TypeScript
open FunScript.TypeScript.vscode
open FunScript.TypeScript.vscode.extensions
open FunScript.TypeScript.child_process

[<AutoOpen>]
[<ReflectedDefinition>]
module Helpers =

    module Toml =
        [<FunScript.JSEmitInline("toml.parse({0})")>]
        let parse (str : string) : 'a = failwith "JS"

    [<AutoOpen>]
    module Dynamic =
        [<JSEmitInline("({0}[{1}])")>]
        let (?) (ob: obj) (prop: string): 'a = failwith "never"

        [<JSEmitInline("({0}[{1}] = {2})")>]
        let (?<-) (ob: obj) (prop: string) (value: 'a): unit = failwith "never"

    module JS =
        //[<Literal>]
        //let byString =
        //    """ function({1}, {0}) {
        //        {1} = {1}.replace(/\[(\w+)\]/g, '.$1'); // convert indexes to properties
        //        {1} = {1}.replace(/^\./, '');           // strip a leading dot
        //        var a = {1}.split('.');
        //        for (var i = 0, n = a.length; i < n; ++i) {
        //            var k = a[i];
        //            if (k in o) {
        //                {0} = {0}[k];
        //            } else {
        //                return;
        //            }
        //        }
        //        return {o};
        //    } """
        //
        //[<JSEmit(byString)>]
        //let getPropertyByString<'T> (prop:string) (o:obj) : 'T = failwith "JS"

        [<JSEmitInline("({1}[{0}])")>]
        let getProperty<'T> (prop:string) (o:obj) : 'T = failwith "JS"

        [<JSEmitInline("({0}[{1}] != undefined)")>]
        let isPropertyDefined (o: obj) (key: string) : bool = failwith "JS"

        [<JSEmitInline("(global[{0}] != undefined)")>]
        let isGloballyDefined (key: string) : bool = failwith "never"

        [<JSEmitInline("({0} != undefined)")>]
        let isDefined (o: obj) : bool = failwith "never"

    [<AutoOpen>]
    module Bindings =
        type EventDelegate<'T> with
            [<FunScript.JSEmitInline("({0}({1}, {2}, {3}))")>]
            member __.Add(f : 'T -> _, args : obj, disposables : Disposable[]) : unit = failwith "JS"

    module EventHandler =
        let add (f : 'T -> _) (args : obj) (disposables : Disposable[]) (ev : EventDelegate<'T>) =
            ev.Add(f,args,disposables)

    module Promise =
        let success (a : 'T -> 'R) (pr : Promise<'T>) : Promise<'R> =
            pr._then (unbox a) |> unbox

        let bind (a : 'T -> Promise<'R>) (pr : Promise<'T>) : Promise<'R> =
            pr._then (unbox a) |> unbox

        let fail (a : obj -> 'T)  (pr : Promise<'T>) : Promise<'T> =
            pr._catch (unbox a)

        let either (a : 'T -> 'R) (b : obj -> 'R)  (pr : Promise<'T>) : Promise<'R> =
            pr._then (unbox a, unbox b) |> unbox

        let lift<'T> (a : 'T) : Promise<'T> =
            Globals.Promise.resolve(a)

        let toPromise (a : Thenable<'T>) = a |> unbox<Promise<'T>>

        let toThenable (a : Promise<'T>) = a |> unbox<Thenable<'T>>

    module VSCode =
        let getPluginPath pluginName =
            let ext = Globals.getExtension pluginName
            ext.extensionPath

    module Process =
        let isWin () = Globals._process.platform = "win32"
        let isMono () = Globals._process.platform = "win32" |> not

        let onExit (f : obj -> _) (proc : ChildProcess) =
            proc.on("exit", f |> unbox) |> ignore
            proc

        let onOutput (f : obj -> _) (proc : ChildProcess) =
            proc.stdout.on("data", f |> unbox) |> ignore
            proc

        let onError (f : obj -> _) (proc : ChildProcess) =
            proc.stderr.on("data", f |> unbox) |> ignore
            proc

        let spawn location linuxCmd (cmd : string) =
            let cmd' = if cmd = "" then [||] else cmd.Split(' ')
            let options = createEmpty<AnonymousType598> ()
            options.cwd <- workspace.Globals.rootPath
            if isWin () || linuxCmd = "" then
                Globals.spawn(location, cmd', options)
            else
                let prms = Array.concat [ [|location|]; cmd']
                Globals.spawn(linuxCmd, prms, options)

        let spawnWithNotification location linuxCmd (cmd : string) (outputChannel : OutputChannel) =
            spawn location linuxCmd cmd
            |> onOutput(fun e -> e.ToString () |> outputChannel.append)
            |> onError (fun e -> e.ToString () |> outputChannel.append)

        let exec location linuxCmd cmd : Promise<Error * Buffer *Buffer> =
            let options = createEmpty<AnonymousType599> ()
            options.cwd <- workspace.Globals.rootPath
            Globals.Promise.Create<Error * Buffer *Buffer>(fun (resolve : Func<Thenable<_>,_>) (error : Func<obj,_>) ->
                if isWin () then
                    Globals.exec(location + " " + cmd, options, (fun (e : Error) (i : Buffer) (o : Buffer) ->
                        let arg = e,i,o
                        resolve.Invoke(arg |> unbox))) |> ignore
                else
                    Globals.exec(linuxCmd + " " + location + " " + cmd, options, (fun (e : Error) (i : Buffer) (o : Buffer) ->
                        let arg = e,i,o
                        resolve.Invoke(arg |> unbox))) |> ignore)
