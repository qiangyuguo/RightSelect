using Com.Data;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Client;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Com.ZY.JXKK.BLL.Client
{
    public class ClientTakeCashToBankBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TTClientTakeCashDAO ttClientTakeCashDAO = new TTClientTakeCashDAO();
        public ClientTakeCashToBankBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }

        /// <summary>
        /// 加载GRID
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="agentId"></param>
        /// <param name="siteId"></param>
        /// <param name="clientQuery"></param>
        /// <param name="clientQueryText"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void LoadGrid(int page, int rows, string agentId, string siteId, string clientQuery, string clientQueryText, string startDate, string endDate)
        {

            //客户编号，客户名称，代理商编号，代理商名称，卡号，银行卡号，提现用户名 ， 提现金额， 提现时间，发生时间，备注
            string strSql = @"select t.flowId, t.ClientId,c.clientname,AgentName,t.CardId,t.CardNo as cardno,t.UserName as username,t.telphoneno as telphoneno,t.Fee,withDrawTime,t.createtime,t.withDrawState,t.remark from TTClientAccDetail t inner join tbagent a on t.agentid=a.agentid
inner join tbclient c on t.clientid=c.clientid where t.SRCMODE in (7,8,9,10)";
            if (!string.IsNullOrEmpty(clientQueryText) && !string.IsNullOrEmpty(clientQuery))
            {
                if (clientQuery == ((int)ClientQuery.CardId).ToString())
                    strSql += " and c.cardId='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClientId).ToString())
                    strSql += " and c.clientId='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClientName).ToString())
                    strSql += " and c.clientName='" + clientQueryText + "'";
                if (clientQuery == ((int)ClientQuery.ClinetPhone).ToString())
                    strSql += " and c.telephone='" + clientQueryText + "'";
            }
            if (!string.IsNullOrEmpty(agentId))
                strSql += " and c.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSql += " and c.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSql += " and c.createTime>= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSql += " and c.createTime<=To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            strSql += " order by c.agentId,c.siteId,c.clientId desc,c.createTime desc";
            string str = commonDao.DataGrid(strSql, null, page, rows);
            WebJson.Write(context, str);
        }

        public void TakeCash(string flowid,string withdrawperson)
        {
            Param Param = new Param();
            Param.Add(":flowid", flowid);
            string sqlStr = string.Format("update TTClientAccDetail set withDrawState=1,withdrawtime=sysdate,withdrawperson='{0}' where flowid=@flowid", withdrawperson);
            WebJson.Write(context, ttClientTakeCashDAO.TakeCash(sqlStr, Param).ToString());
        }
    }
}
