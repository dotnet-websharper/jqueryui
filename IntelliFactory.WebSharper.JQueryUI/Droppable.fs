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
type ToleranceOfDroppable =     
    | [<Constant "fit">] Fit
    | [<Constant "intersect">] Intersect
    | [<Constant "pointer">] Pointer
    | [<Constant "touch">] Touch


[<JavaScriptType>]
type DroppableConfiguration = 

    [<JavaScriptConstructor>]
    new () = {}

    [<DefaultValue>]
    [<Name "accept">]
    //"" by default
    val mutable Accept: string

    [<DefaultValue>]
    [<Name "activeClass">]
    val mutable ActiveClass: string

    [<DefaultValue>]
    [<Name "addClasses">]
    //true by default
    val mutable AddClasses: bool

    [<DefaultValue>]
    [<Name "greedy">]
    //false by default
    val mutable Greedy: bool

    [<DefaultValue>]
    [<Name "hoverClass">]
    //"drophover" by default
    val mutable HoverClass: string

    [<DefaultValue>]
    [<Name "scope">]
    //"default" by default
    val mutable Scope: string

    [<DefaultValue>]
    [<Name "tolerance">]
    //"intersect" by default
    val mutable Tolerance: ToleranceOfDroppable


[<JavaScriptType>]    
module internal DroppableInternal =
    [<Inline "jQuery($el).droppable($conf)">]
    let internal New (el: Element, conf: DroppableConfiguration) = ()

[<JavaScriptType>]
type Droppable =

    [<JavaScriptConstructor>]
    new () = {}

    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : DroppableConfiguration

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
    [<Name "New_Droppable">]
    static member New (el : Element, conf: DroppableConfiguration): Droppable = 
        let a = new Droppable()
        a.configuration <- conf
        a.renderEvent <- new Event<RenderEvent>()
        a.element <- 
            el
            |> On Events.Attach (fun _ _ -> a.Render())
        a

    [<JavaScript>]
    [<Name "New_Droppable_Shortcut">]
    static member New (el : Element) : Droppable = 
        let conf = new DroppableConfiguration()
        Droppable.New(el, conf)


    (****************************************************************
    * Render interface
    *****************************************************************)       
       
    [<JavaScript>]
    member this.OnBeforeRender(f: unit -> unit) : unit=
        this.renderEvent.Publish
        |> Event.Iterate (fun re ->
            match re with
            | RenderEvent.Before  -> f ()
            | _                         -> ()
        )
                    
    [<JavaScript>]
    member this.OnAfterRender(f: unit -> unit) : unit=
        this.renderEvent.Publish
        |> Event.Iterate (fun re ->
            match re with
            | RenderEvent.After  -> f ()
            | _                        -> ()
        )

    [<JavaScript>]
    member this.Render() =     
        if not this.IsRendered  then
            this.renderEvent.Trigger RenderEvent.Before
            DroppableInternal.New(this.Element, this.configuration)
            this.renderEvent.Trigger RenderEvent.After
            this.isRendered <- true
    
    [<JavaScript>]
    member this.IsRendered
        with get () : bool = this.isRendered


    (****************************************************************
    * Methods
    *****************************************************************) 

    [<Inline "jQuery($this.element).droppable('destroy')">]
    member this.Destroy() = ()
            
    [<Inline "jQuery($this.element).droppable('disable')">]
    member this.Disable() = ()

    [<Inline "jQuery($this.element).droppable('enable')">]
    member this.Enable() = ()

    [<Inline "jQuery($this.element).droppable('widget')">]
    member this.Widget() = ()
    
    [<Inline "jQuery($this.element).droppable('option', $name, $value)">]
    member this.Option(optionName: string, value: obj) : unit = ()


    (****************************************************************
    * Events
    *****************************************************************) 

    [<Inline "jQuery($this.element).droppable({activate: function (x,y) {($f(x))(y.activate);}})">]
    member private this.onActivate(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).droppable({deactivate: function (x,y) {($f(x))(y.deactivate);}})">]
    member private this.onDeactivate(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).droppable({over: function (x,y) {($f(x))(y.over);}})">]
    member private this.onOver(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).droppable({out: function (x,y) {($f(x))(y.out);}})">]
    member private this.onOut(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).droppable({drop: function (x,y) {($f(x))(y.drop);}})">]
    member private this.onDrop(f : Events.EventArgs -> Element -> unit) = ()

    [<JavaScript>]
    member private this.On (f : unit -> unit) =
        if this.IsRendered then f ()
        else            
            this.OnAfterRender(fun () -> f ())

    [<JavaScript>]
    member this.OnActivate f =
        this.On (fun () -> this.onActivate f)

    [<JavaScript>]
    member this.OnDeactivate f =
        this.On (fun () -> this.onDeactivate f)

    [<JavaScript>]
    member this.OnOver f =
        this.On (fun () -> this.onOver f)

    [<JavaScript>]
    member this.OnOut f =
        this.On (fun () -> this.onOut f)

    [<JavaScript>]
    member this.OnDrop f =
        this.On (fun () -> this.onDrop f)

