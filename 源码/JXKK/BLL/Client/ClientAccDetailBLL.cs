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
    /// 客户账户明细
    /// Author:代码生成器
    /// </summary>
    public class ClientAccDetailBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TTClientAccDetailDAO ttClientAccDetailDAO= new TTClientAccDetailDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public ClientAccDetailBLL(HttpContext context, ILogin loginSession)
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
            string strSQL = "select c.*,a.agentName,s.siteName from TTClientAccDetail c,TBClient bc,TBAgent a,TBSite s where c.agentId=a.agentId and c.siteId=s.siteId and c.clientId=bc.clientId ";
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
                strSQL += " and c.changeTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and c.changeTime<= '" + endDate + " 23:59:59'";
            strSQL += " order by c.agentid ,c.siteId,c.clientId desc,c.createTime desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }

        public void LoadGridCopy(int page, int rows, string agentId, string siteId, string clientQuery, string clientQueryText, string startDate, string endDate, string allstate)
        {
            string strSQL = "select c.*,a.agentName,s.siteName from TTClientAccDetail c,TBClient bc,TBAgent a,TBSite s where c.agentId=a.agentId and c.siteId=s.siteId and c.clientId=bc.clientId ";
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
            if (!string.IsNullOrEmpty(allstate))
                strSQL += " and c.srcMode='" + allstate + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and c.changeTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and c.changeTime<= '" + endDate + " 23:59:59'";
            strSQL += " order by c.agentid ,c.siteId,c.clientId desc,c.createTime desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }

        /// <summary>
        /// 加载指定客户账户明细
        /// <param name="flowId">编号</param>
        /// </summary>
        public void Load(long flowId)
        {
            try
            {
                TTClientAccDetail ttClientAccDetail=ttClientAccDetailDAO.Get(flowId);
                WebJson.ToJson(context, ttClientAccDetail);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加客户账户明细
        /// <param name="ttClientAccDetail">客户账户明细</param>
        /// </summary>
        public void Add(TTClientAccDetail ttClientAccDetail)
        {
            try
            {
                ttClientAccDetailDAO.Add(ttClientAccDetail);
                Message.success(context, "客户账户明细增加成功");
                loginSession.Log("XXXXXX客户账户明细增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "客户账户明细增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改客户账户明细
        /// <param name="ttClientAccDetail">客户账户明细</param>
        /// </summary>
        public void Edit(TTClientAccDetail ttClientAccDetail)
        {
            try
            {
                ttClientAccDetailDAO.Edit(ttClientAccDetail);
                Message.success(context, "客户账户明细修改成功");
                loginSession.Log("XXXXXX客户账户明细修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "客户账户明细修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除客户账户明细
        /// <param name="flowId">编号</param>
        /// </summary>
        public void Delete(long flowId)
        {
            try
            {
                ttClientAccDetailDAO.Delete(flowId);
                Message.success(context, "客户账户明细删除成功");
                loginSession.Log("XXXXXX客户账户明细删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "客户账户明细删除失败");
                loginSession.Log(e.Message);
            }
        }
    }
}

