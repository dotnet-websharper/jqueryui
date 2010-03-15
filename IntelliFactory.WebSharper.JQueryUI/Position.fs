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
module Position =
    
    [<JavaScriptType>]
    type Target = 
        | Element of Element
        | Event of Events.EventArgs
        | Id of string
        [<JavaScript>]
        [<Name "toString">]
        override this.ToString() = 
            match this with
            | Element el -> unbox<string> (box el)
            | Event ev   -> unbox (box ev)
            | Id str     -> "#" + str 
 
    [<JavaScriptType>]
    type PositionConfiguration =
    
        [<DefaultValue>]
        [<Name "my">]
        //Possible values: "top", "center", "bottom", "left", "right"
        val mutable My: string

        [<DefaultValue>]
        [<Name "at">]
        //Possible values: "top", "center", "bottom", "left", "right"
        val mutable At: string

        //Element to position against. You can use a browser event object contains pageX and pageY values. Example: "#top-menu"
        [<DefaultValue>]
        [<Name "of">]        
        val mutable private ofInternal : string

        //Element to position against. You can use a browser event object contains pageX and pageY values. Example: "#top-menu"
        [<DefaultValue>]
        val mutable private ofTarget : Target

        [<JavaScript>]
        member this.Of 
            with get () =
                this.ofTarget
            and set t =
                this.ofTarget <- t
                this.ofInternal <- t.ToString()


        [<JavaScript>]
        member this.Of 
            with set (t: int) =
                ()
                

        //Add these left-top values to the calculated position, eg. "50 50" (left top) A single value such as "50" will apply to both
        [<DefaultValue>]        
        val mutable offset: string        
        //
        [<DefaultValue>]
        val mutable private offsetTuple: (int * int)
        
        [<DefaultValue>]
        [<Name "collision">]
        //This accepts a single value or a pair for horizontal/vertical, eg. "flip", "fit", "fit flip", "fit none". 
        val mutable Collision: string

        [<DefaultValue>]
        [<Name "by">]
        //When specified the actual property setting is delegated to this callback. Receives a single parameter which is a hash of top and left values for the position that should be set.
        val mutable By: unit -> unit //should take a one parameter

        [<DefaultValue>]
        [<Name "bgiframe">]
        //true by default
        val mutable Bgiframe: bool

        [<JavaScript>]                      
        member this.Offset     
            with get () =
                this.offsetTuple                                                   
            and set pos =                
                this.offsetTuple <- pos
                let (x,y) = pos
                this.offset <- string x + " " + string y

        [<JavaScriptConstructor>]
        new () = {}

    [<JavaScriptType>]
    type Position = 
            
        [<Inline "jQuery($id).position()">]
        static member NewPrivate (id: string) = ()

        [<Inline "jQuery($el).position()">]
        static member New (el: Element) = ()

        [<Inline "jQuery($el).position($conf)">]
        static member New (el: Element, conf: PositionConfiguration) = ()

        [<JavaScript>]
        static member Attach (el: Element) =
            el
            |> On Events.Attach (fun _ _ -> Position.New (el))

        [<JavaScript>]
        static member AttachWithConfiguration (conf: PositionConfiguration) (el: Element) =
            el
            |> On Events.Attach (fun _ _ -> Position.New (el, conf))
