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

type ToleranceOfDroppable =
    | [<Name "fit">] Fit
    | [<Name "intersect">] Intersect
    | [<Name "pointer">] Pointer
    | [<Name "touch">] Touch

type DroppableEvent =
    {
        [<Name "draggable">]
        Draggable : JQuery.JQuery

        [<Name "helper">]
        Helper : JQuery.JQuery

        [<Name "offset">]
        Offset : DraggablecursorAtConfiguration

        [<Name "position">]
        Position : DraggablecursorAtConfiguration
    }

type DroppableConfiguration[<JavaScript>]() =

    [<DefaultValue>]
    //"" by default
    val mutable accept: string

    [<DefaultValue>]
    val mutable activeClass: string

    [<DefaultValue>]
    //true by default
    val mutable addClasses: bool

    [<DefaultValue>]
    //false by default
    val mutable greedy: bool

    [<DefaultValue>]
    //"drophover" by default
    val mutable hoverClass: string

    [<DefaultValue>]
    //"default" by default
    val mutable scope: string

    [<DefaultValue>]
    //"intersect" by default
    val mutable tolerance: ToleranceOfDroppable

module internal DroppableInternal =
    [<Inline "jQuery($el).droppable($conf)">]
    let internal New (el: Dom.Element, conf: DroppableConfiguration) = ()

[<Require(typeof<Dependencies.JQueryUIJs>)>]
[<Require(typeof<Dependencies.JQueryUICss>)>]
type Droppable[<JavaScript>] internal () =
    inherit Pagelet()

    (****************************************************************
    * Constructors
    *****************************************************************)
    /// Creates a new droppable object from the given object and a
    /// configuration object.
    [<JavaScript>]
    [<Name "New1">]
    static member New (el : Element, conf: DroppableConfiguration): Droppable =
        let a = new Droppable()
        a.element <-
            el
            |>! OnAfterRender (fun el  ->
                DroppableInternal.New(el.Body, conf)
            )
        a

    /// Creates a new droppable object using the
    /// default configuration.
    [<JavaScript>]
    [<Name "New2">]
    static member New (el : Element) : Droppable =
        let conf = new DroppableConfiguration()
        Droppable.New(el, conf)

    (****************************************************************
    * Methods
    *****************************************************************)
    /// Removes droppable functionality completely.
    [<Inline "jQuery($this.element.Body).droppable('destroy')">]
    member this.Destroy() = ()

    /// Disables droppable functionality.
    [<Inline "jQuery($this.element.Body).droppable('disable')">]
    member this.Disable() = ()

    /// Enables droppable functionality.
    [<Inline "jQuery($this.element.Body).droppable('enable')">]
    member this.Enable() = ()


    /// Sets droppable option.
    [<Inline "jQuery($this.element.Body).droppable('option', $optionName, $value)">]
    member this.Option(optionName: string, value: obj) : unit = ()


    (****************************************************************
    * Events
    *****************************************************************)
    /// Event triggered any time an accepted draggable starts dragging.
    [<Inline "jQuery($this.element.Body).droppable({activate: function (x,y) {($f(x))(y);}})">]
    member private this.onActivate(f : JQuery.Event -> DroppableEvent -> unit) = ()

    /// Event triggered any time an accepted draggable stops dragging.
    [<Inline "jQuery($this.element.Body).droppable({deactivate: function (x,y) {($f(x))(y);}})">]
    member private this.onDeactivate(f : JQuery.Event -> DroppableEvent -> unit) = ()

    /// Event is triggered when an accepted draggable is dragged 'over' (within the tolerance of) this droppable.
    [<Inline "jQuery($this.element.Body).droppable({over: function (x,y) {($f(x))(y);}})">]
    member private this.onOver(f : JQuery.Event -> DroppableEvent -> unit) = ()

    /// Event triggered when an accepted draggable is dragged out (within the tolerance of) this droppable.
    [<Inline "jQuery($this.element.Body).droppable({out: function (x,y) {($f(x))(y);}})">]
    member private this.onOut(f : JQuery.Event -> DroppableEvent -> unit) = ()

    /// Event triggered when an accepted draggable is dropped 'over' (within the tolerance of) this droppable.
    [<Inline "jQuery($this.element.Body).droppable({drop: function (x,y) {($f(x))(y);}})">]
    member private this.onDrop(f : JQuery.Event -> DroppableEvent -> unit) = ()

    /// Event triggered any time an accepted draggable stops dragging.
    [<JavaScript>]
    member this.OnActivate f =
        this |> OnAfterRender(fun _ -> this.onActivate f)

    /// Event triggered any time an accepted draggable is deactivated.
    [<JavaScript>]
    member this.OnDeactivate f =
        this |> OnAfterRender(fun _ -> this.onDeactivate f)

    // Event triggered as an accepted draggable is dragged 'over' (within the tolerance of) this droppable.
    [<JavaScript>]
    member this.OnOver f =
        this |> OnAfterRender(fun _ -> this.onOver f)


    /// Event triggered when an accepted draggable is dragged out (within the tolerance of) this droppable.
    [<JavaScript>]
    member this.OnOut f =
        this |> OnAfterRender(fun _ -> this.onOut f)


    /// Event triggered when an accepted draggable is dropped 'over'
    /// (within the tolerance of) this droppable.
    [<JavaScript>]
    member this.OnDrop f =
        this |> OnAfterRender(fun _ -> this.onDrop f)

