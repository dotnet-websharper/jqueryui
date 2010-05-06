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
type SortableConfiguration[<JavaScript>]() = 

    

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
    let Init (el: Dom.Element, conf: SortableConfiguration) = ()


[<JavaScriptType>]
type Sortable [<JavaScript>] internal () = 
    inherit Widget()

    (****************************************************************
    * Constructors
    *****************************************************************)                 
    [<JavaScript>]
    static member New (el: Element, conf: SortableConfiguration) : Sortable = 
        let s = new Sortable()
        s.element <- 
            el
            |>! OnAfterRender (fun el  ->
                SortableInternal.Init(el.Dom, conf)
            )
        s

    [<JavaScript>]
    static member New (el: Element) : Sortable =
        let conf = new SortableConfiguration()
        Sortable.New(el, conf)

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
    [<Inline "jQuery($this.element.el).sortable({sort: function (x,y) {($f(x))(y.start);}})">]
    member private this.onStart(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).sortable({sort: function (x,y) {($f(x))(y.sort);}})">]
    member private this.onSort(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).sortable({change: function (x,y) {($f(x))(y.change);}})">]
    member private this.onChange(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).sortable({beforeStop: function (x,y) {($f(x))(y.beforeStop);}})">]
    member private this.onBeforeStop(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).sortable({stop: function (x,y) {($f(x))(y.stop);}})">]
    member private this.onStop(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).sortable({update: function (x,y) {($f(x))(y.update);}})">]
    member private this.onUpdate(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).sortable({receive: function (x,y) {($f(x))(y.receive);}})">]
    member private this.onReceive(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).sortable({remove: function (x,y) {($f(x))(y.remove);}})">]
    member private this.onRemove(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).sortable({over: function (x,y) {($f(x))(y.over);}})">]
    member private this.onOver(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).sortable({out: function (x,y) {($f(x))(y.out);}})">]
    member private this.onOut(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).sortable({activate: function (x,y) {($f(x))(y.activate);}})">]
    member private this.onActivate(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).sortable({deactivate: function (x,y) {($f(x))(y.deactivate);}})">]
    member private this.onDeactivate(f : JQueryEvent -> Element -> unit) = ()

    [<JavaScript>]
    member this.OnStart(f : JQueryEvent -> Element -> unit) =
        this |> OnAfterRender(fun _ ->  this.onStart f)

    [<JavaScript>]
    member this.OnSort f = 
        this |> OnAfterRender(fun _ -> this.onSort f)

    [<JavaScript>]
    member this.OnChange f = 
        this |> OnAfterRender(fun _ -> this.onChange f)

    [<JavaScript>]
    member this.OnBeforeStop f = 
        this |> OnAfterRender(fun _ -> this.onBeforeStop f)

    [<JavaScript>]
    member this.OnStop f = 
        this |> OnAfterRender(fun _ -> this.onStop f)

    [<JavaScript>]
    member this.OnUpdate f = 
        this |> OnAfterRender(fun _ -> this.onUpdate f)

    [<JavaScript>]
    member this.OnReceive f = 
        this |> OnAfterRender(fun _ -> this.onReceive f)
    
    [<JavaScript>]
    member this.OnRemove f = 
        this |> OnAfterRender(fun _ -> this.onRemove f)

    [<JavaScript>]
    member this.OnOver f = 
        this |> OnAfterRender(fun _ -> this.onOut f)

    [<JavaScript>]
    member this.OnActivate f = 
        this |> OnAfterRender(fun _ -> this.onActivate f)

    [<JavaScript>]
    member this.OnDeactivate f = 
        this |> OnAfterRender(fun _ -> this.onDeactivate f)
