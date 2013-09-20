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


type DraggablecursorAtConfiguration =
    {
        [<Name "top">]
        Top: int

        [<Name "left">]
        Left: int
    }
    [<JavaScript>]
    static member Default =
        {Top = 1; Left = 1}


type DraggableStackConfiguration =
    {
        [<Name "group">]
        Group: string

        [<Name "min">]
        Min: int
    }

    [<JavaScript>]
    static member Default =
        {Group = "prouducts"; Min = 50}


type DraggableConfiguration[<JavaScript>]() =

    [<DefaultValue>]
    val mutable disabled: bool

    [<DefaultValue>]
    //true by default
    val mutable addClasses: bool

    [<DefaultValue>]
    //"parent" by default, string of Element
    val mutable appendTo: string

    [<DefaultValue>]
    //"" by default, string of int
    val mutable axis: string

    [<DefaultValue>]
    //"" by default, string of Element
    val mutable cancel: string

    [<DefaultValue>]
    //"" by default, string of Element
    val mutable connectToSortable: string

    [<DefaultValue>]
    //"" by default, string of Element
    val mutable containment: string

    [<DefaultValue>]
    //"auto" by default
    val mutable cursor: string

    [<DefaultValue>]
    //"top=1, left=1" by default
    val mutable cursorAt: DraggablecursorAtConfiguration

    [<DefaultValue>]
    //0 by default
    val mutable delay: int

    [<DefaultValue>]
    //1 by default
    val mutable distance: int

    [<DefaultValue>]
    //0 by default
    val mutable grid: array<int>

    [<DefaultValue>]
    //"" by default, string of Element
    val mutable handle: string

    [<DefaultValue>]
    //"original" by default
    val mutable helper: string

    [<DefaultValue>]
    //false by default
    val mutable iframeFix: bool

    [<DefaultValue>]
    val mutable opacity: float

    [<DefaultValue>]
    //false by default
    val mutable refreshPositions: bool

    [<DefaultValue>]
    //false by default
    val mutable revert: bool

    [<DefaultValue>]
    //500 by default
    val mutable revertDuration: int

    [<DefaultValue>]
    //"default" by default
    val mutable scope: string

    [<DefaultValue>]
    //true by default
    val mutable scroll: bool

    [<DefaultValue>]
    //20 by default
    val mutable scrollSensitivity: int

    [<DefaultValue>]
    //20 by default
    val mutable scrollSpeed: int

    [<DefaultValue>]
    //false by default
    val mutable snap: bool

    [<DefaultValue>]
    //"both" by default
    val mutable snapMode: string

    [<DefaultValue>]
    //20 by default
    val mutable snapTolerance: int

    [<DefaultValue>]
    val mutable stack: DraggableStackConfiguration

    [<DefaultValue>]
    //2700 by default
    val mutable zIndex: int

type DraggableEvent =
    {
        [<Name "offset">]
        Offset : DraggablecursorAtConfiguration

        [<Name "originalPosition">]
        OriginalPosition : DraggablecursorAtConfiguration

        [<Name "position">]
        Position : DraggablecursorAtConfiguration

        [<Name "helper">]
        Helper : JQuery.JQuery
    }

module internal DraggableInternal =
    [<Inline "jQuery($el).draggable($conf)">]
    let internal New (el: Dom.Element, conf: DraggableConfiguration) = ()

[<Require(typeof<Dependencies.JQueryUIJs>)>]
[<Require(typeof<Dependencies.JQueryUICss>)>]
type Draggable[<JavaScript>] internal () =
    inherit Pagelet ()

    (****************************************************************
    * Constructors
    *****************************************************************)
    /// Creates a new draggabel object given an element and a
    /// configuration settings object.
    [<JavaScript>]
    [<Name "New1">]
    static member New (el : Element, conf: DraggableConfiguration): Draggable =
        let a = new Draggable()
        a.element <-
            el
            |>! OnAfterRender (fun el ->
                DraggableInternal.New(el.Body, conf)
            )
        a

    /// Creates a new draggable using the default
    /// configuration settings.
    [<JavaScript>]
    [<Name "New2">]
    static member New (el : Element) : Draggable =
        let conf = new DraggableConfiguration()
        Draggable.New(el, conf)

    (****************************************************************
    * Methods
    *****************************************************************)
    /// Removes draggable functionality completely.
    [<Inline "jQuery($this.element.Body).draggable('destroy')">]
    member this.Destroy() = ()

    /// Disables the draggable functionality.
    [<Inline "jQuery($this.element.Body).draggable('disable')">]
    member this.Disable() = ()

    /// Enables the draggable functionality.
    [<Inline "jQuery($this.element.Body).draggable('enable')">]
    member this.Enable() = ()

    /// Sets a draggable option.
    [<Inline "jQuery($this.element.Body).draggable('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Gets a draggable option.
    [<Inline "jQuery($this.element.Body).draggable('option', $name)">]
    member this.Option (name: string) = X<obj>


    [<Inline "jQuery($this.element.Body).draggable('widget')">]
    member private this.getWidget () = X<Dom.Element>

    /// Returns the .ui-draggable element.
    [<JavaScript>]
    member this.Widget = this.getWidget()


    (****************************************************************
    * Events
    *****************************************************************)

    [<Inline "jQuery($this.element.Body).bind('dragcreate', function (x,y) {($f(x))(y);})">]
    member private this.onCreate(f : JQuery.Event -> DraggableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('dragstart', function (x,y) {($f(x))(y);})">]
    member private this.onStart(f : JQuery.Event -> DraggableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('dragstop', function (x,y) {($f(x))(y);})">]
    member private this.onStop(f : JQuery.Event -> DraggableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('drag', function (x,y) {($f(x))(y);})">]
    member private this.onDrag(f : JQuery.Event -> DraggableEvent -> unit) = ()

    /// Event triggered when dragging is created.
    [<JavaScript>]
    member this.OnCreate f =
        this |> OnAfterRender(fun _ ->  this.onCreate f)

    /// Event triggered when dragging starts.
    [<JavaScript>]
    member this.OnStart f =
        this |> OnAfterRender(fun _ ->  this.onStart f)

    /// Event triggered when dragging stops.
    [<JavaScript>]
    member this.OnStop f =
        this |> OnAfterRender(fun _ -> this.onStop f)

    /// Event triggered during dragging.
    [<JavaScript>]
    member this.OnDrag f =
        this |> OnAfterRender(fun _ -> this.onDrag f)
