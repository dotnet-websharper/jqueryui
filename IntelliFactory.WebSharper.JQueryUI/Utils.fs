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
open IntelliFactory.WebSharper.Html.Client

[<AutoOpen>]
[<JavaScript>]
module Utils =

    type JQuery.JQuery with
        [<Inline "$this.eq($i)">]
        member this.Eq(i: int) = this

    type Pagelet() =
        inherit Html.Client.Pagelet()

        [<DefaultValue>]
        val mutable internal element : Element

        override this.Render() =
            this.element.Render()

        override this.Body
            with get() = this.element.Body
