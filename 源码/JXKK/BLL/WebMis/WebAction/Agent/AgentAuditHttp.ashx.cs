using System;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.Model.Agent;

namespace Com.ZY.JXKK.WebAction.Agent
{
    /// <summary>
    /// 代理商
    /// </summary>
    public class AgentAuditHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AgentAudit");
                if (!loginUser.Pass)//权限验证
                    return;

                AgentBLL bll = new AgentBLL(context, loginUser);
                if (context.Request["action"] == "gridLoad")
                {
                    //加载DataGrid
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string agentId = context.Request["agentId"];
                    string agentName = context.Request["agentName"];
                    bll.LoadGrid(page, rows, agentName, agentId, "", ((int)AuditStauts.NotAudit).ToString());
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
                else if (context.Request["action"] == "audit")
                {
                    //审核
                    TBAgent agent = new TBAgent();
                    agent.agentId = context.Request["agentId"];
                    agent.auditStatus = context.Request["auditStatus"];
                    agent.status = "0";
                    if (agent.auditStatus == ((int)AuditStauts.AuditSucces).ToString())
                        agent.status = "1";
                    agent.remark = context.Request["remark"];
                    bll.Audit(agent);
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