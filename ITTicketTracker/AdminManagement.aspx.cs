using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
    protected void btnMangeNotify_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminManageNotifySettings.aspx");
    }

}