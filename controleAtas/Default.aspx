<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="componentes/Topo.ascx" TagName="Topo" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sistema de Solicitação e Autorização de Pagamentos</title>
<script language="javascript" type="text/javascript">
<!--

function DIV1_onclick() {

}

// -->
</script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Login ID="Login1" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4"
            BorderStyle="Solid" BorderWidth="1px" DisplayRememberMe="False" Font-Names="Verdana"
            Font-Size="0.8em" ForeColor="#333333" Height="141px" LoginButtonText="Entrar"
            OnAuthenticate="Login1_Authenticate" PasswordLabelText="Senha:" Style="z-index: 102;
            left: 36%; position: absolute; top: 36%" TitleText="Autenticação" UserNameLabelText="Usuário:"
            Width="216px" FailureText="Usuário ou Senha incorretos. Por favor, tente novamente.">
            <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <TextBoxStyle Font-Size="0.8em" />
            <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px"
                Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
        </asp:Login>
        <uc1:Topo ID="Topo1" runat="server" />
    </form>
</body>
</html>