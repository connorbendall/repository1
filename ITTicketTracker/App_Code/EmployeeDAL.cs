using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for EmployeeDAL
/// </summary>
public class EmployeeDAL
{
	public EmployeeDAL()
	{
        //
        // TODO: Add constructor logic here
        //
    }
    public EmployeeDAL(int employeeNumber)
    {
        this.employeeNumber = employeeNumber;

        string oString = "SELECT * FROM tbl_SavedEmployees WHERE EmployeeNumber = @employeeNumber";
        SqlCommand oCmd = new SqlCommand(oString, ddConnection);
        oCmd.Parameters.AddWithValue("@employeeNumber", employeeNumber.ToString());
        ddConnection.Open();
        using (SqlDataReader oReader = oCmd.ExecuteReader())
        {
            while (oReader.Read())
            {
                employeeEmail = oReader["EmployeeEmail"].ToString();
                employeePlant = oReader["EmployeePlant"].ToString();
                employeeDept = oReader["EmployeeDepartment"].ToString();
                workPhone = oReader["WorkPhone"].ToString();
                cellPhone = oReader["CellPhone"].ToString();
                location = oReader["Location"].ToString();
            }

            ddConnection.Close();
        }
    }

    #region Class Variables
    private static string connectionString = ConfigurationManager.ConnectionStrings["ISSUESConnectionString"].ConnectionString;

    private static SqlConnection ddConnection = new SqlConnection(connectionString);

    private string employeeEmail, employeePlant, employeeDept, workPhone, cellPhone, location;
    private int employeeNumber;

    public string EmployeeEmail
    {
        get
        {
            return employeeEmail;
        }

        set
        {
            employeeEmail = value;
        }
    }

    public string EmployeePlant
    {
        get
        {
            return employeePlant;
        }

        set
        {
            employeePlant = value;
        }
    }

    public string EmployeeDept
    {
        get
        {
            return employeeDept;
        }

        set
        {
            employeeDept = value;
        }
    }

    public int EmployeeNumber
    {
        get
        {
            return employeeNumber;
        }

        set
        {
            employeeNumber = value;
        }
    }

    public string WorkPhone
    {
        get
        {
            return workPhone;
        }

        set
        {
            workPhone = value;
        }
    }

    public string CellPhone
    {
        get
        {
            return cellPhone;
        }

        set
        {
            cellPhone = value;
        }
    }

    public string Location
    {
        get
        {
            return location;
        }

        set
        {
            location = value;
        }
    }
    #endregion

    #region Get Methods
    public static DataTable getEmployees()
    {

        string sql = string.Format("SELECT lastname FROM tbl_employees");
        SqlDataAdapter employeeAdapter = new SqlDataAdapter(sql, ddConnection);
        DataTable employeeTable = new DataTable();

        try
        {
            employeeAdapter.Fill(employeeTable);
            return employeeTable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Insert Methods

    public static void Insert(int employeeNumber, string employeeEmail, string employeePlant, int employeeDept, string workPhone, 
        string cellPhone, string location, int increase)
    {

        SqlCommand insertCommand = new SqlCommand("SaveEmployee", ddConnection);
        insertCommand.CommandType = CommandType.StoredProcedure;
        insertCommand.Parameters.AddWithValue("@employeeNumber", employeeNumber);
        insertCommand.Parameters.AddWithValue("@employeeEmail", employeeEmail);
        insertCommand.Parameters.AddWithValue("@employeePlant", employeePlant);
        insertCommand.Parameters.AddWithValue("@employeeDept", employeeDept);
        insertCommand.Parameters.AddWithValue("@workPhone", workPhone);
        insertCommand.Parameters.AddWithValue("@cellPhone", cellPhone);
        insertCommand.Parameters.AddWithValue("@location", location);
        insertCommand.Parameters.AddWithValue("@increase", increase);

        try
        {
            ddConnection.Open();
            insertCommand.ExecuteNonQuery();

        }
        catch (Exception ex)
        {

            throw ex;

        }
        finally
        {
            ddConnection.Close();
        }

    }
    #endregion
}