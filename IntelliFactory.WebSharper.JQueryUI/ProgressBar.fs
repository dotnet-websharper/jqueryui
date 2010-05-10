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
type ProgressbarConfiguration[<JavaScript>]() =
    
    [<DefaultValue>]
    [<Name "value">]
    //0 by default
    val mutable Value: int


[<JavaScriptType>]    
module internal ProgressbarInternal =
    [<Inline "jQuery($el).progressbar($conf)">]
    let Init (el: Dom.Element, conf: ProgressbarConfiguration) = ()

[<JavaScriptType>]
type Progressbar[<JavaScript>]internal () = 
    inherit Widget()
    
    (****************************************************************
    * Constructors
    *****************************************************************)        
    /// Creates a new progressbar given an element and a 
    /// configuration object.
    [<JavaScript>]
    static member New (el: Element, conf: ProgressbarConfiguration) =
        let pb = new Progressbar()
        pb.element <- el
        el
        |> OnAfterRender (fun el  -> 
            ProgressbarInternal.Init(el.Dom, conf)
        )
        pb

    /// Creates a new progressbar given an element using
    /// the default configuration.
    [<JavaScript>]
    static member New (el: Element) =
        Progressbar.New(el, new ProgressbarConfiguration())


    /// Creates a new progressbar based on an
    /// empty Div element and the given a configuration object.
    [<JavaScript>]
    static member New ( conf: ProgressbarConfiguration) =
        Progressbar.New(Div [], conf)

    /// Creates a new progressbar based on an empty Div element
    /// and the default configuration.
    [<JavaScript>]
    static member New () =
        Progressbar.New(Div [], new ProgressbarConfiguration())

    (****************************************************************
    * Methods
    *****************************************************************) 
    /// Removes the progressbar functionality completely.
    [<Inline "jQuery($this.element.el).progressbar('destroy')">]
    member this.Destroy() = ()

    /// Disables the progressbar functionality.
    [<Inline "jQuery($this.element.el).progressbar('disable')">]
    member this.Disable () = ()

    /// Enables the progressbar functionality.
    [<Inline "jQuery($this.element.el).progressbar('enable')">]
    member this.Enable () = ()

    /// Sets a progressbar option.
    [<Inline "jQuery($this.element.el).progressbar('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    /// Sets the value of the progressbar.
    [<Inline "jQuery($this.element.el).progressbar('value', $v)">]
    member private this.setValue (v: int) = ()

    /// Gets the value of the progressbar.
    [<Inline "jQuery($this.element.el).progressbar('value')">]
    member private this.getValue () = 0

    /// Gets or sets the value of the progressbar.
    [<JavaScript>]
    member this.Value
        with get () =
            this.getValue()
        and set (v: int) =
            this.setValue v

    (****************************************************************
    * Events
    *****************************************************************)
    [<Inline "jQuery($this.element.el).accordion({change: function (x,y) {$f(x);}})">]
    member private this.onChange(f : JQueryEvent -> unit) = ()

    // Event triggered when the value of the progressbar changes.
    [<JavaScript>]
    member this.OnChange(f : JQueryEvent -> unit) =
        this |> OnAfterRender(fun _ ->
            this.onChange f
        )