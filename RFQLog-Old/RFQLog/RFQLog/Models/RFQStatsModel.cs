// Decompiled with JetBrains decompiler
// Type: RFQLog.Models.RFQStatsModel
// Assembly: RFQLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 25B8AF27-D382-432E-8A3A-9BE2F231470C
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLog.dll

using System;

namespace RFQLog.Models
{
  public class RFQStatsModel
  {
    public string DateName { get; set; }

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public int TotalRFQs { get; set; }

    public int OpenRFQs { get; set; }

    public int LateRFQs { get; set; }

    public string PercentageRFQsCompleted { get; set; }

    public string AvgDaysToComplete { get; set; }

    public int DaysLate { get; set; }
  }
}
