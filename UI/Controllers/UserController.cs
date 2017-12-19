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
    public class UserController : BaseController
    {
        SYS_USER_BLL bll = SYS_USER_BLL.getInstance();
        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        [AuthorityFilter]
        public ActionResult Index()
        {
            //GetMenu(); //获取菜单
            Location("系统管理", "用户管理"); //当前位置
            ViewBag.Title = "User Page - 用户管理"; //页面标题
            return View();
        }

        public string Search(jqDatatable dtparam)
        {
            try
            {
                //页面大小
                int pageSize = dtparam.length;

                //页面索引
                int pageIndex = dtparam.pageIndex;

                //记录总数
                int recordCount = 0;

                //页面总数
                int pageCount = 0;

                //数据Datatable
                DataTable dt = bll.PageQuery(null, 1, 12, out recordCount, out pageCount);
                dtparam.data = dt;
                dtparam.recordsTotal = recordCount;
                dtparam.recordsFiltered = recordCount;

                //序列化
                string searchdata = JsonConvert.SerializeObject(dtparam);

                return searchdata;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}
