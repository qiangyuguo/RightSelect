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
    /// 代理快开厅用户
    /// Author:代码生成器
    /// </summary>
    public class AgentUserBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TSAgentUserDAO tsAgentUserDAO= new TSAgentUserDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public AgentUserBLL(HttpContext context, ILogin loginSession)
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
            string strSQL = "select * from TSAgentUser";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定代理快开厅用户
        /// <param name="userCode">用户帐号</param>
        /// </summary>
        public void Load(string userCode)
        {
            try
            {
                TSAgentUser tsAgentUser=tsAgentUserDAO.Get(userCode);
                WebJson.ToJson(context, tsAgentUser);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加代理快开厅用户
        /// <param name="tsAgentUser">代理快开厅用户</param>
        /// </summary>
        public void Add(TSAgentUser tsAgentUser)
        {
            try
            {
                tsAgentUserDAO.Add(tsAgentUser);
                Message.success(context, "代理快开厅用户增加成功");
                loginSession.Log("XXXXXX代理快开厅用户增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理快开厅用户增加失败");
                loginSession.Log(e.Message);
            }
        }

        ///// <summary>
        ///// 修改代理快开厅用户
        ///// <param name="tsAgentUser">代理快开厅用户</param>
        ///// </summary>
        //public void Edit(TSAgentUser tsAgentUser)
        //{
        //    try
        //    {
        //        tsAgentUserDAO.Edit(tsAgentUser);
        //        Message.success(context, "代理快开厅用户修改成功");
        //        loginSession.Log("XXXXXX代理快开厅用户修改成功");
        //    }
        //    catch (Exception e)
        //    {
        //        Message.error(context, "代理快开厅用户修改失败");
        //        loginSession.Log(e.Message);
        //    }
        //}

        ///// <summary>
        ///// 删除代理快开厅用户
        ///// <param name="userCode">用户帐号</param>
        ///// </summary>
        //public void Delete(string userCode)
        //{
        //    try
        //    {
        //        tsAgentUserDAO.Delete(userCode);
        //        Message.success(context, "代理快开厅用户删除成功");
        //        loginSession.Log("XXXXXX代理快开厅用户删除成功");
        //    }
        //    catch (Exception e)
        //    {
        //        Message.error(context, "代理快开厅用户删除失败");
        //        loginSession.Log(e.Message);
        //    }
        //}
    }
}

