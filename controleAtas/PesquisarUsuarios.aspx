<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PesquisarUsuarios.aspx.cs"
    Inherits="PesqCatDica" %>

<%@ Register Src="componentes/Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<%@ Register Src="componentes/Topo.ascx" TagName="Topo" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pesquisa de Usuários</title>
    <link href="css/Geral.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="BtBusca" defaultfocus="TextBox1">
        <fieldset id="Fieldset1" class="fieldset" runat="server" align="middle" style="z-index: 100;
            left: 21%; position: absolute; top: 9%; width: 552px; height: 396px;" hidefocus="hideFocus"
            unselectable="on">
            <legend class="legend">Usuários</legend>
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" GridLines="None"
                    Style="z-index: 100; left: 2%; position: absolute; top: 20%;" AllowPaging="True"
                    OnPageIndexChanging="GridView1_PageIndexChanging" CellSpacing="1" Width="535px"
                    TabIndex="3">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" />
                        <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="usuarios.aspx?cod={0}"
                            DataTextField="nome" HeaderText="Nome" />
                        <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="usuarios.aspx?cod={0}"
                            DataTextField="email" HeaderText="E-mail" />
                        <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="usuarios.aspx?cod={0}"
                            DataTextField="admin" HeaderText="Administrador" />
                    </Columns>
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                </asp:GridView>
                <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 100; left: 2%; position: absolute;
                    top: 13%" CssClass="text" Width="274px" TabIndex="1"></asp:TextBox>
                <asp:Button ID="BtBusca" runat="server" Style="z-index: 101; left: 53%; position: absolute;
                    top: 13%" Text="Buscar" OnClick="BtBusca_Click" Height="20px" CssClass="button"
                    TabIndex="2" />
                <asp:Label ID="lbdesc" runat="server" Style="z-index: 103; left: 2%; position: absolute;
                    top: 9%" Text="Nome:" CssClass="label_bold"></asp:Label>
                &nbsp;
            </div>
        </fieldset>
        <uc1:Menu ID="Menu1" runat="server" />
        <uc2:Topo ID="Topo1" runat="server" />
    </form>
</body>
</html>
