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


type ToleranceOfSelectable =
    | [<Name "fit">] Fit
    | [<Name "touch">] Touch


type SelectableConfiguration[<JavaScript>]() =


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



module internal SelectableInternal =
    [<Inline "jQuery($el).selectable($conf)">]
    let internal New (el: Dom.Element, conf: SelectableConfiguration) = ()


[<Require(typeof<Resources.JQueryUI>)>]
type Selectable[<JavaScript>] internal () =
    inherit Pagelet()


    (****************************************************************
    * Constructors
    *****************************************************************)
    /// Creates a new selectable object given an element and
    /// a configuration object.
    [<JavaScript>]
    [<Name "New1">]
    static member New (el : Element, conf: SelectableConfiguration): Selectable =
        let a = new Selectable()
        a.element <-
            el |>! OnAfterRender (fun el  ->
                SelectableInternal.New(el.Body, conf)
            )
        a

    /// Creates a new selectable object using the default
    /// configuration.
    [<JavaScript>]
    [<Name "New2">]
    static member New (el : Element) : Selectable =
        let conf = new SelectableConfiguration()
        Selectable.New(el, conf)

    (****************************************************************
    * Methods
    *****************************************************************)
    /// Removes the selectable functionality.
    [<Inline "jQuery($this.element.Body).selectable('destroy')">]
    member this.Destroy() = ()

    /// Disables the selectable functionality.
    [<Inline "jQuery($this.element.Body).selectable('disable')">]
    member this.Disable() = ()

    /// Enables the selectable functionality.
    [<Inline "jQuery($this.element.Body).selectable('enable')">]
    member this.Enable() = ()

    /// Refreshes the position and size of each selectee element.
    /// This method can be used to manually recalculate the position
    // and size of each selectee element.
    [<Inline "jQuery($this.element.Body).selectable('refresh')">]
    member this.Refresh() = ()

    /// Sets selectable option.
    [<Inline "jQuery($this.element.Body).selectable('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element.Body).selectable({selected: function (x,y) {($f(x))(y.selected);}})">]
    member private this.onSelected(f : JQuery.Event -> Element -> unit) = ()

    [<Inline "jQuery($this.element.Body).selectable({selecting: function (x,y) {($f(x))(y.selecting);}})">]
    member private this.onSelecting(f : JQuery.Event -> Element -> unit) = ()

    [<Inline "jQuery($this.element.Body).selectable({start: function (x,y) {($f(x))(y.start);}})">]
    member private this.onStart(f : JQuery.Event -> Element -> unit) = ()

    [<Inline "jQuery($this.element.Body).selectable({stop: function (x,y) {($f(x))(y.stop);}})">]
    member private this.onStop(f : JQuery.Event -> Element -> unit) = ()

    [<Inline "jQuery($this.element.Body).selectable({unselected: function (x,y) {($f(x))(y.unselected);}})">]
    member private this.onUnselected(f : JQuery.Event -> Element -> unit) = ()

    [<Inline "jQuery($this.element.Body).selectable({unselecting: function (x,y) {($f(x))(y.unselecting);}})">]
    member private this.onUnselecting(f : JQuery.Event -> Element -> unit) = ()


    /// Event triggered at the end of the select operation,
    /// on each element added to the selection.
    [<JavaScript>]
    member this.OnSelected(f : JQuery.Event -> Element -> unit) =
        this |> OnAfterRender(fun _ ->  this.onSelected f)

    /// Event triggered during the select operation,
    /// on each element added to the selection.
    [<JavaScript>]
    member this.OnSelecting(f : JQuery.Event -> Element -> unit) =
        this |> OnAfterRender(fun _ -> this.onSelecting f)

    /// Event triggered at the beginning of the select operation.
    [<JavaScript>]
    member this.OnStart(f : JQuery.Event -> Element -> unit) =
        this |> OnAfterRender(fun _ -> this.onStart f)

    /// Event triggered at the end of the select operation.
    [<JavaScript>]
    member this.OnStop(f : JQuery.Event -> Element -> unit) =
        this |> OnAfterRender(fun _ -> this.onStop f)

    /// Event is triggered at the end of the select operation,
    /// on each element removed from the selection.
    [<JavaScript>]
    member this.OnUnselected(f : JQuery.Event -> Element -> unit) =
        this |> OnAfterRender(fun _ ->  this.onUnselected f)

    /// Event triggered during the select operation,
    /// on each element removed from the selection.
    [<JavaScript>]
    member this.OnUnselecting(f : JQuery.Event -> Element -> unit) =
        this |> OnAfterRender(fun _ -> this.onUnselecting f)