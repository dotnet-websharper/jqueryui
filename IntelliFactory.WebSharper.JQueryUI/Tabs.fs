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
type TabsConfiguration = 
    
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

    [<JavaScriptConstructor>]
    new () = {}
    
[<JavaScriptType>]
module internal TabsInternal =
    [<Inline "jQuery($el).tabs($conf)">]
    let Init(el: Element, conf: TabsConfiguration) = ()    

[<JavaScriptType>]
type Tabs = 
    [<JavaScriptConstructor>]
    new () = {}
    
    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : TabsConfiguration

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
    [<Name "New2">]
    static member New (els : List<string * Element>, conf: TabsConfiguration): Tabs =        
        let el = 
            let itemPanels =
                els
                |> List.map (fun (label, panel) ->
                   let id = NewId()
                   let item = LI [A [HRef ("#" + id)] -< [label]] -< [panel]
                   let tab = Div [Id id] -< [P [panel]]
                   (item, tab)
                )
            let ul = itemPanels |> List.map fst |> UL
            Div <| ul :: (List.map snd itemPanels)
        
        let tabs = new Tabs ()
        tabs.configuration <- conf
        tabs.renderEvent <- new Event<RenderEvent>()
        tabs.element <-
            el 
            |> On Events.Attach (fun _ _ -> tabs.Render())     
        tabs

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
            TabsInternal.Init(this.Element, this.configuration)
            this.renderEvent.Trigger Utils.RenderEvent.After
            this.isRendered <- true
    
    [<JavaScript>]
    member this.IsRendered
        with get () : bool = this.isRendered

    (****************************************************************
    * Methods
    *****************************************************************) 
    [<Inline "jQuery($this.element).tabs('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element).tabs('disable')">]
    member this.Disable () = ()

    [<Inline "jQuery($this.element).tabs('enable')">]
    member this.Enable () = ()

    [<Inline "jQuery($this.element).tabs('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    [<Inline "jQuery($this.element).tabs('activate', $index)">]
    member this.Activate (index: int) = ()

    [<Inline "jQuery($this.element).tabs('add', $url, $label, $index)">]
    member private this.add (url:string, label:string, index: int) = ()

    [<Inline "jQuery($this.element).tabs('length')">]
    member private this.getLength () = 0

    [<Inline "jQuery($this.element).tabs('remove', $index)">]
    member this.Remove (index: int) = ()    

    [<Inline "jQuery($this.element).tabs('select', $index)">]
    member this.Select (index: int) = ()

    [<Inline "jQuery($this.element).tabs('load', $index)">]
    member this.Load (index: int) = ()

    [<Inline "jQuery($this.element).tabs('url', $index)">]
    member this.Url (index: int) = ()

    [<Inline "jQuery($this.element).tabs('abort')">]
    member this.Abort () = ()
    
    [<Inline "jQuery($this.element).tabs('rotate', $secs, $loop)">]
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
    [<Inline "jQuery($this.element).tabs({select: function (x,y) {$f(x);}})">]
    member private this.onSelect(f : Events.EventArgs -> unit) = ()

    [<Inline "jQuery($this.element).tabs({load: function (x,y) {$f(x);}})">]
    member private this.onLoad(f : Events.EventArgs -> unit) = ()

    [<Inline "jQuery($this.element).tabs({show: function (x,y) {$f(x);}})">]
    member private this.onShow(f : Events.EventArgs -> unit) = ()

    [<Inline "jQuery($this.element).tabs({add: function (x,y) {$f(x);}})">]
    member private this.onAdd(f : Events.EventArgs -> unit) = ()

    [<Inline "jQuery($this.element).tabs({remove: function (x,y) {$f(x);}})">]
    member private this.onRemove(f : Events.EventArgs -> unit) = ()

    [<Inline "jQuery($this.element).tabs({enable: function (x,y) {$f(x);}})">]
    member private this.onEnable(f : Events.EventArgs -> unit) = ()

    [<Inline "jQuery($this.element).tabs({diable: function (x,y) {$f(x);}})">]
    member private this.onDisable(f : Events.EventArgs -> unit) = ()

    // Adding an event and delaying it if the widget is not yet rendered.
    [<JavaScript>]
    member private this.OnAfter (f : unit -> unit) : unit =
        if this.IsRendered then 
            f ()
        else            
            this.OnAfterRender(fun () -> f ())  

    [<JavaScript>]
    member this.OnSelect f = 
        this.OnAfter (fun () -> 
            this.onSelect f
        )

    [<JavaScript>]
    member this.OnLoad f = 
        this.OnAfter (fun () -> 
            this.onLoad f
        )
    [<JavaScript>]
    member this.OnShow f = 
        this.OnAfter (fun () -> 
            this.onShow f
        )

    [<JavaScript>]
    member this.OnAdd f = 
        this.OnAfter (fun () -> 
            this.onAdd f
        )
    [<JavaScript>]
    member this.OnEnable f = 
        this.OnAfter (fun () -> 
            this.onEnable f
        )
    [<JavaScript>]
    member this.OnDisable f = 
        this.OnAfter (fun () -> 
            this.onDisable f
        )