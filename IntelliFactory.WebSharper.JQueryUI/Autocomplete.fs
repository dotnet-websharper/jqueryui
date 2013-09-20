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

type AutocompleteConfiguration[<JavaScript>]() =

    [<DefaultValue>]
    val mutable disabled: bool

    [<DefaultValue>]
    val mutable appendTo: string

    [<DefaultValue>]
    val mutable autoFocus: bool

    [<DefaultValue>]
    val mutable delay: int

    [<DefaultValue>]
    val mutable minLength: int

    [<DefaultValue>]
    val mutable position: PositionConfiguration

    [<DefaultValue>]
    val mutable source: array<string>

module internal AutocompleteInternal =
    [<Inline "jQuery($el).autocomplete($conf)">]
    let Init (el: Dom.Element, conf: AutocompleteConfiguration) = ()

[<Require(typeof<Dependencies.JQueryUIJs>)>]
[<Require(typeof<Dependencies.JQueryUICss>)>]
type Autocomplete[<JavaScript>] internal () =

    [<DefaultValue>]
    val mutable internal element : IPagelet

    interface IPagelet with
        [<JavaScript>]
        member this.Render () =
            this.element.Render()
        [<JavaScript>]
        member this.Body = this.element.Body


    (****************************************************************
    * Constructors
    *****************************************************************)
    /// Creates an autocomplete widget from the given element and
    /// configuration object.
    [<JavaScript>]
    [<Name "New1">]
    static member New (el : Element, conf: AutocompleteConfiguration): Autocomplete =
        let a = new Autocomplete()
        el
        |> OnAfterRender (fun el  ->
            AutocompleteInternal.Init(el.Body :?> _, conf)
        )
        a.element <- el
        a

    /// Creates an autocomplete widget from the given element and
    /// configuration object.
    [<JavaScript>]
    [<Name "New2">]
    static member New (el : Element): Autocomplete =
        Autocomplete.New(el, new AutocompleteConfiguration())

    /// Creates an autocomplete widget from an input element using
    /// the default configuration.
    [<JavaScript>]
    [<Name "New3">]
    static member New (): Autocomplete =
        Autocomplete.New(Input [], new AutocompleteConfiguration())

    /// Creates an autocomplete widget from an input element using
    /// the given configuration.
    [<JavaScript>]
    [<Name "New4">]
    static member New (conf: AutocompleteConfiguration): Autocomplete =
        Autocomplete.New(Input [], conf)

    (****************************************************************
    * Methods
    *****************************************************************)
    /// Remove the autocomplete functionality completely.
    [<Inline "jQuery($this.element.Body).autocomplete('destroy')">]
    member this.Destroy() = ()

    /// Disables the autocomplete.
    [<Inline "jQuery($this.element.Body).autocomplete('disable')">]
    member this.Disable () = ()

    // Enables the autocomplete.
    [<Inline "jQuery($this.element.Body).autocomplete('enable')">]
    member this.Enable () = ()

    /// Get or set any autocomplete option. If no value is specified, will act as a getter.
    [<Inline "jQuery($this.element.Body).autocomplete('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Get or set any autocomplete option. If no value is specified, will act as a getter.
    [<Inline "jQuery($this.element.Body).autocomplete('option', $name)">]
    member this.Option (name: string) = X<obj>

    [<Inline "jQuery($this.element.Body).autocomplete('widget')">]
    member private this.getWidget () = X<Dom.Element>

    /// Returns the .ui-autocomplete element.
    [<JavaScript>]
    member this.Widget = this.getWidget()

    /// Triggers a search event using the current string value, which, when data is available,
    /// then will display the suggestions;
    /// can be used by a selectbox-like button to open the suggestions when clicked.
    /// The current input's value is used.
    [<Inline "jQuery($this.element.Body).autocomplete('search')">]
    member this.Search () = ()

    /// Triggers a search event using the given string value, which, when data is
    /// available, then will display the suggestions;
    /// can be used by a selectbox-like button to open the suggestions when clicked.
    [<Inline "jQuery($this.element.Body).autocomplete('search', $value)">]
    member this.Search (value: string) = ()

    /// Close the Autocomplete menu. Useful in combination with
    /// the search method, to close the open menu.
    [<Inline "jQuery($this.element.Body).autocomplete('close')">]
    member this.Close () = ()

    (****************************************************************
    * Events
    *****************************************************************)

    [<Inline "jQuery($this.element.Body).bind('autocompletecreate', function (x,y) {($f(x));})">]
    member private this.onCreate(f : JQuery.Event -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('autocompletesearch', function (x,y) {($f(x));})">]
    member private this.onSearch(f : JQuery.Event -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('autocompleteopen', function (x,y) {($f(x));})">]
    member private this.onOpen(f : JQuery.Event -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('autocompletefocus', function (x,y) {($f(x))(y.item);})">]
    member private this.onFocus(f : JQuery.Event -> string -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('autocompleteselect', function (x,y) {($f(x))(y.item);})">]
    member private this.onSelect(f : JQuery.Event -> string -> unit) = ()

    [<Inline "jQuery($this.element.Body).bind('autocompleteclose', function (x,y) {($f(x));})">]
    member private this.onClose(f : JQuery.Event -> unit) = ()

    /// After an item was selected; ui.item refers to the selected item.
    /// Always triggered after the close event
    [<Inline "jQuery($this.element.Body).bind('autocompletechange', function (x,y) {($f(x))(y.item);})">]
    member private this.onChange(f : JQuery.Event -> string -> unit) = ()

    /// This event is triggered when autocomplete is created.
    [<JavaScript>]
    member this.OnCreate f =
        this
        |> OnAfterRender (fun _ -> this.onCreate f)
        |> ignore

    /// Triggered before a request (source-option) is started.
    [<JavaScript>]
    member this.OnSearch f =
        this
        |> OnAfterRender (fun _ -> this.onSearch f)
        |> ignore

    /// After an item was selected. Always triggered after the close event.
    [<JavaScript>]
    member this.OnChange f =
        this
        |> OnAfterRender (fun _ -> this.onChange f)
        |> ignore

    /// Triggered when the list is opened.
    [<JavaScript>]
    member this.OnOpen f =
        this
        |> OnAfterRender (fun _ -> this.onOpen f)
        |> ignore

    /// Triggered when the list is hidden.
    [<JavaScript>]
    member this.OnClose f =
        this
        |> OnAfterRender (fun _ -> this.onClose f)
        |> ignore

    /// Before focus is moved to an item (not selecting), ui.item refers to the focused item.
    [<JavaScript>]
    member this.OnFocus f =
        this
        |> OnAfterRender (fun _ -> this.onFocus f)
        |> ignore

    /// Tiggered when an item is selected from the menu;
    [<JavaScript>]
    member this.OnSelect f =
        this
        |> OnAfterRender (fun _ -> this.onSelect f)
        |> ignore
