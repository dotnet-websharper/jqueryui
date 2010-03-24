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
type SliderConfiguration = 

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

    [<JavaScriptConstructor>]
    new () = {}

[<JavaScriptType>]
module internal SliderInternal =
    [<Inline "jQuery($el).slider($conf)">]
    let Init(el: Element, conf: SliderConfiguration) = ()
    
[<JavaScriptType>]
type Slider = 

    [<JavaScriptConstructor>]
    new () = {}
    
    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : SliderConfiguration

    [<DefaultValue>]
    val mutable private renderEvent: Event<Utils.RenderEvent>

    [<DefaultValue>]
    val mutable private isRendered: bool

    [<JavaScript>]
    member this.Element
        with get () =
            this.element
            
    (****************************************************************
    * Constructors
    *****************************************************************) 
    [<JavaScript>]
    [<Name "New1">]
    static member New (conf: SliderConfiguration): Slider =         
        let s = new Slider()
        s.renderEvent <- new Event<Utils.RenderEvent>()
        s.configuration <- conf
        s.element <- 
            Div []
            |> On Events.Attach (fun _ _ -> s.Render())
        s
    
    [<JavaScript>]
    [<Name "New0">]
    static member New (): Slider =
        Slider.New (new SliderConfiguration())

    (****************************************************************
    * Render interface
    *****************************************************************)          
    [<JavaScript>]
    member this.OnBeforeRender(f: unit -> unit) : unit=
        this.renderEvent.Publish
        |> Event.Iterate (fun re ->
            match re with
            | Utils.RenderEvent.Before  -> f ()
            | _                         -> ()
        )
                    
    [<JavaScript>]
    member this.OnAfterRender(f: unit -> unit) : unit=
        this.renderEvent.Publish
        |> Event.Iterate (fun re ->
            match re with
            | Utils.RenderEvent.After  -> f ()
            | _                         -> ()
        )

    [<JavaScript>]
    member this.Render() =     
        if not this.IsRendered  then
            this.renderEvent.Trigger Utils.RenderEvent.Before
            SliderInternal.Init(this.Element, this.configuration)
            this.renderEvent.Trigger Utils.RenderEvent.After
            this.isRendered <- true
    
    [<JavaScript>]
    member this.IsRendered
        with get () : bool = this.isRendered

    (****************************************************************
    * Methods
    *****************************************************************) 
    [<Inline "jQuery($this.element).slider('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element).slider('disable')">]
    member this.Disable () = ()

    [<Inline "jQuery($this.element).slider('enable')">]
    member this.Enable () = ()

    [<Inline "jQuery($this.element).slider('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    [<Inline "jQuery($this.element).slider('value', $v)">]
    member private this.setValue (v: int) = ()

    [<Inline "jQuery($this.element).slider('value')">]
    member private this.getValue () = 0


    [<JavaScript>]
    member this.Value
        with get () =
            this.getValue()
        and set (v: int) =
            this.setValue v

//    [<JavaScript>]
//    member this.Values
//        with get () =
//            this.getValue()
//        and set (vs : int []) =
//            this.setValue vs

    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element).slider({start: function (x,y) {$f();}})">]
    member private this.onStart(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).slider({change: function (x,y) {$f();}})">]
    member private this.onChange(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).slider({slide: function (x,y) {$f();}})">]
    member private this.onSlide(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).slider({stop: function (x,y) {$f();}})">]
    member private this.onStop(f : unit -> unit) = ()

    [<JavaScript>]
    member private this.OnAfter (f : unit -> unit) : unit =
        if this.IsRendered then 
            f ()
        else            
            this.OnAfterRender(fun () -> f ())

    [<JavaScript>]
    member this.OnStart(f : unit -> unit) =
        this.OnAfter (fun () -> this.onStart f)

    [<JavaScript>]
    member this.OnChange(f : unit -> unit) =
        this.OnAfter (fun () -> this.onChange f)

    [<JavaScript>]
    member this.OnSlide(f : unit -> unit) =
        this.OnAfter (fun () -> this.onSlide f)

    [<JavaScript>]
    member this.OnStop(f : unit -> unit) =
        this.OnAfter (fun () -> this.onStop f)


                  


    


