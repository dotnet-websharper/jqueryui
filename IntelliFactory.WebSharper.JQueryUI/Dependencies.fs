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

module IntelliFactory.WebSharper.JQueryUI.Dependencies

module R = IntelliFactory.WebSharper.Core.Resources
module A = IntelliFactory.WebSharper.Core.Attributes

[<A.Require(typeof<IntelliFactory.WebSharper.JQuery.Resources.JQuery>)>]
[<Sealed>]
type JQueryUIJs() =
    inherit R.BaseResource("http://code.jquery.com/ui/1.10.3/jquery-ui.js")

[<Sealed>]
type JQueryUICss() =
    inherit R.BaseResource("http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css")


