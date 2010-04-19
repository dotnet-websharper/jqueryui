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
type Progressbar[<JavaScript>]() = 
    
    [<DefaultValue>]
    val mutable private element : Element

    [<DefaultValue>]
    val mutable private configuration : ProgressbarConfiguration
    
    [<JavaScript>]
    member this.Element
        with get () =
            this.element

    (****************************************************************
    * Constructors
    *****************************************************************)        
    [<JavaScript>]
    static member New (el: Element, conf: ProgressbarConfiguration) =
        let pb = new Progressbar()
        pb.configuration <- conf
        pb.element <- el
        el
        |>! OnAfterRender (fun _  -> 
            (pb :> IWidget).Render()
        )
        |> ignore
        pb

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
            ProgressbarInternal.Init(this.Element.Dom, this.configuration)

        [<JavaScript>]                                       
        member this.Body
            with get () = this.Element.Dom



    (****************************************************************
    * Methods
    *****************************************************************) 
    [<Inline "jQuery($this.element.el).progressbar('destroy')">]
    member this.Destroy() = ()

    [<Inline "jQuery($this.element.el).progressbar('disable')">]
    member this.Disable () = ()

    [<Inline "jQuery($this.element.el).progressbar('enable')">]
    member this.Enable () = ()

    [<Inline "jQuery($this.element.el).progressbar('option', $name, $value)">]
    member this.Option (name: string, value: obj) = ()

    [<Inline "jQuery($this.element.el).progressbar('value', $v)">]
    member private this.setValue (v: int) = ()

    [<Inline "jQuery($this.element.el).progressbar('value')">]
    member private this.getValue () = 0

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

    // Adding an event and delayin it if the widget is not yet rendered.
    [<JavaScript>]
    member this.OnChange(f : JQueryEvent -> unit) =
        this |> OnAfterRender(fun _ ->
            this.onChange f
        )