namespace IntelliFactory.WebSharper.JQueryUI

open IntelliFactory.WebSharper

[<assembly: WebSharperAssembly>]
[<assembly: Require(typeof<Dependencies.JQueryBase>)>]
[<assembly: Require(typeof<Dependencies.JQueryUIAll>)>]
[<assembly: Require(typeof<Dependencies.AllCss>)>]
do ()
