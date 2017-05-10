<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="PMScheduleEdit.aspx.cs" Inherits="PMScheduleEdit" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<fieldset><legend>Please edit your task and click SUBMIT. Close This Window Once Done Editing.
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </legend>
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        DataKeyNames="ScheduleID" DataSourceID="srcPM" DefaultMode="Edit" 
        Height="50px" onitemupdated="DetailsView1_ItemUpdated" 
        onitemupdating="DetailsView1_ItemUpdating">
        <Fields>
            <asp:BoundField DataField="ScheduleID" HeaderText="ScheduleID" 
                InsertVisible="False" ReadOnly="True" SortExpression="ScheduleID" />
            <asp:BoundField DataField="Machinenumber" HeaderText="Machinenumber" 
                ReadOnly="True" SortExpression="Machinenumber" />
            <asp:TemplateField HeaderText="Schedule Division" SortExpression="Division">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlDivision" runat="server" DataSourceID="sqlDivision" AutoPostBack="true"
                        DataTextField="division" DataValueField="division"  SelectedValue='<%# Bind("Division") %>'>
                    </asp:DropDownList>

                    <asp:SqlDataSource ID="sqlDivision" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:HRDBConnectionString %>" 
                        SelectCommand="ActiveDivisions" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Division") %>'></asp:TextBox>

                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Division") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="StartingDate" SortExpression="StartingDate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" 
                        Text='<%# Bind("StartingDate", "{0:d}") %>'></asp:TextBox>
                    <asp:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                        TargetControlID="TextBox1">
                    </asp:CalendarExtender>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("StartingDate") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("StartingDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="frequency" SortExpression="frequency">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        SelectedValue='<%# Bind("frequency") %>'>
                        <asp:ListItem>PLEASE SELECT</asp:ListItem>
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
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("frequency") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("frequency") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="task" SortExpression="task">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Height="60px" 
                        Text='<%# Bind("task") %>' TextMode="MultiLine" Width="500px"></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("task") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("task") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="activetask" SortExpression="activetask">
                <EditItemTemplate>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                        RepeatDirection="Horizontal" SelectedValue='<%# Bind("activetask") %>'>
                        <asp:ListItem Value="Y">YES</asp:ListItem>
                        <asp:ListItem Value="N">NO</asp:ListItem>
                    </asp:RadioButtonList>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("activetask") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("activetask") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" EditText="Submit" ShowEditButton="True" 
                UpdateText="Submit">
            <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="srcPM" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TESTQTYConnectionString %>" 
        DeleteCommand="DELETE FROM [tbl_PM_Schedule] WHERE [ScheduleID] = @ScheduleID" 
        InsertCommand="INSERT INTO [tbl_PM_Schedule] ([Machinenumber], [StartingDate], [frequency], [task], [tasktype]) VALUES (@Machinenumber, @StartingDate, @frequency, @task, @tasktype)" 
        SelectCommand="SELECT ScheduleID, Machinenumber, StartingDate, frequency, task, activetask, Division FROM tbl_PM_Schedule WHERE (ScheduleID = @ScheduleID)" 
        
        
        
        UpdateCommand="UPDATE [tbl_PM_Schedule] SET  [StartingDate] = @StartingDate, [frequency] = @frequency, [task] = @task, [activetask] = @activetask , [Division] = @Division WHERE [ScheduleID] = @ScheduleID">
        <DeleteParameters>
            <asp:Parameter Name="ScheduleID" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Machinenumber" Type="String" />
            <asp:Parameter Name="StartingDate" Type="DateTime" />
            <asp:Parameter Name="frequency" Type="Decimal" />
            <asp:Parameter Name="task" Type="String" />
            <asp:Parameter Name="tasktype" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="ScheduleID" QueryStringField="ScheduleID" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="StartingDate" Type="DateTime" />
            <asp:Parameter Name="frequency" Type="Decimal" />
            <asp:Parameter Name="task" Type="String" />
            <asp:Parameter Name="activetask" />
            <asp:Parameter Name="Divsion" Type="String" />
            <asp:Parameter Name="ScheduleID" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </fieldset>
</asp:Content>

