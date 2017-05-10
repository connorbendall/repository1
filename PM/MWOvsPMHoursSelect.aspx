<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MWOvsPMHoursSelect.aspx.cs" Inherits="reportDateRangeSelect" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset><legend>Please select a division, date range</legend>
<table align="center">
<tr>
    <td>
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </td>
    <td>
        &nbsp;</td>
</tr>
<tr>
    <td>Date From<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </td>
    <td>
        <asp:TextBox ID="txtDateFrom" runat="server"></asp:TextBox>
        <asp:PopupControlExtender ID="txtDateFrom_PopupControlExtender" runat="server" 
            PopupControlID="pnlDateFrom" TargetControlID="txtDateFrom" OffsetY="20">
        </asp:PopupControlExtender>
    </td>
</tr>
<tr>
    <td>Date To</td>
    <td>
        <asp:TextBox ID="txtDateTo" runat="server"></asp:TextBox>
        <asp:PopupControlExtender ID="txtDateTo_PopupControlExtender" runat="server" 
            PopupControlID="pnlDateTo" TargetControlID="txtDateTo" OffsetY="20">
        </asp:PopupControlExtender>
    </td>
</tr>
<tr>
    <td>Division</td>
    <td>
        <asp:DropDownList ID="drpDivision" runat="server" AppendDataBoundItems="True" 
            DataSourceID="srcActiveDivisions" DataTextField="division" 
            DataValueField="division">
            <asp:ListItem Value="%">ALL</asp:ListItem>
        </asp:DropDownList>
    </td>
</tr>
<tr>
    <td>
        <asp:SqlDataSource ID="srcActiveDivisions" runat="server" 
            ConnectionString="<%$ ConnectionStrings:HRDBConnectionString %>" 
            SelectCommand="ActiveDivisions" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
    </td>
    <td>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
            onclick="btnSubmit_Click" /></td>
</tr>

<tr>
    <td>
        <asp:Panel ID="pnlDateFrom" runat="server">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Calendar ID="calDateFrom" runat="server" 
                    onselectionchanged="calDateFrom_SelectionChanged" BackColor="#FFFFCC" 
                    BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
                    ShowGridLines="True" Width="220px">
                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                    <OtherMonthDayStyle ForeColor="#CC9966" />
                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                    <SelectorStyle BackColor="#FFCC66" />
                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                        ForeColor="#FFFFCC" />
                    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                </asp:Calendar>
            </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </td>
    <td>
        <asp:Panel ID="pnlDateTo" runat="server">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Calendar ID="calDateTo" runat="server" 
                    onselectionchanged="calDateTo_SelectionChanged" BackColor="#FFFFCC" 
                    BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
                    ShowGridLines="True" Width="220px">
                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                    <OtherMonthDayStyle ForeColor="#CC9966" />
                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                    <SelectorStyle BackColor="#FFCC66" />
                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                        ForeColor="#FFFFCC" />
                    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                </asp:Calendar>
            </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </td>
</tr>

</table>
</fieldset>
</asp:Content>

