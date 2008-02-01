<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AtaReuniao.aspx.cs" Inherits="AtaReuniao"
    ValidateRequest="false" %>

<%@ Register Src="componentes/Topo.ascx" TagName="Topo" TagPrefix="uc1" %>
<%@ Register Src="componentes/Menu.ascx" TagName="Menu" TagPrefix="uc2" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ata de Reunião</title>
    <link href="css/Geral.css" rel="stylesheet" type="text/css" />
    <link href="/Style/Style1.css" rel="stylesheet" type="text/css" />
    <link href="/Style/Style1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <fieldset id="Fieldset1" class="fieldset" runat="server" align="middle" style="z-index: 100;
            left: 21%; position: absolute; top: 9%; width: 71.5%; height: 21%;" hidefocus="hideFocus"
            unselectable="on">
            <legend class="legend">Ata da Reunião</legend>
            <CE:Editor ID="Editor2" runat="server" AutoConfigure="None" Style="z-index: 103;
                left: 1%; position: absolute; top: 20%; width: 98%; height: 80%" 
                BackColor="White" BorderColor="White" ShowDecreaseButton="False" ShowEditMode="False"
                ShowEnlargeButton="False" ShowHtmlMode="False" AllowEditServerSideCode="True"
                ReadOnly="True" ShowBottomBar="False" ShowCodeViewToolBar="False" ShowGroupMenuImage="False"
                ShowTagSelector="False" ShowToolBar="False">
                <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                    CssClass="CuteEditorFrame" Height="100%" Width="100%" />
            </CE:Editor>
        </fieldset>
        <div>
            <CE:Editor ID="Editor1" runat="server" Style="z-index: 103; left: 21%; position: absolute;
                top: 31%; width: 73%" ShowHtmlMode="False" ShowTagSelector="False" AllowEditServerSideCode="True"
                AutoConfigure="Minimal" Text="" OnPostBackCommand="salvar" Focus="True">
                <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                    CssClass="CuteEditorFrame" Height="100%" Width="100%" />
            </CE:Editor>
        </div>
        <uc1:Topo ID="Topo1" runat="server" />
        <uc2:Menu ID="Menu1" runat="server" />
    </form>
</body>
</html>
