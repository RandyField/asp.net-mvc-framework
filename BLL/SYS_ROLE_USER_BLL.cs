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
    ///SYS_ROLE_USER_BLL
    ///Author:ZhangDeng
    ///</summary>
    public class SYS_ROLE_USER_BLL
    {
        #region 单例模式
        ///<summary>
        ///create bll instance
        ///</summary>
        private static SYS_ROLE_USER_BLL instance;

        /// <summary>
        /// 私有构造函数，该类无法被实例化
        /// </summary>
        private SYS_ROLE_USER_BLL() { }


        /// <summary>
        /// 线程锁
        /// </summary>
        private static object asyncLock = new object();

        /// <summary>
        /// 获取一个可用的对象
        /// </summary>
        /// <returns></returns>
        public static SYS_ROLE_USER_BLL getInstance()
        {

            if (instance == null)
            {
                instance = new SYS_ROLE_USER_BLL();
            }

            return instance;
        }
        #endregion

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="pkId">主键</param>
        /// <returns></returns>
        public SYS_ROLE_USER GetById(string pkId)
        {
            SYS_ROLE_USER model = null;
            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    int id = Convert.ToInt32(pkId);
                    Expression<Func<SYS_ROLE_USER, bool>> exp = a => a.ID == id;
                    model = dbcontext.Get(exp);
                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("SYS_ROLE_USER_BLL 根据主键获取实体异常,异常信息:{0}", ex.ToString()));
                }
            }
            return model;
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        public List<SYS_ROLE_USER> GetList(string userid)
        {
            List<SYS_ROLE_USER> list = null;
            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    int id = Convert.ToInt32(userid);
                    Expression<Func<SYS_ROLE_USER, bool>> exp = a => a.UserID == id;
                    list = dbcontext.Find(exp);
                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("SYS_ROLE_USER_BLL 根据条件获取列表异常,异常信息:{0}", ex.ToString()));
                }
            }
            return list;
        }

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="model">待新增实体</param>
        /// <returns></returns>
        public bool Add(SYS_ROLE_USER model)
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

                    Logger.Error(string.Format("SYS_ROLE_USER_BLL 新增记录异常,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="model">待新增实体</param>
        /// <returns></returns>
        public bool BulkAdd(List<SYS_ROLE_USER> list, string userid)
        {
            bool success = false;
            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    foreach (var item in list)
                    {
                        Expression<Func<SYS_ROLE_USER, bool>> exp = a => a.UserID == item.UserID;
                        Expression<Func<SYS_ROLE_USER, bool>> exp1 = a => a.RoleID == item.RoleID;
                        exp = CompileLinqSearch.AndAlso(exp, exp1);
                        if (dbcontext.Get(exp) == null)
                        {
                            dbcontext.Insert(item);
                        }
                    }

                    //改变授权状态
                    SYS_LOGIN loginmodel = SYS_LOGIN_BLL.getInstance().GetByUserID(userid);
                    loginmodel.State = 1;
                    dbcontext.Update(loginmodel);

                    //保存
                    dbcontext.Save();
                    success = true;
                }
                catch (Exception ex)
                {

                    Logger.Error(string.Format("SYS_ROLE_USER_BLL 新增记录异常,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="model">待删除实体</param>
        /// <returns></returns>
        public bool Remove(SYS_ROLE_USER model)
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
                    Logger.Error(string.Format("SYS_ROLE_USER_BLL 删除记录异常,异常信息:{0}", ex.ToString()));
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
                    Expression<Func<SYS_ROLE_USER, bool>> exp = a => a.ID == id;
                    dbcontext.Delete(exp);
                    dbcontext.Save();
                    success = true;
                }
                catch (Exception ex)
                {
                    success = false;
                    Logger.Error(string.Format("SYS_ROLE_USER_BLL 根据id删除异常,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns></returns>
        public bool BulkRemove(Expression<Func<SYS_ROLE_USER, bool>> exp)
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
                    Logger.Error(string.Format("SYS_ROLE_USER_BLL 根据条件批量删除,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model">新实体</param>
        /// <returns></returns>
        public bool Edit(SYS_ROLE_USER model)
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
                    Logger.Error(string.Format("SYS_ROLE_USER_BLL 编辑记录异常,异常信息:{0}", ex.ToString()));
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
        public bool Update(Expression<Func<SYS_ROLE_USER, bool>> exp, Dictionary<string, object> dic)
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
                    Logger.Error(string.Format("SYS_ROLE_USER_BLL 按条件更新,异常信息:{0}", ex.ToString()));
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
        ///public List<SYS_ROLE_USER> PageQuery<TKey>(int pageIndex, int pageSize, Expression<Func<SYS_ROLE_USER, bool>> whLamdba,Expression<Func<SYS_ROLE_USER, TKey>> orderByLamdba, out int recordCount, out int pageCount)
        ///{
        ///    List<SYS_ROLE_USER> list = null;
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
        ///        Logger.Error(string.Format("SYS_ROLE_USER_BLL 分页查询异常，异常信息：{0}", ex.ToString()));
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
        public DataTable PageQuery(SYS_ROLE_USER modle, int pageIndex, int pageSize, out int recordCount, out int pageCount)
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
                    Logger.Error(string.Format("SYS_ROLE_USER_BLL 分页查询异常，异常信息：{0}", ex.ToString()));
                }
            }
            return dt;
        }
    }
}