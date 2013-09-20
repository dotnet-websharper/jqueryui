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

type DatepickerShowOptionsConfiguration =
    {
        [<Name "showOptions">]
        Direction: string
    }

    [<JavaScript>]
    static member Default = {Direction = "up"}

type DatepickerConfiguration[<JavaScript>]() =

    [<DefaultValue>]
    val mutable disabled: bool

    [<DefaultValue>]
    val mutable altField: string

    [<DefaultValue>]
    val mutable altFormat: string

    [<DefaultValue>]
    //"" by default
    val mutable appendText: string

    [<DefaultValue>]
    //false by default
    val mutable autoSize: bool

    [<DefaultValue>]
    //"" by default
    val mutable buttonImage: string

    [<DefaultValue>]
    //false by default
    val mutable buttonImageOnly: bool

    [<DefaultValue>]
    //"..." by default
    val mutable buttonText: string

    [<DefaultValue>]
    //"iso8601Week" by default
    val mutable calculateWeek: EcmaScript.Date -> int

    [<DefaultValue>]
    //fasle by default
    val mutable changeMonth: bool

    [<DefaultValue>]
    //fasle by default
    val mutable changeYear: bool

    [<DefaultValue>]
    //"Done" by default
    val mutable closeText: string

    [<DefaultValue>]
    //true by default
    val mutable constrainInput: bool

    [<DefaultValue>]
    //"Today" by default
    val mutable currentText: string

    [<DefaultValue>]
    //"mm/dd/yy" by default
    val mutable dateFormat: string

    [<DefaultValue>]
    //array<string> = [|"Sunday"; "Monday"; "Tuesday"; "Wednesday"; "Thursday"; "Friday"; "Saturday"|]
    val mutable dayNames: array<string>

    [<DefaultValue>]
    // array<string> = [|"Su"; "Mo"; "Tu"; "We"; "Th"; "Fr"; "Sa"|]
    val mutable dayNamesMin: array<string>

    [<DefaultValue>]
    // array<string> = [|"Sun"; "Mon"; "Tue"; "Wed"; "Thu"; "Fri"; "Sat"|]
    val mutable dayNamesShort: array<string>

    [<DefaultValue>]
    // null by default
    val mutable defaultDate: EcmaScript.Date

    [<DefaultValue>]
    // "normal" by default
    val mutable duration: string

    [<DefaultValue>]
    // 0 by default
    val mutable firstDay: int

    [<DefaultValue>]
    // fasle by default
    val mutable gotoCurrent: bool

    [<DefaultValue>]
    // fasle by default
    val mutable hideIfNoPrevNext: bool

    [<DefaultValue>]
    // false by default
    val mutable isRTL: bool

    [<DefaultValue>]
    // null by default
    val mutable maxDate: string

    [<DefaultValue>]
    // null by default
    val mutable minDate: EcmaScript.Date

    [<DefaultValue>]
    // by default [|"January"; "February"; "March"; "April"; "May"; "June"; "July"; "August"; "September"; "October"; "November"; "December"|]
    val mutable monthNames: array<string>

    [<DefaultValue>]
    // by default [|"Jan"; "Feb"; "Mar"; "Apr"; "May"; "Jun"; "Jul"; "Aug"; "Sep"; "Oct"; "Nov"; "Dec"|]
    val mutable monthNamesShort: array<string>

    [<DefaultValue>]
    // false by default
    val mutable navigationAsDateFormat: bool

    [<DefaultValue>]
    // "Next" by default
    val mutable nextText: string

    [<DefaultValue>]
    //1 by default
    val mutable numberOfMonths: array<int>

    [<DefaultValue>]
    // "Prev" by default
    val mutable prevText: string

    [<DefaultValue>]
    // false by default
    val mutable selectOtherMonths: bool

    [<DefaultValue>]
    // "+10" by default
    val mutable shortYearCutoff: int

    [<DefaultValue>]
    // "show" by default
    val mutable showAnim: string

    [<DefaultValue>]
    // false by default
    val mutable showButtonPanel: bool

    [<DefaultValue>]
    // 0 by default
    val mutable showCurrentAtPos: int

    [<DefaultValue>]
    // fasle by default
    val mutable showMonthAfterYear: bool

    [<DefaultValue>]
    // "focus" by default
    val mutable showOn: string

    [<DefaultValue>]
    //{} by default
    val mutable showOptions: DatepickerShowOptionsConfiguration

    [<DefaultValue>]
    // false by default
    val mutable showOtherMonths: bool

    [<DefaultValue>]
    //false by default
    val mutable showWeek: bool

    [<DefaultValue>]
    // 1 by default
    val mutable stepMonths: int

    [<DefaultValue>]
    // 1 by default
    val mutable weekHeader: string

    [<DefaultValue>]
    // "-10:+10" by default
    val mutable yearRange: string

    [<DefaultValue>]
    // 1 by default
    val mutable yearSuffix: string

