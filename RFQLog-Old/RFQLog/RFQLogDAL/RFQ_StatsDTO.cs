// Decompiled with JetBrains decompiler
// Type: RFQLogDAL.RFQ_StatsDTO
// Assembly: RFQLogDAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01B3F331-73BD-4DBB-8BBC-96E4C9AEE7C8
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLogDAL.dll

using System;

namespace RFQLogDAL
{
  public class RFQ_StatsDTO
  {
    public int DatedIndex { get; set; }

    public int TotalRFQs { get; set; }

    public int OpenRFQs { get; set; }

    public int LateRFQs { get; set; }

    public double PercentRFQsCompletedOnTime { get; set; }

    public double AvgDaysToComplete { get; set; }

    public DateTime AvgDays_DateFrom { get; set; }

    public DateTime AvgDays_DateTo { get; set; }

    public int DaysLate { get; set; }
  }
}
