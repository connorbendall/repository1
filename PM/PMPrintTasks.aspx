<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="PMPrintTasks.aspx.cs" Inherits="PMPrintTasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 107px;
            height: 46px;
        }
        .style3
        {
            width: 108px;
            height: 46px;
        }
        .style4
        {
            width: 100px;
            height: 46px;
        }
        .style5
        {
            width: 182px;
            height: 46px;
        }
        .style7
        {
            height: 46px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<fieldset><legend>The following are tasks to be completed for Machine #
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;for frequency:
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
&nbsp;day. Click Print to print this PM sheet. </legend>
    <table>
        <tr>
            <td class="style7" align="center"><a href="#" onclick="print()">
                <font color="#0000FF" face="Arial, Helvetica, sans-serif"><strong>PRINT</strong></font></a></td>
        </tr>
        <tr>
            <td class="style7">Target Date</td>
            <td class="style7">
                <asp:FormView ID="FormView1" runat="server" DataSourceID="srcPMPrint">
                    <EditItemTemplate>
                        Machinenumber:
                        <asp:TextBox ID="MachinenumberTextBox" runat="server" 
                            Text='<%# Bind("Machinenumber") %>' />
                        <br />
                        frequency:
                        <asp:TextBox ID="frequencyTextBox" runat="server" 
                            Text='<%# Bind("frequency") %>' />
                        <br />
                        NEXTPMDATE:
                        <asp:TextBox ID="NEXTPMDATETextBox" runat="server" 
                            Text='<%# Bind("NEXTPMDATE") %>' />
                        <br />
                        task:
                        <asp:TextBox ID="taskTextBox" runat="server" Text='<%# Bind("task") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                            CommandName="Update" Text="Update" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        Machinenumber:
                        <asp:TextBox ID="MachinenumberTextBox" runat="server" 
                            Text='<%# Bind("Machinenumber") %>' />
                        <br />
                        frequency:
                        <asp:TextBox ID="frequencyTextBox" runat="server" 
                            Text='<%# Bind("frequency") %>' />
                        <br />
                        NEXTPMDATE:
                        <asp:TextBox ID="NEXTPMDATETextBox" runat="server" 
                            Text='<%# Bind("NEXTPMDATE") %>' />
                        <br />
                        task:
                        <asp:TextBox ID="taskTextBox" runat="server" Text='<%# Bind("task") %>' />
                        <br />
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                            CommandName="Insert" Text="Insert" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        &nbsp;<asp:Label ID="NEXTPMDATELabel" runat="server" 
                            Text='<%# Bind("NEXTPMDATE") %>' />
                        <br />
                    </ItemTemplate>
                </asp:FormView>
            </td></td>
            <td class="style5">Action Completetion Date</td>
            <td class="style3"></td>
            <td class="style7">Total Time Hrs</td>
            <td class="style4"></td>
            <td class="style2">Completed By</td>
            <td class="style3"></td>
        </tr>
        <tr>
            <td>Notes From Last PM</td>
            <td colspan="7">
                <asp:FormView ID="FormView2" runat="server" DataSourceID="srcNotes">
                    <EditItemTemplate>
                        Machinenumber:
                        <asp:TextBox ID="MachinenumberTextBox" runat="server" 
                            Text='<%# Bind("Machinenumber") %>' />
                        <br />
                        frequency:
                        <asp:TextBox ID="frequencyTextBox" runat="server" 
                            Text='<%# Bind("frequency") %>' />
                        <br />
                        Column1:
                        <asp:TextBox ID="Column1TextBox" runat="server" Text='<%# Bind("Column1") %>' />
                        <br />
                        LASTPMNOTES:
                        <asp:TextBox ID="LASTPMNOTESTextBox" runat="server" 
                            Text='<%# Bind("LASTPMNOTES") %>' />
                        <br />
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                            CommandName="Update" Text="Update" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        Machinenumber:
                        <asp:TextBox ID="MachinenumberTextBox" runat="server" 
                            Text='<%# Bind("Machinenumber") %>' />
                        <br />
                        frequency:
                        <asp:TextBox ID="frequencyTextBox" runat="server" 
                            Text='<%# Bind("frequency") %>' />
                        <br />
                        Column1:
                        <asp:TextBox ID="Column1TextBox" runat="server" Text='<%# Bind("Column1") %>' />
                        <br />
                        LASTPMNOTES:
                        <asp:TextBox ID="LASTPMNOTESTextBox" runat="server" 
                            Text='<%# Bind("LASTPMNOTES") %>' />
                        <br />
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                            CommandName="Insert" Text="Insert" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        &nbsp;<asp:Label ID="LASTPMNOTESLabel" runat="server" 
                            Text='<%# Bind("LASTPMNOTES") %>' />
                        <br />
                    </ItemTemplate>
                </asp:FormView>
                <asp:SqlDataSource ID="srcNotes" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:TESTQTYConnectionString %>" SelectCommand="SELECT Machinenumber, frequency, max(PMDATE), LASTPMNOTES FROM dbo.view_PM_LAST_PM_NOTES WHERE Machinenumber = @Machine and frequency = @Frequency group by Machinenumber, frequency, lastpmnotes ORDER BY Machinenumber ASC
">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="Machine" QueryStringField="Machine" />
                        <asp:QueryStringParameter Name="Frequency" QueryStringField="Frequency" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="srcPMPrint" Width="908px" CellPadding="4" 
        ForeColor="#333333" EmptyDataText="No Data Returned">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="task" HeaderText="Task" SortExpression="task" >
            <ItemStyle Width="250px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Complete?">
                <ItemStyle Width="125px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="New Notes">
                <ItemStyle Height="75px" />
            </asp:TemplateField>
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

    <asp:SqlDataSource ID="srcPMPrint" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TESTQTYConnectionString %>" SelectCommand="SELECT distinct Machinenumber, frequency, NEXTPMDATE, task FROM dbo.view_PM_Next_PM WHERE Machinenumber = @Machine and frequency = @Frequency ORDER BY Machinenumber ASC
">
        <SelectParameters>
            <asp:QueryStringParameter Name="Machine" QueryStringField="Machine" />
            <asp:QueryStringParameter Name="Frequency" QueryStringField="Frequency" />
        </SelectParameters>
    </asp:SqlDataSource>

</fieldset>
</asp:Content>

