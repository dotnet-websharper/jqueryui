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
        let b = 
            Button ["click"]
            |> On Events.Attach (fun _ _ -> Native.Window.Alert "attach")
        let els1 = 
            [
                "Foo", Div [b]
                "Bar", Div ["Second content"]
                "Baz", Div ["Third content"]
            ]
        let acc1 = Accordion.Accordion.New(els1 , new Accordion.AccordionConfiguration())
        let els2 = 
            [
                "Foo", Div [acc1.Element]
                "Bar", Div ["Second content"]
                "Baz", Div ["Third content"]
            ]        
        
        acc1.Enable()
        acc1.Disable() 
        acc1.Enable()       
        acc1.Activate(2)

        let acc2 = Accordion.Accordion.New(els2, new Accordion.AccordionConfiguration())
                
        let b =
            Button ["click"]
            |> On Events.Click (fun _ ev ->
                ev.PreventDefault()
                acc2.Activate(2)
                acc1.Disable()
                acc1.Init()
                acc2.Init()

            )            
        Div [acc2.Element; b]
        
        
        


[<JavaScriptType>]
type Test() = 
    inherit Web.Control()

    [<JavaScript>]
    override this.Body =  Tests.TestAccordian ()
        
        
        

