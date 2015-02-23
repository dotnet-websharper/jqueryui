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

namespace WebSharper.JQueryUI
open WebSharper
open WebSharper.Html.Client

[<JavaScript>]
module Utils =

    type Pagelet() =
        inherit Html.Client.Pagelet()

        [<DefaultValue>]
        val mutable internal element : Element

        override this.Render() =
            this.element.Render()

        override this.Body
            with get() = this.element.Body
