using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for SubsystemRoles
/// </summary>
public class SubsystemRolesDAL
{
  #region Database Connection
    private static string connectionString = ConfigurationManager.ConnectionStrings["ISSUESConnectionString"].ConnectionString;

    private static SqlConnection Connection = new SqlConnection(connectionString);

    #endregion

    // deletePrevious dictates if previous records should be deleted before inserting the new one
    // value of 0 = no delete 1= delete and insert 2= delete no insert
    public void SaveSubsystemRole(int systemID,int subsystemID, int roleID, int deletePrevious)
    {

        List<UserRoles> roleList = new List<UserRoles>() ;

        SqlCommand getCommand = new SqlCommand("ADMIN_SAVE_SUBSYSTEM_ROLES", Connection);
        getCommand.CommandType = CommandType.StoredProcedure;
        getCommand.Parameters.AddWithValue("@systemID", systemID);
        getCommand.Parameters.AddWithValue("@subsystemID", subsystemID);
        getCommand.Parameters.AddWithValue("@roleID", roleID);
        getCommand.Parameters.AddWithValue("@deletePrevious", deletePrevious);

        try
        {
            Connection.Open();
            getCommand.ExecuteNonQuery();
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


    public List<SubsystemRoles> GetRolesForSubsystem(int system, int subsystem)
	{

        List<SubsystemRoles> roleList = new List<SubsystemRoles>();

        SqlCommand getCommand = new SqlCommand("ADMIN_GET_SUBSYSTEM_ROLES", Connection);
        getCommand.CommandType = CommandType.StoredProcedure;
        getCommand.Parameters.AddWithValue("@systemID", system);
        getCommand.Parameters.AddWithValue("@subsystemID", subsystem);

        try
        {
            Connection.Open();
            SqlDataReader reader = getCommand.ExecuteReader();

            while (reader.Read())
            {
                SubsystemRoles role = new SubsystemRoles();
                role.roleID = (int)reader.GetDecimal(0);
                role.roleName = reader.GetString(1);
                role.isChecked = reader.GetInt32(2);


                roleList.Add(role);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Connection.Close();
        }

        return roleList;
	}
}

public class SubsystemRoles
{
    public int isChecked;
    public int roleID;
    public string roleName;
}
