using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFModel;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data;
using Common.Helper;
using System.Data.Common;

namespace IDAL
{
    public interface I_Base_DAL : IDisposable
    {
 
        #region 新增
        /// <summary>
        /// 插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Insert<T>(T entity) where T : class;


        #endregion

        #region 删除

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Delete<T>(T entity) where T : class;

        /// <summary>
        /// 按条件删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conditions"></param>
        void Delete<T>(Expression<Func<T, bool>> conditions) where T : class;

        #endregion

        #region 修改

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Update<T>(T entity) where T : class;

        /// <summary>
        /// 按条件更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <param name="dic"></param>
        void Update<T>(Expression<Func<T, bool>> where, Dictionary<string, object> dic) where T : class;
        #endregion

        #region 查询

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IQueryable<T> All<T>() where T : class;

        /// <summary>
        /// 按条件获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conditions"></param>
        /// <returns></returns>
        T Get<T>(Expression<Func<T, bool>> conditions) where T : class;

        /// <summary>
        /// 按条件获取集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conditions"></param>
        /// <returns></returns>
        List<T> Find<T>(Expression<Func<T, bool>> conditions = null) where T : class;

        /// <summary>
        /// sql查询获取集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        List<T> SqlQuery<T>(string sql);

        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteSqlCommand(string sql);
        #endregion

        #region 保存
        void Save();

        int SaveChanges();
        #endregion

        DataTable PageQuery(PagerInfo info, out int total, out int pagecount);

        //long GetNextSequenceValue(string sequenceName);


        //List<T> PageQuery<T, TKey>(int pageIndex, int pageSize, out int recordTotal, out int pageCount, Expression<Func<T, bool>> whLamdba, Expression<Func<T, TKey>> orderBy, bool isDescending = true) where T : class;

        //IEnumerable<T> getSearchListByPage<T, TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderBy, int pageSize, int pageIndex) where T : class;
    }
}
