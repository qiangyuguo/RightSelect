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
    /// 登录
    /// </summary>
    public class LoginHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser();
                if (context.Request["action"] == "login")
                {
                    string userCode = context.Request.Form["userCode"].Trim();
                    string userPwd = context.Request.Form["userPwd"];
                    loginUser.Login(context, userCode, userPwd);
                }
                else if (context.Request["action"] == "logout")
                {
                    loginUser.Remove(context);
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