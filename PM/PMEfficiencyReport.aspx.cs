using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValidationLibrary;
using System.IO;

public partial class PMEfficiencyReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (!Validator.IsDate(txtDateFrom.Text))
        {
            lblError.Text = "Invalid From Date<br/>";
        }

        if (!Validator.IsDate(txtDateTo.Text))
        {
            lblError.Text += "Invalid To Date<br/>";
        }

        if (lblError.Text == "")
        {
            divReport.Visible = true;

        }
    }
    protected void gvEfficiencyReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDateDiff = e.Row.FindControl("lblElasped") as Label;

            // read the value from the datasoure 

            Double days = Convert.ToDouble(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "life")));
            DataControlFieldCell d = lblDateDiff.Parent as DataControlFieldCell;
            if (days <=5)
            {
                d.BackColor = System.Drawing.Color.Green;
            }
            else if (days >=6 && days <9)
            {
                d.BackColor = System.Drawing.Color.Yellow;
            }
            else if(days >=9)
            {
                d.BackColor = System.Drawing.Color.Red;
            }
            

        }  

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //This is so that we can export the grid view
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        DateTime today = DateTime.Today;
        string attachment = "attachment; filename=Bend-All-PPAP Expiring-" + txtDateFrom.Text + " - " + txtDateTo.Text + ".xls";

        Response.ClearContent();

        Response.AddHeader("content-disposition", attachment);

        Response.ContentType = "application/ms-excel";

        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        fvEfficiencyDetails.RenderControl(htw);
        gvEfficiencyReport.RenderControl(htw);


        Response.Write(sw.ToString());

        Response.End();
    }
}