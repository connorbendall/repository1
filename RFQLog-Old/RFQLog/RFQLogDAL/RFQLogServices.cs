// Decompiled with JetBrains decompiler
// Type: RFQLogDAL.RFQLogServices
// Assembly: RFQLogDAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01B3F331-73BD-4DBB-8BBC-96E4C9AEE7C8
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLogDAL.dll

using RFQLogDAL.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading.Tasks;

namespace RFQLogDAL
{
  public class RFQLogServices
  {
    private static string connectionString = ConfigurationManager.ConnectionStrings["RFQLogDB"].ConnectionString;

    public async Task<int> Create(RFQ_LogDTO rfq)
    {
      int newRFQ_ID = -1;
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("CreateRFQLog"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@RequestType", SqlDbType.NVarChar).Value = (object) rfq.RequestType;
            sqlCommand.Parameters.Add("@RequesterName", SqlDbType.NVarChar).Value = (object) rfq.RequesterName;
            sqlCommand.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = (object) rfq.CustomerName;
            sqlCommand.Parameters.Add("@Division", SqlDbType.NVarChar).Value = (object) rfq.Division;
            sqlCommand.Parameters.Add("@Reason", SqlDbType.NVarChar).Value = (object) rfq.Reason;
            sqlCommand.Parameters.Add("@Program", SqlDbType.NVarChar).Value = (object) rfq.Program;
            sqlCommand.Parameters.Add("@SOPDate", SqlDbType.Date).Value = (object) rfq.SOPDate;
            sqlCommand.Parameters.Add("@PPAPDate", SqlDbType.Date).Value = (object) rfq.PPAPDate;
            sqlCommand.Parameters.Add("@PartNumber", SqlDbType.NVarChar).Value = (object) rfq.PartNumber;
            sqlCommand.Parameters.Add("@DrawingNumber", SqlDbType.NVarChar).Value = (object) rfq.DrawingNumber;
            sqlCommand.Parameters.Add("@DrawingDate", SqlDbType.Date).Value = (object) rfq.DrawingDate;
            sqlCommand.Parameters.Add("@EngineeringLevel", SqlDbType.NVarChar).Value = (object) rfq.EngineeringLevel;
            sqlCommand.Parameters.Add("@EstimatedAnnualVolume", SqlDbType.BigInt).Value = (object) rfq.EstAnnualVolume;
            sqlCommand.Parameters.Add("@QuoteDueDate", SqlDbType.Date).Value = (object) rfq.QuoteDueDate;
            sqlCommand.Parameters.Add("@Status", SqlDbType.NVarChar).Value = (object) rfq.Status;
            SqlParameter id = new SqlParameter("@RFQ_ID", SqlDbType.Int);
            id.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(id);
            await sqlConnection.OpenAsync();
            IAsyncResult result = sqlCommand.BeginExecuteNonQuery();
            do
              ;
            while (!result.IsCompleted);
            sqlCommand.EndExecuteNonQuery(result);
            newRFQ_ID = int.Parse(id.Value.ToString());
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      return newRFQ_ID;
    }

    public async Task<long> Update(RFQ_LogDTO updateRFQ)
    {
      long rtnVal = -1;
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("UpdateRFQLog"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@RFQ_ID", SqlDbType.Int).Value = (object) updateRFQ.RFQLogNumber;
            sqlCommand.Parameters.Add("@RequestType", SqlDbType.NVarChar).Value = (object) updateRFQ.RequestType;
            sqlCommand.Parameters.Add("@RequesterName", SqlDbType.NVarChar).Value = (object) updateRFQ.RequesterName;
            sqlCommand.Parameters.Add("@RequesterEmail", SqlDbType.NVarChar).Value = (object) updateRFQ.ReqesterEmail;
            sqlCommand.Parameters.Add("@PurchasingEmail", SqlDbType.NVarChar).Value = (object) updateRFQ.PurchasingEmail;
            sqlCommand.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = (object) updateRFQ.CustomerName;
            sqlCommand.Parameters.Add("@Division", SqlDbType.NVarChar).Value = (object) updateRFQ.Division;
            sqlCommand.Parameters.Add("@Reason", SqlDbType.NVarChar).Value = (object) updateRFQ.Reason;
            sqlCommand.Parameters.Add("@Program", SqlDbType.NVarChar).Value = (object) updateRFQ.Program;
            sqlCommand.Parameters.Add("@SOPDate", SqlDbType.Date).Value = (object) updateRFQ.SOPDate;
            sqlCommand.Parameters.Add("@PPAPDate", SqlDbType.Date).Value = (object) updateRFQ.PPAPDate;
            sqlCommand.Parameters.Add("@PartNumber", SqlDbType.NVarChar).Value = (object) updateRFQ.PartNumber;
            sqlCommand.Parameters.Add("@DrawingNumber", SqlDbType.NVarChar).Value = (object) updateRFQ.DrawingNumber;
            sqlCommand.Parameters.Add("@DrawingDate", SqlDbType.Date).Value = (object) updateRFQ.DrawingDate;
            sqlCommand.Parameters.Add("@EngineeringLevel", SqlDbType.NVarChar).Value = (object) updateRFQ.EngineeringLevel;
            sqlCommand.Parameters.Add("@EstimatedAnnualVolume", SqlDbType.BigInt).Value = (object) updateRFQ.EstAnnualVolume;
            sqlCommand.Parameters.Add("@QuoteDueDate", SqlDbType.Date).Value = (object) updateRFQ.QuoteDueDate;
            sqlCommand.Parameters.Add("@Status", SqlDbType.NVarChar).Value = (object) updateRFQ.Status;
            await sqlConnection.OpenAsync();
            rtnVal = (long) sqlCommand.ExecuteNonQuery();
            if (rtnVal == 1L)
              rtnVal = (long) updateRFQ.RFQLogNumber;
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      return rtnVal;
    }

    public async Task<RFQ_LogDTO> GetByID(long id)
    {
      RFQ_LogDTO rfq = new RFQ_LogDTO();
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetRFQLogByID"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@RFQ_ID", SqlDbType.Int).Value = (object) id;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              while (sqlDataReader.Read())
              {
                rfq.RFQLogNumber = (int) (Decimal) sqlDataReader.GetSqlDecimal(sqlDataReader.GetOrdinal("RFQ Log Number"));
                int ordinal1 = sqlDataReader.GetOrdinal("Customer Name");
                rfq.CustomerName = sqlDataReader.IsDBNull(ordinal1) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Customer Name"));
                int ordinal2 = sqlDataReader.GetOrdinal("Division");
                rfq.Division = sqlDataReader.IsDBNull(ordinal2) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Division"));
                int ordinal3 = sqlDataReader.GetOrdinal("Reason For Quote");
                rfq.Reason = sqlDataReader.IsDBNull(ordinal3) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Reason For Quote"));
                int ordinal4 = sqlDataReader.GetOrdinal("Program");
                rfq.Program = sqlDataReader.IsDBNull(ordinal4) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Program"));
                int ordinal5 = sqlDataReader.GetOrdinal("SOP Date");
                if (!sqlDataReader.IsDBNull(ordinal5))
                  rfq.SOPDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("SOP Date")));
                int ordinal6 = sqlDataReader.GetOrdinal("PPAP Date");
                if (!sqlDataReader.IsDBNull(ordinal6))
                  rfq.PPAPDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("PPAP Date")));
                int ordinal7 = sqlDataReader.GetOrdinal("Part Number");
                rfq.PartNumber = sqlDataReader.IsDBNull(ordinal7) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Part Number"));
                int ordinal8 = sqlDataReader.GetOrdinal("Drawing Number");
                rfq.DrawingNumber = sqlDataReader.IsDBNull(ordinal8) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Drawing Number"));
                int ordinal9 = sqlDataReader.GetOrdinal("Drawing Date");
                if (!sqlDataReader.IsDBNull(ordinal9))
                  rfq.DrawingDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Drawing Date")));
                int ordinal10 = sqlDataReader.GetOrdinal("Engineering Level");
                rfq.EngineeringLevel = sqlDataReader.IsDBNull(ordinal10) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Engineering Level"));
                int ordinal11 = sqlDataReader.GetOrdinal("Estimated Annual Volume");
                rfq.EstAnnualVolume = sqlDataReader.IsDBNull(ordinal11) ? 0L : sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Estimated Annual Volume"));
                int ordinal12 = sqlDataReader.GetOrdinal("Quote Request Date");
                if (!sqlDataReader.IsDBNull(ordinal12))
                  rfq.QuoteRequestDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Quote Request Date")));
                int ordinal13 = sqlDataReader.GetOrdinal("Quote Due Date");
                if (!sqlDataReader.IsDBNull(ordinal13))
                  rfq.QuoteDueDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Quote Due Date")));
                int ordinal14 = sqlDataReader.GetOrdinal("Status");
                rfq.Status = sqlDataReader.IsDBNull(ordinal14) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Status"));
                int ordinal15 = sqlDataReader.GetOrdinal("Closed Date");
                if (!sqlDataReader.IsDBNull(ordinal15))
                  rfq.ClosedDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Closed Date")));
                int ordinal16 = sqlDataReader.GetOrdinal("Requester Name");
                rfq.RequesterName = sqlDataReader.IsDBNull(ordinal16) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Requester Name"));
                int ordinal17 = sqlDataReader.GetOrdinal("Request Type");
                rfq.RequestType = sqlDataReader.IsDBNull(ordinal17) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Request Type"));
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      return rfq;
    }

    public async Task<List<RFQ_LogDTO>> GetAll()
    {
      List<RFQ_LogDTO> rfqList = new List<RFQ_LogDTO>();
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetAllRFQLogs"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              while (sqlDataReader.Read())
              {
                RFQ_LogDTO rfqLogDto = new RFQ_LogDTO();
                rfqLogDto.RFQLogNumber = (int) (Decimal) sqlDataReader.GetSqlDecimal(sqlDataReader.GetOrdinal("RFQ Log Number"));
                int ordinal1 = sqlDataReader.GetOrdinal("Customer Name");
                rfqLogDto.CustomerName = sqlDataReader.IsDBNull(ordinal1) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Customer Name"));
                int ordinal2 = sqlDataReader.GetOrdinal("Division");
                rfqLogDto.Division = sqlDataReader.IsDBNull(ordinal2) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Division"));
                int ordinal3 = sqlDataReader.GetOrdinal("Reason For Quote");
                rfqLogDto.Reason = sqlDataReader.IsDBNull(ordinal3) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Reason For Quote"));
                int ordinal4 = sqlDataReader.GetOrdinal("Program");
                rfqLogDto.Program = sqlDataReader.IsDBNull(ordinal4) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Program"));
                int ordinal5 = sqlDataReader.GetOrdinal("SOP Date");
                if (!sqlDataReader.IsDBNull(ordinal5))
                  rfqLogDto.SOPDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("SOP Date")));
                int ordinal6 = sqlDataReader.GetOrdinal("PPAP Date");
                if (!sqlDataReader.IsDBNull(ordinal6))
                  rfqLogDto.PPAPDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("PPAP Date")));
                int ordinal7 = sqlDataReader.GetOrdinal("Part Number");
                rfqLogDto.PartNumber = sqlDataReader.IsDBNull(ordinal7) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Part Number"));
                int ordinal8 = sqlDataReader.GetOrdinal("Drawing Number");
                rfqLogDto.DrawingNumber = sqlDataReader.IsDBNull(ordinal8) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Drawing Number"));
                int ordinal9 = sqlDataReader.GetOrdinal("Drawing Date");
                if (!sqlDataReader.IsDBNull(ordinal9))
                  rfqLogDto.DrawingDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Drawing Date")));
                int ordinal10 = sqlDataReader.GetOrdinal("Engineering Level");
                rfqLogDto.EngineeringLevel = sqlDataReader.IsDBNull(ordinal10) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Engineering Level"));
                int ordinal11 = sqlDataReader.GetOrdinal("Estimated Annual Volume");
                rfqLogDto.EstAnnualVolume = sqlDataReader.IsDBNull(ordinal11) ? 0L : sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Estimated Annual Volume"));
                int ordinal12 = sqlDataReader.GetOrdinal("Quote Request Date");
                if (!sqlDataReader.IsDBNull(ordinal12))
                  rfqLogDto.QuoteRequestDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Quote Request Date")));
                int ordinal13 = sqlDataReader.GetOrdinal("Quote Due Date");
                if (!sqlDataReader.IsDBNull(ordinal13))
                  rfqLogDto.QuoteDueDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Quote Due Date")));
                int ordinal14 = sqlDataReader.GetOrdinal("Status");
                rfqLogDto.Status = sqlDataReader.IsDBNull(ordinal14) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Status"));
                int ordinal15 = sqlDataReader.GetOrdinal("Closed Date");
                if (!sqlDataReader.IsDBNull(ordinal15))
                  rfqLogDto.ClosedDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Closed Date")));
                int ordinal16 = sqlDataReader.GetOrdinal("Requester Name");
                rfqLogDto.RequesterName = sqlDataReader.IsDBNull(ordinal16) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Requester Name"));
                int ordinal17 = sqlDataReader.GetOrdinal("Request Type");
                rfqLogDto.RequestType = sqlDataReader.IsDBNull(ordinal17) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Request Type"));
                rfqList.Add(rfqLogDto);
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      return rfqList;
    }

    public async Task<List<RFQ_LogDTO>> CustomSearch(RFQ_LogDTO searchCriteria)
    {
      List<RFQ_LogDTO> results = new List<RFQ_LogDTO>();
      bool insertAND = false;
      string query = "SELECT * FROM [dbo].[RFQLog]";
      if (searchCriteria.RequesterName != null || searchCriteria.CustomerName != null || (searchCriteria.Division != null || searchCriteria.RequestType != "ALL") || searchCriteria.Status != "ALL")
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003Cquery\u003E5__1d += " WHERE ";
        if (searchCriteria.RequesterName != null)
        {
          insertAND = true;
          // ISSUE: variable of a reference type
          RFQLogServices.\u003CCustomSearch\u003Ed__1a& local = this;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          string str = (^local).\u003Cquery\u003E5__1d + "[Requester Name] = '" + searchCriteria.RequesterName + "'";
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^local).\u003Cquery\u003E5__1d = str;
        }
        if (searchCriteria.CustomerName != null)
        {
          if (insertAND)
          {
            // ISSUE: explicit reference operation
            // ISSUE: reference to a compiler-generated field
            (^this).\u003Cquery\u003E5__1d += " AND ";
          }
          // ISSUE: variable of a reference type
          RFQLogServices.\u003CCustomSearch\u003Ed__1a& local = this;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          string str = (^local).\u003Cquery\u003E5__1d + "[Customer Name] = '" + searchCriteria.CustomerName + "'";
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^local).\u003Cquery\u003E5__1d = str;
          insertAND = true;
        }
        if (searchCriteria.Division != null)
        {
          if (insertAND)
          {
            // ISSUE: explicit reference operation
            // ISSUE: reference to a compiler-generated field
            (^this).\u003Cquery\u003E5__1d += " AND ";
          }
          // ISSUE: variable of a reference type
          RFQLogServices.\u003CCustomSearch\u003Ed__1a& local = this;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          string str = (^local).\u003Cquery\u003E5__1d + "[Division] = '" + searchCriteria.Division + "'";
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^local).\u003Cquery\u003E5__1d = str;
          insertAND = true;
        }
        if (searchCriteria.Status != "ALL")
        {
          if (insertAND)
          {
            // ISSUE: explicit reference operation
            // ISSUE: reference to a compiler-generated field
            (^this).\u003Cquery\u003E5__1d += " AND ";
          }
          // ISSUE: variable of a reference type
          RFQLogServices.\u003CCustomSearch\u003Ed__1a& local = this;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          string str = (^local).\u003Cquery\u003E5__1d + "[Status] = '" + searchCriteria.Status + "'";
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^local).\u003Cquery\u003E5__1d = str;
          insertAND = true;
        }
        if (searchCriteria.RequestType != "ALL")
        {
          if (insertAND)
          {
            // ISSUE: explicit reference operation
            // ISSUE: reference to a compiler-generated field
            (^this).\u003Cquery\u003E5__1d += " AND ";
          }
          // ISSUE: variable of a reference type
          RFQLogServices.\u003CCustomSearch\u003Ed__1a& local = this;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          string str = (^local).\u003Cquery\u003E5__1d + "[Request Type] = '" + searchCriteria.RequestType + "'";
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^local).\u003Cquery\u003E5__1d = str;
          insertAND = true;
        }
      }
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand(query))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              while (sqlDataReader.Read())
              {
                RFQ_LogDTO rfqLogDto = new RFQ_LogDTO();
                rfqLogDto.RFQLogNumber = (int) (Decimal) sqlDataReader.GetSqlDecimal(sqlDataReader.GetOrdinal("RFQ Log Number"));
                int ordinal1 = sqlDataReader.GetOrdinal("Customer Name");
                rfqLogDto.CustomerName = sqlDataReader.IsDBNull(ordinal1) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Customer Name"));
                int ordinal2 = sqlDataReader.GetOrdinal("Division");
                rfqLogDto.Division = sqlDataReader.IsDBNull(ordinal2) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Division"));
                int ordinal3 = sqlDataReader.GetOrdinal("Reason For Quote");
                rfqLogDto.Reason = sqlDataReader.IsDBNull(ordinal3) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Reason For Quote"));
                int ordinal4 = sqlDataReader.GetOrdinal("Program");
                rfqLogDto.Program = sqlDataReader.IsDBNull(ordinal4) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Program"));
                int ordinal5 = sqlDataReader.GetOrdinal("SOP Date");
                if (!sqlDataReader.IsDBNull(ordinal5))
                  rfqLogDto.SOPDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("SOP Date")));
                int ordinal6 = sqlDataReader.GetOrdinal("PPAP Date");
                if (!sqlDataReader.IsDBNull(ordinal6))
                  rfqLogDto.PPAPDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("PPAP Date")));
                int ordinal7 = sqlDataReader.GetOrdinal("Part Number");
                rfqLogDto.PartNumber = sqlDataReader.IsDBNull(ordinal7) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Part Number"));
                int ordinal8 = sqlDataReader.GetOrdinal("Drawing Number");
                rfqLogDto.DrawingNumber = sqlDataReader.IsDBNull(ordinal8) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Drawing Number"));
                int ordinal9 = sqlDataReader.GetOrdinal("Drawing Date");
                if (!sqlDataReader.IsDBNull(ordinal9))
                  rfqLogDto.DrawingDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Drawing Date")));
                int ordinal10 = sqlDataReader.GetOrdinal("Engineering Level");
                rfqLogDto.EngineeringLevel = sqlDataReader.IsDBNull(ordinal10) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Engineering Level"));
                int ordinal11 = sqlDataReader.GetOrdinal("Estimated Annual Volume");
                rfqLogDto.EstAnnualVolume = sqlDataReader.IsDBNull(ordinal11) ? 0L : sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Estimated Annual Volume"));
                int ordinal12 = sqlDataReader.GetOrdinal("Quote Request Date");
                if (!sqlDataReader.IsDBNull(ordinal12))
                  rfqLogDto.QuoteRequestDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Quote Request Date")));
                int ordinal13 = sqlDataReader.GetOrdinal("Quote Due Date");
                if (!sqlDataReader.IsDBNull(ordinal13))
                  rfqLogDto.QuoteDueDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Quote Due Date")));
                int ordinal14 = sqlDataReader.GetOrdinal("Status");
                rfqLogDto.Status = sqlDataReader.IsDBNull(ordinal14) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Status"));
                int ordinal15 = sqlDataReader.GetOrdinal("Closed Date");
                if (!sqlDataReader.IsDBNull(ordinal15))
                  rfqLogDto.ClosedDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Closed Date")));
                int ordinal16 = sqlDataReader.GetOrdinal("Requester Name");
                rfqLogDto.RequesterName = sqlDataReader.IsDBNull(ordinal16) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Requester Name"));
                int ordinal17 = sqlDataReader.GetOrdinal("Request Type");
                rfqLogDto.RequestType = sqlDataReader.IsDBNull(ordinal17) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Request Type"));
                results.Add(rfqLogDto);
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      return results;
    }

    public async Task<List<RFQ_LogDTO>> GetAllOpenRFQs()
    {
      List<RFQ_LogDTO> rfqsPassedDue = new List<RFQ_LogDTO>();
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetAllOpenRFQs"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              while (sqlDataReader.Read())
              {
                RFQ_LogDTO rfqLogDto = new RFQ_LogDTO();
                rfqLogDto.RFQLogNumber = (int) (Decimal) sqlDataReader.GetSqlDecimal(sqlDataReader.GetOrdinal("RFQ Log Number"));
                int ordinal1 = sqlDataReader.GetOrdinal("Customer Name");
                rfqLogDto.CustomerName = sqlDataReader.IsDBNull(ordinal1) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Customer Name"));
                int ordinal2 = sqlDataReader.GetOrdinal("Division");
                rfqLogDto.Division = sqlDataReader.IsDBNull(ordinal2) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Division"));
                int ordinal3 = sqlDataReader.GetOrdinal("Reason For Quote");
                rfqLogDto.Reason = sqlDataReader.IsDBNull(ordinal3) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Reason For Quote"));
                int ordinal4 = sqlDataReader.GetOrdinal("Program");
                rfqLogDto.Program = sqlDataReader.IsDBNull(ordinal4) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Program"));
                int ordinal5 = sqlDataReader.GetOrdinal("SOP Date");
                if (!sqlDataReader.IsDBNull(ordinal5))
                  rfqLogDto.SOPDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("SOP Date")));
                int ordinal6 = sqlDataReader.GetOrdinal("PPAP Date");
                if (!sqlDataReader.IsDBNull(ordinal6))
                  rfqLogDto.PPAPDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("PPAP Date")));
                int ordinal7 = sqlDataReader.GetOrdinal("Part Number");
                rfqLogDto.PartNumber = sqlDataReader.IsDBNull(ordinal7) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Part Number"));
                int ordinal8 = sqlDataReader.GetOrdinal("Drawing Number");
                rfqLogDto.DrawingNumber = sqlDataReader.IsDBNull(ordinal8) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Drawing Number"));
                int ordinal9 = sqlDataReader.GetOrdinal("Drawing Date");
                if (!sqlDataReader.IsDBNull(ordinal9))
                  rfqLogDto.DrawingDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Drawing Date")));
                int ordinal10 = sqlDataReader.GetOrdinal("Engineering Level");
                rfqLogDto.EngineeringLevel = sqlDataReader.IsDBNull(ordinal10) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Engineering Level"));
                int ordinal11 = sqlDataReader.GetOrdinal("Estimated Annual Volume");
                rfqLogDto.EstAnnualVolume = sqlDataReader.IsDBNull(ordinal11) ? 0L : sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Estimated Annual Volume"));
                int ordinal12 = sqlDataReader.GetOrdinal("Quote Request Date");
                if (!sqlDataReader.IsDBNull(ordinal12))
                  rfqLogDto.QuoteRequestDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Quote Request Date")));
                int ordinal13 = sqlDataReader.GetOrdinal("Quote Due Date");
                if (!sqlDataReader.IsDBNull(ordinal13))
                  rfqLogDto.QuoteDueDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Quote Due Date")));
                int ordinal14 = sqlDataReader.GetOrdinal("Status");
                rfqLogDto.Status = sqlDataReader.IsDBNull(ordinal14) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Status"));
                int ordinal15 = sqlDataReader.GetOrdinal("Closed Date");
                if (!sqlDataReader.IsDBNull(ordinal15))
                  rfqLogDto.ClosedDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Closed Date")));
                int ordinal16 = sqlDataReader.GetOrdinal("Requester Name");
                rfqLogDto.RequesterName = sqlDataReader.IsDBNull(ordinal16) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Requester Name"));
                int ordinal17 = sqlDataReader.GetOrdinal("Request Type");
                rfqLogDto.RequestType = sqlDataReader.IsDBNull(ordinal17) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Request Type"));
                rfqsPassedDue.Add(rfqLogDto);
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      return rfqsPassedDue;
    }

    public async Task<List<RFQ_LogDTO>> GetCompletedLastWeek()
    {
      List<RFQ_LogDTO> rfqsCompletedLW = new List<RFQ_LogDTO>();
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetCompletedLastWeek"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              while (sqlDataReader.Read())
              {
                RFQ_LogDTO rfqLogDto = new RFQ_LogDTO();
                rfqLogDto.RFQLogNumber = (int) (Decimal) sqlDataReader.GetSqlDecimal(sqlDataReader.GetOrdinal("RFQ Log Number"));
                int ordinal1 = sqlDataReader.GetOrdinal("Customer Name");
                rfqLogDto.CustomerName = sqlDataReader.IsDBNull(ordinal1) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Customer Name"));
                int ordinal2 = sqlDataReader.GetOrdinal("Division");
                rfqLogDto.Division = sqlDataReader.IsDBNull(ordinal2) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Division"));
                int ordinal3 = sqlDataReader.GetOrdinal("Reason For Quote");
                rfqLogDto.Reason = sqlDataReader.IsDBNull(ordinal3) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Reason For Quote"));
                int ordinal4 = sqlDataReader.GetOrdinal("Program");
                rfqLogDto.Program = sqlDataReader.IsDBNull(ordinal4) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Program"));
                int ordinal5 = sqlDataReader.GetOrdinal("SOP Date");
                if (!sqlDataReader.IsDBNull(ordinal5))
                  rfqLogDto.SOPDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("SOP Date")));
                int ordinal6 = sqlDataReader.GetOrdinal("PPAP Date");
                if (!sqlDataReader.IsDBNull(ordinal6))
                  rfqLogDto.PPAPDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("PPAP Date")));
                int ordinal7 = sqlDataReader.GetOrdinal("Part Number");
                rfqLogDto.PartNumber = sqlDataReader.IsDBNull(ordinal7) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Part Number"));
                int ordinal8 = sqlDataReader.GetOrdinal("Drawing Number");
                rfqLogDto.DrawingNumber = sqlDataReader.IsDBNull(ordinal8) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Drawing Number"));
                int ordinal9 = sqlDataReader.GetOrdinal("Drawing Date");
                if (!sqlDataReader.IsDBNull(ordinal9))
                  rfqLogDto.DrawingDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Drawing Date")));
                int ordinal10 = sqlDataReader.GetOrdinal("Engineering Level");
                rfqLogDto.EngineeringLevel = sqlDataReader.IsDBNull(ordinal10) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Engineering Level"));
                int ordinal11 = sqlDataReader.GetOrdinal("Estimated Annual Volume");
                rfqLogDto.EstAnnualVolume = sqlDataReader.IsDBNull(ordinal11) ? 0L : sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Estimated Annual Volume"));
                int ordinal12 = sqlDataReader.GetOrdinal("Quote Request Date");
                if (!sqlDataReader.IsDBNull(ordinal12))
                  rfqLogDto.QuoteRequestDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Quote Request Date")));
                int ordinal13 = sqlDataReader.GetOrdinal("Quote Due Date");
                if (!sqlDataReader.IsDBNull(ordinal13))
                  rfqLogDto.QuoteDueDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Quote Due Date")));
                int ordinal14 = sqlDataReader.GetOrdinal("Status");
                rfqLogDto.Status = sqlDataReader.IsDBNull(ordinal14) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Status"));
                int ordinal15 = sqlDataReader.GetOrdinal("Closed Date");
                if (!sqlDataReader.IsDBNull(ordinal15))
                  rfqLogDto.ClosedDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Closed Date")));
                int ordinal16 = sqlDataReader.GetOrdinal("Requester Name");
                rfqLogDto.RequesterName = sqlDataReader.IsDBNull(ordinal16) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Requester Name"));
                int ordinal17 = sqlDataReader.GetOrdinal("Request Type");
                rfqLogDto.RequestType = sqlDataReader.IsDBNull(ordinal17) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Request Type"));
                rfqsCompletedLW.Add(rfqLogDto);
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      return rfqsCompletedLW;
    }

    public async Task<List<RFQ_LogDTO>> GetPassedDueLastWeek()
    {
      List<RFQ_LogDTO> rfqsCompletedLW = new List<RFQ_LogDTO>();
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetPassedDueLastWeek"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              while (sqlDataReader.Read())
              {
                RFQ_LogDTO rfqLogDto = new RFQ_LogDTO();
                rfqLogDto.RFQLogNumber = (int) (Decimal) sqlDataReader.GetSqlDecimal(sqlDataReader.GetOrdinal("RFQ Log Number"));
                int ordinal1 = sqlDataReader.GetOrdinal("Customer Name");
                rfqLogDto.CustomerName = sqlDataReader.IsDBNull(ordinal1) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Customer Name"));
                int ordinal2 = sqlDataReader.GetOrdinal("Division");
                rfqLogDto.Division = sqlDataReader.IsDBNull(ordinal2) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Division"));
                int ordinal3 = sqlDataReader.GetOrdinal("Reason For Quote");
                rfqLogDto.Reason = sqlDataReader.IsDBNull(ordinal3) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Reason For Quote"));
                int ordinal4 = sqlDataReader.GetOrdinal("Program");
                rfqLogDto.Program = sqlDataReader.IsDBNull(ordinal4) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Program"));
                int ordinal5 = sqlDataReader.GetOrdinal("SOP Date");
                if (!sqlDataReader.IsDBNull(ordinal5))
                  rfqLogDto.SOPDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("SOP Date")));
                int ordinal6 = sqlDataReader.GetOrdinal("PPAP Date");
                if (!sqlDataReader.IsDBNull(ordinal6))
                  rfqLogDto.PPAPDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("PPAP Date")));
                int ordinal7 = sqlDataReader.GetOrdinal("Part Number");
                rfqLogDto.PartNumber = sqlDataReader.IsDBNull(ordinal7) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Part Number"));
                int ordinal8 = sqlDataReader.GetOrdinal("Drawing Number");
                rfqLogDto.DrawingNumber = sqlDataReader.IsDBNull(ordinal8) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Drawing Number"));
                int ordinal9 = sqlDataReader.GetOrdinal("Drawing Date");
                if (!sqlDataReader.IsDBNull(ordinal9))
                  rfqLogDto.DrawingDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Drawing Date")));
                int ordinal10 = sqlDataReader.GetOrdinal("Engineering Level");
                rfqLogDto.EngineeringLevel = sqlDataReader.IsDBNull(ordinal10) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Engineering Level"));
                int ordinal11 = sqlDataReader.GetOrdinal("Estimated Annual Volume");
                rfqLogDto.EstAnnualVolume = sqlDataReader.IsDBNull(ordinal11) ? 0L : sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Estimated Annual Volume"));
                int ordinal12 = sqlDataReader.GetOrdinal("Quote Request Date");
                if (!sqlDataReader.IsDBNull(ordinal12))
                  rfqLogDto.QuoteRequestDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Quote Request Date")));
                int ordinal13 = sqlDataReader.GetOrdinal("Quote Due Date");
                if (!sqlDataReader.IsDBNull(ordinal13))
                  rfqLogDto.QuoteDueDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Quote Due Date")));
                int ordinal14 = sqlDataReader.GetOrdinal("Status");
                rfqLogDto.Status = sqlDataReader.IsDBNull(ordinal14) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Status"));
                int ordinal15 = sqlDataReader.GetOrdinal("Closed Date");
                if (!sqlDataReader.IsDBNull(ordinal15))
                  rfqLogDto.ClosedDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Closed Date")));
                int ordinal16 = sqlDataReader.GetOrdinal("Requester Name");
                rfqLogDto.RequesterName = sqlDataReader.IsDBNull(ordinal16) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Requester Name"));
                int ordinal17 = sqlDataReader.GetOrdinal("Request Type");
                rfqLogDto.RequestType = sqlDataReader.IsDBNull(ordinal17) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Request Type"));
                rfqsCompletedLW.Add(rfqLogDto);
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      return rfqsCompletedLW;
    }

    public async Task<List<RFQ_LogDTO>> GetAllOpen()
    {
      List<RFQ_LogDTO> rfqsPassedDue = new List<RFQ_LogDTO>();
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetPassedDue"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              while (sqlDataReader.Read())
              {
                RFQ_LogDTO rfqLogDto = new RFQ_LogDTO();
                rfqLogDto.RFQLogNumber = (int) (Decimal) sqlDataReader.GetSqlDecimal(sqlDataReader.GetOrdinal("RFQ Log Number"));
                int ordinal1 = sqlDataReader.GetOrdinal("Customer Name");
                rfqLogDto.CustomerName = sqlDataReader.IsDBNull(ordinal1) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Customer Name"));
                int ordinal2 = sqlDataReader.GetOrdinal("Division");
                rfqLogDto.Division = sqlDataReader.IsDBNull(ordinal2) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Division"));
                int ordinal3 = sqlDataReader.GetOrdinal("Reason For Quote");
                rfqLogDto.Reason = sqlDataReader.IsDBNull(ordinal3) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Reason For Quote"));
                int ordinal4 = sqlDataReader.GetOrdinal("Program");
                rfqLogDto.Program = sqlDataReader.IsDBNull(ordinal4) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Program"));
                int ordinal5 = sqlDataReader.GetOrdinal("SOP Date");
                if (!sqlDataReader.IsDBNull(ordinal5))
                  rfqLogDto.SOPDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("SOP Date")));
                int ordinal6 = sqlDataReader.GetOrdinal("PPAP Date");
                if (!sqlDataReader.IsDBNull(ordinal6))
                  rfqLogDto.PPAPDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("PPAP Date")));
                int ordinal7 = sqlDataReader.GetOrdinal("Part Number");
                rfqLogDto.PartNumber = sqlDataReader.IsDBNull(ordinal7) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Part Number"));
                int ordinal8 = sqlDataReader.GetOrdinal("Drawing Number");
                rfqLogDto.DrawingNumber = sqlDataReader.IsDBNull(ordinal8) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Drawing Number"));
                int ordinal9 = sqlDataReader.GetOrdinal("Drawing Date");
                if (!sqlDataReader.IsDBNull(ordinal9))
                  rfqLogDto.DrawingDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Drawing Date")));
                int ordinal10 = sqlDataReader.GetOrdinal("Engineering Level");
                rfqLogDto.EngineeringLevel = sqlDataReader.IsDBNull(ordinal10) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Engineering Level"));
                int ordinal11 = sqlDataReader.GetOrdinal("Estimated Annual Volume");
                rfqLogDto.EstAnnualVolume = sqlDataReader.IsDBNull(ordinal11) ? 0L : sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("Estimated Annual Volume"));
                int ordinal12 = sqlDataReader.GetOrdinal("Quote Request Date");
                if (!sqlDataReader.IsDBNull(ordinal12))
                  rfqLogDto.QuoteRequestDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Quote Request Date")));
                int ordinal13 = sqlDataReader.GetOrdinal("Quote Due Date");
                if (!sqlDataReader.IsDBNull(ordinal13))
                  rfqLogDto.QuoteDueDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Quote Due Date")));
                int ordinal14 = sqlDataReader.GetOrdinal("Status");
                rfqLogDto.Status = sqlDataReader.IsDBNull(ordinal14) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Status"));
                int ordinal15 = sqlDataReader.GetOrdinal("Closed Date");
                if (!sqlDataReader.IsDBNull(ordinal15))
                  rfqLogDto.ClosedDate = new DateTime?(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("Closed Date")));
                int ordinal16 = sqlDataReader.GetOrdinal("Requester Name");
                rfqLogDto.RequesterName = sqlDataReader.IsDBNull(ordinal16) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Requester Name"));
                int ordinal17 = sqlDataReader.GetOrdinal("Request Type");
                rfqLogDto.RequestType = sqlDataReader.IsDBNull(ordinal17) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Request Type"));
                rfqsPassedDue.Add(rfqLogDto);
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      return rfqsPassedDue;
    }

    public async Task<RFQ_StatsListDTO> GetRFQStats_Monthly(DateTime date)
    {
      RFQ_StatsListDTO rfqMonthlyStats = new RFQ_StatsListDTO();
      List<RFQ_StatsDTO> stats = new List<RFQ_StatsDTO>();
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetTotalRFQs_Monthly"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = (object) date;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              int num = 1;
              while (sqlDataReader.Read())
              {
                RFQ_StatsDTO rfqStatsDto = new RFQ_StatsDTO();
                int ordinal = sqlDataReader.GetOrdinal("Month");
                if (!sqlDataReader.IsDBNull(ordinal))
                {
                  int int32 = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Month"));
                  if (num == int32)
                  {
                    rfqStatsDto.DatedIndex = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Month"));
                    rfqStatsDto.TotalRFQs = sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Count"));
                    stats.Add(rfqStatsDto);
                    ++num;
                  }
                  else
                  {
                    for (; num != int32; ++num)
                      stats.Add(new RFQ_StatsDTO());
                    rfqStatsDto.DatedIndex = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Month"));
                    rfqStatsDto.TotalRFQs = sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Count"));
                    stats.Add(rfqStatsDto);
                    ++num;
                  }
                }
              }
              rfqMonthlyStats.stats = stats;
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetOpenRFQs_Monthly"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = (object) date;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              while (sqlDataReader.Read())
              {
                int ordinal = sqlDataReader.GetOrdinal("Month");
                if (!sqlDataReader.IsDBNull(ordinal))
                  rfqMonthlyStats.stats[sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Month")) - 1].OpenRFQs = sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("OpenRFQs"));
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetLateRFQs_Monthly"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = (object) date;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              while (sqlDataReader.Read())
              {
                int ordinal = sqlDataReader.GetOrdinal("Month");
                if (!sqlDataReader.IsDBNull(ordinal))
                  rfqMonthlyStats.stats[sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Month")) - 1].LateRFQs = sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("LateRFQs"));
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetTotalDaysToCompletion_Monthly"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = (object) date;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              while (sqlDataReader.Read())
              {
                int ordinal = sqlDataReader.GetOrdinal("Month");
                if (!sqlDataReader.IsDBNull(ordinal))
                {
                  int int32 = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Month"));
                  int num = sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("DaysToComp"));
                  rfqMonthlyStats.stats[int32 - 1].AvgDaysToComplete = num <= 0 ? 0.0 : (double) (num / (rfqMonthlyStats.stats[int32 - 1].TotalRFQs - rfqMonthlyStats.stats[int32 - 1].OpenRFQs));
                }
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetCompletedOnTime_Monthly"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = (object) date;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              while (sqlDataReader.Read())
              {
                int ordinal = sqlDataReader.GetOrdinal("Month");
                if (!sqlDataReader.IsDBNull(ordinal))
                {
                  int int32 = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Month"));
                  int num = sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("OnTime"));
                  rfqMonthlyStats.stats[int32 - 1].PercentRFQsCompletedOnTime = (double) num / (double) (rfqMonthlyStats.stats[int32 - 1].TotalRFQs - rfqMonthlyStats.stats[int32 - 1].OpenRFQs - rfqMonthlyStats.stats[int32 - 1].LateRFQs) * 100.0;
                }
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetDaysLate_Monthly"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = (object) date;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              while (sqlDataReader.Read())
              {
                int ordinal = sqlDataReader.GetOrdinal("Month");
                if (!sqlDataReader.IsDBNull(ordinal))
                  rfqMonthlyStats.stats[sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Month")) - 1].DaysLate = sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("DaysLate"));
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      return rfqMonthlyStats;
    }

    public async Task<RFQ_StatsListDTO> GetStatsForGivenMonth_Weekly(DateTime date)
    {
      RFQ_StatsListDTO rfqWeeklyStats = new RFQ_StatsListDTO();
      List<RFQ_StatsDTO> stats = new List<RFQ_StatsDTO>();
      int weekNumber = date.GetWeekOfYear();
      DateTime Date_From = DateTimeExtensions.FirstDateOfWeek(date.Year, weekNumber, CultureInfo.CurrentCulture);
      DateTime day1_lastWkOfMonth = DateTimeExtensions.FirstDateOfWeek(Date_From.Year, weekNumber + 3, CultureInfo.CurrentCulture);
      DateTime Date_To = day1_lastWkOfMonth.AddDays(6.0);
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetTotalRFQs_Weekly"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = (object) Date_From;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              int num1 = 0;
              while (sqlDataReader.Read())
              {
                RFQ_StatsDTO rfqStatsDto = new RFQ_StatsDTO();
                if (!sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("WeekNum")))
                  rfqStatsDto.DatedIndex = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("WeekNum"));
                rfqStatsDto.TotalRFQs = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Count")) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Count"));
                if (num1 == 0)
                  stats.Add(rfqStatsDto);
                else if (rfqStatsDto.DatedIndex - num1 == 1)
                {
                  stats.Add(rfqStatsDto);
                }
                else
                {
                  int num2;
                  stats.Add(new RFQ_StatsDTO()
                  {
                    DatedIndex = num2 = num1 + 1
                  });
                  stats.Add(rfqStatsDto);
                }
                num1 = rfqStatsDto.DatedIndex;
              }
              int num3 = 0;
              if (stats.Count != 0)
              {
                int datedIndex = stats[stats.Count - 1].DatedIndex;
                while (stats.Count < 4)
                  stats.Add(new RFQ_StatsDTO()
                  {
                    DatedIndex = ++datedIndex
                  });
              }
              else
              {
                for (int index = 0; index < 4; ++index)
                  stats.Add(new RFQ_StatsDTO()
                  {
                    DatedIndex = ++num3
                  });
              }
              rfqWeeklyStats.stats = stats;
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetOpenRFQsInGivenMonth_Weekly"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = (object) Date_From;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              int ordinal = 0;
              int iso8601WeekOfYear = DateTimeExtensions.GetIso8601WeekOfYear(Date_From);
              int index = 0;
              while (sqlDataReader.Read())
              {
                int num = sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("WeekNum"));
                while (iso8601WeekOfYear != num)
                {
                  ++iso8601WeekOfYear;
                  ++index;
                }
                rfqWeeklyStats.stats[index].OpenRFQs = sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Count"));
                ++iso8601WeekOfYear;
                ++index;
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetLateRFQs_Weekly"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = (object) Date_From;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              int ordinal = 0;
              int iso8601WeekOfYear = DateTimeExtensions.GetIso8601WeekOfYear(Date_From);
              int index = 0;
              while (sqlDataReader.Read())
              {
                int num = sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("WeekNum"));
                while (iso8601WeekOfYear != num)
                {
                  ++iso8601WeekOfYear;
                  ++index;
                }
                rfqWeeklyStats.stats[index].LateRFQs = sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("LateRFQs"));
                ++iso8601WeekOfYear;
                ++index;
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        DateTime dateFrom = DateTimeExtensions.GetSixWeekRollBack_DateFrom_Inclusive(date);
        DateTime dt = DateTimeExtensions.FirstDayOf_FirstWeekInMonth(date);
        DateTime dateTo = dt.AddDays(6.0);
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetTotalDaysToCompletion_Weekly"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@dateFrom", SqlDbType.DateTime).Value = (object) dateFrom;
            sqlCommand.Parameters.Add("@dateTo", SqlDbType.DateTime).Value = (object) dateTo;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              int ordinal = 0;
              int index = 0;
              int num1 = 0;
              int num2 = 0;
              while (sqlDataReader.Read())
              {
                if (rfqWeeklyStats.stats.Count <= index)
                  rfqWeeklyStats.stats.Add(new RFQ_StatsDTO());
                rfqWeeklyStats.stats[index].AvgDays_DateFrom = dateFrom;
                rfqWeeklyStats.stats[index].AvgDays_DateTo = dateTo;
                num1 += sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Count"));
                num2 += sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("DaysToComp"));
                rfqWeeklyStats.stats[index].AvgDaysToComplete = num2 <= 0 || num1 <= 0 ? 0.0 : (double) (num2 / num1);
                ++index;
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetCompletedOnTime_Weekly"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@dateFrom", SqlDbType.DateTime).Value = (object) Date_From;
            sqlCommand.Parameters.Add("@dateTo", SqlDbType.DateTime).Value = (object) Date_To;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              int ordinal = 0;
              int iso8601WeekOfYear = DateTimeExtensions.GetIso8601WeekOfYear(Date_From);
              int index = 0;
              while (sqlDataReader.Read())
              {
                int num1 = sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("WeekNum"));
                while (iso8601WeekOfYear != num1)
                {
                  ++iso8601WeekOfYear;
                  ++index;
                }
                int num2 = sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("OnTime"));
                rfqWeeklyStats.stats[index].PercentRFQsCompletedOnTime = (double) num2 / (double) rfqWeeklyStats.stats[index].TotalRFQs * 100.0;
                ++iso8601WeekOfYear;
                ++index;
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand("GetDaysLate_Weekly"))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@dateFrom", SqlDbType.DateTime).Value = (object) Date_From;
            sqlCommand.Parameters.Add("@dateTo", SqlDbType.DateTime).Value = (object) Date_To;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              int ordinal = 0;
              int iso8601WeekOfYear = DateTimeExtensions.GetIso8601WeekOfYear(Date_From);
              int index = 0;
              while (sqlDataReader.Read())
              {
                int num = sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("WeekNum"));
                while (iso8601WeekOfYear != num)
                {
                  ++iso8601WeekOfYear;
                  ++index;
                }
                rfqWeeklyStats.stats[index].DaysLate = sqlDataReader.IsDBNull(ordinal) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("DaysLate"));
                ++iso8601WeekOfYear;
                ++index;
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      return rfqWeeklyStats;
    }

    public async Task<List<string>> GetDropDownFieldValuesFromRFQLogTable(string columnName)
    {
      List<string> resultList = new List<string>();
      string query = "SELECT DISTINCT [" + columnName + "] FROM [dbo].[RFQLog]";
      using (SqlConnection sqlConnection = new SqlConnection(RFQLogServices.connectionString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand(query))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              while (sqlDataReader.Read())
              {
                int ordinal = sqlDataReader.GetOrdinal(columnName);
                string str = sqlDataReader.IsDBNull(ordinal) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal(columnName));
                if (str != "")
                  resultList.Add(str);
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      return resultList;
    }

    public async Task<List<string>> GetDropDownFieldValues(string connectionstring, string tablename, string columnName, string queryDetails)
    {
      string connString = ConfigurationManager.ConnectionStrings[connectionstring].ConnectionString;
      List<string> resultList = new List<string>();
      string query = "SELECT DISTINCT " + columnName + " FROM [dbo].[" + tablename + "] " + queryDetails;
      using (SqlConnection sqlConnection = new SqlConnection(connString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand(query))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              while (sqlDataReader.Read())
              {
                int ordinal = sqlDataReader.GetOrdinal(columnName);
                string str = sqlDataReader.IsDBNull(ordinal) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal(columnName));
                if (str != "")
                  resultList.Add(str);
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      return resultList;
    }

    public async Task<List<string>> GetDropDownFieldValues_CustomQuery(string connectionstring, string columnName, string query)
    {
      string connString = ConfigurationManager.ConnectionStrings[connectionstring].ConnectionString;
      List<string> resultList = new List<string>();
      using (SqlConnection sqlConnection = new SqlConnection(connString))
      {
        try
        {
          using (SqlCommand sqlCommand = new SqlCommand(query))
          {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            await sqlConnection.OpenAsync();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
              while (sqlDataReader.Read())
              {
                int ordinal = sqlDataReader.GetOrdinal(columnName);
                string str = sqlDataReader.IsDBNull(ordinal) ? "" : sqlDataReader.GetString(sqlDataReader.GetOrdinal(columnName));
                if (str != "")
                  resultList.Add(str);
              }
            }
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {
          sqlConnection.Close();
        }
      }
      return resultList;
    }
  }
}
