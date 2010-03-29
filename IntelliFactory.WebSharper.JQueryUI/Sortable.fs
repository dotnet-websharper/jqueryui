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
type SortableConfiguration = 

    [<JavaScriptConstructor>]
    new () = {}

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
    [<Name "New_Sortable">]
    static member New (el: Element, conf: SortableConfiguration) : Sortable = 
        let s = new Sortable()
        s.configuration <- conf
        s.renderEvent <- new Event<RenderEvent>()
        s.element <- 
            el
            |> On Events.Attach (fun _ _ ->
                s.Render()   
            )
        s

    [<JavaScript>]
    [<Name "New_Sortable_Shortcut">]
    static member New (el: Element) : Sortable =
        let conf = new SortableConfiguration()
        Sortable.New(el, conf)

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

    [<Inline "jQuery($this.element).sortable({sort: function (x,y) {($f(x))(y.start);}})">]
    member private this.onStart(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).sortable({sort: function (x,y) {($f(x))(y.sort);}})">]
    member private this.onSort(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).sortable({change: function (x,y) {($f(x))(y.change);}})">]
    member private this.onChange(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).sortable({beforeStop: function (x,y) {($f(x))(y.beforeStop);}})">]
    member private this.onBeforeStop(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).sortable({stop: function (x,y) {($f(x))(y.stop);}})">]
    member private this.onStop(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).sortable({update: function (x,y) {($f(x))(y.update);}})">]
    member private this.onUpdate(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).sortable({receive: function (x,y) {($f(x))(y.receive);}})">]
    member private this.onReceive(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).sortable({remove: function (x,y) {($f(x))(y.remove);}})">]
    member private this.onRemove(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).sortable({over: function (x,y) {($f(x))(y.over);}})">]
    member private this.onOver(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).sortable({out: function (x,y) {($f(x))(y.out);}})">]
    member private this.onOut(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).sortable({activate: function (x,y) {($f(x))(y.activate);}})">]
    member private this.onActivate(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).sortable({deactivate: function (x,y) {($f(x))(y.deactivate);}})">]
    member private this.onDeactivate(f : Events.EventArgs -> Element -> unit) = ()

    // Adding an event and delayin it if the widget is not yet rendered.
    [<JavaScript>]
    member private this.On (f : unit -> unit) =
        if this.IsRendered then f ()
        else            
            this.OnAfterRender(fun () -> f ())

    [<JavaScript>]
    member this.OnStart(f : Events.EventArgs -> Element -> unit) =
        this.On (fun () ->  this.onStart f)

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
