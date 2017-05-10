using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValidationLibrary;

public partial class PMScheduleList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (DetailsView1.FindControl("txtDivision") as TextBox).Text = Request.QueryString["Division"];
        (DetailsView1.FindControl("txtNumber") as TextBox).Text = Request.QueryString["Machinenumber"];
    }
    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
    protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        if (e.Values["StartingDate"] != null)
        {
            if (!Validator.IsDate(e.Values["StartingDate"].ToString()))
            {
                e.Cancel = true;
                lblError.Text = "Starting Date is an invalid date";
            }
        }
        else
        {
            lblError.Text = "Please select a Start Date";
            e.Cancel = true;
        }
        if (e.Values["frequency"] == null)
        {
            lblError.Text = "Please select a frequency";
            e.Cancel = true;
        }

        if (e.Values["task"] == null)
        {
            lblError.Text = "Please insert a task";
            e.Cancel = true;
        }
    }
}