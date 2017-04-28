using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Terminal;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.Terminal.Handler
{
    /// <summary>
    /// 终端
    /// Author:代码生成器
    /// </summary>
    public class TerminalGrantHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "TerminalGrant");
                TerminalBLL bll = new TerminalBLL(context, loginUser);
                SiteBLL siteBll = new SiteBLL(context, loginUser);
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string siteId = context.Request["siteId"];
                    string siteName = context.Request["siteName"];
                    siteBll.LoadGrid(page, rows, siteId, siteName, ((int)AuditStauts.AuditSucces).ToString());
                    return;
                }
                if (context.Request["action"] == "load")
                {
                    //加载信息
                    siteBll.Load(context.Request["siteId"]);
                }
                //发放
                if (context.Request["action"] == "add")
                {
                    string siteId = context.Request["siteId"];//执法文书名称编号
                    string startTerminalId = context.Request["startTerminalId"];//起始终端号
                    string endTerminalId = context.Request["endTerminalId"];//结束终端号
                    int terminalNum = int.Parse(context.Request["terminalNum"]);//终端数量
                    bll.Grant(siteId, startTerminalId, endTerminalId, terminalNum);
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

