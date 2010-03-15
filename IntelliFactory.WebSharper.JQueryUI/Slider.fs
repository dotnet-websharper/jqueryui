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
module Slider = 
    
    [<JavaScriptType>]
    type SliderConfiguration = 
        
        [<DefaultValue>]
        [<Name "animate">]
        //false by default
        val mutable Animate: bool

        [<DefaultValue>]
        [<Name "max">]
        //100 by default
        val mutable Max: int

        [<DefaultValue>]
        [<Name "min">]
        //0 by default
        val mutable Min: int

        [<DefaultValue>]
        [<Name "orientation">]
        //"horizontal" by default
        val mutable Orientation: string

        [<DefaultValue>]
        [<Name "rang">]
        val mutable Rang: string

        [<DefaultValue>]
        [<Name "step">]
        //1 by default
        val mutable Step: int

        [<DefaultValue>]
        [<Name "value">]
        //0 by default
        val mutable Value: int

        [<DefaultValue>]
        [<Name "values">]
        //0 by default
        val mutable Values: array<int>

        [<JavaScriptConstructor>]
        new () = {}


    [<JavaScriptType>]
    type Slider = 

        [<Inline "jQuery($id).slider()">]
            static member NewPrivate (id: string) = ()

            [<Inline "jQuery($el).slider()">]
            static member New (el: Element) = ()

            [<Inline "jQuery($el).slider($conf)">]
            static member New (el: Element, conf: SliderConfiguration) = ()

            [<JavaScript>]
            static member Attach (el: Element) = 
                el
                |> On Events.Attach (fun _ _ -> Slider.New el)

            [<JavaScript>]
            static member AttachWithConfiguration (conf: SliderConfiguration) (el: Element) = 
                el
                |> On Events.Attach (fun _ _ -> Slider.New (el, conf))


