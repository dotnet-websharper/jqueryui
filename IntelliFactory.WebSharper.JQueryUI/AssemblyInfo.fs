namespace IntelliFactory.WebSharper.JQueryUI

open IntelliFactory.WebSharper

[<assembly: WebSharper>]
[<assembly: Require(typeof<Dependencies.JQueryBase>)>]
[<assembly: Require(typeof<Dependencies.JQueryUIAll>)>]
[<assembly: Require(typeof<Dependencies.AllCss>)>]
do ()
