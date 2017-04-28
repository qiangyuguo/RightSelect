﻿using System;
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
    /// 客户积分明细
    /// Author:代码生成器
    /// </summary>
    public class ClientPointHttp : IHttpHandler, IRequiresSessionState
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
                    string clientId = context.Request["clientId"];
                    string agentId = context.Request["agentId"];
                    string siteId = context.Request["siteId"];
                    string cardId = context.Request["cardId"];
                    string clientName = context.Request["clientName"];
                    bll.LoadGrid(page, rows, clientId, agentId, siteId, cardId, clientName);
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