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

namespace IntelliFactory.WebSharper.JQueryUI

/// Contains YUI resource descriptors and their dependency information.
module Resources =
    open IntelliFactory.WebSharper
    open System.Configuration

    let private jQueryUIBase =
        let setting = "IntelliFactory.WebSharper.JQueryUI"
        match ConfigurationManager.AppSettings.[setting] with
        | null  -> "http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1"
        | url   -> url

    let private jQueryUIBaseCss = jQueryUIBase + "/themes/base"

    /// A resource that renders jQuery UI CSS and JavaScript files.
    type JQueryUI() =
        interface Resources.IResource with
            member this.Id             = "jqueryui"
            member this.Dependencies   = Seq.empty
            member this.Render context =
                Resources.RenderJavaScript (jQueryUIBase + "/jquery-ui.min.js")
                @ Resources.RenderCss (jQueryUIBaseCss + "/jquery.ui.all.css")
