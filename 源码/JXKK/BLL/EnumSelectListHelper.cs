using System;
using System.Collections.Generic;
using System.Text;
using Com.ZY.JXKK.Model.Resource;
using System.Data;
namespace Com.ZY.JXKK.BLL
{
    public class EnumSelectListHelper
    {
        /// <summary>
        /// 获取枚举对应的中文意思
        /// </summary>
        /// <param name="type">枚举</param>
        /// <returns></returns>
        public static DataTable CreatSelectListByEnum(Type type)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");   
            foreach (var keyName in type.GetEnumNames())
            {
                var text = Resource.ResourceManager.GetString(type.Name + "_" + keyName);
                if (string.IsNullOrWhiteSpace(text))
                    text = keyName;
                DataRow dr = dt.NewRow();
                dr["Text"] = text;
                dr["Value"] = (Convert.ToInt64(Enum.Parse(type, keyName)).ToString());
                dt.Rows.Add(dr);       
            }

            return dt;
        }

        public static DataTable  CreatSelectListByEnumValueName(Type type)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");  
            foreach (var keyName in type.GetEnumNames())
            {
                var text = Resource.ResourceManager.GetString(type.Name + "_" + keyName);
                if (string.IsNullOrWhiteSpace(text))
                    text = keyName;
                DataRow dr = dt.NewRow();
                dr["Text"] = text;
                dr["Value"] = keyName;
                dt.Rows.Add(dr);       
            }
            return dt;
        }
    }
}
