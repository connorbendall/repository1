<%@ Page Title="Create Ticket" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" ValidateRequest="false"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        function OnSelectedIndexChange() {

            var prioity = document.getElementById('<%=ddlPriority.ClientID%>');

            if(prioity.value == 5)
                alert("Warning! You are about to create a 911/Escalation Priority Ticket!");

            document.form1.Button1.disabled = false;

        }
    
    
    </script>
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            font-size: small;
        }
        .style4
        {
            font-size: small;
            height: 55px;
        }
        .style5
        {
            height: 55px;
        }
        .style6
        {
            font-size: small;
            height: 29px;
        }
        .style7
        {
            height: 29px;
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
            fileExtension = fileName.substr(indexOfDot + 1, fileName.length - indexOfDot);

            // array of allowed file type extensions  
            var validFileExtensions = new Array("jpg", "png", "pdf", "docx", "xlsx", "msg", "doc", "xls", "txt", "ppt", "pptx", "csv");

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
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <fieldset>
            <legend>Create Ticket</legend>
            
            <div id="ticketEntry" class="CreateTicket" runat="Server" visible="True">
                Fill out The form below to create a ticket. Once submitted, you will recieve a Ticket #.<br/>Please make a note of this Ticket # for future reference.
                <br />
                
                <br/><b><font color="red">All fields are required.</font></b>
                <br />
                <table class="style2" style=" width: 59%">
                    <tr>
                        <td style="font-size: small">
                            Requested By:</td>
                        <td>
                            <asp:DropDownList ID="ddlEmployee" runat="server" AutoPostBack="True" 
                                DataSourceID="sqlEmployees" DataTextField="FullName" 
                                DataValueField="employeenumber" 
                                AppendDataBoundItems="True" Width="342px" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged">
                                <asp:ListItem Text="PLEASE SELECT" Value="000"/>
                                <asp:ListItem Text="OTHER" Value="00"/>
                            </asp:DropDownList>
                            <asp:Label ID="lblEmployee" runat="server" ForeColor="Red" Text="*" 
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            Email Address:</td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" Width="296px"></asp:TextBox>
                            <asp:Label ID="lblEmail" runat="server" ForeColor="Red" Text="*" 
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            Plant/Division:</td>
                        <td style="margin-left: 40px">
                            <asp:DropDownList ID="ddlPlant" runat="server" DataSourceID="sqlDivison" 
                                DataTextField="division" DataValueField="division" 
                                AppendDataBoundItems="True">
                            </asp:DropDownList>
                            <asp:Label ID="lblPlant" runat="server" ForeColor="Red" Text="*" 
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <font color = 'red'><b>What's Your Department:</b></font></td>
                        <td>
                            <asp:DropDownList ID="ddlDepartment" runat="server" 
                                DataSourceID="sqlDepartment" DataTextField="department" 
                                DataValueField="deptid" AppendDataBoundItems="True">
                                <asp:ListItem Text="PLEASE SELECT" Value="000"/>
                            </asp:DropDownList>
                            <asp:Label ID="lblDepartment" runat="server" ForeColor="Red" Text="*" 
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6">
                            System:</td>
                        <td class="style7">
                            <asp:DropDownList ID="ddlSystem" runat="server" DataSourceID="sqlSystem" DataTextField="System" DataValueField="SystemID" OnSelectedIndexChanged="ddlSystemSelectedIndexChanged" AutoPostBack="True" 
                                AppendDataBoundItems="True">
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
                            <asp:DropDownList ID="ddlSubSystem" runat="server" DataSourceID="sqlSubSystem" AutoPostBack="True" DataTextField="SubSystem" DataValueField="SubSystemID" 
                                AppendDataBoundItems="True" Visible="true" OnSelectedIndexChanged="ddlSubsystem_SelectedIndexChanged">
                                <asp:ListItem Value="000">PLEASE SELECT</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="lblSubsystemError" runat="server" ForeColor="Red" Text="*" 
                                Visible="False"></asp:Label>
                        </td>                        
                    </tr>
                    </table>                    
                    
                    <asp:UpdatePanel ID="upDetails" runat="server" UpdateMode="Conditional">
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
                                    </asp:TableCell></asp:TableRow></asp:Table></ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlSubSystem" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>


                    <asp:UpdatePanel ID="upPriority" runat="server">
                        <ContentTemplate>
                            <asp:Table runat="server" ID="tblPriority" Width="600px">
                                <asp:TableRow>
                                    <asp:TableCell CssClass="style6"> Priority :</asp:TableCell>
                                    <asp:TableCell CssClass="style7">
                                         <asp:DropDownList ID="ddlPriority" runat="server" DataSourceID="sqlPriority" 
                                                 DataTextField="prioritydesc" DataValueField="priorityid" AppendDataBoundItems="True" >
                                            <asp:ListItem Value="000">PLEASE SELECT</asp:ListItem>
                                        </asp:DropDownList> <asp:Label ID="lblPriority" runat="server" ForeColor="Red" Text="*" 
                                    Visible="False"></asp:Label>
                                    </asp:TableCell>
                                </asp:TableRow>           
                            </asp:Table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlSubSystem" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>


                    <table class="style2" style=" width: 59%">
                    <tr>
                        <td class="style3">
                            Problem Description:</td><td>
                            <asp:TextBox ID="txtProbDescription" runat="server" Height="77px" MaxLength="3999" 
                                Width="289px" TextMode="MultiLine"></asp:TextBox><asp:Label ID="lblDescription" runat="server" ForeColor="Red" Text="*" 
                                Visible="False"></asp:Label></td></tr><tr>
                        <td class="style3">
                            Repeat issue:</td><td>
                            <asp:DropDownList ID="ddlRepeatIssue" runat="server" 
                                DataSourceID="sqlRepeatIssue" DataTextField="Repeat" 
                                DataValueField="Value" AppendDataBoundItems="True">
                                <asp:ListItem Value="000">PLEASE SELECT</asp:ListItem></asp:DropDownList><asp:Label ID="lblRepeat" runat="server" ForeColor="Red" Text="*" 
                                Visible="False"></asp:Label></td></tr>
                        <tr>
                        <td class="style3">
                            &nbsp;</td><td>
                            <br />
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                                onclick="btnSubmit_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            <asp:SqlDataSource ID="sqlEmployees" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                                SelectCommand="GetEmployees" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="sqlDivison" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:HRDBConnectionString %>" 
                                
                                SelectCommand="SELECT division, active FROM tbl_division WHERE (active = 1)">
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="sqlDepartment" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                                SelectCommand="SELECT * FROM [tbl_departments] WHERE deptid &lt;&gt; 1 "></asp:SqlDataSource>

                           <asp:SqlDataSource ID="sqlSystem" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                                SelectCommand="SELECT [SystemID], [System] FROM [tbl_system_type] WHERE active =1 ORDER BY [System]">
                            </asp:SqlDataSource>

                            <asp:SqlDataSource ID="sqlSubSystem" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>"                                
                                SelectCommand="getSubSystem" SelectCommandType="StoredProcedure"><SelectParameters><asp:ControlParameter 
                                        ControlID="ddlSystem" Name="SystemID" PropertyName="SelectedValue" 
                                        Type="Int32" /></SelectParameters></asp:SqlDataSource>
                            <asp:SqlDataSource ID="sqlPriority" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                                SelectCommand="SELECT * FROM [tbl_priority]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="sqlAssigned" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                                SelectCommand="AssignedTo" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="sqlRepeatIssue" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                                SelectCommand="SELECT * FROM [tbl_RepeatIssue]"></asp:SqlDataSource>
                        </td>
                        <td class="style5">
                            </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td><td>
                            &nbsp;</td></tr><tr>
                        <td>
                            <asp:Label ID="lblTest" runat="server" ForeColor="Red"></asp:Label></td><td>
                            &nbsp;</td></tr><tr>
                        <td>
                            &nbsp;</td><td>
                            &nbsp;</td></tr></table><br />
            </div>
            <div id="Splash" class="CreateTicket" runat="Server" visible="False">
                <h2>Your Ticket has been entered successfully</h2><p>Your ticket number is:&nbsp;<asp:Label ID="lblTicketNumber" 
                    runat="server" style="font-weight: 700"></asp:Label><br />
                
                Press the return button to enter another ticket. <asp:Button ID="btnReturn" runat="server" onclick="btnReturn_Click" 
                    Text="Return" />
                </p>
                <br />
                <br />
                
                
            </div>
        </fieldset>
          </asp:Content>