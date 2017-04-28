using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Client;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DAO.Agent;

namespace Com.ZY.JXKK.BLL.Client
{
    /// <summary>
    /// 客户信息
    /// Author:代码生成器
    /// </summary>
    public class ClientBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBClientDAO tbClientDAO= new TBClientDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public ClientBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string agentId, string siteId, string clientQuery, string clientQueryText,string status, string startDate, string endDate)
        {
            string strSQL = "select c.*,a.agentName,s.siteName from TBClient c,TBAgent a,TBSite s where c.agentId=a.agentId and c.siteId=s.siteId";
            if (!string.IsNullOrEmpty(clientQueryText) && !string.IsNullOrEmpty(clientQuery))
            {
                if (clientQuery==((int)ClientQuery.CardId).ToString())
                    strSQL += " and c.cardId='" + clientQueryText + "'";
                if (clientQuery==((int)ClientQuery.ClientId).ToString())
                    strSQL += " and c.clientId='" + clientQueryText + "'";
                if (clientQuery==((int)ClientQuery.ClientName).ToString())
                    strSQL += " and c.clientName='" + clientQueryText + "'";
                if (clientQuery==((int)ClientQuery.ClinetPhone).ToString())
                    strSQL += " and c.telephone='" + clientQueryText + "'";
            }
            if(!string.IsNullOrEmpty(agentId))
                strSQL += " and c.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and c.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(status))
                strSQL += " and c.status='" + status + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and c.createTime>= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and c.createTime<= To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            strSQL += " order by c.agentId,c.siteId,c.clientId desc,c.createTime desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }



        /// <summary>
        /// 加载DataGrid
        /// <param name="type">1 账户余额 2 积分</param>
        /// </summary>
        public double GetTotalBalanceOrPoints(int type, string agentId, string siteId, string clientQuery, string clientQueryText, string status, string startDate, string endDate)
        {
            double totalVlaue;
            string strSQL = "";
            if (type == 1)
                strSQL += " select sum(c.balance) from ";
            if (type == 2)
                strSQL += " select sum(c.points) from ";
            strSQL += " TBClient c,TBAgent a,TBSite s where c.agentId=a.agentId and c.siteId=s.siteId";
            if (!string.IsNullOrEmpty(clientQueryText) && !string.IsNullOrEmpty(clientQuery))
            {
                if (clientQuery == ((int)ClientQuery.CardId).ToString())
                    strSQL += " and c.cardId='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClientId).ToString())
                    strSQL += " and c.clientId='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClientName).ToString())
                    strSQL += " and c.clientName='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClinetPhone).ToString())
                    strSQL += " and c.telephone='" + clientQueryText + "'";
            }
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and c.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and c.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(status))
                strSQL += " and c.status='" + status + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and c.createTime>= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and c.createTime<= To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            Param param = new Param();
            totalVlaue = tbClientDAO.GetTotalValue(strSQL, param);
            return totalVlaue;
        }

        /// <summary>
        /// 推荐人佣金
        /// </summary>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="clientQuery">0 客户编号 1 客户卡号</param>
        /// <param name="clientId">条件</param>
        public void RefererCommiss(string startDate, string endDate, string clientId)
        {
             string str="";
            if (string.IsNullOrEmpty(clientId))
            {
                Message.success(context, "客户卡号或客户编号不能为空!");
            }
            else
            {
                string strSQL = @" select tc.clientid, tc.cardId,tc.clientName,b.salefee,b.commissfee,b.startdate,b.endDate,tc.refererrebate,substr(tc.referervaliddate,1,10) referervaliddate  " +
                               " from (select l.clientid, sum(l.betfee) salefee, sum(l.betfee*(c.refererrebate/100)) commissfee,'" + startDate + "' startDate,'" + endDate + "' endDate from TTLOTTERYORDER l " +
                               " inner join (select t.clientid,t.refererrebate,t.referervaliddate from TBClient t where t.refererclientid='" + clientId + "') c " +
                               " on l.clientid=c.clientid "+
                               " where l.bettime>='" + startDate + " 00:00:00' " +
                               " and l.bettime<='" + endDate + " 23:59:59' "+ 
                               " and l.orderstatus='" + (int)OrderStatus.Ticket + "'" +
                               " and l.bettime<=c.referervaliddate "+
                               " group by l.clientid) b "+
                               " left join TBClient tc on  b.clientId=tc.clientId "+
                               " order by tc.createtime desc";
                str = commonDao.DataGrid(strSQL, null);
                WebJson.Write(context, str);
            }
        }

         /// <summary>
        /// 获取推荐人佣金总计
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>佣金总计double</returns>
        public double GetTotalCommiss(string startDate, string endDate, string clientId)
        {
            double totalCommiss= 0;
            string strSQL = @"select sum(l.betfee*(c.refererrebate/100)) from TTLOTTERYORDER l" +
                                 " inner join (select t.clientid,t.refererrebate,t.referervaliddate from TBClient t where t.refererclientid='" + clientId + "') c" +
                                 " on l.clientid=c.clientid" +
                                 " where l.bettime>='" + startDate + " 00:00:00' " +
                                 " and l.bettime<='" + endDate + " 23:59:59' " +
                                 " and l.orderstatus='" + (int)OrderStatus.Ticket + "'" +
                                 " and l.bettime<=c.referervaliddate";
            Param param = new Param();
            totalCommiss = tbClientDAO.GetTotalCommiss(strSQL, param);
            return totalCommiss;
        }
        /// <summary>
        /// 根据卡号获取客户信息
        /// <param name="cardId">客户卡号</param>
        /// </summary>
        /// <returns>客户信息对象</returns>
        public TBClient GetByCard(long cardId)
        {
            TBClient tbClient = null;
            tbClient=tbClientDAO.GetByCard(cardId);
            return tbClient;
        }
        /// <summary>
        /// 加载指定客户信息
        /// <param name="clientId">客户编号</param>
        /// </summary>
        public void Load(long clientId)
        {
            try
            {
                TBClient tbClient=tbClientDAO.Get(clientId);
                WebJson.ToJson(context, tbClient);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加客户信息
        /// <param name="tbClient">客户信息</param>
        /// </summary>
        public void Add(TBClient tbClient)
        {
            try
            {
                tbClientDAO.Add(tbClient);
                Message.success(context, "客户信息增加成功");
                loginSession.Log("XXXXXX客户信息增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "客户信息增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改客户信息
        /// <param name="tbClient">客户信息</param>
        /// </summary>
        public void Edit(TBClient tbClient)
        {
            try
            {
                tbClientDAO.Edit(tbClient);
                Message.success(context, "客户信息修改成功");
                loginSession.Log("XXXXXX客户信息修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "客户信息修改失败");
                loginSession.Log(e.Message);
            }
        }
        
       

         /// <summary>
        /// 获取DataSet(交易数据)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>交易数据DataSet</returns>
        public DataSet GetClientDataSet(string startDate, string endDate, string siteId,string status)
        {
            string strSQL = "select c.*,a.agentName,s.siteName from TBClient c,TBAgent a,TBSite s where c.agentId=a.agentId and c.siteId=s.siteId";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and c.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(status))
                strSQL += " and c.status='" + status + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and c.createTime>= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and c.createTime<= To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            strSQL += " order by c.agentId,c.siteId,c.clientId desc,c.createTime desc";
            Param param = new Param();
            return tbClientDAO.GetDataSet(strSQL, param);
        }

        /// <summary>
        /// 加载客户信息报表数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void ClientLoadGrid(int page, int rows, string startDate, string endDate, string agentId,string siteId, string status)
        {
            string strSQL = ClientReportSql(startDate, endDate,agentId, siteId, status);
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }

        /// <summary>
        /// 返回客户信息报表DataTable
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public DataTable ClientReport(string startDate, string endDate, string agentId, string siteId, string status)
        {
            string strSQL = ClientReportSql(startDate, endDate,agentId, siteId, status);
            DataTable dt = tbClientDAO.ClientDT(strSQL);
            return dt;
        }
        public string ClientReportSql(string startDate, string endDate,string agentId, string siteId, string status)
        {
            string strSQL = "select c.*,a.agentName,s.siteName from TBClient c,TBAgent a,TBSite s where c.agentId=a.agentId and c.siteId=s.siteId";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and c.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and c.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(status))
                strSQL += " and c.status='" + status + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and c.createTime>= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and c.createTime<= To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            strSQL += " order by c.agentId,c.siteId,c.clientId desc,c.createTime desc";
            return strSQL;
        }
    }
}

