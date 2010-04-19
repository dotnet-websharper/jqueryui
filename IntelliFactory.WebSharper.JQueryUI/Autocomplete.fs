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
type AutocompleteConfiguration[<JavaScript>]() = 

    [<DefaultValue>]
    [<Name "delay">]
    val mutable Delay: int

    [<DefaultValue>]
    [<Name "minLength">]
    val mutable MinLength: int

    [<DefaultValue>]
    [<Name "source">]
    val mutable Source: array<string>


[<JavaScriptType>]
module internal AutocompleteInternal =
    [<Inline "jQuery($el).autocomplete($conf)">]
    let New (el: Dom.Element, conf: AutocompleteConfiguration) = ()    

[<JavaScriptType>]
type Autocomplete[<JavaScript>]() = 
  
    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : AutocompleteConfiguration

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
        el 
        |> OnAfterRender (fun _  -> 
            (a :> IWidget).Render()
        )
        a.element <- el
        a

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
            AutocompleteInternal.New(this.Element.Dom, this.configuration)

        [<JavaScript>]                                       
        member this.Body
            with get () = this.Element.Dom


    (****************************************************************
    * Methods
    *****************************************************************) 
    [<Inline "jQuery($this.element.el).autocomplete('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element.el).autocomplete('disable')">]
    member this.Disable () = ()

    [<Inline "jQuery($this.element.el).autocomplete('enable')">]
    member this.Enable () = ()

    [<Inline "jQuery($this.element.el).autocomplete('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    [<Inline "jQuery($this.element.el).autocomplete('search')">]
    member this.Search () = ()

    [<Inline "jQuery($this.element.el).autocomplete('search', $value)">]
    member this.Search (value: string) = ()

    [<Inline "jQuery($this.element.el).autocomplete('close')">]
    member this.Close () = ()

    (****************************************************************
    * Events
    *****************************************************************) 
    [<Inline "jQuery($this.element.el).autocomplete({search: function (x,y) {($f(x))(y.search);}})">]
    member private this.onSearch(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).autocomplete({focus: function (x,y) {($f(x))(y.focus);}})">]
    member private this.onFocus(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).autocomplete({select: function (x,y) {($f(x))(y.select);}})">]
    member private this.onSelect(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).autocomplete({close: function (x,y) {($f(x))(y.close);}})">]
    member private this.onClose(f : JQueryEvent -> Element -> unit) = ()

    [<Inline "jQuery($this.element.el).autocomplete({change: function (x,y) {($f(x))(y.change);}})">]
    member private this.onChange(f : JQueryEvent -> Element -> unit) = ()


    // Adding an event and delayin it if the widget is not yet rendered.
    [<JavaScript>]
    member this.OnSearch f =
        this |> OnAfterRender (fun _ -> this.onSearch f)

    /// After an item was selected. Always triggered after the close event.
    [<JavaScript>]
    member this.OnChange f =
        this |> OnAfterRender (fun _ -> this.onChange f)

    // Adding an event and delayin it if the widget is not yet rendered.
    [<JavaScript>]
    member this.OnClose f =
        this |> OnAfterRender (fun _ -> this.onClose f)

    // Adding an event and delayin it if the widget is not yet rendered.
    [<JavaScript>]
    member this.OnFocus f =
        this |> OnAfterRender (fun _ -> this.onFocus f)