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
            base.GetRoleList();
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
                SYS_USER editmodel = SYS_USER_BLL.getInstance().GetById(usermodel.UserID.ToString());
                SYS_LOGIN logineditmodel = SYS_LOGIN_BLL.getInstance().GetByUserID(usermodel.UserID.ToString());
                //输入密码
                if (!string.IsNullOrWhiteSpace(loginmodel.UserPassword))
                {

                    loginmodel.UpdateDate = DateTime.Now;
                    loginmodel.UpdateUserID = UserSession.AccountInfo.UserID;
                    loginmodel.CreateUserID = logineditmodel.CreateUserID;
                    loginmodel.CreateDate = loginmodel.CreateDate;
                    loginmodel.UserPassword = EncryptHelper.MD5DecryptString(loginmodel.UserPassword);
                }
                usermodel.UpdateDate = DateTime.Now;
                usermodel.UpdateUserID = UserSession.AccountInfo.UserID;
                usermodel.CreateDate = editmodel.CreateDate;
                usermodel.CreateUserID = editmodel.CreateUserID;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AuthorityFilter]
        public ActionResult LockUser(string id)
        {
            bool success = false;
            string msg = "";
            try
            {
                SYS_LOGIN_BLL loginbll = SYS_LOGIN_BLL.getInstance();
                SYS_LOGIN model = loginbll.GetByUserID(id);
                if (model.State != 2 && model.State != 0)
                {
                    model.State = 2;
                    success = loginbll.Edit(model);
                }
                else if (model.State == 0)
                {
                    msg = "用户尚未授权,无法禁用";
                }
                else if (model.State == 2)
                {
                    msg = "用户已禁用,请勿重复禁用";
                }
            }
            catch (Exception ex)
            {
                Common.Helper.Logger.Info(string.Format("锁定用户保存异常，异常信息：{0}", ex.ToString()));
                msg = "锁定发生异常";
            }
            return this.Json(new
            {
                success = success,
                msg = msg
            });

        }
        /// <summary>
        /// 启用用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AuthorityFilter]
        public ActionResult StartUser(string id)
        {
            bool success = false;
            string msg = "";
            try
            {
                SYS_LOGIN_BLL loginbll = SYS_LOGIN_BLL.getInstance();
                SYS_LOGIN model = loginbll.GetByUserID(id);
                if (model.State == 2)
                {
                    model.State = 1;
                    success = loginbll.Edit(model);
                }
                else if (model.State == 0)
                {
                    msg = "用户尚未授权,无法启用";
                }
                else if (true)
                {
                    msg = "用户已启用,请勿重复启用";
                }
            }
            catch (Exception ex)
            {
                Common.Helper.Logger.Info(string.Format("启用用户保存异常，异常信息：{0}", ex.ToString()));
                msg = "启用用户发生异常";
            }
            return this.Json(new
            {
                success = success,
                msg = msg
            });
        }

        /// <summary>
        /// 获取用户所属角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetRole(string id)
        {
            string getdata = "";
            try
            {
                List<SYS_ROLE_USER> list = SYS_ROLE_USER_BLL.getInstance().GetList(id);
                getdata = JsonConvert.SerializeObject(list);
            }
            catch (Exception ex)
            {
                Common.Helper.Logger.Info(string.Format("获取用户所属角色列表，获取异常，UserID-【0】，异常信息：{1}", id, ex.ToString())); ;
            }
            return getdata;
        }

        /// <summary>
        /// 设置用户角色
        /// </summary>
        /// <param name="useruserid"></param>
        /// <param name="roleids"></param>
        /// <returns></returns>
        public ActionResult SetRole(string userid, string roleids)
        {
            bool success = false;
            string msg = "";
            try
            {
                List<SYS_ROLE_USER> list = new List<SYS_ROLE_USER>();

                string[] roleid = roleids.Split(',');
                foreach (var item in roleid)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        list.Add(new SYS_ROLE_USER
                        {
                            RoleID = Convert.ToInt32(item),
                            UserID = Convert.ToInt32(userid)
                        });
                    }                   
                }

                //设置用户角色
                success = SYS_ROLE_USER_BLL.getInstance().BulkAdd(list,userid);

               
            }
            catch (Exception ex)
            {
                Common.Helper.Logger.Info(string.Format("设置用户角色，设置异常，UserID-【0】异常信息：{1}", userid, ex.ToString()));
                msg = "设置异常";
            }

            return this.Json(new
            {
                success = success,
                msg = msg
            });
        }
    }
}
