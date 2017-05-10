<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Reports" EnableEventValidation="false" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" Runat="Server">
   
    
    <style type="text/css">
        
        
        .fieldStyle
        {
            margin-right:20px;
            margin-Left:5px;
          
        }
        
        #TicketListing
        {
            height: 1443px;
            margin-top: 3px;
        }
        #TicketNumber
        {
            height: 986px;
            margin-top: 213px;
        }
        #detailview
        {
            height: 891px;
        }
        .style3
        {
            width: 40%;
        }
        .style4
        {
        width: 137px;
    }
    .GRVIEW
    {
        width:100%;
        border:1px solid black;
        overflow:scroll;
        display:block;
        overflow-y:hidden;
    }
    
    .full
        {
        width: 940px;
        }
        
     .tblCell
     {
         font-size:16px;
         padding-right:10px;
     }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
   
    <br/>

   <br/>
    <fieldset>
       <legend>Open Tickets Report</legend>

       <br />
       <fieldset>
        <legend> Search By Ticket #</legend>
        
        <asp:Label runat="server" ID="lblError" Text="Invaild Ticket Number" ForeColor="Red" Font-Bold="true" Visible="false" />
        <br />
        Ticket # :<asp:TextBox runat="server"  ID="txtTicketNumber" /> 
           <asp:Button runat="server" ID="btnTicketNumber" Text="View" 
               onclick="btnTicketNumber_Click" />
       </fieldset>


       <br />

    <div id="Reporting" class="menuTicket" runat="Server">
           
         <table cellspacing="10">
            <tr>
                 <td>
                   <asp:GridView ID="gvStaffStats" runat="server"
                       CellPadding="4" ForeColor="#333333" 
                       GridLines="None" AllowSorting="True" AutoGenerateColumns="False" 
                       DataSourceID="sqlStaffStat"  >
                       <AlternatingRowStyle BackColor="White" />
                       <Columns>

                           <asp:BoundField DataField="USER" HeaderText="USER" SortExpression="USER" />
                           <asp:BoundField DataField="OPEN" HeaderText="OPEN" ReadOnly="True" 
                               SortExpression="OPEN" />
                           <asp:BoundField DataField="CLOSED" HeaderText="CLOSED" ReadOnly="True" 
                               SortExpression="CLOSED" />
                           <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" ReadOnly="True" 
                               SortExpression="TOTAL" />
                           <asp:BoundField DataField="Percentage" HeaderText="Percentage" ReadOnly="True" 
                               SortExpression="Percentage" />

                           <asp:BoundField DataField="Avg Ticket Life" HeaderText="Avg Ticket Life" 
                               ReadOnly="True" SortExpression="Avg Ticket Life" />

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
                </td>
                <td>
                    <table >
                       <tr>
                           <td >
                               Total Open Tickets:</td>
                           <td>
                               <asp:Label ID="lblOpenTickets" runat="server" style="font-weight: 700; color:Red;"></asp:Label>
                           </td>
                           <td>&nbsp;&nbsp;</td>
                           <td class="style4">
                               Assigned Tickets:</td>
                           <td>
                               <asp:Label ID="lblassigned" runat="server" style="font-weight: 700;"></asp:Label>
                           </td>
                       </tr>
                         <tr>
                           <td >
                               Open Issues:</td>
                           <td>
                               <asp:Label ID="lblOpenIssues" runat="server" style="font-weight: 700; color:Red;"></asp:Label>
                           </td>
                              <td>&nbsp;&nbsp;</td>
                           <td class="style4">
                               Unassigned Tickets:</td>
                           <td>
                               <asp:Label ID="lblUnass" runat="server" style="font-weight: 700;"></asp:Label>
                           </td>
                       </tr>
                         <tr>
                           <td >
                               Open Projects:</td>
                           <td>
                               <asp:Label ID="lblOpenProjects" runat="server" style="font-weight: 700; color:Red;"></asp:Label>
                           </td>
                       </tr>
                       <tr>
                           
                       </tr>
                   </table> 
                </td>
            </tr>
         
         </table>
           
           <br />

              <fieldset>
            <legend>Filter</legend>
          
          
          
              <table class="tblCell" cellpadding="6px">
                <tr>
                    <td>
                        Issuer:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlIssuer" AppendDataBoundItems="True" 
                            DataSourceID="sqlIssuer" DataTextField="EmployeeName" 
                            DataValueField="employeenumber" AutoPostBack="True">
                            <asp:ListItem Value="0000" Text="All" />
                        </asp:DropDownList>
                    </td>
                    <td> </td>

                    <td>
                        Assigned To :
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlUser" AppendDataBoundItems="True" 
                            DataSourceID="sqlITUsers" DataTextField="Users" DataValueField="userId" 
                            AutoPostBack="True">
                            <asp:ListItem Value="0000" Text="All" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Department:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlDepartment" AppendDataBoundItems="True" 
                            DataSourceID="sqlDepartments" DataTextField="DepartmentName" 
                            DataValueField="DepartmentID" AutoPostBack="True">
                            <asp:ListItem Value="0000" Text="All" />
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td>
                        Division:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlDivision" AppendDataBoundItems="True" 
                            DataSourceID="sqlDivision" DataTextField="division" 
                            DataValueField="division" AutoPostBack="True">
                            <asp:ListItem Value="0000" Text="All" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td >
                        System:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlSystem" AppendDataBoundItems="True" 
                            DataSourceID="sqlSystem" DataTextField="System" DataValueField="SystemID" 
                            AutoPostBack="True" 
                            onselectedindexchanged="ddlSystem_SelectedIndexChanged">
                            <asp:ListItem Value="0000" Text="All" />
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                        Sub system:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlSubSystem" AppendDataBoundItems="True" 
                            DataSourceID="sqlSubsytstem" DataTextField="SubSystem" 
                            DataValueField="SubSystemID" AutoPostBack="True">
                            <asp:ListItem Value="0000" Text="All" />
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td>
                        Role:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlRole" AppendDataBoundItems="True" 
                            AutoPostBack="True" DataSourceID="sqlRoles" DataTextField="roleName" 
                            DataValueField="roleID">
                            <asp:ListItem Value="0000" Text="All" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Priority:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlPriority" AppendDataBoundItems="True" 
                            DataSourceID="sqlPriority" DataTextField="prioritydesc" 
                            DataValueField="priorityid" AutoPostBack="True">
                            <asp:ListItem Value="0000" Text="All" />
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td>
                        Type:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlTYpe" AppendDataBoundItems="True" 
                            DataSourceID="sqlType" DataTextField="Type" DataValueField="TypeID" 
                            AutoPostBack="True">
                            <asp:ListItem Text="All" Value="0000"/>
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td>
                        Repeat Issue:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlRepeateIssue" 
                            AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="sqlRepeat" 
                            DataTextField="Repeat" DataValueField="Value">
                            <asp:ListItem Value="0000" Text="All" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Ticket Status:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlStatus" AppendDataBoundItems="True" 
                             AutoPostBack="True" >
                            <asp:ListItem Value="0" Text="Closed" />
                            <asp:ListItem Value="1" Text="Open" Selected="True"/>
                            <asp:ListItem Value="2" Text="On-Hold" />
                            <asp:ListItem Value="3" Text="Waiting" />
                       </asp:DropDownList>
                    </td>
                    <td></td>
                    <td>
                        Verification Status:
                    </td>
                    <td>

                        <asp:DropDownList runat="server" ID="ddlVerificationStatus" 
                            AppendDataBoundItems="true" AutoPostBack="True">
                            <asp:ListItem Value="1">Open</asp:ListItem>
                            <asp:ListItem Value="0">Closed</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    
                </tr>         
              </table>
            </fieldset>


        

          <asp:SqlDataSource ID="sqlStaffStat" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
            SelectCommand="ITStaffStats" SelectCommandType="StoredProcedure">
          </asp:SqlDataSource>

       
           <asp:SqlDataSource ID="sqlITUsers" runat="server" 
               ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
               SelectCommand="AssignedTo" SelectCommandType="StoredProcedure">
           </asp:SqlDataSource>
            <asp:SqlDataSource ID="sqlSubsytstem" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                SelectCommand="SELECT SystemID, SubSystemID, SubSystem, interestedParty, active FROM tbl_SubSystem WHERE SystemID = @SystemID">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlSystem" Name="SystemID" 
                        PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="sqlRepeat" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                SelectCommand="SELECT [Repeat], [Value] FROM [tbl_RepeatIssue]">
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="sqlRoles" runat="server" 
               ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
               SelectCommand="SELECT [roleID], [roleName] FROM [tbl_Roles]">
           </asp:SqlDataSource>
           <asp:SqlDataSource ID="sqlPriority" runat="server" 
               ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
               SelectCommand="SELECT [priorityid], [prioritydesc] FROM [tbl_priority]">
           </asp:SqlDataSource>
           <asp:SqlDataSource ID="sqlDivision" runat="server" 
               ConnectionString="<%$ ConnectionStrings:HRDBConnectionString %>" 
               SelectCommand="ActiveDivisions" SelectCommandType="StoredProcedure">
           </asp:SqlDataSource>
           <asp:SqlDataSource ID="sqlDepartments" runat="server" 
               ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
               SelectCommand="SELECT [DepartmentID], [DepartmentName] FROM [Departments]">
           </asp:SqlDataSource>
           <asp:SqlDataSource ID="sqlSystem" runat="server" 
               ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
               SelectCommand="SELECT [System], [SystemID] FROM [tbl_system_type]">
           </asp:SqlDataSource>
           <asp:SqlDataSource ID="sqlType" runat="server" 
               ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
               SelectCommand="SELECT [Type], [TypeID] FROM [tbl_IssueType]">
           </asp:SqlDataSource>
           <asp:SqlDataSource ID="sqlIssuer" runat="server" 
               ConnectionString="<%$ ConnectionStrings:HRDBConnectionString %>" 
               
               SelectCommand="SELECT [employeenumber], [EmployeeName] FROM [EMPLOYEE_LIST_VIEW] ORDER BY EmployeeName">
           </asp:SqlDataSource>
           <asp:SqlDataSource ID="sqlTicketStatus" runat="server" 
               ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
               SelectCommand="SELECT [Status], [StatusID] FROM [tbl_Status]">
           </asp:SqlDataSource>
          <br />
          <fieldset>
            <legend>Ticket Queue</legend>
          
            
         
            <asp:Button ID="btnExpExcel" runat="server" Text="Export" onclick="btnExpExcel_Click" />

            <br />
            <br />
