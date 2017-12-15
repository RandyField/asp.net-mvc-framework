using BLL;
using BLL.Common;
using BLL.Session;
using Common.Helper;
using Common.WebHelper;
using EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            ViewBag.Title = "Login Page - 登录";
            return View();
        }

        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <param name="usercode"></param>
        /// <param name="remember"></param>
        /// <returns></returns>
        public ActionResult CheckLogin(string username, string pwd, string usercode, bool remember)
        {
            // 验证码如果不为空，则需要验证码判断
            if (!string.IsNullOrEmpty(usercode))
            {
                string valerror = string.Empty;
                //if (!ValiDateCode(0, usercode.ToUpper(), out valerror))
                //{
                //    return this.Json(new
                //    {
                //        success = false,
                //        error = valerror
                //    });
                //}
            }

            SYS_LOGIN para = new SYS_LOGIN();
            para.UserName = username;
            para.UserPassword = pwd;

            try
            {
                // 1.返回用户信息,权限信息,菜单信息等
                LoginState state = SYS_LOGIN_BLL.getInstance().CheckLogin(para);

                // 2.密码错误
                if (state == LoginState.PwdError)
                {
                    return this.Json(new
                    {
                        success = false,
                        error = "密码输入错误"
                    });
                }

                // 3.用户被禁用
                if (state == LoginState.AccountLock)
                {
                    return this.Json(new
                    {
                        success = false,
                        error = "用户已被禁用,请联系管理员"
                    });
                }

                // 4.账户不存在
                if (state == LoginState.AccountNoExist)
                {
                    return this.Json(new
                   {
                       success = false,
                       error = "账号不存在"
                   });
                }

                // 5.账户未授权
                if (state == LoginState.NoAuthorize)
                {
                    return this.Json(new
                    {
                        success = false,
                        error = "账号未经授权，请联系管理员"
                    });
                }

                // 用户选择记住账号
                if (remember)
                {
                    CookieHelper.SetCookie("username", username);
                }

                return this.Json(new
                {
                    success = true,
                });
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("【账号】-{0},登录异常，异常信息：{1}", username, ex.ToString()));
                return Json(new
                {
                    success = false,
                    error = ex.Message
                });
            }
        }

        public ActionResult Logout()
        {
            ClearSession();
            return RedirectToAction("Index");
        }
    }
}
