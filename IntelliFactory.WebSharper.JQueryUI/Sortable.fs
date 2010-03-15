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
module Sortable =

    [<JavaScriptType>]
    type AxisConfiguration = 
        | [<Constant "X">] X
        | [<Constant "Y">] Y

    [<JavaScriptType>]
    type ToleranceConfiguration = 
        | [<Constant "intersect">] Intersect
        | [<Constant "Pointer">] Pointer

    [<JavaScriptType>]
    type Start = 
        {
            start: Element
        }

    [<JavaScriptType>]
    type Sort = 
        {
            sort: Element
        }

    [<JavaScriptType>]
    type Change = 
        {
            change: Element
        }

    [<JavaScriptType>]
    type BeforeStop= 
        {
            beforeStop: Element
        }

    
    [<JavaScriptType>]
    type Stop = 
        {
            stop: Element
        }

    [<JavaScriptType>]
    type Update = 
        {
            update: Element
        }

    [<JavaScriptType>]
    type Receive = 
        {
            receive: Element
        }

    [<JavaScriptType>]
    type Remove = 
        {
            remove: Element
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
    type SortableConfiguration = 

        [<DefaultValue>]
        val mutable start: JavaScript.Function<Events.EventArgs, Start, unit>

        [<DefaultValue>]
        val mutable sort: JavaScript.Function<Events.EventArgs, Sort, unit>

        [<DefaultValue>]
        val mutable change: JavaScript.Function<Events.EventArgs, Change, unit>

        [<DefaultValue>]
        val mutable beforeStop: JavaScript.Function<Events.EventArgs, BeforeStop, unit>
        
        [<DefaultValue>]
        val mutable stop: JavaScript.Function<Events.EventArgs, Stop, unit>

        [<DefaultValue>]
        val mutable update: JavaScript.Function<Events.EventArgs, Update, unit>

        [<DefaultValue>]
        val mutable receive: JavaScript.Function<Events.EventArgs, Receive, unit>

        [<DefaultValue>]
        val mutable remove: JavaScript.Function<Events.EventArgs, Remove, unit>

        [<DefaultValue>]
        val mutable over: JavaScript.Function<Events.EventArgs, Over, unit>

        [<DefaultValue>]
        val mutable out: JavaScript.Function<Events.EventArgs, Out, unit>

        [<DefaultValue>]
        val mutable activate: JavaScript.Function<Events.EventArgs, Activate, unit>

        [<DefaultValue>]
        val mutable deactivate: JavaScript.Function<Events.EventArgs, Deactivate, unit>

        [<DefaultValue>]
        [<Name "appendTo">]
        val mutable AppendTo: string

        [<DefaultValue>]
        [<Name "axis">]
        val mutable Axis: AxisConfiguration

        [<DefaultValue>]
        [<Name "cancel">]
        val mutable Cancel: string

        [<DefaultValue>]
        [<Name "connectWith">]
        val mutable ConnectWith: string

        [<DefaultValue>]
        [<Name "containment">]
        val mutable Containment: string

        [<DefaultValue>]
        [<Name "cursor">]
        //"auto" by default
        val mutable Cursor: string

        [<DefaultValue>]
        [<Name "cursorAt">]
        //Coordinates can be combination of one or two keys: {"top"; "left"; "right"; "bottom"}
        val mutable CurosorAt: string

        [<DefaultValue>]
        [<Name "delay">]
        //0 by default
        val mutable Delay: int

        [<DefaultValue>]
        [<Name "distance">]
        val mutable Distance: int

        [<DefaultValue>]
        [<Name "dropOnEmpty">]
        //true by default
        val mutable DropOnEmpty: bool

        [<DefaultValue>]
        [<Name "forceHelperSize">]
        //false by default
        val mutable ForceHelperSize: bool

        [<DefaultValue>]
        [<Name "forcePlaceholderSize">]
        //false by default
        val mutable ForcePlaceholderSize: bool

        [<DefaultValue>]
        [<Name "grid">]
        //array value [|x; y|]
        val mutable Grid: array<int>

        [<DefaultValue>]
        [<Name "handle">]
        val mutable Handel: string

        [<DefaultValue>]
        [<Name "helper">]
        //"original" by default, Possible values: "original", "clone"
        val mutable Helper: string

        [<DefaultValue>]
        [<Name "items">]
        //"> *" by default
        val mutable Items: string

        [<DefaultValue>]
        [<Name "opacity">]
        val mutable Opacity: float

        [<DefaultValue>]
        [<Name "placeholder">]
        val mutable Placeholder: string

        [<DefaultValue>]
        [<Name "revert">]
        //"false" by default
        val mutable Revert: bool

        [<DefaultValue>]
        [<Name "scroll">]
        //"true" by default
        val mutable Scroll: bool

        [<DefaultValue>]
        [<Name "scrollSensitivity">]
        //"20" by default
        val mutable ScrollSensitivity: int

        [<DefaultValue>]
        [<Name "scrollSpeed">]
        //"20" by default
        val mutable ScrollSpeed: int

        [<DefaultValue>]
        [<Name "tolerance">]
        //"false" by default
        val mutable Tolerance: ToleranceConfiguration

        [<DefaultValue>]
        [<Name "zIndex">]
        //"1000" by default
        val mutable ZIndex: int

        [<JavaScript>]
        member ui.SetStart (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Start) = f o s.start
            ui.start    <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetSort (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Sort) = f o s.sort
            ui.sort    <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetChange (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Change) = f o s.change
            ui.change  <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetBeforeStop (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: BeforeStop) = f o s.beforeStop
            ui.beforeStop <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetStop (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Stop) = f o s.stop
            ui.stop    <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetUpdate (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Update) = f o s.update
            ui.update   <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetReceive (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Receive) = f o s.receive
            ui.receive  <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetRemove (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Remove) = f o s.remove
            ui.remove  <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetOver (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Over) = f o s.over
            ui.over  <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetOut (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Out) = f o s.out
            ui.out  <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetActivate (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Activate) = f o s.activate
            ui.activate  <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScript>]
        member ui.SetDeactivate (f: obj -> Element -> unit)  =   
            let fS (o: obj) (s: Deactivate) = f o s.deactivate
            ui.deactivate  <- new JavaScript.Function<_,_,_>(fS)

        [<JavaScriptConstructor>]
        new () = {}

    [<JavaScriptType>]
    type Sortable = 
        
        [<Inline "jQuery($id).sortable()">]
        static member NewPrivate (id: string) : Sortable = Unchecked.defaultof<_>

        [<Inline "jQuery($el).sortable()">]
        static member New (el: Element) : Sortable = Unchecked.defaultof<_>

        [<Inline "jQuery($el).sortable($conf)">]
        static member New (el: Element, conf: SortableConfiguration) : Sortable = Unchecked.defaultof<_>

        [<Inline "$this.sortable('destroy')">]
        member this.Destroy() = ()
                
        [<Inline "$this.sortable('disable')">]
        member this.Disable() = ()

        [<Inline "$this.sortable('enable')">]
        member this.Enable() = ()

        [<Inline "$this.sortable('option', $optionName, $value)">]
        member this.Option(optionName: string, value: obj) : unit = ()

        [<Inline "$this.sortable('serialize', $options)">]
        member this.Serialize(options: obj) : unit = ()

        [<Inline "$this.sortable('toArray')">]
        member this.ToArray() = ()

        [<Inline "$this.sortable('refresh')">]
        member this.Refresh() = ()

        [<Inline "$this.sortable('refreshPositions')">]
        member this.RefreshPositions() = ()

        [<Inline "$this.sortable('cancel')">]
        member this.Cancel() = ()

        [<JavaScript>]
        static member Attach (el: Element) =
            el
            |> On Events.Attach (fun _ _ -> Sortable.New (el) |> ignore)

        [<JavaScript>]
        static member AttachWithConfiguration (conf: SortableConfiguration) (el: Element) =
            el
            |> On Events.Attach (fun _ _ -> Sortable.New (el, conf) |> ignore)