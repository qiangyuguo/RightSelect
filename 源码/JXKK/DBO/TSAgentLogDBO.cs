using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 代理系统日志
    /// Author:代码生成器
    /// </summary>
    public class TSAgentLogDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加代理系统日志
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsAgentLog">代理系统日志</param>
        public virtual void Add(DataAccess data,TSAgentLog tsAgentLog)
        {
            string strSQL = "insert into TSAgentLog (logId,userId,userName,type,siteId,siteName,agentId,agentName,moduleName,userEvent,createDate) values (@logId,@userId,@userName,@type,@siteId,@siteName,@agentId,@agentName,@moduleName,@userEvent,To_date(@createDate,'yyyy-mm-dd hh24:mi:ss'))";
            Param param = new Param();
            param.Clear();
            param.Add("@logId", tsAgentLog.logId);//日志编号
            param.Add("@userId", tsAgentLog.userId);//用户编号
            param.Add("@userName", tsAgentLog.userName);//用户姓名
            param.Add("@type", tsAgentLog.type);//角色类型
            param.Add("@siteId", tsAgentLog.siteId);//门店编号
            param.Add("@siteName", tsAgentLog.siteName);//门店名称
            param.Add("@agentId", tsAgentLog.agentId);//代理商编号
            param.Add("@agentName", tsAgentLog.agentName);//代理商名称
            param.Add("@moduleName", tsAgentLog.moduleName);//模块名称
            param.Add("@userEvent", tsAgentLog.userEvent);//操作事件
            param.Add("@createDate", tsAgentLog.createDate);//操作时间
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加代理系统日志
        /// </summary>
        /// <param name="tsAgentLog">代理系统日志</param>
        public virtual void Add(TSAgentLog tsAgentLog)
        {
            try
            {
                db.Open();
                Add(db,tsAgentLog);
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
        /// 修改代理系统日志
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsAgentLog">代理系统日志</param>
        public virtual void Edit(DataAccess data,TSAgentLog tsAgentLog)
        {
            string strSQL = "update TSAgentLog set userId=@userId,userName=@userName,type=@type,siteId=@siteId,siteName=@siteName,agentId=@agentId,agentName=@agentName,moduleName=@moduleName,userEvent=@userEvent,createDate=To_date(@createDate,'yyyy-mm-dd hh24:mi:ss') where logId=@logId";
            Param param = new Param();
            param.Clear();
            param.Add("@userId", tsAgentLog.userId);//用户编号
            param.Add("@userName", tsAgentLog.userName);//用户姓名
            param.Add("@type", tsAgentLog.type);//角色类型
            param.Add("@siteId", tsAgentLog.siteId);//门店编号
            param.Add("@siteName", tsAgentLog.siteName);//门店名称
            param.Add("@agentId", tsAgentLog.agentId);//代理商编号
            param.Add("@agentName", tsAgentLog.agentName);//代理商名称
            param.Add("@moduleName", tsAgentLog.moduleName);//模块名称
            param.Add("@userEvent", tsAgentLog.userEvent);//操作事件
            param.Add("@createDate", tsAgentLog.createDate);//操作时间
            param.Add("@logId", tsAgentLog.logId);//日志编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改代理系统日志
        /// </summary>
        /// <param name="tsAgentLog">代理系统日志</param>
        public virtual void Edit(TSAgentLog tsAgentLog)
        {
            try
            {
                db.Open();
                Edit(db,tsAgentLog);
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
        /// 删除代理系统日志
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="logId">日志编号</param>
        public virtual void Delete(DataAccess data,long logId)
        {
            string strSQL = "delete from TSAgentLog where logId=@logId";
            Param param = new Param();
            param.Clear();
            param.Add("@logId", logId);//日志编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除代理系统日志
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
        /// 获取代理系统日志
        /// </summary>
        /// <param name="logId">日志编号</param>
        /// <returns>代理系统日志对象</returns>
        public virtual TSAgentLog Get(long logId)
        {
            TSAgentLog tsAgentLog=null;
            try
            {
                string strSQL = "select * from TSAgentLog where logId=@logId";
                Param param = new Param();
                param.Clear();
                param.Add("@logId", logId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsAgentLog=ReadData(dr);
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
            return tsAgentLog;
        }
        
        /// <summary>
        /// 获取列表(代理系统日志)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理系统日志列表对象</returns>
        public virtual List<TSAgentLog> GetList(string strSQL,Param param)
        {
            List<TSAgentLog> list = new List<TSAgentLog>();
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
        /// 获取列表(代理系统日志)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>代理系统日志列表对象</returns>
        public virtual List<TSAgentLog> GetList(string field, string value)
        {
            List<TSAgentLog> list = new List<TSAgentLog>();
            try
            {
                string strSQL = "select * from TSAgentLog where " + field + "=@field";
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
        /// 获取DataSet(代理系统日志)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理系统日志DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSAgentLog");
        }
        
        /// <summary>
        /// 是否存在记录(代理系统日志)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSAgentLog where " + field + "=@field";
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
        /// 读取代理系统日志信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>代理系统日志对象</returns>
        protected virtual TSAgentLog ReadData(ComDataReader dr)
        {
            TSAgentLog tsAgentLog= new TSAgentLog();
            tsAgentLog.logId= long.Parse(dr["logId"].ToString());//日志编号
            tsAgentLog.userId= dr["userId"].ToString();//用户编号
            tsAgentLog.userName= dr["userName"].ToString();//用户姓名
            tsAgentLog.type= dr["type"].ToString();//角色类型
            tsAgentLog.siteId= dr["siteId"].ToString();//门店编号
            tsAgentLog.siteName= dr["siteName"].ToString();//门店名称
            tsAgentLog.agentId= dr["agentId"].ToString();//代理商编号
            tsAgentLog.agentName= dr["agentName"].ToString();//代理商名称
            tsAgentLog.moduleName= dr["moduleName"].ToString();//模块名称
            tsAgentLog.userEvent= dr["userEvent"].ToString();//操作事件
            if(dr["createDate"]==null)
            {
                tsAgentLog.createDate= "";//操作时间
            }
            else
            {
                tsAgentLog.createDate= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createDate"]);//操作时间
            }
            return tsAgentLog;
        }
        
        
        #endregion
        
    }
}

