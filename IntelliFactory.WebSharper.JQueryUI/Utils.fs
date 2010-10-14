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
open IntelliFactory.WebSharper.Html

[<AutoOpen>]
module Utils =
    [<JavaScript>]
    let (|>!) x f = f x; x

    [<Inline "console.log($x)">]    
    let Log x = ()

//// [<AbstractClass>]
type Pagelet[<JavaScript>]() =
               
    [<DefaultValue>]
    val mutable internal element : Element
                        
    (****************************************************************
    * IPagelet
    *****************************************************************)                  
    interface IPagelet with
        
        [<JavaScript>]
        member this.Render() = 
            Log "GO"           
            (this.element :> IPagelet).Render()

        [<JavaScript>]                                       
        member this.Body
            with get () = this.element.Body :> _
