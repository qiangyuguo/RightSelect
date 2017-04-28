using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.BLL;

namespace Com.ZY.JXKK.Agent.Handler
{
    /// <summary>
    /// 代理系统日志
    /// Author:代码生成器
    /// </summary>
    public class AgentLogHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AgentLog");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }
                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    AgentLogBLL bll = new AgentLogBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string userName = context.Request["userName"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.LoadGrid(page, rows, userName, startDate, endDate);
                    return;
                }

                //删除
                if (context.Request["action"] == "delete")
                {
                    AgentLogBLL bll = new AgentLogBLL(context, loginUser);
                    string userName = context.Request["userName"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.Delete(userName, startDate, endDate);
                    return;
                }

            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}