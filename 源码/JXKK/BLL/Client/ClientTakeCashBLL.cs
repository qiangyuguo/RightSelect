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
    /// 客户提现
    /// Author:代码生成器
    /// </summary>
    public class ClientTakeCashBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TTClientTakeCashDAO ttClientTakeCashDAO = new TTClientTakeCashDAO();

        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public ClientTakeCashBLL(HttpContext context, ILogin loginSession)
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
                               from TTClientTakeCash  c,TBAgent a,TBSite s,TBPayMode p,TBClient bc
                               where c.agentId=a.agentId and c.siteId=s.siteId and c.handlemode=p.modeid
                               and  c.clientId=bc.clientId";
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
                strSQL += " and c.createTime<=To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            strSQL += " order by c.agentId,c.siteId,c.clientId desc,c.createTime desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }

        /// <summary>
        /// 根据条件分组获取客户提现数据
        /// </summary>
        /// <param name="startDate">投注开始时间</param>
        /// <param name="endDate">投注结束时间</param>
        /// <param name="city">市</param>
        /// <param name="county">区县</param>
        /// <param name="siteId">快开厅</param>
        /// <param name="agentId">代理商</param>
        /// <param name="terminalId">终端号</param>
        /// <returns></returns>
        public List<ClientTakeCashFee> GetClientTakeCashFeeList(string startDate, string endDate, string city, string county, string siteId, string agentId, string terminalId)
        {
            List<ClientTakeCashFee> clientTakeCashList = new List<ClientTakeCashFee>();
            string strSQL = @"select to_char(c.createTime,'yyyy-MM-dd')createDate ,sum(c.fee)sumFee
                               from TTClientTakeCash  c,TBAgent a
                               where c.agentId=a.agentId ";
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
                              order by to_char(c.createTime,'yyyy-MM-dd')";
            Param param = new Param();
            clientTakeCashList = ttClientTakeCashDAO.GetClientTakeCashFeeList(strSQL, param);
            return clientTakeCashList;
        }
        /// <summary>
        /// 获取客户提现总计
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>客户提现double</returns>
        public double GetTotalFee(string agentId, string siteId, string clientQuery, string clientQueryText, string startDate, string endDate)
        {
            double totalFee;
            string strSQL = "select sum(c.Fee) from TTClientTakeCash  c,TBClient bc,TBAgent a,TBSite s where c.agentId=a.agentId and c.siteId=s.siteId and c.clientId=bc.clientId";
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
                strSQL += " and c.createTime>=To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and c.createTime<= To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            Param param = new Param();
            totalFee = ttClientTakeCashDAO.GetTotalFee(strSQL, param);
            return totalFee;
        }
        /// <summary>
        /// 加载指定客户提现
        /// <param name="flowId">编号</param>
        /// </summary>
        public void Load(long flowId)
        {
            try
            {
                TTClientTakeCash ttClientTakeCash = ttClientTakeCashDAO.Get(flowId);
                WebJson.ToJson(context, ttClientTakeCash);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }

        public DataSet GetDataSet(string startDate, string endDate, string agentId, string clientId)
        {
            DataSet ds = new DataSet();
            string strSql = @"select c.flowid,c.clientid,c.createtime,c.fee,c.operatorname,a.agentname agentid, p.modename handlemode 
                             from TTClientTakeCash c,TBAgent a,TBPayMode p
                             where c.agentid=a.agentid and c.handlemode=p.modeid ";
            if (!string.IsNullOrEmpty(agentId))
                strSql += " and c.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(clientId))
                strSql += " and c.clientId='" + clientId + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSql += " and c.createTime>=to_date('" + startDate + " 00:00:00','yyyy-MM-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSql += " and c.createTime<=to_date('" + endDate + " 23:59:59','yyyy-MM-dd hh24:mi:ss')";
            strSql += " order by c.clientid,c.createTime";
            ds = ttClientTakeCashDAO.GetDataSet(strSql, null);
            return ds;
        }

        public List<TTClientTakeCash> GetList(string startDate, string endDate, string agentId)
        {
            string strSQL = " select * from TTClientTakeCash where agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and createTime>= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and createTime<=To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            strSQL += " order by createTime";
            Param param = new Param();
            List<TTClientTakeCash> clientTakeCashList = ttClientTakeCashDAO.GetList(strSQL, param);
            return clientTakeCashList;
        }

        /// <summary>
        /// 加载客户提现报表数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void ClientTakeCashLoadGrid(int page, int rows, string startDate, string endDate, string agentId, string clientId)
        {
            string strSQL = ClientTakeCashReportSql(startDate, endDate, agentId, clientId);
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }

        /// <summary>
        /// 返回客户提现报表DataTable
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public DataTable ClientTakeCashReport(string startDate, string endDate, string agentId, string clientId)
        {
            string strSQL = ClientTakeCashReportSql(startDate, endDate, agentId, clientId);
            DataTable dt = ttClientTakeCashDAO.ClientTakeCashDT(strSQL);
            return dt;
        }
        public string ClientTakeCashReportSql(string startDate, string endDate, string agentId, string clientId)
        {
            string strSql = @"select c.flowid,c.clientid,c.createtime,c.fee,c.operatorname,a.agentname agentid, p.modename handlemode 
                             from TTClientTakeCash c,TBAgent a,TBPayMode p
                             where c.agentid=a.agentid and c.handlemode=p.modeid ";
            if (!string.IsNullOrEmpty(agentId))
                strSql += " and c.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(clientId))
                strSql += " and c.clientId='" + clientId + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSql += " and c.createTime>=to_date('" + startDate + " 00:00:00','yyyy-MM-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSql += " and c.createTime<=to_date('" + endDate + " 23:59:59','yyyy-MM-dd hh24:mi:ss')";
            strSql += " order by c.createTime desc";
            return strSql;
        }
    }
}

