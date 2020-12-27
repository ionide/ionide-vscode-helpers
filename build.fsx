#r "paket: groupref build //"
#load ".fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.Core.TargetOperators
open Fake.JavaScript
open Fake.DotNet

Target.create "YarnInstall" <| fun _ ->
    Yarn.install id

Target.create "DotNetRestore" <| fun _ ->
    DotNet.restore id "src"

Target.create "CleanFable" <| fun _ ->
    DotNet.exec id "fable" "clean release --extension .js* --yes"   // delete .js.map too
    |> fun res -> if not res.OK then failwithf "ExitCode was %i" res.ExitCode

Target.create "BuildDotnet" <| fun _ ->
    DotNet.build id "src"

Target.create "BuildFable" <| fun _ ->
    DotNet.exec id "fable" "src --outDir release --run webpack"
    |> fun res -> if not res.OK then failwithf "ExitCode was %i" res.ExitCode

Target.create "WatchFable" <| fun _ ->
    DotNet.exec id "fable" "watch src --outDir release --run webpack"
    |> fun res -> if not res.OK then failwithf "ExitCode was %i" res.ExitCode

Target.create "Default" ignore

"YarnInstall" ?=> "BuildFable"
"YarnInstall" ?=> "WatchFable"
"DotNetRestore" ?=> "BuildDotnet"
"DotNetRestore" ?=> "BuildFable"
"DotNetRestore" ?=> "WatchFable"

"YarnInstall" ==> "Default"
"DotNetRestore" ==> "Default"
"BuildFable" ==> "Default"

Target.runOrDefault "Default"