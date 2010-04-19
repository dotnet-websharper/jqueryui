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
    let L x = JConsole.Log(x)

    [<JavaScript>]
    let B (l: string) f = 
        Tag.Button [Text l]
        |>! OnClick (fun _ ev ->
            ev.PreventDefault()
            f ()
        )

    [<JavaScript>]
    let TestAccordian () =
        let els1 = 
            [
                "Foo", Div [Tag.Button [Text "click"]]
                "Bar", Div [Text "Second content"]
                "Baz", Div [Text "Third content"]
            ]
        let acc1 = Accordion.New(els1)
        // Events
        acc1
        |> OnBeforeRender (fun _ -> 
            JConsole.Log "Acc1 - Before Render"
        )        
        acc1
        |> OnAfterRender (fun _ -> 
            JConsole.Log "Acc1 - After Render" 
        )
//        acc1.OnChange (fun _ _ -> 
//            JConsole.Log "Acc1 - Change"
//        )
        acc1.Element

//        let els2 = 
//            [
//                "Foo", Div [acc1.Element]
//                "Bar", Div [Text "Second content"]
//                "Baz", Div [Text "Third content"]
//            ]
//        let acc2 = Accordion.New(els2)
//        // Events
//        acc2.OnChange (fun _ _ -> 
//            JConsole.Log "Acc2 - Change"
//        )
//                
//        let button =
//            B "Click" <| fun () ->
//                acc2.Activate(2)
//                acc1.Disable()
//        Div [acc2.Element; button]
        
    [<JavaScript>]
    let TestAutocomplete () =
        let conf = new AutocompleteConfiguration()
        conf.Source <- [|"Apa"; "Beta"; "Zeta" ; "Zebra"|]
        let a = Autocomplete.New(Input [], conf)
        a |> OnBeforeRender (fun _ -> JConsole.Log "Before Render")
        a |> OnAfterRender ( fun _ -> 
            JConsole.Log "After Render"
            a.Search "Z"
        )
        
        a.OnChange (fun _ _ -> JConsole.Log "Change")
        a.OnClose <| fun _ _ -> JConsole.Log "Close"
        a.OnSearch <| fun _ _ -> JConsole.Log "Search"
        a.OnFocus <| fun _ _ -> JConsole.Log "Focus"

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
        b1 |> OnAfterRender(fun _ -> JConsole.Log "After Render")
        b1 |> OnBeforeRender(fun _ -> JConsole.Log "Before Render")
        b1.OnClick(fun ev -> JConsole.Log "Click")
        let b2 = Button.New "Click 2"
        b2.OnClick(fun ev ->
            b1.OnClick (fun ev -> JConsole.Log "New CB")
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
        // dp.OnSelect(fun d -> JConsole.Log d)       
        dp |> OnAfterRender(fun _ -> JConsole.Log "Dp After Render")
        dp |> OnBeforeRender(fun _ -> JConsole.Log "Dp Before Render")
        Div [dp]

    [<JavaScript>]
    let TestDialog () =
        let conf =DialogConfiguration()
        conf.Buttons <- "Buttons"
        let d = Dialog.New(Div [Text "Dialog"], conf)    
        d.OnClose(fun ev ->
            Window.Alert "close"
        )                  
        d |> OnAfterRender(fun _ -> JConsole.Log "dialog: before render")
        d |> OnAfterRender(fun _ -> JConsole.Log "dialog: after render")
        d.OnOpen(fun ev -> JConsole.Log "dialog: open")
        d.OnClose(fun ev -> JConsole.Log "dialog: close")
        d.OnResize(fun ev -> JConsole.Log "dialog: resize")
        d.OnResizeStop(fun ev -> JConsole.Log "dialog: resize stop")
        d.OnResizeStart(fun ev -> JConsole.Log "dialog: resize start")
        d.OnFocus(fun ev -> JConsole.Log "dialog: focus")
        d.OnDrag(fun ev -> JConsole.Log "dialog: drag")
        d.OnDragStart(fun ev -> JConsole.Log "dialog: drag start")
        d.OnDragStop(fun ev -> JConsole.Log "dialog: drag stop")
        let bO = Button.New ("open")
        bO.OnClick (fun ev -> d.Open())
        let bC = Button.New "Close"
        bC.OnClick (fun ev -> d.Close())
        Div [        
            d.Element
            bO.Element
            bC.Element
        ]

    [<JavaScript>]
    let TestProgressbar () =        
        let conf = ProgressbarConfiguration()
        let p = Progressbar.New(Div [], conf)
        p |> OnAfterRender(fun _ -> JConsole.Log "pb: after render")
        p |> OnBeforeRender(fun _  -> 
            p.Value <- 10
            JConsole.Log "pb: after render"
        )
        
        let b = Button.New("inc")
        b.OnClick (fun ev ->
            p.Value <- p.Value + 10
        )
        Div [p.Element; b.Element]


    [<JavaScript>]
    let TestSlider () =                
        let s = Slider.New()
        s |> OnBeforeRender(fun _ -> JConsole.Log "slider: before render")
        s |> OnAfterRender(fun _  -> 
            // s.Value <- 10
            JConsole.Log "slider: after render"
        )
        s.OnChange(fun ev ->
            JConsole.Log "change"
            // L (string s.Value)
        )
        let b = Button.New("inc")
        let pan = Div [s.Element; b.Element]
        b.OnClick (fun ev ->          
            let d = Dialog.New(Div [Text <| string s.Value]) 
            pan.Append(d.Element)
        )        
        pan

    [<JavaScript>]
    let TestTabs () =                
        let conf = new TabsConfiguration()
        let tabs =
            [
                "Tab 1",  Div [H1 [Text "Tab 1"]]
                "Tab 2",  Div [H1 [Text "Tab 2"]]
                "Tab 3",  Div [H1 [Text "Tab 3"]]
            ]
        let t = Tabs.New(tabs, conf)
        t |> OnAfterRender(fun _ -> JConsole.Log "tabs: before render")
        t |> OnAfterRender(fun _  -> 
            // s.Value <- 10
            JConsole.Log "tabs: after render"            
        )

        let b = Button.New("inc")
        b.OnClick (fun ev ->          
            t.Activate 2
            t.Add( Div [H1 [Text "New tab"]], "tab" + (string t.Length))
        )        
        Div [t.Element; b.Element]
    
    [<JavaScript>]
    let TestSortable () =
        let list =
            UL [
                LI [Text "Item 1"]
                LI [Text "Item 2"]
                LI [Text "Item 3"]
            ]
        let s = Sortable.New(list, new SortableConfiguration())
        s |> OnBeforeRender (fun _ -> JConsole.Log "sortable: before render")
        s |> OnAfterRender (fun _->
            JConsole.Log "sortable: after render"
        )
        s.OnSort( fun _ _ -> JConsole.Log "sort")
        s.OnChange(fun _ _ -> JConsole.Log "change")
        s.Element




    [<JavaScript>]
    let TestWidget t w =
        Div [Style "border:solid 1px gray; padding:10px; margin-top: 10px"] -< [
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
        
        

