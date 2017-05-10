using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class SiteMaster : System.Web.UI.MasterPage
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
        

        NavigationMenu.Items.Clear();

        if (Session["IsAdmin"] == null)
        {
            if (Request.QueryString["SecBypass"] != null)
            {
                string secValue = Request.QueryString["SecBypass"];
                if (secValue.ToLower() == "itadmin")
                {
                    Session["IsAdmin"] = 1;
                }
                else if (secValue.ToLower() == "itsuper")
                {
                    Session["IsAdmin"] = 2;
                }
                else
                {
                    Session["IsAdmin"] = 0;
                }
            }
            else
            {
                Session["IsAdmin"] = 0;
            }

            if (Request.QueryString["SecBypass"] != null)
            {
                string secValue = Request.QueryString["SecBypass"];
                if (secValue.ToLower() == "itadmin")
                {
                    Session["IsAdmin"] = 1;
                }
                else if (secValue.ToLower() == "itsuper")
                {
                    Session["IsAdmin"] = 2;
                }
                else
                {
                    Session["IsAdmin"] = 0;
                }
            }
            else
            {
                Session["IsAdmin"] = 0;
            }

        }
        else
        {
            if (Request.QueryString["SecBypass"] != null)
            {
                string secValue = Request.QueryString["SecBypass"];
                if (secValue.ToLower() == "itadmin")
                {
                    Session["IsAdmin"] = 1;
                }
            }

            if (Request.QueryString["SecBypass"] != null)
            {
                string secValue = Request.QueryString["SecBypass"];
                if (secValue.ToLower() == "itsuper")
                {
                    Session["IsAdmin"] = 2;
                }
            }
        }


        int isAdmin = Int32.Parse(Session["IsAdmin"].ToString());

        if (isAdmin == 1)
        {
          //  overlay.Visible = false;
            //show admin menu
            NavigationMenu.Items.Add(new MenuItem("Create", "Create", null, "~/CreateAdminTicket.aspx?SecBypass=ITAdmin"));
            NavigationMenu.Items.Add(new MenuItem("Reports", "Reports", null, "~/Reports.aspx?SecBypass=ITAdmin"));
            NavigationMenu.Items.Add(new MenuItem("Dashboard", "Dashboard", null, "~/Dashboard.aspx?SecBypass=ITAdmin"));
            NavigationMenu.Items.Add(new MenuItem("IT Stats", "IT Stats", null, "~/ExecutiveDashboard.aspx?SecBypass=ITAdmin"));

            NavigationMenu.Items.Add(new MenuItem("IT Manual", "IT Manual", null, @"~\Doc\AdminSystem.pptx?SecBypass=ITAdmin"));
            NavigationMenu.Items.Add(new MenuItem("Project Summary", "Project Summary", null, @"file:\\baasan\Company\Information Technology\Controlled Documents\Master Documents\L6 Projects\IT Master Project List.xlsx"));
            NavigationMenu.Items.Add(new MenuItem("Manage On-Call", "Manage On-Call", null, "~/AdminManagementOnCall.aspx"));

            MenuItem taskMenue = new MenuItem("Task Manager", "Task Manager", null, null);
            taskMenue.ChildItems.Add(new MenuItem("Complete Task", "Complete Task", null, "~/CompleteTaskDetails.aspx?SecBypass=ITAdmin"));
            taskMenue.ChildItems.Add(new MenuItem("Manage Groups/Tasks", "Manage Groups/Tasks", null, "~/TaskManager.aspx?SecBypass=ITAdmin"));
            taskMenue.ChildItems.Add(new MenuItem("Task Notification", "Task Notification", null, "~/TaskNotification.aspx?SecBypass=ITAdmin"));
            taskMenue.ChildItems.Add(new MenuItem("Task Reports", "Task Reports", null, "~/TaskReport.aspx?SecBypass=ITAdmin"));
            
            NavigationMenu.Items.Add(taskMenue);
        }
        else if(isAdmin ==2)
        {
            NavigationMenu.Items.Add(new MenuItem("Create", "Create", null, "~/CreateAdminTicket.aspx?SecBypass=ITSuper"));
            NavigationMenu.Items.Add(new MenuItem("Reports", "Reports", null, "~/Reports.aspx?SecBypass=ITSuper"));
            NavigationMenu.Items.Add(new MenuItem("Dashboard", "Dashboard", null, "~/Dashboard.aspx?SecBypass=ITSuper"));
            NavigationMenu.Items.Add(new MenuItem("IT Statistics", "IT Statistics", null, "~/ExecutiveDashboard.aspx?SecBypass=ITSuper"));
            NavigationMenu.Items.Add(new MenuItem("IT Manual", "IT Manual", null, @"~\Doc\AdminSystem.pptx?SecBypass=ITSuper"));
            NavigationMenu.Items.Add(new MenuItem("Project Summary", "Project Summary", null, @"file:\\baasan\Company\Information Technology\Controlled Documents\Master Documents\L6 Projects\IT Master Project List.xlsx"));
            NavigationMenu.Items.Add(new MenuItem("Manage On-Call", "Manage On-Call", null, "~/AdminManagementOnCall.aspx"));
            NavigationMenu.Items.Add(new MenuItem("IT ADMIN Management", "Admin Management", null, @"~/AdminManagement.aspx?SecBypass=ITSuper"));

            MenuItem taskMenue = new MenuItem("Task Manager", "Task Manager", null, null);
            taskMenue.ChildItems.Add(new MenuItem("Complete Task", "Complete Task", null, "~/CompleteTaskDetails.aspx?SecBypass=ITSuper"));
            taskMenue.ChildItems.Add(new MenuItem("Manage Groups/Tasks", "Manage Groups/Tasks", null, "~/TaskManager.aspx?SecBypass=ITSuper"));
            taskMenue.ChildItems.Add(new MenuItem("Task Notification", "Task Notification", null, "~/TaskNotification.aspx?SecBypass=ITSuper"));
            taskMenue.ChildItems.Add(new MenuItem("Task Reports", "Task Reports", null, "~/TaskReport.aspx?SecBypass=ITSuper"));
            NavigationMenu.Items.Add(taskMenue);
        }
        else 
        {
           // overlay.Visible = true;
            //show regular user menu
            NavigationMenu.Items.Add(new MenuItem("Create", "Create", null, "~/Default.aspx"));
            NavigationMenu.Items.Add(new MenuItem("View", "View", null, "~/View.aspx"));
            //NavigationMenu.Items.Add(new MenuItem("IT Statistics", "IT Statistics", null, "~/ExecutiveDashboard.aspx"));
        }

        NavigationMenu.Items.Add(new MenuItem("Change Log", "Change Log", null,@"~/ChangeLog.aspx"));
    }
}
