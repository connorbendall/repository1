<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="PMDueWeek2.aspx.cs" Inherits="PMDueWeek2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<fieldset><legend>The following is a list of machines that are due week 2 for PM. 
    <br />
    Click on the Machine # to see what tasks need to be completed for that machine and PM frequency. </legend>
    <br />
    <table>
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
        DataSourceID="dsPMsDueWeek2" Width="791px" CellPadding="4" ForeColor="#333333" 
        EmptyDataText="No Data Returned">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Machine" SortExpression="Machinenumber">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Machinenumber") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl='<%# string.Format("~/PMPrintTasks.aspx?Frequency={1}&Machine={0}", Eval("Machinenumber"), Eval("frequency")) %>' Text='<%# Eval("Machinenumber") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="division" HeaderText="Division" SortExpression="division" />
            <asp:BoundField DataField="frequency" HeaderText="Frequency" SortExpression="frequency" />
            <asp:BoundField DataField="NEXTPMDATE" DataFormatString="{0:d}" HeaderText="PM Due" SortExpression="NEXTPMDATE" />
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
    <asp:SqlDataSource ID="dsPMsDueWeek2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TESTQTYConnectionString %>" 
        SelectCommand="SELECT distinct Machinenumber, frequency, NEXTPMDATE, division 
	                    FROM dbo.view_PM_WEEKLY_PM 
	                    WHERE DATEPART(wk,NEXTPMDATE) = DATEPART(wk,getdate()+7)
	                    AND DATEPART(YEAR,NEXTPMDATE) = DATEPART(YEAR,getdate())
	                    AND division = @division
	                    ORDER BY NEXTPMDATE">
        <SelectParameters>
            <asp:ControlParameter ControlID="drpDivision" Name="division" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    </fieldset>
</asp:Content>
