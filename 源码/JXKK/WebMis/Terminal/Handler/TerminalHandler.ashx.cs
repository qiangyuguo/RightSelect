using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Terminal;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.Terminal.Handler
{
    /// <summary>
    /// 终端
    /// Author:代码生成器
    /// </summary>
    public class TerminalHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "TerminalSearch");
                TerminalBLL bll = new TerminalBLL(context, loginUser);
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string siteId = context.Request["siteId"];
                    string terminalId = context.Request["terminalId"];
                    string status = context.Request["status"];
                    string supplierCode = context.Request["supplierCode"];
                    string supplierBatch = context.Request["supplierBatch"];
                    bll.LoadGrid(page, rows, terminalId, status, supplierCode, supplierBatch, "", siteId);
                    return;
                }
                if (context.Request["action"] == "ddlSiteListLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.SiteAllCombobox();
                }
                if (context.Request["action"] == "ddlStatusListLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.TerminalStatusCombobox();
                }
                //加载信息
                if (context.Request["action"] == "load")
                {
                    string terminalId = context.Request["terminalId"];//终端编号
                    bll.Load(terminalId);
                    return;
                }
                //回收
                if (context.Request["action"] == "recycle")
                {
                    string startTerminalId = context.Request["startTerminalId"];//起始终端号
                    string endTerminalId = context.Request["endTerminalId"];//结束终端号
                    int terminalNum = int.Parse(context.Request["terminalNum"]);//终端数量
                    bll.Recycle(startTerminalId, endTerminalId, terminalNum);
                    return;
                }
                //修改
                if (context.Request["action"] == "edit")
                {
                    TBTerminal tbTerminal = new TBTerminal();
                    tbTerminal.terminalId = context.Request["terminalId"];//终端编号
                    tbTerminal.status = (int.Parse(context.Request["status"])).ToString();//状态
                    bll.Maintence(tbTerminal);
                    return;
                }
                //修改
                if (context.Request["action"] == "updateStatusEdit")
                {
                    TBTerminal tbTerminal = new TBTerminal();
                    tbTerminal.terminalId = context.Request["terminalId"];//终端编号
                    tbTerminal.updateStatus = context.Request["updateStatus"];//更新状态
                    bll.EditUpdateStatus(tbTerminal);
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

