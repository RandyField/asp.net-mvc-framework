using BLL;
using BLL.Session;
using Common.WebHelper;
using EFModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 获取用户Session
        /// </summary>
        public UserSession UserSession
        {
            get { return SessionHelper.Get("Account") as UserSession; }
        }

        /// <summary>
        /// 获取当前页面的按钮
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public void GetButtonPage(string menucode)
        {
            List<SYS_BUTTON> list = SYS_ROLE_MENU_BUTTON_BLL.getInstance().GetButtonByUserIdMenuCode(menucode, UserSession.AccountInfo.UserID);
            this.ViewData["PageBtnList"] = list;
        }

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
            this.ViewData["RootMenus"] = this.UserSession.Menulist.Where(p => p.ParentCode == "00").ToList();
            this.ViewData["OtherMenus"] = this.UserSession.Menulist.Where(p => p.ParentCode != "00").ToList();
            this.ViewData["Logininfo"] = this.UserSession.logininfo;
        }

        /// <summary>
        /// 当前位置
        /// </summary>
        public void Location(string firstmenu, string secondmenu)
        {
            ViewBag.First = firstmenu;
            ViewBag.Second = secondmenu;
        }
    }
}
