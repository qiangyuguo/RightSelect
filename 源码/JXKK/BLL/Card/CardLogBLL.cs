using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Card;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.Card
{
    /// <summary>
    /// 卡片日志
    /// Author:代码生成器
    /// </summary>
    public class CardLogBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBCardLogDAO tbCardLogDAO= new TBCardLogDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public CardLogBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string cardId, string startDate, string endDate)
        {
            string strSQL = "select * from TBCardLog where 1=1 ";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and operateTime >= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and operateTime <= To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(cardId))
                strSQL += " and cardId ='" + cardId + "'";
            strSQL += " order by logId desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
    }
}

