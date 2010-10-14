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


type DialogConfiguration[<JavaScript>]() = 

    [<DefaultValue>]
    [<Name "autoOpen">]
    //true by default
    val mutable AutoOpen: bool

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


module internal DialogInternal =        
    [<Inline "jQuery($el).dialog($conf)">]
    let Init (el: Dom.Element, conf: DialogConfiguration) = ()


type Dialog[<JavaScript>]internal () = 
    inherit Pagelet()  

    /// Create a new dialog using the given element
    /// and configuration object.
    [<JavaScript>]
    [<Name "New1">]
    static member New (el: Element, conf: DialogConfiguration): Dialog = 
        let d = new Dialog()
        el
        |> OnAfterRender(fun el ->
            DialogInternal.Init(el.Body, conf)
        )
        d.element <- el
        d

    /// Creates a new dialog given an element using
    /// default configuration settings.            
    [<JavaScript>]
    [<Name "New2">]
    static member New (el: Element): Dialog = 
        Dialog.New(el, DialogConfiguration())
        
    (****************************************************************
    * Methods
    *****************************************************************)        
    /// Remove the dialog functionality.
    [<Inline "jQuery($this.element.Body).dialog('destroy')">]
    member this.Destroy() = ()

    /// Disables the dialog.
    [<Inline "jQuery($this.element.Body).dialog('disable')">]
    member this.Disable () = ()

    /// Enables the dialog.
    [<Inline "jQuery($this.element.Body).dialog('enable')">]
    member this.Enable () = ()

    /// Sets dialog option.
    [<Inline "jQuery($this.element.Body).dialog('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Close dialog.
    [<Inline "jQuery($this.element.Body).dialog('close')">]
    member this.Close () = ()

    /// Returns whether the dialog is open or not.
    [<Inline "jQuery($this.element.Body).dialog('isOpen')">]
    member this.IsOpen () = false

    /// Move the dialog to the top of the dialogs stack.
    [<Inline "jQuery($this.element.Body).dialog('moveToTop')">]
    member this.MoveToTop () = ()

    /// Open the dialog.
    [<Inline "jQuery($this.element.Body).dialog('open')">]
    member this.Open () = ()
            
    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element.Body).dialog({beforeclose: function (x,y) {$f(x);}})">]
    member private this.onBeforeClose(f : JQuery.Event -> unit) = ()

    [<Inline "jQuery($this.element.Body).dialog({open: function (x,y) {$f(x);}})">]
    member private this.onOpen(f : JQuery.Event -> unit) = ()

    [<Inline "jQuery($this.element.Body).dialog({focus: function (x,y) {$f(x);}})">]
    member private this.onFocus(f : JQuery.Event -> unit) = ()

    [<Inline "jQuery($this.element.Body).dialog({dragStart: function (x,y) {$f(x);}})">]
    member private this.onDragStart(f : JQuery.Event -> unit) = ()
        
    [<Inline "jQuery($this.element.Body).dialog({drag: function (x,y) {$f(x);}})">]
    member private this.onDrag(f : JQuery.Event -> unit) = ()
    
    [<Inline "jQuery($this.element.Body).dialog({dragStop: function (x,y) {$f(x);}})">]
    member private this.onDragStop(f : JQuery.Event -> unit) = ()

    [<Inline "jQuery($this.element.Body).dialog({resizeStart: function (x,y) {$f(x);}})">]
    member private this.onResizeStart(f : JQuery.Event -> unit) = ()

    [<Inline "jQuery($this.element.Body).dialog({resize: function (x,y) {$f(x);}})">]
    member private this.onResize(f : JQuery.Event -> unit) = ()

    [<Inline "jQuery($this.element.Body).dialog({resizeStop: function (x,y) {$f(x);}})">]
    member private this.onResizeStop(f : JQuery.Event -> unit) = ()

    [<Inline "jQuery($this.element.Body).dialog({close: function (x,y) {$f(x);}})">]
    member private this.onClose(f : JQuery.Event -> unit) = ()
 
    
    /// Triggered before the dialog is closed.
    [<JavaScript>]
    member this.OnBeforeClose(f : JQuery.Event -> unit) = 
        this |> OnAfterRender (fun _ -> this.onBeforeClose f)

    /// Triggered before the dialog is opened.
    [<JavaScript>]
    member this.OnOpen (f : JQuery.Event -> unit) = 
        this |> OnAfterRender (fun _  -> this.onOpen f)

    /// Triggered before the dialog gains focus.
    [<JavaScript>]
    member this.OnFocus (f : JQuery.Event -> unit) = 
        this |> OnAfterRender (fun _  -> this.onFocus f)

    /// Triggered at the beginning of the dialog being dragged
    [<JavaScript>]
    member this.OnDragStart (f : JQuery.Event -> unit) = 
        this |> OnAfterRender (fun _ -> this.onDragStart f)

    
    /// Triggered when the dialog is dragged.
    [<JavaScript>]
    member this.OnDrag (f : JQuery.Event -> unit) = 
        this |> OnAfterRender (fun _ -> this.onDrag f)

    
    /// Triggered after the dialog has been dragged.
    [<JavaScript>]
    member this.OnDragStop (f : JQuery.Event -> unit) = 
        this |> OnAfterRender (fun _ -> this.onDragStop f)

    /// Triggered before the dialog is being resized.
    [<JavaScript>]
    member this.OnResizeStart (f : JQuery.Event -> unit) = 
        this |> OnAfterRender (fun _ -> this.onResizeStart f)
    
    /// Triggered when the dialog is being resized.
    [<JavaScript>]
    member this.OnResize (f : JQuery.Event -> unit) = 
        this |> OnAfterRender (fun _ -> this.onResize f)

    /// Triggered after the dialog has been resized.
    [<JavaScript>]
    member this.OnResizeStop (f : JQuery.Event -> unit) = 
        this |> OnAfterRender (fun _ -> this.onResizeStop f)

    /// Triggered when the dialog is closed.
    [<JavaScript>]
    member this.OnClose (f : JQuery.Event -> unit) = 
        this |> OnAfterRender (fun _ -> this.onClose f)
            
               



