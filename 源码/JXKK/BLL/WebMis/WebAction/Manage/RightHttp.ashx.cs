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
    /// 权限
    /// </summary>
    public class RightHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "Right");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载树
                if (context.Request["action"] == "treeLoad")
                {
                    ModuleBLL bll = new ModuleBLL(context, loginUser);
                    string roleId = context.Request["roleId"];
                    bll.LoadTree(roleId);
                    return;
                }

                //加载角色列表
                if (context.Request["action"] == "roleList")
                {
                    RoleBLL bll = new RoleBLL(context, loginUser);
                    bll.Combobox();
                    return;
                }

                //保存权限
                if (context.Request["action"] == "save")
                {
                    RightBLL bll = new RightBLL(context, loginUser);
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