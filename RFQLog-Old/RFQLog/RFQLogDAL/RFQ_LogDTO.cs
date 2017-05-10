// Decompiled with JetBrains decompiler
// Type: RFQLogDAL.RFQ_LogDTO
// Assembly: RFQLogDAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 01B3F331-73BD-4DBB-8BBC-96E4C9AEE7C8
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLogDAL.dll

using System;

namespace RFQLogDAL
{
  public class RFQ_LogDTO
  {
    public int RFQLogNumber { get; set; }

    public string CustomerName { get; set; }

    public string Division { get; set; }

    public string Program { get; set; }

    public string Reason { get; set; }

    public DateTime? SOPDate { get; set; }

    public DateTime? PPAPDate { get; set; }

    public string PartNumber { get; set; }

    public string DrawingNumber { get; set; }

    public DateTime? DrawingDate { get; set; }

    public string EngineeringLevel { get; set; }

    public long EstAnnualVolume { get; set; }

    public DateTime? QuoteRequestDate { get; set; }

    public DateTime? QuoteDueDate { get; set; }

    public DateTime? ClosedDate { get; set; }

    public string Status { get; set; }

    public string RequesterName { get; set; }

    public string ReqesterEmail { get; set; }

    public string PurchasingEmail { get; set; }

    public string RequestType { get; set; }

    public string ParentAssembly { get; set; }
    }
}
