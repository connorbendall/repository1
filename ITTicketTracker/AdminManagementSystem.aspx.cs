using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminManagementSystem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            rblManageSystem.SelectedIndex = 0;
            pCreateSystem.Visible = true;
        }
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Session["IsAdmin"] != null)
        {
            int isAdmin = Int32.Parse(Session["IsAdmin"].ToString());

            if (isAdmin == 0 || isAdmin == 1)
                Response.Redirect("~/Default.aspx");
        }
    }

    protected void rblManageSystem_SelectedIndexChanged(object sender, EventArgs e)
    {
        pCreateSystem.Visible = false;
        pEditSystem.Visible = false;

        lblMessage.Visible = false;
        lblMessage.Text = "";

        if (rblManageSystem.SelectedValue == "1")
            pCreateSystem.Visible = true;
        else if (rblManageSystem.SelectedValue == "2")
            pEditSystem.Visible = true;
    }

    protected void btnMangeUsers_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminManagementUser.aspx");
    }
    protected void btnManageRoles_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminManagementRoles.aspx");
    }
    protected void btnManageSystem_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminManagementSystem.aspx");
    }
    protected void btnManageSubsystems_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminManagementSubsystem.aspx");
    }

    protected void dvCreateSystem_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        lblMessage.Text = "Record Inserted " + DateTime.Now.ToLongTimeString(); 
        lblMessage.Visible = true; 
    }
    protected void dvEditSystem_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        lblMessage.Text = "Record Updated " + DateTime.Now.ToLongTimeString();
        lblMessage.Visible = true;
    }
    protected void btnOnCall_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminManagementOnCall.aspx");
    }
    protected void btnMangeNotify_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminManageNotifySettings.aspx");
    }
}