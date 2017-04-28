using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Manage
{
    /// <summary>
    /// 系统日志
    /// Author:开发人员自行扩展
    /// </summary>
    public class TSLogDAO:TSLogDBO
    {
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
        public override void Add(DataAccess data, TSLog tsLog)
        {
            string strSQL = "insert into TSLog (logId,userId,userName,deptId,deptName,moduleName,userEvent) values (@logId,@userId,@userName,@deptId,@deptName,@moduleName,@userEvent)";
            Param param = new Param();
            param.Clear();
            param.Add("@logId", tsLog.logId);//日志编号{【修改】数据库序列号}
            param.Add("@userId", tsLog.userId);//用户编号
            param.Add("@userName", tsLog.userName);//用户姓名
            param.Add("@deptId", tsLog.deptId);//部门编号
            param.Add("@deptName", tsLog.deptName);//部门名称
            param.Add("@moduleName", tsLog.moduleName);//模块名称
            param.Add("@userEvent", tsLog.userEvent);//操作事件
            //param.Add("@createDate", tsLog.createDate);//操作时间{【修改】数据库系统时间}
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
    }
}

