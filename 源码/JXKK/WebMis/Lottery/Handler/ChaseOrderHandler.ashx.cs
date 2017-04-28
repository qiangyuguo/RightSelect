using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL.Lottery;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Set;
using Com.ZY.JXKK.BLL.Client;

namespace Com.ZY.JXKK.Lottery.Handler
{
    /// <summary>
    /// 追号订单
    /// Author:代码生成器
    /// </summary>
    public class ChaseOrderHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "ChaseOrder");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    ChaseOrderBLL bll = new ChaseOrderBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string chaseOrderId = context.Request["chaseOrderId"];
                    string period = context.Request["period"];
                    string srcType = context.Request["srcType"];//来源方式
                    string chaseStatus = context.Request["chaseStatus"];
                    string clientQuery = context.Request["clientQuery"];
                    string clientQueryText = context.Request["clientQueryText"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.LoadGrid(page, rows, "", "", chaseOrderId,period,srcType, chaseStatus, clientQuery, clientQueryText, startDate, endDate);
                    return;
                }
                //用户查找分类
                if (context.Request["action"] == "clientQueryListLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.ClientQueryCombobox();
                }
                //追号状态下拉框信息
                if (context.Request["action"] == "ddlChaseStatusLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.ChaseStatusCombobox();
                    return;
                }
                //彩种下拉框信息
                if (context.Request["action"] == "ddlLotteryTypeLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.LotteryTypeCombobox();
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
                    ChaseOrderBLL bll = new ChaseOrderBLL(context, loginUser);
                    string chaseOrderId = context.Request["chaseOrderId"];//追号订单号
                    bll.Load(chaseOrderId);
                    return;
                }
                //已追订单
                if (context.Request["action"] == "alreadyChaseDetail")
                {
                    ChasePlanBLL bll = new ChasePlanBLL(context, loginUser);
                    string chaseOrderId = context.Request["chaseOrderId"];
                    string chaseStatus = context.Request["chaseStatus"];
                    bll.LoadGrid(chaseOrderId, chaseStatus,"0","");
                    return;
                }
                
                //未追订单
                if (context.Request["action"] == "notChaseDetail")
                {
                    ChasePlanBLL bll = new ChasePlanBLL(context, loginUser);
                    string chaseOrderId = context.Request["chaseOrderId"];
                    string chaseStatus = context.Request["chaseStatus"];
                    bll.LoadGrid(chaseOrderId, chaseStatus,"1","");
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

