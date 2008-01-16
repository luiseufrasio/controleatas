<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reunioes.aspx.cs" Inherits="ManutencaoOrcamento" %>

<%@ Register Src="componentes/Calendario.ascx" TagName="Calendario" TagPrefix="uc3" %>

<%@ Register Src="componentes/Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<%@ Register Src="componentes/Topo.ascx" TagName="Topo" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema de Controle de Atas de Reunião</title>
    <link href="css/Geral.css" rel="stylesheet" type="text/css" />
    <link href="/Style/Style1.css" rel="stylesheet" type="text/css" />
    <link href="/Style/Style1.css" rel="stylesheet" type="text/css" />
    <link href="/Style/Style1.css" rel="stylesheet" type="text/css" />
    <link href="/Style/Style1.css" rel="stylesheet" type="text/css" />
    <link href="/Style/Style1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="Button7" defaultfocus="txtNome">
        <fieldset id="Fieldset1" class="fieldset" runat="server" align="middle" style="z-index: 100;
            left: 21%; position: absolute; top: 9%; width: 554px; height: 469px;" hidefocus="hideFocus"
            unselectable="on">
            <legend class="legend">Cadastro de Reuniões</legend>
            <div>
                &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <div style="z-index: 112; left: 2%; width: 358px; position: absolute; top: 87%; height: 41px">
                    <asp:Button ID="Button5" runat="server" CssClass="button" Style="z-index: 100; left: 0%;
                        position: absolute; top: 20%" Text="Pesquisar" Width="85px" CausesValidation="False"
                        OnClick="Button5_Click1" TabIndex="8" />
                    <asp:Button ID="Button6" runat="server" CssClass="button" Style="z-index: 101; left: 25%;
                        position: absolute; top: 20%" Text="Novo" Width="85px" CausesValidation="False"
                        OnClick="Button6_Click" TabIndex="7" />
                    <asp:Button ID="Button7" runat="server" CssClass="button" Style="z-index: 102; left: 50%;
                        position: absolute; top: 20%" Text="Salvar" Width="85px" OnClick="Button7_Click" Height="21px" TabIndex="6" />
                    <asp:Button ID="BtExcluir" runat="server" CssClass="button" Style="z-index: 104;
                        left: 75%; position: absolute; top: 20%" Text="Excluir" Width="85px" OnClick="BtExcluir_Click"
                        CausesValidation="False" Enabled="false" Height="21px" TabIndex="9" />
                </div>
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Label ID="Label4" runat="server" Style="z-index: 100; left: 2%; position: absolute;
                    top: 29px" Text="Assunto:"></asp:Label>
                &nbsp; &nbsp;
                <asp:Label ID="Email" runat="server" Style="z-index: 101; left: 2%; position: absolute;
                    top: 72px" Text="Local:"></asp:Label>
                <asp:Label ID="Label1" runat="server" Style="z-index: 102; left: 2%; position: absolute;
                    top: 113px" Text="Data:"></asp:Label>
                <asp:Label ID="Label2" runat="server" Style="z-index: 103; left: 2%; position: absolute;
                    top: 154px" Text="Participantes:"></asp:Label>
                <asp:Label ID="lblCriador" runat="server" Style="z-index: 104; left: 2%; position: absolute;
                    top: 383px" Text="Criador:" Visible="False"></asp:Label>
                <asp:TextBox ID="txtLocal" runat="server" MaxLength="100" Style="z-index: 105; left: 2%;
                    position: absolute; top: 87px" TabIndex="2" Width="320px"></asp:TextBox>
                <asp:TextBox ID="txtCriador" runat="server" Enabled="False" Height="16px" MaxLength="100"
                    Style="z-index: 106; left: 12%; position: absolute; top: 383px" TabIndex="2"
                    Visible="False" Width="260px"></asp:TextBox>
                &nbsp;
                &nbsp;&nbsp;
                <asp:TextBox ID="txtAssunto" runat="server" Style="z-index: 107; left: 2%; position: absolute;
                    top: 45px" Width="320px" MaxLength="100" TabIndex="1"></asp:TextBox>
                &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAssunto"
                    ErrorMessage="* campo obrigatório" Style="z-index: 108; left: 335px; position: absolute;
                    top: 46px" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLocal"
                    ErrorMessage="* campo obrigatório" Style="z-index: 109; left: 335px; position: absolute;
                    top: 89px" SetFocusOnError="True"></asp:RequiredFieldValidator>
                &nbsp; &nbsp; &nbsp; &nbsp;
                <uc3:Calendario ID="DtReuniao" runat="server" left="10" top="128" />
                
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" Style="z-index: 0; left: 2%;
                    position: absolute; top: 172px" Width="320px" BorderColor="#507CD1" BorderStyle="Ridge" BorderWidth="1px" CssClass="check">
                </asp:CheckBoxList>
            </div>
        </fieldset>
        &nbsp;&nbsp;
        <uc1:Menu ID="Menu1" runat="server" />
        <uc2:Topo ID="Topo1" runat="server" />
    </form>
</body>
</html>
