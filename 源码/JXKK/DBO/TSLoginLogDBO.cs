using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 收银登录日志
    /// Author:代码生成器
    /// </summary>
    public class TSLoginLogDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加收银登录日志
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsLoginLog">收银登录日志</param>
        public virtual void Add(DataAccess data,TSLoginLog tsLoginLog)
        {
            string strSQL = "insert into TSLoginLog (logId,staffId,staffName,siteId,siteName,agentId,agentName,softVersion,uKeyId,ip,mac,loginDate) values (@logId,@staffId,@staffName,@siteId,@siteName,@agentId,@agentName,@softVersion,@uKeyId,@ip,@mac,To_date(@loginDate,'yyyy-mm-dd hh24:mi:ss'))";
            Param param = new Param();
            param.Clear();
            param.Add("@logId", tsLoginLog.logId);//日志编号
            param.Add("@staffId", tsLoginLog.staffId);//员工编号
            param.Add("@staffName", tsLoginLog.staffName);//员工姓名
            param.Add("@siteId", tsLoginLog.siteId);//门店编号
            param.Add("@siteName", tsLoginLog.siteName);//门店名称
            param.Add("@agentId", tsLoginLog.agentId);//代理商编号
            param.Add("@agentName", tsLoginLog.agentName);//代理商名称
            param.Add("@softVersion", tsLoginLog.softVersion);//软件版本
            param.Add("@uKeyId", tsLoginLog.uKeyId);//加密狗编号
            param.Add("@ip", tsLoginLog.ip);//IP地址
            param.Add("@mac", tsLoginLog.mac);//网卡MAC
            param.Add("@loginDate", tsLoginLog.loginDate);//登录时间
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加收银登录日志
        /// </summary>
        /// <param name="tsLoginLog">收银登录日志</param>
        public virtual void Add(TSLoginLog tsLoginLog)
        {
            try
            {
                db.Open();
                Add(db,tsLoginLog);
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
        /// 修改收银登录日志
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsLoginLog">收银登录日志</param>
        public virtual void Edit(DataAccess data,TSLoginLog tsLoginLog)
        {
            string strSQL = "update TSLoginLog set staffId=@staffId,staffName=@staffName,siteId=@siteId,siteName=@siteName,agentId=@agentId,agentName=@agentName,softVersion=@softVersion,uKeyId=@uKeyId,ip=@ip,mac=@mac,loginDate=To_date(@loginDate,'yyyy-mm-dd hh24:mi:ss') where logId=@logId";
            Param param = new Param();
            param.Clear();
            param.Add("@staffId", tsLoginLog.staffId);//员工编号
            param.Add("@staffName", tsLoginLog.staffName);//员工姓名
            param.Add("@siteId", tsLoginLog.siteId);//门店编号
            param.Add("@siteName", tsLoginLog.siteName);//门店名称
            param.Add("@agentId", tsLoginLog.agentId);//代理商编号
            param.Add("@agentName", tsLoginLog.agentName);//代理商名称
            param.Add("@softVersion", tsLoginLog.softVersion);//软件版本
            param.Add("@uKeyId", tsLoginLog.uKeyId);//加密狗编号
            param.Add("@ip", tsLoginLog.ip);//IP地址
            param.Add("@mac", tsLoginLog.mac);//网卡MAC
            param.Add("@loginDate", tsLoginLog.loginDate);//登录时间
            param.Add("@logId", tsLoginLog.logId);//日志编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改收银登录日志
        /// </summary>
        /// <param name="tsLoginLog">收银登录日志</param>
        public virtual void Edit(TSLoginLog tsLoginLog)
        {
            try
            {
                db.Open();
                Edit(db,tsLoginLog);
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
        /// 删除收银登录日志
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="logId">日志编号</param>
        public virtual void Delete(DataAccess data,long logId)
        {
            string strSQL = "delete from TSLoginLog where logId=@logId";
            Param param = new Param();
            param.Clear();
            param.Add("@logId", logId);//日志编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除收银登录日志
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
        /// 获取收银登录日志
        /// </summary>
        /// <param name="logId">日志编号</param>
        /// <returns>收银登录日志对象</returns>
        public virtual TSLoginLog Get(long logId)
        {
            TSLoginLog tsLoginLog=null;
            try
            {
                string strSQL = "select * from TSLoginLog where logId=@logId";
                Param param = new Param();
                param.Clear();
                param.Add("@logId", logId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsLoginLog=ReadData(dr);
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
            return tsLoginLog;
        }
        
        /// <summary>
        /// 获取列表(收银登录日志)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>收银登录日志列表对象</returns>
        public virtual List<TSLoginLog> GetList(string strSQL,Param param)
        {
            List<TSLoginLog> list = new List<TSLoginLog>();
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
        /// 获取列表(收银登录日志)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>收银登录日志列表对象</returns>
        public virtual List<TSLoginLog> GetList(string field, string value)
        {
            List<TSLoginLog> list = new List<TSLoginLog>();
            try
            {
                string strSQL = "select * from TSLoginLog where " + field + "=@field";
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
        /// 获取DataSet(收银登录日志)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>收银登录日志DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSLoginLog");
        }
        
        /// <summary>
        /// 是否存在记录(收银登录日志)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSLoginLog where " + field + "=@field";
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
        /// 读取收银登录日志信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>收银登录日志对象</returns>
        protected virtual TSLoginLog ReadData(ComDataReader dr)
        {
            TSLoginLog tsLoginLog= new TSLoginLog();
            tsLoginLog.logId= long.Parse(dr["logId"].ToString());//日志编号
            tsLoginLog.staffId= dr["staffId"].ToString();//员工编号
            tsLoginLog.staffName= dr["staffName"].ToString();//员工姓名
            tsLoginLog.siteId= dr["siteId"].ToString();//门店编号
            tsLoginLog.siteName= dr["siteName"].ToString();//门店名称
            tsLoginLog.agentId= dr["agentId"].ToString();//代理商编号
            tsLoginLog.agentName= dr["agentName"].ToString();//代理商名称
            tsLoginLog.softVersion= dr["softVersion"].ToString();//软件版本
            tsLoginLog.uKeyId= dr["uKeyId"].ToString();//加密狗编号
            tsLoginLog.ip= dr["ip"].ToString();//IP地址
            tsLoginLog.mac= dr["mac"].ToString();//网卡MAC
            if(dr["loginDate"]==null)
            {
                tsLoginLog.loginDate= "";//登录时间
            }
            else
            {
                tsLoginLog.loginDate= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["loginDate"]);//登录时间
            }
            return tsLoginLog;
        }
        
        
        #endregion
        
    }
}

