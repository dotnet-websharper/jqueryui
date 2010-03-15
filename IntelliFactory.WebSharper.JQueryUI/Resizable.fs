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
//[<Require(typeof<Dependencies.Carousel>)>]
module Resizable =

    [<JavaScriptType>]
    type Start = 
        {
            start: Element
        }

    [<JavaScriptType>]
    type Stop = 
        {
            stop: Element
        }

    [<JavaScriptType>]
    type Resize =
        {
            resize: Element
        }
    
    [<JavaScriptType>]
    type ResizableConfiguration = 
        
        [<DefaultValue>]
        val mutable start: JavaScript.Function<Events.EventArgs, Start, unit>

        [<DefaultValue>]
        val mutable stop: JavaScript.Function<Events.EventArgs, Stop, unit>

        [<DefaultValue>]
        val mutable resize: JavaScript.Function<Events.EventArgs, Resize, unit>

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

        [<JavaScript>]
        member ui.SetStart (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Start) = f o s.start
            ui.start    <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetStop (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Stop) = f o s.stop
            ui.stop    <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetResize(f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Resize) = f o s.resize
            ui.resize   <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScriptConstructor>]
        new () = {}

    [<JavaScriptType>]
    type Resizable = 
        
        [<Inline "jQuery($id).resizable()">]
        static member NewPrivate (id: string) : Resizable = Unchecked.defaultof<_>

        [<Inline "jQuery($el).resizable()">]
        static member New (el: Element) : Resizable = Unchecked.defaultof<_>

        [<Inline "jQuery($el).resizable($conf)">]
        static member New (el: Element, conf: ResizableConfiguration) : Resizable = Unchecked.defaultof<_>

        [<Inline "$this.resizable('destroy')">]
        member this.Destroy() = ()
                
        [<Inline "$this.resizable('disable')">]
        member this.Disable() = ()

        [<Inline "$this.resizable('enable')">]
        member this.Enable() = ()

        [<Inline "$this.resizable('option', $optionName, $value)">]
        member this.Option(optionName: string, value: obj) : unit = ()

        [<JavaScript>]
        static member Attach (el: Element) =
            el
            |> On Events.Attach (fun _ _ -> Resizable.New (el) |> ignore)

        [<JavaScript>]
        static member AttachWithConfiguration (conf: ResizableConfiguration) (el: Element) =
            el
            |> On Events.Attach (fun _ _ -> Resizable.New (el, conf) |> ignore)