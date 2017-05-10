using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for SubSystemDAL
/// </summary>
public class SubSystemDAL
{
    #region Database Connection
    private static string connectionString = ConfigurationManager.ConnectionStrings["ISSUESConnectionString"].ConnectionString;

    private static SqlConnection Connection = new SqlConnection(connectionString);
    #endregion


	public List<ListItem> GetSubSystem(int systemID)
	{

        List<ListItem> subSustemList = new List<ListItem>();  

        SqlCommand getCommand = new SqlCommand("[getSubSystem]", Connection);
        getCommand.CommandType = CommandType.StoredProcedure;
        getCommand.Parameters.AddWithValue("@SystemID", systemID);


        try
        {
            Connection.Open();
            SqlDataReader reader = getCommand.ExecuteReader();

            while (reader.Read())
            {
                ListItem subSystem = new ListItem();
                decimal value = !reader.IsDBNull(1) ? reader.GetDecimal(1) : -1;
                subSystem.Value = value.ToString();
                subSystem.Text = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;

                subSustemList.Add(subSystem);
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

        return subSustemList;
	}
}