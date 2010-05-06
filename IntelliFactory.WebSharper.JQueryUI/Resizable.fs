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
type ResizableConfiguration[<JavaScript>]() = 

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
    let internal New (el: Dom.Element, conf: ResizableConfiguration) = ()

[<JavaScriptType>]
type Resizable[<JavaScript>] internal () = 
    inherit Widget()   

    (****************************************************************
    * Constructors
    *****************************************************************)
    [<JavaScript>]
    static member New (el : Element, conf: ResizableConfiguration): Resizable = 
        let a = new Resizable()
        a.element <- 
            el |>! OnAfterRender (fun el  -> 
                ResizableInternal.New(el.Dom, conf)                    
            )
        a

    [<JavaScript>]
    static member New (el : Element) : Resizable = 
        let conf = new ResizableConfiguration()
        Resizable.New(el, conf)

    (****************************************************************
    * Methods
    *****************************************************************) 
    [<Inline "jQuery($this.element.el).resizable('destroy')">]
    member this.Destroy() = ()
            
    [<Inline "jQuery($this.element.el).resizable('disable')">]
    member this.Disable() = ()

    [<Inline "jQuery($this.element.el).resizable('enable')">]
    member this.Enable() = ()

    [<Inline "jQuery($this.element.el).resizable('widget')">]
    member this.Widget() = ()
    
    [<Inline "jQuery($this.element.el).resizable('option', $name, $value)">]
    member this.Option(optionName: string, value: obj) : unit = ()

    (****************************************************************
    * Events
    *****************************************************************) 
    [<Inline "jQuery($this.element.el).resizable({start: function (x,y) {($f(x))(y.start);}})">]
    member private this.onStart(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).resizable({resize: function (x,y) {($f(x))(y.resize);}})">]
    member private this.onResize(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).resizable({stop: function (x,y) {($f(x))(y.stop);}})">]
    member private this.onStop(f : JQueryEvent -> Element -> unit) = ()

    [<JavaScript>]
    member this.OnStart f =
        this |> OnAfterRender(fun _ ->  this.onStart f)

    [<JavaScript>]
    member this.OnResize f =
        this |> OnAfterRender(fun _ -> this.onResize f)

    [<JavaScript>]
    member this.OnStop f =
        this |> OnAfterRender(fun _ -> this.onStop f)
