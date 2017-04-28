<%@ WebHandler Language="C#" Class="Com.ZY.JXKK.WebAction.Lottery.ChaseOrderHttp" %>

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
    /// 追号订单
    /// Author:代码生成器
    /// </summary>
    public class ChaseOrderHttp: IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "ChaseOrder");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }
                
                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    ChaseOrderBLL bll = new ChaseOrderBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    bll.LoadGrid(page, rows);
                    return;
                }
                
                //加载信息
                if (context.Request["action"] == "load")
                {
                    ChaseOrderBLL bll = new ChaseOrderBLL(context, loginUser);
                    string chaseOrderId=context.Request["chaseOrderId"];//追号订单号
                    bll.Load(chaseOrderId);
                    return;
                }
                
                //增加
                if (context.Request["action"] == "add")
                {
                    ChaseOrderBLL bll = new ChaseOrderBLL(context, loginUser);
                    TTChaseOrder ttChaseOrder= new TTChaseOrder();
                    ttChaseOrder.chaseOrderId= context.Request["chaseOrderId"];//追号订单号
                    ttChaseOrder.agentId= context.Request["agentId"];//代理商编号
                    ttChaseOrder.siteId= context.Request["siteId"];//门店编号
                    ttChaseOrder.terminalId= context.Request["terminalId"];//终端编号
                    ttChaseOrder.clientId= long.Parse(context.Request["clientId"]);//客户编号
                    ttChaseOrder.clientName= context.Request["clientName"];//客户名称
                    ttChaseOrder.cardId= context.Request["cardId"];//卡号
                    ttChaseOrder.gameId= context.Request["gameId"];//游戏编号
                    ttChaseOrder.lotteryType= context.Request["lotteryType"];//彩种
                    ttChaseOrder.playType= context.Request["playType"];//玩法
                    ttChaseOrder.period= context.Request["period"];//下单期次
                    ttChaseOrder.betCodes= context.Request["betCodes"];//投注串
                    ttChaseOrder.multiple= int.Parse(context.Request["multiple"]);//倍数
                    ttChaseOrder.betNum= int.Parse(context.Request["betNum"]);//投注期数
                    ttChaseOrder.chaseTotalFee= double.Parse(context.Request["chaseTotalFee"]);//订单总额
                    ttChaseOrder.chaseTime= context.Request["chaseTime"];//追号时间
                    ttChaseOrder.endCondition= context.Request["endCondition"];//停止条件
                    ttChaseOrder.conditionParam= int.Parse(context.Request["conditionParam"]);//停止参数
                    ttChaseOrder.usedPeriod= context.Request["usedPeriod"];//运行期次
                    ttChaseOrder.usedNum= int.Parse(context.Request["usedNum"]);//已追期数
                    ttChaseOrder.usedFee= double.Parse(context.Request["usedFee"]);//已追金额
                    ttChaseOrder.backNum= int.Parse(context.Request["backNum"]);//退款期数
                    ttChaseOrder.backFee= double.Parse(context.Request["backFee"]);//退款金额
                    ttChaseOrder.awardMoney= double.Parse(context.Request["awardMoney"]);//中奖金额
                    ttChaseOrder.frozenFee= double.Parse(context.Request["frozenFee"]);//冻结金额
                    ttChaseOrder.chaseStatus= context.Request["chaseStatus"];//追号状态
                    ttChaseOrder.overTime= context.Request["overTime"];//结束时间
                    ttChaseOrder.createTime= context.Request["createTime"];//创建时间
                    ttChaseOrder.batchId= context.Request["batchId"];//批处理编号
                    bll.Add(ttChaseOrder);
                    return;
                }
                
                //修改
                if (context.Request["action"] == "edit")
                {
                    ChaseOrderBLL bll = new ChaseOrderBLL(context, loginUser);
                    TTChaseOrder ttChaseOrder= new TTChaseOrder();
                    ttChaseOrder.chaseOrderId= context.Request["chaseOrderId"];//追号订单号
                    ttChaseOrder.agentId= context.Request["agentId"];//代理商编号
                    ttChaseOrder.siteId= context.Request["siteId"];//门店编号
                    ttChaseOrder.terminalId= context.Request["terminalId"];//终端编号
                    ttChaseOrder.clientId= long.Parse(context.Request["clientId"]);//客户编号
                    ttChaseOrder.clientName= context.Request["clientName"];//客户名称
                    ttChaseOrder.cardId= context.Request["cardId"];//卡号
                    ttChaseOrder.gameId= context.Request["gameId"];//游戏编号
                    ttChaseOrder.lotteryType= context.Request["lotteryType"];//彩种
                    ttChaseOrder.playType= context.Request["playType"];//玩法
                    ttChaseOrder.period= context.Request["period"];//下单期次
                    ttChaseOrder.betCodes= context.Request["betCodes"];//投注串
                    ttChaseOrder.multiple= int.Parse(context.Request["multiple"]);//倍数
                    ttChaseOrder.betNum= int.Parse(context.Request["betNum"]);//投注期数
                    ttChaseOrder.chaseTotalFee= double.Parse(context.Request["chaseTotalFee"]);//订单总额
                    ttChaseOrder.chaseTime= context.Request["chaseTime"];//追号时间
                    ttChaseOrder.endCondition= context.Request["endCondition"];//停止条件
                    ttChaseOrder.conditionParam= int.Parse(context.Request["conditionParam"]);//停止参数
                    ttChaseOrder.usedPeriod= context.Request["usedPeriod"];//运行期次
                    ttChaseOrder.usedNum= int.Parse(context.Request["usedNum"]);//已追期数
                    ttChaseOrder.usedFee= double.Parse(context.Request["usedFee"]);//已追金额
                    ttChaseOrder.backNum= int.Parse(context.Request["backNum"]);//退款期数
                    ttChaseOrder.backFee= double.Parse(context.Request["backFee"]);//退款金额
                    ttChaseOrder.awardMoney= double.Parse(context.Request["awardMoney"]);//中奖金额
                    ttChaseOrder.frozenFee= double.Parse(context.Request["frozenFee"]);//冻结金额
                    ttChaseOrder.chaseStatus= context.Request["chaseStatus"];//追号状态
                    ttChaseOrder.overTime= context.Request["overTime"];//结束时间
                    ttChaseOrder.createTime= context.Request["createTime"];//创建时间
                    ttChaseOrder.batchId= context.Request["batchId"];//批处理编号
                    bll.Edit(ttChaseOrder);
                    return;
                }
                
                //删除
                if (context.Request["action"] == "delete")
                {
                    ChaseOrderBLL bll = new ChaseOrderBLL(context, loginUser);
                    string chaseOrderId=context.Request["chaseOrderId"];//追号订单号
                    bll.Delete(chaseOrderId);
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

