# WebSharper.JQueryUI Usage

This document explains the main points in using WebSharper.JQueryUI
and how it differs from the JavaScript library. You can also check
[some examples](Examples.md).

The original library, jQuery UI, works by doing a jQuery selection on
an element and calling the relevant widget constructor as an instance
member, for example:

```javascript
$("#datepicker").datepicker();
```

In the jQuery UI binding for WebSharper™ widgets like `Datepicker` are
represented as types.  To create the corresponding `Datepicker` widget
with WebSharper™ you write:

```fsharp
let datePicker = Datepicker.New()
```

The `datePicker` object now contains the available methods.  For
example, to call the `getDate` methods you use:

```fsharp
let date = datePicker.GetDate()
```

## Resource Dependencies

Using the JQuery UI WebSharper™ extension within a WebControl will automatically
include the required JavaScript and Css resources.

You may override the location of the fetched resources by modifying the `app settings`
in in your `web.config` file.

There are two configurable values: One for the root folder of the JavaScript files and
another one for the root folder of the Css files. Here is an example of how to override 
both settings.

```xml
<appSettings>
  <add key="IntelliFactory.WebSharper.JQueryUI" value="scripts/jquery-ui" />
  <add key="IntelliFactory.WebSharper.JQueryUICss" value="css/jquery-ui" />
</appSettings>
```

If you want to serve the resource files locally you need to make sure to you use the same
naming conventions as used by the online repository.


## Constructors

Constructor functions are provided for all `Widgets` and `Effects`.
There are typically a few options for constructing Widgets depending
on the desired configuration.

In the original jQuery UI library configuration settings are usually
passed as a JavaScript object.  For example, a calendar may be
initialized in a disabled state by passing a configuration setting to
the constructor function:

```javascript
$("#datepicker").datepicker({{ disabled: true }});
```

In WebSharper™ configuration settings for any widget are represented
by a corresponding configuration type and may be passed to the
constructors as parameters:

```fsharp
let conf = DatepickerConfiguration(Disabled = true)
let datePicker = Datepicker.New(conf)
```

## Methods

jQuery UI methods are represented as member methods on the objects returned when
creating a widget.  Typically the widget and effect objects contain
some common methods like `destroy`, `enable`, `disable`, and `option`.

For example, the `Datepicker` widget has a method for setting the
date. The JavaScript snippet for this may look like:

```javascript
$("#datepicker").datepicker("setDate", "03/14/2010");
```

The WebSharper™ bindings contain (possibly overloaded) methods with
corresponding names:

```fsharp
datePicker.SetDate(new Date(2010,03,14))
```


## Warning about Initialization

The fundamental difference between original jQuery UI JavaScript
widgets and their WebSharper™ counterparts is that in JavaScript the
constructor methods are typically called on elements already attached
to the DOM tree.  For example, in order for the following code to
work:

```javascript
$(selector).datepicker();
```

the selector needs to refer to an element already attached to the
page.

In WebSharper™ you normally do not work with inserted nodes,
so whenever you call constructor method such as:

```fsharp
Datepicker.New()
```

the actual initialization of the internal element is delayed until
this node is rendered to the page.

Therefore caution needs to be taken when using widget objects.  If the
widget is not yet rendered, some instance member calls may result in
runtime errors.

For example, the following code:

```fsharp
let datePicker = Datepicker.New()
datePicker.SetDate(new Date(2010,3,14))
```

will not work since the call to `SetDate` assumes that the
`datePicker` object is rendered.

Since all widgets implement the `IPagelet` interface you may use the
`OnAfterRender` function to accomodate for this.

You may rewrite the code above using the `OnAfterRender` as in:

```fsharp
DatePicker.New() 
|> OnAfterRender(fun datePicker -> 
    datePicker.SetDate(new Date(2010,3,14))
)
```


## Events

jQuery UI widgets allow to add event handlers to widgets. For example,
the `Datepicker` widget supports the `onSelect` event:

```javascript
$("#datepicker").datepicker({
   onSelect: function(dateText, inst) { ... }
});
```

In the WebSharper™ binding Events are also represented as
functions. To add an event handler for a Datepicker objects you use:

```fsharp
datePicker.OnSelect (fun date -> ...)
```

The `OnSelect` function accepts a callback function of type
`JavaScript.Date -> unit`.  The signatures of the callback functions
differ slightly from their JavaScript counterparts.  For example, the
JavaScript callback function may accept two arguments, with the second
one representing a reference to the `datePicker` object and the date
is passed as a string rather than a `DateTime` object.

In contrast with other method invocations, events may be applied to
objects that has not yet been initialized (rendered).  If an event is
attached to a non initialized object it is implicitly delayed until
the rendering of the object. Therefore the following code is
perfectly valid:

```fsharp
let datePicker = DatePicker.New() 
datePicker.OnSelect(fun date -> ...)
```
