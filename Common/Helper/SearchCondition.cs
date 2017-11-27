using Common.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public class SearchCondition
    {
        #region Field
        private Hashtable conditionTable = new Hashtable();  //查询条件
        #endregion

        #region Property
        /// <summary>
        /// 查询条件列表
        /// </summary>
        public Hashtable ConditionTable
        {
            get { return this.conditionTable; }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// 为查询添加条件
        /// </summary>
        /// <param name="fielName">字段名称</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="sqlOperator">SqlOperator枚举类型</param>
        /// <returns>增加条件后的Hashtable</returns>
        public SearchCondition AddCondition(string fielName, object fieldValue, SqlOperator sqlOperator)
        {
            this.conditionTable.Add(System.Guid.NewGuid()/*fielName*/, new SearchInfo(fielName, fieldValue, sqlOperator));
            return this;
        }

        /// <summary>
        /// 为查询添加条件
        /// </summary>
        /// <param name="fielName">字段名称</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="sqlOperator">SqlOperator枚举类型</param>
        /// <param name="excludeIfEmpty">如果字段为空或者Null则不作为查询条件</param>
        /// <returns></returns>
        public SearchCondition AddCondition(string fielName, object fieldValue, SqlOperator sqlOperator, bool excludeIfEmpty)
        {
            this.conditionTable.Add(System.Guid.NewGuid()/*fielName*/, new SearchInfo(fielName, fieldValue, sqlOperator, excludeIfEmpty));
            return this;
        }

        /// <summary>
        /// 将多个条件分组归类作为一个条件来查询，
        /// 如需构造一个括号内的条件 ( Test = "AA1" OR Test = "AA2")
        /// </summary>
        /// <param name="fielName">字段名称</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="sqlOperator">SqlOperator枚举类型</param>
        /// <param name="excludeIfEmpty">如果字段为空或者Null则不作为查询条件</param>
        /// <param name="groupName">分组的名称，如需构造一个括号内的条件 ( Test = "AA1" OR Test = "AA2"), 定义一个组名集中条件</param>
        /// <returns></returns>
        public SearchCondition AddCondition(string fielName, object fieldValue, SqlOperator sqlOperator,
            bool excludeIfEmpty, string groupName)
        {
            this.conditionTable.Add(System.Guid.NewGuid()/*fielName*/, new SearchInfo(fielName, fieldValue, sqlOperator, excludeIfEmpty, groupName));
            return this;
        }

        #endregion
    }
}
