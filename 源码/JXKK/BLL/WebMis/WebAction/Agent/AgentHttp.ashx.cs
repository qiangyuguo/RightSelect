using System;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.Model.Agent;

namespace Com.ZY.JXKK.WebAction.Agent
{
    /// <summary>
    /// 代理商
    /// </summary>
    public class AgentHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AgentAdd");
                if (!loginUser.Pass)//权限验证
                    return;

                AgentBLL bll = new AgentBLL(context, loginUser);
                if (context.Request["action"] == "gridLoad")
                {
                    //加载DataGrid
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string agentName = context.Request["agentName"];
                    string agentId = context.Request["agentId"];
                    string auditStatus = context.Request["auditStatus"];
                    bll.LoadGrid(page, rows, agentName, agentId, "", auditStatus);
                }
                else if (context.Request["action"] == "areaListLoad")
                {
                    //加载区域列表
                    bll.AreaCombobox();
                }
                else if (context.Request["action"] == "auditListLoad")
                {
                    //加载审核状态列表
                    bll.AuditCombobox();
                }
                else if (context.Request["action"] == "load")
                {
                    //加载信息
                    bll.Load(context.Request["agentId"]);
                }
                else if (context.Request["action"] == "add")
                {
                    //增加
                    TBAgent agent = new TBAgent();
                    TSAgentUser tsAgentUser = new TSAgentUser();
                    agent.agentId = context.Request["agentId"];
                    agent.agentName = context.Request["agentName"];
                    agent.rebate = double.Parse(context.Request["rebate"]);
                    agent.warnValue = double.Parse(context.Request["warnValue"]);
                    agent.contact = context.Request["contact"];
                    agent.telephone = context.Request["telephone"];
                    agent.areaId = context.Request["areaId"];
                    agent.address = context.Request["address"];
                    agent.IDNumber = context.Request["IDNumber"];
                    agent.bankCardId = context.Request["bankCardId"];
                    agent.bankName = context.Request["bankName"];
                    agent.status = "0";
                    agent.fixedLine = context.Request["fixedLine"];
                    agent.remark = context.Request["remark"];
                    tsAgentUser.roleId = "001";
                    tsAgentUser.userCode = context.Request["agentUserCode"];
                    tsAgentUser.userPwd = tsAgentUser.userCode;
                    bll.Add(agent, tsAgentUser);
                }
                else if (context.Request["action"] == "edit")
                {
                    //修改
                    TBAgent agent = new TBAgent();
                    agent.agentId = context.Request["agentId"];
                    agent.agentName = context.Request["agentName"];
                    agent.rebate = double.Parse(context.Request["rebate"]);
                    agent.contact = context.Request["contact"];
                    agent.telephone = context.Request["telephone"];
                    agent.areaId = context.Request["areaId"];
                    agent.address = context.Request["address"];
                    agent.IDNumber = context.Request["IDNumber"];
                    agent.bankCardId = context.Request["bankCardId"];
                    agent.bankName = context.Request["bankName"];
                    agent.status = context.Request["status"];
                    agent.warnValue = double.Parse(context.Request["warnValue"]);
                    agent.auditStatus = context.Request["auditStatus"];
                    agent.fixedLine = context.Request["fixedLine"];
                    agent.remark = context.Request["remark"];
                    bll.Edit(agent);
                }
                else if (context.Request["action"] == "delete")
                {
                    //删除
                    string agentId = context.Request["agentId"];
                    bll.Delete(agentId);
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