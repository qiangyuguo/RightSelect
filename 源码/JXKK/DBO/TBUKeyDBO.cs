using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// UKey信息
    /// Author:代码生成器
    /// </summary>
    public class TBUKeyDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加UKey信息
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbUKey">UKey信息</param>
        public virtual void Add(DataAccess data,TBUKey tbUKey)
        {
            string strSQL = "insert into TBUKey (uKeyId,chipId,data,status,siteId,agentId) values (@uKeyId,@chipId,@data,@status,@siteId,@agentId)";
            Param param = new Param();
            param.Clear();
            param.Add("@uKeyId", tbUKey.uKeyId);//加密狗编号
            param.Add("@chipId", tbUKey.chipId);//内置编号
            param.Add("@data", tbUKey.data);//加密数据
            param.Add("@status", tbUKey.status);//当前状态
            param.Add("@siteId", tbUKey.siteId);//门店编号
            param.Add("@agentId", tbUKey.agentId);//代理商编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加UKey信息
        /// </summary>
        /// <param name="tbUKey">UKey信息</param>
        public virtual void Add(TBUKey tbUKey)
        {
            try
            {
                db.Open();
                Add(db,tbUKey);
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
        /// 修改UKey信息
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbUKey">UKey信息</param>
        public virtual void Edit(DataAccess data,TBUKey tbUKey)
        {
            string strSQL = "update TBUKey set chipId=@chipId,data=@data,status=@status,siteId=@siteId,agentId=@agentId where uKeyId=@uKeyId";
            Param param = new Param();
            param.Clear();
            param.Add("@chipId", tbUKey.chipId);//内置编号
            param.Add("@data", tbUKey.data);//加密数据
            param.Add("@status", tbUKey.status);//当前状态
            param.Add("@siteId", tbUKey.siteId);//门店编号
            param.Add("@agentId", tbUKey.agentId);//代理商编号
            param.Add("@uKeyId", tbUKey.uKeyId);//加密狗编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改UKey信息
        /// </summary>
        /// <param name="tbUKey">UKey信息</param>
        public virtual void Edit(TBUKey tbUKey)
        {
            try
            {
                db.Open();
                Edit(db,tbUKey);
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
        /// 删除UKey信息
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="uKeyId">加密狗编号</param>
        public virtual void Delete(DataAccess data,string uKeyId)
        {
            string strSQL = "delete from TBUKey where uKeyId=@uKeyId";
            Param param = new Param();
            param.Clear();
            param.Add("@uKeyId", uKeyId);//加密狗编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除UKey信息
        /// </summary>
        /// <param name="uKeyId">加密狗编号</param>
        public virtual void Delete(string uKeyId)
        {
            try
            {
                db.Open();
                Delete(db,uKeyId);
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
        /// 获取UKey信息
        /// </summary>
        /// <param name="uKeyId">加密狗编号</param>
        /// <returns>UKey信息对象</returns>
        public virtual TBUKey Get(string uKeyId)
        {
            TBUKey tbUKey=null;
            try
            {
                string strSQL = "select * from TBUKey where uKeyId=@uKeyId";
                Param param = new Param();
                param.Clear();
                param.Add("@uKeyId", uKeyId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbUKey=ReadData(dr);
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
            return tbUKey;
        }
        
        /// <summary>
        /// 获取列表(UKey信息)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>UKey信息列表对象</returns>
        public virtual List<TBUKey> GetList(string strSQL,Param param)
        {
            List<TBUKey> list = new List<TBUKey>();
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
        /// 获取列表(UKey信息)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>UKey信息列表对象</returns>
        public virtual List<TBUKey> GetList(string field, string value)
        {
            List<TBUKey> list = new List<TBUKey>();
            try
            {
                string strSQL = "select * from TBUKey where " + field + "=@field";
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
        /// 获取DataSet(UKey信息)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>UKey信息DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBUKey");
        }
        
        /// <summary>
        /// 是否存在记录(UKey信息)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBUKey where " + field + "=@field";
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
        /// 读取UKey信息信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>UKey信息对象</returns>
        protected virtual TBUKey ReadData(ComDataReader dr)
        {
            TBUKey tbUKey= new TBUKey();
            tbUKey.uKeyId= dr["uKeyId"].ToString();//加密狗编号
            tbUKey.chipId= dr["chipId"].ToString();//内置编号
            tbUKey.data= dr["data"].ToString();//加密数据
            tbUKey.status= dr["status"].ToString();//当前状态
            tbUKey.siteId= dr["siteId"].ToString();//门店编号
            tbUKey.agentId= dr["agentId"].ToString();//代理商编号
            return tbUKey;
        }
        
        
        #endregion
        
    }
}

