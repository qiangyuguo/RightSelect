using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.Model.Agent;

namespace Com.ZY.JXKK.WebAction.Agent
{
    /// <summary>
    /// 代理商充值明细
    /// Author:代码生成器
    /// </summary>
    public class AgentRechargeDetailHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AgentRechargeDetail");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }
                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    AgentRechargeBLL bll = new AgentRechargeBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string agentId = context.Request["agentId"];
                    string agentName = context.Request["agentName"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.LoadGrid(page, rows, agentId, agentName, startDate, endDate);
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

