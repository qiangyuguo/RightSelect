using System;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.Model.Agent;

namespace Com.ZY.JXKK.WebAction.Agent
{
    /// <summary>
    /// 代理商模块
    /// </summary>
    public class AgentModuleHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AgentModule");
                if (!loginUser.Pass)//权限验证
                    return;

                AgentModuleBLL bll = new AgentModuleBLL(context, loginUser);
                if (context.Request["action"] == "treeLoad")
                {//加载树
                    bll.LoadTree("xx");
                }
                else if (context.Request["action"] == "load")
                {//加载信息
                    bll.Load(context.Request["moduleId"]);
                }
                else if (context.Request["action"] == "add")
                {//增加
                    TSAgentModule agentModule = new TSAgentModule();
                    agentModule.moduleCode = context.Request.Form["moduleCode"];//模块代码
                    agentModule.moduleName = context.Request.Form["moduleName"];//模块名称
                    agentModule.moduleURL = context.Request.Form["moduleURL"];//模块URL
                    agentModule.imgClass = context.Request.Form["imgClass"];//模块图片样式
                    agentModule.parentId = context.Request.Form["parentId"];//父模块编号（"0"代表无父模块）
                    agentModule.moduleLayer = int.Parse(context.Request.Form["moduleLayer"]);//模块所属层次
                    agentModule.moduleIndex = int.Parse(context.Request.Form["moduleIndex"]);//模块索引
                    bll.Add(agentModule);
                }
                else if (context.Request["action"] == "edit")
                {//修改
                    TSAgentModule agentModule = new TSAgentModule();
                    agentModule.moduleId = context.Request["moduleId"];//模块编号
                    agentModule.moduleCode = context.Request.Form["moduleCode"];//模块代码
                    agentModule.moduleName = context.Request.Form["moduleName"];//模块名称
                    agentModule.parentId = context.Request.Form["parentId"];//父模块编号（"0"代表无父模块）
                    agentModule.moduleURL = context.Request.Form["moduleURL"];//模块URL
                    agentModule.imgClass = context.Request.Form["imgClass"];//模块图片样式
                    agentModule.moduleIndex = int.Parse(context.Request["moduleIndex"]);//排列顺序
                    bll.Edit(agentModule);
                }
                else if (context.Request["action"] == "delete")
                {//删除
                    string moduleId = context.Request["moduleId"];
                    bll.Delete(moduleId);
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