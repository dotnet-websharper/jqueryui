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

//
//module Position =

type Target =
    | Element of Dom.Element
    | Event of JQuery.Event
    | Id of string

    [<JavaScript>]
    override this.ToString() =
        match this with
        | Element el -> unbox<string> (box el)
        | Event ev   -> unbox (box ev)
        | Id str     -> "#" + str


type PositionConfiguration [<JavaScript>]() =

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


module internal PositionInternal =
    [<Inline "jQuery($el).position($conf)">]
    let internal New (el: Dom.Element, conf: PositionConfiguration) = ()

[<Require(typeof<Dependencies.JQueryUI>)>]
type Position [<JavaScript>] internal () =
    inherit Pagelet()

    (****************************************************************
    * Constructors
    *****************************************************************)
    /// Creates a new position object given an element and a
    /// configuration object.
    [<JavaScript>]
    [<Name "New1">]
    static member New (el : Element, conf: PositionConfiguration): Position =
        let a = new Position()
        a.element <-
            el
            |>! OnAfterRender (fun el  ->
                PositionInternal.New(el.Body, conf)
            )
        a

    /// Creates a new position object given an element
    /// using the default configuration.
    [<JavaScript>]
    [<Name "New2">]
    static member New (el : Element) : Position =
        let conf = new PositionConfiguration()
        Position.New(el, conf)
