using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;

public partial class Reports : System.Web.UI.Page
{

    string connectionString = @"Data Source=pangea;Initial Catalog=ISSUES;User ID=sa;Password=p@ssw0rd";
    int assigned = 0;
    int opentickets = 0;
    int openIssues = 0;
    int openProj = 0;
    int unAss = 0;

    protected void Page_LoadComplete(object sender, EventArgs e)
    {


        if (Session["IsAdmin"] != null)
        {
            int isAdmin = Int32.Parse(Session["IsAdmin"].ToString());

            if (isAdmin == 0)
                Response.Redirect("~/Default.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            TicketStats();
    }

    public int TicketStats()
    {

        SqlConnection conn = new SqlConnection(connectionString);
        
        SqlCommand sqlcmd = new SqlCommand("OpenStats", conn);
        sqlcmd.CommandType = CommandType.StoredProcedure;

        sqlcmd.Parameters.Add("@Open", SqlDbType.Int).Direction = ParameterDirection.Output;
        sqlcmd.Parameters.Add("@assigned", SqlDbType.Int).Direction = ParameterDirection.Output;
        sqlcmd.Parameters.Add("@openIssues", SqlDbType.Int).Direction = ParameterDirection.Output;
        sqlcmd.Parameters.Add("@openProj", SqlDbType.Int).Direction = ParameterDirection.Output;
        sqlcmd.Parameters.Add("@unAss", SqlDbType.Int).Direction = ParameterDirection.Output;
        

        //Execute
        try
        {
            conn.Open();
            sqlcmd.ExecuteNonQuery();

            opentickets = int.Parse(sqlcmd.Parameters["@Open"].Value.ToString()); 
            assigned = int.Parse(sqlcmd.Parameters["@assigned"].Value.ToString());
            openIssues = int.Parse(sqlcmd.Parameters["@openIssues"].Value.ToString());
            openProj = int.Parse(sqlcmd.Parameters["@openProj"].Value.ToString());
            unAss = int.Parse(sqlcmd.Parameters["@unAss"].Value.ToString()); 

        }
        catch (Exception ex)
        {
            throw ex;
            
        }
        finally
        {
            conn.Close();
        }
        
        fillLabels();

        return 0;

    }

    public void fillLabels()
    {

        lblOpenTickets.Text = opentickets.ToString();
        lblassigned.Text = assigned.ToString();
        lblOpenIssues.Text = openIssues.ToString();
        lblOpenProjects.Text = openProj.ToString();
        lblUnass.Text = unAss.ToString();


    }
   
    protected void btnExpExcel_Click(object sender, EventArgs e)
    {
        DataView dvReport = new DataView();
        DataTable dtReport = new DataTable();
        dvReport = (DataView)sqlReportTicket.Select(DataSourceSelectArguments.Empty);
 
        dtReport = dvReport.ToTable();

        DataView dvStats = new DataView();
        DataTable dtStats = new DataTable();
        dvStats = (DataView)sqlStaffStat.Select(DataSourceSelectArguments.Empty);

        dtStats = dvStats.ToTable();


        ExcelPackage pck = new ExcelPackage();
        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Open IT Issues");

        ws.Cells["A2"].LoadFromDataTable(dtStats, true);
        ws.Cells["A10"].LoadFromDataTable(dtReport, true);

        DateTime today = DateTime.Today;
        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;  filename=BAA_ITOpenIssues_" + today.ToShortDateString() + ".xlsx");
        Response.BinaryWrite(pck.GetAsByteArray());
        Response.End();
       
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        //gridReports.FindControl("Comments") as TextBox
    }

    protected void ddlSystem_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSubSystem.Items.Clear();
        ddlSubSystem.Items.Add(new ListItem("All","0000"));
    }

    protected void btnTicketNumber_Click(object sender, EventArgs e)
    {
        try
        {
            int ticketNumber = Int32.Parse(txtTicketNumber.Text);
            Response.Redirect("~/Edit.aspx?ticketnumber=" + txtTicketNumber.Text);
        }
        catch
        {
            lblError.Visible = true;

        }
    }
}