using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValidationLibrary;

public partial class PMEnterPM1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if(drpDivision.SelectedValue != "PLEASE SELECT" && drpMachine.SelectedValue != null && drpFrequency.SelectedValue != "PLEASE SELECT" && lstPerformed.SelectedValue != "PLEASE SELECT" &&
            txtComplete.Text != "")
        {
            if (Validator.IsDate(txtDate.Text))
            {
                Response.Redirect("~/pmenterpm2.aspx?Division=" + drpDivision.SelectedValue + "&Machine=" + drpMachine.SelectedValue + "&Frequency=" + drpFrequency.SelectedValue + "&Date=" + txtDate.Text + "&PerformedBy=" + lstPerformed.SelectedValue + "&Complete=" + txtComplete.Text);
            }
            else
            {
                lblError.Text = "Invalid Date";
            }
        }
        else
        {
            lblError.Text = "All fields are required";
        }
    }
    protected void calDate_SelectionChanged(object sender, EventArgs e)
    {
        txtDate_PopupControlExtender.Commit(calDate.SelectedDate.ToShortDateString());
    }
}