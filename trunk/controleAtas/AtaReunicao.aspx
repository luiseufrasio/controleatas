<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AtaReunicao.aspx.cs" Inherits="AtaReunicao" ValidateRequest="false" %>
<%@ Register Assembly="HTMLControl" Namespace="HTMLControl.HTMLEditorControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ata de Reunião</title>
<style> 
.EditControl1       {       
width:500px;               
height:300px;
line-height:0px;      } 
</style>      
    <script language="javascript">
    function desabilita()
    {
    //RTFEdit_TxtInsere.document.designMode='off';
    alert('teste');
    }
    
    </script>
    </head>
<body runat=server id="pagina">
    <form id="form1" runat="server">
    <fieldset id="Fieldset1" class="fieldset" runat="server" align="middle" style="z-index: 100;
            left: 25%; position: absolute; top: 9%; width: 70%; height: 500px; " hidefocus="hideFocus"
            unselectable="on" >
            <legend class="legend">Cadastro de Atas</legend>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <cc1:htmleditor id="TxtInsere" runat="server"  emotionsdialogueheight="0" emotionsdialoguewidth="0" Height="500" Width="600"
             EnableTheming="False" SmilesPath="" SmilesPickerFilePath="" ColorPickerFilePath="" style="z-index: 101; left: 0px; position: absolute; top: 0px; height:300px; " EditorHeight="300" EditorWidth="500" ></cc1:htmleditor>
        &nbsp;
        <asp:Button ID="BtVisualiza" runat="server" OnClick="BtVisualiza_Click" Width="70px" Style="z-index: 110;
            left: 297px; position: absolute; top: 400px" Text="Visualizar"  />
        <asp:Button ID="BtGrava" runat="server" OnClick="BtGrava_Click" Width="70px" Style="z-index: 110;
            left: 209px; position: absolute; top: 400px" Text="Gravar" />
        <asp:Button ID="BtInsere" runat="server" OnClick="BtInsere_Click" Width="70px" Style="z-index: 110;
            left: 122px; position: absolute; top: 400px" Text="Inserir" />
    </fieldset>
    <div id="teste" onload="desabilita();" oninit="alert('teste2');">
           
    </div>
        <script>
            
            //.style.line-height=1;
            
            document.getElementById('RTFEdit_TxtInsere').className='EditControl1';
           // alert(document.getElementById('RTFEdit_TxtInsere').style.lineHeight);
           // document.getElementById('lstStyle').style.visibility = 'hidden';
            
            //document.getElementById('lstFont').style.visibility = 'hidden';

            
          //  document.getElementById('lstFontSize').style.visibility = 'hidden'; 
          RTFEdit_TxtInsere.focus();
	      RTFEdit_TxtInsere.document.execCommand('lineHeight',false,'1px');
	      RTFEdit_TxtInsere.focus();
                           
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
