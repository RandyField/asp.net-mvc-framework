using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class jqDatatable
    {
        /// <summary>
        /// 请求次数（前端==》后端）
        /// </summary>
        public int draw { get; set; }

        /// <summary>
        /// 总记录数（前端《==后端）
        /// </summary>
        public int recordsTotal { get; set; }

        /// <summary>
        /// 过滤后的总记录数（前端《==后端）
        /// </summary>
        public int recordsFiltered { get; set; }

        /// <summary>
        /// 记录开始索引（前端==》后端）
        /// </summary>
        public int start { get; set; }

        /// <summary>
        /// PageIndex（前端==》后端）
        /// </summary>
        public int pageIndex { get; set; }

        /// <summary>
        /// PageSize（前端==》后端）
        /// </summary>
        public int length { get; set; }

        ///// <summary>
        ///// 集合分页数据（前端《==后端）
        ///// </summary>
        //public IList data { get; set; }

        /// <summary>
        /// 集合分页数据（前端《==后端）
        /// </summary>
        public object data { get; set; }

        /// <summary>
        /// 定义一个错误来描述服务器出了问题后的友好提示（后端《==前端）
        /// </summary>
        public string error { get; set; }
    }
}
