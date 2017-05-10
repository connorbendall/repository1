<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AdminManagementOnCall.aspx.cs" Inherits="AdminManagementOnCall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


<asp:Panel ID="pTasks" runat="server" Visible="true">
    <fieldset>
        <legend>On-Call</legend>

        <asp:DetailsView ID="dvCreateRole" runat="server" AutoGenerateRows="False" 
           DefaultMode="Edit" Width="500px" DataSourceID="sqlOnCall">
            <Fields>
                <asp:TemplateField HeaderText="Status">
                    <EditItemTemplate>
                        <asp:CheckBox ID="rbStatus" Text="Enabled/Disabled" runat="server" Checked='<%# Bind("enabledStatus") %>' />
                    
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:RadioButton ID="rbStatus" runat="server"  />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label12" runat="server"></asp:Label>
                    </ItemTemplate>
                
                </asp:TemplateField>
                <asp:TemplateField HeaderText="All Day">
                    <EditItemTemplate>
                        <asp:CheckBox ID="D2" runat="server" Text="Monday" Checked='<%# Bind("monday") %>'/>
                        <asp:CheckBox ID="D1" runat="server" Text="Sunday" Checked='<%# Bind("sunday") %>' /><br />
                        <asp:CheckBox ID="D3" runat="server" Text="Tuesday" Checked='<%# Bind("tuesday") %>'/>
                        <asp:CheckBox ID="D7" runat="server" Text="Saturday" Checked='<%# Bind("saturday") %>'/><br/>
                        <asp:CheckBox ID="D4" runat="server" Text="Wednesday" Checked='<%# Bind("wednesday") %>'/><br />
                        <asp:CheckBox ID="D5" runat="server" Text="Thursday" Checked='<%# Bind("thursday") %>'/><br />
                        <asp:CheckBox ID="D6" runat="server" Text="Friday" Checked='<%# Bind("friday") %>'/><br />
                        
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:CheckBox ID="D1" runat="server" Text="Sunday" /><br />
                        <asp:CheckBox ID="D2" runat="server" Text="Monday" />
                        <asp:CheckBox ID="D3" runat="server" Text="Tuesday" />
                        <asp:CheckBox ID="D4" runat="server" Text="Wednesday" /><br />
                        <asp:CheckBox ID="D5" runat="server" Text="Thursday" />
                        <asp:CheckBox ID="D6" runat="server" Text="Friday" /><br />
                        <asp:CheckBox ID="D7" runat="server" Text="Saturday" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Time (24 hour)">
                    <EditItemTemplate>
                        <table>
                            <tr>
                                <td><asp:Label ID="lblStart" runat="server" Text="Start: "></asp:Label> </td>
                                <td><asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("startTime") %>'></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblEnd" runat="server" Text="End:"></asp:Label></td>
                                <td><asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("endTime") %>'></asp:TextBox></td>
                            </tr>
                        </table>              
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table>
                            <tr>
                                <td><asp:Label ID="lblStart" runat="server" Text="Start: "></asp:Label> </td>
                                <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblEnd" runat="server" Text="End:"></asp:Label></td>
                                <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                            </tr>
                        </table>              
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email Addresses" >
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("emailAddresses") %>' Width="99%" />
                        <br />
                        <asp:Label ID="lblIn" runat="server" Text="Emails must be ; seperated" Font-Italic="true" ForeColor="Red" Font-Size="9" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="txtEmail1" runat="server" Text='<%# Bind("emailAddresses") %>' TextMode="MultiLine" />
                    </InsertItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ButtonType="Button" ShowEditButton="true" />
            </Fields>
        </asp:DetailsView>
        <asp:SqlDataSource ID="sqlOnCall" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
            SelectCommand="ADMIN_GET_ONCALL" SelectCommandType="StoredProcedure" 
            UpdateCommand="ADMIN_SET_ONCALL" UpdateCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="onCallID" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="onCallID" DefaultValue="1" Type="Int32" />
                <asp:Parameter DbType="Time" Name="startTime" />
                <asp:Parameter DbType="Time" Name="endTime" />
                <asp:Parameter Name="monday" Type="Boolean" />
                <asp:Parameter Name="tuesday" Type="Boolean" />
                <asp:Parameter Name="wednesday" Type="Boolean" />
                <asp:Parameter Name="thursday" Type="Boolean" />
                <asp:Parameter Name="friday" Type="Boolean" />
                <asp:Parameter Name="saturday" Type="Boolean" />
                <asp:Parameter Name="sunday" Type="Boolean" />
                <asp:Parameter Name="enabledStatus" Type="Boolean" />
                <asp:Parameter Name="emailAddresses" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </fieldset> 
    </asp:Panel>
    
</asp:Content>

