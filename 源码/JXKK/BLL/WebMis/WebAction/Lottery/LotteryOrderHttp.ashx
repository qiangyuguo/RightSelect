<%@ WebHandler Language="C#" Class="Com.ZY.JXKK.WebAction.Lottery.LotteryOrderHttp" %>

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
    /// 彩票订单
    /// Author:代码生成器
    /// </summary>
    public class LotteryOrderHttp: IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "LotteryOrder");
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
                    bll.LoadGrid(page, rows);
                    return;
                }
                
                //加载信息
                if (context.Request["action"] == "load")
                {
                    LotteryOrderBLL bll = new LotteryOrderBLL(context, loginUser);
                    string orderId=context.Request["orderId"];//订单号
                    bll.Load(orderId);
                    return;
                }
                
                //增加
                if (context.Request["action"] == "add")
                {
                    LotteryOrderBLL bll = new LotteryOrderBLL(context, loginUser);
                    TTLotteryOrder ttLotteryOrder= new TTLotteryOrder();
                    ttLotteryOrder.orderId= context.Request["orderId"];//订单号
                    ttLotteryOrder.agentId= context.Request["agentId"];//代理商编号
                    ttLotteryOrder.siteId= context.Request["siteId"];//门店编号
                    ttLotteryOrder.terminalId= context.Request["terminalId"];//终端编号
                    ttLotteryOrder.clientId= long.Parse(context.Request["clientId"]);//客户编号
                    ttLotteryOrder.clientName= context.Request["clientName"];//客户名称
                    ttLotteryOrder.cardId= context.Request["cardId"];//卡号
                    ttLotteryOrder.gameId= context.Request["gameId"];//游戏编号
                    ttLotteryOrder.lotteryType= context.Request["lotteryType"];//彩种
                    ttLotteryOrder.playType= context.Request["playType"];//玩法
                    ttLotteryOrder.period= context.Request["period"];//期次
                    ttLotteryOrder.betCodes= context.Request["betCodes"];//投注串
                    ttLotteryOrder.multiple= int.Parse(context.Request["multiple"]);//倍数
                    ttLotteryOrder.betFee= double.Parse(context.Request["betFee"]);//投注金额
                    ttLotteryOrder.betTime= context.Request["betTime"];//投注时间
                    ttLotteryOrder.isChase= context.Request["isChase"];//是否追号
                    ttLotteryOrder.chaseOrderId= context.Request["chaseOrderId"];//追号订单编号
                    ttLotteryOrder.orderStatus= context.Request["orderStatus"];//订单状态
                    ttLotteryOrder.orderTime= context.Request["orderTime"];//出票/撤销时间
                    ttLotteryOrder.awardResult= context.Request["awardResult"];//中奖状态
                    ttLotteryOrder.awardMoney= double.Parse(context.Request["awardMoney"]);//中奖金额
                    ttLotteryOrder.awardTime= context.Request["awardTime"];//返奖时间
                    ttLotteryOrder.settleStatus= context.Request["settleStatus"];//结算状态
                    ttLotteryOrder.settleTime= context.Request["settleTime"];//结算时间
                    ttLotteryOrder.createTime= context.Request["createTime"];//创建时间
                    ttLotteryOrder.batchId= context.Request["batchId"];//批处理编号
                    bll.Add(ttLotteryOrder);
                    return;
                }
                
                //修改
                if (context.Request["action"] == "edit")
                {
                    LotteryOrderBLL bll = new LotteryOrderBLL(context, loginUser);
                    TTLotteryOrder ttLotteryOrder= new TTLotteryOrder();
                    ttLotteryOrder.orderId= context.Request["orderId"];//订单号
                    ttLotteryOrder.agentId= context.Request["agentId"];//代理商编号
                    ttLotteryOrder.siteId= context.Request["siteId"];//门店编号
                    ttLotteryOrder.terminalId= context.Request["terminalId"];//终端编号
                    ttLotteryOrder.clientId= long.Parse(context.Request["clientId"]);//客户编号
                    ttLotteryOrder.clientName= context.Request["clientName"];//客户名称
                    ttLotteryOrder.cardId= context.Request["cardId"];//卡号
                    ttLotteryOrder.gameId= context.Request["gameId"];//游戏编号
                    ttLotteryOrder.lotteryType= context.Request["lotteryType"];//彩种
                    ttLotteryOrder.playType= context.Request["playType"];//玩法
                    ttLotteryOrder.period= context.Request["period"];//期次
                    ttLotteryOrder.betCodes= context.Request["betCodes"];//投注串
                    ttLotteryOrder.multiple= int.Parse(context.Request["multiple"]);//倍数
                    ttLotteryOrder.betFee= double.Parse(context.Request["betFee"]);//投注金额
                    ttLotteryOrder.betTime= context.Request["betTime"];//投注时间
                    ttLotteryOrder.isChase= context.Request["isChase"];//是否追号
                    ttLotteryOrder.chaseOrderId= context.Request["chaseOrderId"];//追号订单编号
                    ttLotteryOrder.orderStatus= context.Request["orderStatus"];//订单状态
                    ttLotteryOrder.orderTime= context.Request["orderTime"];//出票/撤销时间
                    ttLotteryOrder.awardResult= context.Request["awardResult"];//中奖状态
                    ttLotteryOrder.awardMoney= double.Parse(context.Request["awardMoney"]);//中奖金额
                    ttLotteryOrder.awardTime= context.Request["awardTime"];//返奖时间
                    ttLotteryOrder.settleStatus= context.Request["settleStatus"];//结算状态
                    ttLotteryOrder.settleTime= context.Request["settleTime"];//结算时间
                    ttLotteryOrder.createTime= context.Request["createTime"];//创建时间
                    ttLotteryOrder.batchId= context.Request["batchId"];//批处理编号
                    bll.Edit(ttLotteryOrder);
                    return;
                }
                
                //删除
                if (context.Request["action"] == "delete")
                {
                    LotteryOrderBLL bll = new LotteryOrderBLL(context, loginUser);
                    string orderId=context.Request["orderId"];//订单号
                    bll.Delete(orderId);
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

