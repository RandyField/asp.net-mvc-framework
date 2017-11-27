using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public class PagerInfo
    {
        public string tableName { get; set; }          //表名或视图
        public string fields;             //显示的列
        public SearchCondition condition; //查询条件集合
        public string where;
        public string sortField;          //排序的列
        public bool isDescending;         //是否降序排列
        public int curPage;               //当前页
        public int pageSize;              //每页显示记录条数 
        public int pageCount;             //总页数
        public string indexField;         //索引 
    }
}
