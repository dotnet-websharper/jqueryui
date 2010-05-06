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

[<Stub>]
[<JavaScriptType>]
type AccordionIconConfiguration =
    {   
        [<Name "header">]
        Header: string

        [<Name "headerSelected">]
        HeaderSelected: string
    }
    [<JavaScript>]
    static member Default =
        { Header="ui-icon-triangle-1-e"; HeaderSelected="ui-icon-triangle-1-s" }

[<Stub>]
[<JavaScriptType>]
type AccordionConfiguration[<JavaScript>]() = 
    
    [<DefaultValue>]
    [<Name "active">]
    val mutable Active: int

    [<DefaultValue>]
    [<Name "animated">]
    val mutable Animated: string

    [<DefaultValue>]
    [<Name "autoHeight">]
    val mutable AutoHeight: bool

    [<DefaultValue>]
    [<Name "clearStyle">]
    val mutable ClearStyle: bool

    [<DefaultValue>]
    [<Name "collapsible">]
    val mutable Collapsible: bool

    [<DefaultValue>]
    [<Name "event">]
    val mutable Event: string

    [<DefaultValue>]
    [<Name "fillSpace">]
    val mutable FillSpace: bool

    [<DefaultValue>]
    [<Name "header">]
    val mutable Header: string

    [<DefaultValue>]
    [<Name "icons">]
    val mutable Icons: AccordionIconConfiguration

    [<DefaultValue>]
    [<Name "navigation">]
    val mutable Navigation: bool
    
    [<DefaultValue>]
    [<Name "navigationFilter">]
    val mutable NavigationFilter: unit -> unit
    

[<JavaScriptType>]    
module internal AccordianInternal =
    [<Inline "jQuery($el).accordion($conf)">]
    let internal Init (el: Dom.Element, conf: AccordionConfiguration) = ()

[<JavaScriptType>]
type Accordion[<JavaScript>] internal () =
    inherit Widget()
    
    (****************************************************************
    * Constructors
    *****************************************************************)        
    [<JavaScript>]
    static member New (els : List<string * Element>, conf: AccordionConfiguration): Accordion = 
        let a = new Accordion()
        let panel =
            els
            |> List.map (fun (header, el) ->
                [
                    H3 [A [HRef "#"] -< [Text header]]
                    Div [el]
                ]
            )
            |> List.concat
            |> Div
            |>! OnAfterRender (fun el ->
                AccordianInternal.Init(el.Dom, conf)
                (a :> IWidget).Render()
            )
        a.element <- panel
        a            
    
    [<JavaScript>]
    static member New (els : List<string * Element>): Accordion =
        Accordion.New(els, new AccordionConfiguration())        

    (****************************************************************
    * Methods
    *****************************************************************) 
    [<Inline "jQuery($this.element.el).accordion('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element.el).accordion('disable')">]
    member this.Disable () = ()

    [<Inline "jQuery($this.element.el).accordion('enable')">]
    member this.Enable () = ()

    [<Inline "jQuery($this.element.el).accordion('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    [<Inline "jQuery($this.element.el).accordion('activate', $index)">]
    member this.Activate (index: int) = ()

    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element.el).accordion({change: function (x,y) {($f(x))(y.change);}})">]
    member private this.onChange(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).accordion({change: function (x,y) {($f(x))(y.changestart);}})">]
    member private this.onChangestart(f : JQueryEvent -> Element -> unit) = ()

    // Adding an event and delaying it if the widget is not yet rendered.
    [<JavaScript>]
    member this.OnChange f =      
        this
        |> OnAfterRender (fun _ ->
            this.onChange f
        )

    [<JavaScript>]
    member this.OnChangestart f =
        this
        |> OnAfterRender (fun _ ->
            this.onChangestart f
        )
