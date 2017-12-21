using BLL.Common;
using BLL.Session;
using Common;
using Common.Helper;
using Common.WebHelper;
using DAL;
using EFModel;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace BLL
{
    ///<summary>
    ///SYS_LOGIN_BLL
    ///Author:ZhangDeng
    ///</summary>
    public class SYS_LOGIN_BLL
    {
        #region 单例模式
        ///<summary>
        ///create bll instance
        ///</summary>
        private static SYS_LOGIN_BLL instance;

        /// <summary>
        /// 私有构造函数，该类无法被实例化
        /// </summary>
        private SYS_LOGIN_BLL() { }


        /// <summary>
        /// 线程锁
        /// </summary>
        private static object asyncLock = new object();

        /// <summary>
        /// 获取一个可用的对象
        /// </summary>
        /// <returns></returns>
        public static SYS_LOGIN_BLL getInstance()
        {

            if (instance == null)
            {
                instance = new SYS_LOGIN_BLL();
            }

            return instance;
        }
        #endregion

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="pkId">主键</param>
        /// <returns></returns>
        public SYS_LOGIN GetById(string pkId)
        {
            SYS_LOGIN model = null;
            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    int id = Convert.ToInt32(pkId);
                    Expression<Func<SYS_LOGIN, bool>> exp = a => a.ID == id;
                    model = dbcontext.Get(exp);
                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("SYS_LOGIN_BLL 根据主键获取实体异常,异常信息:{0}", ex.ToString()));
                }
            }
            return model;
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="querymodel">条件</param>
        /// <returns></returns>
        public List<SYS_LOGIN> GetList(SYS_LOGIN querymodel)
        {
            List<SYS_LOGIN> list = null;
            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    int id = Convert.ToInt32(querymodel.ID);
                    Expression<Func<SYS_LOGIN, bool>> exp = a => a.ID == id;
                    Expression<Func<SYS_LOGIN, bool>> temp = a => 1 == 1;
                    exp = CompileLinqSearch.AndAlso(exp, temp);
                    list = dbcontext.Find(exp);
                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("SYS_LOGIN_BLL 根据条件获取列表异常,异常信息:{0}", ex.ToString()));
                }
            }
            return list;
        }

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="model">待新增实体</param>
        /// <returns></returns>
        public bool Add(SYS_LOGIN model)
        {
            bool success = false;
            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    dbcontext.Insert(model);
                    dbcontext.Save();
                    success = true;
                }
                catch (Exception ex)
                {

                    Logger.Error(string.Format("SYS_LOGIN_BLL 新增记录异常,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="model">待删除实体</param>
        /// <returns></returns>
        public bool Remove(SYS_LOGIN model)
        {
            bool success = false;

            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    dbcontext.Insert(model);
                    dbcontext.Save();
                    success = true;
                }
                catch (Exception ex)
                {
                    success = false;
                    Logger.Error(string.Format("SYS_LOGIN_BLL 删除记录异常,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }

        /// <summary>
        /// 删除-注意主键要与数据库类型相同
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool Remove(string pkid)
        {
            bool success = false;

            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    int id = Convert.ToInt32(pkid);
                    Expression<Func<SYS_LOGIN, bool>> exp = a => a.ID == id;
                    dbcontext.Delete(exp);
                    dbcontext.Save();
                    success = true;
                }
                catch (Exception ex)
                {
                    success = false;
                    Logger.Error(string.Format("SYS_LOGIN_BLL 根据id删除异常,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns></returns>
        public bool BulkRemove(Expression<Func<SYS_LOGIN, bool>> exp)
        {
            bool success = false;

            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    dbcontext.BulkDelete(exp);
                    success = true;
                }
                catch (Exception ex)
                {
                    success = false;
                    Logger.Error(string.Format("SYS_LOGIN_BLL 根据条件批量删除,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model">新实体</param>
        /// <returns></returns>
        public bool Edit(SYS_LOGIN model)
        {
            bool success = false;

            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    dbcontext.Update(model);
                    dbcontext.Save();
                    success = true;
                }
                catch (Exception ex)
                {
                    success = false;
                    Logger.Error(string.Format("SYS_LOGIN_BLL 编辑记录异常,异常信息:{0}", ex.ToString()));
                }
            }
            return success;
        }

        /// <summary>
        /// 按条件更新
        /// </summary>
        /// <param name="exp">更新条件</param>
        /// <param name="dic">更新值</param>
        /// <returns></returns>
        public bool Update(Expression<Func<SYS_LOGIN, bool>> exp, Dictionary<string, object> dic)
        {
            bool success = false;

            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    dbcontext.Update(exp, dic);
                }
                catch (Exception ex)
                {
                    success = false;
                    Logger.Error(string.Format("SYS_LOGIN_BLL 按条件更新,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }

        ////// <summary>
        ////// 分页查询
        ////// </summary>
        ////// <param name="pageIndex"></param>
        ////// <param name="pageSize"></param>
        ////// <param name="whLamdba"></param>
        ////// <param name="recordCount"></param>
        ////// <param name="pageCount"></param>
        ////// <returns></returns>
        ///public List<SYS_LOGIN> PageQuery<TKey>(int pageIndex, int pageSize, Expression<Func<SYS_LOGIN, bool>> whLamdba,Expression<Func<SYS_LOGIN, TKey>> orderByLamdba, out int recordCount, out int pageCount)
        ///{
        ///    List<SYS_LOGIN> list = null;
        ///    try
        ///    {
        ///        if (pageIndex == 0)
        ///        {
        ///            pageIndex = 1;
        ///        }
        ///        list = idal.PageQuery(pageIndex, pageSize, out recordCount, out pageCount, whLamdba, orderByLamdba);
        ///    }
        ///    catch (Exception ex)
        ///    {
        ///        recordCount = 0;
        ///        pageCount = 0;
        ///        Logger.Error(string.Format("SYS_LOGIN_BLL 分页查询异常，异常信息：{0}", ex.ToString()));
        ///    }
        ///    return list;
        ///}

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="modle"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public DataTable PageQuery(SYS_LOGIN modle, int pageIndex, int pageSize, out int recordCount, out int pageCount)
        {
            DataTable dt = new DataTable();
            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    SearchCondition condition = new SearchCondition();
                    if (modle != null)
                    {
                        #region 组装查询条件

                        //if (!string.IsNullOrWhiteSpace(modle.PlayerNickname))
                        //{
                        //    condition.AddCondition("a.PlayerNickname", modle.PlayerNickname, SqlOperator.Like, true);                        
                        //}

                        #endregion
                    }
                    PagerInfo pager = new PagerInfo();
                    #region 组装存储过程调用参数


                    //pager.curPage = pageIndex;
                    //pager.pageSize = pageSize;
                    //pager.isDescending = true;
                    //pager.fields = "a.*,c.GameName";
                    //pager.sortField = "a.UploadTime";
                    //pager.indexField = "a.ID";
                    //pager.where = null;
                    //pager.condition = condition;
                    //pager.tableName = "[ZhpGame].[dbo].[Zhp_GameRecord] a left join  [Zhp_OnlineGame] b on a.Gameid=b.Gameid left join [Zhp_GameConfig] c on b.GameCode= c.GameCode ";

                    #endregion
                    dt = dbcontext.PageQuery(pager, out recordCount, out pageCount);
                }
                catch (Exception ex)
                {
                    recordCount = 0;
                    pageCount = 0;
                    Logger.Error(string.Format("SYS_LOGIN_BLL 分页查询异常，异常信息：{0}", ex.ToString()));
                }
            }
            return dt;
        }

        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public LoginState CheckLogin(SYS_LOGIN logininfo)
        {
            LoginState state = LoginState.NoLogin;
            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    Expression<Func<SYS_LOGIN, bool>> exp = a => a.UserName == logininfo.UserName;

                    SYS_LOGIN model = dbcontext.Get(exp);

                    if (model == null)
                    {

                        //账号不存在
                        state = LoginState.AccountNoExist;
                    }
                    else
                    {
                        string inputpwd = EncryptHelper.MD5DecryptString(logininfo.UserPassword);
                        if (inputpwd == model.UserPassword)
                        {
                            if (model.State == 1)
                            {

                                //成功
                                state = LoginState.Success;
                                SaveSession(model);
                            }
                            else if (model.State == 0)
                            {

                                //未授权
                                state = LoginState.NoAuthorize;
                            }
                            else if (model.State == 2)
                            {

                                //账号锁定
                                state = LoginState.AccountLock;
                            }

                        }
                        else
                        {

                            //密码错误
                            state = LoginState.PwdError;
                        }
                    }


                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("【账号】-{0},登录异常，异常信息：{1}", logininfo.UserName, ex.ToString()));
                }
            }
            return state;
        }

        /// <summary>
        /// 存入Session
        /// </summary>
        /// <param name="LoginID"></param>
        public void SaveSession(SYS_LOGIN loginmodel)
        {
            List<UserMenuModel> mennulist = null;
            SYS_USER usermodel = null;
            List<SYS_ROLE> userrolelist = null;
            using (var dbcontext = DbFactory.Create())
            {
                #region 获取用户菜单

                var args1 = new DbParameter[] {  
                                      new SqlParameter { ParameterName = "@id", Value = loginmodel.ID},  
                                  };

                StringBuilder strmenuSql = new StringBuilder();
                strmenuSql.Append(" SELECT distinct(M.MenuCode),M.MenuName,M.ParentCode,M.LinkAddress,M.Sort,M.IconScript FROM  [SYS_USER]  U ");
                strmenuSql.Append(" INNER JOIN [SYS_LOGIN] L ON L.UserName =U.UserName");
                strmenuSql.Append(" INNER JOIN [SYS_ROLE_USER] R ON R.UserID=U.UserID");
                strmenuSql.Append(" INNER JOIN [SYS_ROLE_MENU_BUTTON] MB ON R.RoleID=MB.RoleID");
                strmenuSql.Append(" INNER JOIN [SYS_MENU] M ON M.MenuCode=MB.MenuCode WHERE L.ID=@id order by M.ParentCode,M.Sort");
                mennulist = dbcontext.SqlQuery<UserMenuModel>(strmenuSql.ToString(), args1);

                #endregion

                #region 获取用户信息
                Expression<Func<SYS_USER, bool>> exp = a => a.UserName == loginmodel.UserName;
                usermodel = dbcontext.Get(exp);
                #endregion

                #region 获取用户角色
                var args2 = new DbParameter[] {  
                                      new SqlParameter { ParameterName = "@userid", Value = usermodel.UserID},  
                                  };
                StringBuilder strroleSql1 = new StringBuilder();
                strroleSql1.Append(" SELECT R.* FROM [SYS_ROLE_USER] RU");
                strroleSql1.Append(" INNER JOIN [SYS_USER] U ON RU.UserID=U.UserID");
                strroleSql1.Append(" INNER JOIN [SYS_ROLE] R ON R.RoleID=RU.RoleID");
                strroleSql1.Append(" WHERE U.UserID=@userid");
                userrolelist = dbcontext.SqlQuery<SYS_ROLE>(strroleSql1.ToString(), args2);
                #endregion

                UserSession user = new UserSession();
                user.Rolelist = userrolelist;
                user.Menulist = mennulist;
                user.AccountInfo = usermodel;
                user.logininfo = loginmodel;

                SessionHelper.Add("Account", user, 30);


            }
        }


        /// <summary>
        /// 获取登录信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SYS_LOGIN GetByUserID(string id)
        {
            SYS_LOGIN model = null;
            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    string username=SYS_USER_BLL.getInstance().GetById(id).UserName;
                    Expression<Func<SYS_LOGIN, bool>> exp = a => a.UserName == username;
                    model = dbcontext.Get(exp);
                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("判断用户是否授权,异常，异常信息：UserID-【0】-{1}", id, ex.ToString()));
                }
            }

            return model;
        }

    }
}