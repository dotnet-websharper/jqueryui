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
            
    let JQueryUIBase =            
        match ConfigurationManager.AppSettings.["IntelliFactory.WebSharper.JQueryUI"] with
        | null ->
            "http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1"
        | url ->
            url

    let JQueryUIBaseCss =
        match ConfigurationManager.AppSettings.["IntelliFactory.WebSharper.JQueryUICss"] with
        | null ->
            "http://jquery-ui.googlecode.com/svn/tags/1.8rc3/themes/base"
        | url ->
            url     
        
        
    type ModuleResource = {Js: string}
        with
            interface IResource with            
                member this.Id = this.Js
                member this.Dependencies = Seq.empty
                member this.Render context writer =
                    let loc =
                        sprintf "%s/%s.js" JQueryUIBase this.Js
                    Resources.RenderJavaScript loc writer
        
    type ModuleCssResource = {Css: string}
        with
            interface IResource with
                member this.Id = this.Css
                member this.Dependencies = Seq.empty
                member this.Render context writer =
                    let loc = sprintf "%s/%s.css" JQueryUIBaseCss this.Css
                    Resources.RenderCss loc writer

    type JQueryUIAllJS() =          
        inherit Attributes.RequireAttribute()
            override this.Resource ={Js = "jquery-ui"} :> IResource

    type JQueryUIAllCss() =
        inherit Attributes.RequireAttribute()
        override this.Resource = {Css = "jquery.ui.all"} :> IResource