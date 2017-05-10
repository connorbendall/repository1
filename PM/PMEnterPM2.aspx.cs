using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PMEnterPM2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (FormView1.FindControl("txtMachine") as TextBox).Text = Request.QueryString["Machine"];
        (FormView1.FindControl("txtFrequency") as TextBox).Text = Request.QueryString["Frequency"];
        (FormView1.FindControl("txtDate") as TextBox).Text = Request.QueryString["Date"];
        (FormView1.FindControl("txtPerformedBy") as TextBox).Text = Request.QueryString["PerformedBy"];
        (FormView1.FindControl("txtComplete") as TextBox).Text = Request.QueryString["Complete"];
        (FormView1.FindControl("txtDivision") as TextBox).Text = Request.QueryString["division"];
       // (FormView1.FindControl("lblScheduleID") as Label).Text = Request.QueryString["ScheduleID"];

        
    }
    protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
}