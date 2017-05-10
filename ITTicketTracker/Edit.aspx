<%@ Page Title="Edit/View Tickets" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" ValidateRequest="false" EnableEventValidation ="false"
    CodeFile="Edit.aspx.cs" Inherits="About" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
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
            width: 91px;
        }
        .style5
        {
            height: 30px;
        }
        .style6
        {
            width: 91px;
            height: 21px;
        }
        .style7
        {
            height: 21px;
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
         function btnDelete_Click(filename)
         {
             var pageId = '<%=  Page.ClientID %>';
             __doPostBack(pageId, "Delete|" + filename);
         }
         function btnDownload_Click(filename) {
             var pageId = '<%=  Page.ClientID %>';
             __doPostBack(pageId, "Download|" + filename);
         }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <asp:ScriptManager ID="sp1" runat="server" ScriptMode="Release" />

    <fieldset>
   <legend>Edit/View Ticket</legend>

    <br />
    <input type="button" value="<- Back" onclick="history.back(-1)"/>   

   <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="true" />
   <div id="detailview"  runat="server" visible="False">
   
   <table>
    <tr>
        <td>
          <asp:DetailsView ID="dvTicket" runat="server" AutoGenerateRows="False" 
           CellPadding="4" DataKeyNames="issueid" 
           DataSourceID="sqlTickets" ForeColor="Black" GridLines="Vertical" 
           Height="50px" Width="550px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
           BorderWidth="1px" onitemupdated="dvTicket_ItemUpdated" DefaultMode="Edit" 
           onitemupdating="dvTicket_ItemUpdating"
           ondatabound="dvTicket_DataBound" OnPageIndexChanging="dvTicket_PageIndexChanging" >
           <AlternatingRowStyle BackColor="White" />
           <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
           <Fields>
               <asp:TemplateField HeaderText="" Visible="true">
                   <EditItemTemplate>
                       <asp:Label ID="lblSelectedSubSys" runat="server" Text='<%# Bind("subSystem") %>' Visible="false"></asp:Label>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:Label ID="Label17" runat="server" Text='<%# Bind("subSystem") %>'></asp:Label>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label13" runat="server" Text='<%# Bind("subSystem") %>' 
                           Visible="False"></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               
                <asp:TemplateField HeaderText="lblPhase" Visible="true">
                   <EditItemTemplate>
                       <asp:Label ID="lblSelectedPhase" runat="server" Text='<%# Bind("phase") %>' Visible="false"></asp:Label>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:Label ID="lblSelectedPhase" runat="server" Text='<%# Bind("phase") %>'></asp:Label>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="lblSelectedPhase" runat="server" Text='<%# Bind("phase") %>' 
                           Visible="False"></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               

               <asp:BoundField DataField="issueid" HeaderText="Ticket Number:" 
                   InsertVisible="False" ReadOnly="True" SortExpression="issueid" />
               <asp:TemplateField HeaderText="Entered By:" SortExpression="EnteredBy">
                   <EditItemTemplate>
                       <asp:Label ID="lblEnteredBy" runat="server" Text='<%# Bind("EnteredBy") %>'></asp:Label>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("EnteredBy") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label2" runat="server" Text='<%# Bind("EnteredBy") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Requester:" SortExpression="Issuer">
                   <EditItemTemplate>
                       <asp:DropDownList ID="ddlEditRequester" runat="server" AppendDataBoundItems="True" 
                           DataSourceID="sqlemployees" DataTextField="FullName" 
                           DataValueField="employeenumber" SelectedValue='<%# Bind("Issuer") %>'>
                           <asp:ListItem Value="0">OTHER</asp:ListItem>
                       </asp:DropDownList>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Issuer") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:DropDownList ID="ddlRequester" runat="server" AppendDataBoundItems="True" 
                           DataSourceID="sqlemployees" DataTextField="FullName" 
                           DataValueField="employeenumber" Enabled="False" 
                           SelectedValue='<%# Bind("Issuer") %>'>
                           <asp:ListItem Value="0">OTHER</asp:ListItem>
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Email:" SortExpression="email">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label3" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Department:" SortExpression="Dept">
                   <EditItemTemplate>
                       <asp:DropDownList ID="ddlEditDept" runat="server" DataSourceID="sqldept" 
                           DataTextField="department" DataValueField="deptid" 
                           SelectedValue='<%# Bind("Dept") %>'>
                       </asp:DropDownList>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Dept") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>  
                       <asp:DropDownList ID="ddlDept" runat="server" DataSourceID="sqldept" 
                           DataTextField="department" DataValueField="deptid" Enabled="False" 
                           SelectedValue='<%# Bind("Dept") %>'>
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Plant:" SortExpression="division">
                   <EditItemTemplate>
                       <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="sqlDivision" 
                           DataTextField="division" DataValueField="division" 
                           SelectedValue='<%# Bind("division") %>'>
                       </asp:DropDownList>
                       <asp:SqlDataSource ID="sqlDivision" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:HRDBConnectionString %>" 
                           SelectCommand="ActiveDivisions" SelectCommandType="StoredProcedure">
                       </asp:SqlDataSource>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("division") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label12" runat="server" Text='<%# Bind("division") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Date Created:" SortExpression="datecreated">
                   <EditItemTemplate>
                       <asp:Label ID="Label8" runat="server" 
                           Text='<%# Eval("datecreated", "{0:d}") %>'></asp:Label>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("datecreated") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label8" runat="server" 
                           Text='<%# Eval("datecreated", "{0:d}") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Last Update:" InsertVisible="False" 
                   SortExpression="lastupdate">
                   <EditItemTemplate>
                       <asp:Label ID="Label15" runat="server" 
                           Text='<%# Bind("lastupdate", "{0:g}") %>'></asp:Label>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("dateclosed") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label15" runat="server" 
                           Text='<%# Eval("lastupdate", "{0:d}") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Problem Description:" 
                   SortExpression="problemdescription">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox21" runat="server" Height="82px" 
                           Text='<%# Bind("problemdescription") %>' TextMode="MultiLine" Width="412px"></asp:TextBox>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox4" runat="server" 
                           Text='<%# Bind("problemdescription") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label4" runat="server" Text='<%# Bind("problemdescription") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Repeat Issue:" SortExpression="repeatissue">
                   <EditItemTemplate>
                       <asp:DropDownList ID="ddlrepeatIssue" runat="server" 
                           DataSourceID="sqlRepeatIssue" DataTextField="Repeat" DataValueField="Value" 
                           SelectedValue='<%# Bind("repeatissue") %>' AppendDataBoundItems="True">
                           <asp:ListItem Value="">NOT SPECIFIED</asp:ListItem>
                       </asp:DropDownList>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("repeatissue") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:DropDownList ID="ddlrepeatIssue" runat="server" 
                           DataSourceID="sqlRepeatIssue" DataTextField="Repeat" DataValueField="Value" 
                           Enabled="False" SelectedValue='<%# Bind("repeatissue") %>' 
                           AppendDataBoundItems="True">
                           <asp:ListItem Value="">OTHER</asp:ListItem>
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText ="**CLASSIFICATION**" >
                   <EditItemTemplate>
                       <hr />
                   </EditItemTemplate>
                   <ItemTemplate>
                       <hr />
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Class Type:" SortExpression="classType">
                   <EditItemTemplate>
                       <asp:DropDownList ID="ddlClassType" runat="server"  
                           DataSourceID="sqlClassType" DataTextField="classType" 
                           DataValueField="classID" SelectedValue='<%# Bind("classType") %>'>
                          
                       </asp:DropDownList>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ClassType") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:DropDownList ID="ddlClassType" runat="server" 
                           DataSourceID="sqlClassType" DataTextField="classType" 
                           DataValueField="classID" Enabled="False" 
                           SelectedValue='<%# Bind("ClassType") %>'>
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Category:" SortExpression="category">
                   <EditItemTemplate>
                       <asp:DropDownList ID="ddlCategory" runat="server"  
                           DataSourceID="sqlCategory" DataTextField="category" 
                           DataValueField="categoryID" SelectedValue='<%# Bind("category") %>'>
                          
                       </asp:DropDownList>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("category") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:DropDownList ID="ddlCategory" runat="server"  
                           DataSourceID="sqlCategory" DataTextField="category" 
                           DataValueField="categoryID" Enabled="False" 
                           SelectedValue='<%# Bind("category") %>'>
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>












               <asp:TemplateField HeaderText="System:" SortExpression="system">
                   <EditItemTemplate>
                       <asp:DropDownList ID="ddlEditSystem" runat="server" DataSourceID="sqlSystem" 
                           DataTextField="System" DataValueField="SystemID" AutoPostBack="True"
                           SelectedValue='<%# Bind("system") %>' 
                           onselectedindexchanged="ddlEditSystem_SelectedIndexChanged" 
                           ondatabound="ddlEditSystem_DataBound">
                       </asp:DropDownList>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("system") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:DropDownList ID="ddlSystem" runat="server" DataSourceID="sqlSystem" 
                           DataTextField="System" DataValueField="SystemID" Enabled="False" 
                           SelectedValue='<%# Bind("system") %>'>
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>
              
                <asp:TemplateField HeaderText="SubSystem" >
                   <EditItemTemplate>
                       <asp:DropDownList ID="ddlSubsystemEdit" runat="server" DataSourceID="sqlSubsystem"
                           DataTextField="SubSystem" DataValueField="subsystemID" 
                           onselectedindexchanged="ddlSubsystemEdit_SelectedIndexChanged" 
                           AutoPostBack="True"  >
                       </asp:DropDownList>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox18" runat="server" Text='<%# Bind("SubSystem") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:DropDownList ID="ddlSubsystemItem" runat="server" DataSourceID="sqlSubsystem" 
                           DataTextField="SubSystem" DataValueField="subsystemID" Enabled="False"  
                           ondatabound="ddlSubsystemItem_DataBound" >
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>







               <asp:TemplateField HeaderText="Priority:" SortExpression="priority">
                   <EditItemTemplate>
                       <asp:DropDownList ID="ddlEditPriority" runat="server" DataSourceID="sqlPriority" 
                           DataTextField="prioritydesc" DataValueField="priorityid" 
                           SelectedValue='<%# Bind("priority") %>' AppendDataBoundItems="True">
                           <asp:ListItem Value="">OTHER</asp:ListItem>
                       </asp:DropDownList>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("priority") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:DropDownList ID="ddlPriority" runat="server" DataSourceID="sqlPriority" 
                           DataTextField="prioritydesc" DataValueField="priorityid" Enabled="False" 
                           SelectedValue='<%# Bind("priority") %>' AppendDataBoundItems="True">
                           <asp:ListItem Value="">OTHER</asp:ListItem>
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Type:" SortExpression="Type">
                   <EditItemTemplate>
                       <asp:DropDownList ID="ddlIssueType" runat="server" DataSourceID="sqlIssueType" 
                           DataTextField="Type" DataValueField="TypeID" 
                           SelectedValue='<%# Bind("Type") %>' AppendDataBoundItems="True">
                           <asp:ListItem Value="">OTHER</asp:ListItem>
                       </asp:DropDownList>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("Type") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:DropDownList ID="ddlIssueType" runat="server" DataSourceID="sqlIssueType" 
                           DataTextField="Type" DataValueField="TypeID" Enabled="False" 
                           SelectedValue='<%# Bind("Type") %>' AppendDataBoundItems="True">
                           <asp:ListItem Value="">OTHER</asp:ListItem>
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>



               <asp:TemplateField HeaderText="Project" SortExpression="prjNum">
                   <EditItemTemplate>
                       <asp:DropDownList ID="ddlprjNum" runat="server" 
                           DataSourceID="sqlprjNum" DataTextField="Project_Name" DataValueField="Project_Id" 
                           SelectedValue='<%# Bind("prjNum") %>'   AppendDataBoundItems="True" Autopostback="true"
                            onselectedindexchanged="ddlprjNum_SelectedIndexChanged" 
                           >
                           <asp:ListItem Value="">NONE</asp:ListItem>
                           <asp:ListItem Value= "0">NONE</asp:ListItem>
                           
                       </asp:DropDownList>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="txtprjNum" runat="server" Text='<%# Bind("prjNum") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:DropDownList ID="ddlprjNum" runat="server" 
                           DataSourceID="sqlprjNum" DataTextField="Project_Name" DataValueField="Project_Id" 
                           Enabled="False" SelectedValue='<%# Bind("prjNum") %>' AppendDataBoundItems="True" Autopostback="true"
                           onselectedindexchanged="ddlprjNum_SelectedIndexChanged">
                           <asp:ListItem Value= "">NONE</asp:ListItem>
                           <asp:ListItem Value= "0">NONE</asp:ListItem>
                          
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>

               <asp:TemplateField HeaderText="Phase" SortExpression="sqlphase">
                   <EditItemTemplate>
                       <asp:DropDownList ID="ddlphase" runat="server" 
                           onselectedindexchanged="ddlphase_SelectedIndexChanged" 
                             AppendDataBoundItems="True" >
                           <asp:ListItem Value= "">NONE</asp:ListItem>
                           
                       </asp:DropDownList>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="txtphase" runat="server" Text='<%# Bind("phase2") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:DropDownList ID="ddlphase" runat="server" onselectedindexchanged="ddlphase_SelectedIndexChanged"
                        
                           Enabled="False"  AppendDataBoundItems="True">
                           <asp:ListItem Value= "">NONE</asp:ListItem>
                          
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>
             





               <asp:TemplateField HeaderText="Assigned To:" SortExpression="assignedto">
                   <EditItemTemplate>
                       <asp:DropDownList ID="ddlAssignedTo" runat="server" 
                           DataSourceID="sqlAssignedTo" DataTextField="Users" DataValueField="userId" 
                           SelectedValue='<%# Bind("assignedto") %>' AutoPostBack="True" 
                           onselectedindexchanged="ddlAssignedTo_SelectedIndexChanged">
                       </asp:DropDownList>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("assignedto") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:DropDownList ID="DropDownList4" runat="server" 
                           DataSourceID="sqlAssignedTo" DataTextField="Users" DataValueField="userId" 
                           Enabled="False" SelectedValue='<%# Bind("assignedto") %>'>
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Target Completion Date:" 
                   SortExpression="targetcompletiondate">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("targetcompletiondate", "{0:d}") %>'></asp:TextBox>
                        <asp:PopupControlExtender ID="txtTargetCompletionDate_PopupControlExtender" runat="server" DynamicServicePath="" Enabled="True" ExtenderControlID="" 
                                    PopupControlID="CalendarPanel" Position="Right" TargetControlID="TextBox9">
                        </asp:PopupControlExtender>
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
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox9" runat="server" 
                           Text='<%# Bind("targetcompletiondate", "{0:d}") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label9" runat="server" 
                           Text='<%# Bind("targetcompletiondate", "{0:d}") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Target Completion Time (mins):" SortExpression="targetcomptime">
                   <EditItemTemplate>
                       <asp:TextBox runat="server" ID="inputTargetComp" Text='<%# Bind("targetcomptime") %>'></asp:TextBox>
                   </EditItemTemplate>

                   <ItemTemplate>
                        <asp:Label runat="server" ID="inputTargetComp" Text='<%# Bind("targetcomptime") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Status:" SortExpression="status">
                   <EditItemTemplate>
                       <asp:DropDownList ID="ddlStatusEdit" runat="server" DataSourceID="sqlStatus" 
                           DataTextField="Status" DataValueField="StatusID" 
                           SelectedValue='<%# Bind("status") %>' 
                           ondatabound="ddlStatusEdit_DataBound">
                       </asp:DropDownList>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="sqlStatus" 
                           DataTextField="Status" DataValueField="StatusID" Enabled="False" 
                           SelectedValue='<%# Bind("status") %>'>
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>
<asp:TemplateField HeaderText="Immediate Fix "><EditItemTemplate>
                       <asp:TextBox ID="txtImmediateFix" runat="server" Height="80px" 
                           TextMode="MultiLine" Width="350px" Text='<%# Bind("resolution") %>'></asp:TextBox>
                   
</EditItemTemplate>
<InsertItemTemplate>
                       <asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
                   
</InsertItemTemplate>
<ItemTemplate>
                       <asp:Label ID="Label5" runat="server" Text='<%# Eval("resolution") %>'></asp:Label>
                   
</ItemTemplate>
</asp:TemplateField>
               <asp:TemplateField HeaderText="Verification Date" SortExpression="verificationDate">
                   <EditItemTemplate>
                       <asp:Label ID="Label18" runat="server" Text='<%# Eval("ifix_tmsp") %>'></asp:Label>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox19" runat="server" 
                           Text='<%# Bind("verificationDate", "{0:d}") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="lblVerificationItem" runat="server" 
                           Text='<%# Eval("ifix_tmsp") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Root Cause">
                   <EditItemTemplate>
                       <asp:TextBox ID="txtRootCauseEdit" runat="server" Height="80px" 
                           Text='<%# Bind("rootCause") %>' TextMode="MultiLine" Width="350px"></asp:TextBox>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label11" runat="server" Text='<%# Eval("rootCause") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Root Cause Date">
                   <EditItemTemplate>
                       <asp:Label ID="Label19" runat="server" Text='<%# Eval("rootCause_tmsp") %>'></asp:Label>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label7" runat="server" Text='<%# Eval("rootCause_tmsp") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Permanent Fix">
                   <EditItemTemplate>
                       <asp:TextBox ID="tbPermanentFix" runat="server" Height="80px" 
                           TextMode="MultiLine" Width="350px" Text='<%# Bind("PCA") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox24" runat="server"></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label14" runat="server" Text='<%# Eval("PCA") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Permanent Fix Date">
                   <EditItemTemplate>
                       <asp:Label ID="Label20" runat="server" Text='<%# Eval("PCA_tmsp") %>'></asp:Label>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox26" runat="server"></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label16" runat="server" Text='<%# Eval("PCA_tmsp") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Time To Resolve (min)">
                   <EditItemTemplate>
                       <asp:TextBox ID="txtTimeToResolveEdit" runat="server"
                           Text='<%# Bind("resolveTime") %>' ReadOnly="True"></asp:TextBox>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox20" runat="server" Text='<%# Bind("resolveTime") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label6" runat="server" Text='<%# Bind("resolveTime") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Verification Status">
                   <EditItemTemplate>
                       <asp:DropDownList ID="DropDownList10" runat="server" 
                           SelectedValue='<%# Bind("ticket_status") %>'>
                           <asp:ListItem Text="Open" Value="1" />
                           <asp:ListItem Text="Closed" Value="0" />
                       </asp:DropDownList>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox25" runat="server"></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:DropDownList ID="DropDownList11" runat="server" 
                           SelectedValue='<%# Bind("ticket_status") %>' Enabled="False">
                           <asp:ListItem Text="Open" Value="1" />
                           <asp:ListItem Text="Closed" Value="0" />
                       </asp:DropDownList>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Actual Completion Date:" 
                   SortExpression="actualcompletiondate">
                   <EditItemTemplate>
                       <asp:Label ID="lblActualCompletionDate" runat="server" 
                           Text='<%# Eval("actualcompletiondate") %>'></asp:Label>
                   </EditItemTemplate>
                   <InsertItemTemplate>
                       <asp:TextBox ID="TextBox10" runat="server" 
                           Text='<%# Bind("actualcompletiondate") %>'></asp:TextBox>
                   </InsertItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label10" runat="server" 
                           Text='<%# Bind("actualcompletiondate", "{0:d}") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:CommandField ShowEditButton="True" ButtonType="Button"  />
           </Fields>
           <FooterStyle BackColor="#CCCC99" />
           <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
           <RowStyle BackColor="#F7F7DE" />
       </asp:DetailsView>
        </td>
        <td valign="top" >
           
           <div runat="server" id="divExtra">
               <asp:UpdatePanel runat="server" >
                <ContentTemplate>
                     <asp:GridView ID="gvComments" runat="server" 
                       AllowSorting="True" BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" 
                       BorderWidth="2px" CellPadding="4" Height="50px" Width="480px"
                            AutoGenerateColumns="False" PageSize="6" DataKeyNames="commentID"
                       style="margin-right: 0px" DataSourceID="sqlComment" AllowPaging="True">
                           <Columns>
                               <asp:CommandField DeleteText="Delete" ShowDeleteButton="True"></asp:CommandField>
                               <asp:BoundField DataField="commentText" HeaderText="Comment" 
                                   SortExpression="commentText" />
                               <asp:BoundField DataField="dateEntered" HeaderText="Date Entered" 
                                   SortExpression="dateEntered" />
                               <asp:BoundField DataField="comment_entered_by" HeaderText="Comment From" 
                                   NullDisplayText="N/A" />
                               <asp:BoundField DataField="IT_Skill" HeaderText="IT Skill" />
                               <asp:BoundField DataField="timetoresolve" HeaderText="Time Required" />
                           </Columns>
                       <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                       <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                       <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                       <RowStyle BackColor="White" ForeColor="#330099" />
                       <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                       <SortedAscendingCellStyle BackColor="#FEFCEB" />
                       <SortedAscendingHeaderStyle BackColor="#AF0101" />
                       <SortedDescendingCellStyle BackColor="#F6F0C0" />
                       <SortedDescendingHeaderStyle BackColor="#7E0000" />
                   </asp:GridView>
                </ContentTemplate>
                <Triggers >
                    <asp:AsyncPostBackTrigger ControlID="dvComments" EventName ="ItemInserted" />  
                </Triggers>
              </asp:UpdatePanel>

            <asp:DetailsView ID="dvComments" runat="server" AutoGenerateRows="False" 
                   CellPadding="4" DefaultMode="Insert" AllowPaging="True"
                   ForeColor="Black" GridLines="Vertical" Height="50px" Width="480px" 
                   BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
                   BorderWidth="1px" DataSourceID="sqlComment" 
                    oniteminserting="dvComments_ItemInserting"
                    oniteminserted="dvComments_ItemInserted">
                   <AlternatingRowStyle BackColor="White" />
                   <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                   <Fields>
                       <asp:TemplateField HeaderText="Comment" SortExpression="commentText">
                           <EditItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%# Bind("commentText") %>'></asp:Label>
                           </EditItemTemplate>
                           <InsertItemTemplate>
                               <asp:TextBox ID="TextBox1" runat="server" Width="300"  Text='<%# Bind("commentText") %>' 
                                   TextMode="MultiLine"></asp:TextBox>
                           </InsertItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%# Bind("commentText") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comment From">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlEmployeeComment" runat="server" 
                                    DataSourceID="sqlemployees" DataTextField="FullName" 
                                    DataValueField="employeenumber">
                                </asp:DropDownList>
                            </ItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="ddlEmployeeComment" runat="server" 
                                    DataSourceID="sqlAssignedTo" DataTextField="Users" 
                                    DataValueField="Users">
                                </asp:DropDownList>
                            </InsertItemTemplate>
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="IT Skill">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlITSkill" runat="server" DataSourceID="sdsITSkill" 
                                    DataTextField="skillSet" DataValueField="skillSet">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="sdsITSkill" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                                    SelectCommand="SELECT [skillSet] FROM [tbl_skillset]"></asp:SqlDataSource>
                            </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Time To Resolve (min)">
                           <ItemTemplate>
                               <asp:TextBox ID="txtTimeReq" runat="server"></asp:TextBox>
                           </ItemTemplate>
                       </asp:TemplateField>
                        <asp:CommandField ShowInsertButton="true" ButtonType="Button" InsertText="Add"  />
                   </Fields>
                   <FooterStyle BackColor="#CCCC99" />
                   <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                   <RowStyle BackColor="#F7F7DE" />
               </asp:DetailsView>

               <br />
               <br />
               <br />
               <fieldset>
               <legend>File Upload</legend>
                    <asp:Label ID="lblUpload" runat="server" Text="Upload Document (Up to ten per Ticket)." />
                    <ajaxToolkit:AsyncFileUpload runat="server" ID="AsyncFileUpload1" Width="380px" UploaderStyle="Traditional"   
                       OnClientUploadComplete="validateFileUpload" UploadingBackColor="#CCFFFF" ThrobberID="myThrobber"  onuploadedcomplete="AsyncFileUpload1_UploadedComplete"/>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Green = File Uploaded Successfully or File Error Message" ForeColor="Green" />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Red = Issue Uploading File" ForeColor="Red" />
                    <br />

               <div id="divFile" runat="server">
                        
                </div>  
                 <asp:Label Visible="false" ID="lblFileIssue" runat="server" Text="Unable to load File/Direcotry Information At This Time" ForeColor="Red" Font-Bold="true" />
               
                <asp:Button id="btnRefreshFiles"
           Text="Refresh Files"
           OnCommand="btnRefreshFiles_Click" 
           runat="server"/>
               </fieldset>

               <div id="thisDiv" runat="server">
                   <p id ="thisP" runat="server"></p>
               </div>
            




                <asp:SqlDataSource ID="sqlComment" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                    InsertCommand="InsertComment" InsertCommandType="StoredProcedure" 
                    SelectCommand="GetComments" SelectCommandType="StoredProcedure" 
                    DeleteCommand="DELETE FROM tbl_Ticket_Comments WHERE commentID = @commentID">
                    <DeleteParameters>
                        <asp:Parameter Name="commentID" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:ControlParameter ControlID="lblIndex" Name="ticketID" PropertyName="Text" 
                            Type="Int32" />
                        <asp:Parameter Name="commentText" Type="String" />
                        <asp:Parameter Name="UserType" Type="Int32" DefaultValue="1" />
                        <asp:ControlParameter Name="user_entry_id" Type="String" ControlID="dvComments$ddlEmployeeComment" PropertyName="SelectedValue" />
                        <asp:ControlParameter Name="skill" Type="String" ControlID="dvComments$ddlITSkill" PropertyName="SelectedValue" />
                        <asp:ControlParameter Name="timetoresolve" Type="String" ControlID="dvComments$txtTimeReq" DefaultValue="0" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lblIndex" Name="ticketID" PropertyName="Text" 
                            Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </td>
    </tr>
   
   </table>
     
  
       <asp:Label ID="lblIndex" runat="server" Visible="False"></asp:Label>
       <br />
       <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
       <asp:Label ID="lblSystemID" runat ="server" Visible="false" Text=""/>
       <asp:SqlDataSource ID="dsSubSystem" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                           
           
           SelectCommand="SELECT SystemID, SubSystemID, SubSystem FROM tbl_SubSystem  WHERE SystemID =42">
       </asp:SqlDataSource>
       &nbsp;<asp:SqlDataSource ID="sqlSkillSet" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                           SelectCommand="SELECT * FROM tbl_skillSet">
       </asp:SqlDataSource>

       <asp:SqlDataSource ID="sqlSystem" runat="server"  ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
            
           SelectCommand="SELECT SystemID, System, internalsupport, reportfrom, active FROM tbl_system_type WHERE (active = 1) ORDER BY System">
       </asp:SqlDataSource>

       <asp:SqlDataSource ID="sqlSubsystem" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                           SelectCommand="getSubSystem" SelectCommandType="StoredProcedure">
           <SelectParameters>
               <asp:ControlParameter ControlID="lblSystemID" Name="SystemID" 
                                   PropertyName="Text" Type="Int32" DefaultValue="" />
           </SelectParameters>
       </asp:SqlDataSource>

       <asp:SqlDataSource ID="sqlAssignedTo" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                       SelectCommand="AssignedTo" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="sqlPrjNum" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                       SelectCommand="SELECT DISTINCT Project_Name, Project_ID FROM tbl_Projects" >
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="sqlphase" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                       SelectCommand="SELECT DISTINCT Phase_Name, Phase_ID FROM tbl_Project_Phase" >
           
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="sqlStatus" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                       SelectCommand="SELECT * FROM [tbl_Status]">
        </asp:SqlDataSource>
       <br />
       <asp:SqlDataSource ID="sqlTicket" runat="server" 
           ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
           DeleteCommand="DELETE FROM [tbl_issues2] WHERE [issueid] = @issueid" 
           InsertCommand="INSERT INTO [tbl_issues2] ([Issuer], [email], [Dept], [system], [problemdescription], [assignedto], [priority], [ITpriority], [resolution], [datecreated], [targetcompletiondate], [actualcompletiondate], [repeatissue], [comments], [division], [lastupdate], [Type], [status], [externalticket], [externalsupport], [dateclosed], [EnteredBy], prjNum, phase) VALUES (@Issuer, @email, @Dept, @system, @problemdescription, @assignedto, @priority, @ITpriority, @resolution, @datecreated, @targetcompletiondate, @actualcompletiondate, @repeatissue, @comments, @division, @lastupdate, @Type, @status, @externalticket, @externalsupport, @dateclosed, @EnteredBy, @prjNum, @phase)" 
           SelectCommand="SELECT issueid, Issuer, email, Dept, system, problemdescription, assignedto, priority, resolution, datecreated, targetcompletiondate, actualcompletiondate, repeatissue, division, lastupdate, Type, status, dateclosed, EnteredBy,verificationDate, resolveTime, prjNum, phase FROM tbl_issues2 WHERE (issueid = @issueid)" 
           
           UpdateCommand="updateTicket" 
           onselected="sqlTicket_Selected" UpdateCommandType="StoredProcedure">
           <DeleteParameters>
               <asp:Parameter Name="issueid" Type="Decimal" />
           </DeleteParameters>
           <InsertParameters>
               <asp:Parameter Name="Issuer" Type="Int32" />
               <asp:Parameter Name="email" Type="String" />
               <asp:Parameter Name="Dept" Type="Int32" />
               <asp:Parameter Name="system" Type="Int32" />
               <asp:Parameter Name="problemdescription" Type="String" />
               <asp:Parameter Name="assignedto" Type="Int32" />
               <asp:Parameter Name="priority" Type="Int32" />
               <asp:Parameter Name="ITpriority" />
               <asp:Parameter Name="resolution" Type="String" />
               <asp:Parameter Name="datecreated" Type="DateTime" />
               <asp:Parameter Name="targetcompletiondate" Type="DateTime" />
               <asp:Parameter Name="actualcompletiondate" Type="DateTime" />
               <asp:Parameter Name="repeatissue" Type="Int32" />
               <asp:Parameter Name="comments" Type="String" />
               <asp:Parameter Name="division" Type="String" />
               <asp:Parameter Name="lastupdate" Type="DateTime" />
               <asp:Parameter Name="Type" Type="Int32" />
               <asp:Parameter Name="status" Type="Int32" />
               <asp:Parameter Name="externalticket" />
               <asp:Parameter Name="externalsupport" />
               <asp:Parameter Name="dateclosed" />
               <asp:Parameter Name="EnteredBy" Type="String" />
               <asp:Parameter Name="prjNum" Type="String"/>
                <asp:Parameter Name="phase" Type="String"/>
               <asp:Parameter Name="ClassType" Type="Int32" />
               <asp:Parameter Name="category" Type="Int32" />
               <asp:Parameter Name="targetCompTime" Type="Int32" />
           </InsertParameters>
           <SelectParameters>
               <asp:ControlParameter ControlID="lblIndex" Name="issueid" PropertyName="Text" />
           </SelectParameters>
           <UpdateParameters>
               <asp:Parameter Name="issueid" Type="Decimal" />
               <asp:Parameter Name="Issuer" Type="Int32" />
               <asp:Parameter Name="email" Type="String" />
               <asp:Parameter Name="Dept" Type="Int32" />
               <asp:Parameter Name="system" Type="Int32" />
               <asp:Parameter Name="problemdescription" Type="String" />
               <asp:Parameter Name="assignedto" Type="Int32" />
               <asp:Parameter Name="priority" Type="Int32" />
               <asp:Parameter Name="resolution" Type="String" />
               <asp:Parameter Name="targetcompletiondate" Type="DateTime" />
               <asp:Parameter Name="actualcompletiondate" Type="DateTime" />
               <asp:Parameter Name="repeatissue" Type="Int32" />
               <asp:Parameter Name="comments" Type="String" />
               <asp:Parameter Name="division" Type="String" />
               <asp:Parameter Name="Type" Type="Int32" />
               <asp:Parameter Name="status" Type="Int32" />
               <asp:Parameter Name="EnteredBy" Type="String" />
                 <asp:Parameter Name="prjNum" Type="String"/>
                <asp:Parameter Name="phase" Type="String"/>
              
               <asp:Parameter Name="classType" Type="Int32" />
               <asp:Parameter Name="category" Type="Int32" />
               <asp:Parameter Name="targetCompTime" Type="Int32" />

           </UpdateParameters>
       </asp:SqlDataSource>
       <asp:SqlDataSource ID="sqlTickets" runat="server" 
           ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
           SelectCommand="SELECT issueid, Issuer, email, Dept, system, subSystem, problemdescription, assignedto, priority, resolution, datecreated, targetcompletiondate, actualcompletiondate, repeatissue, division, lastupdate, Type, status, dateclosed, EnteredBy, verificationDate, resolveTime, rootCause, rootCause_tmsp, ifix_tmsp, PCA, PCA_tmsp, ticket_Status, prjNum, phase, classType, category, targetCompTime
FROM tbl_issues2  WHERE (issueid = @issueid)" UpdateCommand="UPDATE [tbl_issues2]

      SET [Issuer] = @Issuer, 

            [email] = @email, 

            [Dept] = @Dept, 

            [system] = @system, 

            [lastupdate]= GETDATE(),  

            [problemdescription] = @problemdescription, 

            [assignedto] = @assignedto, 

            [priority] = @priority,  

            [resolution] = @resolution, 

            [targetcompletiondate] = @targetcompletiondate,  

            [actualcompletiondate] = @actualcompletiondate, 

            [repeatissue] = @repeatissue, 

            [comments] = @comments, 

            [division] = @division, 

            [Type] = @Type, 

            [status] = @status, 

            [EnteredBy] = @EnteredBy,

            verificationDate =@verificationDate, 

            resolveTime = @resolveTime,

            subSystem = @subSystem,

            rootCause = @rootCause,   

            PCA = @pca,

            ticket_status = @ticket_status,
            
            prjNum = @prjNum,
            
           phase = @phase,

            classType = @classType,
            
            category = @category,
            
            targetCompTime = @targetCompTime 
            
      WHERE [issueid] = @issueid
">
           <SelectParameters>
               <asp:ControlParameter ControlID="lblIndex" Name="issueid" PropertyName="Text" />
           </SelectParameters>
           <UpdateParameters>
               <asp:Parameter Name="Issuer" />
               <asp:Parameter Name="email" />
               <asp:Parameter Name="Dept" />
               <asp:Parameter Name="system" Type="Int32" />
               <asp:Parameter Name="problemdescription" />
               <asp:Parameter Name="assignedto" Type="Int32" />
               <asp:Parameter Name="priority" Type="Int32" />
               <asp:Parameter Name="resolution" Type="String" />
               <asp:Parameter Name="targetcompletiondate" />
               <asp:Parameter Name="actualcompletiondate" />
               <asp:Parameter Name="repeatissue" />
               <asp:Parameter Name="comments" />
               <asp:Parameter Name="division" />
               <asp:Parameter Name="Type" />
               <asp:Parameter Name="status" Type="Int32" />
               <asp:Parameter Name="EnteredBy" />
               <asp:Parameter Name="verificationDate" />
               <asp:Parameter Name="resolveTime" Type="String" />
               <asp:Parameter Name="subSystem" Type="Int32" />
               <asp:Parameter Name="rootCause" />
               <asp:Parameter Name="PCA" />
               <asp:Parameter Name="ticket_status" />
               <asp:Parameter Name="prjNum" Type="String" />
               <asp:Parameter Name="phase" Type="String" />
               <asp:Parameter Name="issueid" Type="Int32" />
               <asp:Parameter Name="ClassType" Type="Int32" />
               <asp:Parameter Name="category" Type="Int32" />
               <asp:Parameter Name="targetCompTime" Type="Int32" />
           </UpdateParameters>
       </asp:SqlDataSource>
       <asp:SqlDataSource ID="sqlRepeatIssue" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                           SelectCommand="SELECT * FROM [tbl_RepeatIssue]">
       </asp:SqlDataSource>
       <asp:SqlDataSource ID="sqlemployees" runat="server" 
           ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
           SelectCommand="GetALLEmployees" SelectCommandType="StoredProcedure">
       </asp:SqlDataSource>
       <asp:SqlDataSource ID="sqlClassType" runat="server" 
           ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
           SelectCommand="select * from tbl_classType">
       </asp:SqlDataSource>
       <asp:SqlDataSource ID="sqlCategory" runat="server" 
           ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
           SelectCommand="select * from tbl_category">
       </asp:SqlDataSource>
       <asp:SqlDataSource ID="sqldept" runat="server" 
           ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
           SelectCommand="SELECT * FROM [tbl_departments]"></asp:SqlDataSource>
                   <asp:SqlDataSource ID="sqlPriority" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                       SelectCommand="SELECT * FROM [tbl_priority]"></asp:SqlDataSource>
                   <asp:SqlDataSource ID="sqlIssueType" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                       SelectCommand="SELECT * FROM [tbl_IssueType]"></asp:SqlDataSource>
   
   </div>
   </fieldset>
</asp:Content>
