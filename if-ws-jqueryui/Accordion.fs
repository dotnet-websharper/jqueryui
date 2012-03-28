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

    [<DefaultValue>]
    val mutable active: int

    [<DefaultValue>]
    val mutable animated: string

    [<DefaultValue>]
    val mutable autoHeight: bool

    [<DefaultValue>]
    val mutable clearStyle: bool

    [<DefaultValue>]
    val mutable collapsible: bool

    [<DefaultValue>]
    val mutable event: string

    [<DefaultValue>]
    val mutable fillSpace: bool

    [<DefaultValue>]
    val mutable header: string

    [<DefaultValue>]
    val mutable icons: AccordionIconConfiguration

    [<DefaultValue>]
    val mutable navigation: bool

    [<DefaultValue>]
    val mutable navigationFilter: unit -> unit

type AccordionChangeEvent =
    {
        [<Name "newHeader">]
        NewHeader: JQuery.JQuery

        [<Name "newContent">]
        NewContent: JQuery.JQuery

        [<Name "oldHeader">]
        OldHeader: JQuery.JQuery

        [<Name "oldContent">]
        OldContent: JQuery.JQuery

        [<Name "options">]
        Options: AccordionConfiguration
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

    /// Gets or sets any accordion option.
    [<Inline "jQuery($this.element.Body).accordion('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Activate a content part of the accordion with the
    /// corresponding zero-based index.
    [<Inline "jQuery($this.element.Body).accordion('activate', $index)">]
    member this.Activate (index: int) = ()

    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element.Body).accordion({change: function (x,y) {($f(x))(y);}})">]
    member private this.onChange(f : JQuery.Event -> AccordionChangeEvent -> unit) = ()

    [<Inline "jQuery($this.element.Body).accordion({changestart: function (x,y) {($f(x))(y);}})">]
    member private this.onChangestart(f : JQuery.Event -> AccordionChangeEvent -> unit) = ()

    /// Event triggered every time the accordion changes.
    /// If the accordion is animated, the event will be triggered
    /// upon completion of the animation; otherwise,
    /// it is triggered immediately.
    [<JavaScript>]
    member this.OnChange f =
        this
        |> OnAfterRender (fun _ ->
            this.onChange f
        )

    /// Event triggered every time the accordion starts to change.
    [<JavaScript>]
    member this.OnChangeStart f =
        this
        |> OnAfterRender (fun _ ->
            this.onChangestart f
        )
