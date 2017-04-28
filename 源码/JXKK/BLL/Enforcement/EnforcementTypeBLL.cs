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
    public class EnforcementTypeBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBEnforcementTypeDAO tbEnforcementTypeDAO = new TBEnforcementTypeDAO();

        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public EnforcementTypeBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        public EnforcementTypeBLL()
        {

        }

        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string EnforcementTypeId, string EnforcementTypeName, string PunishmentTypeId)
        {
            string strSQL = "select * from TBEnforcementType a where 1=1 and a.statu=1 ";
            if (!string.IsNullOrEmpty(EnforcementTypeId))
                strSQL += " and a.EnforcementTypeId like '%" + EnforcementTypeId + "%'";
            if (!string.IsNullOrEmpty(EnforcementTypeName))
                strSQL += " and a.EnforcementTypeName like '%" + EnforcementTypeName + "%'";
            if (!string.IsNullOrEmpty(PunishmentTypeId))
                strSQL += " and a.PunishmentType = '" + PunishmentTypeId + "'";
         
            Param param = new Param();
            param.Clear();
            string str = commonDao.DataGrid(strSQL, param, page, rows);
            WebJson.Write(context, str);
        }

        /// <summary>
        /// 加载指定执法文书类型信息
        /// <param name="siteId">执法文书类型编号</param>
        /// </summary>
        public void Load(string EnforcementTypeId)
        {
            try
            {
                TBEnforcementType tbEnforcementType = tbEnforcementTypeDAO.Get(EnforcementTypeId);

                WebJson.ToJson(context, tbEnforcementType);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }

        /// <summary>
        /// 增加执法文书类型信息
        /// <param name="tbSite">执法文书类型信息</param>
        /// </summary>
        public void Add(TBEnforcementType tbEnforcementType)
        {
            //判断名称是否重复
            if (tbEnforcementTypeDAO.Exist("EnforcementTypeName", tbEnforcementType.EnforcementTypeName))
            {
               Message.error(context, "执法文书名称重复请重新输入！");
                return;
            }
            try
            {
                tbEnforcementType.EnforcementTypeId = commonDao.GetMaxNo("TBEnforcementType", "", 6);
                tbEnforcementTypeDAO.Add(tbEnforcementType);
                Message.success(context, "执法文书类型信息增加成功");
                loginSession.Log(tbEnforcementType.EnforcementTypeName + "执法文书类型增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "执法文书类型信息增加失败");
                loginSession.Log(e.Message);
            }
        }

        /// <summary>
        /// 修改执法文书类型信息
        /// <param name="tbSite">执法文书类型信息</param>
        /// </summary>
        public void Edit(TBEnforcementType tbEnforcementType)
        {
            //判断是否帐号重复
            List<TBEnforcementType> list = tbEnforcementTypeDAO.GetList("EnforcementTypeName", tbEnforcementType.EnforcementTypeName);
            if (list.Count > 0 && !tbEnforcementType.EnforcementTypeId.Equals(list[0].EnforcementTypeId))
            {
                Message.error(context, "名称重复请重新输入！");
                return;
            }
            try
            {
                tbEnforcementTypeDAO.Edit(tbEnforcementType);
                Message.success(context, "执法文书类型信息修改成功");
                loginSession.Log(tbEnforcementType.EnforcementTypeName + "[" + tbEnforcementType.EnforcementTypeId + "]执法文书类型信息修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "执法文书类型信息修改失败");
                loginSession.Log(e.Message);
            }
        }
         
        /// <summary>
        /// 获取执法文书类型信息
        /// <param name="siteId">执法文书类型编号</param>
        /// </summary>
        /// <returns>执法文书类型信息对象</returns>
        public TBEnforcementType Get(string EnforcementTypeId)
        {
            TBEnforcementType tbEnforcementType = new TBEnforcementType();
            try
            {
                tbEnforcementType = tbEnforcementTypeDAO.Get(EnforcementTypeId);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
            return tbEnforcementType;
        }
        /// <summary>
        /// 删除执法文书类型信息
        /// <param name="siteId">执法文书类型编号</param>
        /// </summary>
        public void Delete(string EnforcementTypeId)
        {
            try
            {
                tbEnforcementTypeDAO.Delete(EnforcementTypeId);
                Message.success(context, "执法文书类型信息删除成功");
                loginSession.Log("执法文书类型信息删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "执法文书类型信息删除失败");
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
            return tbEnforcementTypeDAO.GetDataSet(strSQL, param);
        }
    }
}
