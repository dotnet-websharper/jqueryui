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
type ToleranceOfDroppable =     
    | [<Constant "fit">] Fit
    | [<Constant "intersect">] Intersect
    | [<Constant "pointer">] Pointer
    | [<Constant "touch">] Touch


[<JavaScriptType>]
type DroppableConfiguration[<JavaScript>]() = 

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
    val mutable Tolerance: ToleranceOfDroppable


[<JavaScriptType>]    
module internal DroppableInternal =
    [<Inline "jQuery($el).droppable($conf)">]
    let internal New (el: Dom.Element, conf: DroppableConfiguration) = ()

[<JavaScriptType>]
type Droppable[<JavaScript>]() =

    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : DroppableConfiguration

    [<JavaScript>]
    member this.Element
        with get () =
            this.element

    (****************************************************************
    * Constructors
    *****************************************************************) 
    [<JavaScript>]
    [<Name "New_Droppable">]
    static member New (el : Element, conf: DroppableConfiguration): Droppable = 
        let a = new Droppable()
        a.configuration <- conf
        a.element <- 
            el
            |>! OnAfterRender (fun _  -> (a :> IWidget).Render())
        a

    [<JavaScript>]
    [<Name "New_Droppable_Shortcut">]
    static member New (el : Element) : Droppable = 
        let conf = new DroppableConfiguration()
        Droppable.New(el, conf)


    (****************************************************************
    * INode
    *****************************************************************)              
    interface INode with
        [<JavaScript>]                                       
        member this.Body
            with get () = 
                (this :> IWidget).Render()
                (this.Element.Dom :> Dom.Node)
                
    (****************************************************************
    * IWidget
    *****************************************************************)                  
    interface IWidget with
        [<JavaScript>]
        member this.OnBeforeRender(f: unit -> unit) : unit=
            this.Element
            |> OnBeforeRender (fun _ -> f ())
                        
        [<JavaScript>]
        member this.OnAfterRender(f: unit -> unit) : unit=
            this.Element
            |> OnAfterRender (fun _ -> 
                (this :> IWidget).Render()
                f ()
            )

        [<JavaScript>]
        member this.Render() =
            (this.Element :> IWidget).Render()
            DroppableInternal.New (this.Element.Dom, this.configuration)

        [<JavaScript>]                                       
        member this.Body
            with get () = this.Element.Dom


    (****************************************************************
    * Methods
    *****************************************************************) 

    [<Inline "jQuery($this.element.el).droppable('destroy')">]
    member this.Destroy() = ()
            
    [<Inline "jQuery($this.element.el).droppable('disable')">]
    member this.Disable() = ()

    [<Inline "jQuery($this.element.el).droppable('enable')">]
    member this.Enable() = ()

    [<Inline "jQuery($this.element.el).droppable('widget')">]
    member this.Widget() = ()
    
    [<Inline "jQuery($this.element.el).droppable('option', $name, $value)">]
    member this.Option(optionName: string, value: obj) : unit = ()


    (****************************************************************
    * Events
    *****************************************************************) 

    [<Inline "jQuery($this.element.el).droppable({activate: function (x,y) {($f(x))(y.activate);}})">]
    member private this.onActivate(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).droppable({deactivate: function (x,y) {($f(x))(y.deactivate);}})">]
    member private this.onDeactivate(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).droppable({over: function (x,y) {($f(x))(y.over);}})">]
    member private this.onOver(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).droppable({out: function (x,y) {($f(x))(y.out);}})">]
    member private this.onOut(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).droppable({drop: function (x,y) {($f(x))(y.drop);}})">]
    member private this.onDrop(f : JQueryEvent -> Element -> unit) = ()


    [<JavaScript>]
    member this.OnActivate f =
        this |> OnAfterRender(fun _ -> this.onActivate f)

    [<JavaScript>]
    member this.OnDeactivate f =
        this |> OnAfterRender(fun _ -> this.onDeactivate f)

    [<JavaScript>]
    member this.OnOver f =
        this |> OnAfterRender(fun _ -> this.onOver f)

    [<JavaScript>]
    member this.OnOut f =
        this |> OnAfterRender(fun _ -> this.onOut f)

    [<JavaScript>]
    member this.OnDrop f =
        this |> OnAfterRender(fun _ -> this.onDrop f)

