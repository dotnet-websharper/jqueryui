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

type TooltipConfiguration[<JavaScript>] () =

    [<Name "content">]
    [<Stub>]
    //null by default
    member val Content = Unchecked.defaultof<string> with get, set

    [<Name "content">]
    [<Stub>]
    //null by default
    member val ContentFunction = Unchecked.defaultof<(string -> unit) -> unit> with get, set

    [<Name "disabled">]
    [<Stub>]
    member val Disabled = Unchecked.defaultof<bool> with get, set

    [<Name "hide">]
    [<Stub>]
    //null by default
    member val Hide = Unchecked.defaultof<string> with get, set

    [<Name "items">]
    [<Stub>]
    member val Items = Unchecked.defaultof<string> with get, set

    [<Name "position">]
    [<Stub>]
    //"center" by default
    member val Position = Unchecked.defaultof<PositionConfiguration> with get, set

    [<Name "show">]
    [<Stub>]
    //null by default
    member val Show = Unchecked.defaultof<string> with get, set

    [<Name "tooltipClass">]
    [<Stub>]
    //null by default
    member val TooltipClass = Unchecked.defaultof<string> with get, set

    [<Name "track">]
    [<Stub>]
    member val Track = Unchecked.defaultof<bool> with get, set

module internal TooltipInternal =
    [<Inline "jQuery($el).tooltip($conf)">]
    let Init(el: Dom.Element, conf: TooltipConfiguration) = ()


[<Require(typeof<Dependencies.JQueryUIJs>)>]
[<Require(typeof<Dependencies.JQueryUICss>)>]
type Tooltip[<JavaScript>] internal () =
    inherit Utils.Pagelet()

    (****************************************************************
    * Constructors
    *****************************************************************)
    /// Creates a new tooltip given a configuration object.
    [<JavaScript>]
    [<Name "New1">]
    static member New (conf: TooltipConfiguration): Tooltip =
        let s = new Tooltip()
        s.element <-
            Div []
            |>! OnAfterRender (fun el  ->
                TooltipInternal.Init(el.Dom, conf)
            )
        s

    /// Creates a new tooltip using the default configuration
    /// settings.
    [<JavaScript>]
    [<Name "New2">]
    static member New (): Tooltip =
        Tooltip.New (new TooltipConfiguration())

    (****************************************************************
    * Methods
    *****************************************************************)
    /// Removes the tooltip functionality completly.
    [<Inline "jQuery($this.element.Dom).tooltip('destroy')">]
    member this.Destroy() = ()

    /// Disables the tooltip functionality.
    [<Inline "jQuery($this.element.Dom).tooltip('disable')">]
    member this.Disable () = ()

    /// Enables the tooltip functionality.
    [<Inline "jQuery($this.element.Dom).tooltip('enable')">]
    member this.Enable () = ()

    /// Sets a tooltip option.
    [<Inline "jQuery($this.element.Dom).tooltip('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Gets a tooltip option.
    [<Inline "jQuery($this.element.Dom).tooltip('option', $name)">]
    member this.Option (name: string) = X<obj>

    [<Inline "jQuery($this.element.Dom).tooltip('widget')">]
    member private this.getWidget () = X<Dom.Element>

    /// Returns the .ui-tooltip element.
    [<JavaScript>]
    member this.Widget = this.getWidget()

    /// Closes the tooltip.
    [<Inline "jQuery($this.element.Dom).tooltip('close')">]
    member this.Close () = ()

    /// Opens the tooltip.
    [<Inline "jQuery($this.element.Dom).tooltip('open')">]
    member this.Open () = ()

    (****************************************************************
    * Events
    *****************************************************************)

    [<Inline "jQuery($this.element.Dom).bind('tooltipcreate', function (x,y) {$f(x);})">]
    member private this.onCreate(f : JQuery.Event -> unit) = ()


    [<Inline "jQuery($this.element.Dom).bind('tooltipclose', function (x,y) {$f(x);})">]
    member private this.onClose(f : JQuery.Event -> unit) = ()


    [<Inline "jQuery($this.element.Dom).bind('tooltipopen', function (x,y) {$f(x);})">]
    member private this.onOpen(f : JQuery.Event -> unit) = ()



    /// Event triggered when the tooltip is closed, triggered on focusout or mouseleave.
    [<JavaScript>]
    member this.OnClose(f : JQuery.Event -> unit) =
        this |> OnAfterRender (fun _ -> this.onClose f)

    /// Event triggered when the tooltip is opened.
    [<JavaScript>]
    member this.OnOpen(f : JQuery.Event -> unit) =
        this |> OnAfterRender (fun _ -> this.onOpen f)








