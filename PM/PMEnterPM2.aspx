<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="PMEnterPM2.aspx.cs" Inherits="PMEnterPM2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<fieldset><legend>Please add any notes (if required), and click SUBMIT to add PM Entry. </legend>
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="PMID" 
        DataSourceID="srcPM" DefaultMode="Insert" Width="100%" 
        oniteminserted="FormView1_ItemInserted" CellPadding="4" 
        ForeColor="#333333">
        <EditItemTemplate>
            PMID:
            <asp:Label ID="PMIDLabel1" runat="server" Text='<%# Eval("PMID") %>' />
            <br />
            machinenumber:
            <asp:TextBox ID="machinenumberTextBox" runat="server" 
                Text='<%# Bind("machinenumber") %>' />
            <br />
            frequency:
            <asp:TextBox ID="frequencyTextBox" runat="server" 
                Text='<%# Bind("frequency") %>' />
            <br />
            PMdate:
            <asp:TextBox ID="PMdateTextBox" runat="server" Text='<%# Bind("PMdate") %>' />
            <br />
            performedBy:
            <asp:TextBox ID="performedByTextBox" runat="server" 
                Text='<%# Bind("performedBy") %>' />
            <br />
            totaltime:
            <asp:TextBox ID="totaltimeTextBox" runat="server" 
                Text='<%# Bind("totaltime") %>' />
            <br />
            division:
            <asp:TextBox ID="divisionTextBox" runat="server" 
                Text='<%# Bind("division") %>' />
         
            <br />
            notes:
            <asp:TextBox ID="notesTextBox" runat="server" Text='<%# Bind("notes") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <InsertItemTemplate>
        <table border="1px" style="width: 100%">
            <tr>
                <td>Machine</td>
                <td>
                    <asp:TextBox ID="txtMachine" runat="server" ReadOnly="True" 
                        Text='<%# Bind("machinenumber") %>'></asp:TextBox>
                </td>
                <td>Frequency</td>
                <td>
                    <asp:TextBox ID="txtFrequency" runat="server" ReadOnly="True" 
                        Text='<%# Bind("frequency") %>'></asp:TextBox>
                </td>
                <td>Date</td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server" ReadOnly="True" 
                        Text='<%# Bind("PMdate") %>'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Performed By</td>
                <td>
                    <asp:TextBox ID="txtPerformedBy" runat="server" ReadOnly="True" 
                        Text='<%# Bind("performedBy") %>'></asp:TextBox>
                </td>
                <td>Time To<br />Compelete</td>
                <td>
                    <asp:TextBox ID="txtComplete" runat="server" ReadOnly="True" 
                        Text='<%# Bind("totaltime") %>'></asp:TextBox>
                </td>
                <td>Division</td>
                <td>
                    <asp:TextBox ID="txtDivision" runat="server" ReadOnly="True" 
                        Text='<%# Bind("division") %>'></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                <td colspan="6" align="center" bgcolor="Gray" class="required">Tasks Completed</td>
            </tr>
            <tr>
                <td>Notes</td>
                <td colspan="5"><asp:TextBox ID="notesTextBox" runat="server" Text='<%# Bind("notes") %>' Height="60" TextMode="MultiLine" Width="500" /></td>
            </tr>
            <tr>
                
                <td colspan="6" align="center">
                <asp:Button ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Submit" Width="107px" /></td>
            </tr>
        </table>
        </InsertItemTemplate>
        <ItemTemplate>
            PMID:
            <asp:Label ID="PMIDLabel" runat="server" Text='<%# Eval("PMID") %>' />
            <br />
            machinenumber:
            <asp:Label ID="machinenumberLabel" runat="server" 
                Text='<%# Bind("machinenumber") %>' />
            <br />
            frequency:
            <asp:Label ID="frequencyLabel" runat="server" Text='<%# Bind("frequency") %>' />
            <br />
            PMdate:
            <asp:Label ID="PMdateLabel" runat="server" Text='<%# Bind("PMdate") %>' />
            <br />
            performedBy:
            <asp:Label ID="performedByLabel" runat="server" 
                Text='<%# Bind("performedBy") %>' />
            <br />
            totaltime:
            <asp:Label ID="totaltimeLabel" runat="server" Text='<%# Bind("totaltime") %>' />
            <br />
            division:
            <asp:Label ID="divisionLabel" runat="server" Text='<%# Bind("division") %>' />
            <br />
          
            notes:
            <asp:Label ID="notesLabel" runat="server" Text='<%# Bind("notes") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                CommandName="Edit" Text="Edit" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                CommandName="Delete" Text="Delete" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" 
                CommandName="New" Text="New" />
        </ItemTemplate>
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    </asp:FormView>
    <br />

   <div align="center">Most recent entry is at top.<asp:GridView ID="GridView1" 
           runat="server" AutoGenerateColumns="False" DataKeyNames="PMID" 
           DataSourceID="srcPMS" Width="914px" CellPadding="4" ForeColor="#333333">
       <AlternatingRowStyle BackColor="White" />
       <Columns>
           <asp:BoundField DataField="machinenumber" HeaderText="Machine #" 
               SortExpression="machinenumber" />
           <asp:BoundField DataField="frequency" HeaderText="Frequency" 
               SortExpression="frequency" />
           <asp:BoundField DataField="notes" HeaderText="Notes" SortExpression="notes" />
           <asp:BoundField DataField="PMdate" DataFormatString="{0:d}" 
               HeaderText="PM/CL Date" SortExpression="PMdate" />
           <asp:BoundField DataField="performedBy" HeaderText="Performed By" 
               SortExpression="performedBy" />
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
       <asp:SqlDataSource ID="srcPMS" runat="server" 
           ConnectionString="<%$ ConnectionStrings:TESTQTYConnectionString %>" 
           SelectCommand="SELECT PMID, machinenumber, division, frequency, notes, PMdate, performedBy  FROM dbo.tbl_PM_Entries  WHERE machinenumber =@machine and frequency = @frequency  ORDER BY pmid desc">
           <SelectParameters>
               <asp:QueryStringParameter Name="machine" QueryStringField="Machine" />
               <asp:QueryStringParameter Name="frequency" QueryStringField="Frequency" />
           </SelectParameters>
       </asp:SqlDataSource>
    </div> 
    <asp:SqlDataSource ID="srcPM" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TESTQTYConnectionString %>" 
        DeleteCommand="DELETE FROM [tbl_PM_Entries] WHERE [PMID] = @PMID" 
        InsertCommand="INSERT INTO [tbl_PM_Entries] ([ScheduleID],[machinenumber], [frequency], [PMdate], [performedBy], [totaltime], [division], [notes]) VALUES (@ScheduleID,@machinenumber, @frequency, @PMdate, @performedBy, @totaltime, @division, @notes)" 
        SelectCommand="SELECT [PMID], [machinenumber], [frequency], [PMdate], [performedBy], [totaltime], [division], [notes],[ScheduleID] FROM [tbl_PM_Entries]" 
        UpdateCommand="UPDATE [tbl_PM_Entries] SET [ScheduleID] = @ScheduleID [machinenumber] = @machinenumber, [frequency] = @frequency, [PMdate] = @PMdate, [performedBy] = @performedBy, [totaltime] = @totaltime, [division] = @division, [notes] = @notes WHERE [PMID] = @PMID">
        <DeleteParameters>
            <asp:Parameter Name="PMID" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="machinenumber" Type="String" />
            <asp:Parameter Name="frequency" Type="Decimal" />
            <asp:Parameter Name="PMdate" Type="DateTime" />
            <asp:Parameter Name="performedBy" Type="String" />
            <asp:Parameter Name="totaltime" Type="Decimal" />
            <asp:Parameter Name="division" Type="String" />
            <asp:Parameter Name="notes" Type="String" />
            <asp:Parameter Name="ScheduleID" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="machinenumber" Type="String" />
            <asp:Parameter Name="frequency" Type="Decimal" />
            <asp:Parameter Name="PMdate" Type="DateTime" />
            <asp:Parameter Name="performedBy" Type="String" />
            <asp:Parameter Name="totaltime" Type="Decimal" />
            <asp:Parameter Name="division" Type="String" />
            <asp:Parameter Name="notes" Type="String" />
            <asp:Parameter Name="PMID" Type="Decimal" />
            <asp:Parameter Name="ScheduleID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </fieldset>
</asp:Content>

