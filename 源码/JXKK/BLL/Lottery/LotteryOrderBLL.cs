using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Lottery;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.BLL.Agent;

namespace Com.ZY.JXKK.BLL.Lottery
{
    /// <summary>
    /// 彩票订单
    /// Author:代码生成器
    /// </summary>
    public class LotteryOrderBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TTLotteryOrderDAO ttLotteryOrderDAO = new TTLotteryOrderDAO();

        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public LotteryOrderBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }

        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string agentId, string siteId, string orderId, string period, string orderStatus, string awardResult,string srcType, string clientQuery, string clientQueryText, string startDate, string endDate)
        {
            string strSQL = @"select t.*,g.gamename,l.lotterytypename
                                from ttlotteryorder t,tbgame g,tblottery l,TBClient bc
                                where t.gameid=g.gameid and t.lotterytype=l.lotterytype 
                                and t.clientId=bc.clientId ";
            if (!string.IsNullOrEmpty(orderId))
                strSQL += " and t.orderId like'%" + orderId + "%'";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and t.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and t.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(period))
                strSQL += " and t.period='" + period + "'";
            if (!string.IsNullOrEmpty(orderStatus))
                strSQL += " and t.orderStatus='" + orderStatus + "'";
            if (!string.IsNullOrEmpty(awardResult))
                strSQL += " and t.awardResult='" + awardResult + "'";
            if (!string.IsNullOrEmpty(srcType))
                strSQL += " and t.srcType='" + srcType + "'";
            if (!string.IsNullOrEmpty(clientQueryText) && !string.IsNullOrEmpty(clientQuery))
            {
                if (clientQuery == ((int)ClientQuery.CardId).ToString())
                    strSQL += " and t.cardId='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClientId).ToString())
                    strSQL += " and t.clientId='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClientName).ToString())
                    strSQL += " and t.clientName='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClinetPhone).ToString())
                    strSQL += " and bc.telephone='" + clientQueryText + "'";
            }
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and t.betTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and t.betTime<='" + endDate + " 23:59:59'";
            strSQL += " order by betTime desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }



        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void WLoadGrid(int page, int rows, string agentId, string siteId, string period, string awardResult, string clientQuery, string clientQueryText, string startDate, string endDate)
        {
            string strSQL = @"select t.orderid, t.agentid, t.siteid, t.terminalid, t.clientid, t.clientname, t.cardid,g.gamename gameid, 
                             l.lotterytypename lotterytype,t.period,  t.userBetCodes,t.centerBetCodes, t.multiple, t.betfee, t.bettime, t.ischase, 
                             t.chaseorderid, t.orderstatus, t.ordertime,  t.awardresult, t.awardmoney, t.awardtime,  t.settlestatus, 
                             t.settletime, t.createtime
                             from ttlotteryorder t,tbgame g,tblottery l
                             where t.gameid=g.gameid 
                             and t.lotterytype=l.lotterytype 
                             and t.orderStatus=" + (int)OrderStatus.Ticket + "" +
                             " and t.awardResult in (" + ((int)AwardResult.SmallAward).ToString() + "," + ((int)AwardResult.BigAward).ToString() + ")";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and t.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and t.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(period))
                strSQL += " and t.period='" + period + "'";
            if (!string.IsNullOrEmpty(awardResult))
                strSQL += " and t.awardResult='" + awardResult + "'";
            if (!string.IsNullOrEmpty(clientQueryText) && !string.IsNullOrEmpty(clientQuery))
            {
                if (clientQuery == ((int)ClientQuery.CardId).ToString())
                    strSQL += " and t.cardId='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClientId).ToString())
                    strSQL += " and t.clientId='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClientName).ToString())
                    strSQL += " and t.clientName='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClinetPhone).ToString())
                    strSQL += " and bc.telephone='" + clientQueryText + "'";
            }
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and t.awardTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and t.awardTime<='" + endDate + " 23:59:59'";
            strSQL += " order by t.betTime desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }


        /// <summary>
        /// 根据条件分组获取彩票订单数据
        /// </summary>
        /// <param name="startDate">投注开始时间</param>
        /// <param name="endDate">投注结束时间</param>
        /// <param name="city">市</param>
        /// <param name="county">区县</param>
        /// <param name="siteId">快开厅</param>
        /// <param name="agentId">代理商</param>
        /// <param name="terminalId">终端号</param>
        /// <returns></returns>
        public List<LotteryOrderSale> GetLotteryOrderSaleList(string startDate, string endDate, string city, string county, string siteId, string agentId, string terminalId)
        {
            List<LotteryOrderSale> lotteryOrderSaleList = new List<LotteryOrderSale>();
            string strSQL = @" select sum(t.betFee) sumBetFee,sum(t.awardmoney)sumAwardMoney,substr(t.bettime,1,10) BetDate,t.awardresult,t.orderstatus from ttlotteryorder t,
                              TBAgent a ,TBGame g where t.agentId=a.agentId and t.gameId=g.gameId ";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and t.betTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and t.betTime<='" + endDate + " 23:59:59'";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and t.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and t.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(city) && string.IsNullOrEmpty(county))
                strSQL += " and a.areaId in(select areaid from tbarea start with areaid = '" + city + "'connect by prior areaid = parentid)";
            if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(county))
                strSQL += " and a.areaId='" + county + "'";
            if (!string.IsNullOrEmpty(terminalId))
                strSQL += " and t.terminalId='" + terminalId + "'";
            strSQL += @"group by substr(t.bettime,1,10),t.awardresult,t.orderstatus
                              order by substr(t.bettime,1,10)";
            Param param = new Param();
            lotteryOrderSaleList = ttLotteryOrderDAO.GetLotteryOrderSaleList(strSQL, param);
            return lotteryOrderSaleList;
        }

        public List<TTLotteryOrder> GetList(string startDate, string endDate, string agentId)
        {
            string strSQL = @"select l.*,g.gamename from ttlotteryorder l,TBGame g
                                where l.gameid=g.gameid   and l.agentId=" + agentId + " and l.orderStatus=" + (int)OrderStatus.Ticket + "";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and l.betTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and l.betTime<='" + endDate + " 23:59:59'";
            Param param = new Param();
            List<TTLotteryOrder> lotteryOrderList = ttLotteryOrderDAO.GetList(strSQL, param);
            return lotteryOrderList;

        }
        /// <summary>
        /// 终端号对应的游戏销售金额
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="agentId"></param>
        /// <param name="terminalId"></param>
        /// <returns></returns>
        public List<TTLotteryOrder> GetList(string startDate, string endDate, string agentId, string terminalId)
        {
            string strSQL = @"select orderid,  agentid,  siteid, terminalid, clientid, clientname, cardid,  g.gamename, g.gameid, lotterytype, 
                                period, userbetcodes,  centerbetcodes,  multiple,  betfee,   substr(betTime,1,10) betTime, ischase, chaseorderid, 
                                orderstatus,  ordertime, awardresult, awardmoney,  awardtime, settlestatus, settletime, createtime ,srctype from TTLotteryOrder l,TBGame g
                                where l.gameid=g.gameid and g.typecode=0 and  agentId=" + agentId + " and orderStatus=" + (int)OrderStatus.Ticket + "";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and betTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and betTime<='" + endDate + " 23:59:59'";
            if (!string.IsNullOrEmpty(terminalId))
                strSQL += " and terminalid='" + terminalId + "'";
            strSQL += " order by  bettime desc";
            Param param = new Param();
            List<TTLotteryOrder> lotteryOrderList = ttLotteryOrderDAO.GetList(strSQL, param);
            return lotteryOrderList;

        }
        /// <summary>
        /// 加载指定彩票订单
        /// <param name="orderId">订单号</param>
        /// </summary>
        public void Load(string orderId)
        {
            try
            {
                TTLotteryOrder ttLotteryOrder = ttLotteryOrderDAO.Get(orderId);
                ttLotteryOrder.isChase = "1".Equals(ttLotteryOrder.isChase) ? "on" : "off";
                WebJson.ToJson(context, ttLotteryOrder);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }


        /// <summary>
        /// 获取DataSet(中奖数据)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>中奖数据DataSet</returns>
        public DataSet GetWinPrizeDataSet(string startDate, string endDate, string city, string county, string siteId, string terminalId, string lotteryType, string gameId)
        {
            Param param = new Param();
            string strSQL = @"select pa.areaname city, ca.areaname county, s.sitename sitename,t.terminalid,t.clientid,  l.lotterytypename lotterytype, g.gamename gameId, 
                                t.period, t.awardtime, t.orderid, t.awardmoney
                                from ttlotteryorder t,tbgame g,tblottery l,TBSite s,TBAgent a,TBArea ca,Tbarea pa
                                where t.gameid=g.gameid and t.lotterytype=l.lotterytype
                                and s.siteid=t.siteid and a.agentid=t.agentid
                                and ca.areaid=a.areaid and ca.parentid=pa.areaid 
                                and t.orderStatus=" + (int)OrderStatus.Ticket + "" +
                                " and t.awardResult in (" + ((int)AwardResult.SmallAward).ToString() + "," + ((int)AwardResult.BigAward).ToString() + ")";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and t.awardTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and t.awardTime<='" + endDate + " 23:59:59'";
            if (!string.IsNullOrEmpty(city) && string.IsNullOrEmpty(county))
                strSQL += " and pa.areaId in(select areaid from tbarea start with areaid = '" + city + "'connect by prior areaid = parentid)";
            if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(county))
                strSQL += " and ca.areaId='" + county + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and t.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(terminalId))
                strSQL += " and t.terminalId='" + terminalId + "'";
            if (!string.IsNullOrEmpty(lotteryType))
                strSQL += " and t.lotteryType='" + lotteryType + "'";
            if (!string.IsNullOrEmpty(gameId))
                strSQL += " and t.gameId='" + gameId + "'";
            strSQL += " order by awardTime";
            return ttLotteryOrderDAO.GetDataSet(strSQL, param);
        }

        /// <summary>
        /// 获取DataSet(交易数据)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>交易数据DataSet</returns>
        public DataSet GetTradingDataSet(string startDate, string endDate, string city, string county, string siteId, string terminalId, string lotteryType, string gameId)
        {
            Param param = new Param();
            string strSQL = @"select pa.areaname city, ca.areaname county, s.sitename sitename,t.terminalid,t.clientid,  l.lotterytypename lotterytype, g.gamename gameId, 
                                t.period, t.bettime, t.orderid, t.betfee
                                from ttlotteryorder t,tbgame g,tblottery l,TBSite s,TBAgent a,TBArea ca,Tbarea pa
                                where t.gameid=g.gameid and t.lotterytype=l.lotterytype
                                and s.siteid=t.siteid and a.agentid=t.agentid
                                and ca.areaid=a.areaid and ca.parentid=pa.areaid 
                                and t.orderStatus in (" + ((int)OrderStatus.Ticket).ToString() + ")";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and t.betTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and t.betTime<='" + endDate + " 23:59:59'";
            if (!string.IsNullOrEmpty(city) && string.IsNullOrEmpty(county))
                strSQL += " and pa.areaId in(select areaid from tbarea start with areaid = '" + city + "'connect by prior areaid = parentid)";
            if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(county))
                strSQL += " and ca.areaId='" + county + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and t.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(terminalId))
                strSQL += " and t.terminalId='" + terminalId + "'";
            if (!string.IsNullOrEmpty(lotteryType))
                strSQL += " and t.lotteryType='" + lotteryType + "'";
            if (!string.IsNullOrEmpty(gameId))
                strSQL += " and t.gameId='" + gameId + "'";
            strSQL += " order by betTime";
            return ttLotteryOrderDAO.GetDataSet(strSQL, param);
        }


        /// <summary>
        /// 加载交易数据报表数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">行数</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="city">市</param>
        /// <param name="county">区县</param>
        /// <param name="siteId">快开厅</param>
        /// <param name="terminalId">终端号</param>
        /// <param name="lotteryType">彩种</param>
        /// <param name="gameId">游戏</param>
        public void TradingDataLoadGrid(int page, int rows, string startDate, string endDate, string city, string county, string siteId, string terminalId, string lotteryType, string gameId)
        {
            string strSQL = TradingDataReportSql(startDate, endDate, city, county, siteId, terminalId, lotteryType, gameId);
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }

        /// <summary>
        /// 返回交易数据报表DataTable
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="city">市</param>
        /// <param name="county">区县</param>
        /// <param name="siteId">快开厅</param>
        /// <param name="terminalId">终端号</param>
        /// <param name="lotteryType">彩种</param>
        /// <param name="gameId">游戏</param>
        /// <returns></returns>
        public DataTable TradingDataReport(string startDate, string endDate, string city, string county, string siteId, string terminalId, string lotteryType, string gameId)
        {
            string strSQL = TradingDataReportSql(startDate, endDate, city, county, siteId, terminalId, lotteryType, gameId);
            DataTable dt = ttLotteryOrderDAO.LotteryOrderDT(strSQL);
            return dt;
        }

        /// <summary>
        /// 获取交易数据销售金额总计
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="city">市</param>
        /// <param name="county">区县</param>
        /// <param name="siteId">快开厅</param>
        /// <param name="terminalId">终端号</param>
        /// <param name="lotteryType">彩种</param>
        /// <param name="gameId">游戏</param>
        /// <returns></returns>
        public double GetTotalSale(string startDate, string endDate, string city, string county, string siteId, string terminalId, string lotteryType, string gameId)
        {
            double totalFee;
            string strSQL = " select sum(betfee) from (" + TradingDataReportSql(startDate, endDate, city, county, siteId, terminalId, lotteryType, gameId) + ")";
            Param param = new Param();
            totalFee = ttLotteryOrderDAO.GetTotalFee(strSQL, param);
            return totalFee;
        }
        /// <summary>
        /// 交易数据Sql
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="city">市</param>
        /// <param name="county">区县</param>
        /// <param name="siteId">快开厅</param>
        /// <param name="terminalId">终端号</param>
        /// <param name="lotteryType">彩种</param>
        /// <param name="gameId">游戏</param>
        /// <returns></returns>
        public string TradingDataReportSql(string startDate, string endDate, string city, string county, string siteId, string terminalId, string lotteryType, string gameId)
        {
            string strSQL = @"select pa.areaname city, ca.areaname county, s.sitename sitename,t.terminalid,t.clientid,  l.lotterytypename lotterytype, g.gamename gameId, 
                                t.period, t.bettime, t.orderid, t.betfee
                                from ttlotteryorder t,tbgame g,tblottery l,TBSite s,TBAgent a,TBArea ca,Tbarea pa
                                where t.gameid=g.gameid and t.lotterytype=l.lotterytype
                                and s.siteid=t.siteid and a.agentid=t.agentid
                                and ca.areaid=a.areaid and ca.parentid=pa.areaid 
                                and t.orderStatus in (" + ((int)OrderStatus.Ticket).ToString() + ")";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and t.betTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and t.betTime<='" + endDate + " 23:59:59'";
            if (!string.IsNullOrEmpty(city) && string.IsNullOrEmpty(county))
                strSQL += " and pa.areaId in(select areaid from tbarea start with areaid = '" + city + "'connect by prior areaid = parentid)";
            if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(county))
                strSQL += " and ca.areaId='" + county + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and t.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(terminalId))
                strSQL += " and t.terminalId='" + terminalId + "'";
            if (!string.IsNullOrEmpty(lotteryType))
                strSQL += " and t.lotteryType='" + lotteryType + "'";
            if (!string.IsNullOrEmpty(gameId))
                strSQL += " and t.gameId='" + gameId + "'";
            strSQL += " order by betTime desc";
            return strSQL;
        }


        /// <summary>
        /// 加载中奖数据报表数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void WinPrizeDataLoadGrid(int page, int rows, string startDate, string endDate, string city, string county, string siteId, string terminalId, string lotteryType, string gameId)
        {
            string strSQL = WinPrizeDataReportSql(startDate, endDate, city, county, siteId, terminalId, lotteryType, gameId);
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }

        /// <summary>
        /// 返回中奖数据报表DataTable
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public DataTable WinPrizeDataReport(string startDate, string endDate, string city, string county, string siteId, string terminalId, string lotteryType, string gameId)
        {
            string strSQL = WinPrizeDataReportSql(startDate, endDate, city, county, siteId, terminalId, lotteryType, gameId);
            DataTable dt = ttLotteryOrderDAO.LotteryOrderDT(strSQL);
            return dt;
        }
        /// <summary>
        /// 获取中奖金额总计
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="city">市</param>
        /// <param name="county">区县</param>
        /// <param name="siteId">快开厅</param>
        /// <param name="terminalId">终端号</param>
        /// <param name="lotteryType">彩种</param>
        /// <param name="gameId">游戏</param>
        /// <returns></returns>
        public double GetTotalWinPrize(string startDate, string endDate, string city, string county, string siteId, string terminalId, string lotteryType, string gameId)
        {
            double totalFee;
            string strSQL = " select sum(awardmoney) from (" + WinPrizeDataReportSql(startDate, endDate, city, county, siteId, terminalId, lotteryType, gameId) + ")";
            Param param = new Param();
            totalFee = ttLotteryOrderDAO.GetTotalFee(strSQL, param);
            return totalFee;
        }
        public string WinPrizeDataReportSql(string startDate, string endDate, string city, string county, string siteId, string terminalId, string lotteryType, string gameId)
        {
            string strSQL = @"select pa.areaname city, ca.areaname county, s.sitename sitename,t.terminalid,t.clientid,  l.lotterytypename lotterytype, g.gamename gameId, 
                                t.period, t.awardtime, t.orderid, t.awardmoney
                                from ttlotteryorder t,tbgame g,tblottery l,TBSite s,TBAgent a,TBArea ca,Tbarea pa
                                where t.gameid=g.gameid and t.lotterytype=l.lotterytype
                                and s.siteid=t.siteid and a.agentid=t.agentid
                                and ca.areaid=a.areaid and ca.parentid=pa.areaid 
                                and t.orderStatus=" + (int)OrderStatus.Ticket + "" +
                                " and t.awardResult in (" + ((int)AwardResult.SmallAward).ToString() + "," + ((int)AwardResult.BigAward).ToString() + ")";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and t.awardTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and t.awardTime<='" + endDate + " 23:59:59'";
            if (!string.IsNullOrEmpty(city) && string.IsNullOrEmpty(county))
                strSQL += " and pa.areaId in(select areaid from tbarea start with areaid = '" + city + "'connect by prior areaid = parentid)";
            if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(county))
                strSQL += " and ca.areaId='" + county + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and t.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(terminalId))
                strSQL += " and t.terminalId='" + terminalId + "'";
            if (!string.IsNullOrEmpty(lotteryType))
                strSQL += " and t.lotteryType='" + lotteryType + "'";
            if (!string.IsNullOrEmpty(gameId))
                strSQL += " and t.gameId='" + gameId + "'";
            strSQL += " order by awardTime desc";
            return strSQL;
        }

        /// <summary>
        /// 加载销售统计报表数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">行数</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="city">市</param>
        /// <param name="county">区县</param>
        /// <param name="siteId">快开厅</param>
        /// <param name="agentId">代理商</param>
        /// <param name="terminalId">终端号</param>
        public void SalesInvoiceSummaryLoadGrid(int page, int rows, string startDate, string endDate, string city, string county, string siteId, string agentId, string terminalId)
        {
            string strSQL = SalesInvoiceSummarySql(startDate, endDate, city, county, siteId, agentId, terminalId);
            Param param = new Param();
            DataAccess db = new DataAccess(DataAccess.DBConn);
            int dataTotal = 0;
            try
            {
                db.Open();
                dataTotal = int.Parse(db.ExecuteScalar(CommandType.Text, "select count(*) from (" + strSQL + ")", param).ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }

            string strSqlData = "select * from ( select AP.* , rownum r from (" + strSQL + ") AP ";
            strSqlData += " where rownum <= " + Convert.ToString(page * rows) + " ) BP where r > " + Convert.ToString((page - 1) * rows);
            DataTable dt = db.ExecuteDataView(CommandType.Text, strSqlData, param).Table;
            AgentAccDetailBLL agentAccDetailBLL = new AgentAccDetailBLL(context, loginSession);
            List<TTAgentAccDetail> balanceList = agentAccDetailBLL.GetTTAgentAccDetailList(city, county, siteId, agentId, terminalId);
            foreach (DataRow dr in dt.Rows)
            {
                var balanceGroupList = balanceList.Where(c => DateTime.Parse(c.createTime.Substring(0, 10)) <= DateTime.Parse(dr["dateday"].ToString()))
                                       .OrderByDescending(x => x.createTime).GroupBy(x => x.agentId) //必须排序
                                       .Select(g => new { g, count = g.Count() })
                                       .SelectMany(t => t.g.Select(b => b)
                                       .Zip(Enumerable.Range(1, t.count), (j, i) => 
                                           new { j.balance, j.createTime, rn = i }));
                var advanceBalance = balanceGroupList.Where(c => c.rn == 1).Sum(c => c.balance);
                dr["advanceBalance"] = advanceBalance;
            }
            string str = commonDao.DataGrid(dt, dataTotal);
            WebJson.Write(context, str);
        }

        /// <summary>
        /// 返回销售统计数据报表DataTable
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="city">市</param>
        /// <param name="county">区县</param>
        /// <param name="siteId">快开厅</param>
        /// <param name="agentId">代理商</param>
        /// <param name="terminalId">终端号</param>
        /// <returns></returns>
        public DataTable SalesInvoiceSummaryReport(string startDate, string endDate, string city, string county, string siteId, string agentId, string terminalId)
        {
            string strSQL = SalesInvoiceSummarySql(startDate, endDate, city, county, siteId, agentId, terminalId);
            DataTable dt = ttLotteryOrderDAO.LotteryOrderDT(strSQL);
            return dt;
        }

        /// <summary>
        /// 获取推荐人佣金总计
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>佣金总计double</returns>
        public DataTable GetCommissionTotalSale(string startDate, string endDate, string city, string county, string siteId, string agentId, string terminalId)
        {
            string strSQL = @"select  sum(sumbetfee) totalSumbetfee,sum(commissionFee) totalCommissionFee,
                                sum(awardAmount) totalAwardAmount,sum(sumTakeCashFee) totalSumTakeCashFee,
                                sum(refundAmount) totalRefundAmount from (";
            strSQL += SalesInvoiceSummarySql(startDate, endDate, city, county, siteId, agentId, terminalId);
            strSQL += " )";
            Param param = new Param();
            DataTable  dt= ttLotteryOrderDAO.LotteryOrderSaleDT(strSQL, param);
            return dt;
        }
        /// <summary>
        /// 销售统计报表SQL
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="city">市</param>
        /// <param name="county">区县</param>
        /// <param name="siteId">快开厅</param>
        /// <param name="agentId">代理商</param>
        /// <param name="terminalId">终端号</param>
        /// <returns></returns>
        public string SalesInvoiceSummarySql(string startDate, string endDate, string city, string county, string siteId, string agentId, string terminalId)
        {
            string strSQL = @"select a.dateday,'0' as advanceBalance,nvl(b.sumBetFee,0) sumBetFee,nvl(e.commissionFee,0)commissionFee,
                              nvl(b.awardAmount,0) awardAmount,nvl(d.sumTakeCashFee,0) sumTakeCashFee,nvl(b.refundAmount,0) refundAmount from (select  to_char(to_date('" + startDate + "','yyyy-MM-dd')+rownum-1,'yyyy-MM-dd') dateday" +
                                " from dual connect by level<=to_date('" + endDate + "','yyyy-MM-dd')-to_date('" + startDate + "','yyyy-MM-dd')+1 ) a" +
                                " left join";

            //销售总额、中奖金额、退款金额
            strSQL += @" (select *  from (select sum(decode(t.orderstatus,'1',t.betfee,0)) sumBetFee,
                          sum(decode(t.awardresult,'2',t.awardmoney,0))+sum(decode(t.awardresult,'3',t.awardmoney,0)) awardAmount,
                          sum(decode(t.orderstatus,'2',t.betfee,0))+sum(decode(t.orderstatus,'3',t.betfee,0)) refundAmount,
                          substr(t.bettime,1,10) BetDate from ttlotteryorder t,
                          TBAgent a ,TBGame g where t.agentId=a.agentId and t.gameId=g.gameId";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and t.betTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and t.betTime<='" + endDate + " 23:59:59'";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and t.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and t.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(city) && string.IsNullOrEmpty(county))
                strSQL += " and a.areaId in(select areaid from tbarea start with areaid = '" + city + "'connect by prior areaid = parentid)";
            if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(county))
                strSQL += " and a.areaId='" + county + "'";
            if (!string.IsNullOrEmpty(terminalId))
                strSQL += " and t.terminalId='" + terminalId + "'";

            strSQL += @" group by substr(t.bettime,1,10) order by substr(t.bettime,1,10)) c) b
                                             on a.dateday=b.BetDate
                                             left join";
            //客户提现
            strSQL += @" (select * from(
                               select to_char(c.createTime,'yyyy-MM-dd')createDate ,sum(c.fee) sumTakeCashFee
                               from TTClientTakeCash  c,TBAgent a
                               where c.agentId=a.agentId  and c.createTime>= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss') " +
                              "and c.createTime<=To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss') ";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and c.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and c.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(city) && string.IsNullOrEmpty(county))
                strSQL += " and a.areaId in(select areaid from tbarea start with areaid = '" + city + "'connect by prior areaid = parentid)";
            if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(county))
                strSQL += " and a.areaId='" + county + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and c.createTime>= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and c.createTime<=To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";

            strSQL += @" group by to_char(c.createTime,'yyyy-MM-dd')
                               order by to_char(c.createTime,'yyyy-MM-dd'))）d 
                               on d.createDate=a.dateday 
                               left join ";
            //佣金
            strSQL += @" (select * from (select  substr(t.bettime,1,10) commissionDate,sum(a.rebate/100*t.salefee) commissionFee 
                         from (select l.bettime, l.betfee salefee,l.agentid from TTLotteryOrder l where l.bettime>='" + startDate + " 00:00:00'  " +
                         " and l.bettime<='" + endDate + " 23:59:59'  and l.orderstatus='1'  and l.settleStatus='0'";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and l.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and l.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(terminalId))
                strSQL += " and l.terminalId='" + terminalId + "'";
            strSQL += @" ) t left join TBAgent a on t.agentId=a.agentId where 1=1";
            if (!string.IsNullOrEmpty(city) && string.IsNullOrEmpty(county))
                strSQL += " and a.areaId in(select areaid from tbarea start with areaid = '"+city+"'connect by prior areaid = parentid)";
            if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(county))
                strSQL += " and a.areaId='" + county + "'";
            strSQL += @" group by substr(t.bettime,1,10))) e 
                         on e.commissionDate=a.dateday order by a.dateday desc";
            return strSQL;
        }
    }
}

