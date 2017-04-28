using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Lottery;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.Lottery
{
    /// <summary>
    /// 开奖公告
    /// Author:代码生成器
    /// </summary>
    public class NumNoticeBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBNumNoticeDAO tbNumNoticeDAO= new TBNumNoticeDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public NumNoticeBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string period, string lotteryType,string gameId,string startDate, string endDate,bool isMis)
        {
            string strSQL = @"select * from (select t.flowid,l.lotterytypename,l.lotterytype,t.gameid,g.gamename,t.period,t.starttime,t.endtime,t.publishtime,t.numbers 
                               from TBNUMNOTICE t
                               left join tblottery l  on t.lotterytype=l.lotterytype
                               left join TBGame g  on t.gameid=g.gameid ) tt where 1=1 ";
            if (!string.IsNullOrEmpty(period))
                strSQL += " and tt.period='" + period + "'";
            if (!string.IsNullOrEmpty(lotteryType))
                strSQL += " and tt.lotteryType='" + lotteryType + "'";
            if (!string.IsNullOrEmpty(gameId))
                strSQL += " and tt.gameId='" + gameId + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and tt.publishTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and tt.publishTime<= '" + endDate + " 23:59:59'";
            if(isMis==true)
                strSQL += " and tt.gameId= 'x'";
            if (isMis ==false)
                strSQL += " and tt.gameId!= 'x'";
            strSQL += " order by tt.period desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
    }
}

