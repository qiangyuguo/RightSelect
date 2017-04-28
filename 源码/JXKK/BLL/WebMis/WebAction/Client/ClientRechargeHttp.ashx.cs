using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL.Client;
using Com.ZY.JXKK.Model.Client;
using Com.ZY.JXKK.BLL;

namespace Com.ZY.JXKK.WebAction.Client
{
    /// <summary>
    /// 客户充值
    /// Author:代码生成器
    /// </summary>
    public class ClientRechargeHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "ClientRecharge");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    ClientRechargeBLL bll = new ClientRechargeBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string clientId = context.Request["clientId"];
                    string agentId = context.Request["agentId"];
                    string siteId = context.Request["siteId"];
                    string cardId = context.Request["cardId"];
                    string clientName = context.Request["clientName"];
                    bll.LoadGrid(page, rows, clientId, agentId, siteId, cardId, clientName);
                    return;
                }
                if (context.Request["action"] == "totalFee")
                {
                    ClientRechargeBLL bll = new ClientRechargeBLL(context, loginUser);
                    string clientId = context.Request["clientId"];
                    string agentId = context.Request["agentId"];
                    string siteId = context.Request["siteId"];
                    string cardId = context.Request["cardId"];
                    string clientName = context.Request["clientName"];
                    context.Response.Write(bll.GetTotalFee(clientId, agentId, siteId, cardId, clientName));
                    return;
                }
                //加载信息
                if (context.Request["action"] == "load")
                {
                    ClientRechargeBLL bll = new ClientRechargeBLL(context, loginUser);
                    long flowId = long.Parse(context.Request["flowId"]);//编号
                    bll.Load(flowId);
                    return;
                }
                if (context.Request["action"] == "agentListLoad")
                {
                    ClientBLL bll = new ClientBLL(context, loginUser);
                    bll.AgentCombobox();
                }
                if (context.Request["action"] == "siteListLoad")
                {
                    ClientBLL bll = new ClientBLL(context, loginUser);
                    string agentId = context.Request["agentId"];
                    bll.SiteCombobox(agentId);
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