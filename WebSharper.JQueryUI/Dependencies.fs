// $begin{copyright}
//
// This file is confidential and proprietary.
//
// Copyright (c) IntelliFactory, 2004-2009.
//
// All rights reserved.  Reproduction or use in whole or in part is
// prohibited without the written consent of the copyright holder.
//-----------------------------------------------------------------
// $end{copyright}

module WebSharper.JQueryUI.Dependencies

module R = WebSharper.Core.Resources

[<WebSharper.Require(typeof<WebSharper.JQuery.Resources.JQuery>)>]
[<Sealed>]
type JQueryUIJs() =
    inherit R.BaseResource("//code.jquery.com/ui/1.11.1/jquery-ui.js")

[<Sealed>]
type JQueryUICss() =
    inherit R.BaseResource("//code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css")


