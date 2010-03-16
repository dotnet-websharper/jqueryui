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


    [<Inline "jQuery($el).accordion($conf)">]
    let internal NewAccordion (el: Element, conf: AccordionConfiguration) = ()
    
    [<JavaScriptType>]
    type Accordion =
        
        [<JavaScriptConstructor>]
        new () = {}
        
        [<DefaultValue>]
        val mutable private element : Element

        [<DefaultValue>]
        val mutable private actions : option<List<Accordion -> unit>>

        [<Inline "jQuery($this.element).accordion('destroy')">]
        member private this.destroy() = ()

        [<Inline "jQuery($this.element).accordion('disable')">]
        member private this.disable () = ()

        [<Inline "jQuery($this.element).accordion('enable')">]
        member private this.enable () = ()

        [<Inline "jQuery($this.element).accordion('activate', $index)">]
        member private this.activate (index: int) = ()

        [<Inline "jQuery($this.element).accordion('option', $name, $value)">]
        member private this.option (name: string, value: obj) = ()

        [<JavaScript>]
        member private this.CallMethod(f: unit -> unit) =
            match this.actions with
            | None ->                
                f ()
            | Some acs ->                
                this.actions <- Some ((fun _ -> f ()) :: acs)
        
        [<JavaScript>]
        member this.Destroy() =
            this.CallMethod (fun () -> this.destroy())

        [<JavaScript>]
        member this.Disable() =
            this.CallMethod (fun () -> this.disable())
                
        [<JavaScript>]
        member this.Enable() =
            this.CallMethod (fun () -> this.enable())
        
        [<JavaScript>]
        member this.Activate(index: int) =
            this.CallMethod (fun () -> this.activate(index))
        
        [<JavaScript>]
        member this.Init() =            
            match this.actions with
            | Some acs ->                
                acs
                |> List.rev
                |> List.iter (fun f -> 
                    f this
                )                
            | None ->
                ()
            this.actions <- None                  
                        
        [<JavaScript>]
        static member New (els : List<string * Element>, conf: AccordionConfiguration): Accordion = 
            let a = new Accordion()            
            a.actions <- Some [fun a -> NewAccordion(a.Element, conf)]            
            let panel =
                els
                |> List.map (fun (header, el) ->
                    [
                        H3 [A [HRef "#"] -< [header]]
                        Div [el]
                    ]
                )
                |> List.concat
                |> Div
                |> On Events.Attach (fun _ _ -> a.Init())
            a.element <- panel
            a
        
        [<JavaScript>]
        member this.Element
            with get () =
                this.element



