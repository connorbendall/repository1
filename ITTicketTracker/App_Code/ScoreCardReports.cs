/*
 * ScoreCardReports.cs
 * 
 * Created By Kevin Kudnerman September 13 2012
 *      KevinKunderman@hotmail.com
 * 
 * Modified By Marius Tocitu    August 27, 2015
 *  - changed monthly to weekly Scorecard Connection
 * 
 * Modified By Marius Tocitu    Sept 01, 2015
 *  - added get names of current IT members
 *  - added get name of all Issue categories and classes
 * 
 * Modified By Marius Tocitu Sept 03, 2015
 *  - added get number of issues given a It Member name and a class type
 *  
 * 
 * The following page contains all code related to creating,exporting and changing chart types
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public static class ScoreCardReports
{
        #region Database Connection
        private static string connectionString = ConfigurationManager.ConnectionStrings["ISSUESConnectionString"].ConnectionString;

        private static SqlConnection Connection = new SqlConnection(connectionString);

        #endregion
        public static List<double> GetAverageOpenTime()
        {
            List<double> reportData = new List<double>();
            SqlCommand reportCommand = new SqlCommand("SCORECARD_OpenTicketsAverage", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter closedIssues = new SqlParameter("@OpenIssues", SqlDbType.NVarChar, 70);
            closedIssues.Direction = ParameterDirection.Output;
            parameterList.Add(closedIssues);

            #endregion


            reportCommand.Parameters.Add(closedIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string[] values = closedIssues.Value.ToString().Split(',');//data gets returned as , separated values starting with 11 months previous to current month
        
                    foreach (string intVal in values)
                    {
                        if(intVal !="")
                            reportData.Add(Double.Parse(intVal));
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
            return reportData;
        }

        public static List<double> GetAverageCloseTime()
        {
            List<double> reportData = new List<double>();
            SqlCommand reportCommand = new SqlCommand("SCORECARD_ClosedTicketsAverage", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter closedIssues = new SqlParameter("@OpenIssues", SqlDbType.NVarChar, 70);
            closedIssues.Direction = ParameterDirection.Output;
            parameterList.Add(closedIssues);

            #endregion


            reportCommand.Parameters.Add(closedIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string[] values = closedIssues.Value.ToString().Split(',');//data gets returned as , separated values starting with 11 months previous to current month

                foreach (string intVal in values)
                {
                    reportData.Add(Double.Parse(intVal));
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
            return reportData;
        }

        public static List<int> WeekGetNumberOfNewTickets(int week, int year)
        {
            List<int> reportData = new List<int>();

            SqlCommand reportCommand = new SqlCommand("SCORECARD_WeekNewTickets_Temp", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter newIssues = new SqlParameter("@NewIssues", SqlDbType.NVarChar, 70);
            newIssues.Direction = ParameterDirection.Output;
            parameterList.Add(newIssues);
            #endregion

            reportCommand.Parameters.Add("@year", SqlDbType.Int).Value = year;
            reportCommand.Parameters.Add("@week", SqlDbType.Int).Value = week;

            reportCommand.Parameters.Add(newIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;


            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string values = newIssues.Value.ToString(); //data gets returned as , separated values starting with 11 months previous to current month
                reportData.Add(Int32.Parse(values));

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }

            return reportData;
        }
        public static List<int> Get12WeekAgingTickets()
        { 
            List<int> reportData = new List<int>();

            SqlCommand reportCommand = new SqlCommand("SCORECARD_Aging12Week", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter newIssues = new SqlParameter("@Aging", SqlDbType.NVarChar, 70);
            newIssues.Direction = ParameterDirection.Output;
            parameterList.Add(newIssues);
            #endregion

            reportCommand.Parameters.Add(newIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;


            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string[] values = newIssues.Value.ToString().Split(','); //data gets returned as , separated values starting with 11 months previous to current month

                foreach (string intVal in values)
                {
                    reportData.Add(Int32.Parse(intVal));
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

            return reportData;
        
        }

        public static List<int> Get12WeekNewByResource(string Resource)
        {
            List<int> reportData = new List<int>();

            SqlCommand reportCommand = new SqlCommand("SCORECARD_NewTickets12Week", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter newIssues = new SqlParameter("@NewTickets", SqlDbType.NVarChar, 70);
            newIssues.Direction = ParameterDirection.Output;
            parameterList.Add(newIssues);
            #endregion


            reportCommand.Parameters.Add("@Resource", SqlDbType.NVarChar).Value = Resource;

            reportCommand.Parameters.Add(newIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;


            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string[] values = newIssues.Value.ToString().Split(','); //data gets returned as , separated values starting with 11 months previous to current month

                foreach (string intVal in values)
                {
                    reportData.Add(Int32.Parse(intVal));
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

            return reportData;

        }

        public static List<int> Week12GetNumberOfNewTickets()
        {
            List<int> reportData = new List<int>();

            SqlCommand reportCommand = new SqlCommand("SCORECARD_12WeekNewTickets", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter newIssues = new SqlParameter("@NewIssues", SqlDbType.NVarChar, 70);
            newIssues.Direction = ParameterDirection.Output;
            parameterList.Add(newIssues);
            #endregion

            reportCommand.Parameters.Add(newIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;


            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string[] values = newIssues.Value.ToString().Split(','); //data gets returned as , separated values starting with 11 months previous to current month

                foreach (string intVal in values)
                {
                    reportData.Add(Int32.Parse(intVal));
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

            return reportData;
        }

        public static List<int> GetNumberOfNewTickets()
        {
            List<int> reportData = new List<int>();

            SqlCommand reportCommand = new SqlCommand("SCORECARD_NewTickets", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter newIssues = new SqlParameter("@NewIssues", SqlDbType.NVarChar, 70);
            newIssues.Direction = ParameterDirection.Output;
            parameterList.Add(newIssues);
            #endregion

            reportCommand.Parameters.Add(newIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;


            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string[] values = newIssues.Value.ToString().Split(','); //data gets returned as , separated values starting with 11 months previous to current month

                foreach (string intVal in values)
                {
                    reportData.Add(Int32.Parse(intVal));
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

            return reportData;
        }


        public static List<int> WeekGetNumberOfClosedTickets(int week, int year)
        {
            List<int> reportData = new List<int>();
            SqlCommand reportCommand = new SqlCommand("SCORECARD_WeekClosedTickets_Temp", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter closedIssues = new SqlParameter("@ClosedIssues", SqlDbType.NVarChar, 70);
            closedIssues.Direction = ParameterDirection.Output;
            parameterList.Add(closedIssues);

            #endregion

            reportCommand.Parameters.Add("@year", SqlDbType.Int).Value = year;
            reportCommand.Parameters.Add("@week", SqlDbType.Int).Value = week;
            reportCommand.Parameters.Add(closedIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string value = closedIssues.Value.ToString();//data gets returned as , separated values starting with 11 months previous to current month
                reportData.Add(Int32.Parse(value));

             

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return reportData;
        }

        public static List<int> Week12GetNumberOfClosedTickets()
        {
            List<int> reportData = new List<int>();
            SqlCommand reportCommand = new SqlCommand("SCORECARD_12WeekClosedTickets", Connection);
            reportCommand.CommandTimeout = 5000;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter closedIssues = new SqlParameter("@ClosedIssues", SqlDbType.NVarChar, 70);
            closedIssues.Direction = ParameterDirection.Output;
            parameterList.Add(closedIssues);

            #endregion


            reportCommand.Parameters.Add(closedIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string[] values = closedIssues.Value.ToString().Split(',');//data gets returned as , separated values starting with 11 months previous to current month

                foreach (string intVal in values)
                {
                    reportData.Add(Int32.Parse(intVal));
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
            return reportData;
        }

        public static List<int> GetNumberOfClosedTickets()
        {
            List<int> reportData = new List<int>();
            SqlCommand reportCommand = new SqlCommand("SCORECARD_ClosedTickets", Connection);
            reportCommand.CommandTimeout = 5000;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter closedIssues = new SqlParameter("@ClosedIssues", SqlDbType.NVarChar, 70);
            closedIssues.Direction = ParameterDirection.Output;
            parameterList.Add(closedIssues);

            #endregion


            reportCommand.Parameters.Add(closedIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string[] values = closedIssues.Value.ToString().Split(',');//data gets returned as , separated values starting with 11 months previous to current month

                foreach (string intVal in values)
                {
                    reportData.Add(Int32.Parse(intVal));
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
            return reportData;
        }

        public static List<string> Get12WeekLabels()
        {
            List<string> reportData = new List<string>();
            SqlCommand reportCommand = new SqlCommand("SCORECARD_12WeekLabels", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter closedIssues = new SqlParameter("@WeekLabels", SqlDbType.NVarChar, 150);
            closedIssues.Direction = ParameterDirection.Output;
            parameterList.Add(closedIssues);

            #endregion


            reportCommand.Parameters.Add(closedIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string[] values = closedIssues.Value.ToString().Split(',');//data gets returned as , separated values starting with 11 months previous to current month

                foreach (string intVal in values)
                {
                    reportData.Add(intVal);
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
            return reportData;
        }

        public static List<int> WeekGetNumberOfOpenTickets(int week, int year)
        {
            List<int> reportData = new List<int>();
            SqlCommand reportCommand = new SqlCommand("SCORECARD_WeekOpenTickets_Temp", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter openIssues = new SqlParameter("@OpenIssues", SqlDbType.NVarChar, 70);
            openIssues.Direction = ParameterDirection.Output;

            #endregion

            reportCommand.Parameters.Add("@year", SqlDbType.Int).Value = year;
            reportCommand.Parameters.Add("@week", SqlDbType.Int).Value = week;

            reportCommand.Parameters.Add(openIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string value = openIssues.Value.ToString();//data gets returned as , separated values starting with 11 months previous to current month
                reportData.Add(Int32.Parse(value));
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return reportData;
        }

    
        public static List<int> Week12GetNumberOfOpenTickets()
        {
            List<int> reportData = new List<int>();
            SqlCommand reportCommand = new SqlCommand("SCORECARD_12WeekOpenTickets", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter openIssues = new SqlParameter("@OpenIssues", SqlDbType.NVarChar, 70);
            openIssues.Direction = ParameterDirection.Output;

            #endregion


            reportCommand.Parameters.Add(openIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string[] values = openIssues.Value.ToString().Split(',');//data gets returned as , separated values starting with 11 months previous to current month

                foreach (string intVal in values)
                {
                    reportData.Add(Int32.Parse(intVal));
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
            return reportData;
        }

        public static List<int> GetNumberOfOpenTickets()
        {
            List<int> reportData = new List<int>();
            SqlCommand reportCommand = new SqlCommand("SCORECARD_OpenTickets", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter openIssues = new SqlParameter("@OpenIssues", SqlDbType.NVarChar, 70);
            openIssues.Direction = ParameterDirection.Output;

            #endregion


            reportCommand.Parameters.Add(openIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string[] values = openIssues.Value.ToString().Split(',');//data gets returned as , separated values starting with 11 months previous to current month

                foreach (string intVal in values)
                {
                    reportData.Add(Int32.Parse(intVal));
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
            return reportData;
        }

        public static List<int> GetNumberOfUnplannedTickets()
        {
            List<int> reportData = new List<int>();
            SqlCommand reportCommand = new SqlCommand("SCORECARD_Unplanned", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter unplannedIssues = new SqlParameter("@Issues", SqlDbType.NVarChar,400);
            unplannedIssues.Direction = ParameterDirection.Output;
            parameterList.Add(unplannedIssues);
    
            #endregion
            reportCommand.Parameters.Add(unplannedIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string[] values = unplannedIssues.Value.ToString().Split(',');//data gets returned as , separated values starting with 11 months previous to current month

               
                foreach (string intVal in values)
                {
                    reportData.Add(Int32.Parse(intVal));
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
            return reportData;
        }

        public static List<int> GetNumberOfASNIssues()
        {
            List<int> reportData = new List<int>();
            SqlCommand reportCommand = new SqlCommand("SCORECARD_ASN_ISSUES", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter asnIssues = new SqlParameter("@Issues", SqlDbType.NVarChar,400);
            asnIssues.Direction = ParameterDirection.Output;
            parameterList.Add(asnIssues);
            
            #endregion
            reportCommand.Parameters.Add(asnIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string[] values = asnIssues.Value.ToString().Split(',');//data gets returned as , separated values starting with 11 months previous to current month

                foreach (string intVal in values)
                {
                    reportData.Add(Int32.Parse(intVal));
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
            return reportData;
        }


        public static List<int> GetNumberOfRepeat()
        {
            List<int> reportData = new List<int>();

            SqlCommand reportCommand = new SqlCommand("SCORECARD_REPEAT_ISSUES", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter repeateIssue = new SqlParameter("@Issues", SqlDbType.NVarChar,400);
            repeateIssue.Direction = ParameterDirection.Output;
            parameterList.Add(repeateIssue);

            #endregion
            reportCommand.Parameters.Add(repeateIssue);
            reportCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string[] values = repeateIssue.Value.ToString().Split(',');//data gets returned as , separated values starting with 11 months previous to current month

                foreach (string intVal in values)
                {
                    reportData.Add(Int32.Parse(intVal));
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

            return reportData;
        }

        public static List<int> GetNumberOfCustomer()
        {
            List<int> reportData = new List<int>();

            SqlCommand reportCommand = new SqlCommand("SCORECARD_CUSTOMER_ISSUES", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter issues = new SqlParameter("@Issues", SqlDbType.NVarChar,400);
            issues.Direction = ParameterDirection.Output;
            parameterList.Add(issues);
 
            #endregion

            reportCommand.Parameters.Add(issues);
 
            reportCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string[] values = issues.Value.ToString().Split(',');//data gets returned as , separated values starting with 11 months previous to current month

                foreach (string intVal in values)
                {
                    reportData.Add(Int32.Parse(intVal));
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

            return reportData;
        }

        public static List<int> GetRealTime()
        {
            List<int> reportData = new List<int>();
            SqlCommand reportCommand = new SqlCommand("SCORECARD_RealTime", Connection);
            reportCommand.CommandTimeout = 120;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            #region Declare Output values
            SqlParameter closedIssues = new SqlParameter("@Issues", SqlDbType.NVarChar, 200);
            closedIssues.Direction = ParameterDirection.Output;
            parameterList.Add(closedIssues);

            #endregion


            reportCommand.Parameters.Add(closedIssues);
            reportCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                Connection.Open();
                reportCommand.ExecuteNonQuery();

                string[] values = closedIssues.Value.ToString().Split(',');//data gets returned as , separated values starting with 11 months previous to current month

                foreach (string intVal in values)
                {
                    reportData.Add(Int32.Parse(intVal));
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
            return reportData;
        }


    public static List<double> GetSixMonthTrendOpen()
    {
        List<double> reportData = new List<double>();
        SqlCommand reportCommand = new SqlCommand("SCORECARD_SixMonthTrendOpen", Connection);
        reportCommand.CommandTimeout = 120;
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region Declare Output values
        SqlParameter closedIssues = new SqlParameter("@Issues", SqlDbType.NVarChar, 200);
        closedIssues.Direction = ParameterDirection.Output;
        parameterList.Add(closedIssues);

        #endregion


        reportCommand.Parameters.Add(closedIssues);
        reportCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            Connection.Open();
            reportCommand.ExecuteNonQuery();

           string[] values = closedIssues.Value.ToString().Split(',');//data gets returned as , separated values starting with 11 months previous to current month

            foreach (string intVal in values)
            {
                reportData.Add(Double.Parse(intVal));
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
        return reportData;
    }

   

    public static List<double> GetSixMonthTrendClosed()
    {
        List<double> reportData = new List<double>();
        SqlCommand reportCommand = new SqlCommand("SCORECARD_SixMonthTrendClosed", Connection);
        reportCommand.CommandTimeout = 120;
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region Declare Output values
        SqlParameter closedIssues = new SqlParameter("@Issues", SqlDbType.NVarChar, 200);
        closedIssues.Direction = ParameterDirection.Output;
        parameterList.Add(closedIssues);

        #endregion


        reportCommand.Parameters.Add(closedIssues);
        reportCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            Connection.Open();
            
            reportCommand.ExecuteNonQuery();

            string[] values = closedIssues.Value.ToString().Split(',');//data gets returned as , separated values starting with 11 months previous to current month

            foreach (string intVal in values)
            {
                reportData.Add(Double.Parse(intVal));
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
        return reportData;
    }


    public static List<double> GetSixMonthTrendNew()
    {
        List<double> reportData = new List<double>();
        SqlCommand reportCommand = new SqlCommand("SCORECARD_SixMonthTrendNew", Connection);
        reportCommand.CommandTimeout = 120;
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region Declare Output values
        SqlParameter closedIssues = new SqlParameter("@Issues", SqlDbType.NVarChar, 200);
        closedIssues.Direction = ParameterDirection.Output;
        parameterList.Add(closedIssues);

        #endregion


        reportCommand.Parameters.Add(closedIssues);
        reportCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            Connection.Open();
            reportCommand.ExecuteNonQuery();

            string[] values = closedIssues.Value.ToString().Split(',');//data gets returned as , separated values starting with 11 months previous to current month

            foreach (string intVal in values)
            {
                reportData.Add(Double.Parse(intVal));
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
        return reportData;
    }


    public static List<int> GetTotalTickets()
    {
        List<int> reportData = new List<int>();
        SqlCommand reportCommand = new SqlCommand("SCORECARD_TicketAging", Connection);
        reportCommand.CommandTimeout = 120;
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region Declare Output values
        SqlParameter closedIssues = new SqlParameter("@Issues", SqlDbType.NVarChar, 200);
        closedIssues.Direction = ParameterDirection.Output;
        parameterList.Add(closedIssues);

        #endregion


        reportCommand.Parameters.Add(closedIssues);
        reportCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            Connection.Open();
            reportCommand.ExecuteNonQuery();

            string[] values = closedIssues.Value.ToString().Split(',');//data gets returned as @Current,@OneToSeven, @SevenToThirty, @ThirtyToSixty,@SixtyToNinety, @OlderThenNinety

            foreach (string intVal in values)
            {
                reportData.Add(Int32.Parse(intVal));
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
        return reportData;
    }

    //get list of current IT Members that have tickets assigned to in the current week 
    public static List<string> GetITMembers()
    {
        List<string> reportData = new List<string>();
        SqlCommand reportCommand = new SqlCommand("SCORECARD_WeekITMembers", Connection);
        reportCommand.CommandTimeout = 120;
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region Declare Output values
        SqlParameter closedIssues = new SqlParameter("@Members", SqlDbType.NVarChar, 150);
        
        closedIssues.Direction = ParameterDirection.Output;
        parameterList.Add(closedIssues);

        #endregion


        reportCommand.Parameters.Add(closedIssues);
        reportCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            Connection.Open();
            reportCommand.ExecuteNonQuery();

            string[] values = closedIssues.Value.ToString().Split(',');

            foreach (string intVal in values)
            {
                reportData.Add(intVal);
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
         
        return reportData;
    }

    public static List<string> GetIssueClass()
    {
        List<string> reportData = new List<string>();
        SqlCommand reportCommand = new SqlCommand("SCORECARD_IssueClassType", Connection);
        reportCommand.CommandTimeout = 120;
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region Declare Output values
        SqlParameter closedIssues = new SqlParameter("@IssueClass", SqlDbType.NVarChar, 150);

        closedIssues.Direction = ParameterDirection.Output;
        parameterList.Add(closedIssues);

        #endregion


        reportCommand.Parameters.Add(closedIssues);
        reportCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            Connection.Open();
            reportCommand.ExecuteNonQuery();

            string[] values = closedIssues.Value.ToString().Split(',');

            foreach (string intVal in values)
            {
                reportData.Add(intVal);
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

        return reportData;
    }

    public static List<string> GetIssueCategory()
    {
        List<string> reportData = new List<string>();
        SqlCommand reportCommand = new SqlCommand("SCORECARD_IssueCategory", Connection);
        reportCommand.CommandTimeout = 120;
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region Declare Output values
        SqlParameter closedIssues = new SqlParameter("@IssueCategory", SqlDbType.NVarChar, 150);

        closedIssues.Direction = ParameterDirection.Output;
        parameterList.Add(closedIssues);

        #endregion


        reportCommand.Parameters.Add(closedIssues);
        reportCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            Connection.Open();
            reportCommand.ExecuteNonQuery();

            string[] values = closedIssues.Value.ToString().Split(',');

            foreach (string intVal in values)
            {
                reportData.Add(intVal);
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

        return reportData;
    }

    public static double GetNumberOfClasses(String member, String classType, int week, int year)
    {
        double reportData = new double();
        SqlCommand reportCommand = new SqlCommand("GetTicketsByClass", Connection);
        reportCommand.CommandTimeout = 120;
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region Declare Output values
        SqlParameter closedIssues = new SqlParameter("@typeNumber", SqlDbType.NVarChar, 200);
        closedIssues.Direction = ParameterDirection.Output;
        parameterList.Add(closedIssues);

        #endregion

        reportCommand.Parameters.Add("@member", SqlDbType.NVarChar, 20).Value = member;
        reportCommand.Parameters.Add("@week", SqlDbType.Int).Value = week;
        reportCommand.Parameters.Add("@year", SqlDbType.Int).Value = year;
        reportCommand.Parameters.Add("@type", SqlDbType.NVarChar, 20).Value = classType;
        reportCommand.Parameters.Add(closedIssues);
        reportCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            Connection.Open();
            reportCommand.ExecuteNonQuery();

            //string[] values = closedIssues.Value.ToString().Split(',');//data gets returned as @Current,@OneToSeven, @SevenToThirty, @ThirtyToSixty,@SixtyToNinety, @OlderThenNinety
            string value = closedIssues.Value.ToString();
            

                reportData = (Double.Parse(value));
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Connection.Close();
        }
        return reportData;
    }


    public static double GetMonthNumberOfClasses(String member, String classType, int month, int year)
    {
        double reportData = new double();
        SqlCommand reportCommand = new SqlCommand("MonthGetTicketsByClass", Connection);
        reportCommand.CommandTimeout = 120;
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region Declare Output values
        SqlParameter closedIssues = new SqlParameter("@typeNumber", SqlDbType.NVarChar, 200);
        closedIssues.Direction = ParameterDirection.Output;
        parameterList.Add(closedIssues);

        #endregion

        reportCommand.Parameters.Add("@member", SqlDbType.NVarChar, 20).Value = member;
        reportCommand.Parameters.Add("@month", SqlDbType.Int).Value = month;
        reportCommand.Parameters.Add("@year", SqlDbType.Int).Value = year;
        reportCommand.Parameters.Add("@type", SqlDbType.NVarChar, 20).Value = classType;
        reportCommand.Parameters.Add(closedIssues);
        reportCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            Connection.Open();
            reportCommand.ExecuteNonQuery();

            //string[] values = closedIssues.Value.ToString().Split(',');//data gets returned as @Current,@OneToSeven, @SevenToThirty, @ThirtyToSixty,@SixtyToNinety, @OlderThenNinety
            string value = closedIssues.Value.ToString();


            reportData = (Double.Parse(value));


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Connection.Close();
        }
        return reportData;
    }
    /// <summary>
    /// input IT member, category and a valid class type and get the number of Tickets
    /// </summary>
    /// <param name="member"></param>
    /// <param name="categoryType"></param>
    /// <returns> number of tickets as string </returns>
    public static double GetNumberOfCategory(String member, String classType, String categoryType, int week, int year)
    {
        double reportData = new double();
        SqlCommand reportCommand = new SqlCommand("GetTicketsByCategory", Connection);
        reportCommand.CommandTimeout = 120;
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region Declare Output values
        SqlParameter closedIssues = new SqlParameter("@typeNumber", SqlDbType.NVarChar, 200);
        closedIssues.Direction = ParameterDirection.Output;
        parameterList.Add(closedIssues);

        #endregion

        reportCommand.Parameters.Add("@member", SqlDbType.NVarChar, 20).Value = member;
        reportCommand.Parameters.Add("@class", SqlDbType.NVarChar, 20).Value = classType;
        reportCommand.Parameters.Add("@year", SqlDbType.Int).Value = year;
        reportCommand.Parameters.Add("@week", SqlDbType.Int).Value = week;
        reportCommand.Parameters.Add("@type", SqlDbType.NVarChar, 20).Value = categoryType;
        reportCommand.Parameters.Add(closedIssues);
        reportCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            Connection.Open();
            reportCommand.ExecuteNonQuery();

            string value = closedIssues.Value.ToString();

            reportData = (Double.Parse(value));


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Connection.Close();
        }
        return reportData;
    }

     public static double GetMonthNumberOfCategory(String member, String classType, String categoryType, int month, int year)
    {
        double reportData = new double();
        SqlCommand reportCommand = new SqlCommand("MonthGetTicketsByCategory", Connection);
        reportCommand.CommandTimeout = 120;
        List<SqlParameter> parameterList = new List<SqlParameter>();

        #region Declare Output values
        SqlParameter closedIssues = new SqlParameter("@typeNumber", SqlDbType.NVarChar, 200);
        closedIssues.Direction = ParameterDirection.Output;
        parameterList.Add(closedIssues);

        #endregion

        reportCommand.Parameters.Add("@member", SqlDbType.NVarChar, 20).Value = member;
        reportCommand.Parameters.Add("@class", SqlDbType.NVarChar, 20).Value = classType;
        reportCommand.Parameters.Add("@year", SqlDbType.Int).Value = year;
        reportCommand.Parameters.Add("@month", SqlDbType.Int).Value = month;
        reportCommand.Parameters.Add("@type", SqlDbType.NVarChar, 20).Value = categoryType;
        reportCommand.Parameters.Add(closedIssues);
        reportCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            Connection.Open();
            reportCommand.ExecuteNonQuery();

            string value = closedIssues.Value.ToString();

            reportData = (Double.Parse(value));


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Connection.Close();
        }
        return reportData;
    }

     public static List<double> GetBacklog_Hours(int week, int year)
     {


         List<double> reportData = new List<double>();

         SqlCommand reportCommand = new SqlCommand("SCORECARD_Backlog_Hours", Connection);
         reportCommand.CommandTimeout = 120;
         List<SqlParameter> parameterList = new List<SqlParameter>();

         #region Declare Output values

         SqlParameter closedIssues = new SqlParameter("@Backlog", SqlDbType.NVarChar, 200);
         //SqlParameter closedIssues2 = new SqlParameter("@Names", SqlDbType.NVarChar, 200);
         closedIssues.Direction = ParameterDirection.Output;
         //closedIssues2.Direction = ParameterDirection.Output;
         parameterList.Add(closedIssues);
         //parameterList.Add(closedIssues2);

         #endregion

         reportCommand.Parameters.Add("@yearnum", SqlDbType.Int).Value = year;
         reportCommand.Parameters.Add("@weeknum", SqlDbType.Int).Value = week;
         reportCommand.Parameters.Add(closedIssues);
         // reportCommand.Parameters.Add(closedIssues2);
         reportCommand.CommandType = CommandType.StoredProcedure;

         try
         {
             Connection.Open();
             reportCommand.ExecuteNonQuery();

             if (closedIssues.Value.ToString() != "")
             {
                 string[] values = closedIssues.Value.ToString().Split(',');//data gets returned as @Current,@OneToSeven, @SevenToThirty, @ThirtyToSixty,@SixtyToNinety, @OlderThenNinety

                 foreach (string intVal in values)
                 {
                     reportData.Add(Double.Parse(intVal));
                 }
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

         return reportData;
     }

     public static List<string> GetBacklog_Names(int week, int year)
     {
         List<string> reportData = new List<string>();
         SqlCommand reportCommand = new SqlCommand("SCORECARD_Backlog_Names", Connection);
         reportCommand.CommandTimeout = 120;
         List<SqlParameter> parameterList = new List<SqlParameter>();

         #region Declare Output values
         SqlParameter closedIssues = new SqlParameter("@Names", SqlDbType.NVarChar, 200);
         
         closedIssues.Direction = ParameterDirection.Output;
         
         parameterList.Add(closedIssues);
         
         #endregion

         reportCommand.Parameters.Add("@yearnum", SqlDbType.Int).Value = year;
         reportCommand.Parameters.Add("@weeknum", SqlDbType.Int).Value = week;
         reportCommand.Parameters.Add(closedIssues);
        
         reportCommand.CommandType = CommandType.StoredProcedure;

         try
         {
             Connection.Open();
             reportCommand.ExecuteNonQuery();


             string[] values = closedIssues.Value.ToString().Split(',');//data gets returned as @Current,@OneToSeven, @SevenToThirty, @ThirtyToSixty,@SixtyToNinety, @OlderThenNinety

             foreach (string intVal in values)
             {
                 reportData.Add((intVal));
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
         return reportData;
     }

     public static List<int> GetBacklog_Year()
     {
         List<int> reportData = new List<int>();

         SqlCommand reportCommand = new SqlCommand("SCORECARD_Backlog_Year", Connection);
         reportCommand.CommandTimeout = 120;
         List<SqlParameter> parameterList = new List<SqlParameter>();

         #region Declare Output values
         SqlParameter newIssues = new SqlParameter("@Backlog_Year", SqlDbType.NVarChar, 70);
         newIssues.Direction = ParameterDirection.Output;
         parameterList.Add(newIssues);
         #endregion

         reportCommand.Parameters.Add(newIssues);
         reportCommand.CommandType = CommandType.StoredProcedure;


         try
         {
             Connection.Open();
             reportCommand.ExecuteNonQuery();

             string[] values = newIssues.Value.ToString().Split(','); //data gets returned as , separated values starting with 11 months previous to current month

             foreach (string intVal in values)
             {
                 reportData.Add(Int32.Parse(intVal));
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

         return reportData;

     }

     public static List<int> GetBacklog_Week()
     {
         List<int> reportData = new List<int>();

         SqlCommand reportCommand = new SqlCommand("SCORECARD_Backlog_Week", Connection);
         reportCommand.CommandTimeout = 120;
         List<SqlParameter> parameterList = new List<SqlParameter>();

         #region Declare Output values
         SqlParameter newIssues = new SqlParameter("@Backlog_Week", SqlDbType.NVarChar, 70);
         newIssues.Direction = ParameterDirection.Output;
         parameterList.Add(newIssues);
         #endregion

         reportCommand.Parameters.Add(newIssues);
         reportCommand.CommandType = CommandType.StoredProcedure;


         try
         {
             Connection.Open();
             reportCommand.ExecuteNonQuery();

             string[] values = newIssues.Value.ToString().Split(','); //data gets returned as , separated values starting with 11 months previous to current month

             foreach (string intVal in values)
             {
                 reportData.Add(Int32.Parse(intVal));
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

         return reportData;

     }
}
