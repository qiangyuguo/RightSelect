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
    /// 代理商提现申请
    /// Author:代码生成器
    /// </summary>
    public class AgentTakeCashApplyBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TTAgentTakeCashApplyDAO ttAgentTakeCashApplyDAO= new TTAgentTakeCashApplyDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public AgentTakeCashApplyBLL(HttpContext context, ILogin loginSession)
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
            string strSQL = "select a.* from TTAgentTakeCashApply a where 1=1";
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
        /// 加载指定代理商提现申请
        /// <param name="flowId">编号</param>
        /// </summary>
        public void Load(long flowId)
        {
            try
            {
                TTAgentTakeCashApply ttAgentTakeCashApply=ttAgentTakeCashApplyDAO.Get(flowId);
                WebJson.ToJson(context, ttAgentTakeCashApply);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加代理商提现申请
        /// <param name="ttAgentTakeCashApply">代理商提现申请</param>
        /// </summary>
        public void Add(TTAgentTakeCashApply ttAgentTakeCashApply, double balanceValue)
        {
            try
            {
                if (ttAgentTakeCashApply.fee > balanceValue)
                {
                    Message.success(context, "当前余额不足:" + ttAgentTakeCashApply.fee);
                }
                else
                {
                    ttAgentTakeCashApplyDAO.Add(ttAgentTakeCashApply);
                    Message.success(context, "提现申请增加成功");
                    loginSession.Log(ttAgentTakeCashApply.agentName + "提现申请增加成功");
                }
            }
            catch (Exception e)
            {
                Message.error(context, "提现申请增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改代理商提现申请
        /// <param name="ttAgentTakeCashApply">代理商提现申请</param>
        /// </summary>
        public void Edit(TTAgentTakeCashApply ttAgentTakeCashApply,TTAgentTakeCash ttAgentTakeCash)
        {
            try
            {
                TBAgentDAO tbAgentDAO = new TBAgentDAO();
                TBAgent tbAgent = new TBAgent();
                tbAgent = tbAgentDAO.Get(ttAgentTakeCash.agentId);//获取代理商信息
                if (tbAgent.balanceValue < ttAgentTakeCash.fee && ttAgentTakeCashApply.dealWithStatus==((int)DealWithStatus.HaveToDo).ToString())
                {
                    Message.error(context, "代理商余额不足" + ttAgentTakeCash.fee);
                }
                else
                {
                    ttAgentTakeCashApplyDAO.Edit(ttAgentTakeCashApply, ttAgentTakeCash, tbAgent);
                    Message.success(context, "提现申请修改成功");
                    loginSession.Log("提现申请修改成功");
                }
            }
            catch (Exception e)
            {
                Message.error(context, "代理商提现申请修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除代理商提现申请
        /// <param name="flowId">编号</param>
        /// </summary>
        public void Delete(long flowId)
        {
            try
            {
                ttAgentTakeCashApplyDAO.Delete(flowId);
                Message.success(context, "代理商提现申请删除成功");
                loginSession.Log("XXXXXX代理商提现申请删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理商提现申请删除失败");
                loginSession.Log(e.Message);
            }
        }

       
    }
}

