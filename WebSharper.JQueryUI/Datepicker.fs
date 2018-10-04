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

type DatepickerShowOptionsConfiguration =
    {
        [<Name "showOptions">]
        Direction: string
    }

    [<JavaScript>]
    static member Default = {Direction = "up"}

type internal DatepickerInternal =
    [<Inline "jQuery($el).datepicker($conf)">]
    static member Init (el: Dom.Element, conf: DatepickerConfiguration) = ()

    [<Inline "jQuery($el).datepicker('getDate')">]
    static member getDate (el: Dom.Element) : Date =
        Unchecked.defaultof<_>

and DatepickerConfiguration[<JavaScript>]() =

    [<Name "altField">]
    [<Stub>]
    member val AltField = Unchecked.defaultof<string> with get, set

    [<Name "altFormat">]
    [<Stub>]
    member val AltFormat = Unchecked.defaultof<string> with get, set

    [<Name "appendText">]
    [<Stub>]
    //"" by default
    member val AppendText = Unchecked.defaultof<string> with get, set

    [<Name "autoSize">]
    [<Stub>]
    //false by default
    member val AutoSize = Unchecked.defaultof<bool> with get, set

    [<Name "buttonImage">]
    [<Stub>]
    //"" by default
    member val ButtonImage = Unchecked.defaultof<string> with get, set

    [<Name "buttonImageOnly">]
    [<Stub>]
    //false by default
    member val ButtonImageOnly = Unchecked.defaultof<bool> with get, set

    [<Name "buttonText">]
    [<Stub>]
    //"..." by default
    member val ButtonText = Unchecked.defaultof<string> with get, set

    [<Name "calculateWeek">]
    [<Stub>]
    //"iso8601Week" by default
    member val CalculateWeek = Unchecked.defaultof<Date -> int> with get, set

    [<Name "changeMonth">]
    [<Stub>]
    //false by default
    member val ChangeMonth = Unchecked.defaultof<bool> with get, set

    [<Name "changeYear">]
    [<Stub>]
    //false by default
    member val ChangeYear = Unchecked.defaultof<bool> with get, set

    [<Name "closeText">]
    [<Stub>]
    //"Done" by default
    member val CloseText = Unchecked.defaultof<string> with get, set

    [<Name "constrainInput">]
    [<Stub>]
    //true by default
    member val ConstrainInput = Unchecked.defaultof<bool> with get, set

    [<Name "currentText">]
    [<Stub>]
    //"Today" by default
    member val CurrentText = Unchecked.defaultof<string> with get, set

    [<Name "dateFormat">]
    [<Stub>]
    //"mm/dd/yy" by default
    member val DateFormat = Unchecked.defaultof<string> with get, set

    [<Name "dayNames">]
    [<Stub>]
    //array<string> = [|"Sunday"; "Monday"; "Tuesday"; "Wednesday"; "Thursday"; "Friday"; "Saturday"|]
    member val DayNames = Unchecked.defaultof<array<string>> with get, set

    [<Name "dayNamesMin">]
    [<Stub>]
    // array<string> = [|"Su"; "Mo"; "Tu"; "We"; "Th"; "Fr"; "Sa"|]
    member val DayNamesMin = Unchecked.defaultof<array<string>> with get, set

    [<Name "dayNamesShort">]
    [<Stub>]
    // array<string> = [|"Sun"; "Mon"; "Tue"; "Wed"; "Thu"; "Fri"; "Sat"|]
    member val DayNamesShort = Unchecked.defaultof<array<string>> with get, set

    [<Name "defaultDate">]
    [<Stub>]
    // null by default
    member val DefaultDate = Unchecked.defaultof<Date> with get, set

    [<Name "duration">]
    [<Stub>]
    // "normal" by default
    member val Duration = Unchecked.defaultof<string> with get, set

    [<Name "firstDay">]
    [<Stub>]
    // 0 by default
    member val FirstDay = Unchecked.defaultof<int> with get, set

    [<Name "gotoCurrent">]
    [<Stub>]
    // false by default
    member val GotoCurrent = Unchecked.defaultof<bool> with get, set

    [<Name "hideIfNoPrevNext">]
    [<Stub>]
    // false by default
    member val HideIfNoPrevNext = Unchecked.defaultof<bool> with get, set

    [<Name "isRTL">]
    [<Stub>]
    //false by default
    member val isRTL = Unchecked.defaultof<bool> with get, set

    [<Name "maxDate">]
    [<Stub>]
    // null by default
    member val MaxDate = Unchecked.defaultof<string> with get, set

    [<Name "minDate">]
    [<Stub>]
    // null by default
    member val MinDate = Unchecked.defaultof<Date> with get, set

    [<Name "monthNames">]
    [<Stub>]
    // by default [|"January"; "February"; "March"; "April"; "May"; "June"; "July"; "August"; "September"; "October"; "November"; "December"|]
    member val MonthNames = Unchecked.defaultof<array<string>> with get, set

    [<Name "monthNamesShort">]
    [<Stub>]
    // by default [|"Jan"; "Feb"; "Mar"; "Apr"; "May"; "Jun"; "Jul"; "Aug"; "Sep"; "Oct"; "Nov"; "Dec"|]
    member val MonthNamesShort = Unchecked.defaultof<array<string>> with get, set

    [<Name "navigationAsDateFormat">]
    [<Stub>]
    // false by default
    member val NavigationAsDateFormat = Unchecked.defaultof<bool> with get, set

    [<Name "nextText">]
    [<Stub>]
    // "Next" by default
    member val NextText = Unchecked.defaultof<string> with get, set

    [<Name "numberOfMonths">]
    [<Stub>]
    //1 by default
    member val NumberOfMonths = Unchecked.defaultof<array<int>> with get, set

    [<Name "onChangeMonthYear">]
    [<Stub>]
    member val OnChangeMonthYear = Unchecked.defaultof<int * int * Datepicker -> unit> with get, set

    [<Name "onClose">]
    [<Stub>]
    member val OnClose = Unchecked.defaultof<string -> unit> with get, set

    [<Name "onSelect">]
    [<Stub>]
    member val OnSelect = Unchecked.defaultof<string -> unit> with get, set

    [<Name "prevText">]
    [<Stub>]
    // "Prev" by default
    member val PrevText = Unchecked.defaultof<string> with get, set

    [<Name "selectOtherMonths">]
    [<Stub>]
    // false by default
    member val SelectOtherMonths = Unchecked.defaultof<bool> with get, set

    [<Name "shortYearCutoff">]
    [<Stub>]
    // "+10" by default
    member val ShortYearCutoff = Unchecked.defaultof<int> with get, set

    [<Name "showAnim">]
    [<Stub>]
    // "show" by default
    member val ShowAnim = Unchecked.defaultof<string> with get, set

    [<Name "showButtonPanel">]
    [<Stub>]
    // false by default
    member val ShowButtonPanel = Unchecked.defaultof<bool> with get, set

    [<Name "showCurrentAtPos">]
    [<Stub>]
    // 0 by default
    member val ShowCurrentAtPos = Unchecked.defaultof<int> with get, set

    [<Name "showMonthAfterYear">]
    [<Stub>]
    // false by default
    member val ShowMonthAfterYear = Unchecked.defaultof<bool> with get, set

    [<Name "showOn">]
    [<Stub>]
    // "focus" by default
    member val ShowOn = Unchecked.defaultof<string> with get, set

    [<Name "showOptions">]
    [<Stub>]
    //{} by default
    member val ShowOptions = Unchecked.defaultof<DatepickerShowOptionsConfiguration> with get, set

    [<Name "showOtherMonths">]
    [<Stub>]
    // false by default
    member val ShowOtherMonths = Unchecked.defaultof<bool> with get, set

    [<Name "showWeek">]
    [<Stub>]
    //false by default
    member val ShowWeek = Unchecked.defaultof<bool> with get, set

    [<Name "stepMonths">]
    [<Stub>]
    // 1 by default
    member val StepMonths = Unchecked.defaultof<int> with get, set

    [<Name "weekHeader">]
    [<Stub>]
    // 1 by default
    member val WeekHeader = Unchecked.defaultof<string> with get, set

    [<Name "yearRange">]
    [<Stub>]
    // "-10:+10" by default
    member val YearRange = Unchecked.defaultof<string> with get, set

    [<Name "yearSuffix">]
    [<Stub>]
    // 1 by default
    member val YearSuffix = Unchecked.defaultof<string> with get, set

