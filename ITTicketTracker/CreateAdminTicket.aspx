<%@ Page Title="Create Ticket" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CreateAdminTicket.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    
      <script type="text/javascript">
            function OnSelectedIndexChange() {

                var prioity = document.getElementById('<%=ddlPriority.ClientID%>');

                if (prioity.value == 5)
                    alert("Warning! You are about to create a 911/Escalation Priority Ticket!");

                document.form1.Button1.disabled = false;

            }
    
    
    </script>
    
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
     <script type="text/javascript">

         function validateFileUpload(sender, args) {
             var fileName = new String();
             var fileExtension = new String();

             // store the file name into the variable  
             fileName = args.get_fileName();

             var indexOfDot = fileName.indexOf(".");
             // extract and store the file extension into another variable  
             fileExtension = fileName.substr(indexOfDot +1, fileName.length - indexOfDot);

             // array of allowed file type extensions  
             var validFileExtensions = new Array("jpg", "png", "pdf", "docx", "xlsx","msg","doc","xls","txt","ppt","pptx","csv");

             var flag = false;

             // loop over the valid file extensions to compare them with uploaded file  
             for (var index = 0; index < validFileExtensions.length; index++) {
                 if (fileExtension.toLowerCase() == validFileExtensions[index].toString().toLowerCase()) {
                     flag = true;
                 }
             }

             // display the alert message box according to the flag value  
             if (flag == false) {
                 alert('Files with extension ".' + fileExtension.toUpperCase() + '" are not allowed.\n\nYou can upload the files with following extensions only:\n.jpg\n.png\n.pdf\n.docx\n.xlsx\n.msg\n.xls\n.txt\n.ppt\n.pptx\n.csv');
                 return false;
             }
             else {
                 return true;
             }
         }  
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  
    <fieldset>
    <legend>Create Ticket</legend>
    <div id="ticketEntry" class="CreateTicket" runat="server">
    Fill out the form below to create a ticket. Once submitted, you will receive a Ticket #.<br/>Please make a note of this Ticket # for future reference.
    <br />
    <br /><b style="color:Red">All fields are required.<br />
      <asp:Label runat="server" ID="lblEmailMSG" Font-Bold="true" ForeColor="Red" Visible="false" Text="We require you to confirm your email address so we can ensure you receive all communication surrounding this ticket."/>
  
        </b>
        <table style=" width: 70%">
            <tr>
                <td>
                    Requested By:</td>
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
                    Your Department:</td>
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
                    System:</td>
                <td>
                    <asp:DropDownList ID="ddlSystem" runat="server" AppendDataBoundItems="True" 
                        DataSourceID="sqlSystem" DataTextField="System" DataValueField="SystemID" AutoPostBack="true" OnSelectedIndexChanged="ddlSystemSelectedIndexChanged">
                        <asp:ListItem Value="000">PLEASE SELECT</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblSystem" runat="server" ForeColor="Red" Text="*" 
                        Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>             
                <td class="style6">
                    <asp:Label ID="lblSubsytem" Text="Subsystem:" runat="server" Visible="true"/>
                </td>
                <td class="style7">
                    <asp:DropDownList ID="ddlSubSystem" runat="server" 
                        DataSourceID="sqlGetSubSystems" AutoPostBack="True" 
                        DataTextField="SubSystem" DataValueField="subsystemID" 
                        AppendDataBoundItems="True"   OnSelectedIndexChanged="ddlSubsystemSelectedIndexChanged" 
                        ondatabound="ddlSubSystem_DataBound">
                        <asp:ListItem Value="000">PLEASE SELECT</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblSubsystemError" runat="server" ForeColor="Red" Text="*" 
                        Visible="False"></asp:Label>
                </td>                        
            </tr>
        </table>      
         <asp:UpdatePanel ID="upDetails" runat="server">
            <ContentTemplate>
                    <asp:Table ID="tbInfo" runat="server" Visible="false" Width="410px" >
                    <asp:TableRow>
                        <asp:TableCell CssClass="style6">
                            Contact Extension:
                        </asp:TableCell>
                        <asp:TableCell   CssClass="style7">
                            <asp:TextBox ID="tbContactExtension" runat="server"></asp:TextBox>
                            <asp:Label ID="lblContactExtentionError" runat="server" ForeColor="Red" Text="*" Visible="false"/>
                        </asp:TableCell></asp:TableRow><asp:TableRow>
                        <asp:TableCell  CssClass="style6">
                            BOL Number:
                        </asp:TableCell><asp:TableCell  CssClass="style7">
                            <asp:TextBox ID="tbBOLNumber" runat="server"></asp:TextBox>
                            <asp:Label ID="lblBOLError" runat="server" ForeColor="Red" Text="*" Visible="false"/>
                        </asp:TableCell></asp:TableRow></asp:Table></ContentTemplate><Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlSubSystem"  
                    EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>

         <asp:UpdatePanel ID="upPriority" runat="server">
                        <ContentTemplate>
                            <asp:Table runat="server" ID="tblPriority" Width="800px">
                                <asp:TableRow>
                                    <asp:TableCell CssClass="style6"> Priority :</asp:TableCell><asp:TableCell CssClass="style7" >
                                         <asp:DropDownList ID="ddlPriority" runat="server" DataSourceID="sqlPriority" 
                                                 DataTextField="prioritydesc" DataValueField="priorityid" AppendDataBoundItems="True" >
                                            <asp:ListItem Value="000">PLEASE SELECT</asp:ListItem>
                                        </asp:DropDownList> <asp:Label ID="lblPriority" runat="server" ForeColor="Red" Text="*" 
                                    Visible="False"></asp:Label>
                                    </asp:TableCell></asp:TableRow></asp:Table></ContentTemplate><Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlSubSystem" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
      

        <table  style=" width: 56%">          
            <tr>
                <td>
                    Type:</td><td>
                    <asp:DropDownList ID="ddlType" runat="server" AppendDataBoundItems="True" 
                        DataSourceID="sqlType" DataTextField="Type" DataValueField="TypeID">
                        <asp:ListItem Value="000">PLEASE SELECT</asp:ListItem></asp:DropDownList><asp:Label ID="lblType" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label></td></tr><tr>
                <td>
                    Assigned To:</td><td>
                    <asp:DropDownList ID="ddlAssignedTo" runat="server" AppendDataBoundItems="True" AutoPostBack="true"
                        DataSourceID="sqlAssignedTo" DataTextField="Users" DataValueField="userId" OnSelectedIndexChanged="ddlAssignedTo_SelectedIndexChanged">
                        <asp:ListItem Value="000">PLEASE SELECT</asp:ListItem></asp:DropDownList><asp:Label ID="lblAssignedTo" runat="server" ForeColor="Red" Text="*" 
                        Visible="False"></asp:Label></td></tr><tr>
                <td>
                    Status:</td><td>
                    <asp:DropDownList ID="ddlStatus" 
                        runat="server" AppendDataBoundItems="True" 
                        AutoPostBack="True" DataSourceID="sqlStatus" DataTextField="Status" 
                        DataValueField="StatusID" onselectedindexchanged="ddlStatus_SelectedIndexChanged" 
                        ><asp:ListItem Value="000">PLEASE SELECT</asp:ListItem></asp:DropDownList><asp:Label ID="lblStatus" runat="server" ForeColor="Red" Text="*" 
                        Visible="False"></asp:Label></td></tr><tr>
                <td>
                    Problem Description:</td><td 
                    dir="ltr"><asp:TextBox ID="txtProbDescription" runat="server" Height="61px" 
                        MaxLength="3999" Width="350px" TextMode="MultiLine"></asp:TextBox><asp:Label ID="lblProblemDesc" runat="server" ForeColor="Red" Text="*" 
                        Visible="False"></asp:Label></td></tr><tr>
                <td>
                    <asp:Label ID="lblTargCompletionDate" runat="server" 
                        Text="Target Completion Date:"></asp:Label></td><td>
                    <asp:TextBox ID="txtTargetCompletionDate" runat="server"></asp:TextBox><asp:PopupControlExtender ID="txtTargetCompletionDate_PopupControlExtender" runat="server" DynamicServicePath="" Enabled="True" ExtenderControlID="" 
                        PopupControlID="CalendarPanel" Position="Right" TargetControlID="txtTargetCompletionDate">
                    </asp:PopupControlExtender>
                    <asp:Label ID="lblTargetCompletionDate" runat="server" ForeColor="Red" Text="*" 
                        Visible="False"></asp:Label></td></tr><tr>
                <td>
                    Repeat Isssue:</td><td>
                    <asp:DropDownList ID="ddlRepeatIssue" runat="server" 
                        AppendDataBoundItems="True" DataSourceID="sqlRepeatIssue" 
                        DataTextField="Repeat" DataValueField="Value">
                        <asp:ListItem Value="000">PLEASE SELECT</asp:ListItem></asp:DropDownList><asp:Label ID="lblRepeatIssue" runat="server" ForeColor="Red" Text="*" 
                        Visible="False"></asp:Label></td></tr><tr>
                <td>
                    <asp:Label ID="lblSkills" Text="Skill" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlSkill" runat="server" DataSourceID="sqlSkills" 
                        DataTextField="SkillSet" DataValueField="skillID" 
                        AppendDataBoundItems="True"><asp:ListItem Value="000">PLEASE SELECT</asp:ListItem></asp:DropDownList><asp:Label ID="lblSkillError" runat="server" Visible="false" ForeColor="Red" Text="*"/>
               </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblClosed" Text="IT Status" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlClosed" runat="server" >
                        <asp:ListItem Value="0000">PLEASE SELECT</asp:ListItem><asp:ListItem Text="Open" Value="1" />
                        <asp:ListItem Text="Closed" Value="0" />
                    </asp:DropDownList>
                     <asp:Label ID="lblClosedError" runat="server" Visible="false" ForeColor="Red" Text="*"/>
                </td>
            </tr>
            <tr>          
                <td>
                    <asp:Panel ID="CalendarPanel" runat="server" Width="200px">
                        <asp:UpdatePanel ID="UpdatePanelCalendar" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="Calendar" runat="server" BackColor="#FFFFCC" 
                                BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                                Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="184px" 
                                onselectionchanged="Calendar_SelectionChanged" Width="220px">
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
                </table>
                <asp:UpdatePanel ID="udpClosedInfo" runat="server" style=" width: 90%" >
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblImmediateFix" runat="server" Text="Immediate Fix:"></asp:Label></td><td>
                                <asp:TextBox ID="txtImmediateFix" runat="server" Height="61px" MaxLength="3999" Width="350px" TextMode="MultiLine"></asp:TextBox><asp:Label ID="lblImmediateFixError" runat="server" ForeColor="Red" Text="*" 
                                    Visible="false"></asp:Label></td></tr><tr>
                            <td class="style3"><asp:Label ID="lblRootCause" runat ="server" 
                                Text="Root Cause:"/></td>
                
                            <td class="style3"><asp:TextBox ID="txtRootCause" runat="server" Height="61px" 
                                    MaxLength="3999" Width="350px" TextMode="MultiLine"></asp:TextBox><asp:Label ID="lblRootCauseError" runat="server" ForeColor="Red" Text="*" Visible="false"></asp:Label></td></tr><tr>
                            <td>
                                <asp:Label ID="lblPermanentFix" runat="server" Text="Permanent Fix:"></asp:Label></td><td>
                                <asp:TextBox ID="txtPermanentFix" runat="server" Height="61px" MaxLength="3999" Width="350px" TextMode="MultiLine"></asp:TextBox><asp:Label ID="lblPermanentFixError" runat="server" ForeColor="Red" Text="*" Visible="false"></asp:Label></td></tr><tr>
                            <td>
                                <asp:Label ID="lblTimeToResolve" Visible="true" runat="server" Text="Time To Resolve (min):" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtTimeToResolve" Visible="true" runat="server" />
                                <asp:Label ID="lblTimeToResolveError" runat="server" ForeColor="Red" Text="*" Visible="false" />                    
                            </td>
                        </tr>
                    
                    </table>
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlSubSystem"  
                    EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>  
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
                    <asp:SqlDataSource ID="sqlSkills" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                        SelectCommand="SELECT * FROM tbl_skillSet"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlGetSubSystems" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                        SelectCommand="getSubSystem" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlSystem" Name="SystemID" 
                                PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlDepartment" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                        SelectCommand="SELECT * FROM [tbl_departments]"></asp:SqlDataSource>
                    <asp:SqlDataSource 
                        ID="sqlSystem" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                        
                        SelectCommand="SELECT [SystemID], [System] FROM [tbl_system_type] WHERE active =1 Order by System"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlPriority" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                        SelectCommand="SELECT * FROM [tbl_priority]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlType" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                        SelectCommand="SELECT * FROM [tbl_IssueType]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlAssignedTo" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                        SelectCommand="AssignedTo" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlStatus" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                        SelectCommand="GetStatus" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlRepeatIssue" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                        SelectCommand="SELECT * FROM [tbl_RepeatIssue]"></asp:SqlDataSource>

                    &nbsp; </td></tr></table></div><div id="Splash" class="CreateTicket" runat="server" visible="false">      
            <h2>Your Ticket has been entered successfully </h2><br />
                <p> Press the create tab to enter another ticket. </p><br />
               <p>Your ticket number is: <asp:Label ID="lblTicketNumber" runat="server" style="font-weight: 700"/></p>
        </div>
    </fieldset>
        </asp:Content>