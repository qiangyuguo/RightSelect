using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Client;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.Client
{
    /// <summary>
    /// 客户充值
    /// Author:代码生成器
    /// </summary>
    public class ClientRechargeBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TTClientRechargeDAO ttClientRechargeDAO= new TTClientRechargeDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public ClientRechargeBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string agentId, string siteId, string clientQuery, string clientQueryText, string startDate, string endDate)
        {
            string strSQL = @"select c.*,a.agentName,s.siteName,p.modename 
                                from TTClientRecharge  c,TBAgent a,TBSite s ,TBPayMode p,TBClient bc
                                where c.agentId=a.agentId and c.siteId=s.siteId and c.handlemode=p.modeid
                                and  c.clientId=bc.clientId ";
            if (!string.IsNullOrEmpty(clientQueryText) && !string.IsNullOrEmpty(clientQuery))
            {
                if (clientQuery == ((int)ClientQuery.CardId).ToString())
                    strSQL += " and c.cardId='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClientId).ToString())
                    strSQL += " and c.clientId='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClientName).ToString())
                    strSQL += " and c.clientName='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClinetPhone).ToString())
                    strSQL += " and bc.telephone='" + clientQueryText + "'";
            }
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and c.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and c.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and c.createTime>= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and c.createTime<= To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            strSQL += " order by c.agentId,c.siteId,c.clientId desc,c.createTime desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        /// <summary>
        /// 获取客户充值总计
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>客户充值double</returns>
        public double GetTotalFee(string agentId, string siteId, string clientQuery, string clientQueryText, string startDate, string endDate)
        {
            double totalFee;
            string strSQL = "select sum(c.fee) from TTClientRecharge  c,TBClient bc,TBAgent a,TBSite s where c.agentId=a.agentId and c.siteId=s.siteId and c.clientId=bc.clientId";
            if (!string.IsNullOrEmpty(clientQueryText) && !string.IsNullOrEmpty(clientQuery))
            {
                if (clientQuery == ((int)ClientQuery.CardId).ToString())
                    strSQL += " and c.cardId='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClientId).ToString())
                    strSQL += " and c.clientId='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClientName).ToString())
                    strSQL += " and c.clientName='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClinetPhone).ToString())
                    strSQL += " and bc.telephone='" + clientQueryText + "'";
            }
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and c.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and c.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and c.createTime>= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and c.createTime<= To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            Param param = new Param();
            totalFee = ttClientRechargeDAO.GetTotalFee(strSQL, param);
            return totalFee;
        }
        /// <summary>
        /// 加载指定客户充值
        /// <param name="flowId">编号</param>
        /// </summary>
        public void Load(long flowId)
        {
            try
            {
                TTClientRecharge ttClientRecharge=ttClientRechargeDAO.Get(flowId);
                WebJson.ToJson(context, ttClientRecharge);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }

        public List<TTClientRecharge> GetList(string startDate, string endDate, string agentId)
        {
            string strSQL = " select * from TTClientRecharge where agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and createTime>= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and createTime<=To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            strSQL += " order by createTime";
            Param param = new Param();
            List<TTClientRecharge> clientRechargeList = ttClientRechargeDAO.GetList(strSQL, param);
            return clientRechargeList;
        }
    }
}

