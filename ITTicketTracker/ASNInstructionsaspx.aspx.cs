using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASNInstructionsaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ticketID = Request.QueryString["ticketID"];
        lblTicketNumber.Text = "Your Ticket Number is: " + ticketID;
        
    }
}