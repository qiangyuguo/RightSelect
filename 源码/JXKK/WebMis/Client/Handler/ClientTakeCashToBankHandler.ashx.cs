using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Com.ZY.JXKK.Client.Handler
{
    /// <summary>
    /// ClientTakeCashToBankHandler 的摘要说明
    /// </summary>
    public class ClientTakeCashToBankHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            LoginUser loginUser = new LoginUser(context, "ClientTakeCashToBank");
            if (!loginUser.Pass)//权限验证
            {
                return;
            }
            //加载DataGrid
            if (context.Request["action"] == "gridLoad")
            {
                ClientTakeCashToBankBLL bll = new ClientTakeCashToBankBLL(context, loginUser);
                int page = int.Parse(context.Request["page"]);
                int rows = int.Parse(context.Request["rows"]);
                string agentId = context.Request["agentId"];
                string siteId = context.Request["siteId"];
                string clientQuery = context.Request["clientQuery"];
                string clientQueryText = context.Request["clientQueryText"];
                string startDate = context.Request["startDate"];
                string endDate = context.Request["endDate"];
                bll.LoadGrid(page, rows, agentId, siteId, clientQuery, clientQueryText, startDate, endDate);
            }
            //用户查找分类
            if (context.Request["action"] == "clientQueryListLoad")
            {
                Combobox com = new Combobox(context, loginUser);
                com.ClientQueryCombobox();
            }
            if (context.Request["action"] == "agentListLoad")
            {
                Combobox com = new Combobox(context, loginUser);
                com.AgentCombobox();
            }
            if (context.Request["action"] == "siteListLoad")
            {
                Combobox com = new Combobox(context, loginUser);
                string agentId = context.Request["agentId"];
                com.SiteByAgentCombobox(agentId);
            }
            if (context.Request["action"]=="TakeCash")
            {
                ClientTakeCashToBankBLL bll = new ClientTakeCashToBankBLL(context, loginUser);
                string flowid = context.Request["flowid"];
                bll.TakeCash(flowid, loginUser.UserName);
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