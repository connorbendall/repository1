using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for UserRolesDAL
/// </summary>
public class UserRolesDAL
{

    #region Database Connection
    private static string connectionString = ConfigurationManager.ConnectionStrings["ISSUESConnectionString"].ConnectionString;

    private static SqlConnection Connection = new SqlConnection(connectionString);

    #endregion

    // deletePrevious dictates if previous records should be deleted before inserting the new one
    // value of 0 = no delete 1= delete and insert 2= delete no insert
    public void SaveUserRole(int userID, int roleID, int deletePrevious)
    {

        List<UserRoles> roleList = new List<UserRoles>();

        SqlCommand getCommand = new SqlCommand("ADMIN_SAVE_ITUSER_ROLES", Connection);
        getCommand.CommandType = CommandType.StoredProcedure;
        getCommand.Parameters.AddWithValue("@userID", userID);
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


    public List<UserRoles> GetRolesForUser(int userID)
	{

        List<UserRoles> roleList = new List<UserRoles>();

        SqlCommand getCommand = new SqlCommand("ADMIN_GET_SPECIFIC_ROLES", Connection);
        getCommand.CommandType = CommandType.StoredProcedure;
        getCommand.Parameters.AddWithValue("@userID", userID);


        try
        {
            Connection.Open();
            SqlDataReader reader = getCommand.ExecuteReader();

            while (reader.Read())
            {
                UserRoles role = new UserRoles();
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

public class UserRoles
{
    public int isChecked;
    public int roleID;
    public string roleName;
}