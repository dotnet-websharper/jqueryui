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

type ResizablePosition =
    {
        [<Name "left">]
        Left : int

        [<Name "top">]
        Top : int
    }

type ResizableSize =
    {
        [<Name "width">]
        Width : int

        [<Name "height">]
        Height : int
    }

type ResizableEvent =
    {
        [<Name "element">]
        Element : JQuery.JQuery

        [<Name "helper">]
        Helper : JQuery.JQuery

        [<Name "originalElement">]
        OriginalElement : JQuery.JQuery

        [<Name "originalPosition">]
        OriginalPosition : ResizablePosition

        [<Name "position">]
        Position : ResizablePosition

        [<Name "originalSize">]
        OriginalSize : ResizableSize

        [<Name "size">]
        Size : ResizableSize
    }

type ResizableConfiguration[<JavaScript>]() =

    [<DefaultValue>]
    val mutable disabled: bool

    [<DefaultValue>]
    val mutable alsoResize: string

    [<DefaultValue>]
    //false by default
    val mutable animate: bool

    [<DefaultValue>]
    //"slow" by default
    val mutable animateDuration: string

    [<DefaultValue>]
    //"swing" by default
    val mutable animateEasing: string

    [<DefaultValue>]
    val mutable aspectRatio: float

    [<DefaultValue>]
    //false by default
    val mutable autoHide: bool

    [<DefaultValue>]
    //":input,option" by default
    val mutable cancel: string

    [<DefaultValue>]
    val mutable containment: string

    [<DefaultValue>]
    //0 by default
    val mutable delay: int

    [<DefaultValue>]
    // 1 by default
    val mutable distance: int

    [<DefaultValue>]
    //false by default
    val mutable ghost: bool

    [<DefaultValue>]
    //Array values: [|x; y|]
    val mutable grid: array<int>

    [<DefaultValue>]
    //"e, s, se" by default
    val mutable handles: string

    [<DefaultValue>]
    val mutable helper: string

    [<DefaultValue>]
    val mutable maxHeight: int

    [<DefaultValue>]
    val mutable maxWidth: int

    [<DefaultValue>]
    val mutable minHeight: int

    [<DefaultValue>]
    val mutable minWidth: int

module internal ResizableInternal =
    [<Inline "jQuery($el).resizable($conf)">]
    let internal New (el: Dom.Element, conf: ResizableConfiguration) = ()

[<Require(typeof<Dependencies.JQueryUIJs>)>]
[<Require(typeof<Dependencies.JQueryUICss>)>]
type Resizable[<JavaScript>] internal () =
    inherit Pagelet()

    (****************************************************************
    * Constructors
    *****************************************************************)
    /// Creates a new resizable object given an element and a
    /// configuration object.
    [<JavaScript>]
    [<Name "New1">]
    static member New (el : Element, conf: ResizableConfiguration): Resizable =
        let a = new Resizable()
        a.element <-
            el |>! OnAfterRender (fun el  ->
                ResizableInternal.New(el.Body, conf)
            )
        a

    /// Creates a new resizable object using the default
    /// configuration object.
    [<JavaScript>]
    [<Name "New2">]
    static member New (el : Element) : Resizable =
        let conf = new ResizableConfiguration()
        Resizable.New(el, conf)

    (****************************************************************
    * Methods
    *****************************************************************)
    /// Removes resizable functionality.
    [<Inline "jQuery($this.element.Body).resizable('destroy')">]
    member this.Destroy() = ()

    /// Disables resizable functionality.
    [<Inline "jQuery($this.element.Body).resizable('disable')">]
    member this.Disable() = ()

    /// Enables resizable functionality.
    [<Inline "jQuery($this.element.Body).resizable('enable')">]
    member this.Enable() = ()

    /// Gets a resizable option.
    [<Inline "jQuery($this.element.Body).resizable('option', $optionName)">]
    member this.Option(optionName: string) = X<obj>

    /// Sets a resizable option.
    [<Inline "jQuery($this.element.Body).resizable('option', $optionName, $value)">]
    member this.Option(optionName: string, value: obj) : unit = ()

    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element.Body).bind('resizecreate', function (x,y) {($f(x))(y);})">]
    member private this.onCreate(f : JQuery.Event -> ResizableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('resizestart', function (x,y) {($f(x))(y);})">]
    member private this.onStart(f : JQuery.Event -> ResizableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('resize', function (x,y) {($f(x))(y);})">]
    member private this.onResize(f : JQuery.Event -> ResizableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('resizestop', function (x,y) {($f(x))(y);})">]
    member private this.onStop(f : JQuery.Event -> ResizableEvent -> unit) = ()

    /// Event triggered at the creation of a resizable.
    [<JavaScript>]
    member this.OnCreate f =
        this |> OnAfterRender(fun _ ->  this.onCreate f)

    /// Event triggered at the start of a resize operation.
    [<JavaScript>]
    member this.OnStart f =
        this |> OnAfterRender(fun _ ->  this.onStart f)

    /// Event triggered during resizing.
    [<JavaScript>]
    member this.OnResize f =
        this |> OnAfterRender(fun _ -> this.onResize f)

    /// Event triggered at the end of a resize operation.
    [<JavaScript>]
    member this.OnStop f =
        this |> OnAfterRender(fun _ -> this.onStop f)
