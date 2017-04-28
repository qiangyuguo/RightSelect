using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Lottery;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.Lottery
{
    /// <summary>
    /// 追号订单
    /// Author:代码生成器
    /// </summary>
    public class ChaseOrderBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TTChaseOrderDAO ttChaseOrderDAO= new TTChaseOrderDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public ChaseOrderBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string agentId, string siteId, string chaseOrderId,string period, string srcType,string chaseStatus, string clientQuery, string clientQueryText, string startDate, string endDate)
        {
            string strSQL = @"select c.*,g.gamename ,l.lotterytypename 
                                from TTChaseOrder c,Tbgame g,Tblottery l
                                 where c.gameid=g.gameid
                                 and c.lotterytype=l.lotterytype ";
            if (!string.IsNullOrEmpty(chaseOrderId))
                strSQL += " and c.chaseOrderId like '%" + chaseOrderId + "%'";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and c.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and c.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(period))
                strSQL += " and c.period='" + period + "'";
            if (!string.IsNullOrEmpty(chaseStatus))
                strSQL += " and c.chaseStatus='" + chaseStatus + "'";
            if(!string.IsNullOrEmpty(srcType))
                strSQL += " and c.srcType='" + srcType + "'";
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
             if (!string.IsNullOrEmpty(startDate))
                 strSQL += " and c.chaseTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and c.chaseTime<='" + endDate + " 23:59:59'";
            strSQL += " order by chaseTime desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定追号订单
        /// <param name="chaseOrderId">追号订单号</param>
        /// </summary>
        public void Load(string chaseOrderId)
        {
            try
            {
                TTChaseOrder ttChaseOrder=ttChaseOrderDAO.Get(chaseOrderId);
                WebJson.ToJson(context, ttChaseOrder);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        /// <summary>
        /// 获取快开厅信息
        /// <param name="siteId">快开厅编号</param>
        /// </summary>
        /// <returns>快开厅信息对象</returns>
        public TTChaseOrder Get(string chaseOrderId)
        {
            TTChaseOrder ttChaseOrder = new TTChaseOrder();
            try
            {
                ttChaseOrder = ttChaseOrderDAO.Get(chaseOrderId);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
            return ttChaseOrder;
        }
        
    }
}

