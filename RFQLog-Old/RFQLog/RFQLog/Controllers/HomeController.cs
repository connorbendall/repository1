// Decompiled with JetBrains decompiler
// Type: RFQLog.Controllers.HomeController
// Assembly: RFQLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 25B8AF27-D382-432E-8A3A-9BE2F231470C
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLog.dll

using RFQLog.Helpers;
using RFQLog.Models;
using RFQLogDAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RFQLog.Controllers
{
  public class HomeController : Controller
  {
    public async Task<ActionResult> Index(string month)
    {
      int selectedMonth = 0;
      selectedMonth = month == null ? DateTime.Now.Month : int.Parse(month);
      try
      {
        RFQLogServices srv = new RFQLogServices();
        RFQ_StatsListDTO monthlyStats = await srv.GetRFQStats_Monthly(DateTime.Now);
        RFQStatsListModel statsModel_Monthly = new RFQStatsListModel();
        List<RFQStatsModel> rfqStatsModels = new List<RFQStatsModel>();
        if (monthlyStats.stats.Count > 0)
        {
          for (int index = 0; index < monthlyStats.stats.Count; ++index)
            rfqStatsModels.Add(new RFQStatsModel()
            {
              DateName = DateTimeExtensions.GetMonthNameFromNumber(monthlyStats.stats[index].DatedIndex),
              OpenRFQs = monthlyStats.stats[index].OpenRFQs,
              LateRFQs = monthlyStats.stats[index].LateRFQs,
              PercentageRFQsCompleted = string.Format("{0:0.0}", (object) monthlyStats.stats[index].PercentRFQsCompletedOnTime),
              AvgDaysToComplete = string.Format("{0:0.0}", (object) monthlyStats.stats[index].AvgDaysToComplete),
              DaysLate = monthlyStats.stats[index].DaysLate
            });
        }
        if (monthlyStats.stats.Count < 12)
        {
          int num = 12 - monthlyStats.stats.Count;
          for (int index = 0; index < num; ++index)
            rfqStatsModels.Add(new RFQStatsModel());
        }
        statsModel_Monthly.StatsList = rfqStatsModels;
        if (month == null)
          this.Session["monthSelected"] = (object) 0;
        else
          this.Session["monthSelected"] = (object) (int.Parse(month) - 1);
        if (statsModel_Monthly.StatsList.Count > 0)
          this.ViewData["Monthly"] = (object) statsModel_Monthly;
      }
      catch (Exception ex)
      {
        string message = ex.Message;
        return (ActionResult) this.View();
      }
      try
      {
        DateTime current = DateTime.Now;
        DateTime date = new DateTime(current.Year, selectedMonth, 1);
        RFQLogServices srv = new RFQLogServices();
        RFQ_StatsListDTO weeklyStats = await srv.GetStatsForGivenMonth_Weekly(date);
        RFQStatsListModel statsModel_Weekly = new RFQStatsListModel();
        List<RFQStatsModel> rfqStatsModels = new List<RFQStatsModel>();
        if (weeklyStats.stats.Count > 0)
        {
          for (int index = 0; index < weeklyStats.stats.Count; ++index)
            rfqStatsModels.Add(new RFQStatsModel()
            {
              DateName = "Week " + (object) weeklyStats.stats[index].DatedIndex,
              OpenRFQs = weeklyStats.stats[index].OpenRFQs,
              LateRFQs = weeklyStats.stats[index].LateRFQs,
              PercentageRFQsCompleted = string.Format("{0:0.00}", (object) weeklyStats.stats[index].PercentRFQsCompletedOnTime),
              AvgDaysToComplete = string.Format("{0:0.0}", (object) weeklyStats.stats[index].AvgDaysToComplete),
              DaysLate = weeklyStats.stats[index].DaysLate
            });
        }
        statsModel_Weekly.StatsList = rfqStatsModels;
        this.Session["monthName"] = (object) date.ToString("MMMM", (IFormatProvider) CultureInfo.CurrentCulture);
        this.ViewData["Weekly"] = (object) statsModel_Weekly;
      }
      catch
      {
        return (ActionResult) this.View();
      }
      return (ActionResult) this.View();
    }

    public async Task<ActionResult> Report(string month)
    {
      RFQStatsListModel statsModel_Weekly;
      try
      {
        RFQLogServices srv = new RFQLogServices();
        DateTime current = DateTime.Now;
        DateTime test = new DateTime(current.Year, 2, current.Day);
        RFQ_StatsListDTO weeklyStats = await srv.GetStatsForGivenMonth_Weekly(test);
        statsModel_Weekly = new RFQStatsListModel();
        List<RFQStatsModel> rfqStatsModels = new List<RFQStatsModel>();
        if (weeklyStats.stats.Count > 0)
        {
          for (int index = 0; index < weeklyStats.stats.Count; ++index)
            rfqStatsModels.Add(new RFQStatsModel()
            {
              DateName = "Week " + (object) weeklyStats.stats[index].DatedIndex,
              OpenRFQs = weeklyStats.stats[index].OpenRFQs,
              LateRFQs = weeklyStats.stats[index].LateRFQs,
              PercentageRFQsCompleted = "nil",
              AvgDaysToComplete = string.Format("{0:0.0}", (object) weeklyStats.stats[index].AvgDaysToComplete)
            });
        }
        statsModel_Weekly.StatsList = rfqStatsModels;
      }
      catch
      {
        return (ActionResult) this.PartialView();
      }
      return (ActionResult) this.PartialView((object) statsModel_Weekly);
    }
  }
}
