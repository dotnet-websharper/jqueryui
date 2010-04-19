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
module DemoInternal =

    open IntelliFactory.WebSharper.JQueryUI

    [<JavaScript>]
    let Dialog () =
        let button = Button.New "Open"        
        let pan = Div [button.Element]
        button.OnClick (fun ev ->            
            let dialog = Dialog.New(H1 [Text "Dialog"])
            pan.Append(dialog.Element)
            dialog.OnClose(fun ev ->
                button.Enable()
            )
            button.Disable()
        )
        pan
    
    [<JavaScript>]
    let Accordion () =
        let accElems =
            [
                "Panel 1", H1 [Text "Panel 1"]
                "Panel 2", H1 [Text "Panel 2"]
                "Panel 3", H1 [Text "Panel 3"]
            ]
        let accordion = Accordion.New(accElems)
        accordion.Element

    [<JavaScript>]
    let Slider () =
        let slider = Slider.New()
        let selVal = Label []
        slider.OnChange(fun ev ->
            selVal.Text <- string slider.Value + "%"
        )
        Div [
            Div [
                Label [Text "Selected Value: "]
                selVal
            ]
            slider.Element
        ]

    [<JavaScript>]
    let Date () =
        let datepicker = Datepicker.New()
        let selDate = Label []
        datepicker.OnSelect (fun dt ->
            selDate.Text <- dt.ToLocaleDateString()
        )
        Div [
            Div [Label [Text "Selected date:"]; selDate]
        ]
                    
    [<JavaScript>]
    let Main () =
        let tabElems =
            [
                "Dialog", Dialog ()
                "Accordion", Accordion ()
                "Datepicker", Date ()
                "Slider", Slider ()
            ]
        let tabsConf = new TabsConfiguration()
        let tabs = Tabs.New(tabElems, new TabsConfiguration())
        Div [Style "width:500px"] -< [tabs.Element]

[<JavaScriptType>]
type Demo() = 
    inherit Web.Control()

    [<JavaScript>]
    override this.Body = 
        DemoInternal.Accordion()