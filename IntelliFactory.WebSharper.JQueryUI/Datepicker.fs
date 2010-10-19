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
    [<Name "altField">]
    val mutable AltField: string
    
    [<DefaultValue>]
    [<Name "appendText">]
    //"" by default
    val mutable AppendText: string
    
    [<DefaultValue>]
    [<Name "altFormat">]
    //"" by default
    val mutable AltFormat: string

    [<DefaultValue>]
    [<Name "autoSize">]
    //false by default
    val mutable AutoSize: bool

    [<DefaultValue>]
    [<Name "buttonImage">]
    //"" by default
    val mutable ButtonImage: string
    
    [<DefaultValue>]
    [<Name "buttonImageOnly">]
    //false by default
    val mutable ButtonImageOnly: bool

    [<DefaultValue>]
    [<Name "buttonText">]
    //"..." by default
    val mutable ButtonText: string 

    [<DefaultValue>]
    [<Name "calculateWeek">]
    //"iso8601Week" by default
    val mutable CalculateWeek: EcmaScript.Date -> int

    [<DefaultValue>]
    [<Name "changeMonth">]
    //fasle by default
    val mutable ChangeMonth: bool 
                  
    [<DefaultValue>]
    [<Name "changeYear">]
    //fasle by default
    val mutable ChangeYear: bool 

    [<DefaultValue>]
    [<Name "closeText">]
    //"Done" by default
    val mutable CloseText: string
    
    [<DefaultValue>]
    [<Name "constrainInput">]
    //true by default
    val mutable ConstrainInput: bool 

    [<DefaultValue>]
    [<Name "currentText">]
    //"Today" by default
    val mutable CurrentText: string

    [<DefaultValue>]
    [<Name "dateFormat">]
    //"mm/dd/yy" by default
    val mutable DateFormat: string

    [<DefaultValue>]
    [<Name "dayNames">]
    //array<string> = [|"Sunday"; "Monday"; "Tuesday"; "Wednesday"; "Thursday"; "Friday"; "Saturday"|]
    val mutable DayNames: array<string> 

    [<DefaultValue>]
    [<Name "dayNamesMin">]
    // array<string> = [|"Su"; "Mo"; "Tu"; "We"; "Th"; "Fr"; "Sa"|]
    val mutable DayNamesMin: array<string> 

    [<DefaultValue>]
    [<Name "dayNamesShort">]
    // array<string> = [|"Sun"; "Mon"; "Tue"; "Wed"; "Thu"; "Fri"; "Sat"|]
    val mutable DayNamesShort: array<string> 

    [<DefaultValue>]
    [<Name "defaultDate">]
    // null by default
    val mutable DefaultDate: EcmaScript.Date

    [<DefaultValue>]
    [<Name "duration">]
    // "normal" by default
    val mutable Duration: string 

    [<DefaultValue>]
    [<Name "firstDay">]
    // 0 by default
    val mutable FirstDay: int 

    [<DefaultValue>]
    [<Name "gotoCurrent">]
    // fasle by default
    val mutable GotoCurrent: bool

    [<DefaultValue>]
    [<Name "hideIfNoPrevNext">]
    // fasle by default
    val mutable HideIfNoPrevNext: bool 

    [<DefaultValue>]
    [<Name "isRTL">]
    // false by default
    val mutable IsRTL: bool 

    [<DefaultValue>]
    [<Name "maxDate">]
    // null by default
    val mutable MaxDate: string

    [<DefaultValue>]
    [<Name "minDate">]
    // null by default
    val mutable MinDate: EcmaScript.Date

    [<DefaultValue>]
    [<Name "monthNames">]
    // by default [|"January"; "February"; "March"; "April"; "May"; "June"; "July"; "August"; "September"; "October"; "November"; "December"|]
    val mutable MonthNames: array<string> 

    [<DefaultValue>]
    [<Name "monthNamesShort">]
    // by default [|"Jan"; "Feb"; "Mar"; "Apr"; "May"; "Jun"; "Jul"; "Aug"; "Sep"; "Oct"; "Nov"; "Dec"|]
    val mutable MonthNamesShort: array<string>

    [<DefaultValue>]
    [<Name "navigationAsDateFormat">]
    // false by default
    val mutable NavigationAsDateFormat: bool 

    [<DefaultValue>]
    [<Name "nextText">]
    // "Next" by default
    val mutable NextText: string 

    [<DefaultValue>]
    [<Name "numberOfMonths">]
    //1 by default
    val mutable NumberOfMonths: array<int> 
    
    [<DefaultValue>]
    [<Name "prevText">]
    // "Prev" by default
    val mutable PrevText: string 
    
    [<DefaultValue>]
    [<Name "shortYearCutoff">]
    // "+10" by default
    val mutable ShortYearCutoff: int 
    
    [<DefaultValue>]
    [<Name "showAnim">]
    // "show" by default
    val mutable ShowAnim: string 

    [<DefaultValue>]
    [<Name "showButtonPanel">]
    // false by default
    val mutable ShowButtonPanel: bool 

    [<DefaultValue>]
    [<Name "showCurrentAtPos">]
    // 0 by default
    val mutable ShowCurrentAtPos: int 

    [<DefaultValue>]
    [<Name "showMonthAfterYear">]
    // fasle by default
    val mutable ShowMonthAfterYear: bool 
    
    [<DefaultValue>]
    [<Name "showOn">]
    // "focus" by default
    val mutable ShowOn: string
    
    [<DefaultValue>]
    [<Name "showOptions">]
    //{} by default
    val mutable ShowOptions: DatepickerShowOptionsConfiguration

    [<DefaultValue>]
    [<Name "showOtherMonths">]
    // false by default
    val mutable ShowOtherMonths: bool
    
    [<DefaultValue>]
    [<Name "showWeek">]
    //false by default
    val mutable ShowWeek: bool  

    [<DefaultValue>]
    [<Name "stepMonths">]
    // 1 by default
    val mutable StepMonths: int 

    [<DefaultValue>]
    [<Name "weekHeader">]
    // 1 by default
    val mutable WeekHeader: string

    [<DefaultValue>]
    [<Name "yearRange">]
    // "-10:+10" by default  
    val mutable YearRange: string
    
    [<DefaultValue>]
    [<Name "yearSuffix">]
    // 1 by default
    val mutable YearSuffix: string             

