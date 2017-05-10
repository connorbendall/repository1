<%@ Page Title="User Management" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AdminManagementUser.aspx.cs" Inherits="AdminManagementUser" %>

   
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
     .checkboxClass
     {
         padding:10px;
     }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<fieldset>
    <legend>Admin Management</legend>
    <asp:Button runat="server" ID="btnMangeUsers" Text="Manage IT Users" onclick="btnMangeUsers_Click" /> 
    <asp:Button runat="server" ID="btnManageRoles" Text="Manage Roles"  onclick="btnManageRoles_Click" /> 
    <asp:Button runat="server" ID="btnManageSystem" Text="Manage Systems" onclick="btnManageSystem_Click" /> 
    <asp:Button runat="server" ID="btnManageSubsystems" Text="Manage Subsystems" onclick="btnManageSubsystems_Click" />
    <asp:Button runat="server" ID="btnMangeNotify" Text="Manage User Notifications" onclick="btnMangeNotify_Click" />
    <asp:Button runat="server" ID="btnManageSavedUsers" Text="Manage Saved Users" onclick="btnMangeSavedUsers_Click" />

</fieldset>
   <asp:RadioButtonList runat="server" ID="rblUsers" RepeatDirection="Horizontal" AutoPostBack="true"
            onselectedindexchanged="rblUsers_SelectedIndexChanged">
            <asp:ListItem Value="1" Text="Create User" />
            <asp:ListItem Value="2" Text="Edit User" />
            <asp:ListItem Value="3" Text="Assign User Rolls" />
    </asp:RadioButtonList>
    <br />
    <br />
    <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ForeColor="Red" Visible="false"/>
<%-- Start of Edit User--%>
    <asp:Panel ID="pEditUser" runat="server" Visible="false">
    <fieldset>
        <legend>Edit User</legend>
             
        <b>User:</b> <asp:DropDownList ID="ddlITUsers" runat="server" DataSourceID="sqlITUsers" 
                DataTextField="user" DataValueField="userId" AutoPostBack="true" 
            onselectedindexchanged="ddlITUsers_SelectedIndexChanged" />
        <br />
        <br />
        <asp:DetailsView ID="dvUpdateUser" runat="server"  DefaultMode="Edit"
            AutoGenerateRows="False" DataKeyNames="userId" Width="300"
            DataSourceID="sqlCreateUser" onitemupdated="dvUpdateUser_ItemUpdated" >
            <Fields>
                <asp:BoundField DataField="userId" HeaderText="User ID:" SortExpression="userId" 
                    InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="user" HeaderText="User Name :" 
                    SortExpression="user" />
                <asp:BoundField DataField="email" HeaderText="E-mail :" 
                    SortExpression="email" />
                <asp:TemplateField HeaderText="Status :" SortExpression="status">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlStatusUpdate" runat="server" SelectedValue='<%# Bind("status") %>'>
                            <asp:ListItem Value="A" Text="Active" />
                            <asp:ListItem Value="E" Text="Emails" />
                            <asp:ListItem Value="I" Text="Inactive" />
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:DropDownList ID="ddlStatusUpdate1" runat="server">
                            <asp:ListItem Value="A" Text="Active" />
                            <asp:ListItem Value="E" Text="Emails" />
                            <asp:ListItem Value="I" Text="Inactive" />
                        </asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ButtonType="Button" />
            </Fields>
        </asp:DetailsView>     
    </fieldset>                 
    </asp:Panel>
<%-- End of Edit User--%>

<%-- Start of Create User--%>
    <asp:Panel ID="pCreate" runat="server" Visible="false">
    <fieldset>
        <legend>Create New IT User</legend>
    
        <asp:DetailsView ID="dvCreateUser" runat="server"  DefaultMode="Insert" Width="300"
            AutoGenerateRows="False" DataKeyNames="userId" 
            DataSourceID="sqlCreateUser" oniteminserted="dvCreateUser_ItemInserted">
            <Fields>
                <asp:BoundField DataField="userId" HeaderText="userId" SortExpression="userId" 
                    InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="user" HeaderText="User Name :" 
                    SortExpression="user" />
                <asp:BoundField DataField="email" HeaderText="E-mail :" 
                    SortExpression="email" />
                <asp:TemplateField HeaderText="Status :" SortExpression="status">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:DropDownList ID="ddlStatus" runat="server" SelectedValue='<%# Bind("status") %>'>
                            <asp:ListItem Value="A" Text="Active" />
                            <asp:ListItem Value="E" Text="Emails" />
                            <asp:ListItem Value="I" Text="Inactive" />
                        </asp:DropDownList>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowInsertButton="True" ButtonType="Button" />
            </Fields>
        </asp:DetailsView>
    </fieldset>                
    </asp:Panel>
<%-- End of Create User--%>

<%-- Start of Roles Assign --%>
    <asp:Panel ID="pAssignRoles" runat="server" Visible="false">
    <fieldset>
        <legend>Assign User Roles</legend>
        
        <b>User:</b> <asp:DropDownList ID="ddlUser1" runat="server" 
            DataSourceID="sqlGetITActive" DataTextField="user" DataValueField="userId" AppendDataBoundItems="True"
            AutoPostBack="True" 
            onselectedindexchanged="ddlUser1_SelectedIndexChanged" >
                <asp:ListItem Value="" Text="PLEASE SELECT" />
            </asp:DropDownList>
        <asp:SqlDataSource ID="sqlGetITActive" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
            SelectCommand="SELECT userId, [user] FROM tbl_IT_users WHERE (status = 'A')">
        </asp:SqlDataSource>
        <asp:Button ID="btnViewRoles" runat="server" Text="View Roles" 
            onclick="btnViewRoles_Click" />
        <br />
        <br />
        <div id="divRoles" runat="server" style="border:2px;"></div>
     


        <asp:Button ID="btnSave" runat="server" Text="Save Roles" 
            onclick="btnSave_Click"/>
        <br />
        <br />
        <asp:GridView ID="gvITUserRoles" runat="server" AutoGenerateColumns="False" 
            DataSourceID="sqlITUserRoles" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="user" HeaderText="User" SortExpression="user" />
                <asp:BoundField DataField="roleName" HeaderText="Role" 
                    SortExpression="roleName" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sqlITUserRoles" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
            SelectCommand="ADMIN_GET_ITUSER_ROLES" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
    </fieldset>
    </asp:Panel>
<%-- End of Roles Assign --%>
   <asp:SqlDataSource ID="sqlCreateUser" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                        InsertCommand="ADMIN_INSERT_ITUSER" InsertCommandType="StoredProcedure" 
                        SelectCommand="SELECT userId, [user], status, [e-mail] as 'email' FROM tbl_IT_users WHERE (userId = @userId)" 
                        UpdateCommand="ADMIN_EDIT_ITUSER" 
        UpdateCommandType="StoredProcedure"  >
                        <InsertParameters>
                            <asp:Parameter Name="user" Type="String" />
                            <asp:Parameter Name="status" Type="String" />
                            <asp:Parameter Name="email" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlITUsers" DefaultValue="1" Name="userId" 
                                PropertyName="SelectedValue" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:ControlParameter ControlID="ddlITUsers" Type="Decimal" Name="userId"  />
                            <asp:Parameter Name="user" Type="String" />
                            <asp:Parameter Name="status" Type="String" />
                            <asp:Parameter Name="email" Type="String" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlITUsers" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                        
        
    
        SelectCommand="SELECT userId, [user], status, [e-mail] FROM tbl_IT_users WHERE status ='A' OR status = 'E' ORDER BY [user]">
                    </asp:SqlDataSource>
</asp:Content>

