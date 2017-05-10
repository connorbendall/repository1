<%@ Page Title="System Management" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AdminManagementSystem.aspx.cs" Inherits="AdminManagementSystem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <fieldset>
        <legend>Admin Management</legend>
        <asp:Button runat="server" ID="btnMangeUsers" Text="Manage Users" onclick="btnMangeUsers_Click" /> 
        <asp:Button runat="server" ID="btnManageRoles" Text="Manage Roles"  onclick="btnManageRoles_Click" /> 
        <asp:Button runat="server" ID="btnManageSystem" Text="Manage Systems" onclick="btnManageSystem_Click" /> 
        <asp:Button runat="server" ID="btnManageSubsystems" Text="Manage Subsystems" onclick="btnManageSubsystems_Click" />
        <asp:Button runat="server" ID="btnMangeNotify" Text="Manage User Notifications" 
            onclick="btnMangeNotify_Click" />

    </fieldset>

    <asp:RadioButtonList runat="server" ID="rblManageSystem" 
        RepeatDirection="Horizontal" AutoPostBack="true" onselectedindexchanged="rblManageSystem_SelectedIndexChanged"
           >
                <asp:ListItem Value="1" Text="Create System" />
                <asp:ListItem Value="2" Text="Edit System" />
    </asp:RadioButtonList>
    <br />
    <br />
    <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ForeColor="Red" Visible="false"/>
<%--Start Create System--%>
    <asp:Panel ID="pCreateSystem" runat="server" Visible="false">
    <fieldset>
        <legend>Create System</legend>

          <asp:DetailsView ID="dvCreateSystem" runat="server"  DefaultMode="Insert" Width="300px"
            AutoGenerateRows="False" DataSourceID="sqlManageSystem" 
            oniteminserted="dvCreateSystem_ItemInserted" >
              <Fields>
                  <asp:BoundField DataField="System" HeaderText="System :" SortExpression="System" />
                  <asp:TemplateField HeaderText="Report From :" SortExpression="reportFrom">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("reportFrom") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <InsertItemTemplate>
                          <asp:DropDownList ID="ddlReportFrom" runat="server" SelectedValue='<%# Bind("reportFrom") %>'>
                            <asp:ListItem Text="YES" Value="YES" />
                            <asp:ListItem Text="NO" Value="NO" />
                          </asp:DropDownList>
                      </InsertItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label1" runat="server" Text='<%# Bind("reportFrom") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:CheckBoxField DataField="active" HeaderText="Active" 
                      SortExpression="active" />
                  <asp:CommandField ShowInsertButton="True" ButtonType="Button" />
              </Fields>
        </asp:DetailsView>
    </fieldset>
    </asp:Panel>
<%--End Create System--%>

<%--Start Edit System--%>
    <asp:Panel ID="pEditSystem" runat="server" Visible="false">
    <fieldset>
        <legend>Edit System</legend>
        <b>System :</b> <asp:DropDownList ID="ddlSystem" runat="server" 
            AutoPostBack="True" DataSourceID="sqlSystem" DataTextField="System" 
            DataValueField="SystemID"></asp:DropDownList>

            <asp:DetailsView ID="dvEditSystem" runat="server"  DefaultMode="Edit" Width="300px"
            AutoGenerateRows="False" DataSourceID="sqlManageSystem" 
            onitemupdated="dvEditSystem_ItemUpdated" >
              <Fields>
                  <asp:TemplateField HeaderText="System ID :" SortExpression="SystemID">
                      <EditItemTemplate>
                          <asp:Label ID="lblSysID" runat="server" Text='<%# Bind("SystemID") %>'></asp:Label>
                      </EditItemTemplate>
                      <InsertItemTemplate>
                          <asp:TextBox ID="TextBox112" runat="server" Text='<%# Bind("SystemID") %>'></asp:TextBox>
                      </InsertItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label222" runat="server" Text='<%# Bind("SystemID") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                <asp:BoundField DataField="System" HeaderText="System :" SortExpression="System" />
                  <asp:TemplateField HeaderText="Report From :" SortExpression="reportFrom">
                      <EditItemTemplate>
                          <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("reportFrom") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <InsertItemTemplate>
                          <asp:DropDownList ID="ddlReportFrom" runat="server" SelectedValue='<%# Bind("reportFrom") %>'>
                            <asp:ListItem Text="YES" Value="YES" />
                            <asp:ListItem Text="NO" Value="NO" />
                          </asp:DropDownList>
                      </InsertItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label1" runat="server" Text='<%# Bind("reportFrom") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:CheckBoxField DataField="active" HeaderText="Active" 
                      SortExpression="active" />
                  <asp:CommandField ShowEditButton="True" ButtonType="Button" />
              </Fields>
        </asp:DetailsView>

    </fieldset>
    </asp:Panel>

        <asp:SqlDataSource ID="sqlSystem" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
            SelectCommand="SELECT SystemID, System FROM tbl_system_type ORDER BY System">
        </asp:SqlDataSource>
<%--End Edit System--%>


    
        <asp:SqlDataSource ID="sqlManageSystem" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
            InsertCommand="ADMIN_INSERT_SYSTEM" InsertCommandType="StoredProcedure" 
            SelectCommand="SELECT SystemID , System , internalsupport , reportfrom , active FROM tbl_system_type WHERE (SystemID = @SystemID)" 
            UpdateCommand="ADMIN_EDIT_SYSTEM" UpdateCommandType="StoredProcedure">
            <InsertParameters>
                <asp:Parameter Name="System" Type="String" />
                <asp:Parameter Name="interalsupport" Type="String" DefaultValue="Information Services" />
                <asp:Parameter Name="reportFrom" Type="String" />
                <asp:Parameter Name="active" Type="Boolean" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlSystem" DefaultValue="1" Name="SystemID" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="SystemID" Type="Decimal" />
                <asp:Parameter Name="System" Type="String" />
                <asp:Parameter Name="interalsupport" Type="String" DefaultValue="Information Services"/>
                <asp:Parameter Name="reportFrom" Type="String" />
                <asp:Parameter Name="active" Type="Boolean" />
            </UpdateParameters>
        </asp:SqlDataSource>
</asp:Content>

