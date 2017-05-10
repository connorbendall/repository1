<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="PMMissingSchedule.aspx.cs" Inherits="PMDueThisWeek" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<fieldset><legend>Please select a division. A list of machines will appear that 
    require PM Schedules and need tasks assigned to them.&nbsp; </legend>
    <br />
    <table align="center">
        <tr>
            <td>Select Division</td>
            <td>
                <asp:DropDownList ID="drpDivision" runat="server" AppendDataBoundItems="True" 
                    DataSourceID="srcDivisioon" DataTextField="division" 
                    DataValueField="division" AutoPostBack="True">
                    <asp:ListItem>PLEASE SELECT</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="srcDivisioon" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:HRDBConnectionString %>" 
                    SelectCommand="ActiveDivisions" SelectCommandType="StoredProcedure">
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>

    <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="srcPM" Width="791px" CellPadding="4" ForeColor="#333333" 
        EmptyDataText="No Data Returned">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="machinenumber" HeaderText="Machine Number" 
                SortExpression="machinenumber" />
            <asp:BoundField DataField="machinename" HeaderText="Machine Name" 
                SortExpression="machinename" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <asp:SqlDataSource ID="srcPM" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TESTQTYConnectionString %>" SelectCommand="SELECT machinenumber, machinename, DIVISION FROM dbo.view_PM_Missing_Schedules WHERE division = @Division order by machinenumber
">
        <SelectParameters>
            <asp:ControlParameter ControlID="drpDivision" Name="Division" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    </fieldset>
</asp:Content>

