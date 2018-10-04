// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2018 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}

//JQueryUI Wrapping: (version Stable 1.8rc1)
namespace WebSharper.JQueryUI.Tests

open WebSharper

[<JavaScript>]
module internal Client =

    open WebSharper.JavaScript
    open WebSharper.Html.Client
    open WebSharper.JQuery
    open WebSharper.JQueryUI

    let private Log (x: string) = Console.Log(x)

    let TestAccordion () =
        let els1 =
            [
                "Foo", Div [Tags.Button [Text "click"]]
                "Bar", Div [Text "Second content"]
                "Baz", Div [Text "Third content"]
            ]
        let acc1 = Accordion.New(els1)
        // Events
        acc1
        |> OnBeforeRender (fun _ ->
            Log "Acc1 - Before Render"
        )
        acc1
        |> OnAfterRender (fun _ ->
            Log "Acc1 - After Render"
        )
        acc1.OnActivate (fun _ _ ->
            Log "Acc1 - Activate"
        )
        let els2 =
            [
                "Foo", Div [acc1]
                "Bar", Div [Text "Second content"]
                "Baz", Div [Text "Third content"]
            ]
        let acc2 = Accordion.New(els2)

        // Events
        acc2.OnActivate (fun _ _ ->
            Log "Acc2 - Activate"
        )
        let button = JQueryUI.Button.New("Click")
        button.OnClick (fun _ ->
            acc2.Activate(2)
            acc1.Disable()
        )
        let button = JQueryUI.Button.New "Click"
        button.OnClick (fun _ ->
            acc2.Activate 1
        )
        Div [acc2] -< [button]

    let RunAutocompleter conf =
        let a = Autocomplete.New(Input [], conf)
        a |> OnBeforeRender (fun _ -> Log "Before Render")
        a |> OnAfterRender ( fun _ -> Log "After Render")
        a.OnChange (fun _ _ -> Log "Change")
        a.OnClose <| fun _ -> Log "Close"
        a.OnSearch <| fun _ -> Log "Search"
        a.OnFocus <| fun _ _ -> Log "Focus"

        let bClose = JQueryUI.Button.New "Close"
        bClose.OnClick (fun _ -> a.Close())

        let bDestroy = JQueryUI.Button.New "Destroy"
        bClose.OnClick (fun _ -> a.Destroy())

        Div [a] -< [
            bClose
            bDestroy
        ]

    let TestAutocomplete1 () =
        let conf = new AutocompleteConfiguration()
        conf.Source <- Listing [|"Apa"; "Beta"; "Zeta" ; "Zebra"|]
        RunAutocompleter conf

    let TestAutocomplete2 () =
        let conf = new AutocompleteConfiguration()
        let x : array<AutocompleteItem> =
            [|{Label = "test"; Value = "value"}|]
        conf.Source <- Items x
        RunAutocompleter conf

    let TestAutocomplete3 () =
        let conf = new AutocompleteConfiguration()
        let completef (_ : AutocompleteRequest, f : array<AutocompleteItem> -> unit) =
            let x : array<AutocompleteItem> =
                [|{Label = "test"; Value = "value"}|]
            f x
        conf.Source <- Callback completef
        RunAutocompleter conf

    let TestButton () =
        let b1 = JQueryUI.Button.New ("Click")
        b1 |> OnAfterRender(fun _ -> Log "After Render")
        b1 |> OnBeforeRender(fun _ -> Log "Before Render")
        b1.OnClick(fun ev -> Log "Click")
        let b2 = JQueryUI.Button.New "Click 2"
        b2.OnClick(fun ev ->
            b1.OnClick (fun ev -> Log "New CB")
            if b1.IsEnabled then
                b1.Disable()
            else
                b1.Enable()
        )
        Div [b1; b2]

    let TestDatepicker1 () =
        let conf = new DatepickerConfiguration()
        let dp = Datepicker.New(Input [], conf)
        dp |> OnAfterRender(fun _ -> Log "Dp After Render")
        dp |> OnBeforeRender(fun _ -> Log "Dp Before Render")
        Div [dp]

    let TestDatepicker2 () =
        let conf = new DatepickerConfiguration(AutoSize = true)
        let dp = Datepicker.New(Input [],conf)

        dp.OnClose(fun dt elem ->
            Log "Dp2 OnClose"
            Console.Log dt
            Console.Log elem
        )
        dp.OnSelect(fun dt elem ->
            Log "Dp2 OnSelect"
            Console.Log dt
            Console.Log elem
        )

        dp
        |> OnAfterRender (fun picker ->
            picker.Option("changeYear", true)
        )
        dp |> OnAfterRender(fun picker -> 
            Log "Dp2 After Render"
            Log (picker.Option("changeYear").ToString())
            Log (picker.Option("autoSize").ToString())
            Console.Log <| picker.Option()
        )
        dp |> OnBeforeRender(fun _ -> Log "Dp2 Before Render")
        Div [dp]

    let TestDatepicker3 () =
        let conf = 
            new DatepickerConfiguration(
                AutoSize = true,
                OnClose = (
                    fun dt ->
                        Log "Dp3 OnClose"
                        Console.Log dt),
                OnSelect = (
                    fun dt ->
                        Log "Dp3 OnSelect"
                        Console.Log dt)
            )
        let dp = Datepicker.New(Input [],conf)

        dp
        |> OnAfterRender (fun picker ->
            picker.Option("changeYear", true)
        )
        dp |> OnAfterRender(fun picker -> 
            Log "Dp3 After Render"
            Log (picker.Option("changeYear").ToString())
            Log (picker.Option("autoSize").ToString())
            Console.Log <| picker.Option()
        )
        dp |> OnBeforeRender(fun _ -> Log "Dp3 Before Render")
        Div [dp]


    let TestDraggable () =
        let d =
            Draggable.New(
                Div [
                    Style "width:200px;background:lightgray;text-align:center"
                    Text "Drag me!"
                ],
                DraggableConfiguration(Axis = "x"))
        Div [d]


    let TestDialog () =
        let conf = DialogConfiguration()
        conf.Buttons <- [|DialogButton(Text = "Ok", Click = fun d e -> d.Close())|]
        conf.AutoOpen <- false
        let d = Dialog.New(Div [Text "Dialog"], conf)
        d.OnClose(fun ev ->
            Log "close"
        )
        d |> OnAfterRender(fun _ -> Log "dialog: before render")
        d |> OnAfterRender(fun _ -> Log "dialog: after render")
        d.OnOpen(fun ev -> Log "dialog: open")
        d.OnClose(fun ev -> Log "dialog: close")
        d.OnResize(fun ev -> Log "dialog: resize")
        d.OnResizeStop(fun ev -> Log "dialog: resize stop")
        d.OnResizeStart(fun ev -> Log "dialog: resize start")
        d.OnFocus(fun ev -> Log "dialog: focus")
        d.OnDrag(fun ev -> Log "dialog: drag")
        d.OnDragStart(fun ev -> Log "dialog: drag start")
        d.OnDragStop(fun ev -> Log "dialog: drag stop")
        let bO = JQueryUI.Button.New ("open")
        bO.OnClick (fun ev -> d.Open())
        let bC = JQueryUI.Button.New "Close"
        bC.OnClick (fun ev -> d.Close())
        Div [d] -< [
            bO
            bC
        ]

    let TestProgressbar () =
        let conf = ProgressbarConfiguration()
        let p = Progressbar.New(Div [], conf)
        p |> OnAfterRender(fun _  ->
            p.Value <- 30
        )

        let b = JQueryUI.Button.New("inc")
        b.OnClick (fun ev ->
            p.Value <- p.Value + 10
        )
        Div [p :> Pagelet ; b :> _]


    let TestSlider () =
        let s = Slider.New()
        s |> OnBeforeRender(fun _ -> Log "slider: before render")
        s |> OnAfterRender(fun _  ->
            Log "slider: after render"
        )
        s.OnChange(fun ev ->
            Log "change"
        )
        let b = JQueryUI.Button.New("check")
        let pan = Div [s :> Pagelet ; b :> _]
        b.OnClick (fun ev ->
            let d = Dialog.New(Div [Text <| string s.Value])
            pan.Append(d)
        )
        pan

    let TestTabs () =
        let conf = new TabsConfiguration()
        let tabs =
            [
                "Tab 1",  Div [H1 [Text "Tab 1"]]
                "Tab 2",  Div [H1 [Text "Tab 2"]]
                "Tab 3" , Div [Text "R"]
            ]
        let t = Tabs.New(tabs, conf)
        t |> OnAfterRender(fun _ ->  Log "Aa" )



        let b = JQueryUI.Button.New("inc")
        b.OnClick (fun ev ->
            JQuery.Of(t.TabContainer.Body).Children().Eq(2).Click().Ignore
            t.Add( Div [H1 [Text "New tab"]], "Tab" + (string (t.Length + 1)))
        )
        Div [t :> Pagelet ; b :> _]

    let TestSortable () =
        let elem =
            List.init 6 (fun i ->
                Src ("http://www.look4design.co.uk/l4design/companies/designercurtains/image" + string (i+1) + ".jpg"))
            |> List.map (fun e -> LI [Img [e]])
            |> (-<) (UL [Style "list-style: none"])
        let sortable = Sortable.New elem
        Div [sortable]

    let TestWidget t w =
        Div [
            Style "border:solid 1px gray; padding:10px; margin-top: 10px"
            H1 [Text t ] :> _
            w
        ]
    [<Inline "jQuery(document)">]
    let Document () : Element = Unchecked.defaultof<_>()

    let TestPosition() =
        let position1Body =
            Div [Style "width:50px; height:50px; background-color:#F00;"]
        let targetBody =
            Div [Style "width:240px; height:200px; background-color:#999; margin:30px auto;"; Text "hej"]
            |>! OnAfterRender (fun el ->
                let conf1 = new PositionConfiguration()
                conf1.My <- "center"
                conf1.At <- "center"
                conf1.Of <- JQueryUI.Target.Element el.Dom
                conf1.Collision <- "fit"
                conf1.offset <- "10 -10"
                let p1 = Position.New(position1Body, conf1)
                ()
            )
        Div [
            position1Body
            targetBody
        ]

