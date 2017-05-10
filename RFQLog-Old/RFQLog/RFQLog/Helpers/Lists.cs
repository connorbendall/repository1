// Decompiled with JetBrains decompiler
// Type: RFQLog.Helpers.Lists
// Assembly: RFQLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 25B8AF27-D382-432E-8A3A-9BE2F231470C
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLog.dll

using RFQLogDAL;
using System.Collections.Generic;

namespace RFQLog.Helpers
{
  public class Lists
  {
    public static IEnumerable<string> StatusSearchOptions = (IEnumerable<string>) new List<string>()
    {
      "ALL",
      "OPEN",
      "CLOSED"
    };
    public static IEnumerable<string> StatusOptions = (IEnumerable<string>) new List<string>()
    {
      "OPEN",
      "CLOSED"
    };
    public static IEnumerable<string> RequestTypeOptions = (IEnumerable<string>) new List<string>()
    {
      "Direct Material",
      "MRO"
    };
    public static IEnumerable<string> RequestTypeSearchOptions = (IEnumerable<string>) new List<string>()
    {
      "ALL",
      "Direct Material",
      "MRO"
    };
    private RFQLogServices svr = new RFQLogServices();
  }
}
