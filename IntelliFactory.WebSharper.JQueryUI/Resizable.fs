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
open IntelliFactory.WebSharper.JavaScript
open IntelliFactory.WebSharper.Html.Client

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

    [<Stub>]
    [<Name "alsoResize">]
    //
    member val AlsoResize = Unchecked.defaultof<string> with get, set

    [<Stub>]
    [<Name "animate">]
    //false by default
    member val Animate = Unchecked.defaultof<bool> with get, set

    [<Stub>]
    [<Name "animateDuration">]
    //"slow" by default
    member val AnimateDuration = Unchecked.defaultof<string> with get, set

    [<Stub>]
    [<Name "animateEasing">]
    //"swing" by default
    member val AnimateEasing = Unchecked.defaultof<string> with get, set

    [<Stub>]
    [<Name "aspectRatio">]
    //
    member val AspectRatio = Unchecked.defaultof<float> with get, set

    [<Stub>]
    [<Name "autoHide">]
    //false by default
    member val AutoHide = Unchecked.defaultof<bool> with get, set

    [<Stub>]
    [<Name "cancel">]
    //":input,option" by default
    member val Cancel = Unchecked.defaultof<string> with get, set

    [<Stub>]
    [<Name "containment">]
    //
    member val Containment = Unchecked.defaultof<string> with get, set

    [<Stub>]
    [<Name "delay">]
    //0 by default
    member val Delay = Unchecked.defaultof<int> with get, set

    [<Stub>]
    [<Name "disabled">]
    //
    member val Disabled = Unchecked.defaultof<bool> with get, set

    [<Stub>]
    [<Name "distance">]
    // 1 by default
    member val Distance = Unchecked.defaultof<int> with get, set

    [<Stub>]
    [<Name "ghost">]
    //false by default
    member val Ghost = Unchecked.defaultof<bool> with get, set

    [<Stub>]
    [<Name "grid">]
    //Array values: [|x; y|]
    member val Grid = Unchecked.defaultof<array<int>> with get, set

    [<Stub>]
    [<Name "handles">]
    //"e, s, se" by default
    member val Handles = Unchecked.defaultof<string> with get, set

    [<Stub>]
    [<Name "helper">]
    //
    member val Helper = Unchecked.defaultof<string> with get, set

    [<Stub>]
    [<Name "maxHeight">]
    //
    member val MaxHeight = Unchecked.defaultof<int> with get, set

    [<Stub>]
    [<Name "maxWidth">]
    //
    member val MaxWidth = Unchecked.defaultof<int> with get, set

    [<Stub>]
    [<Name "minHeight">]
    //
    member val MinHeight = Unchecked.defaultof<int> with get, set

    [<Stub>]
    [<Name "minWidth">]
    //
    member val MinWidth = Unchecked.defaultof<int> with get, set

module internal ResizableInternal =
    [<Inline "jQuery($el).resizable($conf)">]
    let internal New (el: Dom.Element, conf: ResizableConfiguration) = ()

[<Require(typeof<Dependencies.JQueryUIJs>)>]
[<Require(typeof<Dependencies.JQueryUICss>)>]
type Resizable[<JavaScript>] internal () =
    inherit Utils.Pagelet()

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
                ResizableInternal.New(el.Dom, conf)
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
    [<Inline "jQuery($this.element.Dom).resizable('destroy')">]
    member this.Destroy() = ()

    /// Disables resizable functionality.
    [<Inline "jQuery($this.element.Dom).resizable('disable')">]
    member this.Disable() = ()

    /// Enables resizable functionality.
    [<Inline "jQuery($this.element.Dom).resizable('enable')">]
    member this.Enable() = ()

    /// Gets a resizable option.
    [<Inline "jQuery($this.element.Dom).resizable('option', $optionName)">]
    member this.Option(optionName: string) = X<obj>

    /// Sets a resizable option.
    [<Inline "jQuery($this.element.Dom).resizable('option', $optionName, $value)">]
    member this.Option(optionName: string, value: obj) : unit = ()

    /// Gets all options.
    [<Inline "jQuery($this.element.Dom).resizable('option')">]
    member this.Option () = X<ResizableConfiguration>

    /// Sets one or more options.
    [<Inline "jQuery($this.element.Dom).resizable('option', $options)">]
    member this.Option (options: ResizableConfiguration) = X<unit>

    [<Inline "jQuery($this.element.Dom).resizable('widget')">]
    member private this.getWidget() = X<Dom.Element>

    /// Returns the .ui-resizable element.
    [<JavaScript>]
    member this.Widget = this.getWidget()


    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element.Dom).bind('resizecreate', function (x,y) {($f(x))(y);})">]
    member private this.onCreate(f : JQuery.Event -> ResizableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Dom).bind('resizestart', function (x,y) {($f(x))(y);})">]
    member private this.onStart(f : JQuery.Event -> ResizableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Dom).bind('resize', function (x,y) {($f(x))(y);})">]
    member private this.onResize(f : JQuery.Event -> ResizableEvent -> unit) = ()

    [<Inline "jQuery($this.element.Dom).bind('resizestop', function (x,y) {($f(x))(y);})">]
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
