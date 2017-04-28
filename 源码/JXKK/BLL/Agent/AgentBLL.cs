using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Agent;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DAO.Set;

namespace Com.ZY.JXKK.BLL.Agent
{
    /// <summary>
    /// 代理商信息
    /// Author:代码生成器
    /// </summary>
    public class AgentBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBAgentDAO tbAgentDAO= new TBAgentDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public AgentBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// <param name="agentName">代理商名称</param>
        /// <param name="agentId">代理商编号</param>
        /// <param name="bankCardId">银行卡号</param>
        /// <param name="auditStatus">审核状态</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string agentName,string agentId,string bankCardId,string auditStatus)
        {
            string strSQL = "select a.*,b.areaName from TBAgent a,TBArea b where a.areaId=b.areaId ";
            if (!string.IsNullOrEmpty(agentName))
                strSQL += " and a.agentName like '%"+agentName+"%'";
            if (!string.IsNullOrEmpty(auditStatus))
            {
                strSQL += " and a.auditStatus in(" + auditStatus + ")";
            }
            if (!string.IsNullOrEmpty(agentId))
            {
                strSQL += " and a.agentId='" + agentId + "'";
            }
            if (!string.IsNullOrEmpty(bankCardId))
            {
                strSQL += " and a.bankCardId='" + bankCardId + "'";
            }
            strSQL += " order by a.agentId ";
            Param param = new Param();
            param.Clear();
            string str = commonDao.DataGrid(strSQL, param, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定代理商信息
        /// <param name="agentId">代理商编号</param>
        /// </summary>
        public void Load(string agentId)
        {
            try
            {
                TBAgentClon tbAgent = tbAgentDAO.GetClon(agentId);
                tbAgent.status = "1".Equals(tbAgent.status) ? "on" : "off";
                WebJson.ToJson(context, tbAgent);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }


        /// <summary>
        /// 获取指定代理商信息
        /// <param name="agentId">代理商编号</param>
        /// </summary>
        public TBAgent Get(string agentId)
        {
            TBAgent tbAgent = new TBAgent();
            try
            {
              tbAgent = tbAgentDAO.Get(agentId);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
            return tbAgent;
        }
        /// <summary>
        /// 增加代理商信息
        /// <param name="tbAgent">代理商信息</param>
        /// </summary>
        public void Add(TBAgent tbAgent,TSAgentUser tsAgentUser)
        {
            TSAgentUserDAO tsAgentUserDAO = new TSAgentUserDAO();
            //判断是否名称重复
            if (tbAgentDAO.Exist("agentName", tbAgent.agentName))
            {
                Message.error(context, "名称重复请重新输入！");
                return;
            }
            //判断是否帐号重复
            if (tsAgentUserDAO.Exist("userCode", tsAgentUser.userCode))
            {
                Message.error(context, "用户帐号重复请重新输入！");
                return;
            }
            try
            {
                tbAgent.agentId = commonDao.GetMaxNo("TBAgent", "", 6);
                tbAgent.status = tbAgent.status == null ? "0" : "1";
                tbAgentDAO.AddTrans(tbAgent, tsAgentUser);

                Message.success(context, "代理商信息增加成功,默认密码为帐号,登录后建议修改");
                loginSession.Log(tbAgent.agentName + "代理商信息增加成功");
                
            }
            catch (Exception e)
            {
                Message.error(context, "代理商信息增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改代理商信息
        /// <param name="tbAgent">代理商信息</param>
        /// </summary>
        public void Edit(TBAgent tbAgent)
        {
            //判断是否帐号重复
            List<TBAgent> list = tbAgentDAO.GetList("agentName", tbAgent.agentName);
            if (list.Count > 0 && !tbAgent.agentId.Equals(list[0].agentId))
            {
                Message.error(context, "名称重复请重新输入！");
                return;
            }

            try
            {
                tbAgent.status = (tbAgent.status == null || tbAgent.status == "off") ? "0" : "1";
                tbAgentDAO.Edit(tbAgent);
                Message.success(context, "代理商信息修改成功");
                loginSession.Log(tbAgent.agentName + "[" + tbAgent.agentId + "]代理商信息修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理商信息修改失败");
                loginSession.Log(e.Message);
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="user">用户对象</param>
        public void Audit(TBAgent tbAgent)
        {
            try
            {
                tbAgentDAO.Audit(tbAgent);
                Message.success(context, "审核操作成功");
                loginSession.Log(tbAgent.agentName + "[" + tbAgent.agentId + "]代理商审核操作成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理商审核失败");
                loginSession.Log(e.Message);
            }
        }

        /// <summary>
        /// 重置代理商密码
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="roleType"></param>
        public void PawReset(string agentId, string roleType)
        {
            TSAgentUser tsAgentUser = new TSAgentUser();
            string strSQL = "select * from tsAgentUser where userId=" + agentId + " and roleId='001'";
            TSAgentUserDAO tsAgentUserDao = new TSAgentUserDAO();
            Param param = new Param();
            tsAgentUser = tsAgentUserDao.GetList(strSQL, param)[0];
            try
            {
                string userPwd = Encrypt.ConvertPwd(tsAgentUser.userId, tsAgentUser.userCode);
                tsAgentUserDao.ChangePwd(tsAgentUser.userId, userPwd, roleType);
                Message.success(context, "代理商密码重置成功");
                loginSession.Log(agentId + "代理商密码重置成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理商密码重置失败");
                loginSession.Log(e.Message);
            }
        }
        /// <summary>
        /// 删除代理商信息
        /// <param name="agentId">代理商编号</param>
        /// </summary>
        public void Delete(string agentId)
        {
            try
            {
                tbAgentDAO.Delete(agentId);
                Message.success(context, "代理商信息删除成功");
                loginSession.Log(agentId+"代理商信息删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理商信息删除失败");
                loginSession.Log(e.Message);
            }
        }

        
       

        public DataSet GetDataSet(string agentName)
        {
            DataSet ds = new DataSet();
            string strSql = @"select * from TBAgent t where 1=1";
            if(!string.IsNullOrEmpty(agentName))
                strSql += " and t.agentName='" + agentName + "'";
            ds = tbAgentDAO.GetDataSet(strSql, null);
            return ds;
        }
        /// <summary>
        /// 获取代理商的预存款余额
        /// </summary>
        /// <returns></returns>
        public double GetAdvanceBalance(string agentId, string siteId, string city, string county)
        {
            double advanceBalance = tbAgentDAO.GetAdvanceBalance(agentId, siteId, city, county);
            return advanceBalance;
        }
    }
}

