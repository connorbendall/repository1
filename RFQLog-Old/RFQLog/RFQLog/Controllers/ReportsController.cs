// Decompiled with JetBrains decompiler
// Type: RFQLog.Controllers.ReportsController
// Assembly: RFQLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 25B8AF27-D382-432E-8A3A-9BE2F231470C
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLog.dll

using RFQLog.Models;
using RFQLogDAL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RFQLog.Controllers
{
  public class ReportsController : Controller
  {
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    public async Task<ActionResult> AllOpenRFQs()
    {
      try
      {
        RFQLogServices srv = new RFQLogServices();
        List<RFQ_LogDTO> rfqDTOs = await srv.GetAllOpenRFQs();
        RFQLogListModel allOpenRFQs = new RFQLogListModel();
        if (rfqDTOs.Count > 0)
        {
          for (int index = 0; index < rfqDTOs.Count; ++index)
            allOpenRFQs.RFQs.Add(new RFQLogModel()
            {
              RFQLogNumber = rfqDTOs[index].RFQLogNumber,
              CustomerName = rfqDTOs[index].CustomerName,
              Division = rfqDTOs[index].Division,
              Reason = rfqDTOs[index].Reason,
              Program = rfqDTOs[index].Program,
              SOPDate = rfqDTOs[index].SOPDate,
              PPAPDate = rfqDTOs[index].PPAPDate,
              PartNumber = rfqDTOs[index].PartNumber,
              DrawingNumber = rfqDTOs[index].DrawingNumber,
              DrawingDate = rfqDTOs[index].DrawingDate,
              EngineeringLevel = rfqDTOs[index].EngineeringLevel,
              EstAnnualVolume = rfqDTOs[index].EstAnnualVolume,
              QuoteDueDate = rfqDTOs[index].QuoteDueDate,
              QuoteRequestDate = rfqDTOs[index].QuoteRequestDate,
              RequesterName = rfqDTOs[index].RequesterName,
              RequestType = rfqDTOs[index].RequestType,
              Status = rfqDTOs[index].Status
            });
        }
        this.Session["recordsReturned"] = (object) allOpenRFQs.RFQs.Count;
        return (ActionResult) this.View((object) allOpenRFQs);
      }
      catch
      {
        return (ActionResult) this.View();
      }
    }

    public async Task<ActionResult> CompletedLastWeek()
    {
      try
      {
        RFQLogServices srv = new RFQLogServices();
        List<RFQ_LogDTO> rfqDTOs = await srv.GetCompletedLastWeek();
        RFQLogListModel completedLW_List = new RFQLogListModel();
        if (rfqDTOs.Count > 0)
        {
          for (int index = 0; index < rfqDTOs.Count; ++index)
            completedLW_List.RFQs.Add(new RFQLogModel()
            {
              RFQLogNumber = rfqDTOs[index].RFQLogNumber,
              CustomerName = rfqDTOs[index].CustomerName,
              Division = rfqDTOs[index].Division,
              Reason = rfqDTOs[index].Reason,
              Program = rfqDTOs[index].Program,
              SOPDate = rfqDTOs[index].SOPDate,
              PPAPDate = rfqDTOs[index].PPAPDate,
              PartNumber = rfqDTOs[index].PartNumber,
              DrawingNumber = rfqDTOs[index].DrawingNumber,
              DrawingDate = rfqDTOs[index].DrawingDate,
              EngineeringLevel = rfqDTOs[index].EngineeringLevel,
              EstAnnualVolume = rfqDTOs[index].EstAnnualVolume,
              QuoteDueDate = rfqDTOs[index].QuoteDueDate,
              QuoteRequestDate = rfqDTOs[index].QuoteRequestDate,
              RequesterName = rfqDTOs[index].RequesterName,
              RequestType = rfqDTOs[index].RequestType,
              ClosedDate = rfqDTOs[index].ClosedDate,
              Status = rfqDTOs[index].Status
            });
        }
        this.Session["recordsReturned"] = (object) completedLW_List.RFQs.Count;
        return (ActionResult) this.View((object) completedLW_List);
      }
      catch
      {
        return (ActionResult) this.View();
      }
    }

    public async Task<ActionResult> PassedDueLastWeek()
    {
      try
      {
        RFQLogServices srv = new RFQLogServices();
        List<RFQ_LogDTO> rfqDTOs = await srv.GetPassedDueLastWeek();
        RFQLogListModel completedLW_List = new RFQLogListModel();
        if (rfqDTOs.Count > 0)
        {
          for (int index = 0; index < rfqDTOs.Count; ++index)
          {
            RFQLogModel rfqLogModel = new RFQLogModel();
            rfqLogModel.RFQLogNumber = rfqDTOs[index].RFQLogNumber;
            rfqLogModel.CustomerName = rfqDTOs[index].CustomerName;
            rfqLogModel.Division = rfqDTOs[index].Division;
            rfqLogModel.Reason = rfqDTOs[index].Reason;
            rfqLogModel.Program = rfqDTOs[index].Program;
            rfqLogModel.SOPDate = rfqDTOs[index].SOPDate;
            rfqLogModel.PPAPDate = rfqDTOs[index].PPAPDate;
            rfqLogModel.PartNumber = rfqDTOs[index].PartNumber;
            rfqLogModel.DrawingNumber = rfqDTOs[index].DrawingNumber;
            rfqLogModel.DrawingDate = rfqDTOs[index].DrawingDate;
            rfqLogModel.EngineeringLevel = rfqDTOs[index].EngineeringLevel;
            rfqLogModel.EstAnnualVolume = rfqDTOs[index].EstAnnualVolume;
            rfqLogModel.QuoteDueDate = rfqDTOs[index].QuoteDueDate;
            rfqLogModel.QuoteRequestDate = rfqDTOs[index].QuoteRequestDate;
            rfqLogModel.RequesterName = rfqDTOs[index].RequesterName;
            rfqLogModel.RequestType = rfqDTOs[index].RequestType;
            DateTime? closedDate = rfqDTOs[index].ClosedDate;
            rfqLogModel.ClosedDate = closedDate.HasValue ? rfqDTOs[index].ClosedDate : new DateTime?(new DateTime(1L));
            rfqLogModel.Status = rfqDTOs[index].Status;
            completedLW_List.RFQs.Add(rfqLogModel);
          }
        }
        this.Session["recordsReturned"] = (object) completedLW_List.RFQs.Count;
        return (ActionResult) this.View((object) completedLW_List);
      }
      catch
      {
        return (ActionResult) this.View();
      }
    }
  }
}
