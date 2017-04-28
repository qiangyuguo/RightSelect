using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL.Client;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.BLL;

namespace Com.ZY.JXKK.Client.Handler
{
    /// <summary>
    /// 客户积分明细
    /// Author:代码生成器
    /// </summary>
    public class ClientPointHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "ClientPoint");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    ClientPointBLL bll = new ClientPointBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string agentId = context.Request["agentId"];
                    string siteId = context.Request["siteId"];
                    string clientQuery = context.Request["clientQuery"];
                    string clientQueryText = context.Request["clientQueryText"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    string sroState = context.Request["sroState"];
                  bll.LoadGridCopy(page, rows, agentId, siteId, clientQuery, clientQueryText, startDate, endDate,sroState);
                    return;
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
                if (context.Request["action"] == "sroStateLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.ScoreStaCombobox();
                }
                if (context.Request["action"] == "siteListLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    string agentId = context.Request["agentId"];
                    com.SiteByAgentCombobox(agentId);
                }
                //加载信息
                if (context.Request["action"] == "load")
                {
                    ClientPointBLL bll = new ClientPointBLL(context, loginUser);
                    long flowId = long.Parse(context.Request["flowId"]);//编号
                    bll.Load(flowId);
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