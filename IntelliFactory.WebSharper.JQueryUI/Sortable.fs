﻿// $begin{copyright}
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

type AxisConfiguration =
    | [<Name "X">] X
    | [<Name "Y">] Y

type ToleranceConfiguration =
    | [<Name "intersect">] Intersect
    | [<Name "Pointer">] Pointer

type SortablePosition =
    {
        [<Name "left">]
        Left : int

        [<Name "top">]
        Top : int
    }

type SortableEvent =
    {
        [<Name "helper">]
        Helper : JQuery.JQuery

        [<Name "item">]
        Item : JQuery.JQuery

        [<Name "placeholder">]
        Placeholder : JQuery.JQuery

        [<Name "offset">]
        Offset : SortablePosition

        [<Name "originalPosition">]
        OriginalPosition : SortablePosition

        [<Name "position">]
        Position : SortablePosition
    }

type SortableConfiguration[<JavaScript>]() =

    [<DefaultValue>]
    val mutable disabled: bool

    [<DefaultValue>]
    val mutable appendTo: string

    [<DefaultValue>]
    val mutable axis: AxisConfiguration

    [<DefaultValue>]
    val mutable cancel: string

    [<DefaultValue>]
    val mutable connectWith: string

    [<DefaultValue>]
    val mutable containment: string

    [<DefaultValue>]
    //"auto" by default
    val mutable cursor: string

    [<DefaultValue>]
    //Coordinates can be combination of one or two keys: {"top"; "left"; "right"; "bottom"}
    val mutable cursorAt: string

    [<DefaultValue>]
    //0 by default
    val mutable delay: int

    [<DefaultValue>]
    val mutable distance: int

    [<DefaultValue>]
    //true by default
    val mutable dropOnEmpty: bool

    [<DefaultValue>]
    //false by default
    val mutable forceHelperSize: bool

    [<DefaultValue>]
    //false by default
    val mutable forcePlaceholderSize: bool

    [<DefaultValue>]
    //array value [|x; y|]
    val mutable grid: array<int>

    [<DefaultValue>]
    val mutable handle: string

    [<DefaultValue>]
    //"original" by default, Possible values: "original", "clone"
    val mutable helper: string

    [<DefaultValue>]
    //"> *" by default
    val mutable items: string

    [<DefaultValue>]
    val mutable opacity: float

    [<DefaultValue>]
    val mutable placeholder: string

    [<DefaultValue>]
    //"false" by default
    val mutable revert: bool

    [<DefaultValue>]
    //"true" by default
    val mutable scroll: bool

    [<DefaultValue>]
    //"20" by default
    val mutable scrollSensitivity: int

    [<DefaultValue>]
    //"20" by default
    val mutable scrollSpeed: int

    [<DefaultValue>]
    //"false" by default
    val mutable tolerance: ToleranceConfiguration

    [<DefaultValue>]
    //"1000" by default
    val mutable zIndex: int

module internal SortableInternal =
    [<Inline "jQuery($el).sortable($conf)">]
    let Init (el: Dom.Element, conf: SortableConfiguration) = ()

