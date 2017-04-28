<%@ WebHandler Language="C#" Class="Com.ZY.JXKK.WebAction.Lottery.LotteryPeriodHttp" %>

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
    /// 彩票奖期
    /// Author:代码生成器
    /// </summary>
    public class LotteryPeriodHttp: IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "LotteryPeriod");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }
                
                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    LotteryPeriodBLL bll = new LotteryPeriodBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    bll.LoadGrid(page, rows);
                    return;
                }
                
                //加载信息
                if (context.Request["action"] == "load")
                {
                    LotteryPeriodBLL bll = new LotteryPeriodBLL(context, loginUser);
                    string lotteryType=context.Request["lotteryType"];//彩种
                    bll.Load(lotteryType);
                    return;
                }
                
                //增加
                if (context.Request["action"] == "add")
                {
                    LotteryPeriodBLL bll = new LotteryPeriodBLL(context, loginUser);
                    TBLotteryPeriod tbLotteryPeriod= new TBLotteryPeriod();
                    tbLotteryPeriod.lotteryType= context.Request["lotteryType"];//彩种
                    tbLotteryPeriod.period= context.Request["period"];//期次
                    tbLotteryPeriod.startTime= context.Request["startTime"];//开售时间
                    tbLotteryPeriod.endTime= context.Request["endTime"];//截止时间
                    tbLotteryPeriod.publishTime= context.Request["publishTime"];//开奖时间
                    tbLotteryPeriod.saleStatus= context.Request["saleStatus"];//销售状态
                    tbLotteryPeriod.remark= context.Request["remark"];//备注说明
                    bll.Add(tbLotteryPeriod);
                    return;
                }
                
                //修改
                if (context.Request["action"] == "edit")
                {
                    LotteryPeriodBLL bll = new LotteryPeriodBLL(context, loginUser);
                    TBLotteryPeriod tbLotteryPeriod= new TBLotteryPeriod();
                    tbLotteryPeriod.lotteryType= context.Request["lotteryType"];//彩种
                    tbLotteryPeriod.period= context.Request["period"];//期次
                    tbLotteryPeriod.startTime= context.Request["startTime"];//开售时间
                    tbLotteryPeriod.endTime= context.Request["endTime"];//截止时间
                    tbLotteryPeriod.publishTime= context.Request["publishTime"];//开奖时间
                    tbLotteryPeriod.saleStatus= context.Request["saleStatus"];//销售状态
                    tbLotteryPeriod.remark= context.Request["remark"];//备注说明
                    bll.Edit(tbLotteryPeriod);
                    return;
                }
                
                //删除
                if (context.Request["action"] == "delete")
                {
                    LotteryPeriodBLL bll = new LotteryPeriodBLL(context, loginUser);
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

