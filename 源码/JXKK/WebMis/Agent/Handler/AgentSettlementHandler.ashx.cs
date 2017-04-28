using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.Util;

namespace Com.ZY.JXKK.Agent.Handler
{
    /// <summary>
    /// 代理佣金结算
    /// Author:代码生成器
    /// </summary>
    public class AgentSettlementHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AgentSettlement");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    AgentSettlementBLL bll = new AgentSettlementBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.CommissionLoadGrid(page, rows, startDate, endDate);
                    return;
                }
                //结算
                if (context.Request["action"] == "settlement")
                {
                    AgentSettlementBLL bll = new AgentSettlementBLL(context, loginUser);
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    List<TTAgentSettlement> agentSettlementList = bll.GetAgentSettlmentList(startDate,endDate);
                    bll.AddList(agentSettlementList,startDate,endDate,loginUser.UserId,loginUser.UserName);
                }
                //加载信息
                if (context.Request["action"] == "load")
                {
                    AgentSettlementBLL bll = new AgentSettlementBLL(context, loginUser);
                    long flowId = long.Parse(context.Request["flowId"]);//结算流水号
                    bll.Load(flowId);
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