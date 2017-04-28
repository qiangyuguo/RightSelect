using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.UKey;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.UKey.Handler
{
    /// <summary>
    /// UKey信息
    /// Author:代码生成器
    /// </summary>
    public class UKeyGrantHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "UKeyGrant");
                SiteBLL siteBll = new SiteBLL(context, loginUser);
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
                    string siteName = context.Request["siteName"];
                    siteBll.LoadGrid(page, rows, siteId, siteName, ((int)AuditStauts.AuditSucces).ToString());
                    return;
                }

                //加载信息
                if (context.Request["action"] == "load")
                {
                    //加载信息
                    siteBll.Load(context.Request["siteId"]);
                }

                //发放
                if (context.Request["action"] == "grant")
                {
                    UKeyBLL bll = new UKeyBLL(context, loginUser);
                    string siteId = context.Request["siteId"];//执法文书名称编号
                    string startUKeyId = context.Request["startUKeyId"];//起始号
                    string endUKeyId = context.Request["endUKeyId"];//结束号
                    int uKeyNum = int.Parse(context.Request["uKeyNum"]);//终端数量
                    bll.Grant(siteId, startUKeyId, endUKeyId, uKeyNum);
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