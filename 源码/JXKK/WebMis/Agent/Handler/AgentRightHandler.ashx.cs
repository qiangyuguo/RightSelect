using System;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.Agent.Handler
{
    /// <summary>
    /// 权限
    /// </summary>
    public class AgentRightHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AgentRight");
                if (!loginUser.Pass)//权限验证
                    return;

                if (context.Request["action"] == "treeLoad")
                {//加载树
                    AgentModuleBLL bll = new AgentModuleBLL(context, loginUser);
                    bll.LoadTree(context.Request["roleId"]);
                }
                else if (context.Request["action"] == "roleList")
                {//加载角色列表
                    Combobox com = new Combobox(context, loginUser);
                    com.AgentRoleCombobox();
                }
                else if (context.Request["action"] == "save")
                {//保存权限
                    AgentRightBLL bll = new AgentRightBLL(context, loginUser);
                    string roleId = context.Request["roleId"];
                    string moduleIds = context.Request["moduleIds"];
                    List<string> moduleIdList = new List<string>();
                    string[] strArray = moduleIds.Split(',');
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (!"0".Equals(strArray[i]) && !"".Equals(strArray[i]))
                            moduleIdList.Add(strArray[i]);
                    }
                    bll.Save(roleId, moduleIdList);
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