[<Require(typeof<Dependencies.JQueryUIJs>)>]
[<Require(typeof<Dependencies.JQueryUICss>)>]
type Sortable [<JavaScript>] internal () =
    inherit Pagelet()

    (****************************************************************
    * Constructors
    *****************************************************************)
    /// Creates a new sortable object given an element and a
    /// configuration object.
    [<JavaScript>]
    [<Name "New1">]
    static member New (el: Element, conf: SortableConfiguration) : Sortable =
        let s = new Sortable()
        s.element <-
            el
            |>! OnAfterRender (fun el  ->
                SortableInternal.Init(el.Body, conf)
            )
        s

    /// Creates a new sortable given an element using
    /// the default configuration settings.
    [<JavaScript>]
    [<Name "New2">]
    static member New (el: Element) : Sortable =
        let conf = new SortableConfiguration()
        Sortable.New(el, conf)

    (****************************************************************
    * Methods
    *****************************************************************)
    /// Removes the sortable functionality.
    [<Inline "$this.sortable('destroy')">]
    member this.Destroy() = ()

    /// Disables the sortable functionality.
    [<Inline "$this.sortable('disable')">]
    member this.Disable() = ()

    /// Enables the sortable functionality.
    [<Inline "$this.sortable('enable')">]
    member this.Enable() = ()

    /// Sets sortable option.
    [<Inline "$this.sortable('option', $optionName, $value)">]
    member this.Option(optionName: string, value: obj) : unit = ()

    /// Gets sortable option.
    [<Inline "$this.sortable('option', $optionName)">]
    member this.Option(optionName: string) = box()

    [<Inline "$this.sortable('widget')">]
    member private this.getWidget() = As<Dom.Element>()

    /// Returns the .ui-sortable element.
    [<JavaScript>]
    member this.Widget = this.getWidget()


    /// Serializes the sortable's item id's into a form/ajax submittable string.
    [<Inline "$this.sortable('serialize', $options)">]
    member this.Serialize(options: obj) : unit = ()

    /// Serializes the sortable's item id's into an array of string.
    [<Inline "$this.sortable('toArray')">]
    member this.ToArray() = [||]

    /// Refreshes the sortable items. Custom trigger the
    /// reloading of all sortable items, causing new items to be recognized.
    [<Inline "$this.sortable('refresh')">]
    member this.Refresh() = ()

    /// Refresh the cached positions of the sortables' items.
    [<Inline "$this.sortable('refreshPositions')">]
    member this.RefreshPositions() = ()

    /// Cancels a change in the current sortable and reverts it back to
    /// how it was before the current sort started. Useful in the stop
    /// and receive callback functions.
    [<Inline "$this.sortable('cancel')">]
    member this.Cancel() = ()

    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element.Body).bind('sortcreate', function (x,y) {($f(x))(y);})">]
    member private this.onCreate(f : JQuery.Event -> SortableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('sortstart', function (x,y) {($f(x))(y);})">]
    member private this.onStart(f : JQuery.Event -> SortableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('sort', function (x,y) {($f(x))(y);})">]
    member private this.onSort(f : JQuery.Event -> SortableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('sortchange', function (x,y) {($f(x))(y);})">]
    member private this.onChange(f : JQuery.Event -> SortableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('sortbeforestop', function (x,y) {($f(x))(y);})">]
    member private this.onBeforeStop(f : JQuery.Event -> SortableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('sortstop', function (event,ui) {($f(event))(ui);})">]
    member private this.onStop(f : JQuery.Event -> SortableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('sortupdate', function (x,y) {($f(x))(y);})">]
    member private this.onUpdate(f : JQuery.Event -> SortableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('sortreceive', function (x,y) {($f(x))(y);})">]
    member private this.onReceive(f : JQuery.Event -> SortableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('sortremove', function (x,y) {($f(x))(y);})">]
    member private this.onRemove(f : JQuery.Event -> SortableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('sortover', function (x,y) {($f(x))(y);})">]
    member private this.onOver(f : JQuery.Event -> SortableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('sortout', function (x,y) {($f(x))(y);})">]
    member private this.onOut(f : JQuery.Event -> SortableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('sortactivate', function (x,y) {($f(x))(y);})">]
    member private this.onActivate(f : JQuery.Event -> SortableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('sortdeactivate', function (x,y) {($f(x))(y);})">]
    member private this.onDeactivate(f : JQuery.Event -> SortableEvent -> unit) = ()

    /// Event triggered triggered when sortable is created.
    [<JavaScript>]
    member this.OnCreate f =
        this |> OnAfterRender(fun _ ->  this.onCreate f)

    /// Event triggered triggered when sorting starts.
    [<JavaScript>]
    member this.OnStart f =
        this |> OnAfterRender(fun _ ->  this.onStart f)

    /// Event triggered during sorting.
    [<JavaScript>]
    member this.OnSort f =
        this |> OnAfterRender(fun _ -> this.onSort f)

    /// Event triggered during sorting, but only when the DOM position has changed.
    [<JavaScript>]
    member this.OnChange f =
        this |> OnAfterRender(fun _ -> this.onChange f)

    /// Event triggered when sorting stops, but when the placeholder/helper is still available.
    [<JavaScript>]
    member this.OnBeforeStop f =
        this |> OnAfterRender(fun _ -> this.onBeforeStop f)

    /// Event triggered when sorting has stopped.
    [<JavaScript>]
    member this.OnStop f =
        this |> OnAfterRender(fun _ -> this.onStop f)

    /// Event triggered when the user stopped sorting and the DOM position has changed.
    [<JavaScript>]
    member this.OnUpdate f =
        this |> OnAfterRender(fun _ -> this.onUpdate f)

    /// Event triggered when a connected sortable list has received an item from another list.
    [<JavaScript>]
    member this.OnReceive f =
        this |> OnAfterRender(fun _ -> this.onReceive f)

    /// Event triggered when a sortable item has been dragged out from the list and into another.
    [<JavaScript>]
    member this.OnRemove f =
        this |> OnAfterRender(fun _ -> this.onRemove f)

    /// Event triggered when a sortable item is moved into a connected list.
    [<JavaScript>]
    member this.OnOver f =
        this |> OnAfterRender(fun _ -> this.onOut f)

    /// Event triggered when using connected lists, every connected list on drag start receives it.
    [<JavaScript>]
    member this.OnActivate f =
        this |> OnAfterRender(fun _ -> this.onActivate f)

    // Event triggered when sorting was stopped, is propagated to all possible connected lists.
    [<JavaScript>]
    member this.OnDeactivate f =
        this |> OnAfterRender(fun _ -> this.onDeactivate f)