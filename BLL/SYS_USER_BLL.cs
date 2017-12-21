using Common.Enum;
using Common.Helper;
using DAL;
using EFModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace BLL
{
    ///<summary>
    ///SYS_USER_BLL
    ///Author:ZhangDeng
    ///</summary>
    public class SYS_USER_BLL
    {
        #region 单例模式
        ///<summary>
        ///create bll instance
        ///</summary>
        private static SYS_USER_BLL instance;

        /// <summary>
        /// 私有构造函数，该类无法被实例化
        /// </summary>
        private SYS_USER_BLL() { }


        /// <summary>
        /// 线程锁
        /// </summary>
        private static object asyncLock = new object();

        /// <summary>
        /// 获取一个可用的对象
        /// </summary>
        /// <returns></returns>
        public static SYS_USER_BLL getInstance()
        {

            if (instance == null)
            {
                instance = new SYS_USER_BLL();
            }

            return instance;
        }
        #endregion

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="pkId">主键</param>
        /// <returns></returns>
        public SYS_USER GetById(string pkId)
        {
            SYS_USER model = null;
            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    int id = Convert.ToInt32(pkId);
                    Expression<Func<SYS_USER, bool>> exp = a => a.UserID == id;
                    model = dbcontext.Get(exp);
                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("SYS_USER_BLL 根据主键获取实体异常,异常信息:{0}", ex.ToString()));
                }
            }
            return model;
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="querymodel">条件</param>
        /// <returns></returns>
        public List<SYS_USER> GetList(SYS_USER querymodel)
        {
            List<SYS_USER> list = null;
            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    int id = Convert.ToInt32(querymodel.UserID);
                    Expression<Func<SYS_USER, bool>> exp = a => a.UserID == id;
                    Expression<Func<SYS_USER, bool>> temp = a => 1 == 1;
                    exp = CompileLinqSearch.AndAlso(exp, temp);
                    list = dbcontext.Find(exp);
                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("SYS_USER_BLL 根据条件获取列表异常,异常信息:{0}", ex.ToString()));
                }
            }
            return list;
        }

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="model">待新增实体</param>
        /// <returns></returns>
        public bool Add(SYS_USER model)
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

                    Logger.Error(string.Format("SYS_USER_BLL 新增记录异常,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="model">待删除实体</param>
        /// <returns></returns>
        public bool Remove(SYS_USER model)
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
                    Logger.Error(string.Format("SYS_USER_BLL 删除记录异常,异常信息:{0}", ex.ToString()));
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
        public bool Remove(string pkid,int loginid)
        {
            bool success = false;

            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    int id = Convert.ToInt32(pkid);
                    Expression<Func<SYS_USER, bool>> exp = a => a.UserID == id;
                    Expression<Func<SYS_LOGIN, bool>> exp1 = a => a.ID == loginid;
                    dbcontext.Delete(exp1);
                    dbcontext.Delete(exp);
                    dbcontext.Save();
                    success = true;
                }
                catch (Exception ex)
                {
                    success = false;
                    Logger.Error(string.Format("SYS_USER_BLL 根据id删除异常,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns></returns>
        public bool BulkRemove(Expression<Func<SYS_USER, bool>> exp)
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
                    Logger.Error(string.Format("SYS_USER_BLL 根据条件批量删除,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model">新实体</param>
        /// <returns></returns>
        public bool Edit(SYS_USER model)
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
                    Logger.Error(string.Format("SYS_USER_BLL 编辑记录异常,异常信息:{0}", ex.ToString()));
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
        public bool Update(Expression<Func<SYS_USER, bool>> exp, Dictionary<string, object> dic)
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
                    Logger.Error(string.Format("SYS_USER_BLL 按条件更新,异常信息:{0}", ex.ToString()));
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
        ///public List<SYS_USER> PageQuery<TKey>(int pageIndex, int pageSize, Expression<Func<SYS_USER, bool>> whLamdba,Expression<Func<SYS_USER, TKey>> orderByLamdba, out int recordCount, out int pageCount)
        ///{
        ///    List<SYS_USER> list = null;
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
        ///        Logger.Error(string.Format("SYS_USER_BLL 分页查询异常，异常信息：{0}", ex.ToString()));
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
        public DataTable PageQuery(string username, int pageIndex, int pageSize, out int recordCount, out int pageCount)
        {
            DataTable dt = new DataTable();
            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    SearchCondition condition = new SearchCondition();

                    #region 组装查询条件

                    if (!string.IsNullOrWhiteSpace(username))
                    {
                        condition.AddCondition("A.UserName", username, SqlOperator.Like, true);                      
                    }
                    condition.AddCondition("A.UserName", "admin", SqlOperator.NotEqual, true);
                    #endregion

                    PagerInfo pager = new PagerInfo();

                    #region 组装存储过程调用参数

                    pager.curPage = pageIndex;
                    pager.pageSize = pageSize;
                    pager.isDescending = true;
                    pager.fields = "A.*,B.State";
                    pager.sortField = "A.UserID";
                    pager.indexField = "A.UserID";
                    pager.where = null;
                    pager.condition = condition;
                    pager.tableName = " SYS_USER A INNER JOIN SYS_LOGIN B ON A.UserName=B.UserName ";

                    #endregion

                    dt = dbcontext.PageQuery(pager, out recordCount, out pageCount);
                }
                catch (Exception ex)
                {
                    recordCount = 0;
                    pageCount = 0;
                    Logger.Error(string.Format("SYS_USER_BLL 分页查询异常，异常信息：{0}", ex.ToString()));
                }
            }
            return dt;
        }

       
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsExist(string username)
        {
            bool success = false;

            using (var dbcontext = DbFactory.Create())
            {
                Expression<Func<SYS_USER, bool>> exp=a=>a.UserName==username;
                SYS_USER model = dbcontext.Get(exp);
                if (model!=null)
                {
                    success = true;
                }
            }
            return success;
        }

        /// <summary>
        /// 保存用户信息，登录信息
        /// </summary>
        /// <param name="usermodel"></param>
        /// <param name="loginmodel"></param>
        /// <returns></returns>
        public bool SaveUser(SYS_USER usermodel, SYS_LOGIN loginmodel)
        {
            bool success = false;

            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    dbcontext.Insert(usermodel);
                    dbcontext.Insert(loginmodel);
                    dbcontext.Save();
                    success = true;
                }
                catch (Exception ex)
                {
                    success = false;
                    Logger.Error(string.Format("SYS_USER_BLL 插入用户信息,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }

        /// <summary>
        /// 编辑用户信息，登录信息
        /// </summary>
        /// <param name="usermodel"></param>
        /// <param name="loginmodel"></param>
        /// <returns></returns>
        public bool EditUser(SYS_USER usermodel, SYS_LOGIN loginmodel)
        {
            bool success = false;

            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    //重置密码
                    if (!string.IsNullOrWhiteSpace(loginmodel.UserPassword))
                    {
                        dbcontext.Update(loginmodel);
                    }
                    dbcontext.Update(usermodel);
                    dbcontext.Save();
                    success = true;
                }
                catch (Exception ex)
                {
                    success = false;
                    Logger.Error(string.Format("SYS_USER_BLL 编辑用户信息,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }
    }
}