using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValidationLibrary;

public partial class PMScheduleEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        if (e.NewValues["StartingDate"] != null)
        {
            if(!Validator.IsDate(e.NewValues["StartingDate"].ToString()))
            {
                e.Cancel = true;
                lblError.Text = "Starting Date is an invalid Date";
            }
        }
    }
    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        DetailsView1.DefaultMode = DetailsViewMode.ReadOnly;
    }
}