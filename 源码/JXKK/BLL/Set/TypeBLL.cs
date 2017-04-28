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
    /// 类型设置
    /// Author:代码生成器
    /// </summary>
    public class TypeBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBTypeDAO tbTypeDAO= new TBTypeDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public TypeBLL(HttpContext context, ILogin loginSession)
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
            string strSQL = "select * from TBType";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定类型设置
        /// <param name="typeCode">类型编号</param>
        /// <param name="tableName">使用表名</param>
        /// </summary>
        public void Load(string typeCode,string tableName)
        {
            try
            {
                TBType tbType=tbTypeDAO.Get(typeCode,tableName);
                WebJson.ToJson(context, tbType);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加类型设置
        /// <param name="tbType">类型设置</param>
        /// </summary>
        public void Add(TBType tbType)
        {
            try
            {
                tbTypeDAO.Add(tbType);
                Message.success(context, "类型设置增加成功");
                loginSession.Log("XXXXXX类型设置增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "类型设置增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改类型设置
        /// <param name="tbType">类型设置</param>
        /// </summary>
        public void Edit(TBType tbType)
        {
            try
            {
                tbTypeDAO.Edit(tbType);
                Message.success(context, "类型设置修改成功");
                loginSession.Log("XXXXXX类型设置修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "类型设置修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除类型设置
        /// <param name="typeCode">类型编号</param>
        /// <param name="tableName">使用表名</param>
        /// </summary>
        public void Delete(string typeCode,string tableName)
        {
            try
            {
                tbTypeDAO.Delete(typeCode,tableName);
                Message.success(context, "类型设置删除成功");
                loginSession.Log("XXXXXX类型设置删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "类型设置删除失败");
                loginSession.Log(e.Message);
            }
        }
    }
}

