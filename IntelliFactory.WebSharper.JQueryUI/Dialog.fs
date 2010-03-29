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
type DialogConfiguration = 

    [<DefaultValue>]
    [<Name "autoOpen">]
    //true by default
    val mutable AutoOpen: bool

//        //New version of JQueryUI 1.8 removes bgiframe
//        [<DefaultValue>]
//        [<Name "bgiframe">]
//        //false by default
//        val mutable Bgiframe: bool

    //Buttons' type to be confirmed (string -> (string -> unit) -> unit)
    [<DefaultValue>]
    [<Name "buttons">]
    //"" by default
    val mutable Buttons: string

    [<DefaultValue>]
    [<Name "closeOnEscape">]
    //false by default
    val mutable CloseOnEscape: bool

    [<DefaultValue>]
    [<Name "closeText">]
    //"close" by default
    val mutable CloseText: string

    [<DefaultValue>]
    [<Name "dialogClass">]
    //"" by default
    val mutable DialogClass: string

    [<DefaultValue>]
    [<Name "draggable">]
    //true by default
    val mutable Draggable: bool

    [<DefaultValue>]
    [<Name "height">]
    val mutable Height: int

    [<DefaultValue>]
    [<Name "hide">]
    //"" by default
    val mutable Hide: string

    [<DefaultValue>]
    [<Name "maxHeight">]
    val mutable MaxHeight: int

    [<DefaultValue>]
    [<Name "maxWidth">]
    val mutable MaxWidth: int

    [<DefaultValue>]
    [<Name "minHeight">]
    val mutable MinHeight: int

    [<DefaultValue>]
    [<Name "minWidth">]
    val mutable MinWidth: int

    [<DefaultValue>]
    [<Name "modal">]
    //false by default
    val mutable Modal: bool

    [<DefaultValue>]
    [<Name "position">]
    //"center" by default
    val mutable Position: string

    [<DefaultValue>]
    [<Name "resizable">]
    //true by default
    val mutable Resizable: bool

    [<DefaultValue>]
    [<Name "show">]
    //"" by default
    val mutable Show: string

    [<DefaultValue>]
    [<Name "stack">]
    //true by default
    val mutable Stack: bool

    [<DefaultValue>]
    [<Name "title">]
    //"" by default
    val mutable Title: string

    [<DefaultValue>]
    [<Name "width">]
    //300 by default
    val mutable Width: int

    [<DefaultValue>]
    [<Name "zindex">]
    //1000 by default
    val mutable ZIndex: int

    [<JavaScriptConstructor>]
    new () = {}

[<JavaScriptType>]
module internal DialogInternal =        
    [<Inline "jQuery($el).dialog($conf)">]
    let Init (el: Element, conf: DialogConfiguration) = ()

