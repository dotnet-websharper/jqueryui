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
module ButtonOfJQ =

    [<JavaScriptType>]
    type ButtonIconsConfiguration = 
        {
            [<Name "primary">]
            Primary: string
            
            [<Name "Secondary">]
            Secondary: string      
        }
        [<JavaScript>]
        static member Default = {Primary = "ui-icon-gear"; Secondary = "ui-icon-triangle-1-s" }

    [<JavaScriptType>]
    type ButtonConfiguration = 
        
        [<DefaultValue>]
        [<Name "text">]
        //true by default
        val mutable Text: bool

        [<DefaultValue>]
        [<Name "label">]
        //true by default
        val mutable Label: string

        [<DefaultValue>]
        [<Name "icons">]
        val mutable Icons: ButtonIconsConfiguration

        [<JavaScriptConstructor>]
        new () = {}

   
    [<JavaScriptType>]
    type ButtonOfJQ = 

        [<Inline "jQuery($id).button()">]
        static member NewPrivate (id: string) = ()

        [<Inline "jQuery($el).button()">]
        static member New (el: Element) = ()

        [<Inline "jQuery($el).button($conf)">]
        static member New (el: Element, conf: ButtonConfiguration) = ()

        [<JavaScript>]
        static member Attach (el: Element) = 
            el
            |> On Events.Attach (fun _ _ -> ButtonOfJQ.New el)

        [<JavaScript>]
        static member AttachWithConfiguration (conf: ButtonConfiguration) (el: Element) = 
            el
            |> On Events.Attach (fun _ _ -> ButtonOfJQ.New (el, conf))