<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AdminManageNotifySettings.aspx.cs" Inherits="AdminManageNotifySettings" %>

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
    <br />
    <asp:RadioButtonList ID="rblReportType" runat="server" AutoPostBack="true" Font-Bold="true"
        RepeatDirection="Horizontal" 
        onselectedindexchanged="rblReportType_SelectedIndexChanged">
        <asp:ListItem Value="1" Text="View By Subsystem" />
        <asp:ListItem Value="2" Text="View By User" />
    </asp:RadioButtonList>
    <br />

<div id="divBySubsystem" runat="server" visible="false">
<fieldset>
    <legend>Notifications By Subsystem</legend>
    
    
    <table>
        <tr>
            <td>
                <b>User Status:</b>
            </td>
            <td>
                <asp:RadioButtonList ID="rblUserStatus" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                    <asp:ListItem Text="Active" Value="A" Selected="True" />
                    <asp:ListItem Text="Inactive" Value="I" />
                </asp:RadioButtonList>
            </td>
            <td rowspan="3">
                &nbsp;&nbsp;&nbsp;User Status Flags :
                <ul>
                    <li><b>I</b>- Inactive</li>
                    <li><b>A</b> - Active IT User</li>
                    <li><b>E</b>- Active Email Only</li>
                </ul>
            </td>
        </tr>
        <tr>
            <td>
                <b>System :</b> 
            </td>
            <td>
                <asp:DropDownList ID="ddlSystem" runat="server" AutoPostBack="true" DataSourceID="sqlSystems"
                     DataTextField="System" DataValueField="SystemID" AppendDataBoundItems="true">
                        <asp:ListItem Text="PLEASE SELECT" Value="-1"/>
                     </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <b>Subsystem :</b>
            </td>
            <td>
                <asp:DropDownList ID="ddlSubsystem" runat="server" DataSourceID="sqlSubSystems" DataTextField="SubSystem" 
                DataValueField="SubSystemID" AutoPostBack="true" AppendDataBoundItems="true">
                        <asp:ListItem Text="PLEASE SELECT" Value="-1"/>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    
     
    <br />



    <asp:GridView ID="gridReports" runat="server"
    CellPadding="5" ForeColor="#333333" GridLines="None" AllowSorting="True" AutoGenerateColumns="False" 
     CssClass="GRVIEW" DataSourceID="sqlNotify"
        onrowupdating="gridReports_RowUpdating" >
        <AlternatingRowStyle BackColor="White" />
            <Columns>               
                <asp:BoundField DataField="userId" HeaderText="User ID" ReadOnly="true" SortExpression="userId" />
                <asp:BoundField DataField="user" HeaderText="User" ReadOnly="True" 
                    SortExpression="user" />
                <asp:BoundField DataField="status" HeaderText="User Status" ReadOnly="True" 
                    SortExpression="status" />
                <asp:TemplateField HeaderText="Open" >
                    <EditItemTemplate>
                        <asp:CheckBox ID="cbOpen" runat="server" Checked='<%# Convert.ToBoolean(Eval("openNotify")) %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbOpen" runat="server" Checked='<%# Convert.ToBoolean(Eval("openNotify")) %>' Enabled="false"/>                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Closed" >
                    <EditItemTemplate>
                        <asp:CheckBox ID="cbClosed" runat="server" Checked='<%# Convert.ToBoolean(Eval("closedNotify")) %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbClosed" runat="server" Checked='<%# Convert.ToBoolean(Eval("closedNotify")) %>' Enabled="false"/>                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Verified" >
                    <EditItemTemplate>
                        <asp:CheckBox ID="cbVerified" runat="server" Checked='<%# Convert.ToBoolean(Eval("verifiedNotify")) %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbVerified" runat="server" Checked='<%# Convert.ToBoolean(Eval("verifiedNotify")) %>' Enabled="false"/>                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Assinged" >
                    <EditItemTemplate>
                        <asp:CheckBox ID="cbAssinged" runat="server" Checked='<%# Convert.ToBoolean(Eval("assingedNotify")) %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbAssinged" runat="server" Checked='<%# Convert.ToBoolean(Eval("assingedNotify")) %>' Enabled="false"/>                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Updated" >
                    <EditItemTemplate>
                        <asp:CheckBox ID="cbUpdated" runat="server" Checked='<%# Convert.ToBoolean(Eval("updatedNotify")) %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbUpdated" runat="server" Checked='<%# Convert.ToBoolean(Eval("updatedNotify")) %>' Enabled="false"/>                        
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:CommandField ShowEditButton="true" ButtonType="Button" />
            </Columns>
        <EditRowStyle BackColor="#FFFF66" />
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

    <asp:SqlDataSource ID="sqlNotify" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
        SelectCommand="ADMIN_GET_NotifySettings" 
        SelectCommandType="StoredProcedure" 
        UpdateCommand="	IF(EXISTS(SELECT * FROM tbl_Ticket_Notify WHERE subSystem = @subsystem AND system = @system AND userID = @userID))
	                    BEGIN
		                    -- Update
		                    UPDATE tbl_Ticket_Notify  SET openNotify = @openNotify , closedNotify = @closedNotify, verifiedNotify = @verifiedNotify
		                    ,assingedNotify = @assingedNotify , updatedNotify = @updatedNotify 
		                    WHERE subSystem = @subSystem AND system = @system AND userID = @userID
	                    END
	                    ELSE
	                    BEGIN
		                    -- Insert 
		                    INSERT INTO tbl_Ticket_Notify (userID,system,subSystem,openNotify,updatedNotify,closedNotify,verifiedNotify,assingedNotify)
			                    VALUES(@userID,@system,@subSystem,@openNotify,@updatedNotify, @closedNotify,@verifiedNotify,@assingedNotify)
	                    END"
      UpdateCommandType="Text">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlSystem" Name="system" 
                PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="ddlSubsystem" Name="subsystem" 
                PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="rblUserStatus" Name="empType" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="system" Type="Int32" />
            <asp:Parameter Name="subSystem" Type="Int32" />
            <asp:Parameter Name="userID" Type="Int32" />
            <asp:Parameter Name="openNotify" Type="Int32" />
            <asp:Parameter Name="closedNotify" Type="Int32" />
            <asp:Parameter Name="verifiedNotify" Type="Int32" />
            <asp:Parameter Name="assingedNotify" Type="Int32" />
            <asp:Parameter Name="updatedNotify" Type="Int32" />
        </UpdateParameters>
        </asp:SqlDataSource>

    <asp:SqlDataSource ID="sqlSystems" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
        SelectCommand="SELECT SystemID, System FROM tbl_system_type WHERE Active = 1 ORDER BY System">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlSubsystems" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
        SelectCommand="SELECT SubSystemID, SubSystem FROM tbl_SubSystem WHERE SystemID = @SystemID AND Active = 1 ">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlSystem" DefaultValue="" Name="SystemID" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
