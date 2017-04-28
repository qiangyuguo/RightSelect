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
    /// AgentPreRechgHttp 的摘要说明
    /// </summary>
    public class AgentPreRechgHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AgentPreRechg");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    AgentBLL bll = new AgentBLL(context, loginUser);
                    //加载DataGrid
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string agentId = context.Request["agentId"];
                    string agentName = context.Request["agentName"];
                    string bankCardId = context.Request["bankCardId"];
                    bll.LoadGrid(page, rows, agentName, agentId, bankCardId, ((int)AuditStauts.AuditSucces).ToString());
                    return;
                }
                if (context.Request["action"] == "handleModeListLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.HandleModeCombobox();
                }
                //加载信息
                if (context.Request["action"] == "load")
                {
                    AgentBLL bll = new AgentBLL(context, loginUser);
                    //加载信息
                    bll.Load(context.Request["agentId"]);
                }

                //增加
                if (context.Request["action"] == "add")
                {
                    AgentPreRechgBLL bll = new AgentPreRechgBLL(context, loginUser);
                    TTAgentPreRechg ttAgentPreRechg = new TTAgentPreRechg();
                    ttAgentPreRechg.agentId = context.Request["agentId"];//代理商编号
                    ttAgentPreRechg.agentName = context.Request["agentName"];//代理商名称
                    ttAgentPreRechg.fee = double.Parse(context.Request["fee"]);//发生金额
                    ttAgentPreRechg.handleMode = context.Request["handleMode"];//充值方式
                    ttAgentPreRechg.operatorId = loginUser.UserId; ;//操作人编号
                    ttAgentPreRechg.operatorName = loginUser.UserName;//操作人名称
                    ttAgentPreRechg.bankAccountId = context.Request["bankCardId"];//银行账号
                    ttAgentPreRechg.bankFlowId = context.Request["bankFlowId"];//银行流水号
                    ttAgentPreRechg.description = context.Request["description"];//说明
                    bll.Add(ttAgentPreRechg);
                    return;
                }

                //修改
                if (context.Request["action"] == "edit")
                {
                    AgentPreRechgBLL bll = new AgentPreRechgBLL(context, loginUser);
                    TTAgentPreRechg ttAgentPreRechg = new TTAgentPreRechg();
                    ttAgentPreRechg.flowId = long.Parse(context.Request["flowId"]);//流水号
                    ttAgentPreRechg.agentId = context.Request["agentId"];//代理商编号
                    ttAgentPreRechg.agentName = context.Request["agentName"];//代理商名称
                    ttAgentPreRechg.fee = double.Parse(context.Request["fee"]);//发生金额
                    ttAgentPreRechg.operatorId = context.Request["operatorId"];//操作人编号
                    ttAgentPreRechg.operatorName = context.Request["operatorName"];//操作人名称
                    ttAgentPreRechg.createTime = context.Request["createTime"];//创建时间
                    ttAgentPreRechg.handleMode = context.Request["handleMode"];//充值方式
                    ttAgentPreRechg.bankAccountId = context.Request["bankAccountId"];//银行账号
                    ttAgentPreRechg.bankFlowId = context.Request["bankFlowId"];//银行流水号
                    ttAgentPreRechg.description = context.Request["description"];//说明
                    ttAgentPreRechg.auditStatus = context.Request["auditStatus"];//审核状态
                    bll.Edit(ttAgentPreRechg);
                    return;
                }

                //删除
                if (context.Request["action"] == "delete")
                {
                    AgentPreRechgBLL bll = new AgentPreRechgBLL(context, loginUser);
                    long flowId = long.Parse(context.Request["flowId"]);//流水号
                    bll.Delete(flowId);
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