using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminManageNotifySettings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gridReports.DataBind();
            GridView1.DataBind();

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

    protected void gridReports_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        int index = gridReports.EditIndex;
        GridViewRow row = gridReports.Rows[index];

        // Get values 

        CheckBox open = (CheckBox)row.FindControl("cbOpen");
        CheckBox closed = (CheckBox)row.FindControl("cbClosed");
        CheckBox verified = (CheckBox)row.FindControl("cbVerified");
        CheckBox assinged = (CheckBox)row.FindControl("cbAssinged");
        CheckBox updated = (CheckBox)row.FindControl("cbUpdated");


        if (updated.Checked)
            e.NewValues["updatedNotify"] = 1;
        else
            e.NewValues["updatedNotify"] = 0;

        if (assinged.Checked)
            e.NewValues["assingedNotify"] = 1;
        else
            e.NewValues["assingedNotify"] = 0;

        if (verified.Checked)
            e.NewValues["verifiedNotify"] = 1;
        else
            e.NewValues["verifiedNotify"] = 0;

        if (closed.Checked)
            e.NewValues["closedNotify"] = 1;
        else
            e.NewValues["closedNotify"] = 0;

        if (open.Checked)
            e.NewValues["openNotify"] = 1;
        else
            e.NewValues["openNotify"] = 0;


        e.NewValues["system"] = ddlSystem.SelectedValue;
        e.NewValues["subSystem"] = ddlSubsystem.SelectedValue;
        e.NewValues["userID"] = e.OldValues["userId"];

        GridView1.DataBind();

    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int index = GridView1.EditIndex;
        GridViewRow row = GridView1.Rows[index];

        // Get values 

        CheckBox open = (CheckBox)row.FindControl("cbOpen");
        CheckBox closed = (CheckBox)row.FindControl("cbClosed");
        CheckBox verified = (CheckBox)row.FindControl("cbVerified");
        CheckBox assinged = (CheckBox)row.FindControl("cbAssinged");
        CheckBox updated = (CheckBox)row.FindControl("cbUpdated");


        if (updated.Checked)
            e.NewValues["updatedNotify"] = 1;
        else
            e.NewValues["updatedNotify"] = 0;

        if (assinged.Checked)
            e.NewValues["assingedNotify"] = 1;
        else
            e.NewValues["assingedNotify"] = 0;

        if (verified.Checked)
            e.NewValues["verifiedNotify"] = 1;
        else
            e.NewValues["verifiedNotify"] = 0;

        if (closed.Checked)
            e.NewValues["closedNotify"] = 1;
        else
            e.NewValues["closedNotify"] = 0;

        if (open.Checked)
            e.NewValues["openNotify"] = 1;
        else
            e.NewValues["openNotify"] = 0;


        e.NewValues["system"] = e.OldValues["sysID"];
        e.NewValues["subSystem"] = e.OldValues["subsystemID"];
        e.NewValues["userID"] = ddlUsers.SelectedValue;

        gridReports.DataBind();

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

    protected void btnOnCall_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminManagementOnCall.aspx");
    }
    protected void btnMangeNotify_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminManageNotifySettings.aspx");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            bool isChecked = false;

            if (drv["openNotify"].ToString() == "True")
                isChecked = true;
            else if (drv["closedNotify"].ToString() == "True")
                isChecked = true;
            else if (drv["verifiedNotify"].ToString() == "True")
                isChecked = true;
            else if (drv["assingedNotify"].ToString() == "True")
                isChecked = true;
            else if (drv["updatedNotify"].ToString() == "True")
                isChecked = true;

            
            if(isChecked)
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#33FF66");   

        }
    }

    protected void rblReportType_SelectedIndexChanged(object sender, EventArgs e)
    {
        divByUser.Visible = false;
        divBySubsystem.Visible = false;

        if (rblReportType.SelectedValue == "1")
            divBySubsystem.Visible = true;
        else if (rblReportType.SelectedValue == "2")
            divByUser.Visible = true;

        gridReports.DataBind();
        GridView1.DataBind();
    }
}

