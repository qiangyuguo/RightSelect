using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.PointBet
{
    /// <summary>
    /// 积分投注
    /// Author:开发人员自行扩展
    /// </summary>
    public class TTPointOrderDAO:TTPointOrderDBO
    {
        /// <summary>
        /// 获取积分订单
        /// <param name="orderId">订单号</param>
        /// </summary>
        /// <returns>积分订单对象</returns>
        public override TTPointOrder Get(string orderId)
        {
            TTPointOrder ttPointOrder = null;
            try
            {
                string strSQL = @"select t.orderid,a.agentname agentid,s.sitename siteid, t.terminalid, t.clientid, t.clientname, t.cardid, g.gamename, g.gameid,
                                   t.period,t.betCodes,  t.betpoint, t.bettime,
                                   case t.orderstatus when '0' then '已投注' when '1' then '已撤单' end orderstatus ,
                                   t.ordertime,
                                   case t.awardresult when '0' then '未开奖' when '1' then '未中奖' when '2' then '中奖' end awardresult,
                                   t.awardpoint,t.awardtime,
                                   case t.srcType when '0' then '游戏终端' when '1' then '手机APP' end srcType,
                                   t.createtime
                                   from TTPointOrder t,TBGame g,TBAgent a,TBSite s
                                   where t.gameid=g.gameid
                                   and t.agentid=a.agentid
                                   and t.siteid=s.siteid and t.orderId=@orderId";
                Param param = new Param();
                param.Clear();
                param.Add("@orderId", orderId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttPointOrder = ReadData(dr);
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
            return ttPointOrder;
        }

        /// <summary>
        /// 读取积分订单信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>积分订单对象</returns>
        protected override TTPointOrder ReadData(ComDataReader dr)
        {
            TTPointOrder ttPointOrder = new TTPointOrder();

            ttPointOrder.orderId = dr["orderId"].ToString();//订单号
            ttPointOrder.agentId = dr["agentId"].ToString();//代理商编号
            ttPointOrder.siteId = dr["siteId"].ToString();//门店编号
            ttPointOrder.terminalId = dr["terminalId"].ToString();//终端编号
            ttPointOrder.clientId = long.Parse(dr["clientId"].ToString());//客户编号
            ttPointOrder.clientName = dr["clientName"].ToString();//客户名称
            ttPointOrder.cardId = dr["cardId"].ToString();//卡号
            ttPointOrder.gameId = dr["gameName"].ToString();//游戏编号
            ttPointOrder.period = dr["period"].ToString();//期次
            ttPointOrder.betPoint = long.Parse(dr["betPoint"].ToString());//投注金额
            ttPointOrder.betTime = dr["betTime"].ToString();//投注时间
            ttPointOrder.orderStatus = dr["orderStatus"].ToString();//订单状态
            ttPointOrder.orderTime = dr["orderTime"].ToString();//出票/撤销时间
            ttPointOrder.awardResult = dr["awardResult"].ToString();//中奖状态
            ttPointOrder.awardPoint = long.Parse(dr["awardPoint"].ToString());//中奖金额
            ttPointOrder.awardTime = dr["awardTime"].ToString();//返奖时间
            ttPointOrder.srcType = dr["srcType"].ToString();//数据来源方式
            ttPointOrder.betCodes =BetCodesContext.GetBetCodes(dr["gameId"].ToString(), dr["betCodes"].ToString(),false);//用户投注串
            if (dr["createTime"] == null)
            {
                ttPointOrder.createTime = "";//创建时间
            }
            else
            {
                ttPointOrder.createTime = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dr["createTime"]);//创建时间
            }
            return ttPointOrder;
        }
    }
}

