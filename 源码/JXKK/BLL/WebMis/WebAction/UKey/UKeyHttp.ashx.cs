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
    /// UKey信息
    /// Author:代码生成器
    /// </summary>
    public class UKeyHttp : IHttpHandler, IRequiresSessionState
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
                    UKeyBLL bll = new UKeyBLL(context, loginUser);
                    bll.UKeyStatusCombobox();
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