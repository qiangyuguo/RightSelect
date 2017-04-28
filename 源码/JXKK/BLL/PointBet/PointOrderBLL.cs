using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.PointBet;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.PointBet
{
    /// <summary>
    /// 积分投注
    /// Author:代码生成器
    /// </summary>
    public class PointOrderBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TTPointOrderDAO ttPointOrderDAO= new TTPointOrderDAO();
        
        /// <summary>
        /// 类构造方法
        /// </summary>
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginUser">登录对象信息</param>
        public PointOrderBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// </summary>
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        public void LoadGrid(int page, int rows, string agentId, string siteId, string orderId, string period, string orderStatus,string srcType, string awardResult, string clientQuery, string clientQueryText, string startDate, string endDate)
        {
            string strSQL = @"select t.*,g.gamename
                                from ttpointorder t,tbgame g,TBClient bc
                                where t.gameid=g.gameid 
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
            if (!string.IsNullOrEmpty(srcType))
                strSQL += " and t.srcType='" + srcType + "'";
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
                strSQL += " and t.betTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and t.betTime<='" + endDate + " 23:59:59'";
            strSQL += " order by betTime desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定积分投注
        /// </summary>
        /// <param name="orderId">订单号</param>
        public void Load(string orderId)
        {
            try
            {
                TTPointOrder ttPointOrder=ttPointOrderDAO.Get(orderId);
                WebJson.ToJson(context, ttPointOrder);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加积分投注
        /// </summary>
        /// <param name="ttPointOrder">积分投注</param>
        public void Add(TTPointOrder ttPointOrder)
        {
            try
            {
                ttPointOrderDAO.Add(ttPointOrder);
                Message.success(context, "积分投注增加成功");
                loginSession.Log("XXXXXX积分投注增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "积分投注增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改积分投注
        /// </summary>
        /// <param name="ttPointOrder">积分投注</param>
        public void Edit(TTPointOrder ttPointOrder)
        {
            try
            {
                ttPointOrderDAO.Edit(ttPointOrder);
                Message.success(context, "积分投注修改成功");
                loginSession.Log("XXXXXX积分投注修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "积分投注修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除积分投注
        /// </summary>
        /// <param name="orderId">订单号</param>
        public void Delete(string orderId)
        {
            try
            {
                ttPointOrderDAO.Delete(orderId);
                Message.success(context, "积分投注删除成功");
                loginSession.Log("XXXXXX积分投注删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "积分投注删除失败");
                loginSession.Log(e.Message);
            }
        }
    }
}

