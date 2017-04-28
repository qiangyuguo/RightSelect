using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Model.Agent;

namespace Com.ZY.JXKK.WebAction.Agent
{
    /// <summary>
    /// 代理商充值提醒
    /// Author:代码生成器
    /// </summary>
    public class AgentRechargeNoticeHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginAgentUser loginAgentUser = new LoginAgentUser(context, "AgentRechargeNotice");
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
                    AgentRechargeNoticeBLL bll = new AgentRechargeNoticeBLL(context, loginAgentUser);
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
                    AgentRechargeNoticeBLL bll = new AgentRechargeNoticeBLL(context, loginAgentUser);
                    long flowId = long.Parse(context.Request["flowId"]);//流水号
                    bll.Load(flowId);
                    return;
                }

                //增加
                if (context.Request["action"] == "add")
                {
                    AgentRechargeNoticeBLL bll = new AgentRechargeNoticeBLL(context, loginAgentUser);
                    TTAgentRechargeNotice ttAgentRechargeNotice = new TTAgentRechargeNotice();
                    ttAgentRechargeNotice.agentId = loginAgentUser.UserId;//代理商编号
                    ttAgentRechargeNotice.agentName = loginAgentUser.GetUserName();//代理商名称
                    ttAgentRechargeNotice.fee = double.Parse(context.Request["fee"]);//充值金额
                    ttAgentRechargeNotice.bankAccountId = context.Request["bankAccountId"];//银行账号
                    ttAgentRechargeNotice.transferAccDate = DateTime.Parse(context.Request["transferAccDate"]).ToString("yyyy-MM-dd HH:mm:ss");//转账日期
                    ttAgentRechargeNotice.remark = context.Request["remark"];//充值说明
                    ttAgentRechargeNotice.dealWithStatus = "0";
                    bll.Add(ttAgentRechargeNotice);
                    return;
                }

                //修改
                if (context.Request["action"] == "edit")
                {
                    AgentRechargeNoticeBLL bll = new AgentRechargeNoticeBLL(context, loginAgentUser);
                    TTAgentRechargeNotice ttAgentRechargeNotice = new TTAgentRechargeNotice();
                    ttAgentRechargeNotice.flowId = long.Parse(context.Request["flowId"]);//流水号
                    ttAgentRechargeNotice.agentId = context.Request["agentId"];//代理商编号
                    ttAgentRechargeNotice.agentName = context.Request["agentName"];//代理商名称
                    ttAgentRechargeNotice.fee = double.Parse(context.Request["fee"]);//充值金额
                    ttAgentRechargeNotice.bankAccountId = context.Request["bankAccountId"];//银行账号
                    ttAgentRechargeNotice.transferAccDate = context.Request["transferAccDate"];//转账日期
                    ttAgentRechargeNotice.remark = context.Request["remark"];//充值说明
                    ttAgentRechargeNotice.createTime = context.Request["createTime"];//创建时间
                    ttAgentRechargeNotice.dealWithStatus = context.Request["dealWithStatus"];//办理状态
                    ttAgentRechargeNotice.operatorId = context.Request["operatorId"];//办理人编号
                    ttAgentRechargeNotice.operatorName = context.Request["operatorName"];//办理人名称
                    ttAgentRechargeNotice.dealWithTime = context.Request["dealWithTime"];//办理时间
                    ttAgentRechargeNotice.opinion = context.Request["opinion"];//办理意见
                    bll.Edit(ttAgentRechargeNotice);
                    return;
                }

                //删除
                if (context.Request["action"] == "delete")
                {
                    AgentRechargeNoticeBLL bll = new AgentRechargeNoticeBLL(context, loginAgentUser);
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

