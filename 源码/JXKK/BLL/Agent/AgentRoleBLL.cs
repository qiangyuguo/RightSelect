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
    /// 代理系统角色
    /// Author:代码生成器
    /// </summary>
    public class AgentRoleBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TSAgentRoleDAO tsAgentRoleDAO= new TSAgentRoleDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public AgentRoleBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows)
        {
            string strSQL = "select * from TSAgentRole";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定代理系统角色
        /// <param name="roleId">角色编号</param>
        /// </summary>
        public void Load(string roleId)
        {
            try
            {
                TSAgentRole tsAgentRole=tsAgentRoleDAO.Get(roleId);
                WebJson.ToJson(context, tsAgentRole);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        /// <summary>
        /// 根据角色ID获取代理商角色类型
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public string GetRoleType(string roleId)
        {
            string roleType = "";
            try
            {
                TSAgentRole tsAgentRole = tsAgentRoleDAO.Get(roleId);
                roleType = tsAgentRole.type;
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
            return roleType;
        }
        /// <summary>
        /// 增加代理系统角色
        /// <param name="tsAgentRole">代理系统角色</param>
        /// </summary>
        public void Add(TSAgentRole tsAgentRole)
        {
            try
            {
                tsAgentRoleDAO.Add(tsAgentRole);
                Message.success(context, "代理系统角色增加成功");
                loginSession.Log("XXXXXX代理系统角色增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理系统角色增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改代理系统角色
        /// <param name="tsAgentRole">代理系统角色</param>
        /// </summary>
        public void Edit(TSAgentRole tsAgentRole)
        {
            try
            {
                tsAgentRoleDAO.Edit(tsAgentRole);
                Message.success(context, "代理系统角色修改成功");
                loginSession.Log("XXXXXX代理系统角色修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理系统角色修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除代理系统角色
        /// <param name="roleId">角色编号</param>
        /// </summary>
        public void Delete(string roleId)
        {
            try
            {
                tsAgentRoleDAO.Delete(roleId);
                Message.success(context, "代理系统角色删除成功");
                loginSession.Log("XXXXXX代理系统角色删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理系统角色删除失败");
                loginSession.Log(e.Message);
            }
        }
    }
}

