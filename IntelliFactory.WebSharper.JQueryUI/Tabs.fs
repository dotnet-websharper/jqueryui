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
type TabsAjaxOptionsConfiguration = 
    {
    [<Name "ajaxOptions">]
    async: bool
    }

    [<JavaScript>]
    static member Default = {async = false}

[<JavaScriptType>]
type TabsCookieConfiguration = 
    {
    [<Name "cookie">]
    expires: int
    }

    [<JavaScript>]
    static member Default = {expires = 30}

[<JavaScriptType>]
type TabsFxConfiguration = 
    {
    [<Name "fx">]
    opacity: string
    }
    [<JavaScript>]
    static member Dafault = {opacity = "toggle"}

[<JavaScriptType>]
type TabsConfiguration[<JavaScript>]() = 
    
    [<DefaultValue>]
    [<Name "ajaxOptions">]
    //null by default
    val mutable AjaxOptions: TabsAjaxOptionsConfiguration

    [<DefaultValue>]
    [<Name "cache">]
    //false by default
    val mutable Cache: bool

    [<DefaultValue>]
    [<Name "collapsible">]
    //false by default
    val mutable Collapsible: bool

    [<DefaultValue>]
    [<Name "cookie">]
    //null by default
    val mutable Cookie: TabsCookieConfiguration

    [<DefaultValue>]
    [<Name "deselectable">]
    //false by default
    val mutable Deselectable: bool

    [<DefaultValue>]
    [<Name "disabled">]
    //[] by default
    val mutable Disabled: array<int>

    [<DefaultValue>]
    [<Name "event">]
    //"click" by default
    val mutable Event: string

    //Option, Array? 
    [<DefaultValue>]
    [<Name "fx">]
    //null by default
    val mutable Fx: TabsFxConfiguration

    [<DefaultValue>]
    [<Name "idPrefix">]
    //"ui-tabs-" by default
    val mutable IdPrefix: string

    [<DefaultValue>]
    [<Name "panelTemplate">]
    //"<div></div>" by default
    val mutable PanelTemplate: string

    [<DefaultValue>]
    [<Name "selected">]
    //0 by default
    val mutable Selected: int

    [<DefaultValue>]
    [<Name "spinner">]
    //"<em>Loading&#8230;</em>" by default
    val mutable Spinner: string

    [<DefaultValue>]
    [<Name "tabTemplate">]
    //"<li><a href="#{href}"><span>#{label}</span></a></li>" by default
    val mutable TabTemplate: string

    
[<JavaScriptType>]
module internal TabsInternal =
    [<Inline "jQuery($el).tabs($conf)">]
    let Init(el: Dom.Element, conf: TabsConfiguration) = ()    

