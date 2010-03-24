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
    let L x = JavaScript.console.log x

    [<JavaScript>]
    let B (l: string) f = 
        Tags.Button [l]
        |> On Events.Click (fun _ ev ->
            ev.PreventDefault()
            f ()
        )

    [<JavaScript>]
    let TestAccordian () =
        let els1 = 
            [
                "Foo", Div [Tags.Button ["click"]]
                "Bar", Div ["Second content"]
                "Baz", Div ["Third content"]
            ]
        let acc1 = Accordion.New(els1)
        // Events
        acc1.OnBeforeRender <| fun () -> L "Acc1 - Before Render" 
        acc1.OnAfterRender <| fun () -> L "Acc1 - After Render" 
        acc1.OnChange <| fun () -> L "Acc1 - Change"        
        
        let els2 = 
            [
                "Foo", Div [acc1.Element]
                "Bar", Div ["Second content"]
                "Baz", Div ["Third content"]
            ]

        let acc2 = Accordion.New(els2)
        // Events
        acc2.OnBeforeRender <| fun () -> L "Acc2 - Before Render" 
        acc2.OnAfterRender <| fun () -> L "Acc2 - After Render" 
        acc2.OnChange <| fun () -> L "Acc2 - Change"    
                
        let button =
            B "Click" <| fun () ->
                acc2.Activate(2)
                acc1.Disable()
        Div [acc2.Element; button]
        
    [<JavaScript>]
    let TestAutocomplete () =
        let conf = new AutocompleteConfiguration()
        conf.Source <- [|"Apa"; "Beta"; "Zeta" ; "Zebra"|]
        let a = Autocomplete.New(Input [], conf)
        a.OnBeforeRender <| fun () -> L "Before Render"
        a.OnAfterRender <| fun () -> 
            L "After Render"
            a.Search "Z"
        
        a.OnChange <| fun () -> L "Change"
        a.OnClose <| fun () -> L "Close"
        a.OnSearch <| fun () -> L "Search"
        a.OnFocus <| fun () -> L "Focus"

        let bClose = 
            B "Close" <| fun () -> a.Close()         
        let bDestroy =
            B "Destroy" <| fun () -> a.Destroy()         

        Div [
            a.Element
            bClose
            bDestroy
        ]

    [<JavaScript>]
    let TestButton () =
        let b1 = Button.New ("Click")
        b1.OnAfterRender(fun () -> L "After Render")
        b1.OnBeforeRender(fun () -> L "Before Render")
        b1.OnClick(fun () -> L "Click")
        let b2 = Button.New "Click 2"
        b2.OnClick(fun () ->
            b1.OnClick (fun () -> L "New CB")
            if b1.IsEnabled then
                b1.Disable()
            else
                b1.Enable()
        )
        Div [b1.Element; b2.Element]

    [<JavaScript>]
    let TestDatepicker () =
        let conf = new DatepickerConfiguration()
        conf.NextText <- "NNNNNExt"
        let dp = Datepicker.New(Input [], conf)        
        dp.OnSelect(fun d -> L d)       
        dp.OnAfterRender(fun () -> L "Dp After Render")
        dp.OnBeforeRender(fun () -> L "Dp Before Render")                        
        dp.Element

    [<JavaScript>]
    let TestDialog () =
        let conf =DialogConfiguration()
        conf.Buttons <- "Buttons"
        let d = Dialog.New(Div ["Dialog"], conf)    
        d.OnClose(fun () ->
            Native.Window.Alert "close"
        )                  
        d.OnAfterRender(fun () -> L "dialog: before render")
        d.OnAfterRender(fun () -> L "dialog: after render")
        d.OnOpen(fun () -> L "dialog: open")
        d.OnClose(fun () -> L "dialog: close")
        d.OnResize(fun () -> L "dialog: resize")
        d.OnResizeStop(fun () -> L "dialog: resize stop")
        d.OnResizeStart(fun () -> L "dialog: resize start")
        d.OnFocus(fun () -> L "dialog: focus")
        d.OnDrag(fun () -> L "dialog: drag")
        d.OnDragStart(fun () -> L "dialog: drag start")
        d.OnDragStop(fun () -> L "dialog: drag stop")
        let bO = Button.New ("open")
        bO.OnClick (fun () -> d.Open())
        let bC = Button.New "Close"
        bC.OnClick (fun () -> d.Close())
        Div [        
            d.Element
            bO.Element
            bC.Element
        ]

    [<JavaScript>]
    let TestProgressbar () =        
        let conf = ProgressbarConfiguration()
        let p = Progressbar.New(Div [], conf)
        p.OnBeforeRender(fun () -> L "pb: after render")
        p.OnAfterRender(fun ()  -> 
            p.Value <- 10
            L "pb: after render"
        )
        
        let b = Button.New("inc")
        b.OnClick (fun () ->
            p.Value <- p.Value + 10
        )
        Div [p.Element; b.Element]


    [<JavaScript>]
    let TestSlider () =                
        let s = Slider.New()
        s.OnBeforeRender(fun () -> L "slider: before render")
        s.OnAfterRender(fun ()  -> 
            // s.Value <- 10
            L "slider: after render"
        )
        s.OnChange(fun () ->
            L "change"
            // L (string s.Value)
        )
        let b = Button.New("inc")
        let pan = Div [s.Element; b.Element]
        b.OnClick (fun () ->          
            let d = Dialog.New(Div [string s.Value]) 
            pan.Append(d.Element)
        )        
        pan

    [<JavaScript>]
    let TestTabs () =                
        let conf = new TabsConfiguration()
        let tabs =
            [
                "Tab 1",  Div [H1 ["Tab 1"]]
                "Tab 2",  Div [H1 ["Tab 2"]]
                "Tab 3",  Div [H1 ["Tab 3"]]
            ]
        let t = Tabs.New(tabs, conf)
        t.OnBeforeRender(fun () -> L "tabs: before render")
        t.OnAfterRender(fun ()  -> 
            // s.Value <- 10
            L "tabs: after render"            
        )

        let b = Button.New("inc")
        b.OnClick (fun () ->          
            t.Activate 2
            t.Add( Div [H1 ["New tab"]], "tab" + (string t.Length))
        )        
        Div [t.Element; b.Element]
    
    [<JavaScript>]
    let TestSortable () =
        let list =
            UL [
                LI ["Item 1"]
                LI ["Item 2"]
                LI ["Item 3"]
            ]
        let s = Sortable.New(list, new SortableConfiguration())
        s.OnBeforeRender (fun () -> L "sortable: before render")
        s.OnAfterRender( fun () ->
            L "sortable: after render"
        )
        s.OnSort( fun () -> L "sort")
        s.OnChange(fun () -> L "change")
        s.Element




    [<JavaScript>]
    let TestWidget t w =
        Div [StyleAttribute "border:solid 1px gray; padding:10px; margin-top: 10px"] -< [
            H1 [Text t ]
            w
        ]
    
    [<JavaScript>]
    let Tests =
        let xs =
            [
                "Accordion", TestAccordian ()
                "Autocomplete", TestAutocomplete ()     
                "Button", TestButton () 
                "Datepicker", TestDatepicker ()    
                "Dialog", TestDialog ()
                "Progressbar", TestProgressbar ()
                "Slider", TestSlider ()
                "Tabs", TestTabs ()
                "Sortable", TestSortable ()
            ]
            |> List.map (fun (t, w) -> TestWidget t w)
        Div xs
                                           
[<JavaScriptType>]
type Test() = 
    inherit Web.Control()

    [<JavaScript>]
    override this.Body = Tests.Tests
        
        

