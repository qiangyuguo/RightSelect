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
    /// 代理商充值预审
    /// Author:代码生成器
    /// </summary>
    public class AgentPreRechgBLL
    {
        private HttpContext context;//HTTP请求上下文
        private LoginUser loginUser;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TTAgentPreRechgDAO ttAgentPreRechgDAO= new TTAgentPreRechgDAO();
        
        /// <summary>
        /// 类构造方法
        /// </summary>
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginUser">登录对象信息</param>
        public AgentPreRechgBLL(HttpContext context, LoginUser loginUser)
        {
            this.context = context;
            this.loginUser = loginUser;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// </summary>
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        public void LoadGrid(int page, int rows, string agentId, string auditStatus, string startDate, string endDate)
        {
            string strSQL = "select * from TTAgentPreRechg where 1=1 "  ;
            if(!string.IsNullOrEmpty(agentId))
                strSQL += " and agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(auditStatus))
                strSQL += " and auditStatus='" + auditStatus + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and createtime>=to_date('" + startDate + " 00:00:00','yyyy-MM-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and createtime<=to_date('" + endDate + " 23:59:59','yyyy-MM-dd hh24:mi:ss')";
            strSQL += " order by auditStatus asc, createtime desc";
                    
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定代理商充值预审
        /// </summary>
        /// <param name="flowId">流水号</param>
        public void Load(long flowId)
        {
            try
            {
                TTAgentPreRechg ttAgentPreRechg=ttAgentPreRechgDAO.Get(flowId);
                WebJson.ToJson(context, ttAgentPreRechg);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }

        /// <summary>
        /// 获取指定代理商充值预审信息
        /// <param name="flowId">流水号</param>
        /// </summary>
        public TTAgentPreRechg Get(long flowId)
        {
            TTAgentPreRechg tbAgentPreRechg = new TTAgentPreRechg();
            try
            {
                tbAgentPreRechg = ttAgentPreRechgDAO.Get(flowId);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
            return tbAgentPreRechg;
        }
        /// <summary>
        /// 增加代理商充值预审
        /// </summary>
        /// <param name="ttAgentPreRechg">代理商充值预审</param>
        public void Add(TTAgentPreRechg ttAgentPreRechg)
        {
            try
            {
                ttAgentPreRechgDAO.Add(ttAgentPreRechg);
                Message.success(context, "代理商充值预审增加成功");
                loginUser.Log(ttAgentPreRechg.agentName+"代理商充值预审增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理商充值预审增加失败");
                loginUser.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改代理商充值预审
        /// </summary>
        /// <param name="ttAgentPreRechg">代理商充值预审</param>
        public void Edit(TTAgentPreRechg ttAgentPreRechg)
        {
            try
            {
                ttAgentPreRechgDAO.Edit(ttAgentPreRechg);
                Message.success(context, "审批成功");
                loginUser.Log(ttAgentPreRechg.agentName+"代理商充值预审成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理商充值预审修改失败");
                loginUser.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除代理商充值预审
        /// </summary>
        /// <param name="flowId">流水号</param>
        public void Delete(long flowId)
        {
            try
            {
                ttAgentPreRechgDAO.Delete(flowId);
                Message.success(context, "代理商充值预审删除成功");
                loginUser.Log("XXXXXX代理商充值预审删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理商充值预审删除失败");
                loginUser.Log(e.Message);
            }
        }
    }
}

