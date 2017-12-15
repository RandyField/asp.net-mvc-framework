using BLL.Session;
using Common.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Attribute;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [AuthorityFilter]
        public ActionResult Index()
        {
            UserSession userinfo = SessionHelper.Get("Account") as UserSession;
            this.ViewData["RootMenus"] = userinfo.Menulist.Where(p=>p.ParentCode=="00").ToList();
            this.ViewData["OtherMenus"] = userinfo.Menulist.Where(p => p.ParentCode != "00").ToList();
            this.ViewData["Logininfo"] = userinfo.logininfo;
            return View();
        }

    }
}
