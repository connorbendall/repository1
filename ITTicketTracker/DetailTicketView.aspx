<%@ Page Title="Ticket Detail" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DetailTicketView.aspx.cs" Inherits="DetailTicketView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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
        function btnDelete_Click(filename) {
            var pageId = '<%=  Page.ClientID %>';
            __doPostBack(pageId, "Delete|" + filename);
        }
        function btnDownload_Click(filename) {
            var pageId = '<%=  Page.ClientID %>';
            __doPostBack(pageId, "Download|" + filename);
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>

    <fieldset>
<legend>Details Of Your Ticket</legend>
<div runat="server" id="divInfo">

<table>
    <tr>
        <td>
             <asp:DetailsView ID="dvTicket" runat="server" AutoGenerateRows="False" 
               CellPadding="4" DataSourceID="sqlTicket" 
               ForeColor="Black" GridLines="Vertical" Height="50px" Width="550px" 
               BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
               BorderWidth="1px">
               <AlternatingRowStyle BackColor="White" />
               <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
               <Fields>
                   <asp:BoundField DataField="issueid" HeaderText="ID" 
                       InsertVisible="False" ReadOnly="True" SortExpression="issueid" />
                   <asp:TemplateField HeaderText="Name" SortExpression="Name">
                       <EditItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                       </EditItemTemplate>
                       <InsertItemTemplate>
                           <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                       </InsertItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                   <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" 
                       SortExpression="DepartmentName" />
                   <asp:BoundField DataField="division" HeaderText="Division" 
                       SortExpression="division" />
                   <asp:BoundField DataField="System" HeaderText="System" 
                       SortExpression="System" />
    <asp:BoundField DataField="SubSystem" HeaderText="Sub-System" SortExpression="SubSystem"></asp:BoundField>
                   <asp:BoundField DataField="problemdescription" HeaderText="Problem" 
                       SortExpression="problemdescription" />
                   <asp:BoundField DataField="prioritydesc" HeaderText="Priority" 
                       SortExpression="prioritydesc" />
                   <asp:BoundField DataField="Repeat" HeaderText="Repeat Issue" 
                       SortExpression="Repeat" />
                   <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                   <asp:BoundField DataField="status" HeaderText="Status" 
                       SortExpression="status" />
                   <asp:BoundField DataField="rootCause" HeaderText="Root Cause" />
                   <asp:BoundField DataField="resolution" HeaderText="Resolution" 
                       SortExpression="resolution" />
                   <asp:BoundField DataFormatString="pca" HeaderText="Permanent Corrective Action" />
                   <asp:BoundField DataField="datecreated" HeaderText="Created" 
                       SortExpression="datecreated" />
                   <asp:BoundField DataField="targetcompletiondate" 
                       HeaderText="Target Date" SortExpression="targetcompletiondate" />
                   <asp:BoundField DataField="user" HeaderText="Assigned IT User" 
                       SortExpression="user" />
                   <asp:BoundField DataField="lastupdate" HeaderText="Last Updated" 
                       SortExpression="lastupdate" />
                   <asp:BoundField DataField="actualcompletiondate" 
                       HeaderText="Completion Date" SortExpression="actualcompletiondate" />
                   <asp:BoundField DataField="EnteredBy" HeaderText="EnteredBy" 
                       SortExpression="EnteredBy" />
                   <asp:TemplateField ShowHeader="False">
                       <ItemTemplate>
                           <input Type="button" Value="Print" onClick="window.print()"/>
                       </ItemTemplate>
                   </asp:TemplateField>
               </Fields>
               <FooterStyle BackColor="#CCCC99" />
               <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
               <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
               <RowStyle BackColor="#F7F7DE" />
           </asp:DetailsView>
        </td>
        <td valign="top" >
          

          <asp:GridView ID="gvComments" runat="server" 
           AllowSorting="True" BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" 
           BorderWidth="2px" CellPadding="4" Height="50px" Width="380px"
                AutoGenerateColumns="False" PageSize="6"  AllowPaging="True"
           style="margin-right: 0px" DataSourceID="sqlComment">
               <Columns>
              
                   <asp:BoundField DataField="commentText" HeaderText="Comment" 
                       SortExpression="commentText" />
                   <asp:BoundField DataField="dateEntered" HeaderText="Date Entered" 
                       SortExpression="dateEntered" />
              
                   <asp:BoundField DataField="comment_entered_by" HeaderText="Comment From" />
              
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


        <asp:DetailsView ID="dvComments" runat="server" AutoGenerateRows="False" 
               CellPadding="4" DefaultMode="Insert"
               ForeColor="Black" GridLines="Vertical" Height="50px" Width="380px" 
               BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
               BorderWidth="1px" DataSourceID="sqlComment" 
                oniteminserted="dvComments_ItemInserted" 
                oniteminserting="dvComments_ItemInserting">
               <AlternatingRowStyle BackColor="White" />
               <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
               <Fields>
                   <asp:TemplateField HeaderText="Comment" SortExpression="commentText">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("commentText") %>' 
                               TextMode="MultiLine" Width="300" ></asp:TextBox>
                       </EditItemTemplate>
                       <InsertItemTemplate>
                           <asp:TextBox ID="TextBox1" runat="server" Width="300" Text='<%# Bind("commentText") %>' 
                               TextMode="MultiLine"></asp:TextBox>
                       </InsertItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Bind("commentText") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                    <asp:CommandField ShowInsertButton="true" ButtonType="Button" />
               </Fields>
               <FooterStyle BackColor="#CCCC99" />
               <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
               <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
               <RowStyle BackColor="#F7F7DE" />
           </asp:DetailsView>

            <asp:SqlDataSource ID="sqlComment" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                InsertCommand="InsertComment" InsertCommandType="StoredProcedure" 
                SelectCommand="GetComments" SelectCommandType="StoredProcedure">
                <InsertParameters>
                    <asp:QueryStringParameter Name="ticketID" QueryStringField="ID" 
                        Type="Int32"  />
                    <asp:Parameter Name="commentText" Type="String" />
                    <asp:Parameter Name="UserType" Type="Int32" DefaultValue="0" />
                    <asp:ControlParameter Name="user_entry_id" Type="String" ControlID="dvTicket$lblUserName" />
                    <asp:Parameter Name="skill" Type="String" DefaultValue="N/A" />
                    <asp:Parameter Name="timetoresolve" Type="String" DefaultValue="0" />
                </InsertParameters>
                <SelectParameters>
                    <asp:QueryStringParameter Name="ticketID" QueryStringField="ID" 
                        Type="Int32"  />
                </SelectParameters>
            </asp:SqlDataSource>
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

    </div>
        </td>
    </tr>

</table>
  

    <br />
    <asp:SqlDataSource ID="sqlTicket" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
        SelectCommand="ViewTicket" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="TicketNum" QueryStringField="ID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlRepeatIssue" runat="server" 
                           ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
                           SelectCommand="SELECT * FROM [tbl_RepeatIssue]">
       </asp:SqlDataSource>
       <asp:SqlDataSource ID="sqlemployees" runat="server" 
           ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
           SelectCommand="GetEmployees" SelectCommandType="StoredProcedure">
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
   
       <asp:SqlDataSource ID="sqlSystem" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
        SelectCommand="SELECT * FROM [tbl_system_type]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlAssignedTo" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
        SelectCommand="AssignedTo" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlStatus" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ISSUESConnectionString %>" 
        SelectCommand="SELECT * FROM [tbl_Status]"></asp:SqlDataSource>
</div>
</fieldset>
</asp:Content>

