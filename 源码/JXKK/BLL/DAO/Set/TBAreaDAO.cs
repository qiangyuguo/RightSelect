using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Set;
using System.Text;

namespace Com.ZY.JXKK.DAO.Set
{
    /// <summary>
    /// 区域设置
    /// Author:代码生成器
    /// </summary>
    public class TBAreaDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接

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
                if (dt.Rows[r]["areaid"].ToString()==parentId)
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

        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加区域设置
        /// <param name="data">数据库连接</param>
        /// <param name="tbArea">区域设置</param>
        /// </summary>
        public void Add(DataAccess data,TBArea tbArea)
        {
            string strSQL = "insert into TBArea (areaId,areaCode,areaName,isUse,parentId,areaLayer,areaIndex) values (:areaId,:areaCode,:areaName,:isUse,:parentId,:areaLayer,:areaIndex)";
            Param param = new Param();
            param.Clear();
            param.Add(":areaId", tbArea.areaId);//区域编号
            param.Add(":areaCode", tbArea.areaCode);//区域代码
            param.Add(":areaName", tbArea.areaName);//区域名称
            param.Add(":isUse", tbArea.isUse);//使用状态
            param.Add(":parentId", tbArea.parentId);//父区域编号
            param.Add(":areaLayer", tbArea.areaLayer);//所属层次
            param.Add(":areaIndex", tbArea.areaIndex);//排列顺序
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加区域设置
        /// <param name="tbArea">区域设置</param>
        /// </summary>
        public void Add(TBArea tbArea)
        {
            try
            {
                db.Open();
                Add(db,tbArea);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
        
        /// <summary>
        /// 修改区域设置
        /// <param name="data">数据库连接</param>
        /// <param name="tbArea">区域设置</param>
        /// </summary>
        public void Edit(DataAccess data,TBArea tbArea)
        {
            string strSQL = "update TBArea set areaCode=:areaCode,areaName=:areaName,isUse=:isUse,parentId=:parentId,areaLayer=:areaLayer,areaIndex=:areaIndex where areaId=:areaId";
            Param param = new Param();
            param.Clear();
            param.Add(":areaCode", tbArea.areaCode);//区域代码
            param.Add(":areaName", tbArea.areaName);//区域名称
            param.Add(":isUse", tbArea.isUse);//使用状态
            param.Add(":parentId", tbArea.parentId);//父区域编号
            param.Add(":areaLayer", tbArea.areaLayer);//所属层次
            param.Add(":areaIndex", tbArea.areaIndex);//排列顺序
            param.Add(":areaId", tbArea.areaId);//区域编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改区域设置
        /// <param name="tbArea">区域设置</param>
        /// </summary>
        public void Edit(TBArea tbArea)
        {
            try
            {
                db.Open();
                Edit(db,tbArea);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
        
        /// <summary>
        /// 删除区域设置
        /// <param name="data">数据库连接</param>
        /// <param name="areaId">区域编号</param>
        /// </summary>
        public void Delete(DataAccess data,string areaId)
        {
            string strSQL = "delete from TBArea where areaId=:areaId";
            Param param = new Param();
            param.Clear();
            param.Add(":areaId", areaId);//区域编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除区域设置
        /// <param name="areaId">区域编号</param>
        /// </summary>
        public void Delete(string areaId)
        {
            try
            {
                db.Open();
                Delete(db,areaId);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
        
        /// <summary>
        /// 获取区域设置
        /// <param name="areaId">区域编号</param>
        /// </summary>
        /// <returns>区域设置对象</returns>
        public TBArea Get(string areaId)
        {
            TBArea tbArea=null;
            try
            {
                string strSQL = "select * from TBArea where areaId=:areaId";
                Param param = new Param();
                param.Clear();
                param.Add(":areaId", areaId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbArea=ReadData(dr);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
            return tbArea;
        }
        
        /// <summary>
        /// 获取列表(区域设置)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>区域设置列表对象</returns>
        public List<TBArea> GetList(string strSQL,Param param)
        {
            List<TBArea> list = new List<TBArea>();
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while(dr.Read())
                {
                    list.Add(ReadData(dr));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
            return list;
        }
        
        /// <summary>
        /// 获取列表(区域设置)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>区域设置列表对象</returns>
        public List<TBArea> GetList(string field, string value)
        {
            List<TBArea> list = new List<TBArea>();
            try
            {
                string strSQL = "select * from TBArea where " + field + "=:field";
                Param param = new Param();
                param.Clear();
                param.Add(":field",value);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while(dr.Read())
                {
                    list.Add(ReadData(dr));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
            return list;
        }
        
        /// <summary>
        /// 获取DataSet(区域设置)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>区域设置DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBArea");
        }
        
        /// <summary>
        /// 是否存在记录(区域设置)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBArea where " + field + "=:field";
                Param param = new Param();
                param.Clear();
                param.Add(":field",value);
                db.Open();
                num = int.Parse(db.ExecuteScalar(CommandType.Text, strSQL, param).ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
            return num > 0;
        }
        
        /// <summary>
        /// 读取区域设置信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>区域设置对象</returns>
        private TBArea ReadData(ComDataReader dr)
        {
            TBArea tbArea= new TBArea();
            tbArea.areaId= dr["areaId"].ToString();//区域编号
            tbArea.areaCode= dr["areaCode"].ToString();//区域代码
            tbArea.areaName= dr["areaName"].ToString();//区域名称
            tbArea.isUse= dr["isUse"].ToString();//使用状态
            tbArea.parentId= dr["parentId"].ToString();//父区域编号
            tbArea.areaLayer= int.Parse(dr["areaLayer"].ToString());//所属层次
            tbArea.areaIndex= int.Parse(dr["areaIndex"].ToString());//排列顺序
            return tbArea;
        }
        
        
        #endregion
        
    }
}

