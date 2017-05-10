<%@ Page Title="View Ticket" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style2
    {
        width: 60%;
    }
        .style3
        {
            width: 122px;
        }
        .style4
        {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
<legend>Ticket View</legend>
<div id="SelectTicket" class="ViewTicket" runat="server">

    Please choose from the criteria below to view tickets submitted by you.<br />
    <table class="style2">
        <tr>
            <td colspan="2" class="style4">
                Ticket #:&nbsp;
                <asp:TextBox ID="txtTicketNumber" runat="server"></asp:TextBox>
            </td>
            <td class="style4">
                <asp:Button ID="btnSubmitTicket" runat="server" onclick="btnSubmitTicket_Click" 
                    Text="Submit" />
            </td>
            <td colspan="2" class="style4">
                </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Employee:</td>
            <td class="style3">
                <asp:DropDownList ID="ddlEmployee" runat="server" DataSourceID="sqlEmployee" 
                    DataTextField="FullName" DataValueField="employeenumber" 
                    AppendDataBoundItems="True">
                    <asp:ListItem Value="000">ALL</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                Ticket Status:</td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server" 
                    DataSourceID="sqlStatus" DataTextField="Status" DataValueField="StatusID" 
                    AppendDataBoundItems="True">
                    <asp:ListItem Value="4">ALL</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnSubmitStatusByEmployee" runat="server" 
                    onclick="btnSubmitStatusByEmployee_Click" Text="Submit" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Department:</td>
            <td class="style3">
                <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="sqlDept" 
                    DataTextField="DepartmentName" DataValueField="DepartmentName" 
                    AppendDataBoundItems="True">
                    <asp:ListItem Value=000>ALL</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                Status:</td>
            <td>
                <asp:DropDownList ID="ddlStatusByDept" runat="server" DataSourceID="sqlStatus" 
                    DataTextField="Status" DataValueField="StatusID" 
                    AppendDataBoundItems="True">
                    <asp:ListItem Value="4">ALL</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnSubmitStatusDept" runat="server" 
                    onclick="btnSubmitStatusDept_Click" Text="Submit" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:SqlDataSource ID="sqlEmployee" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                    SelectCommand="GetEmployees" SelectCommandType="StoredProcedure">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="sqlStatus" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                    SelectCommand="SELECT * FROM [tbl_Status]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="sqlDept" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                    SelectCommand="SELECT * FROM [Departments]">
                </asp:SqlDataSource>
            </td>
            <td colspan="3">
                &nbsp;</td>
        </tr>
    </table>

</div>
<div id="ViewTickets" class="ViewTicket" runat="server" visible="False">

    Tickets entered by
    <asp:Label ID="lblUser" runat="server" ForeColor="Red"></asp:Label>
&nbsp;with status:
    <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
    &nbsp;
    <asp:Button ID="btnReturn" runat="server" onclick="btnReturn_Click" 
        Text="Return" />
    <br />
    <br />
    <asp:GridView ID="gvTickets" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="sqlTickets" 
        EmptyDataText="No Tickets Found" ForeColor="#333333" Width="825px" 
        Visible="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="~/DetailTicketView.aspx?ID={0}" DataTextField="ID" 
                HeaderText="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" 
                ReadOnly="True" NullDisplayText="OTHER" />
            <asp:BoundField DataField="Dept" HeaderText="Dept" 
                SortExpression="Dept" />
            <asp:BoundField DataField="system" HeaderText="System" 
                SortExpression="system" />
            <asp:BoundField DataField="Issue" HeaderText="Issue" SortExpression="Issue" />
            <asp:BoundField DataField="user" HeaderText="user" 
                SortExpression="user" />
            <asp:BoundField DataField="Date" HeaderText="Date" 
                SortExpression="Date" DataFormatString="{0:d}" />
            <asp:BoundField DataField="Life" HeaderText="Life" ReadOnly="True" 
                SortExpression="Life" />
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
    <br />
    <asp:GridView ID="gvTicketsByDeptAndStatus" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="sqlTicketsByDeptStatus" 
        EmptyDataText="No Tickets Found" ForeColor="#333333" Width="825px" 
        Visible="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="~/DetailTicketView.aspx?ID={0}" DataTextField="ID" 
                HeaderText="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" 
                SortExpression="Name" NullDisplayText="OTHER" />
            <asp:BoundField DataField="Dept" HeaderText="Dept" SortExpression="Dept" />
            <asp:BoundField DataField="system" HeaderText="System" 
                SortExpression="system" />
            <asp:BoundField DataField="Issue" HeaderText="Issue" SortExpression="Issue" />
            <asp:BoundField DataField="user" HeaderText="user" SortExpression="user" />
            <asp:BoundField DataField="Date" DataFormatString="{0:d}" HeaderText="Date" 
                SortExpression="Date" />
            <asp:BoundField DataField="Life" HeaderText="Life" ReadOnly="True" 
                SortExpression="Life" />
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
    <br />
    <asp:SqlDataSource ID="sqlTicketsByDeptStatus" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
        SelectCommand="TicketByDeptAndStatus" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlDept" Name="Department" 
                PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="ddlStatusByDept" Name="Status" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="sqlTickets" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
        SelectCommand="TicketsByEmployee" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlEmployee" Name="Employee" 
                PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="ddlStatus" Name="Status" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

</div>
</fieldset>
</asp:Content>

