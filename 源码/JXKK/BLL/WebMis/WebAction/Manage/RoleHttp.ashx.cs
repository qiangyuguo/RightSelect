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
    /// 角色 
    /// </summary>
    public class RoleHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "Role");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    RoleBLL bll = new RoleBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    bll.LoadGrid(page, rows);
                    return;
                }

                //加载信息
                if (context.Request["action"] == "load")
                {
                    RoleBLL bll = new RoleBLL(context, loginUser);
                    string roleId = context.Request["roleId"];//角色编号
                    bll.Load(roleId);
                    return;
                }

                //增加
                if (context.Request["action"] == "add")
                {
                    RoleBLL bll = new RoleBLL(context, loginUser);
                    TSRole tsRole = new TSRole();
                    //tsRole.roleId = context.Request["roleId"];//角色编号
                    tsRole.roleName = context.Request["roleName"];//角色名称
                    tsRole.status = context.Request["status"];//使用状态
                    bll.Add(tsRole);
                    return;
                }

                //修改
                if (context.Request["action"] == "edit")
                {
                    RoleBLL bll = new RoleBLL(context, loginUser);
                    TSRole tsRole = new TSRole();
                    tsRole.roleId = context.Request["roleId"];//角色编号
                    tsRole.roleName = context.Request["roleName"];//角色名称
                    tsRole.status = context.Request["status"];//使用状态
                    bll.Edit(tsRole);
                    return;
                }

                //删除
                if (context.Request["action"] == "delete")
                {
                    RoleBLL bll = new RoleBLL(context, loginUser);
                    string roleId = context.Request["roleId"];//角色编号
                    bll.Delete(roleId);
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