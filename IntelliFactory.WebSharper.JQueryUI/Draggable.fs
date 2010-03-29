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
type DraggableConfiguration = 

    [<JavaScriptConstructor>]
    new () = {}

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

[<JavaScriptType>]    
module internal DraggableInternal =
    [<Inline "jQuery($el).draggable($conf)">]
    let internal New (el: Element, conf: DraggableConfiguration) = ()


[<JavaScriptType>]
type Draggable =

    [<JavaScriptConstructor>]
    new () = {}
    
    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : DraggableConfiguration

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
    [<Name "New_Draggable">]
    static member New (el : Element, conf: DraggableConfiguration): Draggable = 
        let a = new Draggable()
        a.configuration <- conf
        a.renderEvent <- new Event<RenderEvent>()
        a.element <- 
            el
            |> On Events.Attach (fun _ _ -> a.Render())
        a

    [<JavaScript>]
    [<Name "New_Draggable_Shortcut">]
    static member New (el : Element) : Draggable = 
        let conf = new DraggableConfiguration()
        Draggable.New(el, conf)

    (****************************************************************
    * Render interface
    *****************************************************************)       
       
    [<JavaScript>]
    member this.OnBeforeRender(f: unit -> unit) : unit=
        this.renderEvent.Publish
        |> Event.Iterate (fun re ->
            match re with
            | RenderEvent.Before  -> f ()
            | _                         -> ()
        )
                    
    [<JavaScript>]
    member this.OnAfterRender(f: unit -> unit) : unit=
        this.renderEvent.Publish
        |> Event.Iterate (fun re ->
            match re with
            | RenderEvent.After  -> f ()
            | _                        -> ()
        )

    [<JavaScript>]
    member this.Render() =     
        if not this.IsRendered  then
            this.renderEvent.Trigger RenderEvent.Before
            DraggableInternal.New(this.Element, this.configuration)
            this.renderEvent.Trigger RenderEvent.After
            this.isRendered <- true
    
    [<JavaScript>]
    member this.IsRendered
        with get () : bool = this.isRendered


    (****************************************************************
    * Methods
    *****************************************************************) 

    [<Inline "jQuery($this.element).draggable('destroy')">]
    member this.Destroy() = ()
            
    [<Inline "jQuery($this.element).draggable('disable')">]
    member this.Disable() = ()

    [<Inline "jQuery($this.element).draggable('enable')">]
    member this.Enable() = ()

    [<Inline "jQuery($this.element).draggable('widget')">]
    member this.Widget() = ()

    [<Inline "jQuery($this.element).draggable('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()


    (****************************************************************
    * Events
    *****************************************************************) 

    [<Inline "jQuery($this.element).draggable({start: function (x,y) {($f(x))(y.start);}})">]
    member private this.onStart(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).draggable({stop: function (x,y) {($f(x))(y.stop);}})">]
    member private this.onStop(f : Events.EventArgs -> Element -> unit) = ()

    [<Inline "jQuery($this.element).draggable({drag: function (x,y) {($f(x))(y.drag);}})">]
    member private this.onDrag(f : Events.EventArgs -> Element -> unit) = ()

    [<JavaScript>]
    member private this.On (f : unit -> unit) =
        if this.IsRendered then f ()
        else            
            this.OnAfterRender(fun () -> f ())

    [<JavaScript>]
    member this.OnStart f =
        this.On (fun () ->  this.onStart f)

    [<JavaScript>]
    member this.OnStop f =
        this.On (fun () -> this.onStop f)

    [<JavaScript>]
    member this.OnDrag f =
        this.On (fun () -> this.onDrag f)

