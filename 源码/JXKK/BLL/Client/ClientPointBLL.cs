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
    /// 客户积分明细
    /// Author:代码生成器
    /// </summary>
    public class ClientPointBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TTClientPointDAO ttClientPointDAO= new TTClientPointDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public ClientPointBLL(HttpContext context, ILogin loginSession)
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
            string strSQL = @"select c.*,a.agentName,s.siteName from TTClientPoint c,TBClient bc,TBAgent a,TBSite s 
            where c.agentId=a.agentId and c.siteId=s.siteId and c.clientId=bc.clientId";
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
            strSQL += " order by c.agentId,c.siteId,c.clientId desc,c.createTime desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="agentId"></param>
        /// <param name="siteId"></param>
        /// <param name="clientQuery"></param>
        /// <param name="clientQueryText"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void LoadGridCopy(int page, int rows, string agentId, string siteId, string clientQuery, string clientQueryText, string startDate, string endDate,string sroState)
        {
            string strSQL = @"select c.*,a.agentName,s.siteName from TTClientPoint c,TBClient bc,TBAgent a,TBSite s 
            where c.agentId=a.agentId and c.siteId=s.siteId and c.clientId=bc.clientId";
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
            if (!string.IsNullOrEmpty(sroState))
                strSQL += " and  c.gameId='" + sroState + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and c.changeTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and c.changeTime<= '" + endDate + " 23:59:59'";
            strSQL += " order by c.agentId,c.siteId,c.clientId desc,c.createTime desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }



        /// <summary>
        /// 加载指定客户积分明细
        /// <param name="flowId">编号</param>
        /// </summary>
        public void Load(long flowId)
        {
            try
            {
                TTClientPoint ttClientPoint=ttClientPointDAO.Get(flowId);
                WebJson.ToJson(context, ttClientPoint);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }


        /// <summary>
        /// 终端号对应的游戏积分消耗
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="agentId"></param>
        /// <param name="terminalId"></param>
        /// <returns></returns>
        public List<TTClientPoint> GetList(string startDate, string endDate, string agentId)
        {
            string strSQL = @"select * from TTClientPoint c where c.point<0 and  agentId=" + agentId + "";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and changetime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and changetime<='" + endDate + " 23:59:59'";
            strSQL += " order by  changetime desc";
            Param param = new Param();
            List<TTClientPoint> clientPointList = ttClientPointDAO.GetList(strSQL, param);
            return clientPointList;

        }

        /// <summary>
        /// 终端号对应的游戏积分消耗
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="agentId"></param>
        /// <param name="terminalId"></param>
        /// <returns></returns>
        public List<TTClientPoint> GetList(string startDate, string endDate, string agentId, string terminalId)
        {
            string strSQL = @"select flowid,  cardid, clientid,  clientname, agentid, siteid,  lastpoint,  point, 
                               remainingpoint,  substr(changetime,1,10) changetime,description,  createtime, 
                               srcmode, srcflowid, operatorid, operatorname, g.gamename gameid,  terminalid
                               from TTClientPoint c,TBGame g
                               where c.gameid=g.gameid and g.typecode=1 and srcmode=5
                               and  agentId=" + agentId + "";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and changetime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and changetime<='" + endDate + " 23:59:59'";
            if (!string.IsNullOrEmpty(terminalId))
                strSQL += " and terminalid='" + terminalId + "'";
            strSQL += " order by  changetime desc";
            Param param = new Param();
            List<TTClientPoint> clientPointList = ttClientPointDAO.GetList(strSQL, param);
            return clientPointList;

        }
    }
}

