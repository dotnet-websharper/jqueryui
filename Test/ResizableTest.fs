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
module ResizableInternal =

    open IntelliFactory.WebSharper.JQueryUI

    [<JavaScript>]
    let ResizDragImg () =
        let img = Img [Src "http://www.look4design.co.uk/l4design/companies/light-iq/image14.jpg" ]
        let resizable = Resizable.New img
        resizable.OnStart  (fun _ _ -> JavaScript.console.log("Started!"))
        resizable.OnResize (fun _ _ -> JavaScript.console.log("Resized!"))
        resizable.OnStop   (fun _ _ -> JavaScript.console.log("Stopped!"))
        let drag = Draggable.New (Div [resizable.Element])
        drag.Element

[<JavaScriptType>]
type ResizableTest() = 
    inherit Web.Control()

    [<JavaScript>]
    override this.Body = ResizableInternal.ResizDragImg()
