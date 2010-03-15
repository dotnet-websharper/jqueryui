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

[<JavaScriptType>]
//[<Require(typeof<Dependencies.Carousel>)>]
module ProgressBar =

    [<JavaScriptType>]
    type ProgressBarConfiguration =
        
        [<DefaultValue>]
        [<Name "value">]
        //0 by default
        val mutable Value: int
    
        [<JavaScriptConstructor>]
        new () = {}

    [<JavaScriptType>]
    type ProgressBar = 

        [<Inline "jQuery($id).progressbar()">]
        static member NewPrivate (id: string) = ()

        [<Inline "jQuery($el).progressbar()">]
        static member New (el: Element) = ()

        [<Inline "jQuery($el).progressbar($conf)">]
        static member New (el: Element, conf: ProgressBarConfiguration) = ()

        [<JavaScript>]
        static member Attach (el: Element) = 
            el
            |> On Events.Attach (fun _ _ -> ProgressBar.New el)

        [<JavaScript>]
        static member AttachWithConfiguration (conf: ProgressBarConfiguration) (el: Element) = 
            el
            |> On Events.Attach (fun _ _ -> ProgressBar.New (el, conf))