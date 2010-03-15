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
module Autocomplete = 
    
    [<JavaScriptType>]
    type AutocompleteConfiguration = 

        [<DefaultValue>]
        [<Name "delay">]
        val mutable Delay: int

        [<DefaultValue>]
        [<Name "minLength">]
        val mutable MinLength: int

        [<DefaultValue>]
        [<Name "source">]
        val mutable Source: array<string>

        [<JavaScriptConstructor>]
        new () = {}

    [<JavaScriptType>]
    type Autocomplete = 

        [<Inline "jQuery($id).autocomplete()">]
            static member NewPrivate (id: string) = ()

            [<Inline "jQuery($el).autocomplete()">]
            static member New (el: Element) = ()

            [<Inline "jQuery($el).autocomplete($conf)">]
            static member New (el: Element, conf: AutocompleteConfiguration) = ()

            [<JavaScript>]
            static member Attach (el: Element) = 
                el
                |> On Events.Attach (fun _ _ -> Autocomplete.New el)

            [<JavaScript>]
            static member AttachWithConfiguration (conf: AutocompleteConfiguration) (el: Element) = 
                el
                |> On Events.Attach (fun _ _ -> Autocomplete.New (el, conf))