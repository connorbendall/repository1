/*Bend-All
 * TicketDAl
 * 
 * Date created 05/16/2012
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// This DAL (Data Access Layer) Class is used to connecto to the database and insert data to the database 
/// declaring variables to be accessed by the dropdown boxes.
/// </summary>
public class TicketDAL
{
    

    #region Database Connection
    private static string connectionString = ConfigurationManager.ConnectionStrings["ISSUESConnectionString"].ConnectionString;

    private static SqlConnection Connection = new SqlConnection(connectionString);

    #endregion

    #region Class Variables

    private int issueID = 0;

    public int IssueID
    {
        get { return issueID; }
        set { issueID = value; }
    }

    private int issuer;

    public int Issuer
    {
        get { return issuer; }
        set { issuer = value; }
    }

    private string email;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    private int dept;

    public int Dept
    {
        get { return dept; }
        set { dept = value; }
    }

    private int system;

    public int System
    {
        get { return system; }
        set { system = value; }
    }

    private int subsystem;

    public int Subsystem
    {
        get { return subsystem; }
        set { subsystem = value; }
    }


    private string probDesc;

    public string ProbDesc
    {
        get { return probDesc; }
        set { probDesc = value; }
    }

    private int assignedTo;

    public int AssignedTo
    {
        get { return assignedTo; }
        set { assignedTo = value; }
    }

    private int priority;

    public int Priority
    {
        get { return priority; }
        set { priority = value; }
    }

    private int repeatIssue;

    public int RepeatIssue
    {
        get { return repeatIssue; }
        set { repeatIssue = value; }
    }

    private string division;

    public string Division
    {
        get { return division; }
        set { division = value; }
    }


    

    #endregion


    #region Insert Methods

    public static Int32 Insert(TicketDAL newIssue)
    {

        SqlCommand insertCommand = new SqlCommand("CREATE_TICKET_USER", Connection);
        insertCommand.CommandType = CommandType.StoredProcedure;
        insertCommand.Parameters.AddWithValue("@issuer", newIssue.issuer);
        insertCommand.Parameters.AddWithValue("@email", newIssue.email);
        insertCommand.Parameters.AddWithValue("@dept", newIssue.dept);
        insertCommand.Parameters.AddWithValue("@system", newIssue.system);
        insertCommand.Parameters.AddWithValue("@probDesc", newIssue.probDesc);
        insertCommand.Parameters.AddWithValue("@assignedto", newIssue.assignedTo);
        insertCommand.Parameters.AddWithValue("@priority", newIssue.priority);
        insertCommand.Parameters.AddWithValue("@repeatIssue", newIssue.repeatIssue);
        insertCommand.Parameters.AddWithValue("@division", newIssue.division);

        insertCommand.Parameters.AddWithValue("@SubSystem", newIssue.subsystem);
       

        SqlParameter ticketID = new SqlParameter("@ticketID", SqlDbType.Int);
        ticketID.Direction = ParameterDirection.Output;
        insertCommand.Parameters.Add(ticketID);

        try
        {
            Connection.Open();
            insertCommand.ExecuteNonQuery();
            return int.Parse(ticketID.Value.ToString());
            
        }
        catch (Exception ex)
        {

            throw ex;

        }
        finally
        {
            Connection.Close();
        }

    }
    #endregion

    #region Ticket number method

    public static DataTable ticketNumber()
    {
        string sql = string.Format("select MAX(issueid) AS issueid from ISSUES.dbo.tbl_issues2");
        SqlDataAdapter ticketNumberAdapter = new SqlDataAdapter(sql, Connection);
        DataTable issuesTable = new DataTable();
        

        try
        {
            ticketNumberAdapter.Fill(issuesTable);
            return issuesTable;
            
        }
        catch (Exception ex)
        {

            throw ex;
        }
        
    }

    #endregion

}