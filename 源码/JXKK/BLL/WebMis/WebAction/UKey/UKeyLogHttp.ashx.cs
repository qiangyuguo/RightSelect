using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.UKey;
using Com.ZY.JXKK.Model.UKey;

namespace Com.ZY.JXKK.WebAction.UKey
{
    /// <summary>
    /// 加密狗日志
    /// Author:代码生成器
    /// </summary>
    public class UKeyLogHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "UKeyLog");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    UKeyLogBLL bll = new UKeyLogBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string uKeyId = context.Request["uKeyId"];
                    string startDate = context.Request["startDate"];
                    string endDate = context.Request["endDate"];
                    bll.LoadGrid(page, rows, uKeyId, startDate, endDate);
                    return;
                }

                //加载信息
                if (context.Request["action"] == "load")
                {
                    UKeyLogBLL bll = new UKeyLogBLL(context, loginUser);
                    long logId = long.Parse(context.Request["logId"]);//日志编号
                    bll.Load(logId);
                    return;
                }

                //增加
                if (context.Request["action"] == "add")
                {
                    UKeyLogBLL bll = new UKeyLogBLL(context, loginUser);
                    TBUKeyLog tbUKeyLog = new TBUKeyLog();
                    tbUKeyLog.logId = long.Parse(context.Request["logId"]);//日志编号
                    tbUKeyLog.uKeyId = context.Request["uKeyId"];//加密狗编号
                    tbUKeyLog.operateType = context.Request["operateType"];//操作类型
                    tbUKeyLog.summary = context.Request["summary"];//操作说明
                    tbUKeyLog.operateTime = context.Request["operateTime"];//操作时间
                    tbUKeyLog.operatorId = context.Request["operatorId"];//操作人编号
                    tbUKeyLog.operatorName = context.Request["operatorName"];//操作人名称
                    bll.Add(tbUKeyLog);
                    return;
                }

                //修改
                if (context.Request["action"] == "edit")
                {
                    UKeyLogBLL bll = new UKeyLogBLL(context, loginUser);
                    TBUKeyLog tbUKeyLog = new TBUKeyLog();
                    tbUKeyLog.logId = long.Parse(context.Request["logId"]);//日志编号
                    tbUKeyLog.uKeyId = context.Request["uKeyId"];//加密狗编号
                    tbUKeyLog.operateType = context.Request["operateType"];//操作类型
                    tbUKeyLog.summary = context.Request["summary"];//操作说明
                    tbUKeyLog.operateTime = context.Request["operateTime"];//操作时间
                    tbUKeyLog.operatorId = context.Request["operatorId"];//操作人编号
                    tbUKeyLog.operatorName = context.Request["operatorName"];//操作人名称
                    bll.Edit(tbUKeyLog);
                    return;
                }

                //删除
                if (context.Request["action"] == "delete")
                {
                    UKeyLogBLL bll = new UKeyLogBLL(context, loginUser);
                    long logId = long.Parse(context.Request["logId"]);//日志编号
                    bll.Delete(logId);
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

