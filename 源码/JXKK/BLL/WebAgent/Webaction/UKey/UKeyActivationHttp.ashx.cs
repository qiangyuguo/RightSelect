using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.UKey;
using Com.ZY.JXKK.Model.UKey;
using Com.ZY.JXKK.BLL.Agent;

namespace Com.ZY.JXKK.WebAction.UKey
{
    /// <summary>
    /// UKey信息
    /// Author:代码生成器
    /// </summary>
    public class UKeyActivationHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginAgentUser loginAgentUser = new LoginAgentUser(context, "UKeyActivation");
                AgentRoleBLL agentRoleBLL = new AgentRoleBLL(context, loginAgentUser);
                StaffBLL staffBll = new StaffBLL(context, loginAgentUser);
                if (!loginAgentUser.Pass)//权限验证
                {
                    return;
                }
                //获取用户登录的角色类型 0为 代理商 1 为员工
                string roleType = agentRoleBLL.GetRoleType(loginAgentUser.RoleIds);
                string agentId = "";
                string siteId = context.Request["siteId"];
                if (roleType == "0")
                    agentId = loginAgentUser.UserId;
                if (roleType != "0")
                    siteId = staffBll.Get(loginAgentUser.UserId).siteId;

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    UKeyBLL bll = new UKeyBLL(context, loginAgentUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string uKeyId = context.Request["uKeyId"];
                    string status = context.Request["status"];
                    bll.LoadGrid(page, rows, uKeyId, status, siteId, "", agentId);
                    return;
                }
                //加载快开厅
                if (context.Request["action"] == "ddlStatusListLoad")
                {
                    UKeyBLL bll = new UKeyBLL(context, loginAgentUser);
                    bll.AgentUKeyStatusCombobox();
                    return;
                }

                //激活
                if (context.Request["action"] == "activation")
                {
                    UKeyBLL bll = new UKeyBLL(context, loginAgentUser);
                    string ukeyId = context.Request["ukeyId"];//加密狗编号
                    bll.Activation(ukeyId);
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

