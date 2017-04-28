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
    /// 部门
    /// Author:代码生成器
    /// </summary>
    public class DeptBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TSDeptDAO tsDeptDAO= new TSDeptDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public DeptBLL(HttpContext context, ILogin loginSession)
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
            string strSQL = "select    TOP (100) PERCENT * from TSDept order by deptId asc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定部门
        /// <param name="deptId">部门编号</param>
        /// </summary>
        public void Load(string deptId)
        {
            try
            {
                TSDept tsDept=tsDeptDAO.Get(deptId);
                tsDept.status = "1".Equals(tsDept.status) ? "on" : "off";
                WebJson.ToJson(context, tsDept);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加部门
        /// <param name="tsDept">部门</param>
        /// </summary>
        public void Add(TSDept tsDept)
        {
            try
            {
                tsDept.deptId = commonDao.GetMaxNo("TSDept", "", 6);
                tsDept.status = tsDept.status == null ? "0" : "1";
                tsDeptDAO.Add(tsDept);
                Message.success(context, "部门增加成功");
                loginSession.Log(tsDept.deptName + "部门增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "部门增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改部门
        /// <param name="tsDept">部门</param>
        /// </summary>
        public void Edit(TSDept tsDept)
        {
            try
            {
                tsDept.status = tsDept.status == null ? "0" : "1";
                tsDeptDAO.Edit(tsDept);
                Message.success(context, "部门修改成功");
                loginSession.Log(tsDept.deptName + "[" + tsDept.deptId + "]部门修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "部门修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除部门
        /// <param name="deptId">部门编号</param>
        /// </summary>
        public void Delete(string deptId)
        {
            try
            {
                //判断是否存在用户
                if (new TSUserDAO().Exist("deptId", deptId))
                {
                    Message.error(context, "存在用户不能删除，请先删除其用户！");
                    return;
                }

                tsDeptDAO.Delete(deptId);
                Message.success(context, "部门删除成功");
                loginSession.Log(deptId + "编号部门删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "部门删除失败");
                loginSession.Log(e.Message);
            }
        }

        
    }
}

