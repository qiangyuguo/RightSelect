using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Agent;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.Agent
{
    /// <summary>
    /// 代理系统日志
    /// Author:代码生成器
    /// </summary>
    public class AgentLogBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TSAgentLogDAO tsAgentLogDAO= new TSAgentLogDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginUser">登录对象信息</param>
        /// </summary>
        public AgentLogBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string userName, string startDate, string endDate)
        {
            string strSQL = "select * from TSAgentLog where 1=1";
            if (startDate != null && !"".Equals(startDate))
                strSQL += " and createDate >= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (endDate != null && !"".Equals(endDate))
                strSQL += " and createDate <= To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            if (userName != null && !"".Equals(userName))
                strSQL += " and userName ='" + userName + "'";
            strSQL += " order by logId desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定代理系统日志
        /// <param name="logId">日志编号</param>
        /// </summary>
        public void Load(long logId)
        {
            try
            {
                TSAgentLog tsAgentLog=tsAgentLogDAO.Get(logId);
                WebJson.ToJson(context, tsAgentLog);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加代理系统日志
        /// <param name="tsAgentLog">代理系统日志</param>
        /// </summary>
        public void Add(TSAgentLog tsAgentLog)
        {
            try
            {
                tsAgentLogDAO.Add(tsAgentLog);
                Message.success(context, "代理系统日志增加成功");
                loginSession.Log("XXXXXX代理系统日志增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理系统日志增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改代理系统日志
        /// <param name="tsAgentLog">代理系统日志</param>
        /// </summary>
        public void Edit(TSAgentLog tsAgentLog)
        {
            try
            {
                tsAgentLogDAO.Edit(tsAgentLog);
                Message.success(context, "代理系统日志修改成功");
                loginSession.Log("XXXXXX代理系统日志修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理系统日志修改失败");
                loginSession.Log(e.Message);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="startDate">起始时间</param>
        /// <param name="endDate">结束时间</param>
        public void Delete(string userName, string startDate, string endDate)
        {
            try
            {
                tsAgentLogDAO.Delete(userName, startDate, endDate);
                Message.success(context, "日志删除成功");
                loginSession.Log("日志删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理系统日志删除失败");
                loginSession.Log(e.Message);
            }
        }
    }
}

