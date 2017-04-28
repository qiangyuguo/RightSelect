using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 终端
    /// Author:代码生成器
    /// </summary>
    public class TBTerminalDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加终端
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbTerminal">终端</param>
        public virtual void Add(DataAccess data,TBTerminal tbTerminal)
        {
            string strSQL = "insert into TBTerminal (terminalId,status,terminalType,supplierDate,supplierCode,supplierBatch,siteId,agentId,checkTime,touchscreenVersion,updateStatus) values (@terminalId,@status,@terminalType,To_date(@supplierDate,'yyyy-mm-dd hh24:mi:ss'),@supplierCode,@supplierBatch,@siteId,@agentId,To_date(@checkTime,'yyyy-mm-dd hh24:mi:ss'),@touchscreenVersion,@updateStatus)";
            Param param = new Param();
            param.Clear();
            param.Add("@terminalId", tbTerminal.terminalId);//终端编号
            param.Add("@status", tbTerminal.status);//当前状态
            param.Add("@terminalType", tbTerminal.terminalType);//终端类型
            param.Add("@supplierDate", tbTerminal.supplierDate);//出厂时间
            param.Add("@supplierCode", tbTerminal.supplierCode);//厂家代码
            param.Add("@supplierBatch", tbTerminal.supplierBatch);//厂家批次号
            param.Add("@siteId", tbTerminal.siteId);//门店编号
            param.Add("@agentId", tbTerminal.agentId);//代理商编号
            param.Add("@checkTime", tbTerminal.checkTime);//最新心跳时间
            param.Add("@touchscreenVersion", tbTerminal.touchscreenVersion);//触屏版本
            param.Add("@updateStatus", tbTerminal.updateStatus);//更新状态
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加终端
        /// </summary>
        /// <param name="tbTerminal">终端</param>
        public virtual void Add(TBTerminal tbTerminal)
        {
            try
            {
                db.Open();
                Add(db,tbTerminal);
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
        /// 修改终端
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbTerminal">终端</param>
        public virtual void Edit(DataAccess data,TBTerminal tbTerminal)
        {
            string strSQL = "update TBTerminal set status=@status,terminalType=@terminalType,supplierDate=To_date(@supplierDate,'yyyy-mm-dd hh24:mi:ss'),supplierCode=@supplierCode,supplierBatch=@supplierBatch,siteId=@siteId,agentId=@agentId,checkTime=To_date(@checkTime,'yyyy-mm-dd hh24:mi:ss'),touchscreenVersion=@touchscreenVersion,updateStatus=@updateStatus where terminalId=@terminalId";
            Param param = new Param();
            param.Clear();
            param.Add("@status", tbTerminal.status);//当前状态
            param.Add("@terminalType", tbTerminal.terminalType);//终端类型
            param.Add("@supplierDate", tbTerminal.supplierDate);//出厂时间
            param.Add("@supplierCode", tbTerminal.supplierCode);//厂家代码
            param.Add("@supplierBatch", tbTerminal.supplierBatch);//厂家批次号
            param.Add("@siteId", tbTerminal.siteId);//门店编号
            param.Add("@agentId", tbTerminal.agentId);//代理商编号
            param.Add("@checkTime", tbTerminal.checkTime);//最新心跳时间
            param.Add("@touchscreenVersion", tbTerminal.touchscreenVersion);//触屏版本
            param.Add("@updateStatus", tbTerminal.updateStatus);//更新状态
            param.Add("@terminalId", tbTerminal.terminalId);//终端编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改终端
        /// </summary>
        /// <param name="tbTerminal">终端</param>
        public virtual void Edit(TBTerminal tbTerminal)
        {
            try
            {
                db.Open();
                Edit(db,tbTerminal);
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
        /// 删除终端
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="terminalId">终端编号</param>
        public virtual void Delete(DataAccess data,string terminalId)
        {
            string strSQL = "delete from TBTerminal where terminalId=@terminalId";
            Param param = new Param();
            param.Clear();
            param.Add("@terminalId", terminalId);//终端编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除终端
        /// </summary>
        /// <param name="terminalId">终端编号</param>
        public virtual void Delete(string terminalId)
        {
            try
            {
                db.Open();
                Delete(db,terminalId);
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
        /// 获取终端
        /// </summary>
        /// <param name="terminalId">终端编号</param>
        /// <returns>终端对象</returns>
        public virtual TBTerminal Get(string terminalId)
        {
            TBTerminal tbTerminal=null;
            try
            {
                string strSQL = "select * from TBTerminal where terminalId=@terminalId";
                Param param = new Param();
                param.Clear();
                param.Add("@terminalId", terminalId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbTerminal=ReadData(dr);
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
            return tbTerminal;
        }
        
        /// <summary>
        /// 获取列表(终端)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>终端列表对象</returns>
        public virtual List<TBTerminal> GetList(string strSQL,Param param)
        {
            List<TBTerminal> list = new List<TBTerminal>();
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
        /// 获取列表(终端)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>终端列表对象</returns>
        public virtual List<TBTerminal> GetList(string field, string value)
        {
            List<TBTerminal> list = new List<TBTerminal>();
            try
            {
                string strSQL = "select * from TBTerminal where " + field + "=@field";
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
        /// 获取DataSet(终端)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>终端DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBTerminal");
        }
        
        /// <summary>
        /// 是否存在记录(终端)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBTerminal where " + field + "=@field";
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
        /// 读取终端信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>终端对象</returns>
        protected virtual TBTerminal ReadData(ComDataReader dr)
        {
            TBTerminal tbTerminal= new TBTerminal();
            tbTerminal.terminalId= dr["terminalId"].ToString();//终端编号
            tbTerminal.status= dr["status"].ToString();//当前状态
            tbTerminal.terminalType= dr["terminalType"].ToString();//终端类型
            if(dr["supplierDate"]==null)
            {
                tbTerminal.supplierDate= "";//出厂时间
            }
            else
            {
                tbTerminal.supplierDate= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["supplierDate"]);//出厂时间
            }
            tbTerminal.supplierCode= dr["supplierCode"].ToString();//厂家代码
            tbTerminal.supplierBatch= dr["supplierBatch"].ToString();//厂家批次号
            tbTerminal.siteId= dr["siteId"].ToString();//门店编号
            tbTerminal.agentId= dr["agentId"].ToString();//代理商编号
            if(dr["checkTime"]==null)
            {
                tbTerminal.checkTime= "";//最新心跳时间
            }
            else
            {
                tbTerminal.checkTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["checkTime"]);//最新心跳时间
            }
            tbTerminal.touchscreenVersion= dr["touchscreenVersion"].ToString();//触屏版本
            tbTerminal.updateStatus= dr["updateStatus"].ToString();//更新状态
            return tbTerminal;
        }
        
        
        #endregion
        
    }
}

