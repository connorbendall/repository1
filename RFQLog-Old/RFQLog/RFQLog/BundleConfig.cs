// Decompiled with JetBrains decompiler
// Type: RFQLog.BundleConfig
// Assembly: RFQLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 25B8AF27-D382-432E-8A3A-9BE2F231470C
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLog.dll

using System.Web.Optimization;

namespace RFQLog
{
  public class BundleConfig
  {
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js", new IItemTransform[0]));
      bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*", new IItemTransform[0]));
      bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate.unobtrusive*", new IItemTransform[0]));
      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*", new IItemTransform[0]));
      bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(new string[2]
      {
        "~/Scripts/bootstrap.js",
        "~/Scripts/respond.js"
      }));
      bundles.Add(new StyleBundle("~/Content/css").Include(new string[2]
      {
        "~/Content/bootstrap.css",
        "~/Content/site.css"
      }));
      bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui-{version}.js", new IItemTransform[0]));
      bundles.Add(new StyleBundle("~/Content/jqueryui").Include("~/Content/themes/base/all.css", new IItemTransform[0]));
    }
  }
}