module internal DatepickerInternal =
    [<Inline "jQuery($el).datepicker($conf)">]
    let Init (el: Dom.Element, conf: DatepickerConfiguration) = ()

[<Resources.JQueryUIAllJS>]
[<Resources.JQueryUIAllCss>]
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
            DatepickerInternal.Init(el.Body, conf)
        )        
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

    /// Returns true or false wether the datepicker is disabled.
    [<Inline "jQuery($this.element.Body).datepicker('isDisabled')">]
    member this.IsDisabled () : bool = Unchecked.defaultof<_>()
    
    /// Hides the datepicker.
    [<Inline "jQuery($this.element.Body).datepicker('hide')">]
    member this.Hide () = ()

    /// Shows the datepicker.
    [<Inline "jQuery($this.element.Body).datepicker('show')">]
    member this.Show () = ()

    /// Get the currently selected date of the datepicker.
    [<Inline "jQuery($this.element.Body).datepicker('getDate')">]
    member this.GetDate () : EcmaScript.Date = Unchecked.defaultof<_>()

    /// Sets the selected date.
    [<Inline "jQuery($this.element.Body).datepicker('setDate', $date)">]
    member this.SetDate (date:string) = ()


    (****************************************************************
    * Events
    *****************************************************************) 
    [<Inline "jQuery($this.element.Body).datepicker({onSelect: function (x,y) {$f(x);}})">]
    member private this.onSelect(f : string -> unit) = ()

    [<Inline "jQuery($this.element.Body).datepicker({onClose: function (x,y) {$f();}})">]
    member private this.onClose(f : unit -> unit) = ()

    // beforeShow
    // beforeShowDay function(date)
    // onChangeMonthYear function(year, month, inst)
    // onClose function(dateText, inst)
    // Adding an event and delayin it if the Pagelet is not yet rendered.
    /// Triggered when a date is selected.
    [<JavaScript>]
    member this.OnSelect(f : EcmaScript.Date -> unit) : unit =
        this 
        |> OnBeforeRender(fun _ -> 
            this.onSelect <| fun s ->
                // TODO: verify
                f <| EcmaScript.Date(s)
        )
        |> ignore

    /// Triggered when the datepicker is closed.
    [<JavaScript>]
    member this.OnClose(f : unit -> unit) : unit  =
        this
        |> OnBeforeRender (fun _ ->             
            this.onClose f
        )
        |> ignore
     

