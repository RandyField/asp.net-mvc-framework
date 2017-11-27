using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public static class DatatableHelper
    {
        public static  List<U> DataTableToList<U>(DataTable dt, int tableIndex, bool isNullReturnList = false)
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
    }
}
