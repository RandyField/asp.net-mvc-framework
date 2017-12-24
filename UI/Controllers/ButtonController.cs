using BLL;
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
    public class ButtonController : BaseController
    {
        SYS_BUTTON_BLL bll = SYS_BUTTON_BLL.getInstance();
        /// <summary>
        /// 加载页面
        /// </summary>
        /// <returns></returns>
        [AuthorityFilter]
        public ActionResult Index(string menucode)
        {
            Location("系统管理", "按钮管理"); //UI-当前位置
            ViewBag.Title = "User Page - 按钮管理"; //UI-页面标题
            base.GetButtonPage(menucode);
            base.GetRoleList();
            return View();
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="dtparam"></param>
        /// <returns></returns>
        [AuthorityFilter]
        public string Search(jqDatatable dtparam, string btnname)
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
                DataTable dt = bll.PageQuery(btnname, pageIndex, pageSize, out recordCount, out pageCount);

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
        /// 删除
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
                success = bll.Remove(id);
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
        public ActionResult Add(SYS_BUTTON btnmodel)
        {
            bool success = false;
            string msg = "保存成功";
            try
            {
                //if (!bll.IsExist(loginmodel.UserName))
                //{
                //    usermodel.CreateDate = DateTime.Now;
                //    usermodel.CreateUserID = UserSession.AccountInfo.UserID;
                //    loginmodel.CreateDate = DateTime.Now;
                //    loginmodel.CreateUserID = UserSession.AccountInfo.UserID;
                //    loginmodel.State = 0;
                //    loginmodel.UserPassword = EncryptHelper.MD5DecryptString(loginmodel.UserPassword);
                //    success = bll.SaveUser(usermodel, loginmodel);
                //}
                //else
                //{
                //    msg = "用户名已存在";
                //}
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
