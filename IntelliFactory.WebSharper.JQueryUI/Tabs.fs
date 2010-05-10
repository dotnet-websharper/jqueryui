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
type Tabs[<JavaScript>] internal () = 
    inherit Widget()

    (****************************************************************
    * Constructors
    *****************************************************************)        
    /// Creates a new tabs object with panels and titles fromt the given
    /// list of name and element pairs and configuration settings object.
    [<JavaScript>]
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
        tabs.element <-
            el 
            |>! OnAfterRender (fun el -> 
                TabsInternal.Init(el.Dom, conf)
            )     
        tabs
    
    /// Creates a new tabs object using the default configuration.
    [<JavaScript>]
    static member New (els : List<string * Element>): Tabs =
        Tabs.New(els, new TabsConfiguration())


    (****************************************************************
    * Methods
    *****************************************************************) 
    /// Removes the tabs functionality completely.
    [<Inline "jQuery($this.element.el).tabs('destroy')">]
    member this.Destroy() = ()

    /// Disables the tabs functionality.
    [<Inline "jQuery($this.element.el).tabs('disable')">]
    member this.Disable () = ()

    /// Enables the tabs functionality.
    [<Inline "jQuery($this.element.el).tabs('enable')">]
    member this.Enable () = ()

    /// Sets a tabs option.
    [<Inline "jQuery($this.element.el).tabs('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()
        
    [<Inline "jQuery($this.element.el).tabs('add', $url, $label, $index)">]
    member private this.add (url:string, label:string, index: int) = ()

    [<Inline "jQuery($this.element.el).tabs('length')">]
    member private this.getLength () = 0

    /// Removes the tab with the given index.
    [<Inline "jQuery($this.element.el).tabs('remove', $index)">]
    member this.Remove (index: int) = ()    

    /// Selects the tab with the given index.
    [<Inline "jQuery($this.element.el).tabs('select', $index)">]
    member this.Select (index: int) = ()

    /// Reloads the content of an Ajax tab.
    [<Inline "jQuery($this.element.el).tabs('load', $index)">]
    member this.Load (index: int) = ()

    /// Changes the url from which an Ajax (remote) tab will be loaded.
    [<Inline "jQuery($this.element.el).tabs('url', $index)">]
    member this.Url (index: int) = ()
    
    /// Sets up an automatic rotation through tabs of a tab pane. 
    /// The second argument is an amount of time in milliseconds until the next 
    /// tab in the cycle gets activated. Use 0 or null to stop the rotation. 
    /// The third controls whether or not to continue the rotation after a tab has been 
    /// selected by a user.
    [<Inline "jQuery($this.element.el).tabs('rotate', $secs, $loop)">]
    member this.Rotate (secs: int, loop: bool) = ()
    
    /// Retrieve the number of tabs of the first matched tab pane.
    [<JavaScript>]
    member this.Length
        with get () = this.getLength()

    /// Add a new tab with the given element and label
    /// inserted at the specified index.
    [<JavaScript>]
    member this.Add(el: Element, label: string, ix: int) =
        let id = NewId()
        let tab = Div [Id id ] -< [el]
        this.element.Append tab
        this.add("#" + id, label, ix)

    /// Add a new tab with the given element and label.
    [<JavaScript>]
    member this.Add(el: Element, label: string) =
        let id = NewId()
        let tab = Div [Id id ] -< [el]
        this.element.Append tab
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


    /// Event triggered when a tab is selcted.
    [<JavaScript>]
    member this.OnSelect f = 
        this |> OnAfterRender(fun _ -> 
            this.onSelect f
        )

    /// Event triggered when a tab is loaded.
    [<JavaScript>]
    member this.OnLoad f = 
        this |> OnAfterRender(fun _ -> 
            this.onLoad f
        )
    
    /// Event triggered when a tab is showed.
    [<JavaScript>]
    member this.OnShow f = 
        this |> OnAfterRender(fun _  -> 
            this.onShow f
        )

    /// Event triggered when a tab is added.
    [<JavaScript>]
    member this.OnAdd f = 
        this |> OnAfterRender(fun _  -> 
            this.onAdd f
        )
    /// Event triggered when a tab is enabled.
    [<JavaScript>]
    member this.OnEnable f = 
        this |> OnAfterRender(fun _  -> 
            this.onEnable f
        )
    /// Event triggered when a tab is disabled.
    [<JavaScript>]
    member this.OnDisable f = 
        this |> OnAfterRender(fun _  -> 
            this.onDisable f
        )