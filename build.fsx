// --------------------------------------------------------------------------------------
// FAKE build script
// --------------------------------------------------------------------------------------

#I "packages/build/FAKE/tools"
#r "FakeLib.dll"
open System
open System.Diagnostics
open System.IO
open Fake

let run cmd args dir =
    if execProcess( fun info ->
        info.FileName <- cmd
        if not( String.IsNullOrWhiteSpace dir) then
            info.WorkingDirectory <- dir
        info.Arguments <- args
    ) System.TimeSpan.MaxValue = false then
        traceError <| sprintf "Error while running '%s' with args: %s" cmd args

let platformTool tool path =
    isUnix |> function | true -> tool | _ -> path

let npmTool =
    platformTool "npm" ("packages"</>"build"</>"Npm.js"</>"tools"</>"npm.cmd" |> FullName)

Target "RunScript" (fun () ->
    ensureDirectory "release"
    run npmTool "install" "release"
    run npmTool "run build" "release"
)


RunTargetOrDefault "RunScript"