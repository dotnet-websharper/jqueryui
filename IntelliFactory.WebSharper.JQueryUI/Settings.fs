// $begin{copyright}
//
// This file is confidential and proprietary.
//
// Copyright (c) IntelliFactory, 2004-2009.
//
// All rights reserved.  Reproduction or use in whole or in part is
// prohibited without the written consent of the copyright holder.
//-----------------------------------------------------------------
// $end{copyright}

namespace IntelliFactory.WebSharper.JQueryUI
open IntelliFactory.WebSharper

[<JavaScriptType>]
module Utils =
    
    [<JavaScriptType>]
    type RenderEvent =
        | Before
        | After


//[<AbstractClass>]
//[<JavaScriptType>]
//type Widget<'T>[<JavaScript>]() =
//    
//    [<DefaultValue>]        
//    val mutable init:  Dom.Element * 'T -> unit
//
//    [<DefaultValue>]
//    val mutable element : Element
//    
//    [<DefaultValue>]
//    val mutable configuration : 'T
//
//    (****************************************************************
//    * INode
//    *****************************************************************)              
//    interface INode with
//        [<JavaScript>]                                       
//        member this.Body
//            with get () = (this.element.Dom :> Dom.Node)
//                
//    (****************************************************************
//    * IWidget
//    *****************************************************************)                  
//    interface IWidget with
//        [<JavaScript>]
//        member this.OnBeforeRender(f: unit -> unit) : unit=
//            this.element
//            |> OnBeforeRender (fun _ -> f ())
//                        
//        [<JavaScript>]
//        member this.OnAfterRender(f: unit -> unit) : unit=
//            this.element
//            |> OnAfterRender (fun _ -> 
//                (this :> IWidget).Render()
//                f ()
//            )
//
//        [<JavaScript>]
//        member this.Render() =
//            (this.element :> IWidget).Render()
//            this.init(this.element.Dom, this.configuration)
//
//        [<JavaScript>]                                       
//        member this.Body
//            with get () = this.element.Dom
        