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
    public class AgentTakeCashHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AgentTakeCash");
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
                    string auditStauts = context.Request["auditStauts"];
                    string agentId = context.Request["agentId"];
                    string agentName = context.Request["agentName"];
                    string bankCardId = context.Request["bankCardId"];
                    bll.LoadGrid(page, rows, agentName, agentId, bankCardId, auditStauts);
                    return;
                }

                if (context.Request["action"] == "handleModeListLoad")
                {
                    AgentTakeCashBLL bll = new AgentTakeCashBLL(context, loginUser);
                    bll.HandleModeCombobox();
                }
                else if (context.Request["action"] == "load")
                {
                    AgentBLL bll = new AgentBLL(context, loginUser);
                    //加载信息
                    bll.Load(context.Request["agentId"]);
                }
                //增加
                if (context.Request["action"] == "add")
                {
                    AgentTakeCashBLL bll = new AgentTakeCashBLL(context, loginUser);
                    TTAgentTakeCash ttAgentTakeCash = new TTAgentTakeCash();
                    ttAgentTakeCash.agentId = context.Request["agentId"];//代理商编号
                    ttAgentTakeCash.fee = double.Parse(context.Request["fee"]);//发生金额
                    ttAgentTakeCash.operatorId = loginUser.UserId; ;//操作人编号
                    ttAgentTakeCash.operatorName = loginUser.UserName;//操作人名称
                    ttAgentTakeCash.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//创建时间
                    ttAgentTakeCash.handleMode = context.Request["handleMode"];//充值方式
                    ttAgentTakeCash.bankAccountId = context.Request["bankCardId"];//银行账号
                    ttAgentTakeCash.bankFlowId = context.Request["bankFlowId"];//银行流水号
                    ttAgentTakeCash.description = context.Request["description"];//说明
                    //bll.Add(ttAgentTakeCash);暂去
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
