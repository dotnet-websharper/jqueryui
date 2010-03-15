// $begin{copyright}
//
// WebSharper examples
//
// Copyright (c) IntelliFactory, 2004-2009.
//
// All rights reserved.  Reproduction or use in whole or in part is
// prohibited without the written consent of the copyright holder.
//-----------------------------------------------------------------
// $end{copyright}

//JQueryUI Wrapping: (version Stable 1.8rc1) 
namespace IntelliFactory.WebSharper.JQueryUI

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html

[<JavaScriptType>]
//[<Require(typeof<Dependencies.Carousel>)>]
module Tabs = 
    
    [<JavaScriptType>]
    type TabsAjaxOptionsConfiguration = 
        {
        [<Name "ajaxOptions">]
        async: bool
        }

        [<JavaScript>]
        static member Default = {async = false}

    [<JavaScriptType>]
    type TabsCookieConfiguration = 
        {
        [<Name "cookie">]
        expires: int
        }

        [<JavaScript>]
        static member Default = {expires = 30}

    [<JavaScriptType>]
    type TabsFxConfiguration = 
        {
        [<Name "fx">]
        opacity: string
        }
        [<JavaScript>]
        static member Dafault = {opacity = "toggle"}

    [<JavaScriptType>]
    type TabsConfiguration = 
        
        [<DefaultValue>]
        [<Name "ajaxOptions">]
        //null by default
        val mutable AjaxOptions: TabsAjaxOptionsConfiguration

        [<DefaultValue>]
        [<Name "cache">]
        //false by default
        val mutable Cache: bool

        [<DefaultValue>]
        [<Name "collapsible">]
        //false by default
        val mutable Collapsible: bool

        [<DefaultValue>]
        [<Name "cookie">]
        //null by default
        val mutable Cookie: TabsCookieConfiguration

        [<DefaultValue>]
        [<Name "deselectable">]
        //false by default
        val mutable Deselectable: bool

        [<DefaultValue>]
        [<Name "disabled">]
        //[] by default
        val mutable Disabled: array<int>

        [<DefaultValue>]
        [<Name "event">]
        //"click" by default
        val mutable Event: string

        //Option, Array? 
        [<DefaultValue>]
        [<Name "fx">]
        //null by default
        val mutable Fx: TabsFxConfiguration

        [<DefaultValue>]
        [<Name "idPrefix">]
        //"ui-tabs-" by default
        val mutable IdPrefix: string

        [<DefaultValue>]
        [<Name "panelTemplate">]
        //"<div></div>" by default
        val mutable PanelTemplate: string

        [<DefaultValue>]
        [<Name "selected">]
        //0 by default
        val mutable Selected: int

        [<DefaultValue>]
        [<Name "spinner">]
        //"<em>Loading&#8230;</em>" by default
        val mutable Spinner: string

        [<DefaultValue>]
        [<Name "tabTemplate">]
        //"<li><a href="#{href}"><span>#{label}</span></a></li>" by default
        val mutable TabTemplate: string

        [<JavaScriptConstructor>]
        new () = {}
    
    [<JavaScriptType>]
    type Tabs = 

        [<Inline "jQuery($id).tabs()">]
            static member NewPrivate (id: string) = ()

            [<Inline "jQuery($el).tabs()">]
            static member New (el: Element) = ()

            [<Inline "jQuery($el).tabs($conf)">]
            static member New (el: Element, conf: TabsConfiguration) = ()

            [<JavaScript>]
            static member Attach (el: Element) = 
                el
                |> On Events.Attach (fun _ _ -> Tabs.New el)

            [<JavaScript>]
            static member AttachWithConfiguration (conf: TabsConfiguration) (el: Element) = 
                el
                |> On Events.Attach (fun _ _ -> Tabs.New (el, conf))