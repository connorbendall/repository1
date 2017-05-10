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
        ddlPriority.Attributes.Add("onChange", "return OnSelectedIndexChange();");

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


    protected void ddlAssignedTo_SelectedIndexChanged(object sender, EventArgs e)
    {

        ListItem itemToRemove = ddlStatus.Items.FindByValue("0");

        if (ddlAssignedTo.SelectedItem.Text == "Unassigned")
        {
           
            ddlStatus.Items.Remove(itemToRemove);

        }
        else 
        {
            
            if (itemToRemove == null)
            {
                ListItem closedItem = new ListItem("Closed","0");
                ddlStatus.Items.Insert(1,closedItem);
            }
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
        }
        catch (Exception ex)
        {

        }

    }

    protected void ddlSubsystemSelectedIndexChanged(object sender, EventArgs e)
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
    }


    protected void ddlSystemSelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSubSystem.Items.Clear();
    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        CreateAdminTicketDAL insert = new CreateAdminTicketDAL();
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
            lblEmailMSG.Visible = true;
            return;
        }
        if (txtEmail.Text.IndexOf("@") == -1)
        {
            lblEmail.Visible = true;
            lblEmailMSG.Visible = true;
            return;
        }
        else
        {
            lblEmail.Visible = false;
            lblEmailMSG.Visible = false;
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

        //Systems validation
        if (ddlSystem.SelectedValue == "000")
        {
            lblSystem.Visible = true;
            return;
        }
        else
        {
            lblSystem.Visible = false;
        }

        if (tblPriority.Visible == true)
        {
            //priority Validation
            if (ddlPriority.SelectedValue == "000")
            {
                lblPriority.Visible = true;
                return;
            }
            else
            {
                lblPriority.Visible = false;
            }
        }

        //Type Validation
        if (ddlType.SelectedValue == "000")
        {
            lblType.Visible = true;
            return;
        }
        else
        {
            lblType.Visible = false;
        }

        //Assigened To validation
        if (ddlAssignedTo.SelectedValue == "000")
        {
            lblAssignedTo.Visible = true;
            return;
        }
        else
        {
            lblAssignedTo.Visible = false;
        }

        //Status Validation
        if (ddlStatus.SelectedValue == "000")
        {
            lblStatus.Visible = true;
            return;
        }
        else
        {
            lblStatus.Visible = false;
        }

        //Repeat Issue Validation
        if (ddlRepeatIssue.SelectedValue == "000")
        {
            lblRepeatIssue.Visible = true;
            return;
        }
        else
        {
            lblRepeatIssue.Visible = false;
        }

        //if the table that holds the BOL # and Contact Ext is showing then format the description 
        if (tbInfo.Visible == true)
        {
            //Check and verify other fields
            if (tbBOLNumber.Text.Length > 80)
            {
                lblBOLError.Visible = true;
                return;
            }

            if (tbContactExtension.Text.Length > 50)
            {
                lblContactExtentionError.Visible = true;
                return;
            } 
            problem = "BOL #: " + tbBOLNumber.Text + Environment.NewLine + Environment.NewLine + "Description: " + txtProbDescription.Text + Environment.NewLine 
                + Environment.NewLine + "EXT: " + tbContactExtension.Text;
        }
        else // problem is just the one text box
        {
            problem = txtProbDescription.Text;
        }

        try
        {
            insert.TargetCompletionDate = DateTime.Parse(txtTargetCompletionDate.Text);
        }
        catch
        {
            lblTargetCompletionDate.Visible = true;
            return;
        }
        //Insert A new Ticket

        if (txtPermanentFix.Text.Trim() == "" || txtPermanentFix.Text == null)
        {
            insert.PermanentFix = null;
           
        }
        else
        {
            insert.PermanentFix = txtPermanentFix.Text;
        }

        if (txtImmediateFix.Text.Trim() == "" || txtImmediateFix.Text == null)
        {
            insert.ImmediateFix = null;
        }
        else
        {
            insert.ImmediateFix = txtImmediateFix.Text;
        }

        if (txtRootCause.Text.Trim() == "" || txtRootCause.Text == null)
        {
            insert.RootCause = null;
        }
        else
        {
            insert.RootCause = txtRootCause.Text;
        }


        if (ddlSkill.SelectedValue == "0000")
        {
            lblSkillError.Visible = true;
            return;
        }
        else
        {
            lblSkillError.Visible = false;
        }

        if (ddlClosed.SelectedValue == "0000")
        {
            lblClosedError.Visible = true;
            return;
        }
        else
        {
            lblClosedError.Visible = false;
        }

       
        insert.Issuer = Int32.Parse(ddlEmployee.SelectedItem.Value);
        insert.Email = txtEmail.Text;
        insert.Division = ddlPlant.SelectedItem.Value;
        insert.Dept = Int32.Parse(ddlDepartment.SelectedValue);
        insert.System = Int32.Parse(ddlSystem.SelectedValue);
        insert.ProblemDesc = problem;
        insert.AssignedTo = Int32.Parse(ddlAssignedTo.SelectedValue);

        if (tblPriority.Visible == true)
            insert.Priority = Int32.Parse(ddlPriority.SelectedValue);
        else
            insert.Priority = 1; //High

        insert.RepeatIssue = Int32.Parse(ddlRepeatIssue.SelectedValue);    
        insert.IssueType = Int32.Parse(ddlType.SelectedValue);
        insert.Status = Int32.Parse(ddlStatus.SelectedValue);
        insert.SubSystem = Int32.Parse(ddlSubSystem.SelectedValue);
        
        insert.TimeToResolve = txtTimeToResolve.Text;       
        insert.Skill = Int32.Parse(ddlSkill.SelectedValue); //int
      
        insert.Closed = Int32.Parse(ddlClosed.SelectedValue);


        EmployeeDAL.Insert(Int32.Parse(ddlEmployee.SelectedItem.Value), txtEmail.Text,
            ddlPlant.SelectedItem.Value, Int32.Parse(ddlDepartment.SelectedValue),"","","",1);


        int ticketID = CreateAdminTicketDAL.InsertTicket(insert);



         
        //Add image
        lblTicketNumber.Text = ticketID.ToString();
        ticketEntry.Visible = false;
        Splash.Visible = true;
        Splash.Controls.Add(new LiteralControl("<img src='images/Success.jpg'>"));
        Response.Redirect("~/Edit.aspx?ticketnumber=" + ticketID.ToString());
    }

    //Writes the calendar's selected date on the textbox
    protected void Calendar_SelectionChanged(object sender, EventArgs e)
    {
        txtTargetCompletionDate_PopupControlExtender.Commit(Calendar.SelectedDate.ToShortDateString());
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
      //  txtVerificationDate_PopupControlExtender.Commit(Calendar1.SelectedDate.ToShortDateString());
    }

    //Writes the calendar's selected date on the textbox
    protected void actualDateCalendar_SelectionChanged(object sender, EventArgs e)
    {
      //  txtActualCompletionDate_PopupControlExtender.Commit(actualDateCalendar.SelectedDate.ToShortDateString());
    }
    protected void ddlSubSystem_DataBound(object sender, EventArgs e)
    {
        if (ddlSubSystem.SelectedItem.Text == "ASN Issue")
        {
            tbInfo.Visible = true;
        }
        else
        {
            tbInfo.Visible = false;
        }
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedItem.Text == "Open")
        {
            udpClosedInfo.Visible = false;
        }
        else
        {
            udpClosedInfo.Visible = true;
        }
    }
}