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

[<JavaScriptType>]
//[<Require(typeof<Dependencies.Carousel>)>]
module Datepicker =
    
    [<JavaScriptType>]
    type DatepickerShowOptionsConfiguration = 
        {
            [<Name "showOptions">]    
            Direction: string
        }

        [<JavaScript>]
        static member Default = {Direction = "up"}
        
    [<JavaScriptType>]
    type DatepickerConfiguration = 
        
        [<DefaultValue>]
        [<Name "altField">]
        //"" by default
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
        val mutable CalculateWeek: JavaScript.Date -> int

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
        val mutable DefaultDate: JavaScript.Date

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
        val mutable MinDate: JavaScript.Date

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
             
//        //beforeShow Event
//        [<DefaultValue>]
//        [<Name "beforeShow">]
//        val mutable BeforeShow: JavaScript.Date -> string
//
//        //beforeShow Event
//        [<DefaultValue>]
//        [<Name "beforeShowDay">]
//        val mutable BeforeShowDay: JavaScript.Date -> string
        
        [<JavaScriptConstructor>]
        new () = {}

    [<JavaScriptType>]
    type Datepicker =

        [<Inline "jQuery($id).datepicker()">]
        static member NewPrivate (id: string) = ()

        [<Inline "jQuery($el).datepicker()">]
        static member New (el: Element) : Datepicker = Unchecked.defaultof<_>

        [<Inline "jQuery($el).datepicker($conf)">]
        static member New (el: Element, conf: DatepickerConfiguration): Datepicker = Unchecked.defaultof<_>

        [<Inline "jQuery($el).datepicker()">]
        static member Show (el: Element) = ()

        [<JavaScript>]
        static member Attach (el: Element) =
            el
            |> On Events.Attach (fun _ _ -> 
                Datepicker.New (el)
                |> ignore
            )

        [<JavaScript>]
        static member AttachWithConfiguration (conf: DatepickerConfiguration) (el: Element) =
            el
            |> On Events.Attach (fun _ _ -> 
                Datepicker.New (el, conf)
                |> ignore
            )
