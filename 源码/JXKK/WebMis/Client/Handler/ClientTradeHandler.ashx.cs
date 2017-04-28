using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Client;

namespace Com.ZY.JXKK.Client.Handler
{
    /// <summary>
    /// ClientTradeHandler 的摘要说明
    /// </summary>
    public class ClientTradeHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "ClientTrade");
                ClientTradeBLL bll = new ClientTradeBLL(context, loginUser);
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
                    string siteId = context.Request["siteId"];
                    string clientQuery = context.Request["clientQuery"];
                    string clientQueryText = context.Request["clientQueryText"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.LoadGrid(page, rows, agentId, siteId, clientQuery, clientQueryText, startDate, endDate);
                    return;
                }
                //用户查找分类
                if (context.Request["action"] == "clientQueryListLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.ClientQueryCombobox();
                }
                //加载信息
                if (context.Request["action"] == "load")
                {
                    string flowId = context.Request["flowId"];//编号
                    bll.Load(flowId);
                    return;
                }
                if (context.Request["action"] == "agentListLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.AgentCombobox();
                }
                if (context.Request["action"] == "siteListLoad")
                {
                    string agentId = context.Request["agentId"];
                    Combobox com = new Combobox(context, loginUser);
                    com.SiteByAgentCombobox(agentId);
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