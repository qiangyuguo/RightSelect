using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Model.Agent;
using Com.ZY.JXKK.BLL;

namespace Com.ZY.JXKK.WebAction.Agent
{
    /// <summary>
    /// 代理快开厅用户
    /// Author:代码生成器
    /// </summary>
    public class AgentUserHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AgentUser");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    AgentUserBLL bll = new AgentUserBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    bll.LoadGrid(page, rows);
                    return;
                }

                //加载信息
                if (context.Request["action"] == "load")
                {
                    AgentUserBLL bll = new AgentUserBLL(context, loginUser);
                    string userCode = context.Request["userCode"];//用户帐号
                    bll.Load(userCode);
                    return;
                }

                //增加
                if (context.Request["action"] == "add")
                {
                    AgentUserBLL bll = new AgentUserBLL(context, loginUser);
                    TSAgentUser tsAgentUser = new TSAgentUser();
                    tsAgentUser.userCode = context.Request["userCode"];//用户帐号
                    tsAgentUser.userPwd = context.Request["userPwd"];//用户密码
                    tsAgentUser.roleId = context.Request["roleId"];//角色编号
                    tsAgentUser.userId = context.Request["userId"];//关联用户编号
                    bll.Add(tsAgentUser);
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

