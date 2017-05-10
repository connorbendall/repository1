<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="PMMachineHistorySelect.aspx.cs" Inherits="PMSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset><legend>Please select a machine. The next page will allow entry or updating of Schedule. </legend>

    <table>
        <tr>
            <td>Division</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" 
                    AutoPostBack="True" DataSourceID="srcDivision" DataTextField="division" 
                    DataValueField="division">
                </asp:DropDownList>
                <asp:SqlDataSource ID="srcDivision" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:HRDBConnectionString %>" 
                    SelectCommand="ActiveDivisions" SelectCommandType="StoredProcedure">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>Machine #</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="srcMachine" 
                    DataTextField="NAME" DataValueField="ABRESC" AutoPostBack="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="srcMachine" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:COMPConnectionString %>" 
                    
                    
                    SelectCommand="SELECT [ABDEPT], [ABRESC], [ABDES], ABPLNT as DIVISION,
                                    [ABRESC] + ' - ' + [ABDES] AS NAME 
                                    FROM [vMachineNumbers] 
                                    WHERE (ABPLNT = @DIVISION)
                                    ORDER by [ABRESC] ">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="DIVISION" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        </table>

        <br />

        <hr />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="PMID" DataSourceID="srcEntries" Width="768px" 
            CellPadding="4" ForeColor="#333333" EmptyDataText="No Date Returned">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="PMdate" DataFormatString="{0:d}" 
                    HeaderText="PM Date" SortExpression="PMdate" />
                <asp:BoundField DataField="performedBy" HeaderText="Performed By" 
                    SortExpression="performedBy" />
                <asp:BoundField DataField="frequency" HeaderText="Frequency" 
                    SortExpression="frequency" />
                <asp:BoundField DataField="totaltime" HeaderText="Total Time" 
                    SortExpression="totaltime" />
                <asp:BoundField DataField="notes" HeaderText="Notes" SortExpression="notes" />
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
        <asp:SqlDataSource ID="srcEntries" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TESTQTYConnectionString %>" SelectCommand="SELECT PMID, machinenumber, division, tasktype, frequency, notes, PMdate, performedBy, totaltime FROM dbo.tbl_PM_Entries WHERE machinenumber = @Machine ORDER BY PMdate DESC">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList2" Name="Machine" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
</fieldset>
</asp:Content>

