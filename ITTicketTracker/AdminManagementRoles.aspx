<%@ Page Title="Roles Management" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AdminManagementRoles.aspx.cs" Inherits="AdminManagementRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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
    <asp:RadioButtonList runat="server" ID="rblRoles" RepeatDirection="Horizontal" 
        AutoPostBack="true" onselectedindexchanged="rblRoles_SelectedIndexChanged">
            <asp:ListItem Value="1" Text="Create Role" />
            <asp:ListItem Value="2" Text="Edit Role" />
    </asp:RadioButtonList>
    <br />
    <br />

    <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ForeColor="Red" Visible="false"/>
    
    <asp:Panel ID="pCreateRole" runat="server" Visible="false">
    <fieldset>
        <legend>Create Role</legend>
    
        <asp:DetailsView ID="dvCreateRole" runat="server"  DefaultMode="Insert" Width="300px"
                AutoGenerateRows="False" DataKeyNames="roleID"  
            DataSourceID="sqlMangeRoles" oniteminserted="dvCreateRole_ItemInserted" >
            <Fields>
                <asp:BoundField DataField="roleID" HeaderText="roleID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="roleID" />
                <asp:BoundField DataField="roleName" HeaderText="Role Name" 
                    SortExpression="roleName" />
                <asp:CommandField ShowInsertButton="True" ButtonType="Button" />
            </Fields>
        </asp:DetailsView>
    </fieldset> 
    </asp:Panel>

    <asp:Panel ID="pEditRole" runat="server" Visible="false">
    <fieldset>
        <legend>Edit Role</legend>
    
        <b>Role :</b> <asp:DropDownList ID="ddlRoles" runat="server" 
            DataSourceID="sqlRoles" DataTextField="roleName" DataValueField="roleID" AutoPostBack="true"></asp:DropDownList>
        <asp:DetailsView ID="dvEditRole" runat="server"  DefaultMode="Edit" Width="300px"
        AutoGenerateRows="False" DataKeyNames="roleID"  DataSourceID="sqlMangeRoles" 
            onitemupdated="dvEditRole_ItemUpdated" >
            <Fields>
                <asp:BoundField DataField="roleID" HeaderText="roleID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="roleID" />
                <asp:BoundField DataField="roleName" HeaderText="Role Name" 
                    SortExpression="roleName" />
                <asp:CommandField ShowEditButton="True" ButtonType="Button" />
            </Fields>
        </asp:DetailsView>
    </fieldset>
    </asp:Panel>

  


      <asp:SqlDataSource ID="sqlMangeRoles" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
            InsertCommand="ADMIN_INSERT_ROLE" InsertCommandType="StoredProcedure" 
            SelectCommand="SELECT roleID, roleName FROM tbl_Roles WHERE (roleID = @roleID)" 
            UpdateCommand="ADMIN_EDIT_ROLE" UpdateCommandType="StoredProcedure">
            <InsertParameters>
                <asp:Parameter Name="roleName" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlRoles" DefaultValue="0" Name="roleID" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="roleName" Type="String" />
                <asp:Parameter Name="roleID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlRoles" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
        SelectCommand="SELECT roleID, roleName FROM tbl_Roles"></asp:SqlDataSource>
</asp:Content>

