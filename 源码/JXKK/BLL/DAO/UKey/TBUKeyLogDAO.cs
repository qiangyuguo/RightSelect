using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.UKey;

namespace Com.ZY.JXKK.DAO.UKey
{
    /// <summary>
    /// 加密狗日志
    /// Author:代码生成器
    /// </summary>
    public class TBUKeyLogDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加加密狗日志
        /// <param name="data">数据库连接</param>
        /// <param name="tbUKeyLog">加密狗日志</param>
        /// </summary>
        public void Add(DataAccess data,TBUKeyLog tbUKeyLog)
        {
            string strSQL = "insert into TBUKeyLog (logId,uKeyId,operateType,summary,operateTime,operatorId,operatorName) values (SUKeyLog_logId.Nextval,:uKeyId,:operateType,:summary,To_date(:operateTime,'yyyy-mm-dd hh24:mi:ss'),:operatorId,:operatorName)";
            Param param = new Param();
            param.Clear();
            //param.Add(":logId", tbUKeyLog.logId);//日志编号
            param.Add(":uKeyId", tbUKeyLog.uKeyId);//加密狗编号
            param.Add(":operateType", tbUKeyLog.operateType);//操作类型
            param.Add(":summary", tbUKeyLog.summary);//操作说明
            param.Add(":operateTime", tbUKeyLog.operateTime);//操作时间
            param.Add(":operatorId", tbUKeyLog.operatorId);//操作人编号
            param.Add(":operatorName", tbUKeyLog.operatorName);//操作人名称
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加加密狗日志
        /// <param name="tbUKeyLog">加密狗日志</param>
        /// </summary>
        public void Add(TBUKeyLog tbUKeyLog)
        {
            try
            {
                db.Open();
                Add(db,tbUKeyLog);
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
        /// 修改加密狗日志
        /// <param name="data">数据库连接</param>
        /// <param name="tbUKeyLog">加密狗日志</param>
        /// </summary>
        public void Edit(DataAccess data,TBUKeyLog tbUKeyLog)
        {
            string strSQL = "update TBUKeyLog set uKeyId=:uKeyId,operateType=:operateType,summary=:summary,operateTime=To_date(:operateTime,'yyyy-mm-dd hh24:mi:ss'),operatorId=:operatorId,operatorName=:operatorName where logId=:logId";
            Param param = new Param();
            param.Clear();
            param.Add(":uKeyId", tbUKeyLog.uKeyId);//加密狗编号
            param.Add(":operateType", tbUKeyLog.operateType);//操作类型
            param.Add(":summary", tbUKeyLog.summary);//操作说明
            param.Add(":operateTime", tbUKeyLog.operateTime);//操作时间
            param.Add(":operatorId", tbUKeyLog.operatorId);//操作人编号
            param.Add(":operatorName", tbUKeyLog.operatorName);//操作人名称
            param.Add(":logId", tbUKeyLog.logId);//日志编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改加密狗日志
        /// <param name="tbUKeyLog">加密狗日志</param>
        /// </summary>
        public void Edit(TBUKeyLog tbUKeyLog)
        {
            try
            {
                db.Open();
                Edit(db,tbUKeyLog);
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
        /// 删除加密狗日志
        /// <param name="data">数据库连接</param>
        /// <param name="logId">日志编号</param>
        /// </summary>
        public void Delete(DataAccess data,long logId)
        {
            string strSQL = "delete from TBUKeyLog where logId=:logId";
            Param param = new Param();
            param.Clear();
            param.Add(":logId", logId);//日志编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除加密狗日志
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
        /// 获取加密狗日志
        /// <param name="logId">日志编号</param>
        /// </summary>
        /// <returns>加密狗日志对象</returns>
        public TBUKeyLog Get(long logId)
        {
            TBUKeyLog tbUKeyLog=null;
            try
            {
                string strSQL = "select * from TBUKeyLog where logId=:logId";
                Param param = new Param();
                param.Clear();
                param.Add(":logId", logId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbUKeyLog=ReadData(dr);
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
            return tbUKeyLog;
        }
        
        /// <summary>
        /// 获取列表(加密狗日志)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>加密狗日志列表对象</returns>
        public List<TBUKeyLog> GetList(string strSQL,Param param)
        {
            List<TBUKeyLog> list = new List<TBUKeyLog>();
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
        /// 获取列表(加密狗日志)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>加密狗日志列表对象</returns>
        public List<TBUKeyLog> GetList(string field, string value)
        {
            List<TBUKeyLog> list = new List<TBUKeyLog>();
            try
            {
                string strSQL = "select * from TBUKeyLog where " + field + "=:field";
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
        /// 获取DataSet(加密狗日志)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>加密狗日志DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBUKeyLog");
        }
        
        /// <summary>
        /// 是否存在记录(加密狗日志)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBUKeyLog where " + field + "=:field";
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
        /// 读取加密狗日志信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>加密狗日志对象</returns>
        private TBUKeyLog ReadData(ComDataReader dr)
        {
            TBUKeyLog tbUKeyLog= new TBUKeyLog();
            tbUKeyLog.logId= long.Parse(dr["logId"].ToString());//日志编号
            tbUKeyLog.uKeyId= dr["uKeyId"].ToString();//加密狗编号
            tbUKeyLog.operateType= dr["operateType"].ToString();//操作类型
            tbUKeyLog.summary= dr["summary"].ToString();//操作说明
            if(dr["operateTime"]==null)
            {
                tbUKeyLog.operateTime= "";//操作时间
            }
            else
            {
                tbUKeyLog.operateTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["operateTime"]);//操作时间
            }
            tbUKeyLog.operatorId= dr["operatorId"].ToString();//操作人编号
            tbUKeyLog.operatorName= dr["operatorName"].ToString();//操作人名称
            return tbUKeyLog;
        }
        
        
        #endregion
        
    }
}

