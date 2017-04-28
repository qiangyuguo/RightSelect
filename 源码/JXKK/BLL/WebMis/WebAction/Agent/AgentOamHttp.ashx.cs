using System;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.Model.Agent;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.WebAction.Agent
{
    /// <summary>
    /// 代理商
    /// </summary>
    public class AgentOamHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AgentOam");
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
                    bll.LoadGrid(page, rows, agentName, agentId, "", ((int)AuditStauts.AuditSucces).ToString());
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
                    agent.auditStatus = ((int)AuditStauts.AuditSucces).ToString();
                    agent.fixedLine = context.Request["fixedLine"];
                    agent.remark = context.Request["remark"];
                    bll.Edit(agent);
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