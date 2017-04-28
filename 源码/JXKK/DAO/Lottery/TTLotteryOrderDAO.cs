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
    /// 订单
    /// Author:开发人员自行扩展
    /// </summary>
    public class TTLotteryOrderDAO:TTLotteryOrderDBO
    {
        /// <summary>
        /// 获取订单
        /// <param name="orderId">订单号</param>
        /// </summary>
        /// <returns>订单对象</returns>
        public override TTLotteryOrder Get(string orderId)
        {
            TTLotteryOrder ttLotteryOrder = null;
            try
            {
                string strSQL = @"select t.orderid,a.agentname agentid,s.sitename siteid, t.terminalid, t.clientid, t.clientname, t.cardid, g.gamename, g.gameid,
                                   l.lotterytypename lotterytype,t.period, t.userBetCodes,t.centerBetCodes, t.multiple, t.betfee, t.bettime, t.ischase, t.chaseorderid,
                                   case t.orderstatus when '0' then '未出票' when '1' then '已出票' when '2' then '已撤单' else  '出票失败' end orderstatus ,
                                   t.ordertime,
                                   case t.awardresult when '0' then '未开奖' when '1' then '未中奖' when '2' then '小奖' when '3' then '大奖' end awardresult,
                                   t.awardmoney,t.awardtime,
                                   case t.settlestatus when '0' then '未结' when '1' then '已结' end settlestatus,
                                   case t.srcType when '0' then '游戏终端' when '1' then '手机APP' end srcType,
                                   t.settletime, t.createtime
                                   from TTLotteryOrder t,TBGame g,TBLottery l,TBAgent a,TBSite s
                                   where t.gameid=g.gameid
                                   and t.lotterytype=l.lotterytype
                                   and t.agentid=a.agentid
                                   and t.siteid=s.siteid and t.orderId=@orderId";
                Param param = new Param();
                param.Clear();
                param.Add("@orderId", orderId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttLotteryOrder = ReadData(dr);
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
            return ttLotteryOrder;
        }

        /// <summary>
        /// 读取彩票订单信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>彩票订单对象</returns>
        protected override  TTLotteryOrder ReadData(ComDataReader dr)
        {
            TTLotteryOrder ttLotteryOrder= new TTLotteryOrder();

            ttLotteryOrder.orderId= dr["orderId"].ToString();//订单号
            ttLotteryOrder.agentId= dr["agentId"].ToString();//代理商编号
            ttLotteryOrder.siteId= dr["siteId"].ToString();//门店编号
            ttLotteryOrder.terminalId= dr["terminalId"].ToString();//终端编号
            ttLotteryOrder.clientId= long.Parse(dr["clientId"].ToString());//客户编号
            ttLotteryOrder.clientName= dr["clientName"].ToString();//客户名称
            ttLotteryOrder.cardId= dr["cardId"].ToString();//卡号
            ttLotteryOrder.gameId= dr["gameName"].ToString();//游戏编号
            ttLotteryOrder.lotteryType= dr["lotteryType"].ToString();//彩种
            ttLotteryOrder.period= dr["period"].ToString();//期次
            ttLotteryOrder.multiple= int.Parse(dr["multiple"].ToString());//倍数
            ttLotteryOrder.betFee= double.Parse(dr["betFee"].ToString());//投注金额
            ttLotteryOrder.betTime= dr["betTime"].ToString();//投注时间
            ttLotteryOrder.isChase= dr["isChase"].ToString();//是否追号
            ttLotteryOrder.chaseOrderId= dr["chaseOrderId"].ToString();//追号订单编号
            ttLotteryOrder.orderStatus= dr["orderStatus"].ToString();//订单状态
            ttLotteryOrder.orderTime= dr["orderTime"].ToString();//出票/撤销时间
            ttLotteryOrder.awardResult= dr["awardResult"].ToString();//中奖状态
            ttLotteryOrder.awardMoney= double.Parse(dr["awardMoney"].ToString());//中奖金额
            ttLotteryOrder.awardTime= dr["awardTime"].ToString();//返奖时间
            ttLotteryOrder.settleStatus= dr["settleStatus"].ToString();//结算状态
            ttLotteryOrder.srcType = dr["srcType"].ToString();//数据来源方式
            ttLotteryOrder.settleTime= dr["settleTime"].ToString();//结算时间
            bool isChase =false;
            if (ttLotteryOrder.isChase == "1")
                isChase = true;
            ttLotteryOrder.userBetCodes = BetCodesContext.GetBetCodes(dr["gameId"].ToString(), dr["userBetCodes"].ToString(), isChase);//用户投注串
            ttLotteryOrder.centerBetCodes = BetCodesContext.GetBetCodes(dr["gameId"].ToString(), dr["centerBetCodes"].ToString(), isChase);//中心投注串

            if(dr["createTime"]==null)
            {
                ttLotteryOrder.createTime= "";//创建时间
            }
            else
            {
                ttLotteryOrder.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            return ttLotteryOrder;
        }


        /// <summary>
        /// 获取列表(彩票订单)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>彩票订单列表对象</returns>
        public List<LotteryOrderSale> GetLotteryOrderSaleList(string strSQL, Param param)
        {
            List<LotteryOrderSale> list = new List<LotteryOrderSale>();
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while (dr.Read())
                {
                    list.Add(LotteryOrderSaleReadData(dr));
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
            return list;
        }


        /// <summary>
        /// 读取订单信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>订单对象</returns>
        protected LotteryOrderSale LotteryOrderSaleReadData(ComDataReader dr)
        {
            LotteryOrderSale lotteryOrderSale = new LotteryOrderSale();

            lotteryOrderSale.BetDate = dr["BetDate"].ToString();//投注日期
            lotteryOrderSale.SumBetFee =double.Parse(dr["SumBetFee"].ToString());//销售总额
            lotteryOrderSale.SumAwardMoney = double.Parse(dr["SumAwardMoney"].ToString());//中奖金额
            lotteryOrderSale.AwardResult =dr["AwardResult"].ToString();//中奖状态
            lotteryOrderSale.OrderStatus = dr["OrderStatus"].ToString();//订单状态
            return lotteryOrderSale;
        }



        /// <summary>
        /// 获取订单销售总计
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>订单销售总计double</returns>
        public DataTable LotteryOrderSaleDT(string strSQL, Param param)
        {
            DataTable dt;
            try
            {
                db.Open();
                dt = db.ExecuteDataView(CommandType.Text, strSQL, param).Table;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }

            return dt;
        }
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public DataTable LotteryOrderDT(string strSQL)
        {
            Param param = new Param();
            DataTable dt = db.ExecuteDataView(CommandType.Text, strSQL, param).Table;
            return dt;
        }

        /// <summary>
        /// 获取交易销售总计
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>交易销售总计double</returns>
        public double GetTotalFee(string strSQL, Param param)
        {
            double totalFee;
            try
            {
                db.Open();
                object obj = db.ExecuteScalar(CommandType.Text, strSQL, param);
                if (obj == DBNull.Value)
                {
                    totalFee = 0;
                }
                else
                {
                    totalFee = double.Parse(obj.ToString());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }

            return totalFee;
        }
    }
}

