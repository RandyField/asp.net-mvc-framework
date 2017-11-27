using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public class JqueryDataTableParams
    {
        /// <summary>
        /// 操作次数
        /// </summary>
        public int sEcho { get; set; }

        /// <summary>
        /// 列数
        /// </summary>
        public string iColumns { get; set; }
        public int sColumns { get; set; }

        /// <summary>
        /// 起始记录数
        /// </summary>
        public int iDisplayStart { get; set; }

        /// <summary>
        /// pageSize
        /// </summary>
        public int iDisplayLength { get; set; }

        public int iSortingCols { get; set; }

        public int iTotalRecords { get; set; }

        public int iTotalDisplayRecords { get; set; }

        public DataTable aaData { get; set; }
    }
}
