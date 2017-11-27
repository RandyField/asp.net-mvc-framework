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
    /// <summary>
    /// SYS_CONFIG_BLL
    /// Author:ZhangDeng
    /// </summary>
    public class SYS_CONFIG_BLL
    {
        #region 单例模式


        /// <summary>
        /// 创建bll的一个对象
        /// </summary>
        private static SYS_CONFIG_BLL instance;

        /// <summary>
        /// 私有构造函数，该类无法被实例化
        /// </summary>
        private SYS_CONFIG_BLL() { }

        /// <summary>
        /// 线程锁
        /// </summary>
        private static object asyncLock = new object();

        /// <summary>
        /// 获取一个可用的对象
        /// </summary>
        /// <returns></returns>
        public static SYS_CONFIG_BLL getInstance()
        {
            if (instance == null)
            {
                instance = new SYS_CONFIG_BLL();
            }

            return instance;
        }

        #endregion

        #region 通用


        /// <summary>
        /// 根据id获取实体
        /// </summary>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        public SYS_CONFIG GetById(string permissionId)
        {
            SYS_CONFIG model = null;
            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    int id = Convert.ToInt32(permissionId);
                    Expression<Func<SYS_CONFIG, bool>> exp = a => a.ID == id;
                    model = dbcontext.Get(exp);
                }
                catch (Exception ex) 
                {
                    Logger.Error(string.Format("SYS_CONFIG_BLL 根据主键获取实体异常,异常信息:{0}", ex.ToString()));
                }
            }
            return model;
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public List<SYS_CONFIG> GetList(SYS_CONFIG querymodel)
        {
            List<SYS_CONFIG> list = null;
            using (var dbcontext = DbFactory.Create())
            {
                try
                {
                    
                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("SYS_CONFIG_BLL 根据条件获取列表,异常信息:{0}", ex.ToString()));
                }
                //待补充 读取字典 包装linq查询条件
            }
            return list;
        }

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(SYS_CONFIG model)
        {
            bool success = false;
            try
            {
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

                        throw;
                    }
                  
                }
            }
            catch (Exception ex)
            {
                success = false;
                Logger.Error(string.Format("SYS_CONFIG_BLL 新增异常,异常信息:{0}", ex.ToString()));
            }
            return success;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Remove(SYS_CONFIG model)
        {
            bool success = false;
            try
            {
                using (var dbcontext = DbFactory.Create())
                {
                    dbcontext.Insert(model);
                    dbcontext.Save();
                    success = true;
                }
            }
            catch (Exception ex)
            {
                success = false;
                Logger.Error(string.Format("SYS_CONFIG_BLL 删除异常,异常信息:{0}", ex.ToString()));
            }
            return success;
        }

        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remove(string id)
        {

            bool success = false;
            try
            {
                using (var dbcontext = DbFactory.Create())
                {
                    //待补充
                }
            }
            catch (Exception ex)
            {
                success = false;
                Logger.Error(string.Format("SYS_CONFIG_BLL 删除异常,异常信息:{0}", ex.ToString()));
            }
            return success;
        }

        /// <summary>
        /// 按条件删除
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool BulkRemove(SYS_CONFIG deletemodel)
        {
            bool success = false;
            try
            {
                using (var dbcontext = DbFactory.Create())
                {
                    //待补充 读取字典 包装linq查询条件
                }
            }
            catch (Exception ex)
            {
                success = false;
                Logger.Error(string.Format("SYS_CONFIG_BLL 按条件删除异常,异常信息:{0}", ex.ToString()));
            }
            return success;
        }

        /// <summary>
        /// 编辑记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit(SYS_CONFIG model)
        {
            bool success = false;
            try
            {
                using (var dbcontext = DbFactory.Create())
                {
                    dbcontext.Update(model);
                    dbcontext.Save();
                    success = true;
                }
            }
            catch (Exception ex)
            {
                success = false;
                Logger.Error(string.Format("SYS_CONFIG_BLL 编辑记录异常,异常信息:{0}", ex.ToString()));
            }

            return success;
        }

        /// <summary>
        /// 按条件更新
        /// </summary>
        /// <param name="exp">更新</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public bool Update(Dictionary<string, object> expdic, Dictionary<string, object> condic)
        {
            bool success = false;
            try
            {
                using (var dbcontext = DbFactory.Create())
                {
                    //待补充 读取字典 包装linq查询条件
                }
            }
            catch (Exception ex)
            {
                success = false;
                Logger.Error(string.Format("SYS_CONFIG_BLL 按条件更新,异常信息:{0}", ex.ToString()));
            }

            return success;
        }


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="modle"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public DataTable PageQuery(SYS_CONFIG model, int pageIndex, int pageSize, out int recordCount, out int pageCount)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var dbcontext = DbFactory.Create())
                {
                    SearchCondition condition = new SearchCondition();
                    if (model != null)
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
            }
            catch (Exception ex)
            {
                recordCount = 0;
                pageCount = 0;
                Logger.Error(string.Format("Zhp_GameCount_BLL 分页查询异常，异常信息：{0}", ex.ToString()));
            }
            return dt;
        }
        #endregion
    }
}
