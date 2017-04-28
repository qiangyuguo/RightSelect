using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 区域设置
    /// Author:代码生成器
    /// </summary>
    public class TBAreaDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加区域设置
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbArea">区域设置</param>
        public virtual void Add(DataAccess data,TBArea tbArea)
        {
            string strSQL = "insert into TBArea (areaId,areaCode,areaName,isUse,parentId,areaLayer,areaIndex) values (@areaId,@areaCode,@areaName,@isUse,@parentId,@areaLayer,@areaIndex)";
            Param param = new Param();
            param.Clear();
            param.Add("@areaId", tbArea.areaId);//区域编号
            param.Add("@areaCode", tbArea.areaCode);//区域代码
            param.Add("@areaName", tbArea.areaName);//区域名称
            param.Add("@isUse", tbArea.isUse);//使用状态
            param.Add("@parentId", tbArea.parentId);//父区域编号
            param.Add("@areaLayer", tbArea.areaLayer);//所属层次
            param.Add("@areaIndex", tbArea.areaIndex);//排列顺序
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加区域设置
        /// </summary>
        /// <param name="tbArea">区域设置</param>
        public virtual void Add(TBArea tbArea)
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
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbArea">区域设置</param>
        public virtual void Edit(DataAccess data,TBArea tbArea)
        {
            string strSQL = "update TBArea set areaCode=@areaCode,areaName=@areaName,isUse=@isUse,parentId=@parentId,areaLayer=@areaLayer,areaIndex=@areaIndex where areaId=@areaId";
            Param param = new Param();
            param.Clear();
            param.Add("@areaCode", tbArea.areaCode);//区域代码
            param.Add("@areaName", tbArea.areaName);//区域名称
            param.Add("@isUse", tbArea.isUse);//使用状态
            param.Add("@parentId", tbArea.parentId);//父区域编号
            param.Add("@areaLayer", tbArea.areaLayer);//所属层次
            param.Add("@areaIndex", tbArea.areaIndex);//排列顺序
            param.Add("@areaId", tbArea.areaId);//区域编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改区域设置
        /// </summary>
        /// <param name="tbArea">区域设置</param>
        public virtual void Edit(TBArea tbArea)
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
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="areaId">区域编号</param>
        public virtual void Delete(DataAccess data,string areaId)
        {
            string strSQL = "delete from TBArea where areaId=@areaId";
            Param param = new Param();
            param.Clear();
            param.Add("@areaId", areaId);//区域编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除区域设置
        /// </summary>
        /// <param name="areaId">区域编号</param>
        public virtual void Delete(string areaId)
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
        /// </summary>
        /// <param name="areaId">区域编号</param>
        /// <returns>区域设置对象</returns>
        public virtual TBArea Get(string areaId)
        {
            TBArea tbArea=null;
            try
            {
                string strSQL = "select * from TBArea where areaId=@areaId";
                Param param = new Param();
                param.Clear();
                param.Add("@areaId", areaId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbArea=ReadData(dr);
                }
                dr.Close();
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
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>区域设置列表对象</returns>
        public virtual List<TBArea> GetList(string strSQL,Param param)
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
                dr.Close();
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
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>区域设置列表对象</returns>
        public virtual List<TBArea> GetList(string field, string value)
        {
            List<TBArea> list = new List<TBArea>();
            try
            {
                string strSQL = "select * from TBArea where " + field + "=@field";
                Param param = new Param();
                param.Clear();
                param.Add("@field",value);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while(dr.Read())
                {
                    list.Add(ReadData(dr));
                }
                dr.Close();
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
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>区域设置DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBArea");
        }
        
        /// <summary>
        /// 是否存在记录(区域设置)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBArea where " + field + "=@field";
                Param param = new Param();
                param.Clear();
                param.Add("@field",value);
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
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>区域设置对象</returns>
        protected virtual TBArea ReadData(ComDataReader dr)
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

