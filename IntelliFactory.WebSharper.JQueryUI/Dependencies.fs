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
module Dependencies =
    open IntelliFactory.WebSharper
    open System.Configuration

    module Utils = 

        let inline D<'T when 'T :> Resources.IResource
                         and 'T : (new : unit -> 'T)> =
            new 'T() :> Resources.IResource

        let JQueryForUIBase =
            match ConfigurationManager.AppSettings.["IntelliFactory.WebSharper.JQuery"] with
            | null ->
                "http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"
            | url ->
                url


        let JQueryUIBase =
            match ConfigurationManager.AppSettings.["IntelliFactory.WebSharper.JQueryUI"] with
            | null ->
                "http://jquery-ui.googlecode.com/svn/tags/1.8rc3"
            | url ->
                url

        let RelativeLocation loc = 
            JQueryUIBase + loc
            |> Resources.AbsoluteLocation

        [<AbstractClass>]
        type Module(name: string) =
            inherit Resources.JavaScriptResource()
            override this.Location =
                #if DEBUG
                sprintf "/ui/%s.js"  name
                #else
                sprintf "/ui/minified/%s/%s-min.js" name name
                #endif
                |> RelativeLocation

        [<AbstractClass>]
        type ModuleCss(name: string) =
            inherit Resources.CssResource()
            override this.Location =
                sprintf "/themes/base/%s.css" name
                |> RelativeLocation

    open Utils

    type JQueryBase() =
        inherit Resources.JavaScriptResource()
        override this.Location = 
            JQueryForUIBase
            |> Resources.AbsoluteLocation

    and JQueryUIAll() = 
        inherit Module("jquery-ui")
        override this.Dependencies = [] :> _
    and AllCss()= 
        inherit ModuleCss("jquery.ui.all")