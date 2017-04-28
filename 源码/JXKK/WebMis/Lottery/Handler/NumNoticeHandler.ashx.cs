using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL.Lottery;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Set;

namespace Com.ZY.JXKK.Lottery.Handler
{
    /// <summary>
    /// 开奖公告
    /// Author:代码生成器
    /// </summary>
    public class NumNoticeHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "NumNotice");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    NumNoticeBLL bll = new NumNoticeBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string period = context.Request["period"];
                    string lotteryType = context.Request["lotteryType"];
                    //string gameId = context.Request["gameId"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.LoadGrid(page, rows, period, lotteryType,"", startDate, endDate,true);
                    return;
                }
                //彩种下拉框信息
                if (context.Request["action"] == "ddlLotteryTypeLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.LotteryTypeCombobox();
                    return;
                }

                //游戏下拉框信息
                if (context.Request["action"] == "ddlGameLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.LotteryTypeCombobox();
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

