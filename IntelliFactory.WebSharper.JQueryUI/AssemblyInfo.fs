namespace IntelliFactory.WebSharper.JQueryUI

open System.Reflection
open IntelliFactory.WebSharper

[<assembly: AssemblyCompany     "IntelliFactory">]
[<assembly: AssemblyCopyright   "Copyright © IntelliFactory, 2004-2010">]
[<assembly: AssemblyProduct     "IntelliFactory WebSharper™">]
[<assembly: AssemblyTitle       "IntelliFactory.WebSharper.JQueryUI">]
[<assembly: AssemblyName        "IntelliFactory.WebSharper.JQueryUI">]
[<assembly: AssemblyDescription "JQuery UI WebSharper™ Extension">]
[<assembly: AssemblyKeyFile     "//ifbuds01/pub/keys/IntelliFactory.snk">]

[<assembly: WebSharper>]
[<assembly: Require(typeof<Dependencies.JQueryBase>)>]
[<assembly: Require(typeof<Dependencies.JQueryUIAll>)>]
[<assembly: Require(typeof<Dependencies.AllCss>)>]
do ()
