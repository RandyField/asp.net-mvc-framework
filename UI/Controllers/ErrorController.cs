using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ErrorController : BaseController
    {
        //
        // GET: /Error/

        public ActionResult Index()
        {
            Location("ace后台", "错误"); //当前位置
            ViewBag.Title = "Main Page - 错误 ";
            return View();
        }

    }
}