and
    [<Require(typeof<Dependencies.JQueryUIJs>)>]
    [<Require(typeof<Dependencies.JQueryUICss>)>]
    Datepicker[<JavaScript>] internal  () =
    inherit Utils.Pagelet()

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
            DatepickerInternal.Init(el.Dom, conf))
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
        //WARNING! Datepicker behaves on a different fashion when 
        //attached to a div, compared to an input (i.e. hide/show methods)
        Datepicker.New(Div [], new DatepickerConfiguration())


    (****************************************************************
    * Methods
    *****************************************************************)
    /// Destroys the datepicker functionality.
    [<Inline "jQuery($this.element.Dom).datepicker('destroy')">]
    member this.Destroy() = ()

    /// Disables the datepicker functionality.
    [<Inline "jQuery($this.element.Dom).datepicker('disable')">]
    member this.Disable () = ()

    /// Enables the datepicker functionality.
    [<Inline "jQuery($this.element.Dom).datepicker('enable')">]
    member this.Enable () = ()

    /// Set a datepicker option.
    [<Inline "jQuery($this.element.Dom).datepicker('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Get a datepicker option.
    [<Inline "jQuery($this.element.Dom).datepicker('option', $name)">]
    member this.Option (name: string) = X<obj>

    /// Gets all options.
    [<Inline "jQuery($this.element.Dom).datepicker('option','all')">]
    member this.Option () = X<DatepickerConfiguration>

    /// Sets one or more options.
    [<Inline "jQuery($this.element.Dom).datepicker('option', $options)">]
    member this.Option (options: DatepickerConfiguration) = X<unit>

    [<Inline "jQuery($this.element.Dom).datepicker('widget')">]
    member private this.getWidget () = X<Dom.Element>

    /// Returns the .ui-datepicker element.
    [<JavaScript>]
    member this.Widget = this.getWidget()

    /// Open a datepicker in a "dialog" box.
    [<Inline "jQuery($this.element.Dom).datepicker('dialog', $date, function(x,y){return ($onSelect(x))(y)}, $settings, $pos)">]
    member this.Dialog (date: Date, onSelect: string -> Datepicker -> unit, settings: DatepickerConfiguration, pos: int * int) = ()

    /// Open a datepicker in a "dialog" box.
    [<Inline "jQuery($this.element.Dom).datepicker('dialog', $date, function(x,y){return ($onSelect(x))(y)}, $settings)">]
    member this.Dialog (date: Date, onSelect: string -> Datepicker -> unit, settings: DatepickerConfiguration) = ()

    /// Open a datepicker in a "dialog" box.
    [<Inline "jQuery($this.element.Dom).datepicker('dialog', $date, function(x,y){return ($onSelect(x))(y)})">]
    member this.Dialog (date: Date, onSelect: string -> Datepicker -> unit) = ()

    /// Open a datepicker in a "dialog" box.
    [<Inline "jQuery($this.element.Dom).datepicker('dialog', $date)">]
    member this.Dialog (date: Date) = ()

    /// Returns true or false wether the datepicker is disabled.
    [<Inline "jQuery($this.element.Dom).datepicker('isDisabled')">]
    member this.IsDisabled () : bool = Unchecked.defaultof<_>()

    /// Hides the datepicker.
    [<Inline "jQuery($this.element.Dom).datepicker('hide')">]
    member this.Hide () = ()

    /// Shows the datepicker.
    [<Inline "jQuery($this.element.Dom).datepicker('show')">]
    member this.Show () = ()

    /// Redraw a date picker, after having made some external modifications.
    [<Inline "jQuery($this.element.Dom).datepicker('refresh')">]
    member this.Refresh () = ()

    /// Get the currently selected date of the datepicker.
    [<Inline "jQuery($this.element.Dom).datepicker('getDate')">]
    member this.GetDate () : Date = Unchecked.defaultof<_>()

    /// Sets the selected date.
    [<Inline "jQuery($this.element.Dom).datepicker('setDate', $date)">]
    member this.SetDate (date:string) = ()

    /// Sets the selected date.
    [<Inline "jQuery($this.element.Dom).datepicker('setDate', $date)">]
    member this.SetDate (date:Date) = ()


    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element.Dom).datepicker('option',{beforeShow: function (x,y) {($f(x))(y);}})">]
    member private this.onBeforeShow(f : string -> Datepicker -> unit) = ()

    [<Inline "jQuery($this.element.Dom).datepicker('option',{beforeShowDay: function (x,y) {$f(x);}})">]
    member private this.onBeforeShowDay(f : Date -> unit) = ()

    [<Inline "jQuery($this.element.Dom).datepicker('option',{onChangeMonthYear: function (x,y,z) {(($f(x))(y))(z);}})">]
    member private this.onChangeMonthYear(f : int -> int -> Datepicker -> unit) = ()

    [<Inline "jQuery($this.element.Dom).datepicker('option',{onSelect: function (x,y) {($f(x))(y);}})">]
    member private this.onSelect(f : Date -> Datepicker -> unit) = ()

    [<Inline "jQuery($this.element.Dom).datepicker('option',{onClose: function (x,y) {($f(x))(y);}})">]
    member private this.onClose(f : Date -> Datepicker -> unit) = ()

    [<JavaScript>]
    member this.OnBeforeShow(f: Date -> Datepicker -> unit) : unit =
        this
        |> OnAfterRender(fun _ ->
            this.onBeforeShow <| fun _ d ->
                f (DatepickerInternal.getDate this.element.Dom) d
        )
        |> ignore

    [<JavaScript>]
    member this.OnBeforeShowDay(f: Date -> unit) : unit =
        this
        |> OnAfterRender(fun _ -> this.onBeforeShowDay f)
        |> ignore

    [<JavaScript>]
    member this.OnChangeMonthYear(f: int -> int -> Datepicker -> unit) : unit =
        this
        |> OnAfterRender(fun _ -> this.onChangeMonthYear f)
        |> ignore

    [<JavaScript>]
    member this.OnClose(f: Date -> Datepicker -> unit) : unit =
        this
        |> OnAfterRender(fun _ ->
            this.onClose <| fun _ d ->
                f (DatepickerInternal.getDate this.element.Dom) d
        )
        |> ignore

    // Adding an event and delayin it if the Pagelet is not yet rendered.
    /// Triggered when a date is selected.
    /// Changelog: these events are supposed to append behavior to the
    ///   existing config set (see the use of 'option' at each handler),
    ///   instead of overwriting them. To do so, they must be called after
    ///   the Pagelet has been rendered.
    [<JavaScript>]
    member this.OnSelect(f: Date -> Datepicker -> unit) : unit =
        this
        |> OnAfterRender(fun _ ->
            this.onSelect <| fun _ d ->
                f (DatepickerInternal.getDate this.element.Dom) d
        )
        |> ignore


