<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="ManutencaoOrcamento" %>

<%@ Register Src="componentes/Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<%@ Register Src="componentes/Topo.ascx" TagName="Topo" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema de Solicitação e Autorização de Pagamentos</title>
    <link href="css/Geral.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="Button7" defaultfocus="txtNome">
        <fieldset id="Fieldset1" class="fieldset" runat="server" align="middle" style="z-index: 100;
            left: 21%; position: absolute; top: 9%; width: 554px; height: 234px;" hidefocus="hideFocus"
            unselectable="on">
            <legend class="legend">Cadastro de Usuários</legend>
            <div>
                &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <div style="z-index: 114; left: 2%; width: 358px; position: absolute; top: 83%; height: 41px">
                    <asp:Button ID="Button5" runat="server" CssClass="button" Style="z-index: 100; left: 0%;
                        position: absolute; top: 20%" Text="Pesquisar" Width="85px" CausesValidation="False"
                        OnClick="Button5_Click1" TabIndex="10" />
                    <asp:Button ID="Button6" runat="server" CssClass="button" Style="z-index: 101; left: 25%;
                        position: absolute; top: 20%" Text="Novo" Width="85px" CausesValidation="False"
                        OnClick="Button6_Click" TabIndex="9" />
                    <asp:Button ID="Button7" runat="server" CssClass="button" Style="z-index: 102; left: 50%;
                        position: absolute; top: 20%" Text="Salvar" Width="85px" OnClick="Button7_Click" Height="21px" TabIndex="8" />
                    <asp:Button ID="BtExcluir" runat="server" CssClass="button" Style="z-index: 104;
                        left: 75%; position: absolute; top: 20%" Text="Excluir" Width="85px" OnClick="BtExcluir_Click"
                        CausesValidation="False" Enabled="false" Height="21px" TabIndex="11" />
                </div>
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Label ID="Label4" runat="server" Style="z-index: 100; left: 2%; position: absolute;
                    top: 29px" Text="Nome:"></asp:Label>
                &nbsp;
                <asp:Label ID="Label6" runat="server" Style="z-index: 101; left: 2%; position: absolute;
                    top: 114px" Text="Login:"></asp:Label>
                <asp:Label ID="Email" runat="server" Style="z-index: 102; left: 2%; position: absolute;
                    top: 72px" Text="E-mail:"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" Style="z-index: 103; left: 2%; position: absolute;
                    top: 87px" Width="320px" MaxLength="100" TabIndex="2"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Style="z-index: 104; left: 191px; position: absolute;
                    top: 114px" Text="Senha:"></asp:Label>
                <asp:TextBox ID="TxtSenha" runat="server" Style="z-index: 105; left: 191px; position: absolute;
                    top: 131px" Width="141px" TextMode="Password" MaxLength="10" TabIndex="4"></asp:TextBox>
                <asp:TextBox ID="txtNome" runat="server" Style="z-index: 106; left: 2%; position: absolute;
                    top: 45px" Width="320px" MaxLength="100" TabIndex="1"></asp:TextBox>
                &nbsp;
                <asp:TextBox ID="txtLogin" runat="server" Style="z-index: 107; left: 2%; position: absolute;
                    top: 131px" Width="160px" MaxLength="20" TabIndex="3"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNome"
                    ErrorMessage="* campo obrigatório" Style="z-index: 108; left: 335px; position: absolute;
                    top: 46px" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="* campo obrigatório" Style="z-index: 109; left: 335px; position: absolute;
                    top: 88px" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLogin"
                    ErrorMessage="* o campo Login é obrigatório" Style="z-index: 110; left: 336px;
                    position: absolute; top: 125px" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtSenha"
                    ErrorMessage="* o campo Senha é obrigatório" Style="z-index: 111; left: 336px;
                    position: absolute; top: 140px" SetFocusOnError="True"></asp:RequiredFieldValidator>
                &nbsp;&nbsp;
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="* e-mail inválido" Style="z-index: 112; left: 335px; position: absolute;
                    top: 89px" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True"></asp:RegularExpressionValidator>
                <asp:CheckBox ID="chkAdmin" runat="server" Style="z-index: 115; left: 2%; position: absolute;
                    top: 162px" Text="Administrador do Sistema" />
            </div>
        </fieldset>
        &nbsp;&nbsp;
        <uc1:Menu ID="Menu1" runat="server" />
        <uc2:Topo ID="Topo1" runat="server" />
    </form>
</body>
</html>
