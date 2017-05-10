using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminManagementRoles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            rblRoles.SelectedIndex = 0;
            pCreateRole.Visible = true;
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

    protected void rblRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRoles.DataBind();
        pCreateRole.Visible = false;
        pEditRole.Visible = false;

        lblMessage.Visible = false;
        lblMessage.Text = "";

        if (rblRoles.SelectedValue == "1")
            pCreateRole.Visible = true;
        else if (rblRoles.SelectedValue == "2")
            pEditRole.Visible = true;

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

    protected void dvCreateRole_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        lblMessage.Text = "Record Inserted " + DateTime.Now.ToLongTimeString();
        lblMessage.Visible = true;
    }
    protected void dvEditRole_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        lblMessage.Text = "Record Updated " + DateTime.Now.ToLongTimeString(); ;
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