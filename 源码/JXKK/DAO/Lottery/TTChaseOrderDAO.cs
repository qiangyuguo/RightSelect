using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;
using Com.ZY.JXKK.Util;

namespace Com.ZY.JXKK.DAO.Lottery
{
    /// <summary>
    /// 追号订单
    /// Author:开发人员自行扩展
    /// </summary>
    public class TTChaseOrderDAO:TTChaseOrderDBO
    {

        /// <summary>
        /// 获取追号订单
        /// <param name="chaseOrderId">追号订单号</param>
        /// </summary>
        /// <returns>追号订单对象</returns>
        public override TTChaseOrder Get(string chaseOrderId)
        {
            TTChaseOrder ttChaseOrder = null;
            try
            {
                string strSQL = @"select c.chaseorderid,case c.chaseType when '0' then '普通追号' when '1' then '高级追号' end chaseType,      
                                   a.agentname agentid,s.sitename siteid,  c.terminalid, c.clientid,  c.clientname, c.cardid, g.gamename,g.gameid, 
                                   l.LotteryTypeName lotterytype, c.period, c.userBetCodes,c.centerBetCodes, c.betnum,  c.chasetotalfee, c.chasetime, 
                                   case c.endcondition when '0' then '不停止' when '1' then '固定奖金停止' when '2' then '达到中奖率停止' end endcondition, 
                                   c.conditionparam,
                                   c.usedperiod, c.usednum, c.usedfee,  c.backnum,  c.backfee, c.awardmoney, c.frozenfee,  
                                   case c.chasestatus when '0' then '正在追号' when '1' then '中奖停止' when '2' then '追期结束' when '3' then '手工停止'
                                   when '4' then '追号撤单' when '5' then '异常停止' end chasestatus,
                                   c.overtime, c.createtime,
                                   case c.srcType when '0' then '游戏终端' when '1' then '手机APP' end srcType
                                   from TTChaseOrder c,Tbgame g,TBlottery l,TBAgent a,TBSite s
                                   where c.gameid=g.gameid and c.lotterytype=l.lotterytype
                                   and c.agentid=a.agentid and c.siteid=s.siteid and chaseOrderId=@chaseOrderId";
                Param param = new Param();
                param.Clear();
                param.Add("@chaseOrderId", chaseOrderId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttChaseOrder = ReadData(dr);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
            return ttChaseOrder;
        }

        /// <summary>
        /// 读取追号订单信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>追号订单对象</returns>
        protected override TTChaseOrder ReadData(ComDataReader dr)
        {
            TTChaseOrder ttChaseOrder = new TTChaseOrder();
            ttChaseOrder.chaseOrderId = dr["chaseOrderId"].ToString();//追号订单号
            ttChaseOrder.chaseType = dr["chaseType"].ToString();//追号订单类型
            ttChaseOrder.agentId = dr["agentId"].ToString();//代理商编号
            ttChaseOrder.siteId = dr["siteId"].ToString();//门店编号
            ttChaseOrder.terminalId = dr["terminalId"].ToString();//终端编号
            ttChaseOrder.clientId = long.Parse(dr["clientId"].ToString());//客户编号
            ttChaseOrder.clientName = dr["clientName"].ToString();//客户名称
            ttChaseOrder.cardId = dr["cardId"].ToString();//卡号
            ttChaseOrder.gameId = dr["gameName"].ToString();//游戏编号
            ttChaseOrder.lotteryType = dr["lotteryType"].ToString();//彩种
            ttChaseOrder.period = dr["period"].ToString();//下单期次
            ttChaseOrder.userBetCodes = BetCodesContext.GetBetCodes(dr["gameId"].ToString(), dr["userBetCodes"].ToString(), true);//用户投注串
            ttChaseOrder.centerBetCodes = BetCodesContext.GetBetCodes(dr["gameId"].ToString(), dr["centerBetCodes"].ToString(), true);//中心投注串
            ttChaseOrder.betNum = int.Parse(dr["betNum"].ToString());//投注期数
            ttChaseOrder.chaseTotalFee = double.Parse(dr["chaseTotalFee"].ToString());//订单总额
            ttChaseOrder.chaseTime = dr["chaseTime"].ToString();//追号时间
            ttChaseOrder.endCondition = dr["endCondition"].ToString();//停止条件
            ttChaseOrder.conditionParam = int.Parse(dr["conditionParam"].ToString());//停止参数
            ttChaseOrder.usedPeriod = dr["usedPeriod"].ToString();//运行期次
            ttChaseOrder.usedNum = int.Parse(dr["usedNum"].ToString());//已追期数
            ttChaseOrder.usedFee = double.Parse(dr["usedFee"].ToString());//已追金额
            ttChaseOrder.backNum = int.Parse(dr["backNum"].ToString());//退款期数
            ttChaseOrder.backFee = double.Parse(dr["backFee"].ToString());//退款金额
            ttChaseOrder.awardMoney = double.Parse(dr["awardMoney"].ToString());//中奖金额
            ttChaseOrder.frozenFee = double.Parse(dr["frozenFee"].ToString());//冻结金额
            ttChaseOrder.chaseStatus = dr["chaseStatus"].ToString();//追号状态
            ttChaseOrder.srcType = dr["srcType"].ToString();//数据来源方式
            ttChaseOrder.overTime = dr["overTime"].ToString();//结束时间
            if (dr["createTime"] == null)
            {
                ttChaseOrder.createTime = "";//创建时间
            }
            else
            {
                ttChaseOrder.createTime = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dr["createTime"]);//创建时间
            }
            return ttChaseOrder;
        }
    }
}

