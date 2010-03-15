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
module Tests =
    open IntelliFactory.WebSharper.JQueryUI
    
    [<JavaScript>]
    let TestAccordian () =
        let els = 
            [
                "Foo", Div ["a1"]
                "Bar", Div ["a2"]
                "Baz", Div ["a3"]
            ]
        let acc = Accordion.Accordion.New(els, new Accordion.AccordionConfiguration())
        Div [els]
        
    

[<JavaScriptType>]
type Test() = 
    inherit Web.Control()

    [<JavaScript>]
    override this.Body =  Tests.TestAccordian ()
        
        
        

