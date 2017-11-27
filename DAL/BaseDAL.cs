using Common;
using Common.Enum;
using Common.Helper;
using IDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDAL : I_Base_DAL, IDisposable
    {
        #region 变量

        private DbContext dbcontext;

        #endregion

        #region 构造函数

        public BaseDAL(DbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        #endregion

        #region 实现接口

        #region 新增

        /// <summary>
        /// 插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Insert<T>(T entity) where T : class
        {
            dbcontext.Set<T>().Add(entity);
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="list"></param>
        public virtual void BulkInsert<T>(List<T> list) where T : class
        {
            //表名
            var tblName = typeof(T).Name;
            BulkInsert(dbcontext.Database.Connection.ConnectionString, tblName, list);
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="tableName"></param>
        /// <param name="list"></param>
        public static void BulkInsert<T>(string connection, string tableName, IList<T> list) where T : class
        {
            using (var bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.BatchSize = list.Count;
                bulkCopy.DestinationTableName = tableName;

                var table = new DataTable();
                var props = TypeDescriptor.GetProperties(typeof(T))
                    //Dirty hack to make sure we only have system data types
                    //i.e. filter out the relationships/collections
                                           .Cast<PropertyDescriptor>()
                                           .Where(propertyInfo => propertyInfo.PropertyType.Namespace != null
                                               && propertyInfo.PropertyType.Namespace.Equals("System"))
                                           .ToArray();

                foreach (var propertyInfo in props)
                {
                    bulkCopy.ColumnMappings.Add(propertyInfo.Name, propertyInfo.Name);
                    table.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
                }

                var values = new object[props.Length];
                foreach (var item in list)
                {
                    for (var i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }

                    table.Rows.Add(values);
                }

                bulkCopy.WriteToServer(table);
            }
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Delete<T>(T entity) where T : class
        {
            var entry = dbcontext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                dbcontext.Set<T>().Attach(entity);
            }
            entry.State = EntityState.Deleted;
            dbcontext.Set<T>().Remove(entity);
        }

        /// <summary>
        /// 按条件删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conditions"></param>
        public void Delete<T>(Expression<Func<T, bool>> conditions) where T : class
        {
            var list = Find<T>(conditions);
            foreach (var item in list)
            {
                Delete<T>(item);
            }

        }

        /// <summary>
        /// 按条件批量删除
        /// </summary>
        /// <param name="exp"></param>
        public virtual void BulkDelete<T>(Expression<Func<T, bool>> exp) where T : class       
        {
            dbcontext.Set<T>().RemoveRange(FindBy(exp));
        }

        #endregion

        #region 修改

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Update<T>(T entity) where T : class
        {
            var entry = dbcontext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                dbcontext.Set<T>().Attach(entity);
            }
            entry.State = EntityState.Modified;
        }

        /// <summary>
        /// 按条件修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <param name="dic"></param>
        public void Update<T>(Expression<Func<T, bool>> where, Dictionary<string, object> dic) where T : class
        {
            IEnumerable<T> result = dbcontext.Set<T>().Where(where).ToList();
            Type type = typeof(T);
            List<PropertyInfo> propertyList = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).ToList();
            //遍历结果集
            foreach (T entity in result)
            {
                foreach (PropertyInfo propertyInfo in propertyList)
                {
                    string propertyName = propertyInfo.Name;
                    if (dic.ContainsKey(propertyName))
                    {
                        //设置值
                        propertyInfo.SetValue(entity, dic[propertyName], null);
                    }
                }
            }
            dbcontext.SaveChanges();
        }

        #endregion

        #region 查询

        /// <summary>
        /// 所有
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> All<T>() where T : class
        {
            return dbcontext.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// 按条件获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public T Get<T>(Expression<Func<T, bool>> conditions) where T : class
        {
            return All<T>().FirstOrDefault(conditions);
        }

        /// <summary>
        /// 按条件获取集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public List<T> Find<T>(Expression<Func<T, bool>> conditions = null) where T : class
        {
            if (conditions != null)
            {
                return All<T>().Where(conditions).ToList();
            }
            else
            {
                return All<T>().ToList();
            }

        }

        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public virtual IQueryable<T> FindBy<T>(Expression<Func<T, bool>> exp) where T : class
        {
            return dbcontext.Set<T>().Where(exp);
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            dbcontext.Dispose();
        }

        #endregion

        #region 执行sql

        #region sqlserver数据库参数类型
        //var args = new DbParameter[] {  
        //                              new SqlParameter { ParameterName = "id", Value = id},  
        //                          };
        #endregion

        #region mysql数据库参数类型
        //var args = new DbParameter[] {  
        //                          new OdbcParameter { ParameterName = "id", Value = id},  
        //                      };  

        //     var args = new DbParameter[] {  
        //                               new MySqlParameter { ParameterName = "id", Value = "1"},  
        //                 };  
        #endregion

        #region access数据库参数类型
        //var args = new DbParameter[] {  
        //                          new OleDbParameter { ParameterName = "id", Value = id},  
        //                      };  
        #endregion

        /// <summary>
        /// 执行sql返回集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> SqlQuery<T>(string sql)
        {
            return dbcontext.Database.SqlQuery<T>(sql).ToList();
        }

        /// <summary>  
        /// 执行带参数sql语句返回数据列表  
        /// </summary>  
        /// <typeparam name="T">泛型</typeparam>  
        /// <param name="sql">sql语句</param>  
        /// <param name="args">参数</param>  
        /// <returns>数据列表</returns>  
        public List<T> SqlQuery<T>(string sql, DbParameter[] args)
        {
            if (string.IsNullOrEmpty(sql))
                return new List<T>();
            try
            {
                return dbcontext.Database.SqlQuery<T>(sql, args).ToList();
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }

        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteSqlCommand(string sql)
        {
            return dbcontext.Database.ExecuteSqlCommand(sql);
        }

        /// <summary>
        /// 执行sql返回datatable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable SqlQueryForDataTatable(string sql)
        {

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = dbcontext.Database.Connection.ConnectionString;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            conn.Close();//连接需要关闭  
            conn.Dispose();
            return table;
        }

        /// <summary>
        /// 执行sql返回datatable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable SqlQueryForDataTatable(string sql, DbParameter[] parameters)
        {
            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = dbcontext.Database.Connection.ConnectionString;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            if (parameters != null && parameters.Length > 0)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        #endregion

        #region 保存

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return dbcontext.SaveChanges();
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            dbcontext.SaveChanges();
        }

        #endregion

        #region 分页查询

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="conditions"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<T> Find<T, S>(Expression<Func<T, bool>> conditions, Expression<Func<T, S>> orderBy, int pageSize, int pageIndex, out int totalCount) where T : class
        {
            var queryList = conditions == null ?
                All<T>() :
                All<T>().Where(conditions);
            totalCount = queryList.Count();
            return queryList.OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }


        /// <summary>
        /// 分页查询-调用存储过程P_PagerQuery
        /// </summary>
        /// <param name="info"></param>
        /// <param name="total"></param>
        /// <param name="pagecount"></param>
        /// <returns></returns>
        public virtual DataTable PageQuery(PagerInfo info, out int total, out int pagecount)
        {
            string where = string.Empty;
            if (info.condition != null && info.condition.ConditionTable != null && info.condition.ConditionTable.Count > 0)
            {
                where = BuildConditionSql(info.condition.ConditionTable);
            }
            else
            {
                where = info.where == null ? "1=1" : info.where;
            }

            var paras = new List<SqlParameter>
                                {
                                    new SqlParameter("tblName", info.tableName),
                                    new SqlParameter("fldName", info.fields),
                                    new SqlParameter("pageSize", info.pageSize),
                                    new SqlParameter("pageIndex", info.curPage),
                                    new SqlParameter("keyName", info.indexField),                                   
                                    new SqlParameter("orderString", info.sortField),
                                    new SqlParameter("whereString", where),
                                    new SqlParameter("recordTotal", SqlDbType.Int){Direction = ParameterDirection.Output},
                                    new SqlParameter("pageTotal", SqlDbType.Int){Direction = ParameterDirection.Output}
                                };

            var conn = dbcontext.Database.Connection.ConnectionString;
            var ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure,
                                              "dbo.P_PagerQuery", paras.ToArray());
            total = paras[7].Value == DBNull.Value ? 0 : Convert.ToInt32(paras[7].Value);
            pagecount = paras[7].Value == DBNull.Value ? 0 : Convert.ToInt32(paras[8].Value);
            return ds.Tables[0];
        }

        #endregion

        #region 其他
        public long GetNextSequenceValue(string sequenceName)
        {
            var rawQuery = dbcontext.Database.SqlQuery<long>(string.Format("SELECT NEXT VALUE FOR {0}", sequenceName)).ToList();
            long nextVal = rawQuery.Single();

            return nextVal;
        }


      

        ///// <summary>
        ///// 批量删除
        ///// </summary>
        //public virtual void BulkDeleteAll()
        //{
        //    dbcontext.Set<T>().RemoveRange(IEnumerable<T> list);
        //}

        //    #region 分页查询

        //    /// <summary>
        //    /// EF分页查询
        //    /// </summary>
        //    /// <typeparam name="TKey"></typeparam>
        //    /// <param name="pageIndex"></param>
        //    /// <param name="pageSize"></param>
        //    /// <param name="recordTotal"></param>
        //    /// <param name="pageCount"></param>
        //    /// <param name="whLamdba"></param>
        //    /// <param name="orderBy"></param>
        //    /// <param name="isDescending"></param>
        //    /// <returns>List<U></returns>
        //    public virtual List<U> PageQuery<TKey>(int pageIndex, int pageSize, out int recordTotal, out int pageCount, Expression<Func<U, bool>> whLamdba, Expression<Func<U, TKey>> orderBy, bool isDescending = true)
        //    {
        //        try
        //        {
        //            IQueryable<U> list = dbcontext.Set<U>();

        //            list = list.Where(whLamdba);
        //            if (isDescending)
        //            {
        //                list = list.OrderByDescending(orderBy);
        //            }
        //            else
        //            {
        //                list = list.OrderBy(orderBy);
        //            }

        //            //总记录数
        //            recordTotal = list.Count();
        //            var result = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        //            pageCount = Convert.ToInt32(Math.Ceiling((double)recordTotal / (double)pageSize));

        //            return result;
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }


        //    /// <summary>
        //    ///  EF分页查询
        //    /// </summary>
        //    /// <typeparam name="TKey"></typeparam>
        //    /// <param name="where"></param>
        //    /// <param name="orderBy"></param>
        //    /// <param name="pageSize"></param>
        //    /// <param name="pageIndex"></param>
        //    /// <returns>IEnumerable<U></returns>
        //    public IEnumerable<U> getSearchListByPage<TKey>(Expression<Func<U, bool>> where, Expression<Func<U, TKey>> orderBy, int pageSize, int pageIndex)
        //    {
        //        return dbcontext.Set<U>().Where(where).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        //    }

        //    /// <summary>
        //    /// 分页查询-调用存储过程P_PagerQuery
        //    /// </summary>
        //    /// <param name="info"></param>
        //    /// <param name="total"></param>
        //    /// <param name="pagecount"></param>
        //    /// <returns></returns>
        //    public virtual DataTable PageQuery(PagerInfo info, out int total, out int pagecount)
        //    {
        //        string where = string.Empty;
        //        if (info.condition != null && info.condition.ConditionTable != null && info.condition.ConditionTable.Count > 0)
        //        {
        //            where = BuildConditionSql(info.condition.ConditionTable);
        //        }
        //        else
        //        {
        //            where = info.where == null ? "1=1" : info.where;
        //        }

        //        var paras = new List<SqlParameter>
        //                            {
        //                                new SqlParameter("tblName", info.tableName),
        //                                new SqlParameter("fldName", info.fields),
        //                                new SqlParameter("pageSize", info.pageSize),
        //                                new SqlParameter("pageIndex", info.curPage),
        //                                new SqlParameter("keyName", info.indexField),                                   
        //                                new SqlParameter("orderString", info.sortField),
        //                                new SqlParameter("whereString", where),
        //                                new SqlParameter("recordTotal", SqlDbType.Int){Direction = ParameterDirection.Output},
        //                                new SqlParameter("pageTotal", SqlDbType.Int){Direction = ParameterDirection.Output}
        //                            };

        //        var conn = dbcontext.Database.Connection.ConnectionString;
        //        var ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure,
        //                                          "dbo.P_PagerQuery", paras.ToArray());
        //        total = paras[7].Value == DBNull.Value ? 0 : Convert.ToInt32(paras[7].Value);
        //        pagecount = paras[7].Value == DBNull.Value ? 0 : Convert.ToInt32(paras[8].Value);
        //        return ds.Tables[0];
        //    }

        //    /// <summary>
        //    /// 分页查询-存储过程P_PagerQuery
        //    /// </summary>
        //    /// <param name="tblName"></param>
        //    /// <param name="pageNo"></param>
        //    /// <param name="pageSize"></param>
        //    /// <param name="fileds"></param>
        //    /// <param name="indexfield"></param>
        //    /// <param name="sort"></param>
        //    /// <param name="where"></param>
        //    /// <param name="total"></param>
        //    /// <param name="pagecount"></param>
        //    /// <returns></returns>
        //    public virtual DataTable PageQuery(string tblName, int pageNo, int pageSize, string fileds, string indexfield,
        //string sort, string where, out int total, out int pagecount)
        //    {
        //        var paras = new List<SqlParameter>
        //                            {
        //                                new SqlParameter("tblName", tblName),
        //                                new SqlParameter("fldName", fileds),
        //                                new SqlParameter("pageSize", pageSize),
        //                                new SqlParameter("pageIndex", pageNo),
        //                                new SqlParameter("keyName", indexfield),                                   
        //                                new SqlParameter("orderString", sort),
        //                                new SqlParameter("whereString", where),
        //                                new SqlParameter("recordTotal", SqlDbType.Int){Direction = ParameterDirection.Output},
        //                                new SqlParameter("pageTotal", SqlDbType.Int){Direction = ParameterDirection.Output}
        //                            };

        //        var conn = dbcontext.Database.Connection.ConnectionString;
        //        var ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure,
        //                                          "dbo.P_PagerQuery", paras.ToArray());
        //        total = paras[7].Value == DBNull.Value ? 0 : Convert.ToInt32(paras[7].Value);
        //        pagecount = paras[7].Value == DBNull.Value ? 0 : Convert.ToInt32(paras[8].Value);
        //        return ds.Tables[0];
        //    }


        //    /// <summary>
        //    /// 分页查询-存储过程P_PagerQuery
        //    /// </summary>
        //    /// <param name="tblName"></param>
        //    /// <param name="pageNo"></param>
        //    /// <param name="pageSize"></param>
        //    /// <param name="fileds"></param>
        //    /// <param name="indexfield"></param>
        //    /// <param name="sort"></param>
        //    /// <param name="where"></param>
        //    /// <param name="total"></param>
        //    /// <param name="pagecount"></param>
        //    /// <returns></returns>
        //    public virtual List<U> PageQueryList(string tblName, int pageNo, int pageSize, string fileds, string indexfield,
        //string sort, string where, out int total, out int pagecount)
        //    {
        //        var paras = new List<SqlParameter>
        //                            {
        //                                new SqlParameter("tblName", tblName),
        //                                new SqlParameter("fldName", fileds),
        //                                new SqlParameter("pageSize", pageSize),
        //                                new SqlParameter("pageIndex", pageNo),
        //                                new SqlParameter("keyName", indexfield),                                   
        //                                new SqlParameter("orderString", sort),
        //                                new SqlParameter("whereString", where),
        //                                new SqlParameter("recordTotal", SqlDbType.Int){Direction = ParameterDirection.Output},
        //                                new SqlParameter("pageTotal", SqlDbType.Int){Direction = ParameterDirection.Output}
        //                            };

        //        var conn = dbcontext.Database.Connection.ConnectionString;
        //        var ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure,
        //                                          "dbo.P_PagerQuery", paras.ToArray());
        //        total = paras[7].Value == DBNull.Value ? 0 : Convert.ToInt32(paras[7].Value);
        //        pagecount = paras[7].Value == DBNull.Value ? 0 : Convert.ToInt32(paras[8].Value);
        //        return DataTableToList<U>(ds.Tables[0], 0);
        //    }
        //    #endregion



        #region BuildSql
        /// <summary>
        /// 根据对象构造相关的条件语句（不使用参数），如返回的语句是:
        /// <![CDATA[
        /// Where (1=1)  AND Test4  <  'Value4' AND Test6  >=  'Value6' AND Test7  <=  'value7' AND Test  <>  '1' AND Test5  >  'Value5' AND Test2  Like  '%Value2%' AND Test3  =  'Value3'
        /// ]]>
        /// </summary>
        /// <returns></returns> 
        public string BuildConditionSql(Hashtable conditionTable)
        {
            if (conditionTable == null || conditionTable.Values == null || conditionTable.Values.Count < 1)
            {
                return "";
            }

            string sql = string.Empty;
            SearchInfo searchInfo = null;

            StringBuilder sb = new StringBuilder();
            sql += BuildGroupCondiction(conditionTable);

            foreach (DictionaryEntry de in conditionTable)
            {
                searchInfo = (SearchInfo)de.Value;

                //如果选择ExcludeIfEmpty为True,并且该字段为空值的话,跳过
                if (searchInfo.ExcludeIfEmpty &&
                    (searchInfo.FieldValue == null || string.IsNullOrEmpty(searchInfo.FieldValue.ToString())))
                {
                    continue;
                }

                //只有组别名称为空才继续，即正常的sql条件
                if (string.IsNullOrEmpty(searchInfo.GroupName))
                {
                    if (searchInfo.SqlOperator == SqlOperator.Like)
                    {
                        sb.AppendFormat(" AND {0} {1} '{2}'", searchInfo.FieldName,
                            this.ConvertSqlOperator(searchInfo.SqlOperator), string.Format("%{0}%", Strings.Trim(searchInfo.FieldValue)));
                    }
                    else if (searchInfo.SqlOperator == SqlOperator.NotLike)
                    {
                        sb.AppendFormat(" AND {0} {1} '{2}'", searchInfo.FieldName,
                            this.ConvertSqlOperator(searchInfo.SqlOperator), string.Format("%{0}%", Strings.Trim(searchInfo.FieldValue)));
                    }
                    else if (searchInfo.SqlOperator == SqlOperator.LikeStartAt)
                    {
                        sb.AppendFormat(" AND {0} {1} '{2}'", searchInfo.FieldName,
                            this.ConvertSqlOperator(searchInfo.SqlOperator), string.Format("{0}%", Strings.Trim(searchInfo.FieldValue)));
                    }
                    else if (searchInfo.SqlOperator == SqlOperator.LikeEndAt)
                    {
                        sb.AppendFormat(" AND {0} {1} '{2}'", searchInfo.FieldName,
                            this.ConvertSqlOperator(searchInfo.SqlOperator), string.Format("%{0}", Strings.Trim(searchInfo.FieldValue)));
                    }
                    else if (searchInfo.SqlOperator == SqlOperator.In)
                    {
                        sb.AppendFormat(" AND {0} {1} {2}", searchInfo.FieldName,
                            this.ConvertSqlOperator(searchInfo.SqlOperator), string.Format("({0})", Strings.Trim(searchInfo.FieldValue)));
                    }
                    else
                    {
                        #region 特殊sql操作
                        if (searchInfo.FieldValue != null && IsDate(searchInfo.FieldValue.ToString()))
                        {
                            //sb.AppendFormat(" AND {0} {1} to_date('{2}','YYYY-MM-dd')", searchInfo.FieldName,
                            //    this.ConvertSqlOperator(searchInfo.SqlOperator), Strings.Trim(searchInfo.FieldValue));


                            sb.AppendFormat(" AND {0} {1} cast('{2}' as date)", searchInfo.FieldName,
                                this.ConvertSqlOperator(searchInfo.SqlOperator), Strings.Trim(searchInfo.FieldValue));

                            //SELECT convert(datetime, '23 Oct 2016 11:02:07:577', 113) -- dd mon yyyy hh:mm:ss:mmm
                        }
                        else if (searchInfo.FieldValue != null && IsDateHourMinute(searchInfo.FieldValue.ToString()))
                        {
                            //sb.AppendFormat(" AND {0} {1} to_date('{2}','YYYY-MM-dd hh24:mi:ss')", searchInfo.FieldName,
                            //    this.ConvertSqlOperator(searchInfo.SqlOperator), Strings.Trim(searchInfo.FieldValue));
                            sb.AppendFormat(" AND {0} {1} cast('{2}' as date)", searchInfo.FieldName,
                                 this.ConvertSqlOperator(searchInfo.SqlOperator), Strings.Trim(searchInfo.FieldValue));
                        }
                        else if (!searchInfo.ExcludeIfEmpty)
                        {
                            //如果要进行空值查询的时候
                            if (searchInfo.SqlOperator == SqlOperator.Equal)
                            {
                                sb.AppendFormat(" AND ({0} is null or {0}='')", Strings.Trim(searchInfo.FieldName));
                            }
                            else if (searchInfo.SqlOperator == SqlOperator.NotEqual)
                            {
                                sb.AppendFormat(" AND {0} is not null", Strings.Trim(searchInfo.FieldName));
                            }
                        }
                        else
                        {
                            sb.AppendFormat(" AND {0} {1} '{2}'", searchInfo.FieldName,
                                this.ConvertSqlOperator(searchInfo.SqlOperator), Strings.Trim(searchInfo.FieldValue));
                        }
                        #endregion
                    }
                }
            }

            sql += sb.ToString();
            if (!string.IsNullOrEmpty(sql) && sql.Length > 4) sql = sql.Remove(0, 4);

            return sql;
        }

        /// <summary>
        /// 建立分组条件
        /// </summary>
        /// <returns></returns>
        private string BuildGroupCondiction(Hashtable conditionTable)
        {
            Hashtable ht = GetGroupNames(conditionTable);
            SearchInfo searchInfo = null;
            StringBuilder sb = new StringBuilder();
            string sql = string.Empty;
            string tempSql = string.Empty;

            foreach (string groupName in ht.Keys)
            {
                sb = new StringBuilder();
                tempSql = " AND ({0})";
                foreach (DictionaryEntry de in conditionTable)
                {
                    searchInfo = (SearchInfo)de.Value;

                    //如果选择ExcludeIfEmpty为True,并且该字段为空值的话,跳过
                    if (searchInfo.ExcludeIfEmpty &&
                        (searchInfo.FieldValue == null || string.IsNullOrEmpty(searchInfo.FieldValue.ToString())))
                    {
                        continue;
                    }

                    if (groupName.Equals(searchInfo.GroupName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (searchInfo.SqlOperator == SqlOperator.Like)
                        {
                            sb.AppendFormat(" OR {0} {1} '{2}'", searchInfo.FieldName,
                                this.ConvertSqlOperator(searchInfo.SqlOperator), string.Format("%{0}%", Strings.Trim(searchInfo.FieldValue)));
                        }
                        else if (searchInfo.SqlOperator == SqlOperator.NotLike)
                        {
                            sb.AppendFormat(" OR {0} {1} '{2}'", searchInfo.FieldName,
                                this.ConvertSqlOperator(searchInfo.SqlOperator), string.Format("%{0}%", Strings.Trim(searchInfo.FieldValue)));
                        }
                        else if (searchInfo.SqlOperator == SqlOperator.LikeStartAt)
                        {
                            sb.AppendFormat(" OR {0} {1} '{2}'", searchInfo.FieldName,
                                this.ConvertSqlOperator(searchInfo.SqlOperator), string.Format("{0}%", Strings.Trim(searchInfo.FieldValue)));
                        }
                        else if (searchInfo.SqlOperator == SqlOperator.LikeEndAt)
                        {
                            sb.AppendFormat(" OR {0} {1} '{2}'", searchInfo.FieldName,
                                this.ConvertSqlOperator(searchInfo.SqlOperator), string.Format("%{0}", Strings.Trim(searchInfo.FieldValue)));
                        }
                        else if (searchInfo.SqlOperator == SqlOperator.In)
                        {
                            sb.AppendFormat(" OR {0} {1} {2}", searchInfo.FieldName,
                                this.ConvertSqlOperator(searchInfo.SqlOperator), string.Format("({0})", Strings.Trim(searchInfo.FieldValue)));
                        }
                        else
                        {
                            #region Oracle分组
                            if (searchInfo.FieldValue != null && IsDate(searchInfo.FieldValue.ToString()))
                            {
                                sb.AppendFormat(" OR {0} {1} to_date('{2}','YYYY-MM-dd')", searchInfo.FieldName,
                                this.ConvertSqlOperator(searchInfo.SqlOperator), Strings.Trim(searchInfo.FieldValue));
                            }
                            else if (searchInfo.FieldValue != null && IsDateHourMinute(searchInfo.FieldValue.ToString()))
                            {
                                sb.AppendFormat(" OR {0} {1} to_date('{2}','YYYY-MM-dd HH:mi')", searchInfo.FieldName,
                                this.ConvertSqlOperator(searchInfo.SqlOperator), Strings.Trim(searchInfo.FieldValue));
                            }
                            else if (!searchInfo.ExcludeIfEmpty)
                            {
                                //如果要进行空值查询的时候
                                if (searchInfo.SqlOperator == SqlOperator.Equal)
                                {
                                    sb.AppendFormat(" OR ({0} is null or {0}='')", searchInfo.FieldName);
                                }
                                else if (searchInfo.SqlOperator == SqlOperator.NotEqual)
                                {
                                    sb.AppendFormat(" OR {0} is not null", searchInfo.FieldName);
                                }
                            }
                            else
                            {
                                sb.AppendFormat(" OR {0} {1} '{2}'", searchInfo.FieldName,
                                    this.ConvertSqlOperator(searchInfo.SqlOperator), Strings.Trim(searchInfo.FieldValue));
                            }
                            #endregion

                        }
                    }
                }

                if (!string.IsNullOrEmpty(sb.ToString()))
                {
                    tempSql = string.Format(tempSql, sb.ToString().Substring(4));//从第一个Or开始位置
                    sql += tempSql;
                }
            }

            return sql;
        }

        /// <summary>
        /// 获取给定条件集合的组别对象集合
        /// </summary>
        /// <returns></returns>
        private Hashtable GetGroupNames(Hashtable conditionTable)
        {
            Hashtable htGroupNames = new Hashtable();
            SearchInfo searchInfo = null;
            foreach (DictionaryEntry de in conditionTable)
            {
                searchInfo = (SearchInfo)de.Value;
                if (!string.IsNullOrEmpty(searchInfo.GroupName) && !htGroupNames.Contains(searchInfo.GroupName))
                {
                    htGroupNames.Add(searchInfo.GroupName, searchInfo.GroupName);
                }
            }

            return htGroupNames;
        }
        #endregion

        #region DataTableToList

        /// <summary>
        /// DataTableToList
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="dataSet">数据源</param>
        /// <param name="tableIndex">需要转换表的索引</param>
        /// <returns></returns>
        public virtual List<U> DataTableToList<U>(DataTable dt, int tableIndex, bool isNullReturnList = false)
        {
            //确认参数有效
            if (dt == null || dt.Rows.Count <= 0 || tableIndex < 0)
            {
                if (isNullReturnList)
                {
                    return new List<U>();
                }
                else
                {
                    return null;
                }
            }

            List<U> list = new List<U>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //创建泛型对象
                U _u = Activator.CreateInstance<U>();
                //获取对象所有属性
                PropertyInfo[] propertyInfo = _u.GetType().GetProperties();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    foreach (PropertyInfo info in propertyInfo)
                    {
                        //属性名称和列名相同时赋值
                        if (dt.Columns[j].ColumnName.ToUpper().Equals(info.Name.ToUpper()))
                        {
                            if (dt.Rows[i][j] != DBNull.Value)
                            {
                                info.SetValue(_u, dt.Rows[i][j], null);
                            }
                            else
                            {
                                info.SetValue(_u, null, null);
                            }
                            break;
                        }
                    }
                }
                list.Add(_u);
            }
            return list;
        }
        #endregion

        #region 辅助函数



        /// <summary>
        /// 转换枚举类型为对应的Sql语句操作符号
        /// </summary>
        /// <param name="sqlOperator">SqlOperator枚举对象</param>
        /// <returns><![CDATA[对应的Sql语句操作符号（如 ">" "<>" ">=")]]></returns>
        private string ConvertSqlOperator(SqlOperator sqlOperator)
        {
            string stringOperator = " = ";
            switch (sqlOperator)
            {
                case SqlOperator.Equal:
                    stringOperator = " = ";
                    break;
                case SqlOperator.LessThan:
                    stringOperator = " < ";
                    break;
                case SqlOperator.LessThanOrEqual:
                    stringOperator = " <= ";
                    break;
                case SqlOperator.Like:
                    stringOperator = " Like ";
                    break;
                case SqlOperator.NotLike:
                    stringOperator = " NOT Like ";
                    break;
                case SqlOperator.LikeStartAt:
                    stringOperator = " Like ";
                    break;
                case SqlOperator.LikeEndAt:
                    stringOperator = " Like ";
                    break;
                case SqlOperator.MoreThan:
                    stringOperator = " > ";
                    break;
                case SqlOperator.MoreThanOrEqual:
                    stringOperator = " >= ";
                    break;
                case SqlOperator.NotEqual:
                    stringOperator = " <> ";
                    break;
                case SqlOperator.In:
                    stringOperator = " in ";
                    break;
                default:
                    break;
            }

            return stringOperator;
        }

        /// <summary>
        /// 根据传入对象的值类型获取其对应的DbType类型
        /// </summary>
        /// <param name="fieldValue">对象的值</param>
        /// <returns>DbType类型</returns>
        private DbType GetFieldDbType(object fieldValue)
        {
            DbType type = DbType.String;

            switch (fieldValue.GetType().ToString())
            {
                case "System.Int16":
                    type = DbType.Int16;
                    break;
                case "System.UInt16":
                    type = DbType.UInt16;
                    break;
                case "System.Single":
                    type = DbType.Single;
                    break;
                case "System.UInt32":
                    type = DbType.UInt32;
                    break;
                case "System.Int32":
                    type = DbType.Int32;
                    break;
                case "System.UInt64":
                    type = DbType.UInt64;
                    break;
                case "System.Int64":
                    type = DbType.Int64;
                    break;
                case "System.String":
                    type = DbType.String;
                    break;
                case "System.Double":
                    type = DbType.Double;
                    break;
                case "System.Decimal":
                    type = DbType.Decimal;
                    break;
                case "System.Byte":
                    type = DbType.Byte;
                    break;
                case "System.Boolean":
                    type = DbType.Boolean;
                    break;
                case "System.DateTime":
                    type = DbType.DateTime;
                    break;
                case "System.Guid":
                    type = DbType.Guid;
                    break;
                default:
                    break;
            }
            return type;
        }

        /// <summary>
        /// 判断输入的字符是否为日期
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        internal bool IsDate(string strValue)
        {
            DateTime dt = DateTime.Now;
            if (DateTime.TryParse(strValue, out dt))
            {
                if (strValue.Contains(":"))
                    return false;
                return true;
            }
            return false;
            //return Regex.IsMatch(strValue, @"^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))");
        }

        /// <summary>
        /// 判断输入的字符是否为日期,如2004-07-12 14:25|||1900-01-01 00:00|||9999-12-31 23:59
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        internal bool IsDateHourMinute(string strValue)
        {
            DateTime dt = DateTime.Now;
            if (DateTime.TryParse(strValue, out dt))
            {
                if (strValue.Contains(":"))
                    return true;
                return false;
            }
            return false;
            // return Regex.IsMatch(strValue, @"^(19[0-9]{2}|[2-9][0-9]{3})-((0(1|3|5|7|8)|10|12)-(0[1-9]|1[0-9]|2[0-9]|3[0-1])|(0(4|6|9)|11)-(0[1-9]|1[0-9]|2[0-9]|30)|(02)-(0[1-9]|1[0-9]|2[0-9]))\x20(0[0-9]|1[0-9]|2[0-3])(:[0-5][0-9]){1}$");
        }

        #endregion

        #endregion

        #endregion

    }
}
