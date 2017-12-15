using IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbFactory
    {
        /// <summary>
        /// 创建上下文基类
        /// </summary>
        /// <returns></returns>
        public static I_Base_DAL Create()
        {
            //实例化BaseDAL
            return new BaseDAL(new DbContext(("AdminEntities")));
        }
    }
}
