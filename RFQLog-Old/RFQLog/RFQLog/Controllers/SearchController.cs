// Decompiled with JetBrains decompiler
// Type: RFQLog.Controllers.SearchController
// Assembly: RFQLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 25B8AF27-D382-432E-8A3A-9BE2F231470C
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLog.dll

using Microsoft.CSharp.RuntimeBinder;
using RFQLog.Models;
using RFQLogDAL;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RFQLog.Controllers
{
  public class SearchController : Controller
  {
    public async Task<ActionResult> Index()
    {
      try
      {
        RFQLogServices srv = new RFQLogServices();
        List<RFQ_LogDTO> rfqDTOs = await srv.GetAll();
        RFQLogListModel allRFQs = new RFQLogListModel();
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
            allRFQs.RFQs.Add(rfqLogModel);
          }
        }
        List<string> requesters = await srv.GetDropDownFieldValues_CustomQuery("HRDB", "FullName", "SELECT RTRIM(LTRIM(firstname)) + ' ' + RTRIM(LTRIM(lastname)) AS FullName FROM tbl_employees WHERE paystatus = 'A' ORDER BY FullName");
        requesters.Insert(0, "PLEASE SELECT");
        // ISSUE: reference to a compiler-generated field
        if (SearchController.\u003CIndex\u003Eo__SiteContainer0.\u003C\u003Ep__Site1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SearchController.\u003CIndex\u003Eo__SiteContainer0.\u003C\u003Ep__Site1 = CallSite<Func<CallSite, object, List<string>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Requesters", typeof (SearchController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = SearchController.\u003CIndex\u003Eo__SiteContainer0.\u003C\u003Ep__Site1.Target((CallSite) SearchController.\u003CIndex\u003Eo__SiteContainer0.\u003C\u003Ep__Site1, this.ViewBag, requesters);
        List<string> customers = await srv.GetDropDownFieldValues("COMP", "vCustomers", "shortname", "ORDER BY [shortname]");
        customers.Insert(0, "PLEASE SELECT");
        // ISSUE: reference to a compiler-generated field
        if (SearchController.\u003CIndex\u003Eo__SiteContainer0.\u003C\u003Ep__Site2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SearchController.\u003CIndex\u003Eo__SiteContainer0.\u003C\u003Ep__Site2 = CallSite<Func<CallSite, object, List<string>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "CustomerNames", typeof (SearchController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = SearchController.\u003CIndex\u003Eo__SiteContainer0.\u003C\u003Ep__Site2.Target((CallSite) SearchController.\u003CIndex\u003Eo__SiteContainer0.\u003C\u003Ep__Site2, this.ViewBag, customers);
        List<string> divisions = await srv.GetDropDownFieldValues("HRDB", "tbl_division", "division", "WHERE active = 1");
        divisions.Insert(0, "PLEASE SELECT");
        // ISSUE: reference to a compiler-generated field
        if (SearchController.\u003CIndex\u003Eo__SiteContainer0.\u003C\u003Ep__Site3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SearchController.\u003CIndex\u003Eo__SiteContainer0.\u003C\u003Ep__Site3 = CallSite<Func<CallSite, object, List<string>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Divisions", typeof (SearchController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj3 = SearchController.\u003CIndex\u003Eo__SiteContainer0.\u003C\u003Ep__Site3.Target((CallSite) SearchController.\u003CIndex\u003Eo__SiteContainer0.\u003C\u003Ep__Site3, this.ViewBag, divisions);
        this.ViewData["SearchResults"] = (object) allRFQs;
        return (ActionResult) this.View();
      }
      catch
      {
        return (ActionResult) this.View();
      }
    }

    [HttpPost]
    public async Task<ActionResult> Index(RFQLogModel searchCriteria)
    {
      RFQLogServices srv = new RFQLogServices();
      List<string> requesters = await srv.GetDropDownFieldValues_CustomQuery("HRDB", "FullName", "SELECT RTRIM(LTRIM(firstname)) + ' ' + RTRIM(LTRIM(lastname)) AS FullName FROM tbl_employees WHERE paystatus = 'A' ORDER BY FullName");
      requesters.Insert(0, "PLEASE SELECT");
      // ISSUE: reference to a compiler-generated field
      if (SearchController.\u003CIndex\u003Eo__SiteContainere.\u003C\u003Ep__Sitef == null)
      {
        // ISSUE: reference to a compiler-generated field
        SearchController.\u003CIndex\u003Eo__SiteContainere.\u003C\u003Ep__Sitef = CallSite<Func<CallSite, object, List<string>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Requesters", typeof (SearchController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = SearchController.\u003CIndex\u003Eo__SiteContainere.\u003C\u003Ep__Sitef.Target((CallSite) SearchController.\u003CIndex\u003Eo__SiteContainere.\u003C\u003Ep__Sitef, this.ViewBag, requesters);
      List<string> customers = await srv.GetDropDownFieldValues("COMP", "vCustomers", "shortname", "ORDER BY [shortname]");
      customers.Insert(0, "PLEASE SELECT");
      // ISSUE: reference to a compiler-generated field
      if (SearchController.\u003CIndex\u003Eo__SiteContainere.\u003C\u003Ep__Site10 == null)
      {
        // ISSUE: reference to a compiler-generated field
        SearchController.\u003CIndex\u003Eo__SiteContainere.\u003C\u003Ep__Site10 = CallSite<Func<CallSite, object, List<string>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "CustomerNames", typeof (SearchController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = SearchController.\u003CIndex\u003Eo__SiteContainere.\u003C\u003Ep__Site10.Target((CallSite) SearchController.\u003CIndex\u003Eo__SiteContainere.\u003C\u003Ep__Site10, this.ViewBag, customers);
      List<string> divisions = await srv.GetDropDownFieldValues("HRDB", "tbl_division", "division", "WHERE active = 1");
      divisions.Insert(0, "PLEASE SELECT");
      // ISSUE: reference to a compiler-generated field
      if (SearchController.\u003CIndex\u003Eo__SiteContainere.\u003C\u003Ep__Site11 == null)
      {
        // ISSUE: reference to a compiler-generated field
        SearchController.\u003CIndex\u003Eo__SiteContainere.\u003C\u003Ep__Site11 = CallSite<Func<CallSite, object, List<string>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Divisions", typeof (SearchController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = SearchController.\u003CIndex\u003Eo__SiteContainere.\u003C\u003Ep__Site11.Target((CallSite) SearchController.\u003CIndex\u003Eo__SiteContainere.\u003C\u003Ep__Site11, this.ViewBag, divisions);
      RFQ_LogDTO searchDTO = new RFQ_LogDTO();
      searchDTO.CustomerName = !(searchCriteria.CustomerName != "PLEASE SELECT") ? (string) null : searchCriteria.CustomerName;
      searchDTO.Division = !(searchCriteria.Division != "PLEASE SELECT") ? (string) null : searchCriteria.Division;
      searchDTO.Program = !(searchCriteria.Program != "PLEASE SELECT") ? (string) null : searchCriteria.Program;
      searchDTO.Reason = !(searchCriteria.Reason != "PLEASE SELECT") ? (string) null : searchCriteria.Reason;
      searchDTO.PartNumber = !(searchCriteria.PartNumber != "PLEASE SELECT") ? (string) null : searchCriteria.PartNumber;
      searchDTO.DrawingNumber = !(searchCriteria.DrawingNumber != "PLEASE SELECT") ? (string) null : searchCriteria.DrawingNumber;
      searchDTO.EngineeringLevel = !(searchCriteria.EngineeringLevel != "PLEASE SELECT") ? (string) null : searchCriteria.EngineeringLevel;
      searchDTO.RequesterName = !(searchCriteria.RequesterName != "PLEASE SELECT") ? (string) null : searchCriteria.RequesterName;
      searchDTO.Status = !(searchCriteria.Status != "ALL") ? "ALL" : searchCriteria.Status;
      searchDTO.RequestType = !(searchCriteria.RequestType != "ALL") ? "ALL" : searchCriteria.RequestType;
      try
      {
        if (searchDTO.RequesterName != null || searchDTO.CustomerName != null || (searchDTO.Division != null || searchDTO.RequestType != null) || searchDTO.Status != null)
        {
          List<RFQ_LogDTO> resultsReturned = await srv.CustomSearch(searchDTO);
          RFQLogListModel results = new RFQLogListModel();
          if (resultsReturned.Count > 0)
          {
            for (int index = 0; index < resultsReturned.Count; ++index)
            {
              RFQLogModel rfqLogModel = new RFQLogModel();
              rfqLogModel.RFQLogNumber = resultsReturned[index].RFQLogNumber;
              rfqLogModel.CustomerName = resultsReturned[index].CustomerName;
              rfqLogModel.Division = resultsReturned[index].Division;
              rfqLogModel.Reason = resultsReturned[index].Reason;
              rfqLogModel.Program = resultsReturned[index].Program;
              rfqLogModel.SOPDate = resultsReturned[index].SOPDate;
              rfqLogModel.PPAPDate = resultsReturned[index].PPAPDate;
              rfqLogModel.PartNumber = resultsReturned[index].PartNumber;
              rfqLogModel.DrawingNumber = resultsReturned[index].DrawingNumber;
              rfqLogModel.DrawingDate = resultsReturned[index].DrawingDate;
              rfqLogModel.EngineeringLevel = resultsReturned[index].EngineeringLevel;
              rfqLogModel.EstAnnualVolume = resultsReturned[index].EstAnnualVolume;
              rfqLogModel.QuoteDueDate = resultsReturned[index].QuoteDueDate;
              rfqLogModel.QuoteRequestDate = resultsReturned[index].QuoteRequestDate;
              rfqLogModel.RequesterName = resultsReturned[index].RequesterName;
              rfqLogModel.RequestType = resultsReturned[index].RequestType;
              DateTime? closedDate = resultsReturned[index].ClosedDate;
              rfqLogModel.ClosedDate = closedDate.HasValue ? resultsReturned[index].ClosedDate : new DateTime?(new DateTime(1L));
              rfqLogModel.Status = resultsReturned[index].Status;
              results.RFQs.Add(rfqLogModel);
            }
          }
          this.Session["recordsReturned"] = (object) results.RFQs.Count;
          this.ViewData["SearchResults"] = (object) results;
          return (ActionResult) this.View();
        }
        this.ViewData["SearchResults"] = (object) new RFQLogListModel()
        {
          RFQs = {
            new RFQLogModel()
            {
              RequesterName = "No Results Found",
              QuoteRequestDate = new DateTime?(new DateTime(1L)),
              QuoteDueDate = new DateTime?(new DateTime(1L)),
              ClosedDate = new DateTime?(new DateTime(1L))
            }
          }
        };
        return (ActionResult) this.View();
      }
      catch (Exception ex)
      {
        return (ActionResult) this.View((object) ex);
      }
    }

    public ActionResult SearchById()
    {
      return (ActionResult) this.View();
    }

    [HttpPost]
    public ActionResult SearchById(RFQLogModel model)
    {
      return (ActionResult) this.RedirectToAction("Details", "RFQLog", (object) new
      {
        id = model.RFQLogNumber
      });
    }
  }
}
