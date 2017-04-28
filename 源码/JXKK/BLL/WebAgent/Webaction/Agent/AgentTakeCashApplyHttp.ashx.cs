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
                LoginAgentUser loginAgentUser = new LoginAgentUser(context, "AgentTakeCashApply");
                AgentRoleBLL agentRoleBLL = new AgentRoleBLL(context, loginAgentUser);
                StaffBLL staffBll = new StaffBLL(context, loginAgentUser);
                if (!loginAgentUser.Pass)//权限验证
                {
                    return;
                }
                //获取用户登录的角色类型 0为 代理商 1 为员工
                string roleType = agentRoleBLL.GetRoleType(loginAgentUser.RoleIds);
                string agentId = "";
                if (roleType == "0")
                {
                    agentId = loginAgentUser.UserId;
                }
                else
                {
                    agentId = staffBll.Get(loginAgentUser.UserId).agentId;
                }
                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    AgentTakeCashApplyBLL bll = new AgentTakeCashApplyBLL(context, loginAgentUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.LoadGrid(page, rows, agentId, startDate, endDate);
                    return;
                }

                //加载信息
                if (context.Request["action"] == "load")
                {
                    AgentTakeCashApplyBLL bll = new AgentTakeCashApplyBLL(context, loginAgentUser);
                    long flowId = long.Parse(context.Request["flowId"]);//流水号
                    bll.Load(flowId);
                    return;
                }

                //增加
                if (context.Request["action"] == "add")
                {
                    AgentTakeCashApplyBLL bll = new AgentTakeCashApplyBLL(context, loginAgentUser);
                    TTAgentTakeCashApply ttAgentTakeCashApply = new TTAgentTakeCashApply();
                    ttAgentTakeCashApply.agentId = loginAgentUser.UserId;//代理商编号
                    ttAgentTakeCashApply.agentName = loginAgentUser.GetUserName();//代理商名称
                    ttAgentTakeCashApply.fee = double.Parse(context.Request["fee"]);//提现金额
                    ttAgentTakeCashApply.bankAccountId = context.Request["bankAccountId"];//银行账号
                    ttAgentTakeCashApply.remark = context.Request["remark"];//提现说明
                    ttAgentTakeCashApply.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    ttAgentTakeCashApply.dealWithStatus = "0";
                    bll.Add(ttAgentTakeCashApply);
                    return;
                }
                //删除
                if (context.Request["action"] == "delete")
                {
                    AgentTakeCashApplyBLL bll = new AgentTakeCashApplyBLL(context, loginAgentUser);
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

