using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PMSchedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedValue != "")
        {
            Response.Redirect("~/PMScheduleList.aspx?Division=" + DropDownList1.SelectedValue + "&Machinenumber=" + DropDownList2.SelectedValue);
        }
    }
}