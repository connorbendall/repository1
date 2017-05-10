using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminManagementSubsystem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            rblManageSubsystems.SelectedIndex = 0;
            pCreateSubsystem.Visible = true;
            
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


    //protected void Page_Init(object sender, EventArgs e)
    //{
    //    //if (Session["SystemID"] != null && Session["SubsystemID"] != null && Session["SystemID"] != "" && Session["SubsystemID"] != "")
    //    //{
    //    //    SubsystemRolesDAL subsystemDal = new SubsystemRolesDAL();
    //    //    List<SubsystemRoles> rolesList = subsystemDal.GetRolesForSubsystem(Int32.Parse(Session["SystemID"].ToString()), Int32.Parse(Session["SubsystemID"].ToString()));

    //    //    foreach (SubsystemRoles role in rolesList)
    //    //    {
    //    //        CheckBox cb = new CheckBox();
    //    //        cb.ID = role.roleID.ToString();
    //    //        cb.Text = role.roleName;
    //    //        cb.CssClass = "checkboxClass";
    //    //        if (role.isChecked == 1)
    //    //            cb.Checked = true;
    //    //        else
    //    //            cb.Checked = false;

    //    //        divRoles.Controls.Add(cb);
    //    //    }
    //    //}
    //}


    protected void rblManageSubsystems_SelectedIndexChanged(object sender, EventArgs e)
    {
        pCreateSubsystem.Visible = false;
        pEditSubsystem.Visible = false;
        pSubsystemToSystem.Visible = false;
        lblMessage.Visible = false;
        lblMessage.Text = "";

        if (rblManageSubsystems.SelectedValue == "1")
            pCreateSubsystem.Visible = true;
        else if (rblManageSubsystems.SelectedValue == "2")
            pEditSubsystem.Visible = true;
        else if (rblManageSubsystems.SelectedValue == "3")
        {
            pSubsystemToSystem.Visible = true;
        }
    }

    protected void btnViewRoles_Click(object sender, EventArgs e)
    {
        //Session["SystemID"] = ddlSystem2.SelectedValue;
        //Session["SubsystemID"] = ddlSubsystem2.SelectedValue;
        cblRoles.Items.Clear();

        SubsystemRolesDAL subsystemDal = new SubsystemRolesDAL();
        List<SubsystemRoles> rolesList = subsystemDal.GetRolesForSubsystem(Int32.Parse(ddlSystem2.SelectedValue), Int32.Parse(ddlSubsystem2.SelectedValue));

        foreach (SubsystemRoles role in rolesList)
        {
            ListItem item = new ListItem();
            item.Value = role.roleID.ToString();
            item.Text = role.roleName;
            //item.CssClass = "checkboxClass";
            if (role.isChecked == 1)
                item.Selected = true;
            else
                item.Selected = false;

            cblRoles.Items.Add(item);
        }
    }

    protected void ddlSystem2_SelectedIndexChanged(object sender, EventArgs e)
    {
        cblRoles.Items.Clear();
        ddlSubsystem2.Items.Clear();
        ddlSubsystem2.DataBind();
    }

    protected void ddlSubsystem2_SelectedIndexChanged(object sender, EventArgs e)
    {
       // Session["SystemID"] = ddlSystem2.SelectedValue;
        //Session["SubsystemID"] = ddlSubsystem2.SelectedValue;
        //divRoles.Controls.Clear();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SubsystemRoles role = new SubsystemRoles();
        SubsystemRolesDAL rolesDal = new SubsystemRolesDAL();
        bool isFirstTime = true;
        foreach (ListItem item in cblRoles.Items)
        {

                role.roleID = Int32.Parse(item.Value);
                if (item.Selected)
                {
                    if (isFirstTime)
                        rolesDal.SaveSubsystemRole(Int32.Parse(ddlSystem2.SelectedValue),Int32.Parse(ddlSubsystem2.SelectedValue), role.roleID, 1);
                    else
                        rolesDal.SaveSubsystemRole(Int32.Parse(ddlSystem2.SelectedValue), Int32.Parse(ddlSubsystem2.SelectedValue), role.roleID, 0);

                    role.isChecked = 1;
                    isFirstTime = false;
                }
            
        }
        //No boxes checked
        if (isFirstTime)
        {
            rolesDal.SaveSubsystemRole(Int32.Parse(ddlSystem2.SelectedValue), Int32.Parse(ddlSubsystem2.SelectedValue), role.roleID, 2);
        }


        lblMessage.Text = "Items Saved " + DateTime.Now.ToLongTimeString(); 
        lblMessage.Visible = true;
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

    protected void dvEditSubsystem_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        lblMessage.Text = "Record Updated " + DateTime.Now.ToLongTimeString();
        lblMessage.Visible = true;
    }

    protected void dvCreateSubsystem_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        lblMessage.Text = "Record Inserted " + DateTime.Now.ToLongTimeString();
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

    protected void ddlSystem_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddlSubsystem.Items.Clear();

    }
}