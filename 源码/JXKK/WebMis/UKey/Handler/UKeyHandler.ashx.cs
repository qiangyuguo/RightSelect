using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.UKey;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.UKey.Handler
{
    /// <summary>
    /// UKey信息
    /// Author:代码生成器
    /// </summary>
    public class UKeyHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "UKeySearch");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    UKeyBLL bll = new UKeyBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string uKeyId = context.Request["uKeyId"];
                    string status = context.Request["status"];
                    string siteName = context.Request["siteName"];
                    string agentName = context.Request["agentName"];
                    bll.LoadGrid(page, rows, uKeyId, status, siteName, agentName, "");
                    return;
                }
                if (context.Request["action"] == "ddlStatusListLoad")
                {
                    Combobox com = new Combobox(context, loginUser);
                    com.UKeyStatusCombobox();
                    return;
                }
                //回收
                if (context.Request["action"] == "recycle")
                {
                    UKeyBLL bll = new UKeyBLL(context, loginUser);
                    string startUKeyId = context.Request["startUKeyId"];//起始号
                    string endUKeyId = context.Request["endUKeyId"];//结束号
                    int uKeyNum = int.Parse(context.Request["uKeyNum"]);//终端数量
                    bll.Recycle(startUKeyId, endUKeyId, uKeyNum);
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