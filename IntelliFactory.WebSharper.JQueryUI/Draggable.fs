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
module Draggable =
    
    [<JavaScriptType>]
    type DraggablecursorAtConfiguration = 
        {
            [<Name "top">]
            Top: int

            [<Name "left">]
            Left: int
        }
        [<JavaScript>]
        static member Default = 
            {Top = 1; Left = 1}

    [<JavaScriptType>]
    type DraggableStackConfiguration = 
        {
            [<Name "group">]
            Group: string

            [<Name "min">]
            Min: int
        }

        [<JavaScript>]
        static member Default = 
            {Group = "prouducts"; Min = 50}

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
    type Drag =
        {
            drag: Element
        }


    [<JavaScriptType>]
    type DraggableConfiguration = 

        [<DefaultValue>]
        val mutable start: JavaScript.Function<Events.EventArgs, Start, unit>

        [<DefaultValue>]
        val mutable stop: JavaScript.Function<Events.EventArgs, Stop, unit>

        [<DefaultValue>]
        val mutable drag: JavaScript.Function<Events.EventArgs, Drag, unit>

        [<DefaultValue>]
        [<Name "addClasses">]
        //true by default
        val mutable AddClasses: bool 
        
        [<DefaultValue>]
        [<Name "appendTo">]
        //"parent" by default, string of Element
        val mutable AppendTo: string
        
        [<DefaultValue>]
        [<Name "axis">]
        //"" by default, string of int
        val mutable Axis: string
        
        [<DefaultValue>]
        [<Name "cancel">]
        //"" by default, string of Element
        val mutable Cancel: string
        
        [<DefaultValue>]
        [<Name "connectToSortable">]
        //"" by default, string of Element
        val mutable ConnectToSortable: string
        
        [<DefaultValue>]
        [<Name "containment">]
        //"" by default, string of Element
        val mutable Containment: string
        
        [<DefaultValue>]
        [<Name "cursor">]
        //"auto" by default
        val mutable Cursor: string
        
        [<DefaultValue>]
        [<Name "cursorAt">]
        //"top=1, left=1" by default
        val mutable CursorAt: DraggablecursorAtConfiguration
        
        [<DefaultValue>]
        [<Name "delay">]
        //0 by default
        val mutable Delay: int
        
        [<DefaultValue>]
        [<Name "distance">]
        //1 by default
        val mutable Distance: int
        
        [<DefaultValue>]
        [<Name "grid">]
        //0 by default
        val mutable Grid: array<int>
        
        [<DefaultValue>]
        [<Name "handle">]
        //"" by default, string of Element
        val mutable Handle: string
        
        [<DefaultValue>]
        [<Name "helper">]
        //"original" by default
        val mutable Helper: string
        
        [<DefaultValue>]
        [<Name "iframeFix">]
        //false by default
        val mutable IframeFix: bool
        
        [<DefaultValue>]
        [<Name "opacity">]
        val mutable Opacity: float

        [<DefaultValue>]
        [<Name "refreshPositions">]
        //false by default
        val mutable RefreshPositions: bool

        [<DefaultValue>]
        [<Name "revert">]
        //false by default
        val mutable Revert: bool

        [<DefaultValue>]
        [<Name "revertDuration">]
        //500 by default
        val mutable RevertDuration: int

        [<DefaultValue>]
        [<Name "scope">]
        //"default" by default
        val mutable Scope: string

        [<DefaultValue>]
        [<Name "scroll">]
        //true by default
        val mutable Scroll: bool

        [<DefaultValue>]
        [<Name "scrollSensitivity">]
        //20 by default
        val mutable ScrollSensitivity: int

        [<DefaultValue>]
        [<Name "scrollSpeed">]
        //20 by default
        val mutable ScrollSpeed: int

        [<DefaultValue>]
        [<Name "snap">]
        //false by default
        val mutable snap: bool

        [<DefaultValue>]
        [<Name "snapMode">]
        //"both" by default
        val mutable SnapMode: string

        [<DefaultValue>]
        [<Name "snapTolerance">]
        //20 by default
        val mutable SnapTolerance: int

        [<DefaultValue>]
        [<Name "stack">]
        val mutable Stack: DraggableStackConfiguration

        [<DefaultValue>]
        [<Name "zIndex">]
        //2700 by default
        val mutable ZIndex: int

        [<JavaScript>]
        member ui.SetStart (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Start) = f o s.start
            ui.start    <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetStop (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Stop) = f o s.stop
            ui.stop    <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetDrag(f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Drag) = f o s.drag
            ui.drag   <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScriptConstructor>]
        new () = {}

    [<JavaScriptType>]
    type Draggable =

        [<Inline "jQuery($id).draggable()">]
        static member NewPrivate (id: string) : Draggable = Unchecked.defaultof<_>

        [<Inline "jQuery($el).draggable()">]
        static member New (el: Element) : Draggable = Unchecked.defaultof<_>

        [<Inline "jQuery($el).draggable($conf)">]
        static member New (el: Element, conf: DraggableConfiguration) : Draggable = Unchecked.defaultof<_>

        [<Inline "$this.draggable('destroy')">]
        member this.Destroy() = ()
                
        [<Inline "$this.draggable('disable')">]
        member this.Disable() = ()

        [<Inline "$this.draggable('enable')">]
        member this.Enable() = ()

        [<Inline "$this.draggable('option', $optionName, $value)">]
        member this.Option(optionName: string, value: obj) : unit = ()

        [<JavaScript>]
        static member Attach (el: Element) =
            el
            |> On Events.Attach (fun _ _ -> Draggable.New (el) |> ignore)

        [<JavaScript>]
        static member AttachWithConfiguration (conf: DraggableConfiguration) (el: Element) =
            el
            |> On Events.Attach (fun _ _ -> Draggable.New (el, conf) |> ignore)