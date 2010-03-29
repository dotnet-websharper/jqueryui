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
open Utils
    
[<JavaScriptType>]
type ResizableConfiguration = 

    [<JavaScriptConstructor>]
    new () = {}

    [<DefaultValue>]
    [<Name "alsoResize">]
    val mutable AlsoResize: string

    [<DefaultValue>]
    [<Name "animate">]
    //false by default
    val mutable Animate: bool

    [<DefaultValue>]
    [<Name "animateDuration">]
    //"slow" by default
    val mutable AnimateDuration: string

    [<DefaultValue>]
    [<Name "animateEasing">]
    //"swing" by default
    val mutable AnimateEasing: string

    [<DefaultValue>]
    [<Name "aspectRatio">]
    val mutable AspectRatio: float

    [<DefaultValue>]
    [<Name "autoHide">]
    //false by default
    val mutable AutoHide: bool

    [<DefaultValue>]
    [<Name "cancel">]
    //":input,option" by default
    val mutable Cancel: string

    [<DefaultValue>]
    [<Name "containment">]
    val mutable Containment: string

    [<DefaultValue>]
    [<Name "delay">]
    //0 by default
    val mutable Delay: int

    [<DefaultValue>]
    [<Name "distance">]
    // 1 by default
    val mutable Distance: int

    [<DefaultValue>]
    [<Name "ghost">]
    //false by default
    val mutable Ghost: bool

    [<DefaultValue>]
    [<Name "grid">]
    //Array values: [|x; y|]
    val mutable Grid: array<int>

    [<DefaultValue>]
    [<Name "handles">]
    //"e, s, se" by default
    val mutable Handles: string

    [<DefaultValue>]
    [<Name "helper">]
    val mutable Helper: string

    [<DefaultValue>]
    [<Name "maxHeight">]
    val mutable MaxHeight: int

    [<DefaultValue>]
    [<Name "maxWidth">]
    val mutable MaxWidth: int

    [<DefaultValue>]
    [<Name "minHeight">]
    val mutable MinHeight: int

    [<DefaultValue>]
    [<Name "minWidth">]
    val mutable MinWidth: int

[<JavaScriptType>]    
module internal ResizableInternal =
    [<Inline "jQuery($el).resizable($conf)">]
    let internal New (el: Element, conf: ResizableConfiguration) = ()

[<JavaScriptType>]
type Resizable = 
    
    [<JavaScriptConstructor>]
    new () = {}
    
    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : ResizableConfiguration

    [<DefaultValue>]
    val mutable private renderEvent: Event<RenderEvent>

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
    [<Name "New_Resizable">]
    static member New (el : Element, conf: ResizableConfiguration): Resizable = 
        let a = new Resizable()
        a.configuration <- conf
        a.renderEvent <- new Event<RenderEvent>()
        a.element <- 
            el
            |> On Events.Attach (fun _ _ -> a.Render())
        a

    [<JavaScript>]
    [<Name "New_Resizable_Shortcut">]
    static member New (el : Element) : Resizable = 
        let conf = new ResizableConfiguration()
        Resizable.New(el, conf)

    (****************************************************************
    * Render interface
    *****************************************************************)       
       
    [<JavaScript>]
    member this.OnBeforeRender(f: unit -> unit) : unit=
        this.renderEvent.Publish
        |> Event.Iterate (fun re ->
            match re with
            | RenderEvent.Before  -> f ()
            | _                   -> ()
        )
                    
    [<JavaScript>]
    member this.OnAfterRender(f: unit -> unit) : unit=
        this.renderEvent.Publish
        |> Event.Iterate (fun re ->
            match re with
            | RenderEvent.After  -> f ()
            | _                  -> ()
        )

    [<JavaScript>]
    member this.Render() =     
        if not this.IsRendered  then
            this.renderEvent.Trigger RenderEvent.Before
            ResizableInternal.New(this.Element, this.configuration)
            this.renderEvent.Trigger RenderEvent.After
            this.isRendered <- true
    
    [<JavaScript>]
    member this.IsRendered
        with get () : bool = this.isRendered


    (****************************************************************
    * Methods
    *****************************************************************) 

    [<Inline "jQuery($this.element).resizable('destroy')">]
    member this.Destroy() = ()
            
    [<Inline "jQuery($this.element).resizable('disable')">]
    member this.Disable() = ()

    [<Inline "jQuery($this.element).resizable('enable')">]
    member this.Enable() = ()

    [<Inline "jQuery($this.element).resizable('widget')">]
    member this.Widget() = ()
    
    [<Inline "jQuery($this.element).resizable('option', $name, $value)">]
    member this.Option(optionName: string, value: obj) : unit = ()

    (****************************************************************
    * Events
    *****************************************************************) 

    [<Inline "jQuery($this.element).resizable({start: function (x,y) {($f(x))(y.start);}})">]
    member private this.onStart(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).resizable({resize: function (x,y) {($f(x))(y.resize);}})">]
    member private this.onResize(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).resizable({stop: function (x,y) {($f(x))(y.stop);}})">]
    member private this.onStop(f : Events.EventArgs -> Element -> unit) = ()

    [<JavaScript>]
    member private this.On (f : unit -> unit) =
        if this.IsRendered then f ()
        else            
            this.OnAfterRender(fun () -> f ())

    [<JavaScript>]
    member this.OnStart f =
        this.On (fun () ->  this.onStart f)

    [<JavaScript>]
    member this.OnResize f =
        this.On (fun () -> this.onResize f)

    [<JavaScript>]
    member this.OnStop f =
        this.On (fun () -> this.onStop f)
