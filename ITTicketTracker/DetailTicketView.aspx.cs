using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Data;

public partial class DetailTicketView : System.Web.UI.Page, IPostBackEventHandler
{

    protected void Page_LoadComplete(object sender, EventArgs e)
    {

        //Check for file
        if (Request.QueryString["ID"] !=null )
        {
            checkFiles();
            //FileInfo[] listfiles = root.GetFiles(Request.QueryString["ID"].ToString() + ".*");


            //if (listfiles.Length != 0)
            //{
            //    divFile.Visible = true;
            //}
            //else
            //{
            //    divFile.Visible = false;
            //}
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] ==null)
        {
            divInfo.Visible = false;
        }
        else
        {
            divInfo.Visible = true;
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Session["ctrl"] = dvTicket;

        ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=600px,width=530px,scrollbars=1');</script>");
    }


    protected void dvComments_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        Response.Redirect("~/DetailTicketView.aspx?ID=" + Request.QueryString["ID"].ToString());
    }

    protected void btnRefreshFiles_Click(object sender, EventArgs e)
    {
        checkFiles();
    }

    protected void checkFiles()
    {
        ClearContents(AsyncFileUpload1 as Control);
        if (Request.QueryString["ID"] != "")
        {
            try
            {
                DirectoryInfo root = new DirectoryInfo(UploadedFile.filePath);
                FileInfo[] listfiles = root.GetFiles(Request.QueryString["ID"] + "*");
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
        UploadedFile.DeleteExistingFiles(Request.QueryString["ID"]);


        if (UploadedFile.FileExtentionAllowed(fileExt))
        {
            //Get real path to upload files to
            if (lastFile != AsyncFileUpload1.FileName || lastTicket != Request.QueryString["ID"])
            {
                if (Request.QueryString["ID"] != "")
                {
                    try
                    {
                        DirectoryInfo root = new DirectoryInfo(UploadedFile.filePath);
                        FileInfo[] listfiles = root.GetFiles(Request.QueryString["ID"] + "*");
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
                                    AsyncFileUpload1.SaveAs(UploadedFile.filePath + Request.QueryString["ID"] + "_" + nextFileNumber + "." + fileExt);
                                }
                                else
                                {
                                    AsyncFileUpload1.SaveAs(UploadedFile.filePath + Request.QueryString["ID"] + "_" + UploadedFile.MaxUploads() + "." + fileExt);
                                }
                            }
                            else
                            {
                                lblFileIssue.Visible = true;
                            }

                        }
                        else if (UploadedFile.FileExtentionAllowed(fileExt))
                        {
                            AsyncFileUpload1.SaveAs(UploadedFile.filePath + Request.QueryString["ID"] + "_01." + fileExt);
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
        Response.Cookies["lastTicket"].Value = Request.QueryString["ID"];
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
        DataView dv = new DataView();
        DataTable dt = new DataTable();
        dv = (DataView)sqlTicket.Select(DataSourceSelectArguments.Empty);
 
        dt = dv.ToTable();
        DataRow dr = dt.Rows[0];
    }

}