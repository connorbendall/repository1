// Decompiled with JetBrains decompiler
// Type: RFQLog.Helpers.NetResource
// Assembly: RFQLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 25B8AF27-D382-432E-8A3A-9BE2F231470C
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLog.dll

using System.Runtime.InteropServices;

namespace RFQLog.Helpers
{
  [StructLayout(LayoutKind.Sequential)]
  public class NetResource
  {
    public ResourceScope Scope;
    public ResourceType ResourceType;
    public ResourceDisplaytype DisplayType;
    public int Usage;
    public string LocalName;
    public string RemoteName;
    public string Comment;
    public string Provider;
  }
}
