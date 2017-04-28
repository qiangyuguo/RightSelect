using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Agent;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.BLL.Agent
{
    /// <summary>
    /// 代理佣金结算
    /// Author:代码生成器
    /// </summary>
    public class AgentSettlementBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TTAgentSettlementDAO ttAgentSettlementDAO = new TTAgentSettlementDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public AgentSettlementBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
         
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows,string agentId,string agentName,string payStatus,string startDate,string endDate)
        {
            string strSQL = @"select flowid,  agentid, agentname, startdate, enddate, salefee, rebate,  commissionfee,  paystatus, 
                               modeid,  settlementtime,  settlementid, settlementname, cashierid, cashiername,
                               case when payStatus='0' then '' else to_char(paytime,'yyyy-mm-dd hh24:mi:ss') end paytime
                               from TTAGENTSETTLEMENT t   where 1=1";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and agentId='"+agentId+"'";
            if (!string.IsNullOrEmpty(agentName))
                strSQL += " and agentName like '%" + agentName + "%'";
            if (!string.IsNullOrEmpty(payStatus))
                strSQL += " and payStatus='" + payStatus + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and settlementTime>=to_date('" + startDate + " 00:00:00','yyyy-MM-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and settlementTime<=to_date('" + endDate + " 23:59:59','yyyy-MM-dd hh24:mi:ss')";
            strSQL += " order by settlementTime desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }

        /// <summary>
        /// 根据日期获取分组每一天的佣金
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public List<Commission> GetCommissionList(string startDate, string endDate, string city, string county, string siteId, string agentId, string terminalId)
        {
            List<Commission> commissionList = null;
                string strSQL = @"select  substr(t.bettime,1,10) commissionDate,sum(a.rebate/100*t.salefee) commissionFee  " +
                            " from (select l.bettime, l.betfee salefee,l.agentid from TTLotteryOrder l" +
                                " where l.bettime>='" + startDate + " 00:00:00' " +
                                " and l.bettime<='" + endDate + " 23:59:59' " +
                                " and l.orderstatus='" + (int)OrderStatus.Ticket + "' " +
                                " and l.settleStatus='0'";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and l.agentId=" + agentId + "";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and l.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(terminalId))
                strSQL += " and l.terminalId='" + terminalId + "'";
            strSQL += " ) t left join TBAgent a on t.agentId=a.agentId where 1=1";
            if (!string.IsNullOrEmpty(city) && string.IsNullOrEmpty(county))
                strSQL += " and a.areaId in(select areaid from tbarea start with areaid = '" + city + "'connect by prior areaid = parentid)";
            if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(county))
                strSQL += " and a.areaId='" + county + "'";
            strSQL += " group by substr(t.bettime,1,10)";
            Param param = new Param();
            commissionList = ttAgentSettlementDAO.GetCommissionList(strSQL, param);
            return commissionList;
        }
        /// <summary>
        /// 加载佣金DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void CommissionLoadGrid(int page, int rows,string startDate,string endDate)
        {
            string strSQL = @"select t.agentId,a.agentname ,'" + startDate + "' startDate,'" + endDate + "' endDate,t.salefee,a.rebate,a.rebate/100*t.salefee commissionFee" +
                            " from (select sum(l.betfee) salefee,l.agentid from TTLotteryOrder l" +
                                " where l.bettime>='" + startDate + " 00:00:00' " +
                                " and l.bettime<='" + endDate + " 23:59:59' " +
                                " and l.orderstatus='" + (int)OrderStatus.Ticket + "' " +
                                " and l.settleStatus='0'" +
                                " group by agentId) t " +
                                " left join TBAgent a" +
                                " on t.agentId=a.agentId ";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        /// <summary>
        /// 加载指定代理佣金结算
        /// <param name="flowId">结算流水号</param>
        /// </summary>
        public void Load(long flowId)
        {
            try
            {
                TTAgentSettlement ttAgentSettlement=ttAgentSettlementDAO.Get(flowId);
                WebJson.ToJson(context, ttAgentSettlement);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }


        public List<TTAgentSettlement> GetAgentSettlmentList(string startDate, string endDate)
        {
            List<TTAgentSettlement> agentSettlmentList = new List<TTAgentSettlement>();
            string strSQL = @"select t.agentId,a.agentname ,'"+startDate+"' startDate,'"+endDate+"' endDate,t.salefee,a.rebate,a.rebate/100*t.salefee commissionFee"+ 
                            " from (select sum(l.betfee) salefee,l.agentid from TTLotteryOrder l"+
                                " where l.bettime>='" + startDate + " 00:00:00' " +
                                " and l.bettime<='" + endDate + " 23:59:59' " +
                                " and l.orderstatus='"+(int)OrderStatus.Ticket+"' "+
                                " and l.settleStatus='0'"+
                                " group by agentId) t "+
                                " left join TBAgent a" +
                                " on t.agentId=a.agentId ";
            Param param = new Param();
            agentSettlmentList = ttAgentSettlementDAO.GetAgentSettlementList(strSQL, param);
            return agentSettlmentList;
        }
        /// <summary>
        /// 增加代理佣金结算
        /// <param name="ttAgentSettlement">代理佣金结算</param>
        /// </summary>
        public void AddList(List<TTAgentSettlement> agentSettlementList, string startDate, string endDate, string userId, string userName)
        {
            try
            {
                ttAgentSettlementDAO.AddList(agentSettlementList, startDate, endDate, userId, userName);
                Message.success(context, "代理佣金结算成功");
                loginSession.Log("代理佣金结算成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理佣金结算失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改代理佣金结算
        /// <param name="ttAgentSettlement">代理佣金结算</param>
        /// </summary>
        public void Edit(TTAgentSettlement ttAgentSettlement)
        {
            try
            {
                ttAgentSettlementDAO.Edit(ttAgentSettlement);
                Message.success(context, "代理佣金支付成功");
                loginSession.Log(ttAgentSettlement.agentName + "代理佣金支付成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理佣金支付失败");
                loginSession.Log(e.Message);
            }
        }

        
    }
}

