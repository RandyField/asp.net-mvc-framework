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
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        [AuthorityFilter]
        public ActionResult Index()
        {
            GetMenu(); //获取菜单
            Location("ace后台", "首页"); //当前位置
            ViewBag.Title = "Main Page - 首页 ";
            return View();
        }

        public ActionResult Main()
        {
            Location("ace后台", "首页"); //当前位置
            return View();
        }

    }
}
