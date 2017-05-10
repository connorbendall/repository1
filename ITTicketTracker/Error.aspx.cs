using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(String.IsNullOrEmpty(Request.QueryString["errorMessage"]))
        {
            lblError.Text = "A General Error Occurred";
        }
        else
        {
            lblError.Text = Request.QueryString["errorMessage"];
        }


    }
}