[<JavaScriptType>]
type Dialog = 

    [<JavaScriptConstructor>]
    new () = {}
  
    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : DialogConfiguration

    [<DefaultValue>]
    val mutable private renderEvent: Event<Utils.RenderEvent>

    [<DefaultValue>]
    val mutable private isRendered: bool

    [<JavaScript>]
    member this.Element
        with get () =
            this.element

    [<JavaScript>]
    [<Name "New2">]
    static member New (el: Element, conf: DialogConfiguration): Dialog = 
        let d = new Dialog()
        d.configuration <- conf
        d.renderEvent <- new Event<RenderEvent>()
        d.element <- el |> On Events.Attach (fun _ _ -> d.Render())            
        d

    [<JavaScript>]
    [<Name "New1">]
    static member New (el: Element): Dialog = 
        Dialog.New(el, DialogConfiguration())


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
            DialogInternal.Init(this.Element, this.configuration)
            this.renderEvent.Trigger Utils.RenderEvent.After
            this.isRendered <- true
    
    [<JavaScript>]
    member this.IsRendered
        with get () : bool = this.isRendered
        
    (****************************************************************
    * Methods
    *****************************************************************)        
    [<Inline "jQuery($this.element).dialog('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element).dialog('disable')">]
    member this.Disable () = ()

    [<Inline "jQuery($this.element).dialog('enable')">]
    member this.Enable () = ()

    [<Inline "jQuery($this.element).dialog('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    [<Inline "jQuery($this.element).dialog('close')">]
    member this.Close () = ()

    [<Inline "jQuery($this.element).dialog('isOpen')">]
    member this.IsOpen () = false

    [<Inline "jQuery($this.element).dialog('moveToTop')">]
    member this.MoveToTop () = ()

    [<Inline "jQuery($this.element).dialog('open')">]
    member this.Open () = ()
            
    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element).dialog({beforeclose: function (x,y) {$f(x);}})">]
    member private this.onBeforeClose(f : Events.EventArgs -> unit) = ()

    [<Inline "jQuery($this.element).dialog({open: function (x,y) {$f(x);}})">]
    member private this.onOpen(f : Events.EventArgs -> unit) = ()

    [<Inline "jQuery($this.element).dialog({focus: function (x,y) {$f(x);}})">]
    member private this.onFocus(f : Events.EventArgs -> unit) = ()

    [<Inline "jQuery($this.element).dialog({dragStart: function (x,y) {$f(x);}})">]
    member private this.onDragStart(f : Events.EventArgs -> unit) = ()
        
    [<Inline "jQuery($this.element).dialog({drag: function (x,y) {$f(x);}})">]
    member private this.onDrag(f : Events.EventArgs -> unit) = ()
    
    [<Inline "jQuery($this.element).dialog({dragStop: function (x,y) {$f(x);}})">]
    member private this.onDragStop(f : Events.EventArgs -> unit) = ()

    [<Inline "jQuery($this.element).dialog({resizeStart: function (x,y) {$f(x);}})">]
    member private this.onResizeStart(f : Events.EventArgs -> unit) = ()

    [<Inline "jQuery($this.element).dialog({resize: function (x,y) {$f(x);}})">]
    member private this.onResize(f : Events.EventArgs -> unit) = ()

    [<Inline "jQuery($this.element).dialog({resizeStop: function (x,y) {$f(x);}})">]
    member private this.onResizeStop(f : Events.EventArgs -> unit) = ()

    [<Inline "jQuery($this.element).dialog({close: function (x,y) {$f(x);}})">]
    member private this.onClose(f : Events.EventArgs -> unit) = ()

    // Adding an event and delaying it if the widget is not yet rendered.
    [<JavaScript>]
    member private this.OnAfter (f : unit -> unit) : unit =
        if this.IsRendered then 
            f ()
        else            
            this.OnAfterRender(fun () -> f ())    
    
    [<JavaScript>]
    member this.OnBeforeClose(f : Events.EventArgs -> unit) = 
        this.OnAfter (fun () -> this.onBeforeClose f)

    [<JavaScript>]
    member this.OnOpen (f : Events.EventArgs -> unit) = 
        this.OnAfter (fun () -> this.onOpen f)

    [<JavaScript>]
    member this.OnFocus (f : Events.EventArgs -> unit) = 
        this.OnAfter (fun () -> this.onFocus f)

    [<JavaScript>]
    member this.OnDragStart (f : Events.EventArgs -> unit) = 
        this.OnAfter (fun () -> this.onDragStart f)

    [<JavaScript>]
    member this.OnDrag (f : Events.EventArgs -> unit) = 
        this.OnAfter (fun () -> this.onDrag f)

    [<JavaScript>]
    member this.OnDragStop (f : Events.EventArgs -> unit) = 
        this.OnAfter (fun () -> this.onDragStop f)

    [<JavaScript>]
    member this.OnResizeStart (f : Events.EventArgs -> unit) = 
        this.OnAfter (fun () -> this.onResizeStart f)

    [<JavaScript>]
    member this.OnResize (f : Events.EventArgs -> unit) = 
        this.OnAfter (fun () -> this.onResize f)

    [<JavaScript>]
    member this.OnResizeStop (f : Events.EventArgs -> unit) = 
        this.OnAfter (fun () -> this.onResizeStop f)

    [<JavaScript>]
    member this.OnClose (f : Events.EventArgs -> unit) = 
        this.OnAfter (fun () -> this.onClose f)
            
               



