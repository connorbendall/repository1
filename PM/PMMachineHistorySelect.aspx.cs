using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PMSchedule : System.Web.UI.Page
{
    private string divisionNum = null;
    private string machNum = null;
    private bool autoRedirect = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        divisionNum = Request.QueryString["Division"];
        machNum = Request.QueryString["Machine"];
        if (divisionNum != null)
        {
            DropDownList1.SelectedValue = divisionNum;
            DropDownList2.SelectedValue = machNum;
        }
    }
}