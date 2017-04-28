using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.IO;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO.Manage;
using Com.ZY.JXKK.DAO.Agent;
using System.Collections;


namespace Com.ZY.JXKK.BLL
{
    /// <summary>
    /// 登录用户类。
    /// </summary>
    public class LoginAgentUser : ILogin
    {
        private string userId;//用户编号
        private string userName;//用户名称
        private string roleIds;//角色编号(可以多个)
        private Hashtable moduleRight;//权限存储
        private string moduleName;//模块名称
        private string roleType;//角色类型
        private bool pass = false;
        private string siteId;//门店编号
        private string siteName;//门店名称
        private string agentId;//代理商编号
        private string agentName;//代理商名称

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId
        {
            get { return userId; }
        }

        /// <summary>
        /// 角色编号
        /// </summary>
        public string RoleIds
        {
            get { return roleIds; }
        }


        /// <summary>
        /// 权限通过
        /// </summary>
        public bool Pass
        {
            get { return pass; }
        }

        /// <summary>
        /// 实例化用户类并获取用户信息存储方式。（用于系统登录）
        /// </summary>
        public LoginAgentUser()
        {
            this.moduleRight = new System.Collections.Hashtable();
        }

        /// <summary>
        /// 实例化用户类并获取用户信息
        /// </summary>
        public LoginAgentUser(System.Web.HttpContext context, string moduleCode)
        {
            try
            {
                LoginAgentUser user = (LoginAgentUser)context.Session["clientUser"];
                this.userId = user.userId;
                this.roleIds = user.roleIds;
                string roleTypeById =new  TSAgentRoleDAO().Get(user.roleIds).type;
                this.roleType = roleTypeById;
                if (roleTypeById == "0")//代理商
                {
                    this.userName = new  TBAgentDAO().Get(user.userId).agentName;
                    this.agentId = user.userId;
                    this.agentName = userName;
                    this.siteId ="无";
                    this.siteName = "无";
                }
                else //员工
                {
                    TBStaff tbStaff= new TBStaffDAO().Get(user.userId);
                    this.userName = tbStaff.staffName;
                    this.siteId = tbStaff.siteId;
                    TBSite tbSite=new TBSiteDAO().Get(tbStaff.siteId);
                    this.siteName = tbSite.siteName;
                    this.agentId = tbSite.agentId;
                    this.agentName = new TBAgentDAO().Get(tbSite.agentId).agentName;
                }
                this.moduleRight = user.moduleRight;
            }
            catch
            {
                Message.right(context, "登录已过期，请重新登录");
                this.pass = false;
                return;
            }

            if (this.userId == null)
            {
                Message.right(context, "登录已过期，请重新登录");
                this.pass = false;
                return;
            }
            else if (moduleCode != null && !moduleCode.Equals(""))
            {
                if (this.moduleRight.ContainsKey(moduleCode))
                    this.moduleName = (string)this.moduleRight[moduleCode];
                else
                {
                    Message.right(context, "对不起，您无此模块使用权限");
                    this.pass = false;
                    return;
                }
            }
            else
            {
                this.moduleName = "系统主界面";
            }
            this.pass = true;
        }

        ///<summary>
        ///登录系统
        ///</summary>
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="userCode">用户名称</param>
        /// <param name="userPwd">用户密码</param>
        public void Login(System.Web.HttpContext context,string userCode, string userPwd)
        {
            //获取用户信息
            List<TSAgentUser> tsAgentUserList = new TSAgentUserDAO().GetList("userCode", userCode);
            if (tsAgentUserList.Count != 1)
            {
                Message.error(context, "帐号错误");
                return;
            }

            TSAgentUser tsAgentUser = tsAgentUserList[0];
            if (!tsAgentUser.userPwd.Equals(Encrypt.ConvertPwd(tsAgentUser.userId, userPwd)))
            {
                Message.error(context,"密码错误");
                return;
            }
            //获取代理商和执法文书类型信息
            string roleType = new TSAgentRoleDAO().Get(tsAgentUser.roleId).type;
            if (roleType == "0")
            {
                TBAgent tbAgent = new TBAgentDAO().Get(tsAgentUser.userId);
                if (tbAgent.auditStatus !=((int)AuditStauts.AuditSucces).ToString())
                {
                    Message.error(context, "代理商未审核或审核失败");
                    return;
                }
                if (!tbAgent.status.Equals("1"))
                {
                    Message.error(context, "代理商停用");
                    return;
                }
            }
            else
            {
                TBStaff tbStaff = new TBStaffDAO().Get(tsAgentUser.userId);
                TBAgent tbAgent = new TBAgentDAO().Get(tbStaff.agentId);
                if (tbAgent.auditStatus != ((int)AuditStauts.AuditSucces).ToString())
                {
                    Message.error(context, "代理商未审核或审核失败");
                    return;
                }
                if (!tbAgent.status.Equals("1"))
                {
                    Message.error(context, "代理商停用");
                    return;
                }
                TBSite tbSite = new TBSiteDAO().Get(tbStaff.siteId);
                if (tbSite.auditStatus != ((int)AuditStauts.AuditSucces).ToString())
                {
                    Message.error(context, "执法文书类型未审核或审核失败");
                    return;
                }
                if (!tbSite.status.Equals("1"))
                {
                    Message.error(context, "执法文书类型停用");
                    return;
                }
            }
            
            //设置登录信息
            this.userId = tsAgentUser.userId;
            this.roleIds = tsAgentUser.roleId;
            if (roleType == "0")//代理商
            {
                this.userName = new TBAgentDAO().Get(tsAgentUser.userId).agentName;
            }
            else //员工
            {
                this.userName = new TBStaffDAO().Get(tsAgentUser.userId).staffName;
            }
            //会话保存登录用户信息
            context.Session["clientUser"]= this;
            Message.success(context, "success");//成功返回
        }

        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="moduleRight">权限Hash表</param>
        public void SetRight(System.Web.HttpContext context,Hashtable moduleRight)
        {
            this.moduleRight = moduleRight;
            context.Session["clientUser"] = this;
        }

        /// <summary>
        /// 清除登录会话信息
        /// </summary>
        public void Remove(System.Web.HttpContext context)
        {
            context.Session.Remove("clientUser");
            Message.success(context, "success");//成功返回
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="userEvent">用户操作</param>
        public void Log(string userEvent)
        {
            try
            {
                TSAgentLog tsAgentLog = new TSAgentLog();
                tsAgentLog.userId = this.userId;
                tsAgentLog.userName = this.userName;
                tsAgentLog.type = this.roleType;
                tsAgentLog.siteId = this.siteId;
                tsAgentLog.siteName = this.siteName;
                tsAgentLog.agentId = this.agentId;
                tsAgentLog.agentName = this.agentName;
                tsAgentLog.moduleName = this.moduleName;
                tsAgentLog.userEvent = userEvent;
                new TSAgentLogDAO().Add(tsAgentLog);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 获取系统登录用户Id
        /// </summary>
        /// <returns></returns>
        public string GetUserId()
        {
            return this.userId;
        }
        /// <summary>
        /// 获取系统登录用户名称
        /// </summary>
        /// <returns></returns>
        public string GetUserName()
        {
            return this.userName;
        }
    }
}