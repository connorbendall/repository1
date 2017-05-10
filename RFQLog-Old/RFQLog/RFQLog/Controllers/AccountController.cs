// Decompiled with JetBrains decompiler
// Type: RFQLog.Controllers.AccountController
// Assembly: RFQLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 25B8AF27-D382-432E-8A3A-9BE2F231470C
// Assembly location: C:\Users\ckurtz\Documents\Projects\RFQLog\bin\RFQLog.dll

using System.Web.Mvc;

namespace RFQLog.Controllers
{
  public class AccountController : Controller
  {
    public ActionResult Login()
    {
      return (ActionResult) this.View();
    }

    [HttpPost]
    public ActionResult Login(string password)
    {
      if (password == "m@pass")
        this.Session["loginStatus"] = (object) "logged in";
      else
        this.Session["loginStatus"] = (object) "not logged in";
      return (ActionResult) this.RedirectToAction("Index", "Home");
    }

    public ActionResult Logout()
    {
      this.Session["loginStatus"] = (object) "not logged in";
      return (ActionResult) this.RedirectToAction("Index", "Home");
    }
  }
}
