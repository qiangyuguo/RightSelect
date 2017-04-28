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
    /// 代理商充值
    /// Author:代码生成器
    /// </summary>
    public class AgentRechargeHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AgentRecharge");
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
                if (context.Request["action"] == "load")
                {
                    AgentBLL bll = new AgentBLL(context, loginUser);
                    //加载信息
                    bll.Load(context.Request["agentId"]);
                }
                if (context.Request["action"] == "handleModeListLoad")
                {
                    AgentRechargeBLL bll = new AgentRechargeBLL(context, loginUser);
                    bll.HandleModeCombobox();
                }

                //增加
                if (context.Request["action"] == "add")
                {
                    AgentRechargeBLL bll = new AgentRechargeBLL(context, loginUser);
                    TTAgentRecharge ttAgentRecharge = new TTAgentRecharge();
                    ttAgentRecharge.agentId = context.Request["agentId"];//代理商编号
                    ttAgentRecharge.fee = double.Parse(context.Request["fee"]);//发生金额
                    ttAgentRecharge.operatorId = loginUser.UserId; ;//操作人编号
                    ttAgentRecharge.operatorName = loginUser.UserName;//操作人名称
                    ttAgentRecharge.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//创建时间
                    ttAgentRecharge.handleMode = context.Request["handleMode"];//充值方式
                    ttAgentRecharge.bankAccountId = context.Request["bankCardId"];//银行账号
                    ttAgentRecharge.bankFlowId = context.Request["bankFlowId"];//银行流水号
                    ttAgentRecharge.description = context.Request["description"];//说明
                    bll.Add(ttAgentRecharge);
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