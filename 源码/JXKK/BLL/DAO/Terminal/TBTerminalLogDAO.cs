using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Terminal;

namespace Com.ZY.JXKK.DAO.Terminal
{
    /// <summary>
    /// 终端日志
    /// Author:代码生成器
    /// </summary>
    public class TBTerminalLogDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加终端日志
        /// <param name="data">数据库连接</param>
        /// <param name="tbTerminalLog">终端日志</param>
        /// </summary>
        public void Add(DataAccess data,TBTerminalLog tbTerminalLog)
        {
            string strSQL = "insert into TBTerminalLog (logId,terminalId,operateType,summary,operateTime,operatorId,operatorName) values (STerminalLog_logId.Nextval,:terminalId,:operateType,:summary,To_date(:operateTime,'yyyy-mm-dd hh24:mi:ss'),:operatorId,:operatorName)";
            Param param = new Param();
            param.Clear();
            //param.Add(":logId", tbTerminalLog.logId);//日志编号
            param.Add(":terminalId", tbTerminalLog.terminalId);//终端编号
            param.Add(":operateType", tbTerminalLog.operateType);//操作类型
            param.Add(":summary", tbTerminalLog.summary);//操作说明
            param.Add(":operateTime", tbTerminalLog.operateTime);//操作时间
            param.Add(":operatorId", tbTerminalLog.operatorId);//操作人编号
            param.Add(":operatorName", tbTerminalLog.operatorName);//操作人名称
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加终端日志
        /// <param name="tbTerminalLog">终端日志</param>
        /// </summary>
        public void Add(TBTerminalLog tbTerminalLog)
        {
            try
            {
                db.Open();
                Add(db,tbTerminalLog);
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
        /// 修改终端日志
        /// <param name="data">数据库连接</param>
        /// <param name="tbTerminalLog">终端日志</param>
        /// </summary>
        public void Edit(DataAccess data,TBTerminalLog tbTerminalLog)
        {
            string strSQL = "update TBTerminalLog set terminalId=:terminalId,operateType=:operateType,summary=:summary,operateTime=To_date(:operateTime,'yyyy-mm-dd hh24:mi:ss'),operatorId=:operatorId,operatorName=:operatorName where logId=:logId";
            Param param = new Param();
            param.Clear();
            param.Add(":terminalId", tbTerminalLog.terminalId);//终端编号
            param.Add(":operateType", tbTerminalLog.operateType);//操作类型
            param.Add(":summary", tbTerminalLog.summary);//操作说明
            param.Add(":operateTime", tbTerminalLog.operateTime);//操作时间
            param.Add(":operatorId", tbTerminalLog.operatorId);//操作人编号
            param.Add(":operatorName", tbTerminalLog.operatorName);//操作人名称
            param.Add(":logId", tbTerminalLog.logId);//日志编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改终端日志
        /// <param name="tbTerminalLog">终端日志</param>
        /// </summary>
        public void Edit(TBTerminalLog tbTerminalLog)
        {
            try
            {
                db.Open();
                Edit(db,tbTerminalLog);
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
        /// 删除终端日志
        /// <param name="data">数据库连接</param>
        /// <param name="logId">日志编号</param>
        /// </summary>
        public void Delete(DataAccess data,long logId)
        {
            string strSQL = "delete from TBTerminalLog where logId=:logId";
            Param param = new Param();
            param.Clear();
            param.Add(":logId", logId);//日志编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除终端日志
        /// <param name="logId">日志编号</param>
        /// </summary>
        public void Delete(long logId)
        {
            try
            {
                db.Open();
                Delete(db,logId);
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
        /// 获取终端日志
        /// <param name="logId">日志编号</param>
        /// </summary>
        /// <returns>终端日志对象</returns>
        public TBTerminalLog Get(long logId)
        {
            TBTerminalLog tbTerminalLog=null;
            try
            {
                string strSQL = "select * from TBTerminalLog where logId=:logId";
                Param param = new Param();
                param.Clear();
                param.Add(":logId", logId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbTerminalLog=ReadData(dr);
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
            return tbTerminalLog;
        }
        
        /// <summary>
        /// 获取列表(终端日志)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>终端日志列表对象</returns>
        public List<TBTerminalLog> GetList(string strSQL,Param param)
        {
            List<TBTerminalLog> list = new List<TBTerminalLog>();
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
        /// 获取列表(终端日志)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>终端日志列表对象</returns>
        public List<TBTerminalLog> GetList(string field, string value)
        {
            List<TBTerminalLog> list = new List<TBTerminalLog>();
            try
            {
                string strSQL = "select * from TBTerminalLog where " + field + "=:field";
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
        /// 获取DataSet(终端日志)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>终端日志DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBTerminalLog");
        }
        
        /// <summary>
        /// 是否存在记录(终端日志)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBTerminalLog where " + field + "=:field";
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
        /// 读取终端日志信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>终端日志对象</returns>
        private TBTerminalLog ReadData(ComDataReader dr)
        {
            TBTerminalLog tbTerminalLog= new TBTerminalLog();
            tbTerminalLog.logId= long.Parse(dr["logId"].ToString());//日志编号
            tbTerminalLog.terminalId= dr["terminalId"].ToString();//终端编号
            tbTerminalLog.operateType= dr["operateType"].ToString();//操作类型
            tbTerminalLog.summary= dr["summary"].ToString();//操作说明
            if(dr["operateTime"]==null)
            {
                tbTerminalLog.operateTime= "";//操作时间
            }
            else
            {
                tbTerminalLog.operateTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["operateTime"]);//操作时间
            }
            tbTerminalLog.operatorId= dr["operatorId"].ToString();//操作人编号
            tbTerminalLog.operatorName= dr["operatorName"].ToString();//操作人名称
            return tbTerminalLog;
        }
        
        
        #endregion
        
    }
}

