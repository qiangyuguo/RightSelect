using System;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.Sys.Handler
{
    /// <summary>
    /// 系统主界面
    /// </summary>
    public class MainHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "");
                if (!loginUser.Pass)//权限验证
                    return;

                if (context.Request["action"] == "load")
                {//加载主界面
                    MainBll bll = new MainBll(context, loginUser);
                    bll.LoadMain();
                }
                if (context.Request["action"] == "check")
                {//刷新主界面
                    Message.success(context, "系统正常");
                }
                else if (context.Request["action"] == "changePwd")
                {
                    //修改密码
                    MainBll bll = new MainBll(context, loginUser);
                    string oldPwd = context.Request.Form["oldPwd"];
                    string newPwd = context.Request.Form["newPwd"];
                    bll.ChangePwd(oldPwd, newPwd);
                }
                //else if (context.Request["action"] == "gridLoadMeeting")
                //{//加载会议表格
                //    MeetingBll bll = new MeetingBll(context, loginUser);
                //    int page = int.Parse(context.Request["page"]);
                //    int rows = int.Parse(context.Request["rows"]);
                //    bll.LoadGrid(page, rows);
                //}
                //else if (context.Request["action"] == "loadMeeting")
                //{//加载会议信息
                //    MeetingBll bll = new MeetingBll(context, loginUser);
                //    bll.Load(context.Request["meetingId"]);
                //}
                //else if (context.Request["action"] == "gridLoadPublication")
                //{//加载公告通知表格
                //    PublicationBll bll = new PublicationBll(context, loginUser);
                //    int page = int.Parse(context.Request["page"]);
                //    int rows = int.Parse(context.Request["rows"]);
                //    bll.LoadGrid(page, rows);
                //}
                //else if (context.Request["action"] == "loadPublication")
                //{//加载公告通知信息
                //    PublicationBll bll = new PublicationBll(context, loginUser);
                //    bll.Load(context.Request["publicationId"]);
                //}
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