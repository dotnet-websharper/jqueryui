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
type DatepickerShowOptionsConfiguration = 
    {
        [<Name "showOptions">]    
        Direction: string
    }

    [<JavaScript>]
    static member Default = {Direction = "up"}
    
[<JavaScriptType>]
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
    val mutable CalculateWeek:   JDate -> int

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
    val mutable DefaultDate: JDate

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
    val mutable MinDate: JDate

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
//        val mutable BeforeShow: JDate -> string
//
//        //beforeShow Event
//        [<DefaultValue>]
//        [<Name "beforeShowDay">]
//        val mutable BeforeShowDay: JDate -> string
    

[<JavaScriptType>]
module internal DatepickerInternal =
    [<Inline "jQuery($el).datepicker($conf)">]
    let New (el: Dom.Element, conf: DatepickerConfiguration) = ()

[<JavaScriptType>]
type Datepicker[<JavaScript>]() =

    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : DatepickerConfiguration

    [<JavaScript>]
    member this.Element
        with get () =
            this.element

    (****************************************************************
    * Constructors
    *****************************************************************)
    [<JavaScript>]
    static member New (el: Element, conf: DatepickerConfiguration): Datepicker =
        let dp = new Datepicker()
        dp.configuration <- conf
        dp.element <- el
        el
        |> OnAfterRender (fun _  -> 
            JConsole.Log("here")                
            (dp :> IWidget).Render()
        )        
        dp

    [<JavaScript>]
    static member New (el:Element): Datepicker = 
        Datepicker.New(el, new DatepickerConfiguration())

    [<JavaScript>]
    static member New (): Datepicker = 
        Datepicker.New(Div [], new DatepickerConfiguration())
                       
    (****************************************************************
    * INode
    *****************************************************************)              
    interface INode with
        [<JavaScript>]                                       
        member this.Body
            with get () = 
                (this :> IWidget).Render()
                this.Element.Dom :> Dom.Node                

    (****************************************************************
    * IWidget
    *****************************************************************)                  
    interface IWidget with
        [<JavaScript>]
        member this.OnBeforeRender(f: unit -> unit) : unit =
            this.Element
            |> OnBeforeRender (fun _ -> f ())
                        
        [<JavaScript>]
        member this.OnAfterRender(f: unit -> unit) : unit=
            this.Element
            |> OnAfterRender (fun _ -> 
                (this :> IWidget).Render()
                f ()
            )
        
        [<JavaScript>]
        member this.Render() =
            (this.Element :> IWidget).Render()
            DatepickerInternal.New(this.Element.Dom, this.configuration)

        [<JavaScript>]                                       
        member this.Body
            with get () =
                this.Element.Dom

    (****************************************************************
    * Methods
    *****************************************************************)
    [<Inline "jQuery($this.element.el).datepicker('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element.el).datepicker('disable')">]
    member this.Disable () = ()

    [<Inline "jQuery($this.element.el).datepicker('enable')">]
    member this.Enable () = ()

    [<Inline "jQuery($this.element.el).datepicker('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    [<Inline "jQuery($this.element.el).datepicker('isDisabled')">]
    member this.IsDisabled () : bool = Unchecked.defaultof<_>()
    
    [<Inline "jQuery($this.element.el).datepicker('hide')">]
    member this.Hide () = ()

    [<Inline "jQuery($this.element.el).datepicker('show')">]
    member this.Show () = ()

    [<Inline "jQuery($this.element.el).datepicker('getDate')">]
    member this.GetDate () : JDate = Unchecked.defaultof<_>()

    [<Inline "jQuery($this.element.el).datepicker('setDate', $date)">]
    member this.SetDate (date:string) = ()


    (****************************************************************
    * Events
    *****************************************************************) 
    [<Inline "jQuery($this.element.el).datepicker({onSelect: function (x,y) {$f(x);}})">]
    member private this.onSelect(f : string -> unit) = ()

    [<Inline "jQuery($this.element.el).datepicker({onClose: function (x,y) {$f();}})">]
    member private this.onClose(f : unit -> unit) = ()

    // beforeShow
    // beforeShowDay function(date)
    // onChangeMonthYear function(year, month, inst)
    // onClose function(dateText, inst)
    // onSelect function(dateText, inst)

    // Adding an event and delayin it if the widget is not yet rendered.

    // Adding an event and delayin it if the widget is not yet rendered.
    [<JavaScript>]
    member this.OnSelect(f : JDate -> unit) : unit =
        this 
        |> OnBeforeRender(fun _ -> 
            this.onSelect <| fun s -> f (JDate(s))
        )

    // Adding an event and delayin it if the widget is not yet rendered.
    [<JavaScript>]
    member this.OnClose(f : unit -> unit) : unit  =
        this
        |> OnBeforeRender (fun _ ->             
            this.onClose f
        )



//[<JavaScriptType>]
//type Datepicker[<JavaScript>]() =
//
//  
//    [<DefaultValue>]
//    val mutable private element : Element
//
//    [<DefaultValue>]
//    val mutable private configuration : DatepickerConfiguration
//
//    [<DefaultValue>]
//    val mutable private renderEvent: Event<Utils.RenderEvent>
//
//    [<DefaultValue>]
//    val mutable private isRendered: bool
//
//    [<JavaScript>]
//    member this.Element
//        with get () =
//            this.element
//    
//    (****************************************************************
//    * Constructors
//    *****************************************************************)
//    [<JavaScript>]
//    static member New (el: Element, conf: DatepickerConfiguration): Datepicker = 
//        let dp = new Datepicker()
//        dp.configuration <- conf
//        dp.renderEvent <- new Event<RenderEvent>()
//        let el =
//            el
//            |>! OnAfterRender (fun _  -> dp.Render())
//        dp.element <- el
//        dp
//
//    [<JavaScript>]
//    static member New (el:Element): Datepicker = 
//        Datepicker.New(el, new DatepickerConfiguration())
//
//    [<JavaScript>]
//    [<Name "New0">]
//    static member New (): Datepicker = 
//        Datepicker.New(Div [], new DatepickerConfiguration())
//
//
//    (****************************************************************
//    * INode
//    *****************************************************************)              
//    interface INode with
//        [<JavaScript>]                                       
//        member this.Body
//            with get () = (this.Element.Dom :> Dom.Node)
//                
//    (****************************************************************
//    * IWidget
//    *****************************************************************)                  
//    interface IWidget with
//        [<JavaScript>]
//        member this.OnBeforeRender(f: unit -> unit) : unit=
//            this.Element
//            |> OnBeforeRender (fun _ -> f ())
//                        
//        [<JavaScript>]
//        member this.OnAfterRender(f: unit -> unit) : unit=
//            this.Element
//            |> OnAfterRender (fun _ -> 
//                (this :> IWidget).Render()
//                f ()
//            )
//
//        [<JavaScript>]
//        member this.Render() =
//            (this.Element :> IWidget).Render()
//            DatepickerInternal.New(this.Element.Dom, this.configuration)
//
//        [<JavaScript>]                                       
//        member this.Body
//            with get () = this.Element.Dom
//
//    (****************************************************************
//    * Methods
//    *****************************************************************)
//    [<Inline "jQuery($this.element.el).datepicker('destroy')">]
//    member this.Destroy() = ()
//
//    [<Inline "jQuery($this.element.el).datepicker('disable')">]
//    member this.Disable () = ()
//
//    [<Inline "jQuery($this.element.el).datepicker('enable')">]
//    member this.Enable () = ()
//
//    [<Inline "jQuery($this.element.el).datepicker('option', $name, $value)">]
//    member this.Option (name: string, value: obj) = ()
//
//    [<Inline "jQuery($this.element.el).datepicker('isDisabled')">]
//    member this.IsDisabled () : bool = Unchecked.defaultof<_>()
//    
//    [<Inline "jQuery($this.element.el).datepicker('hide')">]
//    member this.Hide () = ()
//
//    [<Inline "jQuery($this.element.el).datepicker('show')">]
//    member this.Show () = ()
//
//    [<Inline "jQuery($this.element.el).datepicker('getDate')">]
//    member this.GetDate () : JDate = Unchecked.defaultof<_>()
//
//    [<Inline "jQuery($this.element.el).datepicker('setDate', $date)">]
//    member this.SetDate (date:string) = ()
//
//
//    (****************************************************************
//    * Events
//    *****************************************************************) 
//    [<Inline "jQuery($this.element.el).datepicker({onSelect: function (x,y) {$f(x);}})">]
//    member private this.onSelect(f : string -> unit) = ()
//
//    [<Inline "jQuery($this.element.el).datepicker({onClose: function (x,y) {$f();}})">]
//    member private this.onClose(f : unit -> unit) = ()
//
//    // beforeShow
//    // beforeShowDay function(date)
//    // onChangeMonthYear function(year, month, inst)
//    // onClose function(dateText, inst)
//    // onSelect function(dateText, inst)
//
//    // Adding an event and delayin it if the widget is not yet rendered.
//    [<JavaScript>]
//    member private this.OnBefore (f : unit -> unit) : unit =
//        if this.IsRendered then 
//            f ()
//        else            
//            this.OnBeforeRender(fun () -> f ())
//
//    [<JavaScript>]
//    member private this.OnAfter (f : unit -> unit) : unit =
//        if this.IsRendered then 
//            f ()
//        else            
//            this.OnAfterRender(fun () -> f ())
//
//    // Adding an event and delayin it if the widget is not yet rendered.
//    [<JavaScript>]
//    member this.OnSelect(f : JDate -> unit) : unit =
//        this.OnBefore(fun () -> 
//            this.onSelect <| fun s -> f (JDate(s))
//        )
//
//    // Adding an event and delayin it if the widget is not yet rendered.
//    [<JavaScript>]
//    member this.OnClose(f : unit -> unit) : unit  =
//        this.OnBefore(fun () ->             
//            this.onClose f
//        )

     

