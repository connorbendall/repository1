using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlPriority.Attributes.Add("onChange", "return OnSelectedIndexChange();");
        //lblTest.Text = "";

    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Session["IsAdmin"] != null)
        {
            int isAdmin = Int32.Parse(Session["IsAdmin"].ToString());

            if (isAdmin == 1)
                Response.Redirect("~/CreateAdminTicket.aspx?SecBypass=ITAdmin");
            else if(isAdmin == 2)
                Response.Redirect("~/CreateAdminTicket.aspx?SecBypass=ITSuper");
        }
    }


    protected void ddlSubsystem_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlSubSystem.SelectedItem.Text == "ASN Issue")
        {
            tbInfo.Visible = true;
            tblPriority.Visible = false;
        }
        else
        {
            tbInfo.Visible = false;
            tblPriority.Visible = true;

        }

        upDetails.Update();
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
        }
        catch(Exception ex)
        {

        }
        
    }

    protected void ddlSystemSelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSubSystem.Items.Clear();
        ddlSubSystem.Items.Insert(000, "PLEASE SELECT" );


        //if (ddlSystem.SelectedItem.Text == "SOLARSOFT")
        //{
        //    tbInfo.Visible = true;
        //}
        //else
        //{
        //    tbInfo.Visible = false;
        //}


    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string problem;

        //Employee Validation
        if (ddlEmployee.SelectedValue == "000")
        {
            lblEmployee.Visible = true;
            lblTest.Text = "Please select your name";
            return;
        }
        else
        {
            lblTest.Text = "";
            lblEmployee.Visible = false;
        }

        //Email Validation
        if (txtEmail.Text.Trim() == "" || txtEmail.Text == null)
        {
            lblEmail.Visible = true;
            lblTest.Text = "We require you to confirm your email address so we can ensure you receive all communication surrounding this ticket.";
          
            return;
        }
        else if (txtEmail.Text.IndexOf("@") == -1)
        {
            lblEmail.Visible = true;
            lblTest.Text = "We require you to confirm your email address so we can ensure you receive all communication surrounding this ticket.";
          
            return;
        }
        else
        {
            lblTest.Text = "";
            lblEmail.Visible = false;
        }

        //Department Validation
        if (ddlDepartment.SelectedValue == "000")
        {
            lblDepartment.Visible = true;
            lblTest.Text = "Please select your department";
            return;
        }
        else
        {
            lblTest.Text = "";
            lblDepartment.Visible = false;
        }

        //Systems validation
        if (ddlSystem.SelectedValue == "000")
        {
            lblTest.Text = "Please select system affected";
            lblSystem.Visible = true;
            return;
        }
        else
        {
            lblTest.Text = "";
            lblSystem.Visible = false;
        }

        //Sub Systems validation
        if (ddlSubSystem.SelectedItem.Value== "PLEASE SELECT")
        {
            lblTest.Text = "Please select Sub-System affected";
            lblSubsystemError.Visible = true;
            return;
        }
        else
        {
            lblTest.Text = "";
            lblSubsystemError.Visible = false;
        }

        if (tblPriority.Visible == true)
        {
            //Priority Validation
            if (ddlPriority.SelectedValue == "000")
            {
                lblTest.Text = "Please select priority";
                lblPriority.Visible = true;
                return;
            }
            else
            {
                lblTest.Text = "";
                lblPriority.Visible = false;
            }
        }

        //Problem Description Validation
        if (txtProbDescription.Text.Trim() == "" || txtProbDescription.Text == null)
        {
            lblTest.Text = "Please specify problem description";
            lblDescription.Visible = true;
            return;
        }
        else
        {
            lblTest.Text = "";
            lblDescription.Visible = false;
        }

        //Repeat issue Validation
        if (ddlRepeatIssue.SelectedValue == "000")
        {
            lblTest.Text = "Please specify if this is a reapeated issue";
            lblRepeat.Visible = true;
            return;
        }
        else
        {
            lblTest.Text = "";
            lblRepeat.Visible = false;
        }


        if (tbInfo.Visible == true)
        {
            //Check and verify other feilds
            if (tbBOLNumber.Text.Length > 80)
            {
                lblBOLError.Visible = true;
                lblTest.Text = "BOL Number Must be less then 80 Characters";
            }

            if (tbContactExtension.Text.Length > 50)
            {
                lblContactExtentionError.Visible = true;
                lblTest.Text = "Contact Extention Must be less then 50 Characters";
            }


            problem = "BOL #: " + tbBOLNumber.Text + Environment.NewLine + Environment.NewLine + "Description: " + txtProbDescription.Text + Environment.NewLine + Environment.NewLine + "EXT: " + tbContactExtension.Text;
        }
        else
        {
            problem = txtProbDescription.Text;
        }

        
        EmployeeDAL.Insert(Int32.Parse(ddlEmployee.SelectedItem.Value), txtEmail.Text, 
            ddlPlant.SelectedItem.Value, Int32.Parse(ddlDepartment.SelectedValue), "", "", "", 1);



        //Calling the TicketDAL Class insert method to insert the new data to the database. Please see TicketDAL
        TicketDAL Insert = new TicketDAL();
        Insert.Subsystem = Int32.Parse(ddlSubSystem.SelectedValue);
        Insert.Issuer = Int32.Parse(ddlEmployee.SelectedItem.Value);
        Insert.Email = txtEmail.Text;
        Insert.Division = ddlPlant.SelectedItem.Value;
        Insert.Dept = Int32.Parse(ddlDepartment.SelectedValue);
        Insert.System = Int32.Parse(ddlSystem.SelectedValue);
        Insert.ProbDesc = problem;
        Insert.AssignedTo = 1;

        if (tblPriority.Visible == true)
            Insert.Priority = Int32.Parse(ddlPriority.SelectedValue);
        else
            Insert.Priority = 1; //High

        Insert.RepeatIssue = Int32.Parse(ddlRepeatIssue.SelectedValue);

        
        int ticketID = TicketDAL.Insert(Insert);

        lblTicketNumber.Text = ticketID.ToString();
        ticketEntry.Visible = false;



        if (tbInfo.Visible == true) //This is always false. Update Panel is not firing.
        {
            Response.Redirect("~/ASNInstructions.aspx?ticketID="+ticketID.ToString());
        }
        else
        {
            Splash.Visible = true;
            Splash.Controls.Add(new LiteralControl("<img src='images/confirmation.jpg'><br>"));
        }
        Response.Redirect("~/DetailTicketView.aspx?ID=" + ticketID.ToString());




    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}
