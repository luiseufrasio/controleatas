<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AtaReunicao.aspx.cs" Inherits="AtaReunicao" ValidateRequest="false" %>
<%@ Register Assembly="HTMLControl" Namespace="HTMLControl.HTMLEditorControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ata de Reunião</title>
    </head>
<body>
    <form id="form1" runat="server">
    <fieldset id="Fieldset1" class="fieldset" runat="server" align="middle" style="z-index: 100;
            left: 25%; position: absolute; top: 9%; width: 70%; height: 70%;" hidefocus="hideFocus"
            unselectable="on">
            <legend class="legend">Cadastro de Reuniões</legend>
    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <cc1:htmleditor id="TxtInsere" runat="server"  emotionsdialogueheight="0" emotionsdialoguewidth="0" Height="80%" Width=500px
             EnableTheming="False" SmilesPath="" SmilesPickerFilePath="" ColorPickerFilePath="" style="z-index: 101; left: 0px; position: absolute; top: 0px" ></cc1:htmleditor>
        &nbsp;
        <asp:Button ID="BtVisualiza" runat="server" OnClick="BtVisualiza_Click" Style="z-index: 101;
            left: 297px; position: absolute; top: 449px" Text="Visualizar" />
        <asp:Button ID="BtGrava" runat="server" OnClick="BtGrava_Click" Style="z-index: 102;
            left: 209px; position: absolute; top: 450px" Text="Gravar" />
        <asp:Button ID="BtInsere" runat="server" OnClick="BtInsere_Click" Style="z-index: 104;
            left: 122px; position: absolute; top: 450px" Text="Inserir" />
    </div>
    </fieldset>
        <script>

            document.getElementById('lstStyle').style.visibility = 'hidden';
            
            document.getElementById('lstFont').style.visibility = 'hidden';
            
            document.getElementById('lstFontSize').style.visibility = 'hidden'; 
                           
            document.getElementById('imgAbout').style.visibility = 'hidden';
            
            document.getElementById('imgHighLight').style.visibility = 'hidden';
            
            document.getElementById('imgImage').style.visibility = 'hidden';
            
            document.getElementById('imgLink').style.visibility = 'hidden';
            
            document.getElementById('imgLine').style.visibility = 'hidden';
            
            document.getElementById('imgFontColor').style.visibility = 'hidden';
            
            document.getElementById('imgSmile').style.visibility = 'hidden';
            
            document.getElementById('imgCustom').style.visibility = 'hidden';
        </script>
        
    </form>
</body>
</html>
