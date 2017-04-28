using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;
using System.Text;

namespace Com.ZY.JXKK.DAO.Set
{
    /// <summary>
    /// 区域设置
    /// Author:开发人员自行扩展
    /// </summary>
    public class TBAreaDAO:TBAreaDBO
    {
        /// <summary>
        /// 获取EasyuUI-Combobox列表数据
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>Json数据格式字符串</returns>
        public string AreaCombobox(string strSQL, Param param)
        {
            StringBuilder sb = new StringBuilder();
            DataAccess db = new DataAccess(DataAccess.DBConn);

            DataTable dt = db.ExecuteDataView(CommandType.Text, strSQL, param).Table;
            string parentId = "";
            sb.Append("[");
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                if (dt.Rows[r]["areaid"].ToString() == parentId)
                {
                    continue;
                }
                DataRow[] childrenRows = dt.Select("parentId=" + dt.Rows[r]["areaId"] + "");

                if (childrenRows.Length == 0 && dt.Rows[r]["parentId"].ToString() == "0")
                {
                    sb.Append("{");
                    sb.Append("\"text\":");
                    sb.AppendFormat("\"{0}\",", dt.Rows[r]["areaname"].ToString().Replace("\"", "\\\"").Replace("\'", "\\\'")).Replace(Convert.ToString((char)13), "\\r\\n").Replace(Convert.ToString((char)10), "\\r\\n");
                    sb.Append("\"value\":");
                    sb.AppendFormat("\"{0}\",", dt.Rows[r]["areaid"].ToString().Replace("\"", "\\\"").Replace("\'", "\\\'")).Replace(Convert.ToString((char)13), "\\r\\n").Replace(Convert.ToString((char)10), "\\r\\n");
                    sb.Remove(sb.ToString().LastIndexOf(','), 1);
                    sb.Append("},");
                }
                else
                {
                    foreach (DataRow dr in childrenRows)
                    {
                        sb.Append("{");
                        sb.Append("\"text\":");
                        sb.AppendFormat("\"{0}\",", dr["areaname"].ToString().Replace("\"", "\\\"").Replace("\'", "\\\'")).Replace(Convert.ToString((char)13), "\\r\\n").Replace(Convert.ToString((char)10), "\\r\\n");
                        sb.Append("\"value\":");
                        sb.AppendFormat("\"{0}\",", dr["areaid"].ToString().Replace("\"", "\\\"").Replace("\'", "\\\'")).Replace(Convert.ToString((char)13), "\\r\\n").Replace(Convert.ToString((char)10), "\\r\\n");
                        sb.Append("\"group\":");
                        parentId = dr["parentId"].ToString();
                        DataRow[] parentRows = dt.Select("areaId=" + dr["parentId"] + "");
                        string parentName = parentRows[0]["areaname"].ToString();
                        sb.AppendFormat("\"{0}\",", parentName.Replace("\"", "\\\"").Replace("\'", "\\\'")).Replace(Convert.ToString((char)13), "\\r\\n").Replace(Convert.ToString((char)10), "\\r\\n");
                        sb.Remove(sb.ToString().LastIndexOf(','), 1);
                        sb.Append("},");
                    }

                }

            }
            if (dt.Rows.Count > 0)
                sb.Remove(sb.ToString().LastIndexOf(','), 1);
            sb.Append("]");
            return sb.ToString();
        }
    }
}

