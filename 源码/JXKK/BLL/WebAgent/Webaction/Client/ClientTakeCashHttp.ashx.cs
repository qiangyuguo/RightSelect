using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL.Client;
using Com.ZY.JXKK.Model.Client;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Agent;
namespace Com.ZY.JXKK.WebAction.Client
{
    /// <summary>
    /// 客户提现
    /// Author:代码生成器
    /// </summary>
    public class ClientTakeCashHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginAgentUser loginAgentUser = new LoginAgentUser(context, "ClientTakeCash");
                AgentRoleBLL agentRoleBLL = new AgentRoleBLL(context, loginAgentUser);
                StaffBLL staffBll = new StaffBLL(context, loginAgentUser);
                if (!loginAgentUser.Pass)//权限验证
                {
                    return;
                }
                //获取用户登录的角色类型 0为 代理商 1 为员工
                string roleType = agentRoleBLL.GetRoleType(loginAgentUser.RoleIds);
                string agentId = "";
                string siteId = context.Request["siteId"];
                if (roleType == "0")
                    agentId = loginAgentUser.UserId;
                if (roleType != "0")
                    siteId = staffBll.Get(loginAgentUser.UserId).siteId;

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    ClientTakeCashBLL bll = new ClientTakeCashBLL(context, loginAgentUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string clientId = context.Request["clientId"];
                    string cardId = context.Request["cardId"];
                    string clientName = context.Request["clientName"];
                    bll.LoadGrid(page, rows, clientId, agentId, siteId, cardId, clientName);
                    return;
                }
                if (context.Request["action"] == "siteListLoad")
                {
                    ClientBLL bll = new ClientBLL(context, loginAgentUser);
                    bll.SiteCombobox(loginAgentUser.UserId, roleType);
                }
                //加载信息
                if (context.Request["action"] == "load")
                {
                    ClientTakeCashBLL bll = new ClientTakeCashBLL(context, loginAgentUser);
                    long flowId = long.Parse(context.Request["flowId"]);//编号
                    bll.Load(flowId);
                    return;
                }
                if (context.Request["action"] == "totalFee")
                {
                    ClientTakeCashBLL bll = new ClientTakeCashBLL(context, loginAgentUser);
                    string clientId = context.Request["clientId"];
                    string cardId = context.Request["cardId"];
                    string clientName = context.Request["clientName"];
                    context.Response.Write(bll.GetTotalFee(clientId, agentId, siteId, cardId, clientName));
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

