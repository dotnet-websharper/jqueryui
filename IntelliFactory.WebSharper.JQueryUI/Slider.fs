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


type SliderConfiguration[<JavaScript>] () =

    [<Name "animate">]
    [<Stub>]
    //false by default
    member val Animate = Unchecked.defaultof<bool> with get, set

    [<Name "disabled">]
    [<Stub>]
    member val Disabled = Unchecked.defaultof<bool> with get, set

    [<Name "max">]
    [<Stub>]
    //100 by default
    member val Max = Unchecked.defaultof<int> with get, set

    [<Name "min">]
    [<Stub>]
    //0 by default
    member val Min = Unchecked.defaultof<int> with get, set

    [<Name "orientation">]
    [<Stub>]
    //"horizontal" by default
    member val Orientation = Unchecked.defaultof<string> with get, set

    [<Name "range">]
    [<Stub>]
    member val Range = Unchecked.defaultof<obj> with get, set

    [<Name "step">]
    [<Stub>]
    //1 by default
    member val Step = Unchecked.defaultof<int> with get, set

    [<Name "value">]
    [<Stub>]
    //0 by default
    member val Value = Unchecked.defaultof<int> with get, set

    [<Name "values">]
    [<Stub>]
    //0 by default
    member val Values = Unchecked.defaultof<array<int>> with get, set

module internal SliderInternal =
    [<Inline "jQuery($el).slider($conf)">]
    let Init(el: Dom.Element, conf: SliderConfiguration) = ()


[<Require(typeof<Dependencies.JQueryUIJs>)>]
[<Require(typeof<Dependencies.JQueryUICss>)>]
type Slider[<JavaScript>] internal () =
    inherit Pagelet()

    (****************************************************************
    * Constructors
    *****************************************************************)
    /// Creates a new slider given a configuration object.
    [<JavaScript>]
    [<Name "New1">]
    static member New (conf: SliderConfiguration): Slider =
        let s = new Slider()
        s.element <-
            Div []
            |>! OnAfterRender (fun el  ->
                SliderInternal.Init(el.Body, conf)
            )
        s

    /// Creates a new slider using the default configuration
    /// settings.
    [<JavaScript>]
    [<Name "New2">]
    static member New (): Slider =
        Slider.New (new SliderConfiguration())

    (****************************************************************
    * Methods
    *****************************************************************)
    /// Removes the slider functionality completly.
    [<Inline "jQuery($this.element.Body).slider('destroy')">]
    member this.Destroy() = ()

    /// Disables the slider functionality.
    [<Inline "jQuery($this.element.Body).slider('disable')">]
    member this.Disable () = ()

    /// Enables the slider functionality.
    [<Inline "jQuery($this.element.Body).slider('enable')">]
    member this.Enable () = ()

    /// Sets a slider option.
    [<Inline "jQuery($this.element.Body).slider('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Gets a slider option.
    [<Inline "jQuery($this.element.Body).slider('option', $name)">]
    member this.Option (name: string) = X<obj>

    [<Inline "jQuery($this.element.Body).slider('widget')">]
    member private this.getWidget () = X<Dom.Element>

    /// Returns the .ui-slider element.
    [<JavaScript>]
    member this.Widget = this.getWidget()

    [<Inline "jQuery($this.element.Body).slider('value', $v)">]
    member private this.setValue (v: int) = ()

    [<Inline "jQuery($this.element.Body).slider('value')">]
    member private this.getValue () = 0

    [<Inline "jQuery($this.element.Body).slider('values', $v)">]
    member private this.setValues (v: int []) = ()

    [<Inline "jQuery($this.element.Body).slider('values')">]
    member private this.getValues () : int [] = [||]



    /// Gets or sets the slider value.
    [<JavaScript>]
    member this.Value
        with get () =
            this.getValue()
        and set (v: int) =
            this.setValue v

    /// Gets or sets the slider value.
    [<JavaScript>]
    member this.Values
        with get () =
            this.getValues()
        and set (v: int []) =
            this.setValues v

    (****************************************************************
    * Events
    *****************************************************************)

    [<Inline "jQuery($this.element.Body).bind('slidercreate', function (x,y) {$f(x);})">]
    member private this.onCreate(f : JQuery.Event -> unit) = ()


    [<Inline "jQuery($this.element.Body).bind('sliderstart', function (x,y) {$f(x);})">]
    member private this.onStart(f : JQuery.Event -> unit) = ()


    [<Inline "jQuery($this.element.Body).bind('sliderchange', function (x,y) {$f(x);})">]
    member private this.onChange(f : JQuery.Event -> unit) = ()


    [<Inline "jQuery($this.element.Body).bind('sliderslide', function (x,y) {$f(x);})">]
    member private this.onSlide(f : JQuery.Event -> unit) = ()


    [<Inline "jQuery($this.element.Body).bind('sliderstop', function (x,y) {$f(x);})">]
    member private this.onStop(f : JQuery.Event -> unit) = ()


    /// Event triggered when the user starts sliding.
    [<JavaScript>]
    member this.OnStart(f : JQuery.Event -> unit) =
        this |> OnAfterRender (fun _ -> this.onStart f)

    /// Event triggered when the slider changes.
    [<JavaScript>]
    member this.OnChange(f : JQuery.Event -> unit) =
        this |> OnAfterRender (fun _ -> this.onChange f)

    /// Event triggered on every mouse move during slide.
    [<JavaScript>]
    member this.OnSlide(f : JQuery.Event -> unit) =
        this |> OnAfterRender (fun _ -> this.onSlide f)

    /// Event triggered when the user stops sliding.
    [<JavaScript>]
    member this.OnStop(f : JQuery.Event -> unit) =
        this |> OnAfterRender (fun _ -> this.onStop f)








