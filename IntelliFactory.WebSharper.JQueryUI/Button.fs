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
type ButtonConfiguration[<JavaScript>]() = 
    
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

[<JavaScriptType>]
module internal ButtonInternal =
    [<Inline "jQuery($el).button($conf)">]
    let New (el: Dom.Element, conf: ButtonConfiguration) = ()

[<JavaScriptType>]
type Button [<JavaScript>]()= 
  
    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : ButtonConfiguration

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
    static member New (el : Element, conf: ButtonConfiguration): Button = 

        el
        |>! OnClick (fun _ ev ->
            ev.PreventDefault()
        )
        |> ignore
        
        let b = new Button()
        b.configuration <- conf
        b.isEnabled <- true
        el 
        |>! OnAfterRender (fun _  -> 
            (b :> IWidget).Render()
        )
        |> ignore
        b.element <- el
        b

    [<JavaScript>]
    static member New (conf: ButtonConfiguration): Button = 
        Button.New(Tag.Button [], conf)

    [<JavaScript>]
    [<Name "New12">]
    static member New (label: string): Button = 
        let conf = new ButtonConfiguration()
        conf.Label <- label
        Button.New(conf)
        
    
    (****************************************************************
    * INode
    *****************************************************************)              
    interface INode with
        [<JavaScript>]                                       
        member this.Body
            with get () = 
                (this :> IWidget).Render()
                (this.Element.Dom :> Dom.Node)
                
    (****************************************************************
    * IWidget
    *****************************************************************)                  
    interface IWidget with
        [<JavaScript>]
        member this.OnBeforeRender(f: unit -> unit) : unit=
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
            ButtonInternal.New(this.Element.Dom, this.configuration)

        [<JavaScript>]                                       
        member this.Body
            with get () = this.Element.Dom

    (****************************************************************
    * Methods
    *****************************************************************)
    [<Inline "jQuery($this.element.el).button('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element.el).button('disable')">]
    member private this.disable () = ()

    [<JavaScript>]
    member this.Disable() =
        this.isEnabled <- false
        this.disable()

    [<Inline "jQuery($this.element.el).button('enable')">]
    member private this.enable () = ()

    [<JavaScript>]
    member this.Enable() =
        this.isEnabled <- true
        this.enable()

    [<Inline "jQuery($this.element.el).button('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    [<Inline "jQuery($this.element.el).button('refresh')">]
    member this.Refresh (index: int) = ()

    (****************************************************************
    * Events
    *****************************************************************)
    [<JavaScript>]
    member this.OnClick (f : JQueryEvent -> unit) : unit =
        this.element
        |>! OnClick (fun _ ev ->
            ev.PreventDefault()
            if this.isEnabled then
                f ev
        )
        |> ignore



