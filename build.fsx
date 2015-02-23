#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("WebSharper.JQueryUI", "3.0-alpha")
        .References(fun r -> [r.Assembly "System.Web"])
    |> fun bt -> bt.WithFramework(bt.Framework.Net40)

let main =
    bt.WebSharper.Library("WebSharper.JQueryUI")
        .SourcesFromProject()

let test =
    bt.WebSharper.HtmlWebsite("WebSharper.JQueryUI.Tests")
        .SourcesFromProject()
        .References(fun r -> [r.Project main])

bt.Solution [
    main
    test

    bt.NuGet.CreatePackage()
        .Configure(fun c ->
            { c with
                Title = Some "WebSharper.JQueryUI-1.11.1"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://github.com/intellifactory/websharper.jqueryui"
                Description = "WebSharper Extensions for JQueryUI 1.11.1"
                RequiresLicenseAcceptance = true })
        .Add(main)

]
|> bt.Dispatch
