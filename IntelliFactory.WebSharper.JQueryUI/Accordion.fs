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
module internal AccordianInternal =
    [<Inline "jQuery($el).accordion($conf)">]
    let internal New (el: Element, conf: AccordionConfiguration) = ()

[<JavaScriptType>]
type Accordion =
    
    [<JavaScriptConstructor>]
    new () = {}
    
    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : AccordionConfiguration

    [<DefaultValue>]
    val mutable private renderEvent: Event<Utils.RenderEvent>

    [<DefaultValue>]
    val mutable private isRendered: bool

    [<JavaScript>]
    member this.Element
        with get () =
            this.element  
    
    (****************************************************************
    * Constructors
    *****************************************************************)        
    [<JavaScript>]
    [<Name "New2">]
    static member New (els : List<string * Element>, conf: AccordionConfiguration): Accordion = 
        let a = new Accordion()
        a.renderEvent <- new Event<Utils.RenderEvent>()
        a.configuration <- conf
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
            |> On Events.Attach (fun _ _ -> a.Render())
        a.element <- panel
        a            
    
    [<JavaScript>]
    [<Name "New1">]
    static member New (els : List<string * Element>): Accordion =
        Accordion.New(els, new AccordionConfiguration())

    
    (****************************************************************
    * Render interface
    *****************************************************************)          
    [<JavaScript>]
    member this.OnBeforeRender(f: unit -> unit) : unit=
        this.renderEvent.Publish
        |> Event.Iterate (fun re ->
            match re with
            | Utils.RenderEvent.Before  -> f ()
            | _                         -> ()
        )
                    
    [<JavaScript>]
    member this.OnAfterRender(f: unit -> unit) : unit=
        this.renderEvent.Publish
        |> Event.Iterate (fun re ->
            match re with
            | Utils.RenderEvent.After  -> f ()
            | _                         -> ()
        )

    [<JavaScript>]
    member this.Render() =     
        if not this.IsRendered  then
            this.renderEvent.Trigger Utils.RenderEvent.Before
            AccordianInternal.New(this.Element, this.configuration)
            this.renderEvent.Trigger Utils.RenderEvent.After
            this.isRendered <- true
    
    [<JavaScript>]
    member this.IsRendered
        with get () : bool = this.isRendered


    (****************************************************************
    * Methods
    *****************************************************************) 
    [<Inline "jQuery($this.element).accordion('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element).accordion('disable')">]
    member this.Disable () = ()

    [<Inline "jQuery($this.element).accordion('enable')">]
    member this.Enable () = ()

    [<Inline "jQuery($this.element).accordion('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    [<Inline "jQuery($this.element).accordion('activate', $index)">]
    member this.Activate (index: int) = ()

    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element).accordion({change: function (x,y) {$f();}})">]
    member private this.onChange(f : unit -> unit) = ()

    // Adding an event and delayin it if the widget is not yet rendered.
    [<JavaScript>]
    member this.OnChange(f : unit -> unit) =
        if this.IsRendered then
            this.onChange f
        else            
            this.OnAfterRender(fun () ->
                this.onChange f
            )
