<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="PMSchedule.aspx.cs" Inherits="PMSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset><legend>Please select a machine. The next page will allow entry or updating of Schedule. </legend>

    <table>
        <tr>
            <td>Division</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" 
                    AutoPostBack="True" DataSourceID="srcDivision" DataTextField="division" 
                    DataValueField="division">
                </asp:DropDownList>
                <asp:SqlDataSource ID="srcDivision" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:HRDBConnectionString %>" 
                    SelectCommand="ActiveDivisions" SelectCommandType="StoredProcedure">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>Machine #</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="srcMachine" 
                    DataTextField="NAME" DataValueField="ABRESC">
                </asp:DropDownList>
                <asp:SqlDataSource ID="srcMachine" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:PRDConnectionString %>" 
                    
                    
                    SelectCommand="SELECT [ABRESC], [machinenumber], ABPLNT AS DIVISION, [machinename], [ABRESC] + ' - ' + [abdes] AS NAME FROM COMP.dbo.vMachineNumbers 
WHERE ([ABPLNT] = @division)
ORDER BY  [ABRESC] ">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="DIVISION" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    Text="Update Schedule" />
            </td>
        </tr>
    </table>
</fieldset>
</asp:Content>

