using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Terminal;
using Com.ZY.JXKK.Model.Terminal;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.WebAction.Terminal
{
    /// <summary>
    /// 终端
    /// Author:代码生成器
    /// </summary>
    public class TerminalHttp : IHttpHandler, IRequiresSessionState
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
                    string terminalId = context.Request["terminalId"];
                    string status = context.Request["status"];
                    string supplierCode = context.Request["supplierCode"];
                    string supplierBatch = context.Request["supplierBatch"];
                    bll.LoadGrid(page, rows, terminalId, status, supplierCode, supplierBatch);
                    return;
                }
                if (context.Request["action"] == "ddlSiteListLoad")
                {
                    bll.SiteCombobox();
                    return;
                }
                if (context.Request["action"] == "ddlStatusListLoad")
                {
                    bll.TerminalStatusCombobox();
                    return;
                }
                //加载信息
                if (context.Request["action"] == "load")
                {
                    string terminalId = context.Request["terminalId"];//终端编号
                    bll.Load(terminalId);
                    return;
                }

                //增加
                if (context.Request["action"] == "add")
                {
                    TBTerminal tbTerminal = new TBTerminal();
                    tbTerminal.terminalId = context.Request["terminalId"];//终端编号
                    tbTerminal.status = ((int)TerminalStatus.InStore).ToString();//当前状态
                    tbTerminal.terminalType = context.Request["terminalType"];//终端类型
                    tbTerminal.supplierDate = context.Request["supplierDate"];//出厂时间
                    tbTerminal.supplierCode = context.Request["supplierCode"];//厂家代码
                    tbTerminal.supplierBatch = context.Request["supplierBatch"];//厂家批次号
                    bll.Add(tbTerminal);
                    return;
                }
                //发放
                if (context.Request["action"] == "grent")
                {
                    string siteId = context.Request["siteId"];//快开厅编号
                    string startTerminalId = context.Request["startTerminalId"];//起始终端号
                    string endTerminalId = context.Request["endTerminalId"];//结束终端号
                    int terminalNum = int.Parse(context.Request["terminalNum"]);//终端数量
                    bll.Grant(siteId, startTerminalId, endTerminalId, terminalNum);
                    return;
                }
                //修改
                if (context.Request["action"] == "edit")
                {
                    TBTerminal tbTerminal = new TBTerminal();
                    tbTerminal.terminalId = context.Request["terminalId"];//终端编号
                    tbTerminal.status = context.Request["status"];//当前状态
                    tbTerminal.terminalType = context.Request["terminalType"];//终端类型
                    tbTerminal.supplierDate = context.Request["supplierDate"];//出厂时间
                    tbTerminal.supplierCode = context.Request["supplierCode"];//厂家代码
                    tbTerminal.supplierBatch = context.Request["supplierBatch"];//厂家批次号
                    tbTerminal.siteId = context.Request["siteId"];//门店编号
                    tbTerminal.agentId = context.Request["agentId"];//代理商编号
                    bll.Edit(tbTerminal);
                    return;
                }

                //删除
                if (context.Request["action"] == "delete")
                {
                    string terminalId = context.Request["terminalId"];//终端编号
                    bll.Delete(terminalId);
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

