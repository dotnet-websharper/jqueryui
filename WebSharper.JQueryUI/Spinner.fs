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
namespace WebSharper.JQueryUI

open WebSharper
open WebSharper.JavaScript
open WebSharper.Html.Client

type SpinnerIcons =
    {
        [<Name "down">]
        Down : string

        [<Name "up">]
        Up : string
    }

type SpinnerConfiguration[<JavaScript>] () =

    [<Name "culture">]
    [<Stub>]
    //null by default
    member val Culture = Unchecked.defaultof<string> with get, set

    [<Name "disabled">]
    [<Stub>]
    member val Disabled = Unchecked.defaultof<bool> with get, set

    [<Name "icons">]
    [<Stub>]
    member val Icons = Unchecked.defaultof<SpinnerIcons> with get, set

    [<Name "incremental">]
    [<Stub>]
    member val Incremental = Unchecked.defaultof<bool> with get, set

    [<Name "max">]
    [<Stub>]
    //100 by default
    member val Max = Unchecked.defaultof<int> with get, set

    [<Name "min">]
    [<Stub>]
    //0 by default
    member val Min = Unchecked.defaultof<int> with get, set

    [<Name "numberFormat">]
    [<Stub>]
    //null by default
    member val NumberFormat = Unchecked.defaultof<string> with get, set

    [<Name "page">]
    [<Stub>]
    //1 by default
    member val Page = Unchecked.defaultof<int> with get, set

    [<Name "step">]
    [<Stub>]
    //1 by default
    member val Step = Unchecked.defaultof<int> with get, set

module internal SpinnerInternal =
    [<Inline "jQuery($el).spinner($conf)">]
    let Init(el: Dom.Element, conf: SpinnerConfiguration) = ()


[<Require(typeof<Dependencies.JQueryUIJs>)>]
[<Require(typeof<Dependencies.JQueryUICss>)>]
type Spinner[<JavaScript>] internal () =
    inherit Utils.Pagelet()

    (****************************************************************
    * Constructors
    *****************************************************************)
    /// Creates a new spinner given a configuration object.
    [<JavaScript>]
    [<Name "New1">]
    static member New (conf: SpinnerConfiguration): Spinner =
        let s = new Spinner()
        s.element <-
            Div []
            |>! OnAfterRender (fun el  ->
                SpinnerInternal.Init(el.Dom, conf)
            )
        s

    /// Creates a new spinner using the default configuration
    /// settings.
    [<JavaScript>]
    [<Name "New2">]
    static member New (): Spinner =
        Spinner.New (new SpinnerConfiguration())

    (****************************************************************
    * Methods
    *****************************************************************)
    /// Removes the spinner functionality completly.
    [<Inline "jQuery($this.element.Dom).spinner('destroy')">]
    member this.Destroy() = ()

    /// Disables the spinner functionality.
    [<Inline "jQuery($this.element.Dom).spinner('disable')">]
    member this.Disable () = ()

    /// Enables the spinner functionality.
    [<Inline "jQuery($this.element.Dom).spinner('enable')">]
    member this.Enable () = ()

    /// Sets a spinner option.
    [<Inline "jQuery($this.element.Dom).spinner('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Gets a spinner option.
    [<Inline "jQuery($this.element.Dom).spinner('option', $name)">]
    member this.Option (name: string) = X<obj>

    [<Inline "jQuery($this.element.Dom).spinner('widget')">]
    member private this.getWidget () = X<Dom.Element>

    /// Returns the .ui-spinner element.
    [<JavaScript>]
    member this.Widget = this.getWidget()

    /// Decrements the value by the specified number of pages, as defined by the page option.
    [<Inline "jQuery($this.element.Dom).spinner('pageDown')">]
    member this.PageDown () = ()

    /// Decrements the value by the specified number of pages, as defined by the page option.
    [<Inline "jQuery($this.element.Dom).spinner('pageDown', $pages)">]
    member this.PageDown (pages: int) = ()

    /// Increments the value by the specified number of pages, as defined by the page option.
    [<Inline "jQuery($this.element.Dom).spinner('pageUp')">]
    member this.PageUp () = ()

    /// Increments the value by the specified number of pages, as defined by the page option.
    [<Inline "jQuery($this.element.Dom).spinner('pageUp', $pages)">]
    member this.PageUp (pages: int) = ()

    /// Decrements the value by the specified number of steps.
    [<Inline "jQuery($this.element.Dom).spinner('stepDown')">]
    member this.StepDown () = ()

    /// Decrements the value by the specified number of steps.
    [<Inline "jQuery($this.element.Dom).spinner('stepDown', $steps)">]
    member this.StepDown (steps: int) = ()

    /// Increments the value by the specified number of steps.
    [<Inline "jQuery($this.element.Dom).spinner('stepUp')">]
    member this.StepUp () = ()

    /// Increments the value by the specified number of steps.
    [<Inline "jQuery($this.element.Dom).spinner('stepUp', $steps)">]
    member this.StepUp (steps: int) = ()

    [<Inline "jQuery($this.element.Dom).spinner('value', $v)">]
    member private this.setValue (v: int) = ()

    [<Inline "jQuery($this.element.Dom).spinner('value')">]
    member private this.getValue () = 0

    /// Gets or sets the spinner value.
    [<JavaScript>]
    member this.Value
        with get () =
            this.getValue()
        and set (v: int) =
            this.setValue v

    (****************************************************************
    * Events
    *****************************************************************)

    [<Inline "jQuery($this.element.Dom).bind('spinnercreate', function (x,y) {$f(x);})">]
    member private this.onCreate(f : JQuery.Event -> unit) = ()


    [<Inline "jQuery($this.element.Dom).bind('spinnerstart', function (x,y) {$f(x);})">]
    member private this.onStart(f : JQuery.Event -> unit) = ()


    [<Inline "jQuery($this.element.Dom).bind('spinnerchange', function (x,y) {$f(x);})">]
    member private this.onChange(f : JQuery.Event -> unit) = ()


    [<Inline "jQuery($this.element.Dom).bind('spinnerspin', function (x,y) {($f(x))($y.value);})">]
    member private this.onSpin(f : JQuery.Event -> int -> unit) = ()


    [<Inline "jQuery($this.element.Dom).bind('spinnerstop', function (x,y) {$f(x);})">]
    member private this.onStop(f : JQuery.Event -> unit) = ()


    /// Event triggered when the user starts sliding.
    [<JavaScript>]
    member this.OnStart(f : JQuery.Event -> unit) =
        this |> OnAfterRender (fun _ -> this.onStart f)

    /// Event triggered when the spinner changes.
    [<JavaScript>]
    member this.OnChange(f : JQuery.Event -> unit) =
        this |> OnAfterRender (fun _ -> this.onChange f)

    /// Event triggered during increment/decrement (to determine direction of spin compare current value with received value).
    [<JavaScript>]
    member this.OnSpin(f : JQuery.Event -> int -> unit) =
        this |> OnAfterRender (fun _ -> this.onSpin f)

    /// Event triggered when the user stops spinning.
    [<JavaScript>]
    member this.OnStop(f : JQuery.Event -> unit) =
        this |> OnAfterRender (fun _ -> this.onStop f)








