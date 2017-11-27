using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public static class ConvertToJson
    {
        /// <summary>
        /// list转json  for jquery datatable aaData
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <param name="sortColum"></param>
        /// <returns></returns>
        public static string GetJson<T>(jqDtParam<T> dt, List<string> sortColum)
        {
            StringBuilder json = new StringBuilder();
            json.Append("{\"sEcho\":" + dt.sEcho.ToString() + ",");
            json.Append("\"iTotalRecords\":" + dt.iTotalRecords.ToString() + ",");
            json.Append("\"iTotalDisplayRecords\":" + dt.iTotalRecords.ToString() + ",");
            json.Append("\"aaData\":[");
            //json.AppendFormat("{\"sEcho\":{0},\n \"iTotalRecords\":{1},\n \"iTotalDisplayRecords\": {2},\n \"aaData\":[", sEcho, totalRow, totalRow);

            for (int i = 0; i < dt.aaData.Count; i++)
            {
                json.Append("{");
                Type type = dt.aaData[i].GetType(); //获取类型
                foreach (string propertyName in sortColum)
                {
                    json.Append("\"");
                    json.Append(propertyName);
                    System.Reflection.PropertyInfo propertyInfo = type.GetProperty(propertyName); //获取指定名称的属性
                    var propertyvalue = propertyInfo.GetValue(dt.aaData[i], null); //获取属性值
                    json.Append("\":\"");
                    json.Append(propertyvalue);
                    json.Append("\",");
                }
                json.Remove(json.Length - 1, 1);
                json.Append("},");

            }
            json.Remove(json.Length - 1, 1);
            json.Append("]}");

            return json.ToString();
        }

        /// <summary>
        /// list转json  for jquery datatable aaData
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <param name="sortColum"></param>
        /// <returns></returns>
        public static string GetJson<T>(jqDtParam<T> dt, string[] sortColum)
        {
            StringBuilder json = new StringBuilder();
            json.Append("{\"sEcho\":" + dt.sEcho.ToString() + ",");
            json.Append("\"iTotalRecords\":" + dt.iTotalRecords.ToString() + ",");
            json.Append("\"iTotalDisplayRecords\":" + dt.iTotalRecords.ToString() + ",");
            json.Append("\"aaData\":[");
            //json.AppendFormat("{\"sEcho\":{0},\n \"iTotalRecords\":{1},\n \"iTotalDisplayRecords\": {2},\n \"aaData\":[", sEcho, totalRow, totalRow);

            for (int i = 0; i < dt.aaData.Count; i++)
            {
                json.Append("{");
                Type type = dt.aaData[i].GetType(); //获取类型
                foreach (string propertyName in sortColum)
                {
                    json.Append("\"");
                    json.Append(propertyName);
                    System.Reflection.PropertyInfo propertyInfo = type.GetProperty(propertyName); //获取指定名称的属性
                    var propertyvalue = propertyInfo.GetValue(dt.aaData[i], null); //获取属性值
                    json.Append("\":\"");
                    json.Append(propertyvalue);
                    json.Append("\",");
                }
                json.Remove(json.Length - 1, 1);
                json.Append("},");

            }
            json.Remove(json.Length - 1, 1);
            json.Append("]}");

            return json.ToString();
        }

        public static string GetJson<T>(jqDtParam<T> dt)
        {
            StringBuilder json = new StringBuilder();
            json.Append("{\"sEcho\":" + dt.sEcho.ToString() + ",");
            json.Append("\"iTotalRecords\":" + dt.iTotalRecords.ToString() + ",");
            json.Append("\"iTotalDisplayRecords\":" + dt.iTotalRecords.ToString() + ",");
            json.Append("\"aaData\":[");
            //json.AppendFormat("{\"sEcho\":{0},\n \"iTotalRecords\":{1},\n \"iTotalDisplayRecords\": {2},\n \"aaData\":[", sEcho, totalRow, totalRow);

            for (int i = 0; i < dt.aaData.Count; i++)
            {
                json.Append("{");
                Type type = dt.aaData[i].GetType(); //获取类型
                System.Reflection.PropertyInfo[] propertyInfos = type.GetProperties();
                foreach (System.Reflection.PropertyInfo propertyInfo in propertyInfos)
                {
                    json.Append("\"");
                    json.Append(propertyInfo.Name);
                    //System.Reflection.PropertyInfo propertyInfo = type.GetProperty(propertyName); //获取指定名称的属性
                    var propertyvalue = propertyInfo.GetValue(dt.aaData[i], null); //获取属性值
                    json.Append("\":\"");
                    json.Append(propertyvalue);
                    json.Append("\",");
                }
                json.Remove(json.Length - 1, 1);
                json.Append("},");

            }
            if ( dt.aaData.Count!=0)
            {
                json.Remove(json.Length - 1, 1);
            }
     
            json.Append("]}");

            return json.ToString();
        }


        public static string GetJson(JqueryDataTableParams param)
        {
            StringBuilder json = new StringBuilder();
            json.Append("{\"sEcho\":" + param.sEcho.ToString() + ",");
            json.Append("\"iTotalRecords\":" + param.iTotalRecords.ToString() + ",");
            json.Append("\"iTotalDisplayRecords\":" + param.iTotalRecords.ToString() + ",");
            json.Append("\"aaData\":[");
            //json.AppendFormat("{\"sEcho\":{0},\n \"iTotalRecords\":{1},\n \"iTotalDisplayRecords\": {2},\n \"aaData\":[", sEcho, totalRow, totalRow);

            for (int i = 0; i < param.aaData.Rows.Count; i++)
            {
                json.Append("{");
                for (int j = 0; j < param.aaData.Columns.Count; j++)
                {
                    json.Append("\"");
                    json.Append(param.aaData.Columns[j].ColumnName);
                    //System.Reflection.PropertyInfo propertyInfo = type.GetProperty(propertyName); //获取指定名称的属性
                    var propertyvalue = param.aaData.Rows[i][j].ToString(); //获取属性值
                    json.Append("\":\"");
                    json.Append(propertyvalue);
                    json.Append("\",");
                }
                json.Remove(json.Length - 1, 1);
                json.Append("},");

            }
            if (param.aaData.Rows.Count != 0)
            {
                json.Remove(json.Length - 1, 1);
            }

            json.Append("]}");

            return json.ToString();
        }
    }
}
