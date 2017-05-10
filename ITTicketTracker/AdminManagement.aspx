<%@ Page Title="Admin Management" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AdminManagement.aspx.cs" Inherits="AdminManagement" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


<fieldset>
    <legend>Admin Management</legend>

    <asp:Button runat="server" ID="btnMangeUsers" Text="Manage Users" onclick="btnMangeUsers_Click" /> 
    <asp:Button runat="server" ID="btnManageRoles" Text="Manage Roles" 
        onclick="btnManageRoles_Click" /> <asp:Button runat="server" 
        ID="btnManageSystem" Text="Manage Systems" onclick="btnManageSystem_Click" /> 
    <asp:Button runat="server" ID="btnManageSubsystems" Text="Manage Subsystems" 
        onclick="btnManageSubsystems_Click" />
    <asp:Button runat="server" ID="btnMangeNotify" Text="Manage User Notifications" onclick="btnMangeNotify_Click" />

    <asp:ScriptManager ID="Test" runat="server" />

</fieldset>
   


</asp:Content>

