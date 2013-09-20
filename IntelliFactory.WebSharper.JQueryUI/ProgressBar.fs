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

type ProgressbarConfiguration[<JavaScript>]() =

    [<DefaultValue>]
    val mutable disabled: bool

    [<DefaultValue>]
    //0 by default
    val mutable value: int

module internal ProgressbarInternal =
    [<Inline "jQuery($el).progressbar($conf)">]
    let Init (el: Dom.Element, conf: ProgressbarConfiguration) = ()

[<Require(typeof<Dependencies.JQueryUIJs>)>]
[<Require(typeof<Dependencies.JQueryUICss>)>]
type Progressbar[<JavaScript>]internal () =
    inherit Pagelet()

    (****************************************************************
    * Constructors
    *****************************************************************)
    /// Creates a new progressbar given an element and a
    /// configuration object.
    [<JavaScript>]
    [<Name "New1">]
    static member New (el: Element, conf: ProgressbarConfiguration) =
        let pb = new Progressbar()
        pb.element <- el
        el
        |> OnAfterRender (fun el  ->
            ProgressbarInternal.Init(el.Body, conf)
        )
        pb

    /// Creates a new progressbar given an element using
    /// the default configuration.
    [<JavaScript>]
    [<Name "New2">]
    static member New (el: Element) =
        Progressbar.New(el, new ProgressbarConfiguration())


    /// Creates a new progressbar based on an
    /// empty Div element and the given a configuration object.
    [<JavaScript>]
    [<Name "New3">]
    static member New ( conf: ProgressbarConfiguration) =
        Progressbar.New(Div [], conf)

    /// Creates a new progressbar based on an empty Div element
    /// and the default configuration.
    [<JavaScript>]
    [<Name "New4">]
    static member New () =
        Progressbar.New(Div [], new ProgressbarConfiguration())

    (****************************************************************
    * Methods
    *****************************************************************)
    /// Removes the progressbar functionality completely.
    [<Inline "jQuery($this.element.Body).progressbar('destroy')">]
    member this.Destroy() = ()

    /// Disables the progressbar functionality.
    [<Inline "jQuery($this.element.Body).progressbar('disable')">]
    member this.Disable () = ()

    /// Enables the progressbar functionality.
    [<Inline "jQuery($this.element.Body).progressbar('enable')">]
    member this.Enable () = ()

    /// Sets a progressbar option.
    [<Inline "jQuery($this.element.Body).progressbar('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Gets a progressbar option.
    [<Inline "jQuery($this.element.Body).progressbar('option', $name)">]
    member this.Option (name: string) = X<obj>

    [<Inline "jQuery($this.element.Body).progressbar('widget')">]
    member private this.getWidget () = X<Dom.Element>

    /// Returns the .ui-progressbar element.
    [<JavaScript>]
    member this.Widget = this.getWidget()

    /// Sets the value of the progressbar.
    [<Inline "jQuery($this.element.Body).progressbar('value', $v)">]
    member private this.setValue (v: int) = ()

    /// Gets the value of the progressbar.
    [<Inline "jQuery($this.element.Body).progressbar('value')">]
    member private this.getValue () = 0

    /// Gets or sets the value of the progressbar.
    [<JavaScript>]
    member this.Value
        with get () =
            this.getValue()
        and set (v: int) =
            this.setValue v

    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element.Body).bind('accordioncreate', function (x,y) {$f(x);})">]
    member private this.onCreate(f : JQuery.Event -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('accordionchange', function (x,y) {$f(x);})">]
    member private this.onChange(f : JQuery.Event -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('accordioncomplete', function (x,y) {$f(x);})">]
    member private this.onComplete(f : JQuery.Event -> unit) = ()

    /// Event triggered when the progressbar is created.
    [<JavaScript>]
    member this.OnCreate(f : JQuery.Event -> unit) =
        this |> OnAfterRender(fun _ ->
            this.onCreate f
        )

    /// Event triggered when the value of the progressbar changes.
    [<JavaScript>]
    member this.OnChange(f : JQuery.Event -> unit) =
        this |> OnAfterRender(fun _ ->
            this.onChange f
        )

    /// This event is triggered when the value of the progressbar reaches the maximum value of 100.
    [<JavaScript>]
    member this.OnComplete(f : JQuery.Event -> unit) =
        this |> OnAfterRender(fun _ ->
            this.onComplete f
        )
