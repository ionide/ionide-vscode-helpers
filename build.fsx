#r "paket: groupref build //"
#load ".fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.Core.TargetOperators
open Fake.JavaScript
open Fake.DotNet
open Fake.IO

let runFable args = 
    DotNet.exec id "fable" args
    |> fun res -> if not res.OK then failwithf "ExitCode was %i" res.ExitCode

Target.create "YarnInstall" <| fun _ ->
    Yarn.install id

Target.create "DotNetRestore" <| fun _ ->
    DotNet.restore id "src"

Target.create "CleanFable" <| fun _ ->
    Shell.cleanDir "release"

Target.create "BuildDotnet" <| fun _ ->
    DotNet.build id "src"

Target.create "BuildFable" <| fun _ ->
    runFable "src --outDir release"

Target.create "BuildFableWithWebpack" <| fun _ ->
    runFable "src --outDir release --run webpack"

Target.create "WatchFable" <| fun _ ->
    runFable "watch src --outDir release"

Target.create "WatchFableWithWebpack" <| fun _ ->
    runFable "watch src --outDir release --runWatch webpack"

Target.create "Webpack" ignore
Target.create "Default" ignore

"CleanFable" ?=> "BuildFable"
"CleanFable" ?=> "BuildFableWithWebpack"
"CleanFable" ?=> "WatchFable"
"CleanFable" ?=> "WatchFableWithWebpack"

"DotNetRestore" ?=> "BuildDotnet"
"DotNetRestore" ?=> "BuildFable"
"DotNetRestore" ?=> "BuildFableWithWebpack"
"DotNetRestore" ?=> "WatchFableWithWebpack"

"YarnInstall" ?=> "BuildFableWithWebpack"
"YarnInstall" ?=> "WatchFableWithWebpack"

"YarnInstall" ==> "Webpack"
"CleanFable" ==> "Webpack"
"DotNetRestore" ==> "Webpack"
"BuildFableWithWebpack" ==> "Webpack"

"CleanFable" ==> "Default"
"DotNetRestore" ==> "Default"
"BuildFable" ==> "Default"

Target.runOrDefault "Default"