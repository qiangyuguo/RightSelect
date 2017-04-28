using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.PointBet;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.PointBet
{
    /// <summary>
    /// 积分投注开奖公告
    /// Author:代码生成器
    /// </summary>
    public class PNumNoticeBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBPNumNoticeDAO tbPNumNoticeDAO= new TBPNumNoticeDAO();
        
        /// <summary>
        /// 类构造方法
        /// </summary>
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginUser">登录对象信息</param>
        public PNumNoticeBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// </summary>
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        public void LoadGrid(int page, int rows,string period, string gameId, string startDate, string endDate)
        {
            string strSQL = @"select * from (select t.flowid,t.gameid,g.gamename,t.period,t.starttime,t.endtime,t.publishtime,t.numbers 
                               from TBPNUMNOTICE t
                               left join TBGame g  on t.gameid=g.gameid ) tt where 1=1 ";
            if (!string.IsNullOrEmpty(period))
                strSQL += " and tt.period='" + period + "'";
            if (!string.IsNullOrEmpty(gameId))
                strSQL += " and tt.gameId='" + gameId + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and tt.publishTime>= '" + startDate + " 00:00:00'";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and tt.publishTime<= '" + endDate + " 23:59:59'";
            strSQL += " order by tt.period desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定积分投注开奖公告
        /// </summary>
        /// <param name="flowId">流水号</param>
        public void Load(string flowId)
        {
            try
            {
                TBPNumNotice tbPNumNotice=tbPNumNoticeDAO.Get(flowId);
                WebJson.ToJson(context, tbPNumNotice);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加积分投注开奖公告
        /// </summary>
        /// <param name="tbPNumNotice">积分投注开奖公告</param>
        public void Add(TBPNumNotice tbPNumNotice)
        {
            try
            {
                tbPNumNoticeDAO.Add(tbPNumNotice);
                Message.success(context, "积分投注开奖公告增加成功");
                loginSession.Log("XXXXXX积分投注开奖公告增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "积分投注开奖公告增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改积分投注开奖公告
        /// </summary>
        /// <param name="tbPNumNotice">积分投注开奖公告</param>
        public void Edit(TBPNumNotice tbPNumNotice)
        {
            try
            {
                tbPNumNoticeDAO.Edit(tbPNumNotice);
                Message.success(context, "积分投注开奖公告修改成功");
                loginSession.Log("XXXXXX积分投注开奖公告修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "积分投注开奖公告修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除积分投注开奖公告
        /// </summary>
        /// <param name="flowId">流水号</param>
        public void Delete(string flowId)
        {
            try
            {
                tbPNumNoticeDAO.Delete(flowId);
                Message.success(context, "积分投注开奖公告删除成功");
                loginSession.Log("XXXXXX积分投注开奖公告删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "积分投注开奖公告删除失败");
                loginSession.Log(e.Message);
            }
        }
    }
}

