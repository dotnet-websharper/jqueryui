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



module internal AutocompleteInternal =
    [<Inline "jQuery($el).autocomplete($conf)">]
    let Init (el: Dom.Element, conf: AutocompleteConfiguration) = ()    


[<Resources.JQueryUIAllJS>]
[<Resources.JQueryUIAllCss>]
type Autocomplete[<JavaScript>] internal () =
    
    [<DefaultValue>]
    val mutable internal element : IPagelet

    interface IPagelet with
        [<JavaScript>]
        member this.Render () = 
            Log "Render auto complete"
            this.element.Render()
        [<JavaScript>]
        member this.Body = this.element.Body 


    (****************************************************************
    * Constructors
    *****************************************************************) 
    /// Creates an autocomplete widget from the given element and 
    /// configuration object.
    [<JavaScript>]
    [<Name "New1">]
    static member New (el : Element, conf: AutocompleteConfiguration): Autocomplete = 
        let a = new Autocomplete()
        el          
        |> OnAfterRender (fun el  ->             
            Log "Init autocomplete"
            AutocompleteInternal.Init(el.Body :?> _, conf)
        )
        a.element <- el
        a
                
    /// Creates an autocomplete widget from the given element and 
    /// configuration object.
    [<JavaScript>]
    [<Name "New2">]
    static member New (el : Element): Autocomplete = 
        Autocomplete.New(el, new AutocompleteConfiguration())
        
    /// Creates an autocomplete widget from an input element using
    /// the default configuration.
    [<JavaScript>]
    [<Name "New3">]
    static member New (): Autocomplete = 
        Autocomplete.New(Input [], new AutocompleteConfiguration())
    
    /// Creates an autocomplete widget from an input element using
    /// the given configuration.
    [<JavaScript>]
    [<Name "New4">]
    static member New (conf: AutocompleteConfiguration): Autocomplete = 
        Autocomplete.New(Input [], conf)                
            
    (****************************************************************
    * Methods
    *****************************************************************) 
    /// Remove the autocomplete functionality completely.
    [<Inline "jQuery($this.element.Body).autocomplete('destroy')">]
    member this.Destroy() = ()

    /// Disables the autocomplete.
    [<Inline "jQuery($this.element.Body).autocomplete('disable')">]
    member this.Disable () = ()

    // Enables the autocomplete.
    [<Inline "jQuery($this.element.Body).autocomplete('enable')">]
    member this.Enable () = ()

    /// Get or set any autocomplete option. If no value is specified, will act as a getter.
    [<Inline "jQuery($this.element.Body).autocomplete('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Triggers a search event using the current string value, which, when data is available, 
    /// then will display the suggestions; 
    /// can be used by a selectbox-like button to open the suggestions when clicked. 
    /// The current input's value is used. 
    [<Inline "jQuery($this.element.Body).autocomplete('search')">]
    member this.Search () = ()

    /// Triggers a search event using the given string value, which, when data is 
    /// available, then will display the suggestions; 
    /// can be used by a selectbox-like button to open the suggestions when clicked. 
    [<Inline "jQuery($this.element.Body).autocomplete('search', $value)">]
    member this.Search (value: string) = ()

    /// Close the Autocomplete menu. Useful in combination with 
    /// the search method, to close the open menu.
    [<Inline "jQuery($this.element.Body).autocomplete('close')">]
    member this.Close () = ()

    (****************************************************************
    * Events
    *****************************************************************) 
    
    [<Inline "jQuery($this.element.Body).autocomplete({search: function (x,y) {($f(x))(y.search);}})">]
    member private this.onSearch(f : JQuery.Event -> Element -> unit) = ()
    
    [<Inline "jQuery($this.element.Body).autocomplete({focus: function (x,y) {($f(x))(y.focus);}})">]
    member private this.onFocus(f : JQuery.Event -> Element -> unit) = ()
    
    [<Inline "jQuery($this.element.Body).autocomplete({select: function (x,y) {($f(x))(y.select);}})">]
    member private this.onSelect(f : JQuery.Event -> Element -> unit) = ()
    
    [<Inline "jQuery($this.element.Body).autocomplete({close: function (x,y) {($f(x))(y.close);}})">]
    member private this.onClose(f : JQuery.Event -> Element -> unit) = ()

    /// After an item was selected; ui.item refers to the selected item. 
    /// Always triggered after the close event
    [<Inline "jQuery($this.element.Body).autocomplete({change: function (x,y) {($f(x))(y.change);}})">]
    member private this.onChange(f : JQuery.Event -> Element -> unit) = ()

    /// Triggered before a request (source-option) is started.
    [<JavaScript>]
    member this.OnSearch f =
        this 
        |> OnAfterRender (fun _ -> this.onSearch f)
        |> ignore

    /// After an item was selected. Always triggered after the close event.
    [<JavaScript>]
    member this.OnChange f =
        this 
        |> OnAfterRender (fun _ -> this.onChange f)
        |> ignore

    /// Triggered when the list is hidden.
    [<JavaScript>]
    member this.OnClose f =
        this 
        |> OnAfterRender (fun _ -> this.onClose f)
        |> ignore

    /// Before focus is moved to an item (not selecting), ui.item refers to the focused item. 
    [<JavaScript>]
    member this.OnFocus f =
        this 
        |> OnAfterRender (fun _ -> this.onFocus f)
        |> ignore
        
    /// Tiggered when an item is selected from the menu; 
    [<JavaScript>]
    member this.OnSelect f =
        this 
        |> OnAfterRender (fun _ -> this.onSelect f)        
        |> ignore