using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.Agent.Handler
{
    /// <summary>
    /// 代理商充值提醒
    /// Author:代码生成器
    /// </summary>
    public class AgentRechargeNoticeHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AgentRechargeNotice");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    AgentRechargeNoticeBLL bll = new AgentRechargeNoticeBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.LoadGrid(page, rows, "", startDate, endDate);
                    return;
                }
                //办理状态
                if (context.Request["action"] == "dealWSListLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.DealWSCombobox();
                }
                //加载信息
                if (context.Request["action"] == "load")
                {
                    AgentRechargeNoticeBLL bll = new AgentRechargeNoticeBLL(context, loginUser);
                    long flowId = long.Parse(context.Request["flowId"]);//编号
                    bll.Load(flowId);
                    return;
                }
                //修改
                if (context.Request["action"] == "edit")
                {
                    AgentRechargeNoticeBLL bll = new AgentRechargeNoticeBLL(context, loginUser);
                    TTAgentRechargeNotice ttAgentRechargeNotice = new TTAgentRechargeNotice();
                    ttAgentRechargeNotice.flowId = long.Parse(context.Request["flowId"]);//编号
                    ttAgentRechargeNotice.dealWithStatus = context.Request["dealWithStatus"];//办理状态
                    ttAgentRechargeNotice.remark = context.Request["remark"];//说明
                    ttAgentRechargeNotice.operatorId = loginUser.UserId;//办理人编号
                    ttAgentRechargeNotice.operatorName = loginUser.UserName;//办理人名称
                    ttAgentRechargeNotice.opinion = context.Request["opinion"];//办理意见
                    ttAgentRechargeNotice.dealWithTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//办理意见
                    bll.Edit(ttAgentRechargeNotice);
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
