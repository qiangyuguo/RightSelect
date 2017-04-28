using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Set;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.Set
{
    /// <summary>
    /// 最大值表
    /// Author:代码生成器
    /// </summary>
    public class MaxBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TSMaxDAO tsMaxDAO= new TSMaxDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public MaxBLL(HttpContext context, ILogin loginSession)
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
            string strSQL = "select * from TSMax";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定最大值表
        /// <param name="tabName">表名</param>
        /// </summary>
        public void Load(string tabName)
        {
            try
            {
                TSMax tsMax=tsMaxDAO.Get(tabName);
                WebJson.ToJson(context, tsMax);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加最大值表
        /// <param name="tsMax">最大值表</param>
        /// </summary>
        public void Add(TSMax tsMax)
        {
            try
            {
                tsMaxDAO.Add(tsMax);
                Message.success(context, "最大值表增加成功");
                loginSession.Log("XXXXXX最大值表增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "最大值表增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改最大值表
        /// <param name="tsMax">最大值表</param>
        /// </summary>
        public void Edit(TSMax tsMax)
        {
            try
            {
                tsMaxDAO.Edit(tsMax);
                Message.success(context, "最大值表修改成功");
                loginSession.Log("XXXXXX最大值表修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "最大值表修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除最大值表
        /// <param name="tabName">表名</param>
        /// </summary>
        public void Delete(string tabName)
        {
            try
            {
                tsMaxDAO.Delete(tabName);
                Message.success(context, "最大值表删除成功");
                loginSession.Log("XXXXXX最大值表删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "最大值表删除失败");
                loginSession.Log(e.Message);
            }
        }
    }
}

