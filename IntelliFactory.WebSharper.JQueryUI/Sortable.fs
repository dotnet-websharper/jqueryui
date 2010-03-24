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
module internal SortableInternal =    
    [<Inline "jQuery($el).sortable($conf)">]
    let Init (el: Element, conf: SortableConfiguration) = ()

[<JavaScriptType>]
type Sortable = 
    [<JavaScriptConstructor>]
    new () = {}
  
    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : SortableConfiguration

    [<DefaultValue>]
    val mutable private renderEvent: Event<Utils.RenderEvent>

    [<DefaultValue>]
    val mutable private isRendered: bool

    [<JavaScript>]
    member this.Element
        with get () =
            this.element
                
    [<JavaScript>]
    [<Name "New1">]
    static member New (el: Element, conf: SortableConfiguration) : Sortable = 
        let s = new Sortable()
        s.element <- 
            el
            |> On Events.Attach (fun _ _ ->
                s.Render()   
            )
        s.configuration <- conf
        s.renderEvent <- new Event<RenderEvent>()
        s

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
            SortableInternal.Init(this.Element, this.configuration)
            this.renderEvent.Trigger Utils.RenderEvent.After
            this.isRendered <- true
    
    [<JavaScript>]
    member this.IsRendered
        with get () : bool = this.isRendered


    (****************************************************************
    * Methods
    *****************************************************************) 
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

    (****************************************************************
    * Events
    *****************************************************************) 
    [<Inline "jQuery($this.element).sortable({sort: function (x,y) {$f();}})">]
    member private this.onSort(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).sortable({change: function (x,y) {$f();}})">]
    member private this.onChange(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).sortable({beforeStop: function (x,y) {$f();}})">]
    member private this.onBeforeStop(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).sortable({stop: function (x,y) {$f();}})">]
    member private this.onStop(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).sortable({update: function (x,y) {$f();}})">]
    member private this.onUpdate(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).sortable({receive: function (x,y) {$f();}})">]
    member private this.onReceive(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).sortable({remove: function (x,y) {$f();}})">]
    member private this.onRemove(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).sortable({over: function (x,y) {$f();}})">]
    member private this.onOver(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).sortable({out: function (x,y) {$f();}})">]
    member private this.onOut(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).sortable({activate: function (x,y) {$f();}})">]
    member private this.onActivate(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).sortable({deactivate: function (x,y) {$f();}})">]
    member private this.onDeactivate(f : unit -> unit) = ()

    // Adding an event and delayin it if the widget is not yet rendered.
    [<JavaScript>]
    member private this.On (f : unit -> unit) =
        if this.IsRendered then f ()
        else            
            this.OnAfterRender(fun () -> f ())

    [<JavaScript>]
    member this.OnSort f = this.On (fun () -> this.onSort f)

    [<JavaScript>]
    member this.OnChange f = this.On (fun () -> this.onChange f)

    [<JavaScript>]
    member this.OnBeforeStop f = this.On (fun () -> this.onBeforeStop f)

    [<JavaScript>]
    member this.OnStop f = this.On (fun () -> this.onStop f)

    [<JavaScript>]
    member this.OnUpdate f = this.On (fun () -> this.onUpdate f)

    [<JavaScript>]
    member this.OnReceive f = this.On (fun () -> this.onReceive f)
    
    [<JavaScript>]
    member this.OnRemove f = this.On (fun () -> this.onRemove f)

    [<JavaScript>]
    member this.OnOver f = this.On (fun () -> this.onOut f)

    [<JavaScript>]
    member this.OnActivate f = this.On (fun () -> this.onActivate f)

    [<JavaScript>]
    member this.OnDeactivate f = this.On (fun () -> this.onDeactivate f)