module internal DatepickerInternal =
    [<Inline "jQuery($el).datepicker($conf)">]
    let Init (el: Dom.Element, conf: DatepickerConfiguration) = ()

    [<Inline "jQuery($el).datepicker('getDate')">]
    let getDate (el: Dom.Element) : EcmaScript.Date =
        Unchecked.defaultof<_>

[<Require(typeof<Dependencies.JQueryUIJs>)>]
[<Require(typeof<Dependencies.JQueryUICss>)>]
type Datepicker[<JavaScript>] internal  () =
    inherit Pagelet()

    (****************************************************************
    * Constructors
    *****************************************************************)
    [<JavaScript>]
    /// Creates a new datepicker given an element and a configuration object.
    [<Name "New1">]
    static member New (el: Element, conf: DatepickerConfiguration): Datepicker =
        let dp = new Datepicker()
        dp.element <- el
        el
        |> OnAfterRender (fun el  ->
            DatepickerInternal.Init(el.Body, conf))
        |> ignore
        dp

    /// Creates a new datepicker given an element, using the default
    /// configuration.
    [<JavaScript>]
    [<Name "New2">]
    static member New (el:Element): Datepicker =
        Datepicker.New(el, new DatepickerConfiguration())

    /// Creates a new datepicker using an empty Div element and
    /// the given configuration object.
    [<JavaScript>]
    [<Name "New3">]
    static member New (conf: DatepickerConfiguration): Datepicker =
        Datepicker.New(Div [], conf)

    /// Creates a new datepicker using an empty Div element and
    /// the default configuration.
    [<JavaScript>]
    [<Name "New4">]
    static member New (): Datepicker =
        Datepicker.New(Div [], new DatepickerConfiguration())


    (****************************************************************
    * Methods
    *****************************************************************)
    /// Destroys the datepicker functionality.
    [<Inline "jQuery($this.element.Body).datepicker('destroy')">]
    member this.Destroy() = ()

    /// Disables the datepicker functionality.
    [<Inline "jQuery($this.element.Body).datepicker('disable')">]
    member this.Disable () = ()

    /// Enables the datepicker functionality.
    [<Inline "jQuery($this.element.Body).datepicker('enable')">]
    member this.Enable () = ()

    /// Set a datepicker option.
    [<Inline "jQuery($this.element.Body).datepicker('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Get a datepicker option.
    [<Inline "jQuery($this.element.Body).datepicker('option', $name)">]
    member this.Option (name: string) = X<obj>

    [<Inline "jQuery($this.element.Body).datepicker('widget')">]
    member private this.getWidget () = X<Dom.Element>

    /// Returns the .ui-datepicker element.
    [<JavaScript>]
    member this.Widget = this.getWidget()

    /// Open a datepicker in a "dialog" box.
    [<Inline "jQuery($this.element.Body).datepicker('dialog', $date, function(x,y){return ($onSelect(x))(y)}, $settings, $pos)">]
    member this.Dialog (date: EcmaScript.Date, onSelect: string -> Datepicker -> unit, settings: DatepickerConfiguration, pos: int * int) = ()

    /// Open a datepicker in a "dialog" box.
    [<Inline "jQuery($this.element.Body).datepicker('dialog', $date, function(x,y){return ($onSelect(x))(y)}, $settings)">]
    member this.Dialog (date: EcmaScript.Date, onSelect: string -> Datepicker -> unit, settings: DatepickerConfiguration) = ()

    /// Open a datepicker in a "dialog" box.
    [<Inline "jQuery($this.element.Body).datepicker('dialog', $date, function(x,y){return ($onSelect(x))(y)})">]
    member this.Dialog (date: EcmaScript.Date, onSelect: string -> Datepicker -> unit) = ()

    /// Open a datepicker in a "dialog" box.
    [<Inline "jQuery($this.element.Body).datepicker('dialog', $date)">]
    member this.Dialog (date: EcmaScript.Date) = ()

    /// Returns true or false wether the datepicker is disabled.
    [<Inline "jQuery($this.element.Body).datepicker('isDisabled')">]
    member this.IsDisabled () : bool = Unchecked.defaultof<_>()

    /// Hides the datepicker.
    [<Inline "jQuery($this.element.Body).datepicker('hide')">]
    member this.Hide () = ()

    /// Shows the datepicker.
    [<Inline "jQuery($this.element.Body).datepicker('show')">]
    member this.Show () = ()

    /// Redraw a date picker, after having made some external modifications.
    [<Inline "jQuery($this.element.Body).datepicker('refresh')">]
    member this.Refresh () = ()

    /// Get the currently selected date of the datepicker.
    [<Inline "jQuery($this.element.Body).datepicker('getDate')">]
    member this.GetDate () : EcmaScript.Date = Unchecked.defaultof<_>()

    /// Sets the selected date.
    [<Inline "jQuery($this.element.Body).datepicker('setDate', $date)">]
    member this.SetDate (date:string) = ()

    /// Sets the selected date.
    [<Inline "jQuery($this.element.Body).datepicker('setDate', $date)">]
    member this.SetDate (date:EcmaScript.Date) = ()


    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element.Body).datepicker({beforeShow: function (x,y) {($f(x))(y);}})">]
    member private this.onBeforeShow(f : string -> Datepicker -> unit) = ()

    [<Inline "jQuery($this.element.Body).datepicker({beforeShowDay: function (x,y) {$f(x);}})">]
    member private this.onBeforeShowDay(f : EcmaScript.Date -> unit) = ()

    [<Inline "jQuery($this.element.Body).datepicker({beforeShowDay: function (x,y,z) {(($f(x))(y))(z);}})">]
    member private this.onChangeMonthYear(f : int -> int -> Datepicker -> unit) = ()

    [<Inline "jQuery($this.element.Body).datepicker({onSelect: function (x,y) {($f(x))(y);}})">]
    member private this.onSelect(f : string -> Datepicker -> unit) = ()

    [<Inline "jQuery($this.element.Body).datepicker({onClose: function (x,y) {($f(x))(y);}})">]
    member private this.onClose(f : string -> Datepicker -> unit) = ()

    [<JavaScript>]
    member this.OnBeforeShow(f: EcmaScript.Date -> Datepicker -> unit) : unit =
        this
        |> OnBeforeRender(fun _ ->
            this.onBeforeShow <| fun _ d ->
                f (DatepickerInternal.getDate this.element.Dom) d
        )
        |> ignore

    [<JavaScript>]
    member this.OnBeforeShowDay(f: EcmaScript.Date -> unit) : unit =
        this
        |> OnBeforeRender(fun _ -> this.onBeforeShowDay f)
        |> ignore

    [<JavaScript>]
    member this.OnChangeMonthYear(f: int -> int -> Datepicker -> unit) : unit =
        this
        |> OnBeforeRender(fun _ -> this.onChangeMonthYear f)
        |> ignore

    [<JavaScript>]
    member this.OnClose(f: EcmaScript.Date -> Datepicker -> unit) : unit =
        this
        |> OnBeforeRender(fun _ ->
            this.onClose <| fun _ d ->
                f (DatepickerInternal.getDate this.element.Dom) d
        )
        |> ignore

    // Adding an event and delayin it if the Pagelet is not yet rendered.
    /// Triggered when a date is selected.
    [<JavaScript>]
    member this.OnSelect(f: EcmaScript.Date -> Datepicker -> unit) : unit =
        this
        |> OnBeforeRender(fun _ ->
            this.onSelect <| fun _ d ->
                f (DatepickerInternal.getDate this.element.Dom) d
        )
        |> ignore


