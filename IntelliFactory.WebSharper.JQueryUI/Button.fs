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
type ButtonIconsConfiguration = 
    {
        [<Name "primary">]
        Primary: string
        
        [<Name "Secondary">]
        Secondary: string      
    }
    [<JavaScript>]
    static member Default = {Primary = "ui-icon-gear"; Secondary = "ui-icon-triangle-1-s" }

[<JavaScriptType>]
type ButtonConfiguration[<JavaScript>] internal () = 
    
    [<DefaultValue>]
    [<Name "text">]
    //true by default
    val mutable Text: bool

    [<DefaultValue>]
    [<Name "label">]
    //true by default
    val mutable Label: string

    [<DefaultValue>]
    [<Name "icons">]
    val mutable Icons: ButtonIconsConfiguration

[<JavaScriptType>]
module internal ButtonInternal =
    [<Inline "jQuery($el).button($conf)">]
    let Init (el: Dom.Element, conf: ButtonConfiguration) = ()

[<JavaScriptType>]
type Button [<JavaScript>]()= 
    inherit Widget()
    
    [<DefaultValue>]
    val mutable private isEnabled: bool

    [<JavaScript>]
    /// Returns wether button is enabled or not.
    member this.IsEnabled
        with get () =
            this.isEnabled
    
    (****************************************************************
    * Constructors
    *****************************************************************)     
    /// Creates a new button given an element and a configuration object.
    [<JavaScript>]
    static member New (el : Element, conf: ButtonConfiguration): Button = 
        el
        |>! OnClick (fun _ ev ->
            ev.PreventDefault()
        )
        |> ignore
        
        let b = new Button()
        b.isEnabled <- true
        el 
        |>! OnAfterRender (fun el  -> 
            ButtonInternal.Init(el.Dom, conf)
        )
        |> ignore
        b.element <- el
        b

    /// Creates a new button given a configuration object.
    [<JavaScript>]
    static member New (conf: ButtonConfiguration): Button = 
        Button.New(Tag.Button [], conf)

    /// Creates a new button with the given label and
    /// using the default configuration object.
    [<JavaScript>]
    static member New (label: string): Button = 
        let conf = new ButtonConfiguration()
        conf.Label <- label
        Button.New(conf)

    (****************************************************************
    * Methods
    *****************************************************************)
    
    /// Removes the button functionality completely. 
    [<Inline "jQuery($this.element.el).button('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element.el).button('disable')">]
    member private this.disable () = ()

    /// Disables the button.
    [<JavaScript>]
    member this.Disable() =
        this.isEnabled <- false
        this.disable()

    [<Inline "jQuery($this.element.el).button('enable')">]
    member private this.enable () = ()

    /// Enables the button.
    [<JavaScript>]
    member this.Enable() =
        this.isEnabled <- true
        this.enable()

    /// Set any button option.
    [<Inline "jQuery($this.element.el).button('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Refreshes the visual state of the button. 
    /// Useful for updating button state after the native element's checked or disabled state 
    /// is changed programatically.
    [<Inline "jQuery($this.element.el).button('refresh')">]
    member this.Refresh (index: int) = ()

    (****************************************************************
    * Events
    *****************************************************************)
    
    /// Triggered when the button is clicked.
    [<JavaScript>]
    member this.OnClick (f : JQueryEvent -> unit) : unit =
        this.element
        |>! OnClick (fun _ ev ->
            ev.PreventDefault()
            if this.isEnabled then
                f ev
        )
        |> ignore



