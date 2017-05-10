using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Session["IsAdmin"] != null)
        {
            int isAdmin = Int32.Parse(Session["IsAdmin"].ToString());

            if (isAdmin == 0)
                Response.Redirect("~/Default.aspx");
        }
    }

    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int employeeNumber = int.Parse(ddlEmployee.Text);
            EmployeeDAL thisEmployee = new EmployeeDAL(employeeNumber);
            if (thisEmployee.EmployeeEmail != null)
            {
                txtEmail.Text = thisEmployee.EmployeeEmail;
            }
            if (thisEmployee.EmployeePlant != null)
            {
                ddlPlant.ClearSelection();
                ddlPlant.Items.FindByValue(thisEmployee.EmployeePlant).Selected = true;
            }
            if (thisEmployee.EmployeeDept != null)
            {
                ddlDepartment.ClearSelection();
                ddlDepartment.Items.FindByValue(thisEmployee.EmployeeDept).Selected = true;
            }
            if (thisEmployee.WorkPhone != null)
            {
                txtWorkPhone.Text = thisEmployee.WorkPhone;
            }
            if (thisEmployee.CellPhone != null)
            {
                txtCellPhone.Text = thisEmployee.CellPhone;
            }
            if (thisEmployee.Location != null)
            {
                txtLocation.Text = thisEmployee.Location;
            }
        }
        catch (Exception ex)
        {

        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string problem;
        //Validation
        if (ddlEmployee.SelectedValue == "000")
        {
            lblEmployee.Visible = true;
            return;
        }
        else
        {
            lblEmployee.Visible = false;
        }

        //Email Validation
        if (txtEmail.Text.Trim() == "" || txtEmail.Text == null)
        {
            lblEmail.Visible = true;
            return;
        }
        if (txtEmail.Text.IndexOf("@") == -1)
        {
            lblEmail.Visible = true;
            return;
        }
        else
        {
            lblEmail.Visible = false;
        }

        //Plant/Division Validation
        if (ddlPlant.SelectedValue == "0000")
        {
            lblPlant.Visible = true;
            return;
        }
        else
        {
            lblPlant.Visible = false;
        }

        //Department Validation
        if (ddlDepartment.SelectedValue == "000")
        {
            lblDepartment.Visible = true;
            return;
        }
        else
        {
            lblDepartment.Visible = false;
        }

        EmployeeDAL.Insert(Int32.Parse(ddlEmployee.SelectedItem.Value), txtEmail.Text,
            ddlPlant.SelectedItem.Value, Int32.Parse(ddlDepartment.SelectedValue), txtWorkPhone.Text, txtCellPhone.Text, txtLocation.Text, 0);


        userEntry.Visible = false;
        Splash.Visible = true;
        Splash.Controls.Add(new LiteralControl("<img src='images/Success.jpg'>"));
    }

    protected void btnAnother_Click(object sender, EventArgs e)
    {
        userEntry.Visible = true;
        Splash.Controls.Clear();
        Splash.Visible = false;

        ddlEmployee.ClearSelection();
        txtEmail.Text = "";
        ddlPlant.ClearSelection();
        ddlDepartment.ClearSelection();
        txtWorkPhone.Text = "";
        txtCellPhone.Text = "";
        txtLocation.Text = "";
    }
}