#load "tools/includes.fsx"
open IntelliFactory.Build

let bt = BuildTool().PackageId("IntelliFactory.WebSharper.JQueryUI", "2.5")

let main =
    bt.WebSharper.Library("IntelliFactory.WebSharper.JQueryUI")
    |> fun main ->
        main.SourcesFromProject().References(fun r ->
            [
                r.Assembly "System.Web"
            ])

bt.Solution [

    main

    bt.NuGet.CreatePackage()
        .Description("Bindings to JQuery UI")
        .Add(main)

]
|> bt.Dispatch
