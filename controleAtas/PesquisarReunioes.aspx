<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PesquisarReunioes.aspx.cs"
    Inherits="PesqCatDica" %>

<%@ Register Src="componentes/Calendario.ascx" TagName="Calendario" TagPrefix="uc3" %>
<%@ Register Src="componentes/Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<%@ Register Src="componentes/Topo.ascx" TagName="Topo" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pesquisa de Reuniões</title>
    <link href="css/Geral.css" rel="stylesheet" type="text/css" />
    <link href="/Style/Style1.css" rel="stylesheet" type="text/css" />
    <link href="/Style/Style1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="BtBusca" defaultfocus="TextBox1">
        <fieldset id="Fieldset1" class="fieldset" runat="server" align="middle" style="z-index: 100;
            left: 21%; position: absolute; top: 9%; width: 552px; height: 366px;" hidefocus="hideFocus"
            unselectable="on">
            <legend class="legend">Reuniões no período entre:</legend>
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" GridLines="None"
                    Style="z-index: 100; left: 2%; position: absolute; top: 20%;" AllowPaging="True"
                    OnPageIndexChanging="GridView1_PageIndexChanging" CellSpacing="1" Width="535px"
                    TabIndex="3" OnRowDataBound="GridView1_RowDataBound">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" />
                        <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="reunioes.aspx?cod={0}"
                            DataTextField="data" HeaderText="Data" />
                        <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="reunioes.aspx?cod={0}"
                            DataTextField="assunto" HeaderText="Assunto" />
                        <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="reunioes.aspx?cod={0}"
                            DataTextField="local" HeaderText="Local" />
                    </Columns>
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                </asp:GridView>
                &nbsp;
                <asp:Button ID="BtBusca" runat="server" Style="z-index: 101; left: 84%; position: absolute;
                    top: 12%" Text="Buscar" OnClick="BtBusca_Click" Width="80px" Height="20px" CssClass="button"
                    TabIndex="2" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Style="z-index: 102; left: 2%; position: absolute;
                    top: 7%" Text="Data Inicial:"></asp:Label>
                &nbsp;
                <asp:Label ID="Label2" runat="server" Style="z-index: 104; left: 27%; position: absolute;
                    top: 7%" Text="Data Final:"></asp:Label>
                <uc3:Calendario ID="dtInicio" left="10" top="45" runat="server" />
                <uc3:Calendario ID="dtFim" left="148" top="45" runat="server" />
            </div>
        </fieldset>
        <uc1:Menu ID="Menu1" runat="server" />
        <uc2:Topo ID="Topo1" runat="server" />
    </form>
</body>
</html>
