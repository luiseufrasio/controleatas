<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Inicio.aspx.cs" Inherits="_Default" %>

<%@ Register Src="componentes/Menu.ascx" TagName="Menu" TagPrefix="uc2" %>

<%@ Register Src="componentes/Topo.ascx" TagName="Topo" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
<!--

function DIV1_onclick() {

}

// -->
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <uc1:Topo ID="Topo1" runat="server" />
        <uc2:Menu ID="Menu1" runat="server" />
    </form>
</body>
</html>
