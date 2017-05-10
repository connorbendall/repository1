<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="PMEnterPM1.aspx.cs" Inherits="PMEnterPM1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style2
    {
        height: 25px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset><legend>Please enter all the info below. If the machine is not in the list, 
    <br />
    then a schedule needs to entered for it. 
        
        </legend>
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    <table>
        <tr>
            <td>Division<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td>
                <asp:DropDownList ID="drpDivision" runat="server" AppendDataBoundItems="True" 
                    AutoPostBack="True" DataSourceID="srcDivision" DataTextField="division" 
                    DataValueField="division">
                    <asp:ListItem>PLEASE SELECT</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="srcDivision" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:HRDBConnectionString %>" 
                    SelectCommand="ActiveDivisions" SelectCommandType="StoredProcedure">
                </asp:SqlDataSource>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Machine</td>
            <td>
                <asp:DropDownList ID="drpMachine" runat="server" DataSourceID="srcMachine" AutoPostBack="true"
                    DataTextField="Machine" DataValueField="machinenumber">
                </asp:DropDownList>
                <asp:SqlDataSource ID="srcMachine" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:COMPConnectionString %>" SelectCommand="select ABRESC as machinenumber, ABPLNT AS Division, ABRESC  + ' - ' + UPPER(ABDES) as Machine
FROM COMP.dbo.vMachineNumbers 
WHERE ABPLNT = @division
ORDER BY machinenumber
">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="drpDivision" Name="Division" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Task-Group by Frequency</td>
            <td>
                <asp:DropDownList ID="drpFrequency" runat="server" DataSourceID="sqlFrequency" 
                    DataTextField="frequency" DataValueField="frequency">
                  
                </asp:DropDownList>

                <asp:SqlDataSource ID="sqlFrequency" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:TESTQTYConnectionString %>" 
                    SelectCommand="SELECT DISTINCT frequency FROM [TESTQTY].[dbo].[tbl_PM_Schedule]
                                    WHERE activetask = 'Y' AND
                                    Machinenumber = @machineNumber">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="drpMachine" Name="machineNumber" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>

            </td>
            <td>
                &nbsp;</td>
        </tr>
     
        <tr>
            <td>Date</td>
            <td>
                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                <asp:PopupControlExtender ID="txtDate_PopupControlExtender" runat="server" 
                    PopupControlID="pnlDate" TargetControlID="txtDate" OffsetY="20">
                </asp:PopupControlExtender>
            </td>
            <td>
                <asp:Panel ID="pnlDate" runat="server">
                    <asp:UpdatePanel ID="UpdatePanel" runat="server">
                    <ContentTemplate>
                        <asp:Calendar ID="calDate" runat="server" BackColor="#FFFFCC" 
                            BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                            Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
                            onselectionchanged="calDate_SelectionChanged" ShowGridLines="True" 
                            Width="220px">
                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                            <OtherMonthDayStyle ForeColor="#CC9966" />
                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                            <SelectorStyle BackColor="#FFCC66" />
                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                                ForeColor="#FFFFCC" />
                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                        </asp:Calendar>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style2">Performed By<br />
                (hold ctrl to select multiple)</td>
            <td class="style2">
                <asp:ListBox ID="lstPerformed" runat="server"
                    DataSourceID="srcEmployee" DataTextField="EmployeeName" 
                    DataValueField="EmployeeName">
                </asp:ListBox>
                <asp:SqlDataSource ID="srcEmployee" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:HRDBConnectionString %>" SelectCommand="SELECT employeenumber, UPPER(lastname) + ', ' + UPPER(firstname) AS EmployeeName, dept, title, division FROM tbl_employees WHERE (division = @Division) AND ( (paystatus = 'A') AND (title LIKE 'MTCE%') OR   (paystatus = 'A') AND (dept like 'MAIN%') OR    (paystatus = 'A') AND (dept like 'MHCLD%') OR  (paystatus = 'A') AND (dept like 'CTMPD%') OR    (paystatus = 'A') AND (dept like 'D%WELD') OR (paystatus = 'A' and dept like 'MHCLD%'))  ORDER BY lastname
">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="drpDivision" Name="Division" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td>Time to complete<br />(hrs)</td>
            <td>
                <asp:TextBox ID="txtComplete" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

    </fieldset>
</asp:Content>

