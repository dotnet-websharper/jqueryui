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
type DialogConfiguration[<JavaScript>]() = 

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

[<JavaScriptType>]
module internal DialogInternal =        
    [<Inline "jQuery($el).dialog($conf)">]
    let Init (el: Dom.Element, conf: DialogConfiguration) = ()

[<JavaScriptType>]
type Dialog[<JavaScript>]() = 
  
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
    static member New (el: Element, conf: DialogConfiguration): Dialog = 
        let d = new Dialog()
        d.configuration <- conf
        d.renderEvent <- new Event<RenderEvent>()
        d.element <- el |>! OnAfterRender (fun _  -> (d :> IWidget).Render())            
        d

    [<JavaScript>]
    static member New (el: Element): Dialog = 
        Dialog.New(el, DialogConfiguration())



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
            DialogInternal.Init(this.Element.Dom, this.configuration)

        [<JavaScript>]                                       
        member this.Body
            with get () = this.Element.Dom
        
    (****************************************************************
    * Methods
    *****************************************************************)        
    [<Inline "jQuery($this.element.el).dialog('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element.el).dialog('disable')">]
    member this.Disable () = ()

    [<Inline "jQuery($this.element.el).dialog('enable')">]
    member this.Enable () = ()

    [<Inline "jQuery($this.element.el).dialog('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    [<Inline "jQuery($this.element.el).dialog('close')">]
    member this.Close () = ()

    [<Inline "jQuery($this.element.el).dialog('isOpen')">]
    member this.IsOpen () = false

    [<Inline "jQuery($this.element.el).dialog('moveToTop')">]
    member this.MoveToTop () = ()

    [<Inline "jQuery($this.element.el).dialog('open')">]
    member this.Open () = ()
            
    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element.el).dialog({beforeclose: function (x,y) {$f(x);}})">]
    member private this.onBeforeClose(f : JQueryEvent -> unit) = ()

    [<Inline "jQuery($this.element.el).dialog({open: function (x,y) {$f(x);}})">]
    member private this.onOpen(f : JQueryEvent -> unit) = ()

    [<Inline "jQuery($this.element.el).dialog({focus: function (x,y) {$f(x);}})">]
    member private this.onFocus(f : JQueryEvent -> unit) = ()

    [<Inline "jQuery($this.element.el).dialog({dragStart: function (x,y) {$f(x);}})">]
    member private this.onDragStart(f : JQueryEvent -> unit) = ()
        
    [<Inline "jQuery($this.element.el).dialog({drag: function (x,y) {$f(x);}})">]
    member private this.onDrag(f : JQueryEvent -> unit) = ()
    
    [<Inline "jQuery($this.element.el).dialog({dragStop: function (x,y) {$f(x);}})">]
    member private this.onDragStop(f : JQueryEvent -> unit) = ()

    [<Inline "jQuery($this.element.el).dialog({resizeStart: function (x,y) {$f(x);}})">]
    member private this.onResizeStart(f : JQueryEvent -> unit) = ()

    [<Inline "jQuery($this.element.el).dialog({resize: function (x,y) {$f(x);}})">]
    member private this.onResize(f : JQueryEvent -> unit) = ()

    [<Inline "jQuery($this.element.el).dialog({resizeStop: function (x,y) {$f(x);}})">]
    member private this.onResizeStop(f : JQueryEvent -> unit) = ()

    [<Inline "jQuery($this.element.el).dialog({close: function (x,y) {$f(x);}})">]
    member private this.onClose(f : JQueryEvent -> unit) = ()
 
    
    [<JavaScript>]
    member this.OnBeforeClose(f : JQueryEvent -> unit) = 
        this |> OnAfterRender (fun _ -> this.onBeforeClose f)

    [<JavaScript>]
    member this.OnOpen (f : JQueryEvent -> unit) = 
        this |> OnAfterRender (fun _  -> this.onOpen f)

    [<JavaScript>]
    member this.OnFocus (f : JQueryEvent -> unit) = 
        this |> OnAfterRender (fun _  -> this.onFocus f)

    [<JavaScript>]
    member this.OnDragStart (f : JQueryEvent -> unit) = 
        this |> OnAfterRender (fun _ -> this.onDragStart f)

    [<JavaScript>]
    member this.OnDrag (f : JQueryEvent -> unit) = 
        this |> OnAfterRender (fun _ -> this.onDrag f)

    [<JavaScript>]
    member this.OnDragStop (f : JQueryEvent -> unit) = 
        this |> OnAfterRender (fun _ -> this.onDragStop f)

    [<JavaScript>]
    member this.OnResizeStart (f : JQueryEvent -> unit) = 
        this |> OnAfterRender (fun _ -> this.onResizeStart f)

    [<JavaScript>]
    member this.OnResize (f : JQueryEvent -> unit) = 
        this |> OnAfterRender (fun _ -> this.onResize f)

    [<JavaScript>]
    member this.OnResizeStop (f : JQueryEvent -> unit) = 
        this |> OnAfterRender (fun _ -> this.onResizeStop f)

    [<JavaScript>]
    member this.OnClose (f : JQueryEvent -> unit) = 
        this |> OnAfterRender (fun _ -> this.onClose f)
            
               



