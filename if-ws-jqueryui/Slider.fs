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

    [<DefaultValue>]
    //false by default
    val mutable animate: bool

    [<DefaultValue>]
    //100 by default
    val mutable max: int

    [<DefaultValue>]
    //0 by default
    val mutable min: int

    [<DefaultValue>]
    //"horizontal" by default
    val mutable orientation: string

    [<DefaultValue>]
    val mutable range: obj

    [<DefaultValue>]
    //1 by default
    val mutable step: int

    [<DefaultValue>]
    //0 by default
    val mutable value: int

    [<DefaultValue>]
    //0 by default
    val mutable values: array<int>

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

    [<Inline "jQuery($this.element.Body).slider({start: function (x,y) {$f(x);}})">]
    member private this.onStart(f : JQuery.Event -> unit) = ()


    [<Inline "jQuery($this.element.Body).slider({change: function (x,y) {$f(x);}})">]
    member private this.onChange(f : JQuery.Event -> unit) = ()


    [<Inline "jQuery($this.element.Body).slider({slide: function (x,y) {$f(x);}})">]
    member private this.onSlide(f : JQuery.Event -> unit) = ()


    [<Inline "jQuery($this.element.Body).slider({stop: function (x,y) {$f(x);}})">]
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








