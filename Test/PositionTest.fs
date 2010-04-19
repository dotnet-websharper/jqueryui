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
namespace IntelliFactory.WebSharper.JQueryUI.Test

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html


[<JavaScriptType>]
module PositionInternal =

    open IntelliFactory.WebSharper.JQueryUI

    [<Inline "jQuery(document)">]
    let Document () : Element = Unchecked.defaultof<_>()

    [<JavaScript>]
    let PositionTestCont() =
        let targetBody = Div [Style "width:240px; height:200px; background-color:#999; margin:30px auto;"]

        let position1Body = 
            Div [Style "width:50px; height:50px; background-color:#F00;"]
        let conf1 = new PositionConfiguration()
        conf1.My <- "center" 
        conf1.At <- "center"
        conf1.Of <- Target.Element targetBody
        conf1.Collision <- "fit"
        conf1.offset <- "10 -10"
        let p1 = Position.New(position1Body, conf1)

        let position2Body =  
            Div [Style "width:50px; height:50px; background-color:#0F0;"]
        let conf2 = new PositionConfiguration()
        conf2.My <- "left top" 
        conf2.At <- "left top"
        conf2.Of <- Target.Element targetBody
        conf2.Collision <- "fit"
        conf2.offset <- "10 -10"
        let p2 = Position.New(position2Body, conf2)

        let position3Body = 
            Div [Style "width:50px; height:50px; background-color:#00F;"]
        let conf3 = new PositionConfiguration()
        conf3.My <- "right center" 
        conf3.At <- "right bottom"
        conf3.Of <- Target.Element targetBody
        conf3.Collision <- "fit"
        conf3.offset <- "10 -10"
        let p3 = Position.New(position3Body, conf3)

        let position4Body =
            Div [Style "width:50px; height:50px; background-color:#FF0;"]
        let conf4 = new PositionConfiguration()
        conf4.My <- "left bottom" 
        conf4.At <- "center"
        conf4.Of <- Target.Element targetBody
        conf4.Collision <- "fit"
        conf4.offset <- "10 -10"
        let p4 = Position.New (position4Body, conf4)

        Document()
        |>! OnMouseMove (fun _ ev ->
            let conf = new PositionConfiguration()
            conf.My <- "left bottom" 
            conf.At <- "center"
            conf.Of <- Target.Event ev
            conf.Collision <- "fit"
            conf.offset <- "10 -10"
            Position.New (position4Body, conf)|>ignore)
        |> ignore

        Div [
            targetBody
            p1.Element
            p2.Element
            p3.Element
            p4.Element
        ]
            

[<JavaScriptType>]
type PositionTest() = 
    inherit Web.Control()

    [<JavaScript>]
    override this.Body = PositionInternal.PositionTestCont()