[<JavaScriptType>]
type Tabs[<JavaScript>]() = 
    
    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : TabsConfiguration

    [<JavaScript>]
    member this.Element
        with get () =
            this.element

    (****************************************************************
    * Constructors
    *****************************************************************)        
    [<JavaScript>]
    [<Name "New2">]
    static member New (els : List<string * Element>, conf: TabsConfiguration): Tabs =        
        let el = 
            let itemPanels =
                els
                |> List.map (fun (label, panel) ->
                   let id = NewId()
                   let item = LI [A [HRef ("#" + id)] -< [Text label]] -< [panel]
                   let tab = Div [Id id] -< [P [panel]]
                   (item, tab)
                )
            let ul = itemPanels |> List.map fst |> UL
            Div <| ul :: (List.map snd itemPanels)
        
        let tabs = new Tabs ()
        tabs.configuration <- conf
        tabs.element <-
            el 
            |>! OnAfterRender (fun _  -> (tabs :> IWidget).Render())     
        tabs

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
            TabsInternal.Init(this.Element.Dom, this.configuration)

        [<JavaScript>]                                       
        member this.Body
            with get () = this.Element.Dom

    (****************************************************************
    * Methods
    *****************************************************************) 
    [<Inline "jQuery($this.element.el).tabs('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element.el).tabs('disable')">]
    member this.Disable () = ()

    [<Inline "jQuery($this.element.el).tabs('enable')">]
    member this.Enable () = ()

    [<Inline "jQuery($this.element.el).tabs('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    [<Inline "jQuery($this.element.el).tabs('activate', $index)">]
    member this.Activate (index: int) = ()

    [<Inline "jQuery($this.element.el).tabs('add', $url, $label, $index)">]
    member private this.add (url:string, label:string, index: int) = ()

    [<Inline "jQuery($this.element.el).tabs('length')">]
    member private this.getLength () = 0

    [<Inline "jQuery($this.element.el).tabs('remove', $index)">]
    member this.Remove (index: int) = ()    

    [<Inline "jQuery($this.element.el).tabs('select', $index)">]
    member this.Select (index: int) = ()

    [<Inline "jQuery($this.element.el).tabs('load', $index)">]
    member this.Load (index: int) = ()

    [<Inline "jQuery($this.element.el).tabs('url', $index)">]
    member this.Url (index: int) = ()

    [<Inline "jQuery($this.element.el).tabs('abort')">]
    member this.Abort () = ()
    
    [<Inline "jQuery($this.element.el).tabs('rotate', $secs, $loop)">]
    member this.Rotate (secs: int, loop: bool) = ()
    
    [<JavaScript>]
    member this.Length
        with get () = this.getLength()

    [<JavaScript>]
    member this.Add(el: Element, label: string, ix: int) =
        let id = NewId()
        let tab = Div [Id id ] -< [el]
        this.Element.Append tab
        this.add("#" + id, label, ix)

    [<JavaScript>]
    member this.Add(el: Element, label: string) =
        let id = NewId()
        let tab = Div [Id id ] -< [el]
        this.Element.Append tab
        this.add("#" + id, label, this.Length)

    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element.el).tabs({select: function (x,y) {$f(x);}})">]
    member private this.onSelect(f : JQueryEvent -> unit) = ()

    [<Inline "jQuery($this.element.el).tabs({load: function (x,y) {$f(x);}})">]
    member private this.onLoad(f : JQueryEvent -> unit) = ()

    [<Inline "jQuery($this.element.el).tabs({show: function (x,y) {$f(x);}})">]
    member private this.onShow(f : JQueryEvent -> unit) = ()

    [<Inline "jQuery($this.element.el).tabs({add: function (x,y) {$f(x);}})">]
    member private this.onAdd(f : JQueryEvent -> unit) = ()

    [<Inline "jQuery($this.element.el).tabs({remove: function (x,y) {$f(x);}})">]
    member private this.onRemove(f : JQueryEvent -> unit) = ()

    [<Inline "jQuery($this.element.el).tabs({enable: function (x,y) {$f(x);}})">]
    member private this.onEnable(f : JQueryEvent -> unit) = ()

    [<Inline "jQuery($this.element.el).tabs({diable: function (x,y) {$f(x);}})">]
    member private this.onDisable(f : JQueryEvent -> unit) = ()


    [<JavaScript>]
    member this.OnSelect f = 
        this |> OnAfterRender(fun _ -> 
            this.onSelect f
        )

    [<JavaScript>]
    member this.OnLoad f = 
        this |> OnAfterRender(fun _ -> 
            this.onLoad f
        )
    [<JavaScript>]
    member this.OnShow f = 
        this |> OnAfterRender(fun _  -> 
            this.onShow f
        )

    [<JavaScript>]
    member this.OnAdd f = 
        this |> OnAfterRender(fun _  -> 
            this.onAdd f
        )
    [<JavaScript>]
    member this.OnEnable f = 
        this |> OnAfterRender(fun _  -> 
            this.onEnable f
        )
    [<JavaScript>]
    member this.OnDisable f = 
        this |> OnAfterRender(fun _  -> 
            this.onDisable f
        )