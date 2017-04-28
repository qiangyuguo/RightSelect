using System;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.WebAction
{
    /// <summary>
    /// 系统主界面
    /// </summary>
    public class MainHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginAgentUser loginAgentUser = new LoginAgentUser(context, "");
                MainAgentBll bll = new MainAgentBll(context, loginAgentUser);
                if (!loginAgentUser.Pass)//权限验证
                    return;

                if (context.Request["action"] == "load")
                {//加载主界面

                    bll.LoadMain();
                }
                if (context.Request["action"] == "check")
                {//刷新主界面
                    Message.success(context, "系统正常");
                }
                else if (context.Request["action"] == "changePwd")
                {//修改密码
                    string oldPwd = context.Request.Form["oldPwd"];
                    string newPwd = context.Request.Form["newPwd"];
                    bll.ChangePwd(oldPwd, newPwd);
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