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
module Selectable =

    [<JavaScriptType>]
    type Tolerance =     
        | [<Constant "fit">] Fit
        | [<Constant "touch">] Touch

    [<JavaScriptType>]
    type Selected =
        {
            selected: Element
        }
    
    [<JavaScriptType>]
    type Unselected = 
        {
            unselected: Element
        }

    [<JavaScriptType>]
    type Selecting = 
        {
            selecting: Element
        }

    [<JavaScriptType>]
    type Unselecting = 
        {
            unselecting: Element
        }

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

//    [<JavaScriptType>]
//    type SelectedFunction = delegate of obj * Selected -> unit
//
//    [<JavaScriptType>]
//    type UnselectedFunction = delegate of obj * Unselected -> unit
//
//    [<JavaScriptType>]
//    type SelectingFunction = delegate of obj * Selecting -> unit
//
//    [<JavaScriptType>]
//    type UnselectingFunction = delegate of obj * Unselecting -> unit
//
//    [<JavaScriptType>]
//    type SelectableStartFunction = delegate of obj * SelectableStart -> unit
//
//    [<JavaScriptType>]
//    type SelectableStopFunction = delegate of obj * SelectableStop -> unit

    [<JavaScriptType>]
    type SelectableConfiguration = 

        [<DefaultValue>]
        val mutable selected: JavaScript.Function<Events.EventArgs, Selected, unit>
        //val mutable selected: obj * Selected -> unit

        [<DefaultValue>]
        val mutable unselected: JavaScript.Function<Events.EventArgs, Unselected, unit>

        [<DefaultValue>]
        val mutable selecting: JavaScript.Function<Events.EventArgs, Selecting, unit>

        [<DefaultValue>]
        val mutable unselecting: JavaScript.Function<Events.EventArgs, Unselecting, unit>

        [<DefaultValue>]
        val mutable start: JavaScript.Function<Events.EventArgs, Start, unit>

        [<DefaultValue>]
        val mutable stop: JavaScript.Function<Events.EventArgs, Stop, unit>

        [<DefaultValue>]
        [<Name "autoRefresh">]
        //true by default
        val mutable AutoRefresh: bool

        [<DefaultValue>]
        [<Name "cancel">]
        //":input,option"
        val mutable Cancel: string

        [<DefaultValue>]
        [<Name "delay">]
        //0 by default
        val mutable Delay: int

        [<DefaultValue>]
        [<Name "distance">]
        //0 by default
        val mutable Distance: int

        [<DefaultValue>]
        [<Name "filter">]
        //"*" by default
        val mutable Filter: string

        [<DefaultValue>]
        [<Name "tolerance">]
        //"*" by default
        val mutable Tolerance: Tolerance

        [<JavaScript>]
        member ui.SetSelected (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Selected) = f o s.selected 
            ui.selected    <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetUnselected (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Unselected) = f o s.unselected 
            ui.unselected    <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetSelecting (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Selecting) = f o s.selecting
            ui.selecting    <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetUnselecting (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Unselecting) = f o s.unselecting
            ui.unselecting    <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetStart (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Start) = f o s.start
            ui.start   <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetStop (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Stop) = f o s.stop
            ui.stop   <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScriptConstructor>]
        new () = {}


    [<JavaScriptType>]
    type Selectable = 
        
        [<Inline "jQuery($id).selectable()">]
        static member NewPrivate (id: string) : Selectable = Unchecked.defaultof<_>

        [<Inline "jQuery($el).selectable()">]
        static member New (el: Element) : Selectable = Unchecked.defaultof<_>

        [<Inline "jQuery($el).selectable($conf)">]
        static member New (el: Element, conf: SelectableConfiguration) : Selectable = Unchecked.defaultof<_>

        [<Inline "$this.selectable('destroy')">]
        member this.Destroy() = ()
                
        [<Inline "$this.selectable('disable')">]
        member this.Disable() = ()

        [<Inline "$this.selectable('enable')">]
        member this.Enable() = ()

        [<Inline "$this.selectable('refresh')">]
        member this.Refresh() = ()

        [<Inline "$this.selectable('option', $optionName, $value)">]
        member this.Option(optionName: string, value: obj) : unit = ()

        [<JavaScript>]
        static member Attach (el: Element) =
            el
            |> On Events.Attach (fun _ _ -> Selectable.New (el) |> ignore)

        [<JavaScript>]
        static member AttachWithConfiguration (conf: SelectableConfiguration) (el: Element) =
            el
            |> On Events.Attach (fun _ _ -> Selectable.New (el, conf) |> ignore)
