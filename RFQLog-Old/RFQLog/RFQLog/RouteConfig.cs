// Decompiled with JetBrains decompiler
// Type: RFQLog.RouteConfig
// Assembly: RFQLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 25B8AF27-D382-432E-8A3A-9BE2F231470C
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLog.dll

using System.Web.Mvc;
using System.Web.Routing;

namespace RFQLog
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
      routes.MapRoute("Default", "{controller}/{action}/{id}", (object) new
      {
        controller = "Home",
        action = "Index",
        id = UrlParameter.Optional
      });
      routes.MapRoute("Create", "{controller}/{action}/{id}", (object) new
      {
        controller = "RFQLog",
        action = "Create",
        id = UrlParameter.Optional
      });
      routes.MapRoute("Edit", "{controller}/{action}/{id}", (object) new
      {
        controller = "RFQLog",
        action = "Edit",
        id = UrlParameter.Optional
      });
      routes.MapRoute("Upload", "{controller}/{action}/{id}", (object) new
      {
        controller = "RFQLog",
        action = "Upload",
        id = UrlParameter.Optional
      });
      routes.MapRoute("Download", "{controller}/{action}/{id}", (object) new
      {
        controller = "RFQLog",
        action = "Download",
        id = UrlParameter.Optional
      });
      routes.MapRoute("Login", "{controller}/{action}/{id}", (object) new
      {
        controller = "Account",
        action = "Login",
        id = UrlParameter.Optional
      });
    }
  }
}
