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
open IntelliFactory.WebSharper.Html.Events

type ButtonIconsConfiguration =
    {
        [<Name "primary">]
        Primary: string

        [<Name "Secondary">]
        Secondary: string
    }
    [<JavaScript>]
    static member Default = {Primary = "ui-icon-gear"; Secondary = "ui-icon-triangle-1-s" }


type ButtonConfiguration[<JavaScript>] () =

    [<DefaultValue>]
    [<Name "disabled">]
    val mutable Disabled: bool

    [<DefaultValue>]
    [<Name "text">]
    val mutable Text: bool

    [<DefaultValue>]
    [<Name "label">]
    //true by default
    val mutable Label: string

    [<DefaultValue>]
    [<Name "icons">]
    val mutable Icons: ButtonIconsConfiguration


module internal ButtonInternal =
    [<Inline "jQuery($el).button($conf)">]
    let Init (el: Dom.Element, conf: ButtonConfiguration) = ()

[<Require(typeof<Dependencies.JQueryUIJs>)>]
[<Require(typeof<Dependencies.JQueryUICss>)>]
type Button [<JavaScript>]()=
    inherit Pagelet()

    [<DefaultValue>]
    val mutable private isEnabled: bool

    [<JavaScript>]
    /// Returns weather button is enabled or not.
    member this.IsEnabled
        with get () =
            this.isEnabled

    (****************************************************************
    * Constructors
    *****************************************************************)
    /// Creates a new button given an element and a configuration object.
    [<JavaScript>]
    [<Name "New1">]
    static member New (el : Element, conf: ButtonConfiguration): Button =
        let b = new Button()
        b.isEnabled <- true
        el
        |> OnAfterRender (fun el  ->
            ButtonInternal.Init(el.Body, conf)
        )
        |> ignore
        b.element <- el
        b

    /// Creates a new button given an element and a configuration object.
    [<JavaScript>]
    [<Name "New3">]
    static member New (genEl : unit -> Element, conf: ButtonConfiguration) : Button =
        let button = new Button()
        button.isEnabled <- true
        button.element <-
            genEl ()
            |>! OnAfterRender (fun el  ->
                ButtonInternal.Init(el.Body, conf)
            )
        button

    /// Creates a new button given a configuration object.
    [<JavaScript>]
    [<Name "New2">]
    static member New (conf: ButtonConfiguration): Button =
        Button.New(IntelliFactory.WebSharper.Html.Default.Button [], conf)

    /// Creates a new button with the given label and
    /// using the default configuration object.
    [<JavaScript>]
    [<Name "New3">]
    static member New (label: string): Button =
        let conf = new ButtonConfiguration()
        conf.Label <- label
        Button.New(conf)

    (****************************************************************
    * Methods
    *****************************************************************)

    /// Removes the button functionality completely.
    [<Inline "jQuery($this.element.Body).button('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element.Body).button('disable')">]
    member private this.disable () = ()

    /// Disables the button.
    [<JavaScript>]
    member this.Disable() =
        this.isEnabled <- false
        this.disable()

    [<Inline "jQuery($this.element.Body).button('enable')">]
    member private this.enable () = ()

    /// Enables the button.
    [<JavaScript>]
    member this.Enable() =
        this.isEnabled <- true
        this.enable()

    /// Set any button option.
    [<Inline "jQuery($this.element.Body).button('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Refreshes the visual state of the button.
    /// Useful for updating button state after the native element's checked or disabled state
    /// is changed programatically.
    [<Inline "jQuery($this.element.Body).button('refresh')">]
    member this.Refresh (index: int) = ()

    (****************************************************************
    * Events
    *****************************************************************)

    /// Triggered when the button is clicked.
    [<JavaScript>]
    member this.OnClick (f : Events.MouseEvent -> unit) : unit =
        this.element
        |> Events.OnClick (fun _ ev ->
            // ev.PreventDefault()
            if this.isEnabled then
                f ev
        )




