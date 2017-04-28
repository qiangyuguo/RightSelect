using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.UKey;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.UKey
{
    /// <summary>
    /// 加密狗日志
    /// Author:代码生成器
    /// </summary>
    public class UKeyLogBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBUKeyLogDAO tbUKeyLogDAO= new TBUKeyLogDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginUser">登录对象信息</param>
        /// </summary>
        public UKeyLogBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string uKeyId, string startDate, string endDate)
        {
            string strSQL = "select * from TBUKeyLog where 1=1";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and operateTime >= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and operateTime <= To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(uKeyId))
                strSQL += " and uKeyId ='" + uKeyId + "'";
            strSQL += " order by logId desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定加密狗日志
        /// <param name="logId">日志编号</param>
        /// </summary>
        public void Load(long logId)
        {
            try
            {
                TBUKeyLog tbUKeyLog=tbUKeyLogDAO.Get(logId);
                WebJson.ToJson(context, tbUKeyLog);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加加密狗日志
        /// <param name="tbUKeyLog">加密狗日志</param>
        /// </summary>
        public void Add(TBUKeyLog tbUKeyLog)
        {
            try
            {
                tbUKeyLogDAO.Add(tbUKeyLog);
                Message.success(context, "加密狗日志增加成功");
                loginSession.Log("XXXXXX加密狗日志增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "加密狗日志增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改加密狗日志
        /// <param name="tbUKeyLog">加密狗日志</param>
        /// </summary>
        public void Edit(TBUKeyLog tbUKeyLog)
        {
            try
            {
                tbUKeyLogDAO.Edit(tbUKeyLog);
                Message.success(context, "加密狗日志修改成功");
                loginSession.Log("XXXXXX加密狗日志修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "加密狗日志修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除加密狗日志
        /// <param name="logId">日志编号</param>
        /// </summary>
        public void Delete(long logId)
        {
            try
            {
                tbUKeyLogDAO.Delete(logId);
                Message.success(context, "加密狗日志删除成功");
                loginSession.Log("XXXXXX加密狗日志删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "加密狗日志删除失败");
                loginSession.Log(e.Message);
            }
        }
    }
}

