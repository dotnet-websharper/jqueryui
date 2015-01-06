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
open IntelliFactory.WebSharper.JavaScript
open IntelliFactory.WebSharper.Html.Client

type MenuIcons =
    {
        [<Name "submenu">]
        Submenu : string
    }

type MenuConfiguration[<JavaScript>]() =

    [<Name "disabled">]
    [<Stub>]
    //false by default
    member val Disabled = Unchecked.defaultof<bool> with get, set

    [<Name "icons">]
    [<Stub>]
    member val Icons = Unchecked.defaultof<MenuIcons> with get, set

    [<Name "menus">]
    [<Stub>]
    //false by default
    member val Menus = Unchecked.defaultof<string> with get, set

    [<Name "position">]
    [<Stub>]
    //"center" by default
    member val Position = Unchecked.defaultof<Position> with get, set

    [<Name "role">]
    [<Stub>]
    //"menu" by default
    member val Role = Unchecked.defaultof<string> with get, set

module MenuInternal =
    [<Inline "jQuery($el).menu($conf)">]
    let Init (el: Dom.Element, conf: MenuConfiguration) = ()


[<Require(typeof<Dependencies.JQueryUIJs>)>]
[<Require(typeof<Dependencies.JQueryUICss>)>]
type Menu[<JavaScript>]internal () =
    inherit Utils.Pagelet()

    /// Create a new menu using the given element
    /// and configuration object.
    [<JavaScript>]
    [<Name "New1">]
    static member New (el: Element, conf: MenuConfiguration): Menu =
        let d = new Menu()
        el
        |> OnAfterRender(fun el ->
            MenuInternal.Init(el.Dom, conf)
        )
        d.element <- el
        d

    /// Creates a new menu given an element using
    /// default configuration settings.
    [<JavaScript>]
    [<Name "New2">]
    static member New (el: Element): Menu =
        Menu.New(el, MenuConfiguration())

    (****************************************************************
    * Methods
    *****************************************************************)
    /// Remove the menu functionality.
    [<Inline "jQuery($this.element.Dom).menu('destroy')">]
    member this.Destroy() = ()

    /// Disables the menu.
    [<Inline "jQuery($this.element.Dom).menu('disable')">]
    member this.Disable () = ()

    /// Enables the menu.
    [<Inline "jQuery($this.element.Dom).menu('enable')">]
    member this.Enable () = ()

    /// Sets menu option.
    [<Inline "jQuery($this.element.Dom).menu('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Gets menu option.
    [<Inline "jQuery($this.element.Dom).menu('option', $name)">]
    member this.Option (name: string) = X<obj>

    /// Gets all options.
    [<Inline "jQuery($this.element.Dom).menu('option')">]
    member this.Option () = X<MenuConfiguration>

    /// Sets one or more options.
    [<Inline "jQuery($this.element.Dom).menu('option', $options)">]
    member this.Option (options: MenuConfiguration) = X<unit>

    [<Inline "jQuery($this.element.Dom).menu('widget')">]
    member private this.getWidget () = X<Dom.Element>

    /// Returns the .ui-menu element.
    [<JavaScript>]
    member this.Widget = this.getWidget()

    /// Removes focus from the menu.
    [<Inline "jQuery($this.element.Dom).menu('blur')">]
    member this.Blur () = ()

    /// Removes focus from the menu.
    [<Inline "jQuery($this.element.Dom).menu('blur', $e)">]
    member this.Blur (e: JQuery.Event) = ()

    /// Closes the currently active sub-menu.
    [<Inline "jQuery($this.element.Dom).menu('collapse')">]
    member this.Collapse () = ()

    /// Closes the currently active sub-menu.
    [<Inline "jQuery($this.element.Dom).menu('collapse', $e)">]
    member this.Collapse (e: JQuery.Event) = ()

    /// Closes all open sub-menus.
    [<Inline "jQuery($this.element.Dom).menu('collapseAll')">]
    member this.CollapseAll () = ()

    /// Closes all open sub-menus.
    [<Inline "jQuery($this.element.Dom).menu('collapseAll', $e)">]
    member this.CollapseAll (e: JQuery.Event) = ()

    /// Closes all open sub-menus.
    [<Inline "jQuery($this.element.Dom).menu('collapseAll', $e, $all)">]
    member this.CollapseAll (e: JQuery.Event, all: bool) = ()

    /// Opens the sub-menu below the currently active item, if one exists.
    [<Inline "jQuery($this.element.Dom).menu('expand')">]
    member this.Expand () = ()

    /// Opens the sub-menu below the currently active item, if one exists.
    [<Inline "jQuery($this.element.Dom).menu('expand', $e)">]
    member this.Expand (e: JQuery.Event) = ()

    /// Activates a particular menu item, begins opening any sub-menu if present and triggers the menu's focus event.
    [<Inline "jQuery($this.element.Dom).menu('focus', $item)">]
    member this.Focus (item: JQuery.JQuery) = ()

    /// Activates a particular menu item, begins opening any sub-menu if present and triggers the menu's focus event.
    [<Inline "jQuery($this.element.Dom).menu('focus', $e, $item)">]
    member this.Focus (e: JQuery.Event, item: JQuery.JQuery) = ()

    /// Returns a boolean value stating whether or not the currently active item is the first item in the menu.
    [<Inline "jQuery($this.element.Dom).menu('isFirstItem')">]
    member this.IsFirstItem () = false

    /// Returns a boolean value stating whether or not the currently active item is the last item in the menu.
    [<Inline "jQuery($this.element.Dom).menu('isLastItem')">]
    member this.IsLastItem () = false

    /// Moves active state to next menu item.
    [<Inline "jQuery($this.element.Dom).menu('next')">]
    member this.Next () = ()

    /// Moves active state to next menu item.
    [<Inline "jQuery($this.element.Dom).menu('next', $e)">]
    member this.Next (e: JQuery.Event) = ()

    /// Moves active state to first menu item below the bottom of a scrollable menu or the last item if not scrollable.
    [<Inline "jQuery($this.element.Dom).menu('nextPage')">]
    member this.NextPage () = ()

    /// Moves active state to first menu item below the bottom of a scrollable menu or the last item if not scrollable.
    [<Inline "jQuery($this.element.Dom).menu('nextPage', $e)">]
    member this.NextPage (e: JQuery.Event) = ()

    /// Moves active state to previous menu item.
    [<Inline "jQuery($this.element.Dom).menu('previous')">]
    member this.Previous () = ()

    /// Moves active state to previous menu item.
    [<Inline "jQuery($this.element.Dom).menu('previous', $e)">]
    member this.Previous (e: JQuery.Event) = ()

    /// Moves active state to first menu item below the bottom of a scrollable menu or the last item if not scrollable.
    [<Inline "jQuery($this.element.Dom).menu('previousPage')">]
    member this.PreviousPage () = ()

    /// Moves active state to first menu item below the bottom of a scrollable menu or the last item if not scrollable.
    [<Inline "jQuery($this.element.Dom).menu('previousPage', $e)">]
    member this.PreviousPage (e: JQuery.Event) = ()

    /// Initializes sub-menus and menu items that have not already been initialized. New menu items, including sub-menus can be added to the menu or all of the contents of the menu can be replaced and then initialized with the refresh() method.
    [<Inline "jQuery($this.element.Dom).menu('refresh')">]
    member this.Refresh () = ()

    /// Selects the currently active menu item, collapses all sub-menus and triggers the menu's select event.
    [<Inline "jQuery($this.element.Dom).menu('selectPage')">]
    member this.SelectPage () = ()

    /// Selects the currently active menu item, collapses all sub-menus and triggers the menu's select event.
    [<Inline "jQuery($this.element.Dom).menu('selectPage', $e)">]
    member this.SelectPage (e: JQuery.Event) = ()

    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element.Dom).bind('menucreate', function (x,y) {$f(x);})">]
    member private this.onCreate(f : JQuery.Event -> unit) = ()

    [<Inline "jQuery($this.element.Dom).bind('menufocus', function (x,y) {($f(x))(y.item);})">]
    member private this.onFocus(f : JQuery.Event -> JQuery.JQuery -> unit) = ()

    [<Inline "jQuery($this.element.Dom).bind('menublur', function (x,y) {($f(x))(y.item);})">]
    member private this.onBlur(f : JQuery.Event -> JQuery.JQuery -> unit) = ()

    [<Inline "jQuery($this.element.Dom).bind('menuselect', function (x,y) {($f(x))(y.item);})">]
    member private this.onSelect(f : JQuery.Event -> JQuery.JQuery -> unit) = ()


    /// Triggered before the menu is closed.
    [<JavaScript>]
    member this.OnCreate(f : JQuery.Event -> unit) =
        this |> OnAfterRender (fun _ -> this.onCreate f)

    /// Triggered before the menu gains focus.
    [<JavaScript>]
    member this.OnFocus (f : JQuery.Event -> JQuery.JQuery -> unit) =
        this |> OnAfterRender (fun _  -> this.onFocus f)

    /// Triggered after the menu loses focus.
    [<JavaScript>]
    member this.OnBlur (f : JQuery.Event -> JQuery.JQuery -> unit) =
        this |> OnAfterRender (fun _ -> this.onBlur f)

    /// Triggered when a menu item is selected.
    [<JavaScript>]
    member this.OnSelect (f : JQuery.Event -> JQuery.JQuery -> unit) =
        this |> OnAfterRender (fun _ -> this.onSelect f)





