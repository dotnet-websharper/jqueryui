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
type ToleranceOfSelectable =     
    | [<Constant "fit">] Fit
    | [<Constant "touch">] Touch

[<JavaScriptType>]
type SelectableConfiguration[<JavaScript>]() = 


    [<DefaultValue>]
    [<Name "disabled">]
    //false by default
    val mutable Disabled: bool

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
    val mutable Tolerance: ToleranceOfSelectable


[<JavaScriptType>]    
module internal SelectableInternal =
    [<Inline "jQuery($el).selectable($conf)">]
    let internal New (el: Dom.Element, conf: SelectableConfiguration) = ()


[<JavaScriptType>]
type Selectable[<JavaScript>] internal () =
    inherit Widget() 


    (****************************************************************
    * Constructors
    *****************************************************************) 
    [<JavaScript>]
    static member New (el : Element, conf: SelectableConfiguration): Selectable = 
        let a = new Selectable()        
        a.element <- 
            el |>! OnAfterRender (fun el  -> 
                SelectableInternal.New(el.Dom, conf)
            )
        a

    [<JavaScript>]
    static member New (el : Element) : Selectable = 
        let conf = new SelectableConfiguration()
        Selectable.New(el, conf)

    (****************************************************************
    * Methods
    *****************************************************************) 

    [<Inline "jQuery($this.element.el).selectable('destroy')">]
    member this.Destroy() = ()
   
    [<Inline "jQuery($this.element.el).selectable('disable')">]
    member this.Disable() = ()

    [<Inline "jQuery($this.element.el).selectable('enable')">]
    member this.Enable() = ()

    [<Inline "jQuery($this.element.el).selectable('refresh')">]
    member this.Refresh() = ()

    [<Inline "jQuery($this.element.el).selectable('widget')">]
    member this.Widget() = ()

    [<Inline "jQuery($this.element.el).selectable('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element.el).selectable({selected: function (x,y) {($f(x))(y.selected);}})">]
    member private this.onSelected(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).selectable({selecting: function (x,y) {($f(x))(y.selecting);}})">]
    member private this.onSelecting(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).selectable({start: function (x,y) {($f(x))(y.start);}})">]
    member private this.onStart(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).selectable({stop: function (x,y) {($f(x))(y.stop);}})">]
    member private this.onStop(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).selectable({unselected: function (x,y) {($f(x))(y.unselected);}})">]
    member private this.onUnselected(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).selectable({unselecting: function (x,y) {($f(x))(y.unselecting);}})">]
    member private this.onUnselecting(f : JQueryEvent -> Element -> unit) = ()


    [<JavaScript>]
    member this.OnSelected(f : JQueryEvent -> Element -> unit) =
        this |> OnAfterRender(fun _ ->  this.onSelected f)

    [<JavaScript>]
    member this.OnSelecting(f : JQueryEvent -> Element -> unit) =
        this |> OnAfterRender(fun _ -> this.onSelecting f)

    [<JavaScript>]
    member this.OnStart(f : JQueryEvent -> Element -> unit) =
        this |> OnAfterRender(fun _ -> this.onStart f)

    [<JavaScript>]
    member this.OnStop(f : JQueryEvent -> Element -> unit) =
        this |> OnAfterRender(fun _ -> this.onStop f)

    [<JavaScript>]
    member this.OnUnselected(f : JQueryEvent -> Element -> unit) =
        this |> OnAfterRender(fun _ ->  this.onUnselected f)

    [<JavaScript>]
    member this.OnUnselecting(f : JQueryEvent -> Element -> unit) =
        this |> OnAfterRender(fun _ -> this.onUnselecting f)