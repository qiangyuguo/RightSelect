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
    /// 客户账户明细
    /// Author:代码生成器
    /// </summary>
    public class ClientAccDetailHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "ClientAccDetail");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    ClientAccDetailBLL bll = new ClientAccDetailBLL(context, loginUser);
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

                //加载信息
                if (context.Request["action"] == "load")
                {
                    ClientAccDetailBLL bll = new ClientAccDetailBLL(context, loginUser);
                    long flowId = long.Parse(context.Request["flowId"]);//编号
                    bll.Load(flowId);
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

