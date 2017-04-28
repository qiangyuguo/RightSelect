using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Set;
using Com.ZY.JXKK.BLL.Client;
using Com.ZY.JXKK.BLL.PointBet;

namespace Com.ZY.JXKK.PointBet.Handler
{
    /// <summary>
    /// 彩票订单
    /// Author:代码生成器
    /// </summary>
    public class PointOrderHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "PointOrder");
                PointOrderBLL bll = new PointOrderBLL(context, loginUser);
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string orderId = context.Request["orderId"];//订单号
                    string period = context.Request["period"]; //期次
                    string srcType = context.Request["srcType"];//来源方式
                    string orderStatus = context.Request["orderStatus"];//订单状态
                    string awardResult = context.Request["awardResult"];//中奖状态
                    string clientQuery = context.Request["clientQuery"];
                    string clientQueryText = context.Request["clientQueryText"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.LoadGrid(page, rows, "", "", orderId,period, orderStatus,srcType, awardResult, clientQuery, clientQueryText, startDate, endDate);
                }
                //用户查找分类
                if (context.Request["action"] == "clientQueryListLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.ClientQueryCombobox();
                }
                //订单状态下拉框信息
                if (context.Request["action"] == "ddlPointOrderStatusLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.PointOrderStatusCombobox();
                }
                //中奖状态下拉框信息
                if (context.Request["action"] == "ddlPointAwardResultLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.PointAwardResultCombobox();
                    return;
                }
                //来源方式下拉框信息
                if (context.Request["action"] == "ddlSrcTypeLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.SrcTypeCombobox();
                    return;
                }
                //加载信息
                if (context.Request["action"] == "load")
                {
                    string orderId = context.Request["orderId"];//订单号
                    bll.Load(orderId);
                    return;
                }
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}

