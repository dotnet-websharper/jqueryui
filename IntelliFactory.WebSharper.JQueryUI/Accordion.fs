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

type AccordionIconConfiguration =
    {
        [<Name "header">]
        Header: string

        [<Name "headerSelected">]
        HeaderSelected: string
    }
    [<JavaScript>]
    static member Default =
        { Header="ui-icon-triangle-1-e"; HeaderSelected="ui-icon-triangle-1-s" }

type AccordionConfiguration[<JavaScript>]() =

    [<Name "active">]
    [<Stub>]
    member val Active = Unchecked.defaultof<int> with get, set

    [<Name "animate">]
    [<Stub>]
    member val Animated = Unchecked.defaultof<string> with get, set

    [<Name "collapsible">]
    [<Stub>]
    member val Collapsible = Unchecked.defaultof<bool> with get, set

    [<Name "disabled">]
    [<Stub>]
    member val Disabled = Unchecked.defaultof<bool> with get, set

    [<Name "event">]
    [<Stub>]
    member val Event = Unchecked.defaultof<string> with get, set

    [<Name "header">]
    [<Stub>]
    member val Header = Unchecked.defaultof<string> with get, set

    [<Name "heightStyle">]
    [<Stub>]
    member val HeightStyle = Unchecked.defaultof<string> with get, set

    [<Name "icons">]
    [<Stub>]
    member val Icons = Unchecked.defaultof<AccordionIconConfiguration> with get, set

type AccordionCreateEvent =
    {
        [<Name "header">]
        Header: JQuery.JQuery

        [<Name "panel">]
        Panel: JQuery.JQuery
    }

type AccordionChangeEvent =
    {
        [<Name "newHeader">]
        NewHeader: JQuery.JQuery

        [<Name "newPanel">]
        NewPanel: JQuery.JQuery

        [<Name "oldHeader">]
        OldHeader: JQuery.JQuery

        [<Name "oldPanel">]
        OldPanel: JQuery.JQuery
    }

module internal AccordianInternal =
    [<Inline "jQuery($el).accordion($conf)">]
    let internal Init (el: Dom.Element, conf: AccordionConfiguration) = ()

[<Require(typeof<Dependencies.JQueryUIJs>)>]
[<Require(typeof<Dependencies.JQueryUICss>)>]
type Accordion[<JavaScript>] internal () =
    inherit Pagelet()

    (****************************************************************
    * Constructors
    *****************************************************************)
    /// Create an accordion with title and content panels according to the
    /// given list of name and value pairs.
    [<JavaScript>]
    [<Name "New1">]
    static member New (els : List<string * Element>, conf: AccordionConfiguration): Accordion =
        let a = new Accordion()
        let panel =
            let els =
                els
                |> List.map (fun (header, el) ->
                    [
                        H3 [A [Attr.HRef "#"; Text header]]
                        Div [el]
                    ]
                )
                |> List.concat
            Div els
            |>! OnAfterRender (fun el ->
                AccordianInternal.Init(el.Body :?> _, conf)
            )
        a.element <- panel
        a

    /// Create an accordion with default configuration settings.
    [<JavaScript>]
    [<Name "New2">]
    static member New (els : List<string * Element>): Accordion =
        Accordion.New(els, new AccordionConfiguration())

    (****************************************************************
    * Methods
    *****************************************************************)
    /// Remove the accordion functionality completely.
    /// This will return the element back to its pre-init state.
    [<Inline "jQuery($this.element.Body).accordion('destroy')">]
    member this.Destroy() = ()

    /// Disable the accordion.
    [<Inline "jQuery($this.element.Body).accordion('disable')">]
    member this.Disable () = ()

    /// Enables the accordion.
    [<Inline "jQuery($this.element.Body).accordion('enable')">]
    member this.Enable () = ()

    [<Inline "jQuery($this.element.Body).accordion('widget')">]
    member private this.getWidget () = X<Dom.Element>

    /// Returns the .ui-accordion element.
    [<JavaScript>]
    member this.Widget = this.getWidget()

    /// Gets or sets any accordion option.
    [<Inline "jQuery($this.element.Body).accordion('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Gets or sets any accordion option.
    [<Inline "jQuery($this.element.Body).accordion('option', $name)">]
    member this.Option (name: string) = X<obj>

    /// Gets all options.
    [<Inline "jQuery($this.element.Body).accordion('option')">]
    member this.Option () = X<AccordionConfiguration>

    /// Sets one or more options.
    [<Inline "jQuery($this.element.Body).accordion('option', $options)">]
    member this.Option (options: AccordionConfiguration) = X<unit>

    /// Activate a content part of the accordion with the
    /// corresponding zero-based index.
    [<Inline "jQuery($this.element.Body).accordion('option', 'active', $index)">]
    member this.Activate (index: int) = ()

    /// Pass false to close all content parts (only possible with collapsible=true).
    [<Inline "jQuery($this.element.Body).accordion('option', 'active', $keep_open)">]
    member this.Activate (keep_open: bool) = ()

    /// Recompute heights of the accordion contents when using the fillSpace
    /// option and the container height changed. For example, when the container
    /// is a resizable, this method should be called by its resize-event.
    [<Inline "jQuery($this.element.Body).accordion('refresh')">]
    member this.Refresh () = ()

    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element.Body).bind('accordioncreate', function (x,y) {($f(x))(y);})">]
    member private this.onCreate(f : JQuery.Event -> AccordionCreateEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('accordionbeforeactivate', function (x,y) {($f(x))(y);})">]
    member private this.onBeforeActivate(f : JQuery.Event -> AccordionChangeEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('accordionactivate', function (x,y) {($f(x))(y);})">]
    member private this.onActivate(f : JQuery.Event -> AccordionChangeEvent -> unit) = ()

    /// This event is triggered when accordion is created.
    [<JavaScript>]
    member this.OnCreate f =
        this
        |> OnAfterRender (fun _ ->
            this.onCreate f
        )

    /// Event triggered every time the accordion changes.
    /// If the accordion is animated, the event will be triggered
    /// upon completion of the animation; otherwise,
    /// it is triggered immediately.
    [<JavaScript>]
    member this.OnBeforeActivate f =
        this
        |> OnAfterRender (fun _ ->
            this.onBeforeActivate f
        )

    /// Event triggered every time the accordion starts to change.
    [<JavaScript>]
    member this.OnActivate f =
        this
        |> OnAfterRender (fun _ ->
            this.onActivate f
        )
