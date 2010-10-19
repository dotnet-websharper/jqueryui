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
        
    let JQueryUIBase =            
        match null with // ConfigurationManager.AppSettings.["IntelliFactory.WebSharper.JQueryUI"] with
        | null ->
            "http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1"
        | url ->
            url

    let JQueryUIBaseCss =
        match null with // ConfigurationManager.AppSettings.["IntelliFactory.WebSharper.JQueryUICss"] with
        | null ->
            "http://jquery-ui.googlecode.com/svn/tags/1.8rc3/themes/base"
        | url ->
            url     
        
        
    type ModuleResource = {Name: string}
        with
            interface IResource with            
                member this.Id = this.Name
                member this.Dependencies = Seq.empty
                member this.Render context writer =
                    let loc =
                        sprintf "%s/%s.js" JQueryUIBase this.Name
                    Resources.RenderJavaScript loc writer
        
    type ModuleCssResource = {Name: string}
        with
            interface IResource with
                member this.Id = this.Name
                member this.Dependencies = Seq.empty
                member this.Render context writer =
                    let loc = sprintf "%s/%s.css" JQueryUIBaseCss this.Name
                    Resources.RenderCss loc writer

    type JQueryUIAllJS() =          
        inherit Attributes.RequireAttribute()
            override this.Resource ={Name = "jquery-ui"} :> IResource

    type JQueryUIAllCss() =
        inherit Attributes.RequireAttribute()
        override this.Resource = {Name = "jquery.ui.all"} :> IResource

//    open Utils
//
//    type JQueryUIAll() = 
//        inherit Module("jquery-ui")
//                
//    and AllCss()= 
//        inherit ModuleCss("jquery.ui.all")