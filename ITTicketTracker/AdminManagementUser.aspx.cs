using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminManagementUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            rblUsers.SelectedIndex = 0;
            pCreate.Visible = true;
        }
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Session["IsAdmin"] != null)
        {
            int isAdmin = Int32.Parse(Session["IsAdmin"].ToString());

            if (isAdmin == 0 || isAdmin ==1)
                Response.Redirect("~/Default.aspx");
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["UserID"] != null && Session["UserID"].ToString() != "")
        {
            UserRolesDAL rolesDal = new UserRolesDAL();
            List<UserRoles> rolesList = rolesDal.GetRolesForUser(Int32.Parse(Session["UserID"].ToString()));

            foreach (UserRoles role in rolesList)
            {
                CheckBox cb = new CheckBox();
                cb.ID = role.roleID.ToString();
                cb.Text = role.roleName;
                cb.CssClass = "checkboxClass";
                if (role.isChecked == 1)
                    cb.Checked = true;
                else
                    cb.Checked = false;

                divRoles.Controls.Add(cb);
            }
        }
    }

    protected void rblUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlITUsers.DataBind();
        pEditUser.Visible = false;
        pCreate.Visible = false;
        pAssignRoles.Visible = false;
        lblMessage.Visible = false;
        lblMessage.Text = "";

        if (rblUsers.SelectedValue == "1")
            pCreate.Visible = true;
        else if (rblUsers.SelectedValue == "2")
            pEditUser.Visible = true;
        else if (rblUsers.SelectedValue == "3")
        {
            pAssignRoles.Visible = true;      
        }
    }

    protected void ddlITUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        dvUpdateUser.DataBind();
    }


    protected void btnViewRoles_Click(object sender, EventArgs e)
    {
        Session["UserID"] = ddlUser1.SelectedValue;

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {       
        UserRoles role = new UserRoles();
        UserRolesDAL rolesDal = new UserRolesDAL();
        bool isFirstTime = true;
        foreach (Control control in divRoles.Controls)
        {
            if (control.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
            {
                CheckBox cb = (CheckBox)control;
                role.roleID = Int32.Parse(cb.ID);
                if (cb.Checked)
                {
                    if(isFirstTime)
                        rolesDal.SaveUserRole(Int32.Parse(ddlUser1.SelectedValue), role.roleID, 1);
                    else
                        rolesDal.SaveUserRole(Int32.Parse(ddlUser1.SelectedValue), role.roleID, 0);

                    role.isChecked = 1;
                    isFirstTime = false;
                }
            } 
        }
        //No boxes checked
        if (isFirstTime)
        {
            rolesDal.SaveUserRole(Int32.Parse(ddlUser1.SelectedValue), role.roleID,2);
        }
        divRoles.Controls.Clear();
        gvITUserRoles.DataBind();

        lblMessage.Text = "Items Saved " + DateTime.Now.ToLongTimeString(); ;
        lblMessage.Visible = false;
    }

    protected void ddlUser1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["UserID"] = ddlUser1.SelectedValue;
        divRoles.Controls.Clear();
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
    protected void btnMangeSavedUsers_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UpdateSavedEmployee.aspx");
    }


    protected void dvUpdateUser_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        lblMessage.Text = "Record Updated " + DateTime.Now.ToLongTimeString();
        lblMessage.Visible = true;
    }
    protected void dvCreateUser_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        lblMessage.Text = "Record Inserted " + DateTime.Now.ToLongTimeString();
        lblMessage.Visible = true;
    }
    protected void btnOnCall_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminManagementOnCall.aspx");
    }
}