<%--
            <asp:DataList ID="dlTickets" runat="server" DataSourceID="sqlReportTicket">
            <ItemStyle BorderColor="Black" BorderWidth="2" Font-Size="11" ForeColor="Black" />
            <AlternatingItemStyle BackColor="#FFFBD6" />
                <ItemTemplate>
  
                 
                    <table style="width:100%">
                        <tr >
                            <td style="width:32%"> <span class="fieldStyle"> <span style="font-weight:600;">ID: </span>      <b><asp:HyperLink Runat =server NavigateUrl ='<%#"Edit.aspx?ticketnumber=" + DataBinder.Eval(Container.DataItem, "issueid").ToString()%>' ID="Hyperlink1"> <%#DataBinder.Eval(Container.DataItem, "issueid")%></asp:HyperLink></b> </span> </td>
                            <td style="width:32%">&nbsp;</td>
                            <td style="width:32%">  <span class="fieldStyle"> <span style="font-weight:600;">Date Created: </span> <asp:Label ID="datecreatedLabel" runat="server" Text='<%# Eval("datecreated") %>' /></span></td>
                            
                        </tr>
                        
                        <tr>
                            <td style="width:32%">
                                 <span class="fieldStyle"> <span style="font-weight:600;">Issuer: </span> <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' /></span>
                            </td>
                            <td style="width:32%">
                                 <span class="fieldStyle"> <span style="font-weight:600;">Department: </span><asp:Label ID="DepartmentNameLabel" runat="server" Text='<%# Eval("DepartmentName") %>' /> </span>
                            </td>
                            <td style="width:32%"> 
                                 <span class="fieldStyle"> <span style="font-weight:600;">Division: </span> <asp:Label ID="divisionLabel" runat="server" Text='<%# Eval("division") %>' /></span>
                           </td>
                            
                        </tr>
                        <tr>
                            <td style="width:32%"><span class="fieldStyle"> <span style="font-weight:600;">System: </span><asp:Label ID="SystemLabel" runat="server" Text='<%# Eval("System") %>' /></span></td>
                            <td style="width:32%"><span class="fieldStyle"> <span style="font-weight:600;">SubSystem: </span> <asp:Label ID="SubSystemLabel" runat="server" Text='<%# Eval("SubSystem") %>' /></span></td>
                        </tr>
                        
                        <tr>
                            <td style="width:32%"><span class="fieldStyle"> <span style="font-weight:600;">Priority: </span> <asp:Label ID="prioritydescLabel" runat="server" Text='<%# Eval("prioritydesc") %>' /></span></td>
                            <td style="width:32%"><span class="fieldStyle"> <span style="font-weight:600;">Type: </span> <asp:Label ID="TypeLabel" runat="server" Text='<%# Eval("Type") %>' /></span></td>
                            <td style="width:32%"><span class="fieldStyle"> <span style="font-weight:600;">Repeat: </span><asp:Label ID="RepeatLabel" runat="server" Text='<%# Eval("Repeat") %>' /></span></td>
                        </tr>
                        <tr><td><br /></td></tr>
                        <tr>
                            <td  colspan="3" style="width:32%"><span class="fieldStyle"> <span style="font-weight:600;">Description:</span>  <asp:Label ID="problemdescriptionLabel" runat="server" Text='<%# Eval("problemdescription") %>' /></span> </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="width:32%"><span class="fieldStyle"> <span style="font-weight:600;">Comments: </span><asp:Label ID="commentsLabel" runat="server" Text='<%# Eval("comments") %>' /></span></td>
                        </tr>
                        <tr><td><br /></td></tr>
                        <tr>
                            <td style="width:32%"><span class="fieldStyle"> <span style="font-weight:600;">Assigned To: </span><asp:Label ID="userLabel" runat="server" Text='<%# Eval("user") %>' /></span></td>
                            <td style="width:32%"><span class="fieldStyle"> <span style="font-weight:600;">Role: </span> <asp:Label ID="RoleNameLabel" runat="server" Text='<%# Eval("RoleName") %>' /></span></td>
                        </tr>
                        <tr>
                            <td style="width:32%"><span class="fieldStyle"> <span style="font-weight:600;">Status:</span> <asp:Label ID="statusLabel" runat="server" Text='<%# Eval("status") %>' /></span></td>
                            <td style="width:32%"><span class="fieldStyle"> <span style="font-weight:600;">Ticket Status:</span> <asp:Label ID="ticket_StatusLabel" runat="server" Text='<%# Eval("ticket_Status") %>' /></span></td>
                            <td style="width:32%">   <span class="fieldStyle"> <span style="font-weight:600;">Target Date: </span> <asp:Label ID="targetcompletiondateLabel" runat="server" Text='<%# Eval("targetcompletiondate") %>' /></span> </td>
                           
                        </tr>
                    </table>
                    <br />
                </ItemTemplate>
            
            
            
            </asp:DataList>--%>
            
            
              <asp:GridView ID="gridReports" runat="server"
                   CellPadding="5" ForeColor="#333333" GridLines="None" AllowSorting="True" AutoGenerateColumns="False" 
                   DataSourceID="sqlReportTicket"  CssClass="GRVIEW">
                   <AlternatingRowStyle BackColor="White" />
                   <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="issueid" 
                           DataNavigateUrlFormatString="~/Edit.aspx?ticketnumber={0}" 
                           DataTextField="issueid" HeaderText="IssueID" />
                       <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" 
                           SortExpression="Name" />
                       <asp:BoundField DataField="DepartmentName" HeaderText="Dept" 
                           SortExpression="DepartmentName" />
                       <asp:BoundField DataField="division" HeaderText="Plant" 
                           SortExpression="division" />
                       <asp:BoundField DataField="RoleName" HeaderText="Role" ReadOnly="True" 
                           SortExpression="RoleName" />
                       <asp:BoundField DataField="System" HeaderText="System" 
                           SortExpression="System" />
                       <asp:BoundField DataField="SubSystem" HeaderText="SubSystem" ReadOnly="True" 
                           SortExpression="SubSystem" />
                       <asp:BoundField DataField="prioritydesc" HeaderText="Priority" 
                           SortExpression="prioritydesc" />
                       <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                       <asp:BoundField DataField="Repeat" HeaderText="Repeat" 
                           SortExpression="Repeat" />
                       <asp:BoundField DataField="datecreated" HeaderText="Date Created" 
                           SortExpression="datecreated" />
                       <asp:BoundField DataField="problemdescription" HeaderText="Problem" 
                           SortExpression="problemdescription" />
                       <asp:BoundField DataField="targetcompletiondate" 
                           HeaderText="Target Date" SortExpression="targetcompletiondate" DataFormatString="{0:d}"/>
                       <asp:BoundField DataField="user" HeaderText="Assigned" SortExpression="user" />
                       <asp:BoundField DataField="comments" HeaderText="Comments" 
                           SortExpression="comments" />
                       <asp:BoundField DataField="status" HeaderText="Ticket Status" 
                           SortExpression="status" />
                       <asp:BoundField DataField="ticket_Status" HeaderText="Verification Status" 
                           ReadOnly="True" SortExpression="ticket_Status" />
                
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
            </fieldset>
           <asp:SqlDataSource ID="sqlReportTicket" runat="server" 
               ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
               SelectCommand="GetITReport" SelectCommandType="StoredProcedure">
               <SelectParameters>
                   <asp:ControlParameter ControlID="ddlIssuer" Name="Name" 
                       PropertyName="SelectedValue" Type="String" />
                   <asp:ControlParameter ControlID="ddlDivision" Name="division" 
                       PropertyName="SelectedValue" Type="String" />
                   <asp:ControlParameter ControlID="ddlRole" Name="roleName" 
                       PropertyName="SelectedValue" Type="String" />
                   <asp:ControlParameter ControlID="ddlDepartment" Name="Dept" 
                       PropertyName="SelectedValue" Type="String" />
                   <asp:ControlParameter ControlID="ddlSystem" Name="system" 
                       PropertyName="SelectedValue" Type="String" />
                   <asp:ControlParameter ControlID="ddlSubSystem" Name="subsystem" 
                       PropertyName="SelectedValue" Type="String" />
                   <asp:ControlParameter ControlID="ddlPriority" Name="priority" 
                       PropertyName="SelectedValue" Type="String" />
                   <asp:ControlParameter ControlID="ddlTYpe" Name="type" 
                       PropertyName="SelectedValue" Type="String" />
                   <asp:ControlParameter ControlID="ddlRepeateIssue" Name="repeat" 
                       PropertyName="SelectedValue" Type="String" />
                   <asp:ControlParameter ControlID="ddlUser" Name="assigned" 
                       PropertyName="SelectedValue" Type="String" />
                   <asp:ControlParameter ControlID="ddlStatus" Name="status" 
                       PropertyName="SelectedValue" Type="String" />
                   <asp:ControlParameter ControlID="ddlVerificationStatus" Name="ticketStatus" 
                       PropertyName="SelectedValue" Type="String" />
                  <%-- <asp:ControlParameter ControlID="ddlOrder" Name="orderBy" 
                       PropertyName="SeleGetITctedValue" Type="String" />--%>
               </SelectParameters>
           </asp:SqlDataSource>
       </div>
   </fieldset>
</asp:Content>

