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
module SortableInternal =

    open IntelliFactory.WebSharper.JQueryUI

    [<JavaScript>]
    let SortableElem () =
        let elem =
            List.init 6 (fun i ->
                Src ("http://www.look4design.co.uk/l4design/companies/designercurtains/image" + string (i+1) + ".jpg"))
            |> List.map (fun e -> LI [Img [e]])
            |> UL
        let sortable = Sortable.New elem
        sortable.Element

(* Demo2 *
    [<JavaScript>]
    let SelectableElem () =       
        let elem =
            UL [
                LI [Text "Item 1"]
                LI [Text "Item 2"]
                LI [Text "Item 3"]
                LI [Text "Item 4"]
                LI [Text "Item 5"]
               ]
        let selectable = Selectable.New elem
        selectable.Selected (fun _ el ->
            el.["style"] <- "background: gray")
        selectable.Unselected (fun _ el ->
            el.["style"] <- "background: white")
        selectable.Selecting (fun _ el ->
            el.["style"] <- "background: red")
        selectable.Unselecting (fun _ el ->
            el.["style"] <- "background: yellow")
        selectable.Element
*)

[<JavaScriptType>]
type SortableTest() = 
    inherit Web.Control()

    [<JavaScript>]
    override this.Body = SortableInternal.SortableElem()
