<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <WebSharper:ScriptManager runat="server"></WebSharper:ScriptManager>
<%--    <link type="text/css" href="http://jqueryui.com/latest/themes/base/jquery.ui.all.css" rel="stylesheet" />
    <script type="text/javascript" src="http://jqueryui.com/latest/jquery-1.4.2.js"></script>
    <script type="text/javascript" src="http://jquery-ui.googlecode.com/svn/tags/1.8rc1/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="http://jquery-ui.googlecode.com/svn/tags/1.8rc1/ui/jquery-ui.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<test:Test runat="server"></test:Test>--%>
        <test:Demo ID="Test1" runat="server"></test:Demo>
        
    </div>
    </form>
</body>
</html>
