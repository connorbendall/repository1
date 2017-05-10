/*Modified Dec 04, 2015
 * Author: Marius Tocitu
 * Added project and Phase dropdown
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using ValidationClassLibrary;
using System.IO;
using OfficeOpenXml;
using AjaxControlToolkit;
using System.Configuration;

public partial class About : System.Web.UI.Page, IPostBackEventHandler
{
    private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["IssuesConnectionString"].ConnectionString;


    static string prevPage = string.Empty;

    string ticketnumber = "";

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Session["IsAdmin"] != null)
        {
            int isAdmin = Int32.Parse(Session["IsAdmin"].ToString());

            if (isAdmin == 0)
            {
                Response.Redirect("~/DetailTicketView.aspx?ID=" + Request.QueryString["ticketnumber"]);

            }
        }
        //Check for file
        checkFiles();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["ticketnumber"] != null)
        {
            ticketnumber = Request.QueryString["ticketnumber"].ToString();
            lblIndex.Text = ticketnumber;
            detailview.Visible = true;
        }

        DropDownList phseNumDdl = (DropDownList)dvTicket.FindControl("ddlphase");

        if (!IsPostBack)
        {
            //Prevent Crashing when directly accessing this page
            if (Request.UrlReferrer != null)
                prevPage = Request.UrlReferrer.ToString(); //Referrer (Reports.aspx)




            

            //join tciket number and get values for phase 

            //DropDownList phseNumDdl = (DropDownList)dvTicket.FindControl("ddlphase");

            Label txtphase = (Label)dvTicket.FindControl("lblSelectedPhase");
            //DropDownList phaseddl = (DropDownList)dvTicket.FindControl("ddlphase");
            txtphase.Text = Convert.ToString(2); //phaseddl.SelectedItem.Value;


            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("SELECT coalesce(Phase_ID,NULL)'Phase_ID' FROM tbl_issues2 iss join tbl_Project_Phase ph on convert(int, iss.Phase) = ph.Phase_ID WHERE issueid = " + ticketnumber);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            phseNumDdl.Items.Clear();
            txtphase.Text = Convert.ToString(cmd.ExecuteScalar()); //Convert.ToString(2); //phaseddl.SelectedItem.Value;
           // phseNumDdl.DataSource = cmd.ExecuteReader();
           // phseNumDdl.DataTextField = "Phase_Name";
           // phseNumDdl.DataValueField = "Phase_ID";
           // phseNumDdl.DataBind();
            //phseNumDdl.SelectedValue = "Phase_ID";
            con.Close();
            
            
            //Label txtphase = (Label)dvTicket.FindControl("lblSelectedPhase");
            //DropDownList phaseddl = (DropDownList)dvTicket.FindControl("ddlphase");
            //txtphase.Text = Convert.ToString(2); //phaseddl.SelectedItem.Value;
            //DropDownList prjNumDdl = (DropDownList)dvTicket.FindControl("ddlprjNum");
            // SqlConnection con1 = new SqlConnection(constr);
            //phseNumDdl.Items.Clear();
            cmd = new SqlCommand("SELECT coalesce(Phase_ID,NULL)'Phase_ID', coalesce(Phase_Name,NULL)'Phase_Name' FROM tbl_issues2 iss join tbl_Project_Phase ph on convert(int, iss.prjNum) = ph.Project_ID WHERE issueid = " + ticketnumber);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            //phseNumDdl.ClearSelection();
            phseNumDdl.DataSource = cmd.ExecuteReader();
            phseNumDdl.DataTextField = "Phase_Name";
            phseNumDdl.DataValueField = "Phase_ID";
            if (txtphase.Text != "")
            {
                    phseNumDdl.SelectedValue = txtphase.Text;
            }
           
            phseNumDdl.DataBind();
            con.Close();
        }
            /*
        else
        {
            DropDownList prjNumDdl = (DropDownList)dvTicket.FindControl("ddlprjNum");
            SqlConnection con1 = new SqlConnection(constr);
            SqlCommand cmd1 = new SqlCommand("SELECT coalesce(Phase_ID,NULL)'Phase_ID', coalesce(Phase_Name,NULL)'Phase_Name' FROM tbl_Project_Phase WHERE Project_ID = " + prjNumDdl.SelectedValue);
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con1;
            con1.Open();
            phseNumDdl.Items.Clear();
            phseNumDdl.DataSource = cmd1.ExecuteReader();
            phseNumDdl.DataTextField = "Phase_Name";
            phseNumDdl.DataValueField = "Phase_ID";
            //phseNumDdl.SelectedValue = "Phase_ID";
            phseNumDdl.DataBind();
            con1.Close();


        }
        */

                }

    protected void dvTicket_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        lblErrorMessage.Text = String.Empty;
        lblErrorMessage.Visible = false;
        dvTicket.DataBind();
        dvTicket.DefaultMode = DetailsViewMode.ReadOnly;
    }

    protected void sqlTicket_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;


            if (e.Exception.InnerException != null)
            {
                lblMessage.Text = e.Exception.InnerException.Message;
            }
            else
            {
                lblMessage.Text = e.Exception.Message;
            }
        }
    }


    protected void dvTicket_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {


        if (Edit(e.NewValues) == false)
        {
            e.Cancel = true;
        }
        else
            if (Edit(e.NewValues) == true)
            {

                TextBox txtImmediateFix = (TextBox)dvTicket.FindControl("txtImmediateFix");
                DropDownList ddlStatus = (DropDownList)dvTicket.FindControl("ddlStatusEdit");
                string val = txtImmediateFix.Text;

                if (ddlStatus.SelectedItem.Text == "Closed")
                {
                    if (val.ToString() == "")
                    {
                        lblErrorMessage.Visible = true;
                        lblErrorMessage.Text = "Enter a resolution note before closing ticket";
                        e.Cancel = true;
                    }
                }



            }

    }

    public bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }



    protected bool Edit(IOrderedDictionary values)
    {
        lblErrorMessage.Text = "";

        /*if (values["email"] != null)
        {
            if (!EmailValid.IsValidEmail(values["email"].ToString()))
            {
                lblErrorMessage.Text = "Please enter a correct email address";
            }
        }
        else
        {
            lblErrorMessage.Text = "Please enter an email address";
        }*/

        if (values["targetcomptime"] == null)
        {
            lblErrorMessage.Text = "Enter target Completion time";
        }


        if (values["problemdescription"] == null)
        {
            lblErrorMessage.Text = "Enter problem description";
        }


        if (lblErrorMessage.Text != "")
        {
            return false;
        }
        else
        {
            return true;
        }



    }



    protected void ddlSubsystemEdit_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList subsytemList = (DropDownList)sender;
        Label selectedSubSystem = (Label)dvTicket.FindControl("lblSelectedSubSys");
        selectedSubSystem.Text = subsytemList.SelectedValue;
    }


    protected void dvTicket_DataBound(object sender, EventArgs e)
    {

        if (dvTicket.CurrentMode == DetailsViewMode.Edit)//The controls 
        {
            DropDownList subsystemDDL = (DropDownList)dvTicket.FindControl("ddlSubsystemEdit");
            DropDownList statusDDL = (DropDownList)dvTicket.FindControl("ddlStatusEdit");
            DropDownList systemDDL = (DropDownList)dvTicket.FindControl("ddlEditSystem");
            DropDownList phaseDDL = (DropDownList)dvTicket.FindControl("ddlphase");


            if (subsystemDDL != null)
            {
                subsystemDDL.DataBind();

                Label selectedSubSystem = (Label)dvTicket.FindControl("lblSelectedSubSys");
                if (selectedSubSystem != null)
                    subsystemDDL.SelectedValue = selectedSubSystem.Text;
            }

            if (phaseDDL != null)
            {
                phaseDDL.DataBind();

                Label selectedSubSystem = (Label)dvTicket.FindControl("lblSelectedSubSys");
                if (selectedSubSystem != null)
                    subsystemDDL.SelectedValue = selectedSubSystem.Text;
            }

        }

        int isAdmin = Int32.Parse(Session["IsAdmin"].ToString());


        if (isAdmin == 1)
        {
            if (dvTicket.CurrentMode == DetailsViewMode.Edit)
            {
                DropDownList ddlVerification = (DropDownList)dvTicket.FindControl("DropDownList10");
                if (ddlVerification != null)
                    ddlVerification.Enabled = false;
                else
                    divExtra.Visible = false;
            }
        }
    }

    protected void ddlEditSystem_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList subsystemDDL = (DropDownList)dvTicket.FindControl("ddlSubsystemEdit");
        DropDownList systemDDL = (DropDownList)dvTicket.FindControl("ddlEditSystem");


        /*
         * if the system is not Solarsoft then hide subsystem, resolve time, verification date and root cause (blank them out)
         * 
         * if the system is solar soft  but the subsytem is not ASN issue do the same as above but show the subsytem
         * 
         * else if the system is  solarsoft and the subsystem is asn issue show everything.
         * 
         * */
        subsystemDDL.DataBind();
        lblSystemID.Text = systemDDL.SelectedValue;
    }

    protected void ddlEditSystem_DataBound(object sender, EventArgs e)
    {
        DropDownList systemDDL = (DropDownList)dvTicket.FindControl("ddlEditSystem");
        lblSystemID.Text = systemDDL.SelectedValue;
    }


    protected void ddlSubsystemItem_DataBound(object sender, EventArgs e)
    {
        DropDownList subsystemDDL = (DropDownList)dvTicket.FindControl("ddlSubsystemItem");
        Label selectedSubSystem = (Label)dvTicket.FindControl("Label13");
        subsystemDDL.SelectedValue = selectedSubSystem.Text;
    }


    protected void ddlAssignedTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList assingedToDDL = (DropDownList)dvTicket.FindControl("ddlAssignedTo");
        DropDownList statusDDL = (DropDownList)dvTicket.FindControl("ddlStatusEdit");

        ListItem itemToRemove = statusDDL.Items.FindByValue("0");


        if (assingedToDDL.SelectedItem.Text == "Unassigned")
        {
            statusDDL.Items.Remove(itemToRemove);
        }
        else
        {

            if (itemToRemove == null)
            {
                ListItem closedItem = new ListItem("Closed", "0");
                statusDDL.Items.Insert(0, closedItem);
            }
        }
    }

    protected void ddlStatusEdit_DataBound(object sender, EventArgs e)
    {
        DropDownList assingedToDDL = (DropDownList)dvTicket.FindControl("ddlAssignedTo");
        DropDownList statusDDL = (DropDownList)dvTicket.FindControl("ddlStatusEdit");

        if (assingedToDDL.SelectedItem.Text == "Unassigned")
        {
            ListItem itemToRemove = statusDDL.Items.FindByValue("0");
            statusDDL.Items.Remove(itemToRemove);
        }
    }
    protected void btnRefreshFiles_Click(object sender, EventArgs e)
    {
        checkFiles();
    }

    protected void checkFiles()
    {
        ClearContents(AsyncFileUpload1 as Control);
        if (lblIndex.Text != "")
        {
            try
            {
                DirectoryInfo root = new DirectoryInfo(UploadedFile.filePath);
                FileInfo[] listfiles = root.GetFiles(lblIndex.Text + "*");
                Array.Sort(listfiles, delegate (FileInfo listfile1, FileInfo listfile2) {
                    return listfile1.Name.CompareTo(listfile2.Name);
                });

                if (listfiles.Length != 0)
                {
                    divFile.Visible = true;
                    divFile.Controls.Clear();
                    for (int count = 1; count <= listfiles.Length; count++)
                    {
                        System.Web.UI.HtmlControls.HtmlGenericControl subDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        subDiv.ID = "divFile" + (count);
                        subDiv.Attributes["class"] = "col-lg-8";
                        subDiv.Controls.Add(
                            new LinkButton()
                            {
                                ID = "lbFile_" + count,
                                OnClientClick = "btnDownload_Click('" + listfiles[count - 1].Name + "')",
                                Text = "Click here to download file " + listfiles[count - 1].Name,
                                CommandArgument = listfiles[count - 1].Name
                            });
                        subDiv.Controls.Add(
                            new Button()
                            {
                                ID = "btnRemoveUpload_" + count,
                                OnClientClick = "btnDelete_Click('" + listfiles[count - 1].Name + "')",
                                Text = "Delete"
                            });
                        divFile.Controls.Add(subDiv);
                    }
                }
                else
                {
                    divFile.Visible = false;
                }
            }
            catch (Exception ex)
            {
                divFile.Visible = false;
                lblFileIssue.Visible = true;
            }
        }
    }

    public void RaisePostBackEvent(string eventArgument)
    {
        var strings = eventArgument.Split('|');
        if (strings.Length == 2)
        {
            var type = strings[0];
            var filename = strings[1];
            if (type == "Download")
            {
                DirectoryInfo root = new DirectoryInfo(UploadedFile.filePath);
                FileInfo[] listfiles = root.GetFiles(filename);


                if (listfiles.Length != 0)
                {
                    Response.ClearContent();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + listfiles[0].Name);
                    Response.AddHeader("Content-Length", listfiles[0].Length.ToString());
                    Response.ContentType = "application//octet-stream";

                    Response.TransmitFile(listfiles[0].FullName);
                    Response.End();
                }
            }
            if (type == "Delete")
            {
                string[] file = filename.Split('.');
                UploadedFile.DeleteExistingFiles(file[0]);
                Response.Cookies["lastFile"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["lastTicket"].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }

    protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        string lastFile = "";
        try
        {
            lastFile = Request.Cookies["lastFile"].Value;
        }
        catch { }

        string lastTicket = "";
        try
        {
            lastTicket = Request.Cookies["lastTicket"].Value;
        }
        catch { }

        string fileExt = UploadedFile.GetFileExtention(AsyncFileUpload1.FileName);

        // The user had uploaded a second file see if one with the id and any extension exists and delete it to make room for the new one
        UploadedFile.DeleteExistingFiles(lblIndex.Text);


        if (UploadedFile.FileExtentionAllowed(fileExt))
        {
            //Get real path to upload files to
            if (lastFile != AsyncFileUpload1.FileName || lastTicket != lblIndex.Text)
            {
                if (lblIndex.Text != "")
                {
                    try
                    {
                        DirectoryInfo root = new DirectoryInfo(UploadedFile.filePath);
                        FileInfo[] listfiles = root.GetFiles(lblIndex.Text + "*");
                        Array.Sort(listfiles, delegate (FileInfo listfile1, FileInfo listfile2)
                        {
                            return listfile1.Name.CompareTo(listfile2.Name);
                        });
                        if (listfiles.Length != 0)
                        {
                            string currentFile = listfiles[listfiles.Length - 1].FullName;
                            int currentFileNumber = int.Parse(currentFile.Split('_')[1].Split('.')[0]);
                            currentFileNumber++;
                            string nextFileNumber = currentFileNumber.ToString();
                            if (currentFileNumber < 10)
                            {
                                nextFileNumber = "0" + nextFileNumber;
                            }
                            if (UploadedFile.FileExtentionAllowed(fileExt))
                            {
                                if (currentFileNumber <= UploadedFile.MaxUploads())
                                {
                                    AsyncFileUpload1.SaveAs(UploadedFile.filePath + lblIndex.Text + "_" + nextFileNumber + "." + fileExt);
                                }
                                else
                                {
                                    AsyncFileUpload1.SaveAs(UploadedFile.filePath + lblIndex.Text + "_" + UploadedFile.MaxUploads() + "." + fileExt);
                                }
                            }
                            else
                            {
                                lblFileIssue.Visible = true;
                            }

                        }
                        else if (UploadedFile.FileExtentionAllowed(fileExt))
                        {
                            AsyncFileUpload1.SaveAs(UploadedFile.filePath + lblIndex.Text + "_01." + fileExt);
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
        }
        ClearContents(AsyncFileUpload1 as Control);
        Response.Cookies["lastFile"].Value = AsyncFileUpload1.FileName;
        Response.Cookies["lastFile"].Expires = DateTime.Now.AddDays(1);
        Response.Cookies["lastTicket"].Value = lblIndex.Text;
        Response.Cookies["lastTicket"].Expires = DateTime.Now.AddDays(1);
    }
    private void ClearContents(Control control)
    {
        for (var i = 0; i < Session.Keys.Count; i++)
        {
            if (Session.Keys[i].Contains(control.ClientID))
            {
                Session.Remove(Session.Keys[i]);
                break;
            }
        }
    }
    protected void dvComments_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        string assingedTo = "";

        if (dvTicket.CurrentMode == DetailsViewMode.Edit)
        {
            DropDownList assingedToList = (DropDownList)dvTicket.FindControl("ddlAssignedTo");
            assingedTo = assingedToList.SelectedItem.Text;
        }
        else if (dvTicket.CurrentMode == DetailsViewMode.ReadOnly)
        {
            DropDownList assingedText = (DropDownList)dvTicket.FindControl("DropDownList4");
            assingedTo = assingedText.SelectedItem.Text;
        }
    }

    protected void dvComments_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        Response.Redirect("~/Edit.aspx?ticketnumber=" + Request.QueryString["ticketnumber"]);
    }

    //Writes the calendar's selected date on the textbox
    protected void Calendar_SelectionChanged(object sender, EventArgs e)
    {
        PopupControlExtender pop = (PopupControlExtender)dvTicket.FindControl("txtTargetCompletionDate_PopupControlExtender");
        Calendar cal = (Calendar)dvTicket.FindControl("Calendar");

        pop.Commit(cal.SelectedDate.ToShortDateString());
    }

    protected void dvTicket_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }



    protected void ddlprjNum_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList prjNumDdl = (DropDownList)dvTicket.FindControl("ddlprjNum");
        DropDownList phseNumDdl = (DropDownList)dvTicket.FindControl("ddlphase");
        Label txtphase = (Label)dvTicket.FindControl("lblSelectedPhase");
        if(prjNumDdl.SelectedValue!="")
        {

        
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("SELECT coalesce(Phase_ID,NULL)'Phase_ID', coalesce(Phase_Name,NULL)'Phase_Name' FROM tbl_Project_Phase WHERE Project_ID = " + prjNumDdl.SelectedValue);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        con.Open();
        phseNumDdl.Items.Clear();
        phseNumDdl.DataSource = cmd.ExecuteReader();
        phseNumDdl.DataTextField = "Phase_Name";
        phseNumDdl.DataValueField = "Phase_ID";
        //phseNumDdl.SelectedValue = "Phase_ID";
        phseNumDdl.DataBind();
        con.Close();
        if (phseNumDdl.Items.Count > 0)
        {
            phseNumDdl.SelectedIndex = 0;
            txtphase.Text = phseNumDdl.SelectedValue;
        }
        
        }
        else
        {
            phseNumDdl.Items.Clear();
            txtphase.Text = null;
        }
    }

    protected void ddlphase_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        Label txtphase = (Label)dvTicket.FindControl("lblSelectedPhase");
        DropDownList phaseddl = (DropDownList)dvTicket.FindControl("ddlphase");
        txtphase.Text = phaseddl.SelectedItem.Value;//Convert.ToString(2); //
           
        Console.WriteLine("in ddlphase change////");
        Console.WriteLine(phaseddl.SelectedItem.Value);
    }

   
}
