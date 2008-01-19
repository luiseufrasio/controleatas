<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Menu" %>

<style type="text/css">
<!--
    ul#menu {
        width:200px;
        border:1px solid #003399;
        background:#EFF3FB;
        margin:0;
        padding:0;
        list-style-type:none;
    }
    ul#menu li {
        border-bottom:1px solid #A4A0F5;
    }
    ul#menu li a:link, ul#menu li a:visited {
        display:block;
        height:1%;
        text-decoration:none;
        font-family: Geneva, Arial, Helvetica, sans-serif;
        font-size:14px;
        color:#5E0F50;
        border-left:10px solid #507CD1;
        padding-left:5px;
    }
    ul#menu li a:hover {
        background-color: #507CD1;
        color:#FFFFFF;
        border-left:10px solid #FFFFFF;
    }
-->
</style>

<ul id="menu" style="z-index: 100; left: 1px; position: absolute; top: 56px">
    <li id="sair"><a href="Sair.aspx"><u>Sair</u></a></li>
    <li id="alteracaosenha"><a href="AlteracaoSenha.aspx"><u>Alterar Senha</u></a></li>
    <li id="cr"><a href="reunioes.aspx">Criar Reunião</a></li>
    <li id="cu" style="display: <%=Session["admin"].ToString().Equals("True") ? "block" : "none"%>;">
        <a href="Usuarios.aspx">Criar Usuário</a></li>
    <li id="ea"><a href="#">Escrever Ata</a></li>
</ul>