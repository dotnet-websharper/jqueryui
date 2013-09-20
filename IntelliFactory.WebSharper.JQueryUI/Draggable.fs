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

    [<Name "addClasses">]
    [<Stub>]
    //true by default
    member val AddClasses = Unchecked.defaultof<bool> with get, set

    [<Name "appendTo">]
    [<Stub>]
    //"parent" by default, string of Element
    member val AppendTo = Unchecked.defaultof<string> with get, set

    [<Name "axis">]
    [<Stub>]
    //"" by default, string of int
    member val Axis = Unchecked.defaultof<string> with get, set

    [<Name "cancel">]
    [<Stub>]
    //"" by default, string of Element
    member val Cancel = Unchecked.defaultof<string> with get, set

    [<Name "connectToSortable">]
    [<Stub>]
    //"" by default, string of Element
    member val ConnectToSortable = Unchecked.defaultof<string> with get, set

    [<Name "containment">]
    [<Stub>]
    //"" by default, string of Element
    member val Containment = Unchecked.defaultof<string> with get, set

    [<Name "cursor">]
    [<Stub>]
    //"auto" by default
    member val Cursor = Unchecked.defaultof<string> with get, set

    [<Name "cursorAt">]
    [<Stub>]
    //"top=1, left=1" by default
    member val CursorAt = Unchecked.defaultof<DraggablecursorAtConfiguration> with get, set

    [<Name "delay">]
    [<Stub>]
    //0 by default
    member val Delay = Unchecked.defaultof<int> with get, set

    [<Name "disabled">]
    [<Stub>]
    //false by default
    member val Disabled = Unchecked.defaultof<bool> with get, set

    [<Name "distance">]
    [<Stub>]
    //1 by default
    member val Distance = Unchecked.defaultof<int> with get, set

    [<Name "grid">]
    [<Stub>]
    //0 by default
    member val Grid = Unchecked.defaultof<int[]> with get, set

    [<Name "handle">]
    [<Stub>]
    //"" by default, string of Element
    member val Handle = Unchecked.defaultof<string> with get, set

    [<Name "helper">]
    [<Stub>]
    //"original" by default
    member val Helper = Unchecked.defaultof<string> with get, set

    [<Name "iframeFix">]
    [<Stub>]
    //false by default
    member val IframeFix = Unchecked.defaultof<bool> with get, set

    [<Name "opacity">]
    [<Stub>]
    //1 by default
    member val Opacity = Unchecked.defaultof<float> with get, set

    [<Name "refreshPositions">]
    [<Stub>]
    //false by default
    member val RefreshPositions = Unchecked.defaultof<bool> with get, set

    [<Name "revert">]
    [<Stub>]
    //false by default
    member val Revert = Unchecked.defaultof<bool> with get, set

    [<Name "revertDuration">]
    [<Stub>]
    //500 by default
    member val RevertDuration = Unchecked.defaultof<int> with get, set

    [<Name "scope">]
    [<Stub>]
    //"default" by default
    member val Scope = Unchecked.defaultof<string> with get, set

    [<Name "scroll">]
    [<Stub>]
    //true by default
    member val Scroll = Unchecked.defaultof<bool> with get, set

    [<Name "scrollSensitivity">]
    [<Stub>]
    //20 by default
    member val ScrollSensitivity = Unchecked.defaultof<int> with get, set

    [<Name "scrollSpeed">]
    [<Stub>]
    //20 by default
    member val ScrollSpeed = Unchecked.defaultof<int> with get, set

    [<Name "snap">]
    [<Stub>]
    //false by default
    member val Snap = Unchecked.defaultof<bool> with get, set

    [<Name "snapMode">]
    [<Stub>]
    //"both" by default
    member val SnapMode = Unchecked.defaultof<string> with get, set

    [<Name "snapTolerance">]
    [<Stub>]
    //20 by default
    member val SnapTolerance = Unchecked.defaultof<int> with get, set

    [<Name "stack">]
    [<Stub>]
    //
    member val Stack = Unchecked.defaultof<DraggableStackConfiguration> with get, set

    [<Name "zIndex">]
    [<Stub>]
    //2700 by default
    member val ZIndex = Unchecked.defaultof<int> with get, set

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
    member this.Destroy() = X<unit>

    /// Disables the draggable functionality.
    [<Inline "jQuery($this.element.Body).draggable('disable')">]
    member this.Disable() = X<unit>

    /// Enables the draggable functionality.
    [<Inline "jQuery($this.element.Body).draggable('enable')">]
    member this.Enable() = X<unit>

    /// Sets a draggable option.
    [<Inline "jQuery($this.element.Body).draggable('option', $name, $value)">]
    member this.Option (name: string, value: obj) = X<unit>

    /// Gets a draggable option.
    [<Inline "jQuery($this.element.Body).draggable('option', $name)">]
    member this.Option (name: string) = X<obj>

    /// Gets all options.
    [<Inline "jQuery($this.element.Body).draggable('option')">]
    member this.Option () = X<DraggableConfiguration>

    /// Sets one or more options.
    [<Inline "jQuery($this.element.Body).draggable('option', $options)">]
    member this.Option (options: DraggableConfiguration) = X<unit>

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
