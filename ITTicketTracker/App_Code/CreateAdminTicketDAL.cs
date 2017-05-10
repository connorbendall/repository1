/*Bend-All
 * TicketDAl
 * 
 * Date created 05/16/2012
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

/// <summary>
///This DAL (Data Access Layer) Class is used to connecto to the database and insert data to the database 
/// declaring variables to be accessed by the dropdown boxes.
/// </summary>
public class CreateAdminTicketDAL
{
    #region Database Connection

    private static string connectionString = ConfigurationManager.ConnectionStrings["ISSUESConnectionString"].ConnectionString;

    private static SqlConnection Connection = new SqlConnection(connectionString);

    #endregion

    #region Class Variables

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

    private int subSystem;

    public int SubSystem
    {
        get { return subSystem; }
        set { subSystem = value; }
    }

    private SqlDateTime verificationCheck;

    public SqlDateTime VerificationCheck
    {
        get { return verificationCheck; }
        set { verificationCheck = value; }
    }

    private string timeToResolve;

    public string TimeToResolve
    {
        get { return timeToResolve; }
        set { timeToResolve = value; }
    }

    private string rootCause;

    public string RootCause
    {
        get { return rootCause; }
        set { rootCause = value; }
    }

    private string immediateFix;

    public string ImmediateFix
    {
        get { return immediateFix; }
        set { immediateFix = value; }
    }

    private string permanentFix;

    public string PermanentFix
    {
        get { return permanentFix; }
        set { permanentFix = value; }
    }


    private string problemDesc;

    public string ProblemDesc
    {
        get { return problemDesc; }
        set { problemDesc = value; }
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

    private int closed;

    public int Closed
    {
        get { return closed; }
        set { closed = value; }
    }

    private string division;

    public string Division
    {
        get { return division; }
        set { division = value; }
    }

    private int skill;

    public int Skill
    {
        get { return skill; }
        set { skill = value; }
    }


    private SqlDateTime targetCompletionDate;

    public SqlDateTime TargetCompletionDate
    {
        get { return targetCompletionDate; }
        set { targetCompletionDate = value; }
    }

    private SqlDateTime actualCompletionDate;

    public SqlDateTime ActualCompletionDate
    {
        get { return actualCompletionDate; }
        set { actualCompletionDate = value; }
    }

    private int issueType;

    public int IssueType
    {
        get { return issueType; }
        set { issueType = value; }
    }

    private int prjNum;

    public int PrjNum
    {
        get { return prjNum; }
        set { prjNum = value; }
    }
    private int status;

    public int Status
    {
        get { return status; }
        set { status = value; }
    }

    private SqlDateTime dateClosed;

    public SqlDateTime DateClosed
    {
        get { return dateClosed; }
        set { dateClosed = value; }
    }



    #endregion

    #region Insert Methods

    public static Int32 InsertTicket(CreateAdminTicketDAL newIssue)
    {

        SqlCommand insertCommand = new SqlCommand("CREATE_TICKET_ADMIN", Connection);
        //Pass variable parameters to procedure
        insertCommand.CommandType = CommandType.StoredProcedure;
        insertCommand.Parameters.AddWithValue("@issuer", newIssue.issuer);
        insertCommand.Parameters.AddWithValue("@email", newIssue.email);
        insertCommand.Parameters.AddWithValue("@dept", newIssue.dept);
        insertCommand.Parameters.AddWithValue("@system", newIssue.system);
        insertCommand.Parameters.AddWithValue("@probDesc", newIssue.problemDesc);
        insertCommand.Parameters.AddWithValue("@priority", newIssue.priority);
        insertCommand.Parameters.AddWithValue("@repeatIssue", newIssue.repeatIssue);
        insertCommand.Parameters.AddWithValue("@division", newIssue.division);
        insertCommand.Parameters.AddWithValue("@assignedTo", newIssue.assignedTo);

        insertCommand.Parameters.AddWithValue("@issueType", newIssue.issueType);
        insertCommand.Parameters.AddWithValue("@prjNum", (object)newIssue.prjNum ?? DBNull.Value);

        insertCommand.Parameters.AddWithValue("@status", newIssue.status);
        insertCommand.Parameters.AddWithValue("@SubSystem", (object)newIssue.subSystem ?? DBNull.Value);
        insertCommand.Parameters.AddWithValue("@ResolveTime", (object)newIssue.TimeToResolve ?? DBNull.Value);
        insertCommand.Parameters.AddWithValue("@rootCause", (object)newIssue.RootCause ?? DBNull.Value);


        insertCommand.Parameters.AddWithValue("@PCA", (object)newIssue.PermanentFix ?? DBNull.Value);
        insertCommand.Parameters.AddWithValue("@resolution", (object)newIssue.ImmediateFix ?? DBNull.Value);
        insertCommand.Parameters.AddWithValue("@skill", (object)newIssue.Closed ?? DBNull.Value);
        insertCommand.Parameters.AddWithValue("@ticket_status", (object)newIssue.Closed ?? DBNull.Value);

        SqlParameter targetCompleteParam = new SqlParameter("@targetComplete", SqlDbType.DateTime);
        targetCompleteParam.Value = (object)newIssue.targetCompletionDate ?? DBNull.Value;



        insertCommand.Parameters.Add(targetCompleteParam);

  

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
}