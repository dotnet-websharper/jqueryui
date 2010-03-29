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
type ToleranceOfSelectable =     
    | [<Constant "fit">] Fit
    | [<Constant "touch">] Touch

[<JavaScriptType>]
type SelectableConfiguration = 

    [<JavaScriptConstructor>]
    new () = {}

    [<DefaultValue>]
    [<Name "disabled">]
    //false by default
    val mutable Disabled: bool

    [<DefaultValue>]
    [<Name "autoRefresh">]
    //true by default
    val mutable AutoRefresh: bool

    [<DefaultValue>]
    [<Name "cancel">]
    //":input,option"
    val mutable Cancel: string

    [<DefaultValue>]
    [<Name "delay">]
    //0 by default
    val mutable Delay: int

    [<DefaultValue>]
    [<Name "distance">]
    //0 by default
    val mutable Distance: int

    [<DefaultValue>]
    [<Name "filter">]
    //"*" by default
    val mutable Filter: string

    [<DefaultValue>]
    [<Name "tolerance">]
    //"*" by default
    val mutable Tolerance: ToleranceOfSelectable


[<JavaScriptType>]    
module internal SelectableInternal =
    [<Inline "jQuery($el).selectable($conf)">]
    let internal New (el: Element, conf: SelectableConfiguration) = ()


[<JavaScriptType>]
type Selectable = 

    [<JavaScriptConstructor>]
    new () = {}
    
    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : SelectableConfiguration

    [<DefaultValue>]
    val mutable private renderEvent: Event<RenderEvent>

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
    [<Name "New_Selectable">]
    static member New (el : Element, conf: SelectableConfiguration): Selectable = 
        let a = new Selectable()
        a.configuration <- conf
        a.renderEvent <- new Event<RenderEvent>()
        a.element <- 
            el
            |> On Events.Attach (fun _ _ -> a.Render())
        a

    [<JavaScript>]
    [<Name "New_Selectable_Shortcut">]
    static member New (el : Element) : Selectable = 
        let conf = new SelectableConfiguration()
        Selectable.New(el, conf)

    (****************************************************************
    * Render interface
    *****************************************************************)       
       
    [<JavaScript>]
    member this.OnBeforeRender(f: unit -> unit) : unit=
        this.renderEvent.Publish
        |> Event.Iterate (fun re ->
            match re with
            | RenderEvent.Before  -> f ()
            | _                   -> ()
        )
                    
    [<JavaScript>]
    member this.OnAfterRender(f: unit -> unit) : unit=
        this.renderEvent.Publish
        |> Event.Iterate (fun re ->
            match re with
            | RenderEvent.After  -> f ()
            | _                  -> ()
        )

    [<JavaScript>]
    member this.Render() =     
        if not this.IsRendered  then
            this.renderEvent.Trigger RenderEvent.Before
            SelectableInternal.New(this.Element, this.configuration)
            this.renderEvent.Trigger RenderEvent.After
            this.isRendered <- true
    
    [<JavaScript>]
    member this.IsRendered
        with get () : bool = this.isRendered


    (****************************************************************
    * Methods
    *****************************************************************) 

    [<Inline "jQuery($this.element).selectable('destroy')">]
    member this.Destroy() = ()
   
    [<Inline "jQuery($this.element).selectable('disable')">]
    member this.Disable() = ()

    [<Inline "jQuery($this.element).selectable('enable')">]
    member this.Enable() = ()

    [<Inline "jQuery($this.element).selectable('refresh')">]
    member this.Refresh() = ()

    [<Inline "jQuery($this.element).selectable('widget')">]
    member this.Widget() = ()

    [<Inline "jQuery($this.element).selectable('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()



    (****************************************************************
    * Events
    *****************************************************************) 

    [<Inline "jQuery($this.element).selectable({selected: function (x,y) {($f(x))(y.selected);}})">]
    member private this.onSelected(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).selectable({selecting: function (x,y) {($f(x))(y.selecting);}})">]
    member private this.onSelecting(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).selectable({start: function (x,y) {($f(x))(y.start);}})">]
    member private this.onStart(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).selectable({stop: function (x,y) {($f(x))(y.stop);}})">]
    member private this.onStop(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).selectable({unselected: function (x,y) {($f(x))(y.unselected);}})">]
    member private this.onUnselected(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).selectable({unselecting: function (x,y) {($f(x))(y.unselecting);}})">]
    member private this.onUnselecting(f : Events.EventArgs -> Element -> unit) = ()

    [<JavaScript>]
    member private this.On (f : unit -> unit) =
        if this.IsRendered then f ()
        else            
            this.OnAfterRender(fun () -> f ())

    [<JavaScript>]
    member this.OnSelected(f : Events.EventArgs -> Element -> unit) =
        this.On (fun () ->  this.onSelected f)

    [<JavaScript>]
    member this.OnSelecting(f : Events.EventArgs -> Element -> unit) =
        this.On (fun () -> this.onSelecting f)

    [<JavaScript>]
    member this.OnStart(f : Events.EventArgs -> Element -> unit) =
        this.On (fun () -> this.onStart f)

    [<JavaScript>]
    member this.OnStop(f : Events.EventArgs -> Element -> unit) =
        this.On (fun () -> this.onStop f)

    [<JavaScript>]
    member this.OnUnselected(f : Events.EventArgs -> Element -> unit) =
        this.On (fun () ->  this.onUnselected f)

    [<JavaScript>]
    member this.OnUnselecting(f : Events.EventArgs -> Element -> unit) =
        this.On (fun () -> this.onUnselecting f)