// Decompiled with JetBrains decompiler
// Type: RFQLog.Models.LoginModel
// Assembly: RFQLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 25B8AF27-D382-432E-8A3A-9BE2F231470C
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLog.dll

using System.ComponentModel.DataAnnotations;

namespace RFQLog.Models
{
  public class LoginModel
  {
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
  }
}
