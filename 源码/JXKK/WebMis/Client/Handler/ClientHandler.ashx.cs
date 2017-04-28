using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Client;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.Client.Handler
{
    /// <summary>
    /// 客户信息
    /// Author:代码生成器
    /// </summary>
    public class ClientHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "Client");
                ClientBLL bll = new ClientBLL(context, loginUser);
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }
                if (context.Request["action"] == "agentListLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.AgentCombobox();
                }
                //用户查找分类
                if (context.Request["action"] == "clientQueryListLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.ClientQueryCombobox();
                }
                if (context.Request["action"] == "siteListLoad")
                {
                    string agentId = context.Request["agentId"];
                    Combobox com = new Combobox(context, loginUser);
                    com.SiteByAgentCombobox(agentId);
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
                    string status = context.Request["status"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.LoadGrid(page, rows, agentId, siteId, clientQuery, clientQueryText,status, startDate, endDate);
                    return;
                }
                //获取账户余额积分总计
                if (context.Request["action"] == "totalBalanceAndPoints")
                {
                    string agentId = context.Request["agentId"];
                    string siteId = context.Request["siteId"];
                    string clientQuery = context.Request["clientQuery"];
                    string clientQueryText = context.Request["clientQueryText"];
                    string status = context.Request["status"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    var totalBalance = bll.GetTotalBalanceOrPoints(1, agentId, siteId, clientQuery, clientQueryText, status, startDate, endDate);
                    var totalPoints = bll.GetTotalBalanceOrPoints(2, agentId, siteId, clientQuery, clientQueryText, status, startDate, endDate);
                    context.Response.Write("{\"totalBalance\":" + totalBalance + ",\"totalPoints\":" + totalPoints + "}");
                }
                //加载信息
                if (context.Request["action"] == "load")
                {
                    long clientId =long.Parse(context.Request["clientId"]);//客户编号
                    bll.Load(clientId);
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