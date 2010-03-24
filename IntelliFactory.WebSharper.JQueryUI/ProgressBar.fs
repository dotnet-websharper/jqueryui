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
open Utils

[<JavaScriptType>]
type ProgressbarConfiguration =
    
    [<DefaultValue>]
    [<Name "value">]
    //0 by default
    val mutable Value: int

    [<JavaScriptConstructor>]
    new () = {}

[<JavaScriptType>]    
module internal ProgressbarInternal =
    [<Inline "jQuery($el).progressbar($conf)">]
    let Init (el: Element, conf: ProgressbarConfiguration) = ()

[<JavaScriptType>]
type Progressbar = 

    [<JavaScriptConstructor>]
    new () = {}
    
    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : ProgressbarConfiguration

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
    static member New (el: Element, conf: ProgressbarConfiguration) =
        let pb = new Progressbar()
        pb.configuration <- conf
        pb.element <- el
        pb.renderEvent <- new Event<RenderEvent>()
        el
        |> On Events.Attach (fun _ _ -> pb.Render())
        |> ignore
        pb

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
            ProgressbarInternal.Init(this.Element, this.configuration)
            this.renderEvent.Trigger Utils.RenderEvent.After
            this.isRendered <- true
    
    [<JavaScript>]
    member this.IsRendered
        with get () : bool = this.isRendered



    (****************************************************************
    * Methods
    *****************************************************************) 
    [<Inline "jQuery($this.element).progressbar('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element).progressbar('disable')">]
    member this.Disable () = ()

    [<Inline "jQuery($this.element).progressbar('enable')">]
    member this.Enable () = ()

    [<Inline "jQuery($this.element).progressbar('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    [<Inline "jQuery($this.element).progressbar('value', $v)">]
    member private this.setValue (v: int) = ()

    [<Inline "jQuery($this.element).progressbar('value')">]
    member private this.getValue () = 0

    [<JavaScript>]
    member this.Value
        with get () =
            this.getValue()
        and set (v: int) =
            this.setValue v

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