//        let position2Body =
//            Div [Style "width:50px; height:50px; background-color:#0F0;"]
//        let conf2 = new PositionConfiguration()
//        conf2.My <- "left top"
//        conf2.At <- "left top"
//        conf2.Of <- Target.Element targetBody.Dom
//        conf2.Collision <- "fit"
//        conf2.offset <- "10 -10"
//        let p2 = Position.New(position2Body, conf2)
//
//        let position3Body =
//            Div [Style "width:50px; height:50px; background-color:#00F;"]
//        let conf3 = new PositionConfiguration()
//        conf3.My <- "right center"
//        conf3.At <- "right bottom"
//        conf3.Of <- Target.Element targetBody.Dom
//        conf3.Collision <- "fit"
//        conf3.offset <- "10 -10"
//        let p3 = Position.New(position3Body, conf3)
//
//        let position4Body =
//            Div [Style "width:50px; height:50px; background-color:#FF0;"]
//        let conf4 = new PositionConfiguration()
//        conf4.My <- "left bottom"
//        conf4.At <- "center"
//        conf4.Of <- Target.Element targetBody.Dom
//        conf4.Collision <- "fit"
//        conf4.offset <- "10 -10"
//        let p4 = Position.New (position4Body, conf4)
//
//        Document()
//        |>! OnMouseMove (fun _ ev ->
//            let conf = new PositionConfiguration()
//            conf.My <- "left bottom"
//            conf.At <- "center"
//            conf.Of <- Target.Event ev
//            conf.Collision <- "fit"
//            conf.offset <- "10 -10"
//            Position.New (position4Body, conf)|>ignore)
//        |> ignore
//        Div [
//            targetBody
//            ]
//            -< [p1; p2; p3; p4 ]

    let TestResizable () =
        let img = Div [Style "background:url(http://www.look4design.co.uk/l4design/companies/light-iq/image14.jpg);height:100px;width:100px" ]
        let resizable = Resizable.New img
        resizable.OnStart  (fun _ _ -> Log("Started!"))
        resizable.OnResize (fun event ui ->
            if ui.Size.Width > 300 then
                ui.Size.Width <- 300
            if ui.Size.Height < 200  then
                ui.Size.Height <- 200
            Log("Resized!"))
        resizable.OnStop   (fun _ _ -> Log("Stopped!"))
        let drag = Draggable.New (Div [resizable])
        Div [drag]


    let Tests () =
        let tab =
            [
                "Accordion", TestAccordion ()
                "Autocomplete1", TestAutocomplete1 ()
                "Autocomplete2", TestAutocomplete2 ()
                "Autocomplete3", TestAutocomplete3 ()
                "Button", TestButton ()
                "Datepicker1", TestDatepicker1 ()
                "Datepicker2", TestDatepicker2 ()
                "Datepicker3", TestDatepicker3 ()
                "Draggable", TestDraggable ()
                "Dialog", TestDialog ()
                "Progressbar", TestProgressbar ()
                "Slider", TestSlider ()
                "Tabs", TestTabs ()
                "Sortable", TestSortable ()
                "Position", TestPosition ()
                "Resizable",  TestResizable ()
            ]
            |> Tabs.New
        Div [tab]

open WebSharper.Sitelets

type Action = | Index

module Site =

    [<Sealed>]
    type TestControl() =
        inherit Web.Control()

        [<JavaScript>]
        override this.Body =
            Client.Tests() :> _

    open WebSharper.Html.Server

    let HomePage ctx =
        Content.Page(
            Title = "WebSharper JQueryUI Tests",
            Body = [Div [new TestControl()]]
        )

    let Main = Sitelet.Content "/" Index HomePage

[<Sealed>]
type Website() =
    interface IWebsite<Action> with
        member this.Sitelet = Site.Main
        member this.Actions = [Action.Index]

[<assembly: Website(typeof<Website>)>]
do ()
