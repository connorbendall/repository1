using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValidationClassLibrary;

public partial class View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";
    }
    
    protected void btnSubmitTicket_Click(object sender, EventArgs e)
    {
        if (!Validator.IsNumeric(txtTicketNumber.Text))
        {
            lblError.Text = "Please enter numbers only";
            
        }
        else
        {
            Response.Redirect("~/DetailTicketView.aspx?ID=" + txtTicketNumber.Text);
        }
    }
    
    protected void btnSubmitStatusByEmployee_Click(object sender, EventArgs e)
    {
        ViewTickets.Visible = true;
        SelectTicket.Visible = false;
        gvTickets.Visible = true;
        lblUser.Text = ddlEmployee.SelectedItem.ToString();
        
        lblStatus.Text = ddlStatus.SelectedItem.ToString();
    }
    protected void btnSubmitStatusDept_Click(object sender, EventArgs e)
    {
        ViewTickets.Visible = true;
        SelectTicket.Visible = false;
        gvTicketsByDeptAndStatus.Visible = true;
        lblUser.Text = ddlDept.SelectedItem.ToString();
        lblStatus.Text = ddlStatusByDept.SelectedItem.ToString();
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        ViewTickets.Visible = false;
        SelectTicket.Visible = true;
        gvTicketsByDeptAndStatus.Visible = false;
        gvTickets.Visible = false;
    }
}