using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Lottery;
using Com.ZY.JXKK.BLL.Set;
using Com.ZY.JXKK.Util;
using System.Web.SessionState;
using Com.ZY.JXKK.BLL.Client;

namespace Com.ZY.JXKK.Lottery.Handler
{
    /// <summary>
    /// 中奖彩票订单 的摘要说明
    /// </summary>
    public class WinningLotteryOrderHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "WinningLotteryOrder");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    LotteryOrderBLL bll = new LotteryOrderBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string period = context.Request["period"]; //期次
                    string awardResult = context.Request["awardResult"];//中奖状态
                    string clientQuery = context.Request["clientQuery"];
                    string clientQueryText = context.Request["clientQueryText"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.WLoadGrid(page, rows, "", "", period, awardResult, clientQuery, clientQueryText, startDate, endDate);
                    return;
                }
                //用户查找分类
                if (context.Request["action"] == "clientQueryListLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.ClientQueryCombobox();
                }
                //中奖状态下拉框信息
                if (context.Request["action"] == "ddlAwardResultLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.WinnerLotteryCombobox();
                    return;
                }
                //加载信息
                if (context.Request["action"] == "load")
                {
                    LotteryOrderBLL bll = new LotteryOrderBLL(context, loginUser);
                    string orderId = context.Request["orderId"];//订单号
                    bll.Load(orderId);
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