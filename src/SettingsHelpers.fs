namespace Ionide.VSCode

open System
open System.Text.RegularExpressions
open FunScript
open FunScript.TypeScript
open FunScript.TypeScript.fs
open FunScript.TypeScript.child_process
open FunScript.TypeScript.path
open FunScript.TypeScript.vscode


[<ReflectedDefinition>]
module Settings =

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
            let path = workspace.Globals.rootPath + "/.ionide"
            let t = (Globals.readFileSync path).toString ()
                    |> Toml.parse
                    |> map
            Globals.console.log t
            if JS.isDefined t then t else def
        with
        | _ -> def
