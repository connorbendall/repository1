// Decompiled with JetBrains decompiler
// Type: RFQLog.Controllers.RFQLogController
// Assembly: RFQLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 25B8AF27-D382-432E-8A3A-9BE2F231470C
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLog.dll

using Microsoft.CSharp.RuntimeBinder;
using RFQLog.Helpers;
using RFQLog.Models;
using RFQLogDAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RFQLog.Controllers
{
  public class RFQLogController : Controller
  {
    private const string repositoryPath = "\\\\192.168.2.88\\iisfile\\RFQLog\\RFQLogRepository\\";

    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    public async Task<ActionResult> Details(int id)
    {
      RFQLogServices srv = new RFQLogServices();
      RFQ_LogDTO rfq = await srv.GetByID((long) id);
      RFQLogModel rfqModel = RFQLogModel.DTO_to_Model(rfq);
      try
      {
        List<string> stringList = new List<string>();
        using (new NetworkConnection("\\\\192.168.2.88", new NetworkCredential("iisfile", "p@ssw0rd")))
        {
          string[] files = Directory.GetFiles("\\\\192.168.2.88\\iisfile\\RFQLog\\RFQLogRepository\\", id.ToString() + "_*");
          foreach (string path in files)
          {
            string fileName = Path.GetFileName(path);
            stringList.Add(fileName);
          }
          bool flag;
          int num = flag ? 1 : 0;
        }
        stringList.Sort();
        rfqModel.Filenames = stringList;
      }
      catch (Exception ex)
      {
        return (ActionResult) this.View((object) ex);
      }
      return (ActionResult) this.View((object) rfqModel);
    }

    public async Task<ActionResult> Create()
    {
      RFQLogServices srv = new RFQLogServices();
      if (this.Session["filesToPost"] != null)
      {
        List<HttpPostedFileBase> httpPostedFileBaseList = this.Session["filesToPost"] as List<HttpPostedFileBase>;
        object viewBag1 = this.ViewBag;
        // ISSUE: reference to a compiler-generated field
        if (RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site7 == null)
        {
          // ISSUE: reference to a compiler-generated field
          RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site7 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.IsEvent(CSharpBinderFlags.None, "Message", typeof (RFQLogController)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (!RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site7.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site7, viewBag1))
        {
          // ISSUE: reference to a compiler-generated field
          if (RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sitea == null)
          {
            // ISSUE: reference to a compiler-generated field
            RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sitea = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.ValueFromCompoundAssignment, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, object, object> target1 = RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sitea.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, object, object>> pSitea = RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sitea;
          object obj1 = viewBag1;
          // ISSUE: reference to a compiler-generated field
          if (RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site9 == null)
          {
            // ISSUE: reference to a compiler-generated field
            RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site9 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string, object> target2 = RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site9.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string, object>> pSite9 = RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site9;
          // ISSUE: reference to a compiler-generated field
          if (RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Siteb == null)
          {
            // ISSUE: reference to a compiler-generated field
            RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Siteb = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Siteb.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Siteb, viewBag1);
          string str = "<b style='font-weight:bold'>FILE LIST</b><br/><hr/>";
          object obj3 = target2((CallSite) pSite9, obj2, str);
          object obj4 = target1((CallSite) pSitea, obj1, obj3);
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          if (RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site8 == null)
          {
            // ISSUE: reference to a compiler-generated field
            RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site8 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.InvokeSpecialName | CSharpBinderFlags.ResultDiscarded, "add_Message", (IEnumerable<Type>) null, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site8.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site8, viewBag1, "<b style='font-weight:bold'>FILE LIST</b><br/><hr/>");
        }
        httpPostedFileBaseList.Sort();
        if (httpPostedFileBaseList != null)
        {
          foreach (HttpPostedFileBase httpPostedFileBase in httpPostedFileBaseList)
          {
            if (httpPostedFileBase != null)
            {
              string fileName = Path.GetFileName(httpPostedFileBase.FileName);
              object viewBag2 = this.ViewBag;
              string str1 = "<b>" + fileName + "</b><br />";
              // ISSUE: reference to a compiler-generated field
              if (RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sitec == null)
              {
                // ISSUE: reference to a compiler-generated field
                RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sitec = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.IsEvent(CSharpBinderFlags.None, "Message", typeof (RFQLogController)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              if (!RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sitec.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sitec, viewBag2))
              {
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sitef == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sitef = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.ValueFromCompoundAssignment, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                Func<CallSite, object, object, object> target1 = RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sitef.Target;
                // ISSUE: reference to a compiler-generated field
                CallSite<Func<CallSite, object, object, object>> pSitef = RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sitef;
                object obj1 = viewBag2;
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sitee == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sitee = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                Func<CallSite, object, string, object> target2 = RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sitee.Target;
                // ISSUE: reference to a compiler-generated field
                CallSite<Func<CallSite, object, string, object>> pSitee = RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sitee;
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site10 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site10 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                object obj2 = RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site10.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site10, viewBag2);
                string str2 = str1;
                object obj3 = target2((CallSite) pSitee, obj2, str2);
                object obj4 = target1((CallSite) pSitef, obj1, obj3);
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sited == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sited = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.InvokeSpecialName | CSharpBinderFlags.ResultDiscarded, "add_Message", (IEnumerable<Type>) null, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                object obj = RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sited.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Sited, viewBag2, str1);
              }
            }
          }
        }
      }
      List<string> requesters = await srv.GetDropDownFieldValues_CustomQuery("HRDB", "FullName", "SELECT RTRIM(LTRIM(firstname)) + ' ' + RTRIM(LTRIM(lastname)) AS FullName FROM tbl_employees WHERE paystatus = 'A' ORDER BY FullName");
      // ISSUE: reference to a compiler-generated field
      if (RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site11 == null)
      {
        // ISSUE: reference to a compiler-generated field
        RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site11 = CallSite<Func<CallSite, object, List<string>, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "Requesters", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj5 = RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site11.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site11, this.ViewBag, requesters);
      List<string> customers = await srv.GetDropDownFieldValues("COMP", "vCustomers", "shortname", "ORDER BY [shortname]");
      // ISSUE: reference to a compiler-generated field
      if (RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site12 == null)
      {
        // ISSUE: reference to a compiler-generated field
        RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site12 = CallSite<Func<CallSite, object, List<string>, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "CustomerNames", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj6 = RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site12.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site12, this.ViewBag, customers);
      List<string> divisions = await srv.GetDropDownFieldValues("HRDB", "tbl_division", "division", "WHERE active = 1");
      // ISSUE: reference to a compiler-generated field
      if (RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site13 == null)
      {
        // ISSUE: reference to a compiler-generated field
        RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site13 = CallSite<Func<CallSite, object, List<string>, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "Divisions", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj7 = RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site13.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer6.\u003C\u003Ep__Site13, this.ViewBag, divisions);
      return this.Session["myModel"] == null ? (ActionResult) this.View() : (ActionResult) this.View((object) (this.Session["myModel"] as RFQLogModel));
    }

    [HttpPost]
    [RFQLogController.MultipleButton(Argument = "Create", Name = "action")]
    public async Task<ActionResult> Create(RFQLogModel model)
    {
      RFQLogServices srv = new RFQLogServices();
      List<string> requesters = await srv.GetDropDownFieldValues_CustomQuery("HRDB", "FullName", "SELECT RTRIM(LTRIM(firstname)) + ' ' + RTRIM(LTRIM(lastname)) AS FullName FROM tbl_employees WHERE paystatus = 'A' ORDER BY FullName");
      // ISSUE: reference to a compiler-generated field
      if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site1c == null)
      {
        // ISSUE: reference to a compiler-generated field
        RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site1c = CallSite<Func<CallSite, object, List<string>, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "Requesters", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site1c.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site1c, this.ViewBag, requesters);
      List<string> customers = await srv.GetDropDownFieldValues("COMP", "vCustomers", "shortname", "ORDER BY [shortname]");
      // ISSUE: reference to a compiler-generated field
      if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site1d == null)
      {
        // ISSUE: reference to a compiler-generated field
        RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site1d = CallSite<Func<CallSite, object, List<string>, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "CustomerNames", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site1d.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site1d, this.ViewBag, customers);
      List<string> divisions = await srv.GetDropDownFieldValues("HRDB", "tbl_division", "division", "WHERE active = 1");
      // ISSUE: reference to a compiler-generated field
      if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site1e == null)
      {
        // ISSUE: reference to a compiler-generated field
        RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site1e = CallSite<Func<CallSite, object, List<string>, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "Divisions", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site1e.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site1e, this.ViewBag, divisions);
      RFQ_LogDTO newRFQ = new RFQ_LogDTO();
      if (this.ModelState.IsValid)
      {
        newRFQ = RFQLogModel.Model_to_DTO(model);
        try
        {
          int retVal = await srv.Create(newRFQ);
          if (retVal > 0)
          {
            this.Session["statusGreen"] = (object) ("RFQ log #" + (object) retVal + " successfully submited.");
            this.Session["statusRed"] = (object) "";
            using (new NetworkConnection("\\\\192.168.2.88", new NetworkCredential("iisfile", "p@ssw0rd")))
            {
              if (this.Session["filesToPost"] != null)
              {
                object viewBag = this.ViewBag;
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site1f == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site1f = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.IsEvent(CSharpBinderFlags.None, "Message", typeof (RFQLogController)));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                if (!RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site1f.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site1f, viewBag))
                {
                  // ISSUE: reference to a compiler-generated field
                  if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site22 == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site22 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.ValueFromCompoundAssignment, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                    {
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                    }));
                  }
                  // ISSUE: reference to a compiler-generated field
                  Func<CallSite, object, object, object> target1 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site22.Target;
                  // ISSUE: reference to a compiler-generated field
                  CallSite<Func<CallSite, object, object, object>> pSite22 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site22;
                  object obj4 = viewBag;
                  // ISSUE: reference to a compiler-generated field
                  if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site21 == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site21 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                    {
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                    }));
                  }
                  // ISSUE: reference to a compiler-generated field
                  Func<CallSite, object, string, object> target2 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site21.Target;
                  // ISSUE: reference to a compiler-generated field
                  CallSite<Func<CallSite, object, string, object>> pSite21 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site21;
                  // ISSUE: reference to a compiler-generated field
                  if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site23 == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site23 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
                    {
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                    }));
                  }
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  object obj5 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site23.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site23, viewBag);
                  string str = "<b sytle=\"font-weight;\">FILE LIST</b><br/>";
                  object obj6 = target2((CallSite) pSite21, obj5, str);
                  object obj7 = target1((CallSite) pSite22, obj4, obj6);
                }
                else
                {
                  // ISSUE: reference to a compiler-generated field
                  if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site20 == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site20 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.InvokeSpecialName | CSharpBinderFlags.ResultDiscarded, "add_Message", (IEnumerable<Type>) null, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                    {
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                    }));
                  }
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  object obj4 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site20.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site20, viewBag, "<b sytle=\"font-weight;\">FILE LIST</b><br/>");
                }
                List<HttpPostedFileBase> httpPostedFileBaseList = this.Session["filesToPost"] as List<HttpPostedFileBase>;
                httpPostedFileBaseList.Sort();
                foreach (HttpPostedFileBase httpPostedFileBase in httpPostedFileBaseList)
                {
                  if (httpPostedFileBase != null)
                  {
                    string fileName = Path.GetFileName(httpPostedFileBase.FileName);
                    httpPostedFileBase.SaveAs("\\\\192.168.2.88\\iisfile\\RFQLog\\RFQLogRepository\\" + (object) retVal + "_" + fileName);
                  }
                }
                this.Session.Remove("filesToPost");
              }
            }
            this.Session.Remove("myModel");
          }
          else
          {
            this.Session["statusRed"] = (object) ("RFQ log not created. - " + (object) retVal);
            this.Session["statusGreen"] = (object) "";
          }
          return (ActionResult) this.RedirectToAction("Details", (object) new
          {
            id = retVal
          });
        }
        catch (Exception ex)
        {
          this.Session["statusRed"] = (object) ("RFQ log not created. - " + ex.Message);
          return (ActionResult) this.View();
        }
      }
      else
      {
        if (this.Session["filesToPost"] != null)
        {
          List<HttpPostedFileBase> httpPostedFileBaseList = this.Session["filesToPost"] as List<HttpPostedFileBase>;
          object viewBag1 = this.ViewBag;
          // ISSUE: reference to a compiler-generated field
          if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site24 == null)
          {
            // ISSUE: reference to a compiler-generated field
            RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site24 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.IsEvent(CSharpBinderFlags.None, "Message", typeof (RFQLogController)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (!RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site24.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site24, viewBag1))
          {
            // ISSUE: reference to a compiler-generated field
            if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site27 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site27 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.ValueFromCompoundAssignment, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, object, object> target1 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site27.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, object, object>> pSite27 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site27;
            object obj4 = viewBag1;
            // ISSUE: reference to a compiler-generated field
            if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site26 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site26 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, string, object> target2 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site26.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, string, object>> pSite26 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site26;
            // ISSUE: reference to a compiler-generated field
            if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site28 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site28 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj5 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site28.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site28, viewBag1);
            string str = "<b style='font-weight:bold'>FILE LIST</b><br/><hr/>";
            object obj6 = target2((CallSite) pSite26, obj5, str);
            object obj7 = target1((CallSite) pSite27, obj4, obj6);
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site25 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site25 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.InvokeSpecialName | CSharpBinderFlags.ResultDiscarded, "add_Message", (IEnumerable<Type>) null, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj4 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site25.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site25, viewBag1, "<b style='font-weight:bold'>FILE LIST</b><br/><hr/>");
          }
          if (httpPostedFileBaseList != null)
          {
            foreach (HttpPostedFileBase httpPostedFileBase in httpPostedFileBaseList)
            {
              if (httpPostedFileBase != null)
              {
                string fileName = Path.GetFileName(httpPostedFileBase.FileName);
                object viewBag2 = this.ViewBag;
                string str1 = "<b>" + fileName + "</b><br />";
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site29 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site29 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.IsEvent(CSharpBinderFlags.None, "Message", typeof (RFQLogController)));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                if (!RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site29.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site29, viewBag2))
                {
                  // ISSUE: reference to a compiler-generated field
                  if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site2c == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site2c = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.ValueFromCompoundAssignment, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                    {
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                    }));
                  }
                  // ISSUE: reference to a compiler-generated field
                  Func<CallSite, object, object, object> target1 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site2c.Target;
                  // ISSUE: reference to a compiler-generated field
                  CallSite<Func<CallSite, object, object, object>> pSite2c = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site2c;
                  object obj4 = viewBag2;
                  // ISSUE: reference to a compiler-generated field
                  if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site2b == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site2b = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                    {
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
                    }));
                  }
                  // ISSUE: reference to a compiler-generated field
                  Func<CallSite, object, string, object> target2 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site2b.Target;
                  // ISSUE: reference to a compiler-generated field
                  CallSite<Func<CallSite, object, string, object>> pSite2b = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site2b;
                  // ISSUE: reference to a compiler-generated field
                  if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site2d == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site2d = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
                    {
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                    }));
                  }
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  object obj5 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site2d.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site2d, viewBag2);
                  string str2 = str1;
                  object obj6 = target2((CallSite) pSite2b, obj5, str2);
                  object obj7 = target1((CallSite) pSite2c, obj4, obj6);
                }
                else
                {
                  // ISSUE: reference to a compiler-generated field
                  if (RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site2a == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site2a = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.InvokeSpecialName | CSharpBinderFlags.ResultDiscarded, "add_Message", (IEnumerable<Type>) null, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                    {
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
                    }));
                  }
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  object obj4 = RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site2a.Target((CallSite) RFQLogController.\u003CCreate\u003Eo__SiteContainer1b.\u003C\u003Ep__Site2a, viewBag2, str1);
                }
              }
            }
            this.Session["filesToPost"] = (object) httpPostedFileBaseList;
            model.PostedFiles = httpPostedFileBaseList;
          }
        }
        return (ActionResult) this.View((object) model);
      }
    }

    public async Task<ActionResult> Edit(int id)
    {
      RFQLogServices srv = new RFQLogServices();
      RFQ_LogDTO rfq = await srv.GetByID((long) id);
      List<string> requesters = await srv.GetDropDownFieldValues_CustomQuery("HRDB", "FullName", "SELECT RTRIM(LTRIM(firstname)) + ' ' + RTRIM(LTRIM(lastname)) AS FullName FROM tbl_employees WHERE paystatus = 'A' ORDER BY FullName");
      requesters.Insert(0, "PLEASE SELECT");
      // ISSUE: reference to a compiler-generated field
      if (RFQLogController.\u003CEdit\u003Eo__SiteContainer38.\u003C\u003Ep__Site39 == null)
      {
        // ISSUE: reference to a compiler-generated field
        RFQLogController.\u003CEdit\u003Eo__SiteContainer38.\u003C\u003Ep__Site39 = CallSite<Func<CallSite, object, List<string>, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "Requesters", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = RFQLogController.\u003CEdit\u003Eo__SiteContainer38.\u003C\u003Ep__Site39.Target((CallSite) RFQLogController.\u003CEdit\u003Eo__SiteContainer38.\u003C\u003Ep__Site39, this.ViewBag, requesters);
      List<string> customers = await srv.GetDropDownFieldValues("COMP", "vCustomers", "shortname", "ORDER BY [shortname]");
      customers.Insert(0, "PLEASE SELECT");
      // ISSUE: reference to a compiler-generated field
      if (RFQLogController.\u003CEdit\u003Eo__SiteContainer38.\u003C\u003Ep__Site3a == null)
      {
        // ISSUE: reference to a compiler-generated field
        RFQLogController.\u003CEdit\u003Eo__SiteContainer38.\u003C\u003Ep__Site3a = CallSite<Func<CallSite, object, List<string>, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "CustomerNames", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = RFQLogController.\u003CEdit\u003Eo__SiteContainer38.\u003C\u003Ep__Site3a.Target((CallSite) RFQLogController.\u003CEdit\u003Eo__SiteContainer38.\u003C\u003Ep__Site3a, this.ViewBag, customers);
      List<string> divisions = await srv.GetDropDownFieldValues("HRDB", "tbl_division", "division", "WHERE active = 1");
      divisions.Insert(0, "PLEASE SELECT");
      // ISSUE: reference to a compiler-generated field
      if (RFQLogController.\u003CEdit\u003Eo__SiteContainer38.\u003C\u003Ep__Site3b == null)
      {
        // ISSUE: reference to a compiler-generated field
        RFQLogController.\u003CEdit\u003Eo__SiteContainer38.\u003C\u003Ep__Site3b = CallSite<Func<CallSite, object, List<string>, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.None, "Divisions", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = RFQLogController.\u003CEdit\u003Eo__SiteContainer38.\u003C\u003Ep__Site3b.Target((CallSite) RFQLogController.\u003CEdit\u003Eo__SiteContainer38.\u003C\u003Ep__Site3b, this.ViewBag, divisions);
      RFQLogModel rfqModel = RFQLogModel.DTO_to_Model(rfq);
      try
      {
        List<string> stringList = new List<string>();
        using (new NetworkConnection("\\\\192.168.2.88", new NetworkCredential("iisfile", "p@ssw0rd")))
        {
          string[] files = Directory.GetFiles("\\\\192.168.2.88\\iisfile\\RFQLog\\RFQLogRepository\\", id.ToString() + "_*");
          foreach (string path in files)
          {
            string fileName = Path.GetFileName(path);
            stringList.Add(fileName);
          }
          bool flag;
          int num = flag ? 1 : 0;
        }
        rfqModel.Filenames = stringList;
      }
      catch (Exception ex)
      {
        return (ActionResult) this.View((object) ex);
      }
      return (ActionResult) this.View((object) rfqModel);
    }

    [RFQLogController.MultipleButton(Argument = "Edit", Name = "action")]
    [HttpPost]
    public async Task<ActionResult> Edit(int id, RFQLogModel model)
    {
      using (new NetworkConnection("\\\\192.168.2.88", new NetworkCredential("iisfile", "p@ssw0rd")))
      {
        if (this.Session["filesToPost"] != null)
        {
          object viewBag = this.ViewBag;
          // ISSUE: reference to a compiler-generated field
          if (RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site47 == null)
          {
            // ISSUE: reference to a compiler-generated field
            RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site47 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.IsEvent(CSharpBinderFlags.None, "Message", typeof (RFQLogController)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (!RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site47.Target((CallSite) RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site47, viewBag))
          {
            // ISSUE: reference to a compiler-generated field
            if (RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site4a == null)
            {
              // ISSUE: reference to a compiler-generated field
              RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site4a = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.ValueFromCompoundAssignment, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, object, object> target1 = RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site4a.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, object, object>> pSite4a = RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site4a;
            object obj1 = viewBag;
            // ISSUE: reference to a compiler-generated field
            if (RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site49 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site49 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, string, object> target2 = RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site49.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, string, object>> pSite49 = RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site49;
            // ISSUE: reference to a compiler-generated field
            if (RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site4b == null)
            {
              // ISSUE: reference to a compiler-generated field
              RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site4b = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj2 = RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site4b.Target((CallSite) RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site4b, viewBag);
            string str = "<b>FILE LIST</b><br/>";
            object obj3 = target2((CallSite) pSite49, obj2, str);
            object obj4 = target1((CallSite) pSite4a, obj1, obj3);
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            if (RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site48 == null)
            {
              // ISSUE: reference to a compiler-generated field
              RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site48 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.InvokeSpecialName | CSharpBinderFlags.ResultDiscarded, "add_Message", (IEnumerable<Type>) null, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj = RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site48.Target((CallSite) RFQLogController.\u003CEdit\u003Eo__SiteContainer46.\u003C\u003Ep__Site48, viewBag, "<b>FILE LIST</b><br/>");
          }
          foreach (HttpPostedFileBase httpPostedFileBase in this.Session["filesToPost"] as List<HttpPostedFileBase>)
          {
            if (httpPostedFileBase != null)
            {
              string fileName = Path.GetFileName(httpPostedFileBase.FileName);
              httpPostedFileBase.SaveAs("\\\\192.168.2.88\\iisfile\\RFQLog\\RFQLogRepository\\" + (object) model.RFQLogNumber + "_" + fileName);
            }
          }
          this.Session.Remove("filesToPost");
        }
      }
      this.Session.Remove("myModel");
      try
      {
        RFQLogServices srv = new RFQLogServices();
        model.RFQLogNumber = id;
        RFQ_LogDTO updatedRFQ = RFQLogModel.Model_to_DTO(model);
        long retVal = await srv.Update(updatedRFQ);
        this.Session["statusGreen"] = (object) ("RFQ log #" + (object) retVal + " successfully updated.");
        this.Session["statusRed"] = (object) "";
        return (ActionResult) this.RedirectToAction("Details", (object) new
        {
          id = retVal
        });
      }
      catch
      {
        return (ActionResult) this.View();
      }
    }

    public ActionResult Delete(int id)
    {
      return (ActionResult) this.View();
    }

    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection)
    {
      try
      {
        return (ActionResult) this.RedirectToAction("Index");
      }
      catch
      {
        return (ActionResult) this.View();
      }
    }

    [RFQLogController.MultipleButton(Argument = "Upload", Name = "action")]
    [HttpPost]
    public ActionResult Upload(List<HttpPostedFileBase> postedFiles, int? id, RFQLogModel model)
    {
      if (id.HasValue)
      {
        if (postedFiles != null)
        {
          using (new NetworkConnection("\\\\192.168.2.88", new NetworkCredential("iisfile", "p@ssw0rd")))
          {
            foreach (HttpPostedFileBase postedFile in postedFiles)
            {
              if (postedFile != null)
              {
                string fileName = Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(fileName);
                string str1 = id.ToString() + "_" + fileName;
                int num = 1;
                while (System.IO.File.Exists("\\\\192.168.2.88\\iisfile\\RFQLog\\RFQLogRepository\\" + str1))
                {
                  str1 = id.ToString() + "_" + fileName.Trim() + " Copy(" + (object) num + ")" + extension;
                  ++num;
                }
                postedFile.SaveAs("\\\\192.168.2.88\\iisfile\\RFQLog\\RFQLogRepository\\" + str1);
                object viewBag = this.ViewBag;
                string str2 = string.Format("<b>{0}</b> uploaded.<br />", (object) str1);
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site53 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site53 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.IsEvent(CSharpBinderFlags.None, "Message", typeof (RFQLogController)));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                if (!RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site53.Target((CallSite) RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site53, viewBag))
                {
                  // ISSUE: reference to a compiler-generated field
                  if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site56 == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site56 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.ValueFromCompoundAssignment, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                    {
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                    }));
                  }
                  // ISSUE: reference to a compiler-generated field
                  Func<CallSite, object, object, object> target1 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site56.Target;
                  // ISSUE: reference to a compiler-generated field
                  CallSite<Func<CallSite, object, object, object>> pSite56 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site56;
                  object obj1 = viewBag;
                  // ISSUE: reference to a compiler-generated field
                  if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site55 == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site55 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                    {
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
                    }));
                  }
                  // ISSUE: reference to a compiler-generated field
                  Func<CallSite, object, string, object> target2 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site55.Target;
                  // ISSUE: reference to a compiler-generated field
                  CallSite<Func<CallSite, object, string, object>> pSite55 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site55;
                  // ISSUE: reference to a compiler-generated field
                  if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site57 == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site57 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
                    {
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                    }));
                  }
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  object obj2 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site57.Target((CallSite) RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site57, viewBag);
                  string str3 = str2;
                  object obj3 = target2((CallSite) pSite55, obj2, str3);
                  object obj4 = target1((CallSite) pSite56, obj1, obj3);
                }
                else
                {
                  // ISSUE: reference to a compiler-generated field
                  if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site54 == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site54 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.InvokeSpecialName | CSharpBinderFlags.ResultDiscarded, "add_Message", (IEnumerable<Type>) null, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                    {
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
                    }));
                  }
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  object obj = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site54.Target((CallSite) RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site54, viewBag, str2);
                }
              }
            }
          }
        }
        return (ActionResult) this.RedirectToAction("Details", (object) new
        {
          id = id
        });
      }
      if (postedFiles != null)
      {
        if (this.Session["filesToPost"] != null)
        {
          List<HttpPostedFileBase> httpPostedFileBaseList = this.Session["filesToPost"] as List<HttpPostedFileBase>;
          foreach (HttpPostedFileBase httpPostedFileBase in httpPostedFileBaseList)
          {
            if (httpPostedFileBase != null)
            {
              string fileName = Path.GetFileName(httpPostedFileBase.FileName);
              object viewBag = this.ViewBag;
              string str1 = "<b>" + fileName + "</b><br />";
              // ISSUE: reference to a compiler-generated field
              if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site58 == null)
              {
                // ISSUE: reference to a compiler-generated field
                RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site58 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.IsEvent(CSharpBinderFlags.None, "Message", typeof (RFQLogController)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              if (!RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site58.Target((CallSite) RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site58, viewBag))
              {
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5b == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5b = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.ValueFromCompoundAssignment, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                Func<CallSite, object, object, object> target1 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5b.Target;
                // ISSUE: reference to a compiler-generated field
                CallSite<Func<CallSite, object, object, object>> pSite5b = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5b;
                object obj1 = viewBag;
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5a == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5a = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                Func<CallSite, object, string, object> target2 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5a.Target;
                // ISSUE: reference to a compiler-generated field
                CallSite<Func<CallSite, object, string, object>> pSite5a = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5a;
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5c == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5c = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                object obj2 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5c.Target((CallSite) RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5c, viewBag);
                string str2 = str1;
                object obj3 = target2((CallSite) pSite5a, obj2, str2);
                object obj4 = target1((CallSite) pSite5b, obj1, obj3);
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site59 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site59 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.InvokeSpecialName | CSharpBinderFlags.ResultDiscarded, "add_Message", (IEnumerable<Type>) null, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                object obj = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site59.Target((CallSite) RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site59, viewBag, str1);
              }
            }
          }
          foreach (HttpPostedFileBase postedFile in postedFiles)
          {
            if (postedFile != null)
            {
              string fileName = Path.GetFileName(postedFile.FileName);
              object viewBag = this.ViewBag;
              string str1 = "<b>" + fileName + "</b><br />";
              // ISSUE: reference to a compiler-generated field
              if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5d == null)
              {
                // ISSUE: reference to a compiler-generated field
                RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5d = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.IsEvent(CSharpBinderFlags.None, "Message", typeof (RFQLogController)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              if (!RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5d.Target((CallSite) RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5d, viewBag))
              {
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site60 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site60 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.ValueFromCompoundAssignment, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                Func<CallSite, object, object, object> target1 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site60.Target;
                // ISSUE: reference to a compiler-generated field
                CallSite<Func<CallSite, object, object, object>> pSite60 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site60;
                object obj1 = viewBag;
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5f == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5f = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                Func<CallSite, object, string, object> target2 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5f.Target;
                // ISSUE: reference to a compiler-generated field
                CallSite<Func<CallSite, object, string, object>> pSite5f = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5f;
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site61 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site61 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                object obj2 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site61.Target((CallSite) RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site61, viewBag);
                string str2 = str1;
                object obj3 = target2((CallSite) pSite5f, obj2, str2);
                object obj4 = target1((CallSite) pSite60, obj1, obj3);
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5e == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5e = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.InvokeSpecialName | CSharpBinderFlags.ResultDiscarded, "add_Message", (IEnumerable<Type>) null, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                object obj = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5e.Target((CallSite) RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site5e, viewBag, str1);
              }
              httpPostedFileBaseList.Add(postedFile);
            }
          }
          httpPostedFileBaseList.Sort();
          this.Session["filesToPost"] = (object) httpPostedFileBaseList;
        }
        else
        {
          foreach (HttpPostedFileBase postedFile in postedFiles)
          {
            if (postedFile != null)
            {
              string fileName = Path.GetFileName(postedFile.FileName);
              object viewBag = this.ViewBag;
              string str1 = "<b>" + fileName + "</b><br />";
              // ISSUE: reference to a compiler-generated field
              if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site62 == null)
              {
                // ISSUE: reference to a compiler-generated field
                RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site62 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.IsEvent(CSharpBinderFlags.None, "Message", typeof (RFQLogController)));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              if (!RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site62.Target((CallSite) RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site62, viewBag))
              {
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site65 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site65 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.SetMember(CSharpBinderFlags.ValueFromCompoundAssignment, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                Func<CallSite, object, object, object> target1 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site65.Target;
                // ISSUE: reference to a compiler-generated field
                CallSite<Func<CallSite, object, object, object>> pSite65 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site65;
                object obj1 = viewBag;
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site64 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site64 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.AddAssign, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                Func<CallSite, object, string, object> target2 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site64.Target;
                // ISSUE: reference to a compiler-generated field
                CallSite<Func<CallSite, object, string, object>> pSite64 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site64;
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site66 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site66 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Message", typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                object obj2 = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site66.Target((CallSite) RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site66, viewBag);
                string str2 = str1;
                object obj3 = target2((CallSite) pSite64, obj2, str2);
                object obj4 = target1((CallSite) pSite65, obj1, obj3);
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                if (RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site63 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site63 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.InvokeSpecialName | CSharpBinderFlags.ResultDiscarded, "add_Message", (IEnumerable<Type>) null, typeof (RFQLogController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                object obj = RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site63.Target((CallSite) RFQLogController.\u003CUpload\u003Eo__SiteContainer52.\u003C\u003Ep__Site63, viewBag, str1);
              }
            }
          }
          this.Session["filesToPost"] = (object) postedFiles;
        }
      }
      if (model != null)
        this.Session["myModel"] = (object) model;
      return (ActionResult) this.RedirectToAction("Create");
    }

    public ActionResult Download(string filename)
    {
      using (new NetworkConnection("\\\\192.168.2.88", new NetworkCredential("iisfile", "p@ssw0rd")))
        return (ActionResult) this.File("\\\\192.168.2.88\\iisfile\\RFQLog\\RFQLogRepository\\" + filename, "application/" + filename.Split('.')[1], filename);
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MultipleButtonAttribute : ActionNameSelectorAttribute
    {
      public string Name { get; set; }

      public string Argument { get; set; }

      public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
      {
        bool flag = false;
        string key = string.Format("{0}:{1}", (object) this.Name, (object) this.Argument);
        if (controllerContext.Controller.ValueProvider.GetValue(key) != null)
        {
          controllerContext.Controller.ControllerContext.RouteData.Values[this.Name] = (object) this.Argument;
          flag = true;
        }
        return flag;
      }
    }
  }
}
