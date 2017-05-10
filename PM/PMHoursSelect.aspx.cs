using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValidationLibrary;

public partial class reportDateRangeSelect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtDateFrom.Text == "" || txtDateTo.Text == "")
        {
            lblError.Text = "Invalid Date selected";
        }
        else
        {
            if (Validator.IsDate(txtDateFrom.Text) && Validator.IsDate(txtDateTo.Text))
            {
                if (Validator.dateRange(txtDateFrom.Text, txtDateTo.Text))
                {
                    Response.Redirect("~/PMHoursReport.aspx?DateFrom=" + txtDateFrom.Text + "&DateTo=" + txtDateTo.Text + "&Division=" + drpDivision.SelectedValue);
                }
                else
                {
                    lblError.Text = "Date From cannot be past Date To";
                }
            }
            else
            {
                lblError.Text = "Invalid Dates";
            }
        }
    }
    protected void calDateFrom_SelectionChanged(object sender, EventArgs e)
    {
        txtDateFrom_PopupControlExtender.Commit(calDateFrom.SelectedDate.ToShortDateString());
    }
    protected void calDateTo_SelectionChanged(object sender, EventArgs e)
    {
         txtDateTo_PopupControlExtender.Commit(calDateTo.SelectedDate.ToShortDateString());
    }
}