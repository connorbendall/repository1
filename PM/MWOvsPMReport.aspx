<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MWOvsPMReport.aspx.cs" Inherits="printCustomerFastTrack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset><legend>The following is a comparison of Work Order hours vs. PM Hours 
    from <span class="required">
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>&nbsp;</span>to <span class="required">
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></span></legend><h4>To save this report to Excel, click the "Export To Excel" 
    Button<br />and you will be prompted to open OR SAVE the file.</h4>
    <asp:SqlDataSource ID="srcPM" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TESTQTYConnectionString %>" 
        SelectCommand="SELECT TOP 100 PERCENT machinenumber, division, SUM(CASE WHEN WOHours IS NULL THEN 0 ELSE wohours END) AS WOHours,                        SUM(CASE WHEN PMhours IS NULL THEN 0 ELSE PMhours END) AS PMHours, SUM((CASE WHEN PMhours IS NULL THEN 0 ELSE pmhours END)                        + (CASE WHEN WOHours IS NULL THEN 0 ELSE wohours END)) AS TotalHours FROM dbo.view_WOvsPM_hours WHERE (machinenumber &lt;&gt; ' ') and division like @Division and dateofcompletion between @DateFrom and @DateTo   GROUP BY machinenumber, division ORDER BY 'totalhours' desc
" onselecting="srcPM_Selecting">
        <SelectParameters>
            <asp:QueryStringParameter Name="Division" QueryStringField="Division" />
            <asp:QueryStringParameter Name="DateFrom" QueryStringField="DateFrom" />
            <asp:QueryStringParameter Name="DateTo" QueryStringField="DateTo" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Button ID="btnExport" runat="server" onclick="btnExport_Click" 
        Text="Export To Excel" />
        <br />
        <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="srcPM" HorizontalAlign="Center" Width="930px" CellPadding="4" 
            ForeColor="#333333" EmptyDataText="No Data Returned" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="machinenumber" HeaderText="Machine" 
                SortExpression="machinenumber" />
            <asp:BoundField DataField="division" HeaderText="Division" 
                SortExpression="division" />
            <asp:BoundField DataField="PMHours" HeaderText="PM Hours" 
                SortExpression="PMHours" ReadOnly="True" />
            <asp:BoundField DataField="WOHours" HeaderText="Work Order Hours" 
                SortExpression="WOHours" ReadOnly="True" />
            <asp:BoundField DataField="TotalHours" HeaderText="Total Hours" 
                SortExpression="TotalHours" ReadOnly="True" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle HorizontalAlign="Center" BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
</fieldset>
</asp:Content>

