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
	 	///SYS_BUG_FEEDBACK_BLL
		///Author:ZhangDeng
	///</summary>
	public class SYS_BUG_FEEDBACK_BLL
	{	
	    #region 单例模式
		///<summary>
		///create bll instance
		///</summary>
		private static SYS_BUG_FEEDBACK_BLL instance;
		
		/// <summary>
        /// 私有构造函数，该类无法被实例化
        /// </summary>
        private SYS_BUG_FEEDBACK_BLL() { }


        /// <summary>
        /// 线程锁
        /// </summary>
        private static object asyncLock = new object();

        /// <summary>
        /// 获取一个可用的对象
        /// </summary>
        /// <returns></returns>
        public static SYS_BUG_FEEDBACK_BLL getInstance()
        {

            if (instance == null)
            {
                instance = new SYS_BUG_FEEDBACK_BLL();
            }

            return instance;
        }
        #endregion
        
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="pkId">主键</param>
        /// <returns></returns>
        public SYS_BUG_FEEDBACK GetById(string pkId)
        {
            SYS_BUG_FEEDBACK model = null;
            using (var dbcontext = DbFactory.Create())
            {
	            try
	            {
	            	int id = Convert.ToInt32(pkId);
	            	Expression<Func<SYS_BUG_FEEDBACK, bool>> exp = a => a.ID == id;
                	model = dbcontext.Get(exp);
	            }
	            catch (Exception ex)
	            {
	                Logger.Error(string.Format("SYS_BUG_FEEDBACK_BLL 根据主键获取实体异常,异常信息:{0}", ex.ToString()));
	            }
            }
            return model;
        }
        
         /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <param name="querymodel">条件</param>
        /// <returns></returns>
         public List<SYS_BUG_FEEDBACK> GetList(SYS_BUG_FEEDBACK querymodel)
        {
            List<SYS_BUG_FEEDBACK> list = null;
            using (var dbcontext = DbFactory.Create())
            {
	            try
	            {
	                	int id = Convert.ToInt32(querymodel.ID);
	                    Expression<Func<SYS_BUG_FEEDBACK, bool>> exp = a => a.ID == id;
	                    Expression<Func<SYS_BUG_FEEDBACK, bool>> temp = a => 1 == 1;
	                    exp = CompileLinqSearch.AndAlso(exp, temp);
	                    list = dbcontext.Find(exp);
	            }
	            catch (Exception ex)
	            {
	                Logger.Error(string.Format("SYS_BUG_FEEDBACK_BLL 根据条件获取列表异常,异常信息:{0}", ex.ToString()));
	            }
	        }
            return list;
        }
        
        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="model">待新增实体</param>
        /// <returns></returns>
        public bool Add(SYS_BUG_FEEDBACK model)
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

                    Logger.Error(string.Format("SYS_BUG_FEEDBACK_BLL 新增记录异常,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }

		/// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="model">待删除实体</param>
        /// <returns></returns>
		public bool Remove(SYS_BUG_FEEDBACK model)
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
                    Logger.Error(string.Format("SYS_BUG_FEEDBACK_BLL 删除记录异常,异常信息:{0}", ex.ToString()));
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
                    Expression<Func<SYS_BUG_FEEDBACK, bool>> exp = a => a.ID == id;
                    dbcontext.Delete(exp);
                    dbcontext.Save();
                    success = true;
                }
                catch (Exception ex)
                {
                    success = false;
                    Logger.Error(string.Format("SYS_BUG_FEEDBACK_BLL 根据id删除异常,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns></returns>
        public bool BulkRemove(Expression<Func<SYS_BUG_FEEDBACK, bool>> exp)
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
                    Logger.Error(string.Format("SYS_BUG_FEEDBACK_BLL 根据条件批量删除,异常信息:{0}", ex.ToString()));
                }
            }

            return success;
        }
        
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model">新实体</param>
        /// <returns></returns>
        public bool Edit(SYS_BUG_FEEDBACK model)
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
                    Logger.Error(string.Format("SYS_BUG_FEEDBACK_BLL 编辑记录异常,异常信息:{0}", ex.ToString()));
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
        public bool Update(Expression<Func<SYS_BUG_FEEDBACK, bool>> exp, Dictionary<string, object> dic)
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
                    Logger.Error(string.Format("SYS_BUG_FEEDBACK_BLL 按条件更新,异常信息:{0}", ex.ToString()));
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
        ///public List<SYS_BUG_FEEDBACK> PageQuery<TKey>(int pageIndex, int pageSize, Expression<Func<SYS_BUG_FEEDBACK, bool>> whLamdba,Expression<Func<SYS_BUG_FEEDBACK, TKey>> orderByLamdba, out int recordCount, out int pageCount)
        ///{
        ///    List<SYS_BUG_FEEDBACK> list = null;
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
        ///        Logger.Error(string.Format("SYS_BUG_FEEDBACK_BLL 分页查询异常，异常信息：{0}", ex.ToString()));
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
        public DataTable PageQuery(SYS_BUG_FEEDBACK modle,int pageIndex, int pageSize, out int recordCount, out int pageCount)
        {
            DataTable dt = new DataTable();
            using (var dbcontext = DbFactory.Create())
            {
	            try
	            {
	                SearchCondition condition = new SearchCondition();
	                if (modle!=null)
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
	                Logger.Error(string.Format("SYS_BUG_FEEDBACK_BLL 分页查询异常，异常信息：{0}", ex.ToString()));
	            }
	        }
            return dt;
        }
	}
}