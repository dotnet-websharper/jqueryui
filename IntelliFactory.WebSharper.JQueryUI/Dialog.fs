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
module Dialog =
    
//    [<JavaScriptType>]
//    type DialogButtonsConfiguration = 
//        {
//        [<Name "buttons">]
//        OK: InnerDialogButtonsConfiguration
//        }
//
//        [<JavaScript>]
//        static member Default = {OK = InnerDialogButtonsConfiguration}
//
//    [<JavaScriptType>]
//    type InnerDialogButtonsConfiguration = 
//        {
//        f: unit -> unit
//        }
//
//        [<JavaScript>]
//        //need to use Dialog object method - dialog ("close")
//        static member Default = {f: fun () -> dialog...}

//    [<JavaScriptType>]
//    type DialogPositionConfiguration = 
//        | Str
//        | Arr
//
//        [<JavaScript>]
//        static member Default param = 
//            match param with
//            | Str -> Str <- "top"
//            | Arr -> Arr <- [|350; 100|]

    [<JavaScriptType>]
    type DialogConfiguration = 

        [<DefaultValue>]
        [<Name "autoOpen">]
        //true by default
        val mutable AutoOpen: bool

//        //New version of JQueryUI 1.8 removes bgiframe
//        [<DefaultValue>]
//        [<Name "bgiframe">]
//        //false by default
//        val mutable Bgiframe: bool

        //Buttons' type to be confirmed (string -> (string -> unit) -> unit)
        [<DefaultValue>]
        [<Name "buttons">]
        //"" by default
        val mutable Buttons: string

        [<DefaultValue>]
        [<Name "closeOnEscape">]
        //false by default
        val mutable CloseOnEscape: bool

        [<DefaultValue>]
        [<Name "closeText">]
        //"close" by default
        val mutable CloseText: string

        [<DefaultValue>]
        [<Name "dialogClass">]
        //"" by default
        val mutable DialogClass: string

        [<DefaultValue>]
        [<Name "draggable">]
        //true by default
        val mutable Draggable: bool

        [<DefaultValue>]
        [<Name "height">]
        val mutable Height: int

        [<DefaultValue>]
        [<Name "hide">]
        //"" by default
        val mutable Hide: string

        [<DefaultValue>]
        [<Name "maxHeight">]
        val mutable MaxHeight: int

        [<DefaultValue>]
        [<Name "maxWidth">]
        val mutable MaxWidth: int

        [<DefaultValue>]
        [<Name "minHeight">]
        val mutable MinHeight: int

        [<DefaultValue>]
        [<Name "minWidth">]
        val mutable MinWidth: int

        [<DefaultValue>]
        [<Name "modal">]
        //false by default
        val mutable Modal: bool

        [<DefaultValue>]
        [<Name "position">]
        //"center" by default
        val mutable Position: string

        [<DefaultValue>]
        [<Name "resizable">]
        //true by default
        val mutable Resizable: bool

        [<DefaultValue>]
        [<Name "show">]
        //"" by default
        val mutable Show: string

        [<DefaultValue>]
        [<Name "stack">]
        //true by default
        val mutable Stack: bool

        [<DefaultValue>]
        [<Name "title">]
        //"" by default
        val mutable Title: string

        [<DefaultValue>]
        [<Name "width">]
        //300 by default
        val mutable Width: int

        [<DefaultValue>]
        [<Name "zindex">]
        //1000 by default
        val mutable ZIndex: int

        [<JavaScriptConstructor>]
        new () = {}

    [<JavaScriptType>]
    type Dialog = 
  
        [<Inline "jQuery($id).dialog()">]
        static member NewPrivate (id: string) = ()

        [<Inline "jQuery($el).dialog()">]
        static member New (el: Element) = ()

        [<Inline "jQuery($el).dialog($conf)">]
        static member New (el: Element, conf: DialogConfiguration) = ()


        [<JavaScript>]
        static member Attach (el: Element) = 
            el
            |> On Events.Attach (fun _ _ -> Dialog.New el)

        [<JavaScript>]
        static member AttachWithConfiguration (conf: DialogConfiguration) (el: Element) = 
            el
            |> On Events.Attach (fun _ _ -> Dialog.New (el, conf))


