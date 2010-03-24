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
type ButtonIconsConfiguration = 
    {
        [<Name "primary">]
        Primary: string
        
        [<Name "Secondary">]
        Secondary: string      
    }
    [<JavaScript>]
    static member Default = {Primary = "ui-icon-gear"; Secondary = "ui-icon-triangle-1-s" }

[<JavaScriptType>]
type ButtonConfiguration = 
    
    [<DefaultValue>]
    [<Name "text">]
    //true by default
    val mutable Text: bool

    [<DefaultValue>]
    [<Name "label">]
    //true by default
    val mutable Label: string

    [<DefaultValue>]
    [<Name "icons">]
    val mutable Icons: ButtonIconsConfiguration

    [<JavaScriptConstructor>]
    new () = {}

[<JavaScriptType>]
module internal ButtonInternal =
    [<Inline "jQuery($el).button($conf)">]
    let New (el: Element, conf: ButtonConfiguration) = ()    


[<JavaScriptType>]
type Button = 

    [<JavaScriptConstructor>]
    new () = {}
  
    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : ButtonConfiguration

    [<DefaultValue>]
    val mutable private renderEvent: Event<Utils.RenderEvent>

    [<DefaultValue>]
    val mutable private isRendered: bool

    [<DefaultValue>]
    val mutable private isEnabled: bool

    [<JavaScript>]
    member this.Element
        with get () =
            this.element

    [<JavaScript>]
    member this.IsEnabled
        with get () =
            this.isEnabled
    
    (****************************************************************
    * Constructors
    *****************************************************************)     
    [<JavaScript>]
    [<Name "New3">]
    static member New (el : Element, conf: ButtonConfiguration): Button = 
        let b = new Button()
        b.configuration <- conf
        b.isEnabled <- true
        b.renderEvent <- new Event<RenderEvent>()
        el 
        |> On Events.Attach (fun _ _ -> b.Render())
        |> ignore
        b.element <- el
        b

    [<JavaScript>]
    [<Name "New11">]
    static member New (conf: ButtonConfiguration): Button = 
        Button.New(Tags.Button [], conf)

    [<JavaScript>]
    [<Name "New12">]
    static member New (label: string): Button = 
        let conf = new ButtonConfiguration()
        conf.Label <- label
        Button.New(conf)
        
    
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
            ButtonInternal.New(this.Element, this.configuration)
            this.renderEvent.Trigger Utils.RenderEvent.After
            this.isRendered <- true
    
    [<JavaScript>]
    member this.IsRendered
        with get () : bool = this.isRendered

    (****************************************************************
    * Methods
    *****************************************************************)
    [<Inline "jQuery($this.element).button('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element).button('disable')">]
    member private this.disable () = ()

    [<JavaScript>]
    member this.Disable() =
        this.isEnabled <- false
        this.disable()

    [<Inline "jQuery($this.element).button('enable')">]
    member private this.enable () = ()

    [<JavaScript>]
    member this.Enable() =
        this.isEnabled <- true
        this.enable()

    [<Inline "jQuery($this.element).button('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    [<Inline "jQuery($this.element).button('refresh')">]
    member this.Refresh (index: int) = ()

    (****************************************************************
    * Events
    *****************************************************************)
    [<JavaScript>]
    member this.OnClick (f : unit -> unit) : unit =
        this.element
        |> On Events.Click (fun _ ev ->
            ev.PreventDefault()
            if this.isEnabled then
                f ()
        )
        |> ignore



