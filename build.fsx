#r "packages/build/FAKE/tools/FakeLib.dll"

open Fake
open Fake.YarnHelper
open Fake.DotNetCli

Target "YarnInstall" <| fun () ->
    Yarn (fun p -> { p with Command = Install Standard })

Target "BuildDotnet" <| fun () ->
    DotNetCli.Build (fun p -> { p with WorkingDir = "src" } )

Target "BuildFable" <| fun () ->
    DotNetCli.RunCommand (fun p -> { p with WorkingDir = "src" } ) "fable yarn-build -- -p"

Target "Default" DoNothing

"YarnInstall" ==> "BuildFable"
"BuildFable" ==> "Default"

RunTargetOrDefault "Default"