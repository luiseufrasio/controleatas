<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Calendario.ascx.cs" Inherits="Calendario" %>



<link href="/Style/Style1.css" rel="stylesheet" type="text/css" />
<asp:Panel ID="PanelCalendar" runat="server"  style="z-index: 100; left: 1%; position: absolute; top: 1%;" Height="167px" Width="181px">
        <asp:TextBox ID="EdCalendar" runat="server" Style="z-index: 1; left: 1%; position: absolute;
            top: 0%" Width="72px" CssClass="forms" ReadOnly="True"></asp:TextBox>
        <asp:ImageButton ID="BtCalendar" runat="server" Style="z-index: 101; left: 44%;
            position: absolute; top: 0%" Height="22px" ImageUrl="~/imagens/calendario.gif" OnClick="BtCalendar_Click" Width="22px" CausesValidation="False" ImageAlign="Top" />
        <asp:Calendar ID="Calendar" runat="server" BackColor="White" BorderColor="#3366CC"
            BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
            Font-Size="8pt" ForeColor="#003399" Height="58px" OnSelectionChanged="Calendar_SelectionChanged"
            Style="z-index: 100; left: 2%; position: absolute; top: 13%" Width="49px" Visible="False">
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <WeekendDayStyle BackColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
        </asp:Calendar>    

</asp:Panel>




