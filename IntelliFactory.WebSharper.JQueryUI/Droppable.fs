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
module Droppable =
    
    [<JavaScriptType>]
    type Tolerance =     
        | [<Constant "fit">] Fit
        | [<Constant "intersect">] Intersect
        | [<Constant "pointer">] Pointer
        | [<Constant "touch">] Touch

    [<JavaScriptType>]
    type Activate =
        {
            activate: Element
        } 

    [<JavaScriptType>]
    type Deactivate =
        {
            deactivate: Element
        }

    [<JavaScriptType>]
    type Over =
        {
            over: Element
        }

    [<JavaScriptType>]
    type Out =
        {
            out: Element
        }

    [<JavaScriptType>]
    type Drop =
        {
            drop: Element
        }

    [<JavaScriptType>]
    type DroppableConfiguration = 

        [<DefaultValue>]
        val mutable activate: JavaScript.Function<Events.EventArgs, Activate, unit>

        [<DefaultValue>]
        val mutable deactivate: JavaScript.Function<Events.EventArgs, Deactivate, unit>

        [<DefaultValue>]
        val mutable over: JavaScript.Function<Events.EventArgs, Over, unit>

        [<DefaultValue>]
        val mutable out: JavaScript.Function<Events.EventArgs, Out, unit>

        [<DefaultValue>]
        val mutable drop: JavaScript.Function<Events.EventArgs, Drop, unit>
        
        [<DefaultValue>]
        [<Name "accept">]
        //"" by default
        val mutable Accept: string

        [<DefaultValue>]
        [<Name "activeClass">]
        val mutable ActiveClass: string

        [<DefaultValue>]
        [<Name "addClasses">]
        //true by default
        val mutable AddClasses: bool

        [<DefaultValue>]
        [<Name "greedy">]
        //false by default
        val mutable Greedy: bool

        [<DefaultValue>]
        [<Name "hoverClass">]
        //"drophover" by default
        val mutable HoverClass: string

        [<DefaultValue>]
        [<Name "scope">]
        //"default" by default
        val mutable Scope: string

        [<DefaultValue>]
        [<Name "tolerance">]
        //"intersect" by default
        val mutable Tolerance: Tolerance

        [<JavaScript>]
        member ui.SetActivate (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Activate) = f o s.activate
            ui.activate<- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetDeactivate (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Deactivate) = f o s.deactivate
            ui.deactivate<- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetOver (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Over) = f o s.over
            ui.over<- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetOut(f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Out) = f o s.out
            ui.out<- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetDrop(f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Drop) = f o s.drop
            ui.drop<- new JavaScript.Function<_,_,_>(fS)

        [<JavaScriptConstructor>]
        new () = {}


    [<JavaScriptType>]
    type Droppable =

        [<Inline "jQuery($id).droppable()">]
        static member NewPrivate (id: string) : Droppable = Unchecked.defaultof<_>

        [<Inline "jQuery($el).droppable()">]
        static member New (el: Element) : Droppable = Unchecked.defaultof<_>

        [<Inline "jQuery($el).droppable($conf)">]
        static member New (el: Element, conf: DroppableConfiguration) : Droppable = Unchecked.defaultof<_>

        [<Inline "$this.droppable('destroy')">]
        member this.Destroy() = ()
                
        [<Inline "$this.droppable('disable')">]
        member this.Disable() = ()

        [<Inline "$this.droppable('enable')">]
        member this.Enable() = ()
        
        [<Inline "$this.droppable('option', $optionName, $value)">]
        member this.Option(optionName: string, value: obj) : unit = ()

        [<JavaScript>]
        static member Attach (el: Element) =
            el
            |> On Events.Attach (fun _ _ -> Droppable.New (el) |> ignore)

        [<JavaScript>]
        static member AttachWithConfiguration (conf: DroppableConfiguration) (el: Element) =
            el
            |> On Events.Attach (fun _ _ -> Droppable.New (el, conf) |> ignore)



