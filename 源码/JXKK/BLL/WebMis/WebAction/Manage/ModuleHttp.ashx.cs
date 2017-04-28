using System;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Manage;
using Com.ZY.JXKK.Model.Manage;

namespace Com.ZY.JXKK.WebAction.Manage
{
    /// <summary>
    /// 模块
    /// </summary>
    public class ModuleHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "Module");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载树
                if (context.Request["action"] == "treeLoad")
                {
                    ModuleBLL bll = new ModuleBLL(context, loginUser);
                    bll.LoadTree("XX");
                    return;
                }

                //加载信息
                if (context.Request["action"] == "load")
                {
                    ModuleBLL bll = new ModuleBLL(context, loginUser);
                    string moduleId = context.Request["moduleId"];//模块编号
                    bll.Load(moduleId);
                    return;
                }

                //增加
                if (context.Request["action"] == "add")
                {
                    ModuleBLL bll = new ModuleBLL(context, loginUser);
                    TSModule tsModule = new TSModule();
                    //tsModule.moduleId = context.Request["moduleId"];//模块编号
                    tsModule.moduleCode = context.Request["moduleCode"];//模块代码
                    tsModule.moduleName = context.Request["moduleName"];//模块名称
                    tsModule.moduleURL = context.Request["moduleURL"];//模块路径
                    tsModule.imgClass = context.Request["imgClass"];//图片样式
                    tsModule.parentId = context.Request["parentId"];//父模块编号
                    tsModule.moduleLayer = int.Parse(context.Request["moduleLayer"]);//模块层次
                    tsModule.moduleIndex = int.Parse(context.Request["moduleIndex"]);//排列顺序
                    bll.Add(tsModule);
                    return;
                }

                //修改
                if (context.Request["action"] == "edit")
                {
                    ModuleBLL bll = new ModuleBLL(context, loginUser);
                    TSModule tsModule = new TSModule();
                    tsModule.moduleId = context.Request["moduleId"];//模块编号
                    tsModule.moduleCode = context.Request["moduleCode"];//模块代码
                    tsModule.moduleName = context.Request["moduleName"];//模块名称
                    tsModule.moduleURL = context.Request["moduleURL"];//模块路径
                    tsModule.imgClass = context.Request["imgClass"];//图片样式
                    //tsModule.parentId = context.Request["parentId"];//父模块编号
                    //tsModule.moduleLayer = int.Parse(context.Request["moduleLayer"]);//模块层次
                    tsModule.moduleIndex = int.Parse(context.Request["moduleIndex"]);//排列顺序
                    bll.Edit(tsModule);
                    return;
                }

                //删除
                if (context.Request["action"] == "delete")
                {
                    ModuleBLL bll = new ModuleBLL(context, loginUser);
                    string moduleId = context.Request["moduleId"];//模块编号
                    bll.Delete(moduleId);
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