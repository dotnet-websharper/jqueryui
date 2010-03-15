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
module Accordion =

    [<JavaScriptType>]
    type AccordionIconConfiguration =
        {   
            [<Name "header">]
            Header: string

            [<Name "headerSelected">]
            HeaderSelected: string
        }

        [<JavaScript>]
        static member Default =
            { Header="ui-icon-triangle-1-e"; HeaderSelected="ui-icon-triangle-1-s" }

    [<JavaScriptType>]
    type AccordionConfiguration = 
        
        [<DefaultValue>]
        [<Name "active">]
        val mutable Active: int

        [<DefaultValue>]
        [<Name "animated">]
        val mutable Animated: string

        [<DefaultValue>]
        [<Name "autoHeight">]
        val mutable AutoHeight: bool

        [<DefaultValue>]
        [<Name "clearStyle">]
        val mutable ClearStyle: bool

        [<DefaultValue>]
        [<Name "collapsible">]
        val mutable Collapsible: bool

        [<DefaultValue>]
        [<Name "event">]
        val mutable Event: string

        [<DefaultValue>]
        [<Name "fillSpace">]
        val mutable FillSpace: bool

        [<DefaultValue>]
        [<Name "header">]
        val mutable Header: string

        [<DefaultValue>]
        [<Name "icons">]
        val mutable Icons: AccordionIconConfiguration

        [<DefaultValue>]
        [<Name "navigation">]
        val mutable Navigation: bool
        
        [<DefaultValue>]
        [<Name "navigationFilter">]
        val mutable NavigationFilter: unit -> unit
        
        [<JavaScriptConstructor>]
        new () = {}

    [<JavaScriptType>]
    type AccordionInternal =

        [<Inline "jQuery($id).accordion()">]
        static member NewPrivate (id: string) : AccordionInternal = 
            Unchecked.defaultof<_>

        [<Inline "jQuery($el).accordion()">]
        static member New (el: Element) : AccordionInternal = 
            Unchecked.defaultof<_>

        [<Inline "jQuery($el).accordion($conf)">]
        static member New (el: Element, conf: AccordionConfiguration): AccordionInternal = 
            Unchecked.defaultof<_>

        [<JavaScript>]
        static member New (els : List<string * Element>, conf: AccordionConfiguration): AccordionInternal = 
            let el =
                els
                |> List.map (fun (header, el) ->
                    [
                        H3 [A [HRef "#"] -< [header]]
                        Div [el]
                    ]
                )
                |> List.concat
                |> Div
            AccordionInternal.New(el, conf)

        [<JavaScript>]
        static member Attach (el: Element) =
            el
            |> On Events.Attach (fun _ _ -> 
                AccordionInternal.New (el)
                |> ignore
            )

        [<JavaScript>]
        static member AttachWithConfiguration (conf: AccordionConfiguration) (el: Element) =
            el
            |> On Events.Attach (fun _ _ -> 
                AccordionInternal.New (el, conf)
                |> ignore
            )

