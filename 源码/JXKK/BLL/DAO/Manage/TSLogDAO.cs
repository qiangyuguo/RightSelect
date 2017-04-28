using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Manage;

namespace Com.ZY.JXKK.DAO.Manage
{
    /// <summary>
    /// 系统日志
    /// Author:代码生成器
    /// </summary>
    public class TSLogDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接

        /// <summary>
        /// 删除日志【新增】
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="startDate">起始时间</param>
        /// <param name="endDate">结束时间</param>
        public void Delete(string userName, string startDate, string endDate)
        {
            string strSQL = "delete from TSLog where 1=1 ";
            if (startDate != null && !"".Equals(startDate))
                strSQL += " and createDate >= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (endDate != null && !"".Equals(endDate))
                strSQL += " and createDate <= To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            if (userName != null && !"".Equals(userName))
                strSQL += " and userName ='" + userName + "'";
            try
            {
                db.Open();
                db.ExecuteNonQuery(CommandType.Text, strSQL, null);
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
        /// 增加系统日志
        /// <param name="data">数据库连接</param>
        /// <param name="tsLog">系统日志</param>
        /// </summary>
        public void Add(DataAccess data,TSLog tsLog)
        {
            string strSQL = "insert into TSLog (logId,userId,userName,deptId,deptName,moduleName,userEvent) values (SLog_logId.Nextval,:userId,:userName,:deptId,:deptName,:moduleName,:userEvent)";
            Param param = new Param();
            param.Clear();
            //param.Add(":logId", tsLog.logId);//日志编号{【修改】数据库序列号}
            param.Add(":userId", tsLog.userId);//用户编号
            param.Add(":userName", tsLog.userName);//用户姓名
            param.Add(":deptId", tsLog.deptId);//部门编号
            param.Add(":deptName", tsLog.deptName);//部门名称
            param.Add(":moduleName", tsLog.moduleName);//模块名称
            param.Add(":userEvent", tsLog.userEvent);//操作事件
            //param.Add(":createDate", tsLog.createDate);//操作时间{【修改】数据库系统时间}
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        #region 代码生成器自动生成

        /// <summary>
        /// 增加系统日志
        /// <param name="tsLog">系统日志</param>
        /// </summary>
        public void Add(TSLog tsLog)
        {
            try
            {
                db.Open();
                Add(db, tsLog);
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
        /// 修改系统日志
        /// <param name="data">数据库连接</param>
        /// <param name="tsLog">系统日志</param>
        /// </summary>
        public void Edit(DataAccess data, TSLog tsLog)
        {
            string strSQL = "update TSLog set userId=:userId,userName=:userName,deptId=:deptId,deptName=:deptName,moduleName=:moduleName,userEvent=:userEvent,createDate=To_date(:createDate,'yyyy-mm-dd hh24:mi:ss') where logId=:logId";
            Param param = new Param();
            param.Clear();
            param.Add(":userId", tsLog.userId);//用户编号
            param.Add(":userName", tsLog.userName);//用户姓名
            param.Add(":deptId", tsLog.deptId);//部门编号
            param.Add(":deptName", tsLog.deptName);//部门名称
            param.Add(":moduleName", tsLog.moduleName);//模块名称
            param.Add(":userEvent", tsLog.userEvent);//操作事件
            param.Add(":createDate", tsLog.createDate);//操作时间
            param.Add(":logId", tsLog.logId);//日志编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 修改系统日志
        /// <param name="tsLog">系统日志</param>
        /// </summary>
        public void Edit(TSLog tsLog)
        {
            try
            {
                db.Open();
                Edit(db, tsLog);
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
        /// 删除系统日志
        /// <param name="data">数据库连接</param>
        /// <param name="logId">日志编号</param>
        /// </summary>
        public void Delete(DataAccess data, long logId)
        {
            string strSQL = "delete from TSLog where logId=:logId";
            Param param = new Param();
            param.Clear();
            param.Add(":logId", logId);//日志编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 删除系统日志
        /// <param name="logId">日志编号</param>
        /// </summary>
        public void Delete(long logId)
        {
            try
            {
                db.Open();
                Delete(db, logId);
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
        /// 获取系统日志
        /// <param name="logId">日志编号</param>
        /// </summary>
        /// <returns>系统日志对象</returns>
        public TSLog Get(long logId)
        {
            TSLog tsLog = null;
            try
            {
                string strSQL = "select * from TSLog where logId=:logId";
                Param param = new Param();
                param.Clear();
                param.Add(":logId", logId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsLog = ReadData(dr);
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
            return tsLog;
        }

        /// <summary>
        /// 获取列表(系统日志)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>系统日志列表对象</returns>
        public List<TSLog> GetList(string strSQL, Param param)
        {
            List<TSLog> list = new List<TSLog>();
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while (dr.Read())
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
        /// 获取列表(系统日志)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>系统日志列表对象</returns>
        public List<TSLog> GetList(string field, string value)
        {
            List<TSLog> list = new List<TSLog>();
            try
            {
                string strSQL = "select * from TSLog where " + field + "=:field";
                Param param = new Param();
                param.Clear();
                param.Add(":field", value);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while (dr.Read())
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
        /// 获取DataSet(系统日志)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>系统日志DataSet</returns>
        public DataSet GetDataSet(string strSQL, Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSLog");
        }

        /// <summary>
        /// 是否存在记录(系统日志)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSLog where " + field + "=:field";
                Param param = new Param();
                param.Clear();
                param.Add(":field", value);
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
        /// 读取系统日志信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>系统日志对象</returns>
        private TSLog ReadData(ComDataReader dr)
        {
            TSLog tsLog = new TSLog();
            tsLog.logId = long.Parse(dr["logId"].ToString());//日志编号
            tsLog.userId = dr["userId"].ToString();//用户编号
            tsLog.userName = dr["userName"].ToString();//用户姓名
            tsLog.deptId = dr["deptId"].ToString();//部门编号
            tsLog.deptName = dr["deptName"].ToString();//部门名称
            tsLog.moduleName = dr["moduleName"].ToString();//模块名称
            tsLog.userEvent = dr["userEvent"].ToString();//操作事件
            if (dr["createDate"] == null)
            {
                tsLog.createDate = "";//操作时间
            }
            else
            {
                tsLog.createDate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dr["createDate"]);//操作时间
            }
            return tsLog;
        }


        #endregion
    }
}

