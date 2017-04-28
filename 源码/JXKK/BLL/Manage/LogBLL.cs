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
    /// 系统日志
    /// Author:代码生成器
    /// </summary>
    public class LogBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TSLogDAO tsLogDAO= new TSLogDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public LogBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// </summary>
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// <param name="orgName">机构名称</param>
        /// <param name="userName">用户名称</param>
        /// <param name="startDate">起始时间</param>
        /// <param name="endDate">结束时间</param>
        public void LoadGrid(int page, int rows, string userName, string startDate, string endDate)
        {
            string strSQL = "select    TOP (100) PERCENT * from TSLog where 1=1 ";
            if (startDate != null && !"".Equals(startDate))
                strSQL += " and createDate >= '"  + startDate + " 00:00:00'";
            if (endDate != null && !"".Equals(endDate))
                strSQL += " and createDate <= '" + endDate + " 23:59:59'";
            if (userName != null && !"".Equals(userName))
                strSQL += " and userName ='" + userName + "'";
            strSQL += " order by logId desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="startDate">起始时间</param>
        /// <param name="endDate">结束时间</param>
        public void Delete(string userName, string startDate, string endDate)
        {
            try
            {
                tsLogDAO.Delete(userName, startDate, endDate);
                Message.success(context, "日志删除成功");
                loginSession.Log("日志删除成功");
            }
            catch (Exception e)
            {
                Message.success(context, "日志删除失败");
                loginSession.Log("日志删除失败，错误：" + e.Message);
            }
        }
    }
}

