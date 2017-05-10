using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class printCustomerFastTrack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = Request.QueryString["DateFrom"];
        Label3.Text = Request.QueryString["DateTo"];
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        DateTime today = DateTime.Today;
        string attachment = "attachment; filename=BendAllAutomotiveReport_" + today.ToShortDateString() + ".xls";

        Response.ClearContent();

        Response.AddHeader("content-disposition", attachment);

        Response.ContentType = "application/ms-excel";

        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        GridView1.RenderControl(htw);

        Response.Write(sw.ToString());

        Response.End(); 

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void srcPM_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.CommandTimeout = 8000;
    }
}