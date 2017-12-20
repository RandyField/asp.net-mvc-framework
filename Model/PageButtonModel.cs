using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 页面按钮
    /// </summary>
    public class PageButtonModel
    {
        /// <summary>
        /// 按钮名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 按钮编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 按钮图片脚本
        /// </summary>
        public string IconScript { get; set; }

        /// <summary>
        /// 按钮排序
        /// </summary>
        public int Sort { get; set; }
    }
}
