<%@ Page Title="Subsystem Management" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AdminManagementSubsystem.aspx.cs" Inherits="AdminManagementSubsystem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
     .checkboxClass
     {
         padding:10px;
     }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
    <legend>Admin Management</legend>
    <asp:Button runat="server" ID="btnMangeUsers" Text="Manage Users" onclick="btnMangeUsers_Click" /> 
    <asp:Button runat="server" ID="btnManageRoles" Text="Manage Roles"  onclick="btnManageRoles_Click" /> 
    <asp:Button runat="server" ID="btnManageSystem" Text="Manage Systems" onclick="btnManageSystem_Click" /> 
    <asp:Button runat="server" ID="btnManageSubsystems" Text="Manage Subsystems" onclick="btnManageSubsystems_Click" />
    <asp:Button runat="server" ID="btnMangeNotify" Text="Manage User Notifications" onclick="btnMangeNotify_Click" />
</fieldset>
    <asp:RadioButtonList runat="server" ID="rblManageSubsystems" RepeatDirection="Horizontal" 
        AutoPostBack="true" 
        onselectedindexchanged="rblManageSubsystems_SelectedIndexChanged" >
            <asp:ListItem Value="1" Text="Create Subsystem" />
            <asp:ListItem Value="2" Text="Edit Subsystem" />
            <asp:ListItem Value="3" Text="Assign Role To Subsystem" />
    </asp:RadioButtonList>
    <br />
    <br />
    <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ForeColor="Red" Visible="false"/>

    <asp:Panel ID="pCreateSubsystem" runat="server" Visible="false">
        <fieldset>
            <legend>Create Subsystem</legend>

            <asp:DetailsView ID="dvCreateSubsystem" runat="server"  DefaultMode="Insert" Width="500px"
                AutoGenerateRows="False" DataSourceID="sqlManageSubsystem" 
                oniteminserted="dvCreateSubsystem_ItemInserted">
            <Fields>
                <asp:TemplateField HeaderText="System ID :" SortExpression="SystemID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SystemID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="sqlSystems"
                            DataTextField="System" DataValueField="SystemID" SelectedValue='<%# Bind("SystemID") %>'>
                        </asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("SystemID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SubSystem" HeaderText="Subsystem Name :" 
                    SortExpression="SubSystem" />

                <asp:CheckBoxField DataField="active" HeaderText="Active :" 
                    SortExpression="active" />

                <asp:CommandField ShowInsertButton="True" ButtonType="Button" />

            </Fields>
        </asp:DetailsView>

        </fieldset>
    </asp:Panel>

    <asp:Panel ID="pEditSubsystem" runat="server" Visible="false">
        <fieldset>
            <legend>Edit Subsystem</legend>
            <b>System :</b> <asp:DropDownList ID="ddlSystem" runat="server" AutoPostBack="true"
                DataSourceID="sqlSystems" DataTextField="System" DataValueField="SystemID" 
                onselectedindexchanged="ddlSystem_SelectedIndexChanged"></asp:DropDownList> <br />
            <b>Subsystem :</b> <asp:DropDownList ID="ddlSubsystem" runat="server" DataSourceID="sqlSubSystems" DataTextField="SubSystem" 
                DataValueField="SubSystemID" AutoPostBack="true"/>
            <br />
            <asp:DetailsView ID="dvEditSubsystem" runat="server"  DefaultMode="Edit" Width="400px"
                AutoGenerateRows="False" DataSourceID="sqlManageSubsystem" 
                onitemupdated="dvEditSubsystem_ItemUpdated">
            <Fields>
                <asp:TemplateField HeaderText="System :" SortExpression="SystemID">
                    <EditItemTemplate>
                        <asp:Label ID="TextBox1" runat="server" Text='<%# Bind("SystemID") %>'></asp:Label>
                    </EditItemTemplate>
                    <InsertItemTemplate>`
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="sqlSystems"
                            DataTextField="System" DataValueField="SystemID" SelectedValue='<%# Bind("SystemID") %>'>
                        </asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("SystemID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="System ID:" SortExpression="SystemID">
                    <EditItemTemplate>
                        <asp:Label ID="TextBox13" runat="server" Text='<%# Bind("SubSystemID") %>'></asp:Label>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:Label ID="TextBox12" runat="server" Text='<%# Bind("SubSystemID") %>'></asp:Label>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("SubSystemID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SubSystem" HeaderText="Subsystem Name :" 
                    SortExpression="SubSystem" />
                <asp:CheckBoxField DataField="active" HeaderText="Active :" 
                    SortExpression="active" />

                <asp:CommandField ShowEditButton="True" ButtonType="Button" />

            </Fields>
        </asp:DetailsView>
        </fieldset>
    </asp:Panel>

    <asp:Panel ID="pSubsystemToSystem" runat="server" Visible="false">
        <fieldset>
            <legend>Assign Subsystem To System</legend>
            <b>System :</b> <asp:DropDownList ID="ddlSystem2" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
                DataSourceID="sqlSystems" DataTextField="System" DataValueField="SystemID" 
                onselectedindexchanged="ddlSystem2_SelectedIndexChanged">
                    <asp:ListItem Value="" Text="PLEASE SELECT" />
                </asp:DropDownList> <br />
            <b>Subsystem :</b> <asp:DropDownList ID="ddlSubsystem2" runat="server" 
                DataSourceID="sqlSubsystem2" DataTextField="SubSystem" DataValueField="SubSystemID" AutoPostBack="true" AppendDataBoundItems="true"
                onselectedindexchanged="ddlSubsystem2_SelectedIndexChanged">
                    <asp:ListItem Value="" Text="PLEASE SELECT" />
                </asp:DropDownList>
            <br />
            <asp:Button ID="btnViewRoles" runat="server" Text="View Roles" 
                onclick="btnViewRoles_Click" />
            <br />
            <br />
                <div id="divRoles" runat="server" style="border:2px;">
                    <asp:CheckBoxList ID="cblRoles" runat="server" />
                </div>
            <br />
            <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
            <br />
            <br />
        </fieldset>
    </asp:Panel>
    

    
    <asp:SqlDataSource ID="sqlManageSubsystem" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
        InsertCommand="ADMIN_INSERT_SUBSYSTEM" InsertCommandType="StoredProcedure" 
        SelectCommand="SELECT active, SubSystem, SubSystemID, SystemID FROM tbl_SubSystem WHERE (SystemID = @SystemID) AND (SubSystemID = @SubSystemID)" 
        UpdateCommand="ADMIN_EDIT_SUBSYSTEM" UpdateCommandType="StoredProcedure">
        <InsertParameters>
            <asp:Parameter Name="SystemID" Type="Decimal" />
            <asp:Parameter Name="SubSystem" Type="String" />
            <asp:Parameter Name="active" Type="Boolean" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlSystem" DefaultValue="1" Name="SystemID" 
                PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="ddlSubsystem" DefaultValue="1" 
                Name="SubSystemID" PropertyName="SelectedValue" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="SystemID" Type="Decimal" />
            <asp:Parameter Name="SubsystemID" Type="Decimal" />
            <asp:Parameter Name="SubSystem" Type="String" />
            <asp:Parameter Name="active" Type="Boolean" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sqlSystems" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
        
        
        SelectCommand="SELECT SystemID, System FROM tbl_system_type WHERE Active = 1 ORDER BY System">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sqlSubSystems" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
        SelectCommand="SELECT SubSystemID, SubSystem FROM tbl_SubSystem WHERE SystemID = @SystemID">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlSystem" DefaultValue="" Name="SystemID" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sqlSubsystem2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
        
        SelectCommand="SELECT SubSystemID, SubSystem FROM tbl_SubSystem WHERE SystemID = @SystemID AND Active = 1 ">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlSystem2" DefaultValue="" Name="SystemID" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

