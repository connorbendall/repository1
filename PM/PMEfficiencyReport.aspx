<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="PMEfficiencyReport.aspx.cs" EnableEventValidation ="false"  Inherits="PMEfficiencyReport" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <fieldset><legend>PM Efficiency Report - Select a date range to report on</legend>
        <br />
        <asp:Label ID="lblError" ForeColor="Red" Font-Bold="true" runat="server" />
        <asp:Label ID="lblInfo" ForeColor="Red" Font-Italic="true" Font-Size="08" runat="server" Text="Data only vaild as of 11/30/2012" />
        <table>
            <tr>
                <td>Date From</td>
                <td>
                    <asp:TextBox ID="txtDateFrom" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="fromDateCalander" TargetControlID="txtDateFrom" runat="server" />
                </td>
            </tr>
                <tr>
                <td>Date To</td>
                <td>
                    <asp:TextBox ID="txtDateTo" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="toDateCalander" TargetControlID="txtDateTo" runat="server" />
                </td>
            </tr>
          <tr>
              <td>Division</td>
              <td>
                  <asp:DropDownList ID="drpDivision" runat="server" AppendDataBoundItems="True" 
            DataSourceID="srcActiveDivisions" DataTextField="division" 
            DataValueField="division">
        </asp:DropDownList>
                  <asp:SqlDataSource ID="srcActiveDivisions" runat="server" 
            ConnectionString="<%$ ConnectionStrings:HRDBConnectionString %>" 
            SelectCommand="ActiveDivisions" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
              </td>
          </tr>
            <tr>
                <td>Status</td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server" >
                        <asp:ListItem Text="Late" Value="Late" />
                        <asp:ListItem Text="On Time" Value= "OnTime" />
                        <asp:ListItem Text="ALL" Value="All" Selected="True"/>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td>
                <td align="right">
                    <br />

                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                        onclick="btnSubmit_Click"  />
                </td>
            </tr>
        </table>
        <br />
        Excel :  <asp:Button ID="btnExport" runat="server" Text="Export"  onclick="btnExport_Click" />
        <div id="divReport" runat="server" visible="false">
        <fieldset>
            <legend style="{font-size:15px}">Report</legend>
         
            <fieldset>
                <legend>Statistics - Filtered By Date and Division</legend>
                <asp:FormView ID="fvEfficiencyDetails" runat="server" Width="100%"
                CellPadding="4"  ForeColor="#333333" DataSourceID="sqlEfficiencyDetails" EmptyDataText="No Data Returned">
                <EditItemTemplate>
                    MachineSum:
                    <asp:TextBox ID="MachineSumTextBox" runat="server" Text='<%# Bind("MachineSum") %>' />
                    <br />
                    SumNine:
                    <asp:TextBox ID="SumNineTextBox" runat="server" Text='<%# Bind("SumNine") %>' />
                    <br />
                    EfficiencyPer:
                    <asp:TextBox ID="EfficiencyPerTextBox" runat="server" Text='<%# Bind("EfficiencyPer") %>' />
                    <br />
                    SumSixNine:
                    <asp:TextBox ID="SumSixNineTextBox" runat="server" Text='<%# Bind("SumSixNine") %>' />
                    <br />
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    MachineSum:
                    <asp:TextBox ID="MachineSumTextBox" runat="server" Text='<%# Bind("MachineSum") %>' />
                    <br />
                    SumNine:
                    <asp:TextBox ID="SumNineTextBox" runat="server" Text='<%# Bind("SumNine") %>' />
                    <br />
                    EfficiencyPer:
                    <asp:TextBox ID="EfficiencyPerTextBox" runat="server" Text='<%# Bind("EfficiencyPer") %>' />
                    <br />
                    SumSixNine:
                    <asp:TextBox ID="SumSixNineTextBox" runat="server" Text='<%# Bind("SumSixNine") %>' />
                    <br />
                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                </InsertItemTemplate>
                <ItemTemplate>
                    <b>Total Machines :</b>
                    <asp:Label ID="MachineSumLabel" runat="server" Text='<%# Bind("MachineSum") %>' />
                    <br />
                    <br />
                    <b>Machines > 9 :</b>
                    <asp:Label ID="SumNineLabel" runat="server" Text='<%# Bind("SumNine") %>' />
                    <br />
                    <br />
                    <b>Machines > 6 and  < 9 :</b>
                    <asp:Label ID="SumSixNineLabel" runat="server" Text='<%# Bind("SumSixNine") %>' />
                    <br />
                    <br />
                    <b>Percent Of Efficiency</b>
                    <asp:Label ID="EfficiencyPerLabel" runat="server" Text='<%# Bind("EfficiencyPer") %>' />
                    <br />
                    <br />
                </ItemTemplate>

            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" Font-Size="12" />
            </asp:FormView>
        </fieldset>

         <br />
            <asp:SqlDataSource ID="sqlEfficiencyDetails" runat="server" 
                ConnectionString="<%$ ConnectionStrings:TESTQTYConnectionString %>" 
                SelectCommand="Get_Efficiency_Report_Stats" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtDateTo" Name="DateTo" PropertyName="Text" Type="DateTime" />
                    <asp:ControlParameter ControlID="txtDateFrom" Name="DateFrom" PropertyName="Text" Type="DateTime" />
                    <asp:ControlParameter ControlID="drpDivision" Name="Division" PropertyName="SelectedValue" Type="String" />                   
                </SelectParameters>
            </asp:SqlDataSource>


            <br />

            <asp:GridView ID="gvEfficiencyReport" runat="server" 
                AutoGenerateColumns="False" Width="791px" CellPadding="4" ForeColor="#333333" 
                EmptyDataText="No Data Returned"  
                DataSourceID="sqlEfficiencyReport" 
                onrowdatabound="gvEfficiencyReport_RowDataBound" AllowSorting="True">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="division" HeaderText="Division" SortExpression="division" />
                    <asp:BoundField DataField="machinenumber" HeaderText="Machinenumber" SortExpression="machinenumber" />
                    <asp:BoundField DataField="frequency" HeaderText="Frequency" SortExpression="frequency" />
                    <asp:BoundField DataField="Previous_PMDate" HeaderText="Previous PMDate" SortExpression="Previous_PMDate" />
                    <asp:BoundField DataField="ScheduledDate" HeaderText="ScheduledDate" ReadOnly="True" SortExpression="ScheduledDate" />                    
                    <asp:BoundField DataField="PMDate" HeaderText="Latest PMDate" SortExpression="PMDate" />
                     <asp:TemplateField HeaderText="Elapsed" SortExpression="life">
                        <EditItemTemplate>
                            <asp:Label ID="lblElasped" runat="server" Text='<%# Eval("life", "{0:d}") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblElasped" runat="server" Font-Bold="true" Text='<%# Bind("life", "{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                
                </Columns>
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

            <asp:SqlDataSource ID="sqlEfficiencyReport" runat="server" 
                ConnectionString="<%$ ConnectionStrings:TESTQTYConnectionString %>"             
                SelectCommand="Get_Efficiency_Report" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtDateTo" Name="DateTo" 
                        PropertyName="Text" Type="DateTime" />
                    <asp:ControlParameter ControlID="txtDateFrom" Name="DateFrom" 
                        PropertyName="Text" Type="DateTime" />
                    <asp:ControlParameter ControlID="ddlStatus" Name="Status" 
                        PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="drpDivision" Name="Division" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </fieldset>
        </div>
    </fieldset>

</asp:Content>

