<%@ WebHandler Language="C#" Class="Com.ZY.JXKK.WebAction.Lottery.LotteryHistoryHttp" %>

using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL.Lottery;
using Com.ZY.JXKK.Model.Lottery;

namespace Com.ZY.JXKK.WebAction.Lottery
{
    /// <summary>
    /// 开奖历史
    /// Author:代码生成器
    /// </summary>
    public class LotteryHistoryHttp: IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "LotteryHistory");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }
                
                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    LotteryHistoryBLL bll = new LotteryHistoryBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    bll.LoadGrid(page, rows);
                    return;
                }
                
                //加载信息
                if (context.Request["action"] == "load")
                {
                    LotteryHistoryBLL bll = new LotteryHistoryBLL(context, loginUser);
                    string lotteryType=context.Request["lotteryType"];//彩种
                    bll.Load(lotteryType);
                    return;
                }
                
                //增加
                if (context.Request["action"] == "add")
                {
                    LotteryHistoryBLL bll = new LotteryHistoryBLL(context, loginUser);
                    TBLotteryHistory tbLotteryHistory= new TBLotteryHistory();
                    tbLotteryHistory.lotteryType= context.Request["lotteryType"];//彩种
                    tbLotteryHistory.period= context.Request["period"];//期次
                    tbLotteryHistory.startTime= context.Request["startTime"];//开售时间
                    tbLotteryHistory.endTime= context.Request["endTime"];//截止时间
                    tbLotteryHistory.publishTime= context.Request["publishTime"];//开奖时间
                    tbLotteryHistory.saleStatus= context.Request["saleStatus"];//销售状态
                    tbLotteryHistory.numbers= context.Request["numbers"];//开奖号码
                    tbLotteryHistory.remark= context.Request["remark"];//备注说明
                    bll.Add(tbLotteryHistory);
                    return;
                }
                
                //修改
                if (context.Request["action"] == "edit")
                {
                    LotteryHistoryBLL bll = new LotteryHistoryBLL(context, loginUser);
                    TBLotteryHistory tbLotteryHistory= new TBLotteryHistory();
                    tbLotteryHistory.lotteryType= context.Request["lotteryType"];//彩种
                    tbLotteryHistory.period= context.Request["period"];//期次
                    tbLotteryHistory.startTime= context.Request["startTime"];//开售时间
                    tbLotteryHistory.endTime= context.Request["endTime"];//截止时间
                    tbLotteryHistory.publishTime= context.Request["publishTime"];//开奖时间
                    tbLotteryHistory.saleStatus= context.Request["saleStatus"];//销售状态
                    tbLotteryHistory.numbers= context.Request["numbers"];//开奖号码
                    tbLotteryHistory.remark= context.Request["remark"];//备注说明
                    bll.Edit(tbLotteryHistory);
                    return;
                }
                
                //删除
                if (context.Request["action"] == "delete")
                {
                    LotteryHistoryBLL bll = new LotteryHistoryBLL(context, loginUser);
                    string lotteryType=context.Request["lotteryType"];//彩种
                    bll.Delete(lotteryType);
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

