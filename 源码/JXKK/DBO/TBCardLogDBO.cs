using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 卡片日志
    /// Author:代码生成器
    /// </summary>
    public class TBCardLogDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加卡片日志
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbCardLog">卡片日志</param>
        public virtual void Add(DataAccess data,TBCardLog tbCardLog)
        {
            string strSQL = "insert into TBCardLog (logId,cardId,operateType,summary,operateTime,operatorId,operatorName) values (@logId,@cardId,@operateType,@summary,To_date(@operateTime,'yyyy-mm-dd hh24:mi:ss'),@operatorId,@operatorName)";
            Param param = new Param();
            param.Clear();
            param.Add("@logId", tbCardLog.logId);//日志编号
            param.Add("@cardId", tbCardLog.cardId);//卡号
            param.Add("@operateType", tbCardLog.operateType);//操作类型
            param.Add("@summary", tbCardLog.summary);//操作说明
            param.Add("@operateTime", tbCardLog.operateTime);//操作时间
            param.Add("@operatorId", tbCardLog.operatorId);//操作人编号
            param.Add("@operatorName", tbCardLog.operatorName);//操作人名称
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加卡片日志
        /// </summary>
        /// <param name="tbCardLog">卡片日志</param>
        public virtual void Add(TBCardLog tbCardLog)
        {
            try
            {
                db.Open();
                Add(db,tbCardLog);
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
        /// 修改卡片日志
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbCardLog">卡片日志</param>
        public virtual void Edit(DataAccess data,TBCardLog tbCardLog)
        {
            string strSQL = "update TBCardLog set cardId=@cardId,operateType=@operateType,summary=@summary,operateTime=To_date(@operateTime,'yyyy-mm-dd hh24:mi:ss'),operatorId=@operatorId,operatorName=@operatorName where logId=@logId";
            Param param = new Param();
            param.Clear();
            param.Add("@cardId", tbCardLog.cardId);//卡号
            param.Add("@operateType", tbCardLog.operateType);//操作类型
            param.Add("@summary", tbCardLog.summary);//操作说明
            param.Add("@operateTime", tbCardLog.operateTime);//操作时间
            param.Add("@operatorId", tbCardLog.operatorId);//操作人编号
            param.Add("@operatorName", tbCardLog.operatorName);//操作人名称
            param.Add("@logId", tbCardLog.logId);//日志编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改卡片日志
        /// </summary>
        /// <param name="tbCardLog">卡片日志</param>
        public virtual void Edit(TBCardLog tbCardLog)
        {
            try
            {
                db.Open();
                Edit(db,tbCardLog);
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
        /// 删除卡片日志
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="logId">日志编号</param>
        public virtual void Delete(DataAccess data,long logId)
        {
            string strSQL = "delete from TBCardLog where logId=@logId";
            Param param = new Param();
            param.Clear();
            param.Add("@logId", logId);//日志编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除卡片日志
        /// </summary>
        /// <param name="logId">日志编号</param>
        public virtual void Delete(long logId)
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
        /// 获取卡片日志
        /// </summary>
        /// <param name="logId">日志编号</param>
        /// <returns>卡片日志对象</returns>
        public virtual TBCardLog Get(long logId)
        {
            TBCardLog tbCardLog=null;
            try
            {
                string strSQL = "select * from TBCardLog where logId=@logId";
                Param param = new Param();
                param.Clear();
                param.Add("@logId", logId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbCardLog=ReadData(dr);
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
            return tbCardLog;
        }
        
        /// <summary>
        /// 获取列表(卡片日志)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>卡片日志列表对象</returns>
        public virtual List<TBCardLog> GetList(string strSQL,Param param)
        {
            List<TBCardLog> list = new List<TBCardLog>();
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
        /// 获取列表(卡片日志)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>卡片日志列表对象</returns>
        public virtual List<TBCardLog> GetList(string field, string value)
        {
            List<TBCardLog> list = new List<TBCardLog>();
            try
            {
                string strSQL = "select * from TBCardLog where " + field + "=@field";
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
        /// 获取DataSet(卡片日志)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>卡片日志DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBCardLog");
        }
        
        /// <summary>
        /// 是否存在记录(卡片日志)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBCardLog where " + field + "=@field";
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
        /// 读取卡片日志信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>卡片日志对象</returns>
        protected virtual TBCardLog ReadData(ComDataReader dr)
        {
            TBCardLog tbCardLog= new TBCardLog();
            tbCardLog.logId= long.Parse(dr["logId"].ToString());//日志编号
            tbCardLog.cardId= dr["cardId"].ToString();//卡号
            tbCardLog.operateType= dr["operateType"].ToString();//操作类型
            tbCardLog.summary= dr["summary"].ToString();//操作说明
            if(dr["operateTime"]==null)
            {
                tbCardLog.operateTime= "";//操作时间
            }
            else
            {
                tbCardLog.operateTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["operateTime"]);//操作时间
            }
            tbCardLog.operatorId= dr["operatorId"].ToString();//操作人编号
            tbCardLog.operatorName= dr["operatorName"].ToString();//操作人名称
            return tbCardLog;
        }
        
        
        #endregion
        
    }
}

