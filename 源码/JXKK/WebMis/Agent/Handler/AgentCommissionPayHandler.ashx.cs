using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.Util;
using System.Web.SessionState;

namespace Com.ZY.JXKK.Agent.Handler
{
    /// <summary>
    /// AgentCommissionPayHttp 的摘要说明
    /// </summary>
    public class AgentCommissionPayHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AgentCommissionPay");
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
                    string agentId = context.Request["agentId"];
                    string agentName = context.Request["agentName"];
                    string payStatus = context.Request["payStatus"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.LoadGrid(page, rows, agentId, agentName, payStatus, startDate, endDate);
                    return;
                }
                //加载信息
                if (context.Request["action"] == "load")
                {
                    AgentSettlementBLL bll = new AgentSettlementBLL(context, loginUser);
                    long flowId = long.Parse(context.Request["flowId"]);//结算流水号
                    bll.Load(flowId);
                    return;
                }
                //支付
                if (context.Request["action"] == "pay")
                {
                    AgentSettlementBLL bll = new AgentSettlementBLL(context, loginUser);
                    TTAgentSettlement ttAgentSettlement = new TTAgentSettlement();
                    ttAgentSettlement.flowId = long.Parse(context.Request["flowId"]);
                    ttAgentSettlement.payStatus = "1";
                    ttAgentSettlement.modeId = context.Request["modeId"];//支付方式
                    ttAgentSettlement.payTime = context.Request["payTime"];//支付时间
                    ttAgentSettlement.cashierId = loginUser.UserId;//支付人编号
                    ttAgentSettlement.cashierName = loginUser.UserName;//支付人名称
                    bll.Edit(ttAgentSettlement);
                    return;
                }
                //支付方式
                if (context.Request["action"] == "handleModeListLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.HandleModeCombobox();
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