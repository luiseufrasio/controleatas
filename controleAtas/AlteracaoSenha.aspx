<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlteracaoSenha.aspx.cs" Inherits="ManutencaoOrcamento" %>

<%@ Register Src="componentes/Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<%@ Register Src="componentes/Topo.ascx" TagName="Topo" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema de Solicitação e Autorização de Pagamentos</title>
    <link href="css/Geral.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="Button7" defaultfocus="TxtSenha">
        <fieldset id="Fieldset1" class="fieldset" runat="server" align="middle" style="z-index: 100;
            left: 21%; position: absolute; top: 9%; width: 554px; height: 328px;" hidefocus="hideFocus"
            unselectable="on">
            <legend class="legend">Alteração de Senha</legend>
            <div>
                &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <div style="z-index: 113; left: 2%; width: 358px; position: absolute; top: 86%; height: 41px">
                    &nbsp;
                    <asp:Button ID="Button7" runat="server" CssClass="button" Style="z-index: 102; left: 0%;
                        position: absolute; top: 44%" Text="Salvar" Width="85px" OnClick="Button7_Click" Height="21px" TabIndex="8" />
                    &nbsp;
                </div>
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Label ID="Label4" runat="server" Style="z-index: 100; left: 2%; position: absolute;
                    top: 29px" Text="Nome:"></asp:Label>
                &nbsp;
                <asp:Label ID="Label6" runat="server" Style="z-index: 101; left: 2%; position: absolute;
                    top: 103px" Text="Login:"></asp:Label>
                <asp:Label ID="Email" runat="server" Style="z-index: 102; left: 2%; position: absolute;
                    top: 66px" Text="E-mail:"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" Style="z-index: 103; left: 2%; position: absolute;
                    top: 81px" Width="320px" MaxLength="100" TabIndex="2" Enabled="False"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Style="z-index: 104; left: 2%; position: absolute;
                    top: 164px" Text="Senha Atual:"></asp:Label>
                <asp:TextBox ID="TxtSenha" runat="server" Style="z-index: 105; left: 2%; position: absolute;
                    top: 181px" Width="127px" TextMode="Password" MaxLength="10" TabIndex="1"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Style="z-index: 106; left: 2%; position: absolute;
                    top: 202px" Text="Nova senha:"></asp:Label>
                <asp:Label ID="Label3" runat="server" Style="z-index: 107; left: 2%; position: absolute;
                    top: 239px" Text="Digite Novamente:"></asp:Label>
                <asp:TextBox ID="TxtNovaSenha2" runat="server" MaxLength="10" Style="z-index: 108; left: 2%;
                    position: absolute; top: 256px" TabIndex="3" TextMode="Password" Width="127px"></asp:TextBox>
                <asp:TextBox ID="TxtNovaSenha" runat="server" MaxLength="10" Style="z-index: 109; left: 2%;
                    position: absolute; top: 219px" TabIndex="2" TextMode="Password" Width="127px"></asp:TextBox>
                &nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="txtNome" runat="server" Style="z-index: 110; left: 2%; position: absolute;
                    top: 45px" Width="320px" MaxLength="100" TabIndex="1" Enabled="False"></asp:TextBox>
                &nbsp;
                <asp:TextBox ID="txtLogin" runat="server" Style="z-index: 111; left: 2%; position: absolute;
                    top: 120px" Width="320px" MaxLength="20" TabIndex="3" Enabled="False"></asp:TextBox>
                &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtSenha"
                    ErrorMessage="* campo obrigatório" Style="z-index: 114; left: 142px; position: absolute;
                    top: 182px" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNovaSenha"
                    ErrorMessage="* campo obrigatório" Style="z-index: 114; left: 142px; position: absolute;
                    top: 221px" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtNovaSenha2"
                    ErrorMessage="* campo obrigatório" Style="z-index: 114; left: 142px; position: absolute;
                    top: 257px" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>
        </fieldset>
        &nbsp;&nbsp;
        <uc1:Menu ID="Menu1" runat="server" />
        <uc2:Topo ID="Topo1" runat="server" />
    </form>
</body>
</html>
