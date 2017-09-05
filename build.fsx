#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("WebSharper.JQueryUI")
        .VersionFrom("WebSharper")
        .WithFSharpVersion(FSharpVersion.FSharp30)
        .WithFramework(fun fw -> fw.Net40)
        .References(fun r ->
            [
                r.Assembly "System.Web"
                r.NuGet("WebSharper.Html").Latest(true).ForceFoundVersion().Reference()
            ])

let main =
    bt.WebSharper4.Library("WebSharper.JQueryUI")
        .SourcesFromProject()

let test =
    bt.WebSharper4.HtmlWebsite("WebSharper.JQueryUI.Tests")
        .SourcesFromProject()
        .References(fun r -> [
                r.Project main
                r.NuGet("WebSharper.Html").Latest(true).ForceFoundVersion().Reference()
            ])

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
