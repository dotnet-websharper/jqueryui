// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2018 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}

//JQueryUI Wrapping: (version Stable 1.8rc1)
namespace WebSharper.JQueryUI

open WebSharper
open WebSharper.JavaScript
open WebSharper.Html.Client
open WebSharper.Html.Client.Events

type ButtonIconsConfiguration =
    {
        [<Name "primary">]
        Primary: string

        [<Name "secondary">]
        Secondary: string
    }
    [<JavaScript>]
    static member Default = {Primary = "ui-icon-gear"; Secondary = "ui-icon-triangle-1-s" }


type ButtonConfiguration[<JavaScript>] () =

    [<Name "disabled">]
    [<Stub>]
    member val Disabled = Unchecked.defaultof<bool> with get, set

    [<Name "icons">]
    [<Stub>]
    member val Icons = Unchecked.defaultof<ButtonIconsConfiguration> with get, set

    [<Name "label">]
    [<Stub>]
    //true by default
    member val Label = Unchecked.defaultof<string> with get, set

    [<Name "text">]
    [<Stub>]
    member val Text = Unchecked.defaultof<bool> with get, set


module internal ButtonInternal =
    [<Inline "jQuery($el).button($conf)">]
    let Init (el: Dom.Element, conf: ButtonConfiguration) = ()

[<Require(typeof<Dependencies.JQueryUIJs>)>]
[<Require(typeof<Dependencies.JQueryUICss>)>]
type Button [<JavaScript>]()=
    inherit Utils.Pagelet()

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
        |> OnAfterRender (fun el ->
            ButtonInternal.Init(el.Dom, conf)
        )
        |> ignore
        b.element <- el
        b

    /// Creates a new button given an element and a configuration object.
    [<JavaScript>]
    [<Name "New2">]
    static member New (genEl : unit -> Element, conf: ButtonConfiguration) : Button =
        let button = new Button()
        button.isEnabled <- true
        button.element <-
            genEl ()
            |>! OnAfterRender (fun el ->
                ButtonInternal.Init(el.Dom, conf)
            )
        button

    /// Creates a new button given a configuration object.
    [<JavaScript>]
    [<Name "New3">]
    static member New (conf: ButtonConfiguration): Button =
        Button.New(Tags.Button [], conf)

    /// Creates a new button with the given label and
    /// using the default configuration object.
    [<JavaScript>]
    [<Name "New4">]
    static member New (label: string): Button =
        let conf = new ButtonConfiguration(Label = label)
        Button.New(conf)

    (****************************************************************
    * Methods
    *****************************************************************)

    /// Removes the button functionality completely.
    [<Inline "jQuery($this.element.Dom).button('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element.Dom).button('disable')">]
    member private this.disable () = ()

    /// Disables the button.
    [<JavaScript>]
    member this.Disable() =
        this.isEnabled <- false
        this.disable()

    [<Inline "jQuery($this.element.Dom).button('enable')">]
    member private this.enable () = ()

    /// Enables the button.
    [<JavaScript>]
    member this.Enable() =
        this.isEnabled <- true
        this.enable()

    /// Set any button option.
    [<Inline "jQuery($this.element.Dom).button('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Get any button option.
    [<Inline "jQuery($this.element.Dom).button('option', $name)">]
    member this.Option (name: string) = X<obj>

    /// Gets all options.
    [<Inline "jQuery($this.element.Dom).button('option')">]
    member this.Option () = X<ButtonConfiguration>

    /// Sets one or more options.
    [<Inline "jQuery($this.element.Dom).button('option', $options)">]
    member this.Option (options: ButtonConfiguration) = X<unit>

    [<Inline "jQuery($this.element.Dom).button('widget')">]
    member private this.getWidget () = X<Dom.Element>

    /// Returns the .ui-button element.
    [<JavaScript>]
    member this.Widget = this.getWidget()

    /// Refreshes the visual state of the button.
    /// Useful for updating button state after the native element's checked or disabled state
    /// is changed programatically.
    [<Inline "jQuery($this.element.Dom).button('refresh')">]
    member this.Refresh (index: int) = ()

    (****************************************************************
    * Events
    *****************************************************************)

    [<Inline "jQuery($this.element.Dom).bind('buttoncreate', function (x,y) {($f(x));})">]
    member private this.onCreate(f : JQuery.Event -> unit) = ()

    /// This event is triggered when button is created.
    [<JavaScript>]
    member this.OnCreate f =
        this
        |> OnAfterRender (fun _ -> this.onCreate f)
        |> ignore

    /// Triggered when the button is clicked.
    [<JavaScript>]
    member this.OnClick (f : Events.MouseEvent -> unit) : unit =
        this.element
        |> OnClick (fun _ ev ->
            // ev.PreventDefault()
            if this.isEnabled then
                f ev
        )




