using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Agent;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.Agent
{
    /// <summary>
    /// 代理商充值
    /// Author:代码生成器
    /// </summary>
    public class AgentRechargeBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TTAgentRechargeDAO ttAgentRechargeDAO= new TTAgentRechargeDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public AgentRechargeBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string agentId,string agentName, string startDate, string endDate)
        {
            string strSQL = "select a.*,p.modename from TTAgentRecharge a,TBPayMode p where a.handlemode=p.modeid";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and a.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(agentName))
                strSQL += " and a.agentName like '%" + agentName + "%'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and a.createTime >= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and a.createTime <= To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            strSQL += " order by agentId,createTime desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }

        /// <summary>
        /// 获取代理商充值总计
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理商充值double</returns>
        public double GetTotalFee(string agentId, string agentName, string startDate, string endDate)
        {
            double totalFee;
            string strSQL = "select sum(a.fee) from TTAgentRecharge a,TBPayMode p where a.handlemode=p.modeid";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and a.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(agentName))
                strSQL += " and a.agentName like '%" + agentName + "%'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and a.createTime >= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and a.createTime <= To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            Param param = new Param();
            totalFee = ttAgentRechargeDAO.GetTotalFee(strSQL, param);
            return totalFee;
        }

        /// <summary>
        /// 增加代理商充值
        /// <param name="ttAgentRecharge">代理商充值</param>
        /// </summary>
        public void Add(TTAgentRecharge ttAgentRecharge, TTAgentPreRechg ttAgentPreRechg, double balanceValue)
        {
            try
            {
                if (ttAgentRecharge.fee<0 && Math.Abs(ttAgentRecharge.fee) > balanceValue)
                {
                    Message.success(context, "代理商账户余额不足");
                    return;
                }
                ttAgentRechargeDAO.Add(ttAgentRecharge, ttAgentPreRechg);
                Message.success(context, "代理商充值审批成功");
                loginSession.Log(ttAgentRecharge.agentName + "代理商充值审批成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理商充值审批失败");
                loginSession.Log(e.Message);
            }
        }
        
       

       

        public DataSet GetDataSet(string agentName,string startDate,string endDate)
        {
            DataSet ds = new DataSet();
            string strSql = @"select sum(tt.fee) sumRecharge,t.agentName,t.balanceValue from ttagentrecharge tt,tbagent t where tt.agentid=t.agentid ";
            if (!string.IsNullOrEmpty(agentName))
                strSql += " and tt.agentName='" + agentName + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSql += " and tt.createTime>=to_date('"+startDate+" 00:00:00','yyyy-MM-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSql += " and tt.createTime<=to_date('" + endDate + " 23:59:59','yyyy-MM-dd hh24:mi:ss')";
            strSql+=" group by t.agentid,t.agentname,t.balancevalue";
            ds = ttAgentRechargeDAO.GetDataSet(strSql, null);
            return ds;
        }
    }
}

