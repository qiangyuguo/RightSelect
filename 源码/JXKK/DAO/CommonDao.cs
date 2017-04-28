using System;
using System.Data;
using System.Text;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DAO
{
    /// <summary>
    /// 系统通用函数（数据库操作）
    /// </summary>
    public class CommonDao
    {
        /// <summary>
        /// 数据来源于最大值表！
        /// 取最大值号〔已经自加1,无须再加1〕
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="codex">编码规则</param>
        /// <param name="digit">位数</param>
        /// <returns>生成后的编码</returns>
        public string GetMaxNo(string tableName, string codex, int digit)
        {
            DataAccess db = new DataAccess(DataAccess.DBConn);
            string maxNo = "";
            ComCommand acmd = new ComCommand("PGetMax", db.DbConnection);
            acmd.CommandType = System.Data.CommandType.StoredProcedure;
            acmd.Parameters.Add("vi_TabName", tableName);
            acmd.Parameters.Add("vi_Codex", codex);
            acmd.Parameters.Add("vi_Digit", digit);
            acmd.Parameters.Add("vo_ReturnValue", maxNo);
            acmd.Parameters["vi_TabName"].Direction = System.Data.ParameterDirection.Input;
            acmd.Parameters["vi_Codex"].Direction = System.Data.ParameterDirection.Input;
            acmd.Parameters["vi_Digit"].Direction = System.Data.ParameterDirection.Input;
            acmd.Parameters["vo_ReturnValue"].Direction = System.Data.ParameterDirection.InputOutput;
            acmd.Parameters["vo_ReturnValue"].Size = 50;
            try
            {
                db.Open();
                acmd.ExecuteNonQuery();
                maxNo = acmd.Parameters["vo_ReturnValue"].Value.ToString();
                acmd.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
            return maxNo.Trim();
        }

        /// <summary>
        /// 获取EasyuUI-DataGrid列表数据
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">每页数量</param>
        /// <returns>Json数据格式字符串</returns>
        public string DataGrid(string strSQL, Param param, int pageNum, int pageSize)
        {
            StringBuilder sb = new StringBuilder();
            DataAccess db = new DataAccess(DataAccess.DBConn);
            int dataTotal = 0;
            try
            {
                db.Open();
                dataTotal = int.Parse(db.ExecuteScalar(CommandType.Text, "select count(*) from (   " + strSQL + ") e ", param).ToString());
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }

            string strSqlData = "select * from ( select AP.* , ROW_NUMBER() over (order by ap.CreateDate desc) as RowNumber from (" + strSQL + ") AP ";
            strSqlData += " )as  son where RowNumber between " + Convert.ToString(pageSize * (pageNum-1)+1) + " and " + Convert.ToString(pageNum * pageSize);
            DataTable dt = db.ExecuteDataView(CommandType.Text, strSqlData, param).Table;
            sb.Append("{");
            sb.AppendFormat("\"total\":{0},\"rows\":[", dataTotal);
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                sb.Append("{");
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    sb.AppendFormat("\"{0}\":", dt.Columns[c].ColumnName.Replace("\"", "\\\"").Replace("\'", "\\\'").ToLower());
                    if (dt.Rows[r].IsNull(c))
                    {
                        if (dt.Columns[c].DataType.FullName.Equals("System.DateTime"))
                            sb.Append("\"\",");
                        else if (dt.Columns[c].DataType.FullName.Equals("System.Decimal"))
                            sb.Append("0,");
                        else
                            sb.Append("\"\",");
                    }
                    else
                    {
                        if (dt.Columns[c].DataType.FullName.Equals("System.DateTime"))
                            sb.AppendFormat("\"{0:yyyy-MM-dd HH:mm:ss}\",", dt.Rows[r][c]);
                        else if (dt.Columns[c].DataType.FullName.Equals("System.Decimal"))
                            sb.AppendFormat("{0},", dt.Rows[r][c]);
                        else
                            sb.AppendFormat("\"{0}\",", dt.Rows[r][c].ToString().Replace("\\","\\\\").Replace("\"", "\\\"").Replace("'", "\'")).Replace(Convert.ToString((char)13), "\\r\\n").Replace(Convert.ToString((char)10), "\\r\\n");
                    }
                }
                sb.Remove(sb.ToString().LastIndexOf(','), 1);
                sb.Append("},");
            }
            if(dt.Rows.Count > 0)
                sb.Remove(sb.ToString().LastIndexOf(','), 1);
            sb.Append("]}");
            return sb.ToString();
        }


        /// <summary>
        /// 获取EasyuUI-DataGrid列表数据
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">每页数量</param>
        /// <returns>Json数据格式字符串</returns>
        public string DataGrid(string strSQL, Param param)
        {
            StringBuilder sb = new StringBuilder();
            DataAccess db = new DataAccess(DataAccess.DBConn);
            int dataTotal = 0;
            try
            {
                db.Open();
                dataTotal = int.Parse(db.ExecuteScalar(CommandType.Text, "select count(*) from (" + strSQL + ")", param).ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }

            string strSqlData = "select * from (" + strSQL + ") AP ";
            DataTable dt = db.ExecuteDataView(CommandType.Text, strSqlData, param).Table;
            sb.Append("{");
            sb.AppendFormat("\"total\":{0},\"rows\":[", dataTotal);
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                sb.Append("{");
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    sb.AppendFormat("\"{0}\":", dt.Columns[c].ColumnName.Replace("\"", "\\\"").Replace("\'", "\\\'").ToLower());
                    if (dt.Rows[r].IsNull(c))
                    {
                        if (dt.Columns[c].DataType.FullName.Equals("System.DateTime"))
                            sb.Append("\"\",");
                        else if (dt.Columns[c].DataType.FullName.Equals("System.Decimal"))
                            sb.Append("0,");
                        else
                            sb.Append("\"\",");
                    }
                    else
                    {
                        if (dt.Columns[c].DataType.FullName.Equals("System.DateTime"))
                            sb.AppendFormat("\"{0:yyyy-MM-dd HH:mm:ss}\",", dt.Rows[r][c]);
                        else if (dt.Columns[c].DataType.FullName.Equals("System.Decimal"))
                            sb.AppendFormat("{0},", dt.Rows[r][c]);
                        else
                            sb.AppendFormat("\"{0}\",", dt.Rows[r][c].ToString().Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("'", "\'")).Replace(Convert.ToString((char)13), "\\r\\n").Replace(Convert.ToString((char)10), "\\r\\n");
                    }
                }
                sb.Remove(sb.ToString().LastIndexOf(','), 1);
                sb.Append("},");
            }
            if (dt.Rows.Count > 0)
                sb.Remove(sb.ToString().LastIndexOf(','), 1);
            sb.Append("]}");
            return sb.ToString();
        }
        public string DataGridTemp(string strSQL, Param param)
        {
            StringBuilder sb = new StringBuilder();
            DataAccess db = new DataAccess(DataAccess.DBConn);
            int dataTotal = 0;
            try
            {
                db.Open();
                dataTotal = int.Parse(db.ExecuteScalar(CommandType.Text, "select count(*) from (" + strSQL + ") as a", param).ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }

            string strSqlData = "select * from (" + strSQL + ") as a ";
            DataTable dt = db.ExecuteDataView(CommandType.Text, strSqlData, param).Table;
            sb.Append("{");
            sb.AppendFormat("\"total\":{0},\"rows\":[", dataTotal);
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                sb.Append("{");
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    sb.AppendFormat("\"{0}\":", dt.Columns[c].ColumnName.Replace("\"", "\\\"").Replace("\'", "\\\'").ToLower());
                    if (dt.Rows[r].IsNull(c))
                    {
                        if (dt.Columns[c].DataType.FullName.Equals("System.DateTime"))
                            sb.Append("\"\",");
                        else if (dt.Columns[c].DataType.FullName.Equals("System.Decimal"))
                            sb.Append("0,");
                        else
                            sb.Append("\"\",");
                    }
                    else
                    {
                        if (dt.Columns[c].DataType.FullName.Equals("System.DateTime"))
                            sb.AppendFormat("\"{0:yyyy-MM-dd HH:mm:ss}\",", dt.Rows[r][c]);
                        else if (dt.Columns[c].DataType.FullName.Equals("System.Decimal"))
                            sb.AppendFormat("{0},", dt.Rows[r][c]);
                        else
                            sb.AppendFormat("\"{0}\",", dt.Rows[r][c].ToString().Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("'", "\'")).Replace(Convert.ToString((char)13), "\\r\\n").Replace(Convert.ToString((char)10), "\\r\\n");
                    }
                }
                sb.Remove(sb.ToString().LastIndexOf(','), 1);
                sb.Append("},");
            }
            if (dt.Rows.Count > 0)
                sb.Remove(sb.ToString().LastIndexOf(','), 1);
            sb.Append("]}");
            return sb.ToString();
        }


        /// <summary>
        ///  获取EasyuUI-DataGrid列表数据
        /// </summary>
        /// <param name="dt">DataTable集合</param>
        /// <param name="dataTotal">总行数</param>
        /// <returns></returns>
        public string DataGrid(DataTable dt,int dataTotal)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.AppendFormat("\"total\":{0},\"rows\":[", dataTotal);
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                sb.Append("{");
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    sb.AppendFormat("\"{0}\":", dt.Columns[c].ColumnName.Replace("\"", "\\\"").Replace("\'", "\\\'").ToLower());
                    if (dt.Rows[r].IsNull(c))
                    {
                        if (dt.Columns[c].DataType.FullName.Equals("System.DateTime"))
                            sb.Append("\"\",");
                        else if (dt.Columns[c].DataType.FullName.Equals("System.Decimal"))
                            sb.Append("0,");
                        else
                            sb.Append("\"\",");
                    }
                    else
                    {
                        if (dt.Columns[c].DataType.FullName.Equals("System.DateTime"))
                            sb.AppendFormat("\"{0:yyyy-MM-dd HH:mm:ss}\",", dt.Rows[r][c]);
                        else if (dt.Columns[c].DataType.FullName.Equals("System.Decimal"))
                            sb.AppendFormat("{0},", dt.Rows[r][c]);
                        else
                            sb.AppendFormat("\"{0}\",", dt.Rows[r][c].ToString().Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("'", "\'")).Replace(Convert.ToString((char)13), "\\r\\n").Replace(Convert.ToString((char)10), "\\r\\n");
                    }
                }
                sb.Remove(sb.ToString().LastIndexOf(','), 1);
                sb.Append("},");
            }
            if (dt.Rows.Count > 0)
                sb.Remove(sb.ToString().LastIndexOf(','), 1);
            sb.Append("]}");
            return sb.ToString();
        }






        /// <summary>
        /// 获取EasyuUI-Combobox列表数据
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>Json数据格式字符串</returns>
        public string Combobox(string strSQL, Param param)
        {
            StringBuilder sb = new StringBuilder();
            DataAccess db = new DataAccess(DataAccess.DBConn);

            DataTable dt = db.ExecuteDataView(CommandType.Text, strSQL, param).Table;
            DataRow newRow;
            newRow = dt.NewRow();
            newRow["name"] = "全部";
            newRow["id"] = "";
            dt.Rows.Add(newRow);
            DataView dv = dt.DefaultView;
            dv.Sort = "id Asc";
            dt = dv.ToTable();
            sb.Append("[");
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                sb.Append("{");
                for (int c = 0; c < 2; c++)
                {
                    if (c == 0)
                        sb.Append("\"text\":");
                    else
                        sb.Append("\"value\":");

                    if (dt.Rows[r].IsNull(c))
                    {
                        if (dt.Columns[c].DataType.FullName.Equals("System.Decimal"))
                            sb.Append("0,");
                        else
                            sb.Append("\"\",");
                    }
                    else
                    {
                        if (dt.Columns[c].DataType.FullName.Equals("System.Decimal"))
                            sb.AppendFormat("{0},", dt.Rows[r][c]);
                        else
                            sb.AppendFormat("\"{0}\",", dt.Rows[r][c].ToString().Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\'", "\\\'")).Replace(Convert.ToString((char)13), "\\r\\n").Replace(Convert.ToString((char)10), "\\r\\n");
                    }
                }
                sb.Remove(sb.ToString().LastIndexOf(','), 1);
                sb.Append("},");
            }
            if (dt.Rows.Count > 0)
                sb.Remove(sb.ToString().LastIndexOf(','), 1);
            sb.Append("]");
            return sb.ToString();
        }

        /// <summary>
        /// 获取EasyuUI-Combobox列表数据
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <param name="firstText">首选Text</param>
        /// <param name="firstValue">首先Value</param>
        /// <returns>Json数据格式字符串</returns>
        public string Combobox(string strSQL, Param param, string firstText, string firstValue)
        {
            StringBuilder sb = new StringBuilder();
            DataAccess db = new DataAccess(DataAccess.DBConn);

            DataTable dt = db.ExecuteDataView(CommandType.Text, strSQL, param).Table;
            sb.Append("[{");
            sb.AppendFormat("\"text\":\"{0}\",\"value\":\"{1}\",\"selected\":true", firstText, firstValue);
            sb.Append("},");
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                sb.Append("{");
                for (int c = 0; c < 2; c++)
                {
                    if (c == 0)
                        sb.Append("\"text\":");
                    else
                        sb.Append("\"value\":");

                    if (dt.Rows[r].IsNull(c))
                    {
                        if (dt.Columns[c].DataType.FullName.Equals("System.Decimal"))
                            sb.Append("0,");
                        else
                            sb.Append("\"\",");
                    }
                    else
                    {
                        if (dt.Columns[c].DataType.FullName.Equals("System.Decimal"))
                            sb.AppendFormat("{0},", dt.Rows[r][c]);
                        else
                            sb.AppendFormat("\"{0}\",", dt.Rows[r][c].ToString().Replace("\"", "\\\"").Replace("\'", "\\\'")).Replace(Convert.ToString((char)13), "\\r\\n").Replace(Convert.ToString((char)10), "\\r\\n");
                    }
                }
                sb.Remove(sb.ToString().LastIndexOf(','), 1);
                sb.Append("},");
            }
            sb.Remove(sb.ToString().LastIndexOf(','), 1);
            sb.Append("]");
            return sb.ToString();
        }

        /// <summary>
        /// 获取EasyuUI-Combobox列表数据
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>Json数据格式字符串</returns>
        public string Combobox(DataTable dt)
        {
            DataRow newRow;
            newRow = dt.NewRow();
            newRow["text"] = "全部";
            newRow["value"] = "";
            dt.Rows.Add(newRow);
            DataView dv = dt.DefaultView;
            dv.Sort = "value Asc";
            dt = dv.ToTable();
            StringBuilder sb = new StringBuilder();
            DataAccess db = new DataAccess(DataAccess.DBConn);
            sb.Append("[");
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                sb.Append("{");
                for (int c = 0; c < 2; c++)
                {
                    if (c == 0)
                        sb.Append("\"text\":");
                    else
                        sb.Append("\"value\":");

                    if (dt.Rows[r].IsNull(c))
                    {
                        if (dt.Columns[c].DataType.FullName.Equals("System.Decimal"))
                            sb.Append("0,");
                        else
                            sb.Append("\"\",");
                    }
                    else
                    {
                        if (dt.Columns[c].DataType.FullName.Equals("System.Decimal"))
                            sb.AppendFormat("{0},", dt.Rows[r][c]);
                        else
                            sb.AppendFormat("\"{0}\",", dt.Rows[r][c].ToString().Replace("\"", "\\\"").Replace("\'", "\\\'")).Replace(Convert.ToString((char)13), "\\r\\n").Replace(Convert.ToString((char)10), "\\r\\n");
                    }
                }
                sb.Remove(sb.ToString().LastIndexOf(','), 1);
                sb.Append("},");
            }
            if (dt.Rows.Count > 0)
                sb.Remove(sb.ToString().LastIndexOf(','), 1);
            sb.Append("]");
            return sb.ToString();
        }


    }
}
