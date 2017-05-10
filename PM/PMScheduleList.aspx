<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="PMScheduleList.aspx.cs" Inherits="PMScheduleList" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<fieldset><legend>Please enter a new task, or update and existing task. 
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    </legend><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        DataKeyNames="ScheduleID" DataSourceID="srcPMSchedule" DefaultMode="Insert" 
        Height="50px" Width="449px" oniteminserted="DetailsView1_ItemInserted" 
        oniteminserting="DetailsView1_ItemInserting">
        <Fields>
            <asp:TemplateField HeaderText="Division" SortExpression="Division">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Division") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtDivision" runat="server" ReadOnly="True" 
                        Text='<%# Bind("Division") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Division") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Machine" SortExpression="Machinenumber">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Machinenumber") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtNumber" runat="server" ReadOnly="True" 
                        Text='<%# Bind("Machinenumber") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Machinenumber") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Task Frequency" SortExpression="frequency">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("frequency") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        SelectedValue='<%# Bind("frequency") %>'>
                        <asp:ListItem Value="">PLEASE SELECT</asp:ListItem>
			<asp:ListItem value="1">Daily (1)</asp:ListItem>
                        <asp:ListItem Value="7">Weekly (7)</asp:ListItem>
                        <asp:ListItem Value="14">BI-WEEKLY (14)</asp:ListItem>
                        <asp:ListItem Value="30">Month (30)</asp:ListItem>
                        <asp:ListItem Value="45">BI QUARTERLY (45)</asp:ListItem>
                        <asp:ListItem Value="60">BI-MONTHLY (60)</asp:ListItem>
                        <asp:ListItem Value="90">QUARTERLY (90)</asp:ListItem>
                        <asp:ListItem Value="120">THIRDLY (120)</asp:ListItem>
                        <asp:ListItem Value="180">SEMI-ANNUAL (180)</asp:ListItem>
                        <asp:ListItem Value="365">ANNUAL (365)</asp:ListItem>
                    </asp:DropDownList>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("frequency") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Task" SortExpression="task">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("task") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Height="60px" 
                        Text='<%# Bind("task") %>' TextMode="MultiLine" Width="500px"></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("task") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Start Date" SortExpression="StartingDate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("StartingDate") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("StartingDate") %>'></asp:TextBox>
                    <asp:CalendarExtender ID="TextBox5_CalendarExtender" runat="server" 
                        TargetControlID="TextBox5">
                    </asp:CalendarExtender>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("StartingDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ScheduleID" HeaderText="ScheduleID" 
                InsertVisible="False" ReadOnly="True" SortExpression="ScheduleID" />
            <asp:CommandField ButtonType="Button" InsertText="Submit" 
                ShowInsertButton="True">
            <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="srcPMSchedule" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TESTQTYConnectionString %>" 
        DeleteCommand="DELETE FROM [tbl_PM_Schedule] WHERE [ScheduleID] = @ScheduleID" 
        InsertCommand="INSERT INTO [tbl_PM_Schedule] ([Division], [Machinenumber], [frequency], [task], [StartingDate]) VALUES (@Division, @Machinenumber, @frequency, @task, @StartingDate)" 
        SelectCommand="SELECT [Division], [Machinenumber], [frequency], [task], [StartingDate], [ScheduleID] FROM [tbl_PM_Schedule] ORDER BY [ScheduleID] DESC" 
        UpdateCommand="UPDATE [tbl_PM_Schedule] SET [Division] = @Division, [Machinenumber] = @Machinenumber, [frequency] = @frequency, [task] = @task, [StartingDate] = @StartingDate WHERE [ScheduleID] = @ScheduleID">
        <DeleteParameters>
            <asp:Parameter Name="ScheduleID" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Division" Type="String" />
            <asp:Parameter Name="Machinenumber" Type="String" />
            <asp:Parameter Name="frequency" Type="Decimal" />
            <asp:Parameter Name="task" Type="String" />
            <asp:Parameter Name="StartingDate" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Division" Type="String" />
            <asp:Parameter Name="Machinenumber" Type="String" />
            <asp:Parameter Name="frequency" Type="Decimal" />
            <asp:Parameter Name="task" Type="String" />
            <asp:Parameter Name="StartingDate" Type="DateTime" />
            <asp:Parameter Name="ScheduleID" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    To update a task, click on the "Record #" from the list below. 
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ScheduleID" DataSourceID="srcPM" Width="902px" 
        CellPadding="4" ForeColor="#333333" 
        EmptyDataText="No Data Returned">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Record #" InsertVisible="False" 
                SortExpression="ScheduleID">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ScheduleID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl='<%# Bind("ScheduleID", "~/PMScheduleEdit.aspx?ScheduleID={0}") %>' 
                        Text='<%# Eval("ScheduleID") %>' Target="_blank"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Machinenumber" HeaderText="Machine #" 
                SortExpression="Machinenumber" />
            <asp:BoundField DataField="Division" HeaderText="Schedule Division" 
                SortExpression="Division" />

                
            <asp:BoundField DataField="task" HeaderText="Task" SortExpression="task" />
            <asp:BoundField DataField="frequency" HeaderText="Frequency" 
                SortExpression="frequency" />
            <asp:BoundField DataField="activetask" HeaderText="Active Task?" 
                SortExpression="activetask" />
            <asp:BoundField DataField="StartingDate" DataFormatString="{0:d}" 
                HeaderText="Start Date" SortExpression="StartingDate" />
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
        ConnectionString="<%$ ConnectionStrings:TESTQTYConnectionString %>" 
        SelectCommand="SELECT ScheduleID, Machinenumber, Division, frequency, task, tasktype, activetask, StartingDate, dateentered FROM tbl_PM_Schedule WHERE (Machinenumber = @machineNumber) ORDER BY tasktype DESC, task">
        <SelectParameters>
            <asp:QueryStringParameter Name="machineNumber" 
                QueryStringField="Machinenumber" />
        </SelectParameters>
    </asp:SqlDataSource>
    </fieldset>
</asp:Content>

