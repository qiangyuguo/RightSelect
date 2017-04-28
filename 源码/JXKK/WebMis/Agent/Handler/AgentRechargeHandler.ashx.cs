using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.Agent.Handler
{
    /// <summary>
    /// 代理商充值
    /// Author:代码生成器
    /// </summary>
    public class AgentRechargeHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AgentRecharge");
                AgentPreRechgBLL bll = new AgentPreRechgBLL(context, loginUser);
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string agentId = context.Request["agentId"];
                    string auditStatus= context.Request["auditStatus"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.LoadGrid(page, rows, agentId, auditStatus, startDate, endDate);
                    return;
                }
                if (context.Request["action"] == "load")
                {
                    //加载信息
                    bll.Load(long.Parse(context.Request["flowId"]));
                }
                if (context.Request["action"] == "handleModeListLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.HandleModeCombobox();
                }

                //审核
                if (context.Request["action"] == "audit")
                {
                    AgentRechargeBLL agentRechargeBLL = new AgentRechargeBLL(context, loginUser);
                    long flowId = long.Parse(context.Request["flowId"]);
                    string remark = context.Request["remark"];
                    TTAgentPreRechg ttAgentPreRechg = bll.Get(flowId);//预审
                    ttAgentPreRechg.auditStatus = context.Request["auditStatus"];
                    if (ttAgentPreRechg.auditStatus == "1")
                    {
                        TTAgentRecharge ttAgentRecharge = new TTAgentRecharge();//充值明细
                        ttAgentRecharge.agentId = ttAgentPreRechg.agentId;//代理商编号
                        ttAgentRecharge.fee = ttAgentPreRechg.fee;//发生金额
                        ttAgentRecharge.operatorId = loginUser.UserId;//操作人编号
                        ttAgentRecharge.operatorName = loginUser.UserName;//操作人名称
                        ttAgentRecharge.handleMode = ttAgentPreRechg.handleMode;//充值方式
                        ttAgentRecharge.bankAccountId = ttAgentPreRechg.bankAccountId;//银行账号
                        ttAgentRecharge.bankFlowId = ttAgentPreRechg.bankFlowId;//银行流水号
                        if (remark.Trim() == "")
                            ttAgentRecharge.description = ttAgentPreRechg.description;//说明
                        else
                            ttAgentRecharge.description = remark;
                        agentRechargeBLL.Add(ttAgentRecharge, ttAgentPreRechg, ttAgentPreRechg.fee);
                    }
                    else
                    {
                        bll.Edit(ttAgentPreRechg);
                    }
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