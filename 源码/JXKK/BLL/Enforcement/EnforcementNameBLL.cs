using Com.Data;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Enforcement;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Com.ZY.JXKK.BLL.Enforcement
{
    public class EnforcementNameBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBEnforcementNameDAO tbEnforcementNameDAO = new TBEnforcementNameDAO();

        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public EnforcementNameBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        public EnforcementNameBLL()
        {

        }

        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string EnforcementNameId, string EnforcementName, string EnforcementTypeId)
        {
            string strSQL = "select a.*,b.EnforcementTypeName ,c.TemplateName  from TBEnForcementName a  ,TBEnforcementType b ,TBEnforcementTemplate c  where 1=1   and a.EnforcementTemplateId=c.TemplateId and  a.EnforcementTypeId=b.EnforcementTypeId and  a.statu=1   ";
            if (!string.IsNullOrEmpty(EnforcementNameId))
                strSQL += " and a.EnforcementNameId   like '%" + EnforcementNameId + "%'";
            if (!string.IsNullOrEmpty(EnforcementName))
                strSQL += " and a.EnforcementName like '%" + EnforcementName + "%'";
            if (!string.IsNullOrEmpty(EnforcementTypeId))
                strSQL += " and a.EnforcementTypeId = '" + EnforcementTypeId + "'";
           
            Param param = new Param();
            param.Clear();
            string str = commonDao.DataGrid(strSQL, param, page, rows);
            WebJson.Write(context, str);
        }

        /// <summary>
        /// 加载指定执法文书名称信息
        /// <param name="siteId">执法文书名称编号</param>
        /// </summary>
        public void Load(string EnforcementTypeId)
        {
            try
            {
                TBEnforcementName tbEnforcementName = tbEnforcementNameDAO.Get(EnforcementTypeId);

                WebJson.ToJson(context, tbEnforcementName);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }

        /// <summary>
        /// 增加执法文书名称信息
        /// <param name="tbSite">执法文书名称信息</param>
        /// </summary>
        public void Add(TBEnforcementName tbEnforcementName)
        {
            //判断名称是否重复
            if (tbEnforcementNameDAO.Exist("EnforcementName", tbEnforcementName.EnforcementName))
            {
               Message.error(context, "执法文书名称重复请重新输入！");
                return;
            }
            try
            {
                tbEnforcementName.EnforcementNameId = commonDao.GetMaxNo("TBEnForcementName", "", 6);
                tbEnforcementName.IsEmpty = tbEnforcementName.IsEmpty == null ? "0" : "1";
                tbEnforcementNameDAO.Add(tbEnforcementName);
                Message.success(context, "执法文书名称信息增加成功");
                loginSession.Log(tbEnforcementName.EnforcementName + "执法文书名称增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "执法文书名称信息增加失败");
                loginSession.Log(e.Message);
            }
        }

        /// <summary>
        /// 修改执法文书名称信息
        /// <param name="tbSite">执法文书名称信息</param>
        /// </summary>
        public void Edit(TBEnforcementName tbEnforcementName)
        {
            //判断是否帐号重复
            List<TBEnforcementName> list = tbEnforcementNameDAO.GetList("EnforcementName", tbEnforcementName.EnforcementName);
            if (list.Count > 0 && !tbEnforcementName.EnforcementName.Equals(list[0].EnforcementName))
            {
                Message.error(context, "名称重复请重新输入！");
                return;
            }
            try
            {
                tbEnforcementNameDAO.Edit(tbEnforcementName);
                Message.success(context, "执法文书名称信息修改成功");
                loginSession.Log(tbEnforcementName.EnforcementName + "[" + tbEnforcementName.EnforcementNameId + "]执法文书名称信息修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "执法文书名称信息修改失败");
                loginSession.Log(e.Message);
            }
        }
         
        /// <summary>
        /// 获取执法文书名称信息
        /// <param name="siteId">执法文书名称编号</param>
        /// </summary>
        /// <returns>执法文书名称信息对象</returns>
        public TBEnforcementName Get(string EnforcementNameId)
        {
            TBEnforcementName tbEnforcementName = new TBEnforcementName();
            try
            {
                tbEnforcementName = tbEnforcementNameDAO.Get(EnforcementNameId);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
            return tbEnforcementName;
        }
        /// <summary>
        /// 删除执法文书名称信息
        /// <param name="siteId">执法文书名称编号</param>
        /// </summary>
        public void Delete(string EnforcementNameId)
        {
            try
            {
                tbEnforcementNameDAO.Delete(EnforcementNameId);
                Message.success(context, "执法文书信息删除成功");
                loginSession.Log("执法文书名称信息删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "执法文书名称信息删除失败");
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
            return tbEnforcementNameDAO.GetDataSet(strSQL, param);
        }
    }
}
