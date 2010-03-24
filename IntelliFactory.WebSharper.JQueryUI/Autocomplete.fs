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
type AutocompleteConfiguration = 

    [<DefaultValue>]
    [<Name "delay">]
    val mutable Delay: int

    [<DefaultValue>]
    [<Name "minLength">]
    val mutable MinLength: int

    [<DefaultValue>]
    [<Name "source">]
    val mutable Source: array<string>

    [<JavaScriptConstructor>]
    new () = {}

[<JavaScriptType>]
module internal AutocompleteInternal =
    [<Inline "jQuery($el).autocomplete($conf)">]
    let New (el: Element, conf: AutocompleteConfiguration) = ()    

[<JavaScriptType>]
type Autocomplete = 
    [<JavaScriptConstructor>]
    new () = {}
  
    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : AutocompleteConfiguration

    [<DefaultValue>]
    val mutable private renderEvent: Event<Utils.RenderEvent>

    [<DefaultValue>]
    val mutable private isRendered: bool

    [<JavaScript>]
    member this.Element
        with get () =
            this.element

    (****************************************************************
    * Constructors
    *****************************************************************) 
    [<JavaScript>]
    static member New (el : Element, conf: AutocompleteConfiguration): Autocomplete = 
        let a = new Autocomplete()
        a.configuration <- conf
        a.renderEvent <- new Event<RenderEvent>()
        el 
        |> On Events.Attach (fun _ _ -> a.Render())
        |> ignore
        a.element <- el
        a

    (****************************************************************
    * Render interface
    *****************************************************************)          
    [<JavaScript>]
    member this.OnBeforeRender(f: unit -> unit) : unit=
        this.renderEvent.Publish
        |> Event.Iterate (fun re ->
            match re with
            | Utils.RenderEvent.Before  -> f ()
            | _                         -> ()
        )
                    
    [<JavaScript>]
    member this.OnAfterRender(f: unit -> unit) : unit=
        this.renderEvent.Publish
        |> Event.Iterate (fun re ->
            match re with
            | Utils.RenderEvent.After  -> f ()
            | _                         -> ()
        )

    [<JavaScript>]
    member this.Render() =     
        if not this.IsRendered  then
            this.renderEvent.Trigger Utils.RenderEvent.Before
            AutocompleteInternal.New(this.Element, this.configuration)
            this.renderEvent.Trigger Utils.RenderEvent.After
            this.isRendered <- true
    
    [<JavaScript>]
    member this.IsRendered
        with get () : bool = this.isRendered


    (****************************************************************
    * Methods
    *****************************************************************) 
    [<Inline "jQuery($this.element).autocomplete('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element).autocomplete('disable')">]
    member this.Disable () = ()

    [<Inline "jQuery($this.element).autocomplete('enable')">]
    member this.Enable () = ()

    [<Inline "jQuery($this.element).autocomplete('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    [<Inline "jQuery($this.element).autocomplete('search')">]
    member this.Search () = ()

    [<Inline "jQuery($this.element).autocomplete('search', $value)">]
    member this.Search (value: string) = ()

    [<Inline "jQuery($this.element).autocomplete('close')">]
    member this.Close () = ()

    (****************************************************************
    * Events
    *****************************************************************) 
    [<Inline "jQuery($this.element).autocomplete({search: function (x,y) {$f();}})">]
    member private this.onSearch(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).autocomplete({focus: function (x,y) {$f();}})">]
    member private this.onFocus(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).autocomplete({select: function (x,y) {$f();}})">]
    member private this.onSelect(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).autocomplete({close: function (x,y) {$f();}})">]
    member private this.onClose(f : unit -> unit) = ()

    [<Inline "jQuery($this.element).autocomplete({change: function (x,y) {$f();}})">]
    member private this.onChange(f : unit -> unit) = ()

    // Adding an event and delayin it if the widget is not yet rendered.
    [<JavaScript>]
    member private this.On (f : unit -> unit) =
        if this.IsRendered then f ()
        else            
            this.OnAfterRender(fun () -> f ())

    // Adding an event and delayin it if the widget is not yet rendered.
    [<JavaScript>]
    member this.OnSearch(f : unit -> unit) =
        this.On (fun () -> this.onSearch f)

    /// After an item was selected. Always triggered after the close event.
    [<JavaScript>]
    member this.OnChange(f : unit -> unit) =
        this.On (fun () -> this.onChange f)

    // Adding an event and delayin it if the widget is not yet rendered.
    [<JavaScript>]
    member this.OnClose(f : unit -> unit) =
        this.On (fun () -> this.onClose f)

    // Adding an event and delayin it if the widget is not yet rendered.
    [<JavaScript>]
    member this.OnFocus(f : unit -> unit) =
        this.On (fun () -> this.onFocus f)