<%@ Page Title="Create Ticket" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="UpdateSavedEmployee.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    
    <style type="text/css">
        .style2
        {
            width: 60%;
        }
        .style3
        {
            height: 68px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  
    <fieldset>
    <legend>Update Saved User</legend>
    <div id="userEntry" class="CreateTicket" runat="server">
    <br /><b style="color:Red">All fields are required except Work Phone Number, Cell Phone Number and Location.</b><br />
        <table style=" width: 70%">
            <tr>
                <td>
                    User:</td>
                <td>
                    <asp:DropDownList ID="ddlEmployee" runat="server" Width="344px" 
                        AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="sqlEmployees" 
                        DataTextField="FullName" DataValueField="employeenumber" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged">
                        <asp:ListItem Value="000">PLEASE SELECT</asp:ListItem>
                        <asp:ListItem Value="00">OTHER</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblEmployee" runat="server" ForeColor="Red" Text="*" 
                        Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Email Address:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="342px"></asp:TextBox>
                    <asp:Label ID="lblEmail" runat="server" ForeColor="Red" Text="*" 
                        Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Plant/Division:</td>
                <td>
                    <asp:DropDownList ID="ddlPlant" runat="server" AppendDataBoundItems="True" 
                        DataSourceID="sqlPlant" DataTextField="division" DataValueField="division">
                        <asp:ListItem Value="0000">PLEASE SELECT</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblPlant" runat="server" ForeColor="Red" Text="*" 
                        Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Department:</td>
                <td>
                    <asp:DropDownList ID="ddlDepartment" runat="server" AppendDataBoundItems="True" 
                        DataSourceID="sqlDepartment" DataTextField="department" DataValueField="deptid">
                        <asp:ListItem Value="000">PLEASE SELECT</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblDepartment" runat="server" ForeColor="Red" Text="*" 
                        Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Work Phone Number:</td>
                <td>
                    <asp:TextBox ID="txtWorkPhone" runat="server" Width="342px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Cell Phone Number:</td>
                <td>
                    <asp:TextBox ID="txtCellPhone" runat="server" Width="342px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Location:</td>
                <td>
                    <asp:TextBox ID="txtLocation" runat="server" Width="342px"></asp:TextBox>
                </td>
            </tr>
        </table>  
            <br />
            <table Width="400px">
            <tr align="center">
                <td>
                    &nbsp; </td><td>&nbsp;</td><td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                        onclick="btnSubmit_Click" style="height: 26px" />
                </td>
           </tr>                  
           </table>
           
                    <asp:SqlDataSource ID="sqlEmployees" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                        SelectCommand="GetEmployees" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlPlant" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                        SelectCommand="GetDivision" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlDepartment" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                        SelectCommand="SELECT * FROM [tbl_departments]"></asp:SqlDataSource>
                    
                    &nbsp; </div><div id="Splash" class="UpdateEmployee" runat="server" visible="false">      
            <h2>This User has been updated successfully </h2><br />
                    <p>Press the return button to update another employee. <asp:Button ID="btnAnother" runat="server" Text="Return" 
                        onclick="btnAnother_Click" style="height: 26px" /></p><br />
        </div>
    </fieldset>
        </asp:Content>