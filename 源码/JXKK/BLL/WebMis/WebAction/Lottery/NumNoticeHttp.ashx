<%@ WebHandler Language="C#" Class="Com.ZY.JXKK.WebAction.Lottery.NumNoticeHttp" %>

using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL.Lottery;
using Com.ZY.JXKK.Model.Lottery;

namespace Com.ZY.JXKK.WebAction.Lottery
{
    /// <summary>
    /// 开奖公告
    /// Author:代码生成器
    /// </summary>
    public class NumNoticeHttp: IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "NumNotice");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }
                
                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    NumNoticeBLL bll = new NumNoticeBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    bll.LoadGrid(page, rows);
                    return;
                }
                
                //加载信息
                if (context.Request["action"] == "load")
                {
                    NumNoticeBLL bll = new NumNoticeBLL(context, loginUser);
                    string flowId=context.Request["flowId"];//流水号
                    bll.Load(flowId);
                    return;
                }
                
                //增加
                if (context.Request["action"] == "add")
                {
                    NumNoticeBLL bll = new NumNoticeBLL(context, loginUser);
                    TBNumNotice tbNumNotice= new TBNumNotice();
                    tbNumNotice.flowId= context.Request["flowId"];//流水号
                    tbNumNotice.lotteryType= context.Request["lotteryType"];//彩种
                    tbNumNotice.period= context.Request["period"];//期次
                    tbNumNotice.startTime= context.Request["startTime"];//开售时间
                    tbNumNotice.endTime= context.Request["endTime"];//截止时间
                    tbNumNotice.publishTime= context.Request["publishTime"];//开奖时间
                    tbNumNotice.numbers= context.Request["numbers"];//开奖号码
                    bll.Add(tbNumNotice);
                    return;
                }
                
                //修改
                if (context.Request["action"] == "edit")
                {
                    NumNoticeBLL bll = new NumNoticeBLL(context, loginUser);
                    TBNumNotice tbNumNotice= new TBNumNotice();
                    tbNumNotice.flowId= context.Request["flowId"];//流水号
                    tbNumNotice.lotteryType= context.Request["lotteryType"];//彩种
                    tbNumNotice.period= context.Request["period"];//期次
                    tbNumNotice.startTime= context.Request["startTime"];//开售时间
                    tbNumNotice.endTime= context.Request["endTime"];//截止时间
                    tbNumNotice.publishTime= context.Request["publishTime"];//开奖时间
                    tbNumNotice.numbers= context.Request["numbers"];//开奖号码
                    bll.Edit(tbNumNotice);
                    return;
                }
                
                //删除
                if (context.Request["action"] == "delete")
                {
                    NumNoticeBLL bll = new NumNoticeBLL(context, loginUser);
                    string flowId=context.Request["flowId"];//流水号
                    bll.Delete(flowId);
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

