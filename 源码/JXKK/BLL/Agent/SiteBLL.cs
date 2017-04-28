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
    /// 快开厅信息
    /// Author:代码生成器
    /// </summary>
    public class SiteBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBSiteDAO tbSiteDAO = new TBSiteDAO();

        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public SiteBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        public SiteBLL()
        {

        }

        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string siteId, string siteName, string auditStatus)
        {
            string strSQL = "select a.*,b.agentName from TBSite a,TBAgent b where a.agentId=b.agentId ";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and a.siteId = '" + siteId + "'";
            if (!string.IsNullOrEmpty(siteName))
                strSQL += " and a.siteName like '%" + siteName + "%'";
            if (!string.IsNullOrEmpty(auditStatus))
                strSQL += " and a.auditStatus in(" + auditStatus + ")";
            Param param = new Param();
            param.Clear();
            string str = commonDao.DataGrid(strSQL, param, page, rows);
            WebJson.Write(context, str);
        }

        /// <summary>
        /// 加载指定快开厅信息
        /// <param name="siteId">快开厅编号</param>
        /// </summary>
        public void Load(string siteId)
        {
            try
            {
                TBSite tbSite = tbSiteDAO.Get(siteId);
                tbSite.status = "1".Equals(tbSite.status) ? "on" : "off";
                WebJson.ToJson(context, tbSite);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }

        /// <summary>
        /// 增加快开厅信息
        /// <param name="tbSite">快开厅信息</param>
        /// </summary>
        public void Add(TBSite tbSite)
        {
            //判断名称是否重复
            if (tbSiteDAO.Exist("siteName", tbSite.siteName))
            {
                Message.error(context, "名称重复请重新输入！");
                return;
            }
            try
            {
                tbSite.siteId = commonDao.GetMaxNo("TBSite", "", 6);
                tbSite.status = tbSite.status == null ? "0" : "1";
                tbSiteDAO.Add(tbSite);
                Message.success(context, "快开厅信息增加成功");
                loginSession.Log(tbSite.siteName + "快开厅信息增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "快开厅信息增加失败");
                loginSession.Log(e.Message);
            }
        }

        /// <summary>
        /// 修改快开厅信息
        /// <param name="tbSite">快开厅信息</param>
        /// </summary>
        public void Edit(TBSite tbSite)
        {
            //判断是否帐号重复
            List<TBSite> list = tbSiteDAO.GetList("siteName", tbSite.siteName);
            if (list.Count > 0 && !tbSite.siteId.Equals(list[0].siteId))
            {
                Message.error(context, "名称重复请重新输入！");
                return;
            }
            try
            {
                tbSite.status = tbSite.status == null ? "0" : "1";
                tbSiteDAO.Edit(tbSite);
                Message.success(context, "快开厅信息修改成功");
                loginSession.Log(tbSite.siteName + "[" + tbSite.siteId + "]快开厅信息修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "快开厅信息修改失败");
                loginSession.Log(e.Message);
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="user">用户对象</param>
        public void Audit(TBSite tbSite)
        {
            try
            {
                tbSiteDAO.Audit(tbSite);
                Message.success(context, "审核操作成功");
                loginSession.Log(tbSite.siteName + "[" + tbSite.siteId + "]快开厅审核操作成功");
            }
            catch (Exception e)
            {
                Message.error(context, "快开厅审核失败");
                loginSession.Log(e.Message);
            }
        }
        /// <summary>
        /// 获取快开厅信息
        /// <param name="siteId">快开厅编号</param>
        /// </summary>
        /// <returns>快开厅信息对象</returns>
        public TBSite Get(string siteId)
        {
            TBSite tbSite = new TBSite();
            try
            {
                tbSite = tbSiteDAO.Get(siteId);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
            return tbSite;
        }
        /// <summary>
        /// 删除快开厅信息
        /// <param name="siteId">快开厅编号</param>
        /// </summary>
        public void Delete(string siteId)
        {
            try
            {
                tbSiteDAO.Delete(siteId);
                Message.success(context, "快开厅信息删除成功");
                loginSession.Log("快开厅信息删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "快开厅信息删除失败");
                loginSession.Log(e.Message);
            }
        }
        


       


        /// <summary>
        /// 获取DataSet(门店信息)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>门店信息DataSet</returns>
        public DataSet GetDataSet(string strSQL)
        {
            Param param = new Param();
            return tbSiteDAO.GetDataSet(strSQL, param);
        }
    }
}

