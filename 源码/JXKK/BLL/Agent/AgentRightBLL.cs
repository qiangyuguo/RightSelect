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
    /// 代理系统权限模块
    /// Author:代码生成器
    /// </summary>
    public class AgentRightBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TSAgentRightDAO tsAgentRightDAO= new TSAgentRightDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public AgentRightBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }

        /// <summary>
        /// 权限保存
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="moduleIdList">角色拥有模块编号</param>
        public void Save(string roleId, List<string> moduleIdList)
        {
            try
            {
                tsAgentRightDAO.Save(roleId, moduleIdList);
                Message.success(context, "权限保存成功");
                loginSession.Log(roleId + "角色权限保存成功");
            }
            catch (Exception e)
            {
                Message.error(context, "权限保存失败");
                loginSession.Log(e.Message);
            }
        }
    }
}

