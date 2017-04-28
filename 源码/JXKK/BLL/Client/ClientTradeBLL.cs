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
    /// 客户账户交易
    /// Author:代码生成器
    /// </summary>
    public class ClientTradeBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TTClientTradeDAO ttClientTradeDAO= new TTClientTradeDAO();
        
        /// <summary>
        /// 类构造方法
        /// </summary>
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginUser">登录对象信息</param>
        public ClientTradeBLL(HttpContext context, ILogin loginSession)
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
            string strSQL = @"select c.*,a.agentName,s.siteName,t.name tradetypename
                                from TTClientTrade  c,TBAgent a,TBSite s ,TBTradeType t,TBClient bc
                                where c.agentId=a.agentId and c.siteId=s.siteId and c.tradeType=t.code
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
        /// 加载指定客户账户交易
        /// </summary>
        /// <param name="tradeId">交易流水</param>
        public void Load(string tradeId)
        {
            try
            {
                TTClientTrade ttClientTrade=ttClientTradeDAO.Get(tradeId);
                WebJson.ToJson(context, ttClientTrade);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加客户账户交易
        /// </summary>
        /// <param name="ttClientTrade">客户账户交易</param>
        public void Add(TTClientTrade ttClientTrade)
        {
            try
            {
                ttClientTradeDAO.Add(ttClientTrade);
                Message.success(context, "客户账户交易增加成功");
                loginSession.Log("XXXXXX客户账户交易增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "客户账户交易增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改客户账户交易
        /// </summary>
        /// <param name="ttClientTrade">客户账户交易</param>
        public void Edit(TTClientTrade ttClientTrade)
        {
            try
            {
                ttClientTradeDAO.Edit(ttClientTrade);
                Message.success(context, "客户账户交易修改成功");
                loginSession.Log("XXXXXX客户账户交易修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "客户账户交易修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除客户账户交易
        /// </summary>
        /// <param name="tradeId">交易流水</param>
        public void Delete(string tradeId)
        {
            try
            {
                ttClientTradeDAO.Delete(tradeId);
                Message.success(context, "客户账户交易删除成功");
                loginSession.Log("XXXXXX客户账户交易删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "客户账户交易删除失败");
                loginSession.Log(e.Message);
            }
        }
    }
}

