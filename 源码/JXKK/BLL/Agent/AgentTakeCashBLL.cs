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
    /// 代理商提现
    /// Author:代码生成器
    /// </summary>
    public class AgentTakeCashBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TTAgentTakeCashDAO ttAgentTakeCashDAO= new TTAgentTakeCashDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public AgentTakeCashBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows,string agentId,string agentName, string startDate, string endDate)
        {
            string strSQL = "select a.*,p.modename from TTAgentTakeCash a,TBPayMode p where a.handlemode=p.modeid ";
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

        ///// <summary>
        ///// 增加代理商提现
        ///// <param name="ttAgentTakeCash">代理商提现</param>
        ///// </summary>
        //public void Add(TTAgentTakeCash ttAgentTakeCash)
        //{
        //    try
        //    {
        //        TBAgentDAO tbAgentDAO = new TBAgentDAO();
        //        TBAgent tbAgent = new TBAgent();
        //        tbAgent = tbAgentDAO.Get(ttAgentTakeCash.agentId);//获取代理商信息
        //        if (tbAgent.balanceValue < ttAgentTakeCash.fee)
        //        {
        //            Message.error(context, "代理商余额不足" + ttAgentTakeCash.fee);
        //        }
        //        else
        //        {
        //            ttAgentTakeCashDAO.Add(ttAgentTakeCash, tbAgent);
        //            Message.success(context, "代理商提现增加成功");
        //            loginSession.Log(ttAgentTakeCash.agentName + "代理商提现增加成功");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Message.error(context, "代理商提现增加失败");
        //        loginSession.Log(e.Message);
        //    }
        //}
        
    }
}

