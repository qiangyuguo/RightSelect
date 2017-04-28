using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理系统日志
    /// Author:开发人员自行扩展
    /// </summary>
    public class TSAgentLogDAO:TSAgentLogDBO
    {

        /// <summary>
        /// 增加代理系统日志
        /// <param name="data">数据库连接</param>
        /// <param name="tsAgentLog">代理系统日志</param>
        /// </summary>
        public override void Add(DataAccess data, TSAgentLog tsAgentLog)
        {
            string strSQL = "insert into TSAgentLog (logId,userId,userName,type,siteId,siteName,agentId,agentName,moduleName,userEvent) values (SAgentLog_logId.Nextval,@userId,@userName,@type,@siteId,@siteName,@agentId,@agentName,@moduleName,@userEvent)";
            Param param = new Param();
            param.Clear();
            //param.Add("@logId", tsAgentLog.logId);//日志编号
            param.Add("@userId", tsAgentLog.userId);//用户编号
            param.Add("@userName", tsAgentLog.userName);//用户姓名
            param.Add("@type", tsAgentLog.type);//角色类型
            param.Add("@siteId", tsAgentLog.siteId);//门店编号
            param.Add("@siteName", tsAgentLog.siteName);//门店名称
            param.Add("@agentId", tsAgentLog.agentId);//代理商编号
            param.Add("@agentName", tsAgentLog.agentName);//代理商名称
            param.Add("@moduleName", tsAgentLog.moduleName);//模块名称
            param.Add("@userEvent", tsAgentLog.userEvent);//操作事件
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
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
    }
}

