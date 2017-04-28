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
    /// 代理商充值提醒
    /// Author:代码生成器
    /// </summary>
    public class AgentRechargeNoticeBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TTAgentRechargeNoticeDAO ttAgentRechargeNoticeDAO= new TTAgentRechargeNoticeDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public AgentRechargeNoticeBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string agentId, string startDate, string endDate)
        {
            string strSQL = "select a.* from TTAgentRechargeNotice a where 1=1" ;
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and a.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and a.createTime >= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and a.createTime <= To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            strSQL += " order by a.createTime desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定代理商充值提醒
        /// <param name="flowId">流水号</param>
        /// </summary>
        public void Load(long flowId)
        {
            try
            {
                TTAgentRechargeNotice ttAgentRechargeNotice=ttAgentRechargeNoticeDAO.Get(flowId);
                WebJson.ToJson(context, ttAgentRechargeNotice);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加代理商充值提醒
        /// <param name="ttAgentRechargeNotice">代理商充值提醒</param>
        /// </summary>
        public void Add(TTAgentRechargeNotice ttAgentRechargeNotice)
        {
            try
            {
                ttAgentRechargeNoticeDAO.Add(ttAgentRechargeNotice);
                Message.success(context, "代理商充值提醒增加成功");
                loginSession.Log(ttAgentRechargeNotice.agentName+"代理商充值提醒增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理商充值提醒增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改代理商充值提醒
        /// <param name="ttAgentRechargeNotice">代理商充值提醒</param>
        /// </summary>
        public void Edit(TTAgentRechargeNotice ttAgentRechargeNotice)
        {
            try
            {
                ttAgentRechargeNoticeDAO.Edit(ttAgentRechargeNotice);
                Message.success(context, "代理商充值回复成功");
                loginSession.Log(ttAgentRechargeNotice.agentName + "代理商充值回复成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理商充值回复失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除代理商充值提醒
        /// <param name="flowId">流水号</param>
        /// </summary>
        public void Delete(long flowId)
        {
            try
            {
                ttAgentRechargeNoticeDAO.Delete(flowId);
                Message.success(context, "代理商充值提醒删除成功");
                loginSession.Log("XXXXXX代理商充值提醒删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理商充值提醒删除失败");
                loginSession.Log(e.Message);
            }
        }
    }
}

