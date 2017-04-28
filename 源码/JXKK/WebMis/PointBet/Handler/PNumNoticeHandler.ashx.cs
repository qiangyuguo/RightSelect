using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Set;
using Com.ZY.JXKK.BLL.PointBet;

namespace Com.ZY.JXKK.PointBet.Handler
{
    /// <summary>
    /// 开奖公告
    /// Author:代码生成器
    /// </summary>
    public class PNumNoticeHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "PNumNotice");
                PNumNoticeBLL bll = new PNumNoticeBLL(context, loginUser);
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string period = context.Request["period"];
                    string gameId = context.Request["gameId"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.LoadGrid(page, rows, period, gameId, startDate, endDate);
                    return;
                }
                //游戏下拉框信息
                if (context.Request["action"] == "ddlGameLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.PointGameCombobox("2,3");
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

