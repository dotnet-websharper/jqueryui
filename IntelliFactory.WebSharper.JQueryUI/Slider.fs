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
    
[<JavaScriptType>]
type SliderConfiguration[<JavaScript>] internal() = 

    [<DefaultValue>]
    [<Name "animate">]
    //false by default
    val mutable Animate: bool

    [<DefaultValue>]
    [<Name "max">]
    //100 by default
    val mutable Max: int

    [<DefaultValue>]
    [<Name "min">]
    //0 by default
    val mutable Min: int

    [<DefaultValue>]
    [<Name "orientation">]
    //"horizontal" by default
    val mutable Orientation: string

    [<DefaultValue>]
    [<Name "rang">]
    val mutable Rang: string

    [<DefaultValue>]
    [<Name "step">]
    //1 by default
    val mutable Step: int

    [<DefaultValue>]
    [<Name "value">]
    //0 by default
    val mutable Value: int

    [<DefaultValue>]
    [<Name "values">]
    //0 by default
    val mutable Values: array<int>


[<JavaScriptType>]
module internal SliderInternal =
    [<Inline "jQuery($el).slider($conf)">]
    let Init(el: Dom.Element, conf: SliderConfiguration) = ()
    
[<JavaScriptType>]
type Slider[<JavaScript>] internal () =     
    inherit Widget()
                        
    (****************************************************************
    * Constructors
    *****************************************************************) 
    /// Creates a new slider given a configuration object.
    [<JavaScript>]
    static member New (conf: SliderConfiguration): Slider =         
        let s = new Slider()
        s.element <- 
            Div []
            |>! OnAfterRender (fun el  -> 
                SliderInternal.Init(el.Dom, conf)
            )
        s
    
    /// Creates a new slider using the default configuration
    /// settings.
    [<JavaScript>]
    static member New (): Slider =
        Slider.New (new SliderConfiguration())

    (****************************************************************
    * Methods
    *****************************************************************) 
    /// Removes the slider functionality completly.
    [<Inline "jQuery($this.element.el).slider('destroy')">]
    member this.Destroy() = ()

    /// Disables the slider functionality.
    [<Inline "jQuery($this.element.el).slider('disable')">]
    member this.Disable () = ()

    /// Enables the slider functionality.
    [<Inline "jQuery($this.element.el).slider('enable')">]
    member this.Enable () = ()

    /// Sets a slider option.
    [<Inline "jQuery($this.element.el).slider('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    [<Inline "jQuery($this.element.el).slider('value', $v)">]
    member private this.setValue (v: int) = ()

    [<Inline "jQuery($this.element.el).slider('value')">]
    member private this.getValue () = 0

    /// Gets or sets the slider value.
    [<JavaScript>]
    member this.Value
        with get () =
            this.getValue()
        and set (v: int) =
            this.setValue v

    (****************************************************************
    * Events
    *****************************************************************)
    
    [<Inline "jQuery($this.element.el).slider({start: function (x,y) {$f(x);}})">]
    member private this.onStart(f : JQueryEvent -> unit) = ()

    
    [<Inline "jQuery($this.element.el).slider({change: function (x,y) {$f(x);}})">]
    member private this.onChange(f : JQueryEvent -> unit) = ()

    
    [<Inline "jQuery($this.element.el).slider({slide: function (x,y) {$f(x);}})">]
    member private this.onSlide(f : JQueryEvent -> unit) = ()

    
    [<Inline "jQuery($this.element.el).slider({stop: function (x,y) {$f(x);}})">]
    member private this.onStop(f : JQueryEvent -> unit) = ()


    /// Event triggered when the user starts sliding.
    [<JavaScript>]
    member this.OnStart(f : JQueryEvent -> unit) =
        this |> OnAfterRender (fun _ -> this.onStart f)

    /// Event triggered when the slider changes.
    [<JavaScript>]
    member this.OnChange(f : JQueryEvent -> unit) =
        this |> OnAfterRender (fun _ -> this.onChange f)

    /// Event triggered on every mouse move during slide.
    [<JavaScript>]
    member this.OnSlide(f : JQueryEvent -> unit) =
        this |> OnAfterRender (fun _ -> this.onSlide f)

    /// Event triggered when the user stops sliding.
    [<JavaScript>]
    member this.OnStop(f : JQueryEvent -> unit) =
        this |> OnAfterRender (fun _ -> this.onStop f)


                  


    


