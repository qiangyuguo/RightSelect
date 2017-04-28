using System;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Manage;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.Manage.Handler
{
    /// <summary>
    /// 日志
    /// </summary>
    public class LogHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "Log");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    LogBLL bll = new LogBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string userName = context.Request["userName"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.LoadGrid(page, rows, userName, startDate, endDate);
                    return;
                }

                //删除
                if (context.Request["action"] == "delete")
                {
                    LogBLL bll = new LogBLL(context, loginUser);
                    string userName = context.Request["userName"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.Delete(userName, startDate, endDate);
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