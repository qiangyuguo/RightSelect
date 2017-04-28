using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Manage;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.Manage
{
    /// <summary>
    /// 系统角色
    /// Author:代码生成器
    /// </summary>
    public class RoleBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TSRoleDAO tsRoleDAO= new TSRoleDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public RoleBLL(HttpContext context, ILogin loginSession)
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
            string strSQL = "select  TOP (100) PERCENT * from TSRole order by roleId asc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定系统角色
        /// <param name="roleId">角色编号</param>
        /// </summary>
        public void Load(string roleId)
        {
            try
            {
                TSRole tsRole=tsRoleDAO.Get(roleId);
                tsRole.status = "1".Equals(tsRole.status) ? "on" : "off";
                WebJson.ToJson(context, tsRole);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加系统角色
        /// <param name="tsRole">系统角色</param>
        /// </summary>
        public void Add(TSRole tsRole)
        {
            try
            {
                tsRole.roleId = commonDao.GetMaxNo("TSRole", "", 3);
                tsRole.status = tsRole.status == null ? "0" : "1";
                tsRoleDAO.Add(tsRole);
                Message.success(context, "角色增加成功");
                loginSession.Log(tsRole.roleName + "角色增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "角色增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改系统角色
        /// <param name="tsRole">系统角色</param>
        /// </summary>
        public void Edit(TSRole tsRole)
        {
            try
            {
                tsRole.status = tsRole.status == null ? "0" : "1";
                tsRoleDAO.Edit(tsRole);
                Message.success(context, "角色修改成功");
                loginSession.Log(tsRole.roleName + "[" + tsRole.roleId + "]角色修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "角色修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除系统角色
        /// <param name="roleId">角色编号</param>
        /// </summary>
        public void Delete(string roleId)
        {
            try
            {
                tsRoleDAO.Delete(roleId);
                Message.success(context, "角色删除成功");
                loginSession.Log(roleId + "编号角色删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "角色删除失败");
                loginSession.Log(e.Message);
            }
        }

    }
}

