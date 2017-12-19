using BLL.Session;
using Common.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 获取菜单
        /// </summary>
        public void ClearSession()
        {
            SessionHelper.Del("Account");
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        public void GetMenu()
        {
            UserSession userinfo = SessionHelper.Get("Account") as UserSession;
            this.ViewData["RootMenus"] = userinfo.Menulist.Where(p => p.ParentCode == "00").ToList();
            this.ViewData["OtherMenus"] = userinfo.Menulist.Where(p => p.ParentCode != "00").ToList();
            this.ViewData["Logininfo"] = userinfo.logininfo;
        }
        
        /// <summary>
        /// 获取菜单的按钮权限
        /// </summary>
        public void GetMenuBtn()
        {
            UserSession userinfo = SessionHelper.Get("Account") as UserSession;

                //this.ViewData["OtherMenus"] = userinfo.Menulist.Where(p => p.ParentCode != "00").ToList();
            //this.ViewData["Logininfo"] = userinfo.logininfo;
        }

        /// <summary>
        /// 当前位置
        /// </summary>
        public void Location(string firstmenu,string secondmenu)
        {
            ViewBag.First = firstmenu;
            ViewBag.Second = secondmenu;
        }
    }
}
