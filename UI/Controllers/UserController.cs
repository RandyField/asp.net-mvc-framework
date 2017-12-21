using BLL;
using Common;
using EFModel;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Attribute;

namespace UI.Controllers
{
    public class UserController : BaseController
    {
        SYS_USER_BLL bll = SYS_USER_BLL.getInstance();
        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        [AuthorityFilter]
        public ActionResult Index(string menucode)
        {
            //GetMenu(); //获取菜单
            Location("系统管理", "用户管理"); //UI-当前位置
            ViewBag.Title = "User Page - 用户管理"; //UI-页面标题
            base.GetButtonPage(menucode);
            return View();
        }

        /// <summary>
        /// 用户查询
        /// </summary>
        /// <param name="dtparam"></param>
        /// <returns></returns>
        [AuthorityFilter]
        public string Search(jqDatatable dtparam, string username)
        {
            string searchdata = "";
            try
            {
                //页面大小
                int pageSize = dtparam.length;

                //页面索引
                int pageIndex = (dtparam.start + 1) / pageSize + 1;

                //记录总数
                int recordCount = 0;

                //页面总数
                int pageCount = 0;

                //数据Datatable
                DataTable dt = bll.PageQuery(username, pageIndex, pageSize, out recordCount, out pageCount);

                dtparam.data = dt;
                dtparam.recordsTotal = recordCount;
                dtparam.recordsFiltered = recordCount;

                //序列化             
                searchdata = JsonConvert.SerializeObject(dtparam);
            }
            catch (Exception ex)
            {
                Common.Helper.Logger.Info(string.Format("查询用户，查询异常，异常信息：{0}", ex.ToString()));
            }
            return searchdata;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AuthorityFilter]
        public ActionResult Delet(string id)
        {
            bool success = false;
            string msg = "";
            try
            {
                SYS_LOGIN loginmodel = SYS_LOGIN_BLL.getInstance().GetByUserID(id);
                if (loginmodel.State == 0)
                {
                    success = bll.Remove(id, loginmodel.ID);
                }
                else
                {
                    msg = "用户已在使用中，不能删除";
                }
            }
            catch (Exception ex)
            {
                Common.Helper.Logger.Info(string.Format("删除用户，删除异常，UserID-【0】异常信息：{1}", id, ex.ToString()));
                msg = "删除异常";
            }

            return this.Json(new
            {
                success = success,
                msg = msg
            });
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="usermodel"></param>
        /// <param name="loginmodel"></param>
        /// <returns></returns>
        [AuthorityFilter]
        public ActionResult Add(SYS_USER usermodel, SYS_LOGIN loginmodel)
        {
            bool success = false;
            string msg = "保存成功";
            try
            {
                if (!bll.IsExist(loginmodel.UserName))
                {
                    usermodel.CreateDate = DateTime.Now;
                    usermodel.CreateUserID = UserSession.AccountInfo.UserID;
                    loginmodel.CreateDate = DateTime.Now;
                    loginmodel.CreateUserID = UserSession.AccountInfo.UserID;
                    loginmodel.State = 0;
                    loginmodel.UserPassword = EncryptHelper.MD5DecryptString(loginmodel.UserPassword);
                    success = bll.SaveUser(usermodel, loginmodel);
                }
                else
                {
                    msg = "用户名已存在";
                }
            }
            catch (Exception ex)
            {
                Common.Helper.Logger.Info(string.Format("保存用户信息，保存异常，异常信息：{0}", ex.ToString()));
                msg = "保存异常";
            }
            return this.Json(new
            {
                success = success,
                msg = msg
            });
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AuthorityFilter]
        public string GetUser(string id)
        {
            string getdata = "";
            try
            {
                SYS_USER info = bll.GetById(id);
                getdata = JsonConvert.SerializeObject(info);
            }
            catch (Exception ex)
            {
                Common.Helper.Logger.Info(string.Format("获取用户信息，获取异常，UserID-【0】，异常信息：{1}", id, ex.ToString())); ;
            }
            return getdata;
        }

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="usermodel"></param>
        /// <param name="loginmodel"></param>
        /// <returns></returns>
        [AuthorityFilter]
        public ActionResult Edit(SYS_USER usermodel, SYS_LOGIN loginmodel)
        {
            bool success = false;
            string msg = "";
            try
            {
                //输入密码
                if (!string.IsNullOrWhiteSpace(loginmodel.UserPassword))
                {
                    loginmodel.UpdateDate = DateTime.Now;
                    loginmodel.UpdateUserID = UserSession.AccountInfo.UserID;
                    loginmodel.UserPassword = EncryptHelper.MD5DecryptString(loginmodel.UserPassword);
                }
                usermodel.UpdateDate = DateTime.Now;
                usermodel.UpdateUserID = UserSession.AccountInfo.UserID;
                success = bll.EditUser(usermodel, loginmodel);
            }
            catch (Exception ex)
            {
                Common.Helper.Logger.Info(string.Format("保存用户信息，保存异常，异常信息：{0}", ex.ToString()));
                msg = "保存异常";
            }
            return this.Json(new
            {
                success = success,
                msg = msg
            });
        }
    }
}
