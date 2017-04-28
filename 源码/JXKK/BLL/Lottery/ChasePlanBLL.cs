using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Lottery;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.BLL.Lottery
{
    /// <summary>
    /// 追号计划
    /// Author:代码生成器
    /// </summary>
    public class ChasePlanBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TTChasePlanDBO ttChasePlanDBO= new TTChasePlanDBO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public ChasePlanBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(string chaseOrderId, string chaseStatus, string alreadyOrNotChase, string agentId)
        {
            string strSQL = "";
            if (chaseStatus == "0")//计划追号订单
            {
                if (alreadyOrNotChase == "1")
                {
                    strSQL = @"select * from Ttchaseplan c
                            where c.period>
                            (select case when max(l.period) is null then '0' else max(l.period) end 
                            from TTLotteryOrder l where 1=1 ";
                    if (!string.IsNullOrEmpty(agentId))
                        strSQL += " and l.agentId='" + agentId + "'";

                    strSQL += " and l.chaseorderid='" + chaseOrderId + "') and c.chaseorderid='" + chaseOrderId + "'";
                    strSQL += " order by c.period desc";
                }
                else if (alreadyOrNotChase == "0")//已追号的订单 
                {
                    strSQL = @"select * from TTLotteryOrder l where  l.chaseorderid='" + chaseOrderId + "'";
                    if (!string.IsNullOrEmpty(agentId))
                        strSQL += " and l.agentId='" + agentId + "'";
                    strSQL += " order by l.period desc";
                }
            }
            else if (chaseStatus != "0")//已经完成追号的订单
            {
                strSQL = @"select * from TTLotteryOrder l where  l.chaseorderid='" + chaseOrderId + "'";
                if (!string.IsNullOrEmpty(agentId))
                    strSQL += " and l.agentId='" + agentId + "'";
                strSQL += " order by l.period desc";
            }
            string str = commonDao.DataGrid(strSQL, null);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定追号计划
        /// <param name="orderId">订单号</param>
        /// </summary>
        public void Load(string orderId)
        {
            try
            {
                TTChasePlan ttChasePlan=ttChasePlanDBO.Get(orderId);
                WebJson.ToJson(context, ttChasePlan);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
    }
}

