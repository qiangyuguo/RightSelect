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
    /// 代理商提现申请
    /// Author:代码生成器
    /// </summary>
    public class AgentTakeCashApplyHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AgentTakeCashApply");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }
                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    AgentTakeCashApplyBLL bll = new AgentTakeCashApplyBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.LoadGrid(page, rows, "", startDate, endDate);
                    return;
                }
                //办理状态
                if (context.Request["action"] == "dealWSListLoad")
                {
                    AgentTakeCashApplyBLL bll = new AgentTakeCashApplyBLL(context, loginUser);
                    bll.DealWSCombobox();
                }
                //加载信息
                if (context.Request["action"] == "load")
                {
                    AgentTakeCashApplyBLL bll = new AgentTakeCashApplyBLL(context, loginUser);
                    long flowId = long.Parse(context.Request["flowId"]);//流水号
                    bll.Load(flowId);
                    return;
                }

                //修改
                if (context.Request["action"] == "edit")
                {
                    AgentTakeCashApplyBLL bll = new AgentTakeCashApplyBLL(context, loginUser);
                    TTAgentTakeCashApply ttAgentTakeCashApply = new TTAgentTakeCashApply();
                    ttAgentTakeCashApply.flowId = long.Parse(context.Request["flowId"]);//流水号
                    ttAgentTakeCashApply.dealWithStatus = context.Request["dealWithStatus"];//办理状态
                    ttAgentTakeCashApply.transferAccDate = context.Request["transferAccDate"];//转账日期
                    ttAgentTakeCashApply.operatorId = loginUser.UserId;//办理人编号
                    ttAgentTakeCashApply.operatorName = loginUser.UserName;//办理人名称
                    ttAgentTakeCashApply.dealWithTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//办理时间
                    ttAgentTakeCashApply.opinion = context.Request["opinion"];//办理意见

                    TTAgentTakeCash ttAgentTakeCash = new TTAgentTakeCash();
                    ttAgentTakeCash.agentId = context.Request["agentId"];//代理商编号
                    ttAgentTakeCash.fee = double.Parse(context.Request["fee"]);//发生金额
                    ttAgentTakeCash.operatorId = loginUser.UserId; ;//操作人编号
                    ttAgentTakeCash.operatorName = loginUser.UserName;//操作人名称
                    ttAgentTakeCash.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//创建时间
                    ttAgentTakeCash.handleMode = "0";
                    ttAgentTakeCash.bankAccountId = context.Request["bankAccountId"];//银行账号
                    ttAgentTakeCash.bankFlowId = "";
                    ttAgentTakeCash.description = context.Request["remark"];//说明

                    bll.Edit(ttAgentTakeCashApply, ttAgentTakeCash);
                    return;
                }

                //删除
                if (context.Request["action"] == "delete")
                {
                    AgentTakeCashApplyBLL bll = new AgentTakeCashApplyBLL(context, loginUser);
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