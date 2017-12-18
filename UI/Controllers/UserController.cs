using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class UserController : BaseController
    {

        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            GetMenu(); //获取菜单
            Location("系统管理", "用户管理"); //当前位置
            ViewBag.Title = "User Page - 用户管理"; //页面标题
            return View();
        }

    }
}
