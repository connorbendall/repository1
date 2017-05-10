// Decompiled with JetBrains decompiler
// Type: RFQLog.Helpers.NetworkConnection
// Assembly: RFQLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 25B8AF27-D382-432E-8A3A-9BE2F231470C
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLog.dll

using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.InteropServices;

namespace RFQLog.Helpers
{
  public class NetworkConnection : IDisposable
  {
    private readonly string _networkName;

    public event EventHandler<EventArgs> Disposed;

    public NetworkConnection(string networkName, NetworkCredential credentials)
    {
      this._networkName = networkName;
      int error = NetworkConnection.WNetAddConnection2(new NetResource()
      {
        Scope = ResourceScope.GlobalNetwork,
        ResourceType = ResourceType.Disk,
        DisplayType = ResourceDisplaytype.Share,
        RemoteName = networkName.TrimEnd('\\')
      }, credentials.Password, credentials.UserName, 0);
      if (error != 0)
        throw new Win32Exception(error);
    }

    ~NetworkConnection()
    {
      this.Dispose(false);
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        EventHandler<EventArgs> disposed = this.Disposed;
        if (disposed != null)
          disposed((object) this, EventArgs.Empty);
      }
      NetworkConnection.WNetCancelConnection2(this._networkName, 0, true);
    }

    [DllImport("mpr.dll")]
    private static extern int WNetAddConnection2(NetResource netResource, string password, string username, int flags);

    [DllImport("mpr.dll")]
    private static extern int WNetCancelConnection2(string name, int flags, bool force);
  }
}
