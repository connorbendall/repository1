// Decompiled with JetBrains decompiler
// Type: RFQLog.Models.RFQLogModel
// Assembly: RFQLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 25B8AF27-D382-432E-8A3A-9BE2F231470C
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLog.dll

using RFQLogDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace RFQLog.Models
{
  public class RFQLogModel
  {
    private RFQLogServices _dal;

    public int RFQLogNumber { get; set; }

    [Required(ErrorMessage = "Request Type is required.")]
    public string RequestType { get; set; }

    [Required(ErrorMessage = "Parent Assembly is required.")]
    public string ParentAssembly { get; set; }

    [Required(ErrorMessage = "Requester Name is required.")]
    public string RequesterName { get; set; }

    [Required(ErrorMessage = "Customer Name is required.")]
    public string CustomerName { get; set; }

    [Required(ErrorMessage = "Division is required.")]
    public string Division { get; set; }

    [Required(ErrorMessage = "Program is required.")]
    public string Program { get; set; }

    [Required(ErrorMessage = "Reason for Quote is required.")]
    public string Reason { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    [Required(ErrorMessage = "SOP Date is required.")]
    public DateTime? SOPDate { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    [Required(ErrorMessage = "PPAP Date is required.")]
    public DateTime? PPAPDate { get; set; }

    [Required(ErrorMessage = "Part Number is required.")]
    public string PartNumber { get; set; }

    [Required(ErrorMessage = "Drawing Number is required.")]
    public string DrawingNumber { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    [Required(ErrorMessage = "Drawing Date is required.")]
    public DateTime? DrawingDate { get; set; }

    [Required(ErrorMessage = "Engineering Level is required.")]
    public string EngineeringLevel { get; set; }

    [Required(ErrorMessage = "Estimated Annual Volume is required.")]
    public long EstAnnualVolume { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? QuoteRequestDate { get; set; }

    [Required(ErrorMessage = "Quote Due Date is required.")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? QuoteDueDate { get; set; }

    public string Status { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? ClosedDate { get; set; }

    public string ReqesterEmail { get; set; }

    public string PurchasingEmail { get; set; }

    public List<HttpPostedFileBase> PostedFiles { get; set; }

    public List<string> Filenames { get; set; }

    public RFQLogModel()
    {
      this._dal = new RFQLogServices();
      this.Filenames = new List<string>();
      this.PostedFiles = new List<HttpPostedFileBase>();
    }

    public static RFQLogModel DTO_to_Model(RFQ_LogDTO dto)
    {
      return new RFQLogModel()
      {
        RFQLogNumber = dto.RFQLogNumber,
        RequestType = dto.RequestType,
        RequesterName = dto.RequesterName,
        ReqesterEmail = dto.ReqesterEmail,
        PurchasingEmail = dto.PurchasingEmail,
        CustomerName = dto.CustomerName,
        Division = dto.Division,
        Program = dto.Program,
        Reason = dto.Reason,
        SOPDate = dto.SOPDate,
        PPAPDate = dto.PPAPDate,
        PartNumber = dto.PartNumber,
        DrawingNumber = dto.DrawingNumber,
        DrawingDate = dto.DrawingDate,
        EngineeringLevel = dto.EngineeringLevel,
        EstAnnualVolume = dto.EstAnnualVolume,
        QuoteRequestDate = dto.QuoteRequestDate,
        QuoteDueDate = dto.QuoteDueDate,
        Status = dto.Status,
        ClosedDate = dto.ClosedDate,
        ParentAssembly = dto.ParentAssembly
      };
    }

    public static RFQ_LogDTO Model_to_DTO(RFQLogModel model)
    {
      return new RFQ_LogDTO()
      {
        RFQLogNumber = model.RFQLogNumber,
        RequestType = model.RequestType,
        RequesterName = model.RequesterName,
        ReqesterEmail = model.ReqesterEmail,
        PurchasingEmail = model.PurchasingEmail,
        CustomerName = model.CustomerName,
        Division = model.Division,
        Program = model.Program,
        Reason = model.Reason,
        SOPDate = model.SOPDate,
        PPAPDate = model.PPAPDate,
        PartNumber = model.PartNumber,
        DrawingNumber = model.DrawingNumber,
        DrawingDate = model.DrawingDate,
        EngineeringLevel = model.EngineeringLevel,
        EstAnnualVolume = model.EstAnnualVolume,
        QuoteDueDate = model.QuoteDueDate,
        QuoteRequestDate = model.QuoteRequestDate,
        Status = model.Status,
        Status = model.Status != null ? model.Status : "OPEN",
        ClosedDate = model.ClosedDate,
        ParentAssembly = model.ParentAssembly
      };
    }
  }
}