</fieldset>
</div>
<div id="divByUser" runat="server" visible="false">

<fieldset>
    <legend>Notifications By User</legend>

     <table>
     <tr>
             <td>
                    <b>Subsystem Status:</b>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblSubStatus" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                        <asp:ListItem Text="Active" Value="1" Selected="True" />
                        <asp:ListItem Text="Inactive" Value="0" />
                    </asp:RadioButtonList>
                </td>
            </tr>
        <tr>
            <td><b>Users :</b></td>
            <td>
                <asp:DropDownList ID="ddlUsers" runat="server" DataSourceID="sqlITUsers" AutoPostBack="true"
                    DataTextField="user" DataValueField="userId" AppendDataBoundItems="true">
                        <asp:ListItem Text="PLEASE SELECT" Value="-1"/>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2"><b>Items Highlighted In <span style="background-color:#33FF66">Green</span> have Notifications Set-up</b></td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="GridView1" runat="server"
    CellPadding="5" ForeColor="#333333" GridLines="None" AllowSorting="True" AutoGenerateColumns="False" 
     CssClass="GRVIEW" DataSourceID="sqlNotifyByUser" 
        onrowupdating="GridView1_RowUpdating" 
        onrowdatabound="GridView1_RowDataBound" >
        <Columns> 
            <asp:BoundField DataField="sysID" HeaderText="System ID" ReadOnly="true" SortExpression="sysID" />
             <asp:BoundField DataField="System" HeaderText="System" ReadOnly="true" SortExpression="System" />
             <asp:BoundField DataField="subsystemID" HeaderText="Subsystem ID" ReadOnly="true" SortExpression="subsystemID" /> 
             <asp:BoundField DataField="SubSystem" HeaderText="Subsystem" ReadOnly="true" SortExpression="SubSystem" /> 
            <asp:TemplateField HeaderText="Open" >
                    <EditItemTemplate>
                        <asp:CheckBox ID="cbOpen" runat="server" Checked='<%# Convert.ToBoolean(Eval("openNotify")) %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbOpen" runat="server" Checked='<%# Convert.ToBoolean(Eval("openNotify")) %>' Enabled="false"/>                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Closed" >
                    <EditItemTemplate>
                        <asp:CheckBox ID="cbClosed" runat="server" Checked='<%# Convert.ToBoolean(Eval("closedNotify")) %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbClosed" runat="server" Checked='<%# Convert.ToBoolean(Eval("closedNotify")) %>' Enabled="false"/>                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Verified" >
                    <EditItemTemplate>
                        <asp:CheckBox ID="cbVerified" runat="server" Checked='<%# Convert.ToBoolean(Eval("verifiedNotify")) %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbVerified" runat="server" Checked='<%# Convert.ToBoolean(Eval("verifiedNotify")) %>' Enabled="false"/>                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Assinged" >
                    <EditItemTemplate>
                        <asp:CheckBox ID="cbAssinged" runat="server" Checked='<%# Convert.ToBoolean(Eval("assingedNotify")) %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbAssinged" runat="server" Checked='<%# Convert.ToBoolean(Eval("assingedNotify")) %>' Enabled="false"/>                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Updated" >
                    <EditItemTemplate>
                        <asp:CheckBox ID="cbUpdated" runat="server" Checked='<%# Convert.ToBoolean(Eval("updatedNotify")) %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbUpdated" runat="server" Checked='<%# Convert.ToBoolean(Eval("updatedNotify")) %>' Enabled="false"/>                        
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:CommandField ShowEditButton="true" ButtonType="Button" />
        </Columns>
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#FFFF66" />
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


    <asp:SqlDataSource ID="sqlNotifyByUser" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
        SelectCommand="ADMIN_GET_NotifySettings_ByUser" 
        SelectCommandType="StoredProcedure" UpdateCommand="
        	IF(EXISTS(SELECT * FROM tbl_Ticket_Notify WHERE subSystem = @subsystem AND system = @system AND userID = @userID))
            BEGIN
		        -- Update
		        UPDATE tbl_Ticket_Notify  SET openNotify = @openNotify , closedNotify = @closedNotify, verifiedNotify = @verifiedNotify
		        ,assingedNotify = @assingedNotify , updatedNotify = @updatedNotify 
		        WHERE subSystem = @subSystem AND system = @system AND userID = @userID
	       END
	       ELSE
	       BEGIN
		        -- Insert
		        INSERT INTO tbl_Ticket_Notify (userID,system,subSystem,openNotify,updatedNotify,closedNotify,verifiedNotify,assingedNotify)
			        VALUES(@userID,@system,@subSystem,@openNotify,@updatedNotify, @closedNotify,@verifiedNotify,@assingedNotify)
	       END">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlUsers" Name="userID" 
                PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="rblSubStatus" DefaultValue="" Name="subType" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="subsystem" />
            <asp:Parameter Name="system" />
            <asp:Parameter Name="userID" />
            <asp:Parameter Name="openNotify" />
            <asp:Parameter Name="closedNotify" />
            <asp:Parameter Name="verifiedNotify" />
            <asp:Parameter Name="assingedNotify" />
            <asp:Parameter Name="updatedNotify" />
        </UpdateParameters>
    </asp:SqlDataSource>


    <asp:SqlDataSource ID="sqlITUsers" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
        
        SelectCommand="SELECT userId, [user] FROM tbl_IT_users WHERE status &lt;&gt; 'I' and userID &lt;&gt;1">
    </asp:SqlDataSource>
</fieldset>
</div>
</asp:Content>

