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
    /// 终端入库
    /// Author:代码生成器
    /// </summary>
    public class TerminalStoreHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "TerminalStore");
                TerminalBLL bll = new TerminalBLL(context, loginUser);
                if (!loginUser.Pass)//权限验证
                {
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