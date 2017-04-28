using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Terminal;
using Com.ZY.JXKK.Util;

namespace Com.ZY.JXKK.Terminal.Handler
{
    /// <summary>
    /// TerminalOnlineHttp 的摘要说明
    /// </summary>
    public class TerminalOnlineHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "TerminalOnline");
                TerminalBLL bll = new TerminalBLL(context, loginUser);
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    int offlineMinutes = int.Parse(System.Configuration.ConfigurationManager.AppSettings["OfflineMinutes"]);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string agentId = context.Request["agentId"];
                    string siteId = context.Request["siteId"];
                    string terminalId = context.Request["terminalId"];
                    string onlineStatus = context.Request["onlineStatus"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.LoadGridOnLine(page, rows,agentId, siteId, terminalId, onlineStatus,offlineMinutes, startDate, endDate);
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