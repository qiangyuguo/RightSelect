using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.IO;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO.Manage;

namespace Com.ZY.JXKK.BLL
{
    /// <summary>
    /// 登录用户类。
    /// </summary>
    public class LoginUser : ILogin
    {
        private string userId;//用户编号
        private string userName;//用户名称
        private string roleIds;//角色编号(可以多个)
        private string deptId;//部门编号
        private string deptName;//部门名称
        private System.Collections.Hashtable moduleRight;//权限存储
        private string moduleName;//模块名称
        private bool pass = false;
        private CommonDao commonDao = new CommonDao();

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId
        {
            get { return userId; }
        }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            get { return userName; }
        }

        /// <summary>
        /// 角色编号
        /// </summary>
        public string RoleIds
        {
            get { return roleIds; }
        }

        /// <summary>
        /// 部门编号
        /// </summary>
        public string DeptId
        {
            get { return deptId; }
        }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName
        {
            get { return deptName; }
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
        public LoginUser()
        {
            this.moduleRight = new System.Collections.Hashtable();
        }

        /// <summary>
        /// 实例化用户类并获取用户信息
        /// </summary>
        public LoginUser(System.Web.HttpContext context, string moduleCode)
        {
            try
            {
                LoginUser user = (LoginUser)context.Session["clientUser"];
                this.userId = user.userId;
                this.userName = user.userName;
                this.roleIds = user.roleIds;
                this.deptId = user.deptId;
                this.deptName = user.deptName;
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
            //else if (moduleCode != null && !moduleCode.Equals(""))
            //{
            //    if (this.moduleRight.ContainsKey(moduleCode))
            //        this.moduleName = (string)this.moduleRight[moduleCode];
            //    else
            //    {
            //        Message.right(context, "对不起，您无此模块使用权限");
            //        this.pass = false;
            //        return;
            //    }
            //}
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
            List<TSUser> tsUserList = new TSUserDAO().GetList("userCode", userCode);
            if (tsUserList.Count != 1)
            {
                Message.error(context, "帐号错误");
                return;
            }

            TSUser tsUser = tsUserList[0];
            if (!tsUser.userPwd.Equals(Encrypt.ConvertPwd(tsUser.userId, userPwd)))
            {
                Message.error(context,"密码错误");
                return;
            }
            else if (!"1".Equals(tsUser.status))
            {
                Message.error(context, "帐号停用");
                return;
            }

            //获取部门信息
            TSDept tsDept = new TSDeptDAO().Get(tsUser.deptId);
            if (tsDept == null)
            {
                Message.error(context,"用户所属部门不存在");
                return;
            }
            else if (!"1".Equals(tsDept.status))
            {
                Message.error(context, "用户所属部门停用");
                return;
            }

            //设置登录信息
            this.userId = tsUser.userId;
            this.userName = tsUser.userName;
            this.roleIds = tsUser.roleIds;
            this.deptId = tsUser.deptId;
            this.deptName = tsDept.deptName;

            //会话保存登录用户信息
            context.Session["clientUser"]= this;
            Message.success(context, "success");//成功返回
        }

        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="moduleRight">权限Hash表</param>
        public void SetRight(System.Web.HttpContext context,System.Collections.Hashtable moduleRight)
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
                TSLog tsLog = new TSLog();
                tsLog.logId =  commonDao.GetMaxNo("TSModule", "", 6);
                tsLog.deptId = this.deptId;
                tsLog.deptName = this.deptName;
                tsLog.userId = this.userId;
                tsLog.userName = this.userName;
                tsLog.moduleName = this.moduleName;
                tsLog.userEvent = userEvent;
                new TSLogDAO().Add(tsLog);
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