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
    /// 用户
    /// </summary>
    public class UserHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "User");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载角色列表
                if (context.Request["action"] == "roleListLoad")
                {
                    RoleBLL bll = new RoleBLL(context, loginUser);
                    bll.Combobox();
                    return;
                }

                //加载部门列表
                if (context.Request["action"] == "deptListLoad")
                {
                    DeptBLL bll = new DeptBLL(context, loginUser);
                    bll.Combobox();
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    UserBLL bll = new UserBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string deptId = context.Request["deptId"];
                    string userName = context.Request["userName"];
                    bll.LoadGrid(page, rows, deptId, userName);
                    return;
                }

                //加载信息
                if (context.Request["action"] == "load")
                {
                    UserBLL bll = new UserBLL(context, loginUser);
                    string userId = context.Request["userId"];//用户编号
                    bll.Load(userId);
                    return;
                }

                //增加
                if (context.Request["action"] == "add")
                {
                    UserBLL bll = new UserBLL(context, loginUser);
                    TSUser tsUser = new TSUser();
                    //tsUser.userId= context.Request["userId"];//用户编号
                    tsUser.userName = context.Request["userName"];//用户姓名
                    tsUser.userCode = context.Request["userCode"];//用户帐号
                    tsUser.userPwd = tsUser.userCode;//用户密码
                    tsUser.roleIds = context.Request["roleIds"];//角色编号
                    tsUser.deptId = context.Request["deptId"];//部门编号
                    tsUser.status = context.Request["status"];//使用状态
                    tsUser.post = context.Request["post"];//职务
                    tsUser.telephone = context.Request["telephone"];//联系电话
                    bll.Add(tsUser);
                    return;
                }

                //修改
                if (context.Request["action"] == "edit")
                {
                    UserBLL bll = new UserBLL(context, loginUser);
                    TSUser tsUser = new TSUser();
                    tsUser.userId = context.Request["userId"];//用户编号
                    tsUser.userName = context.Request["userName"];//用户姓名
                    tsUser.userCode = context.Request["userCode"];//用户帐号
                    //tsUser.userPwd = context.Request["userPwd"];//用户密码
                    tsUser.roleIds = context.Request["roleIds"];//角色编号
                    tsUser.deptId = context.Request["deptId"];//部门编号
                    tsUser.status = context.Request["status"];//使用状态
                    tsUser.post = context.Request["post"];//职务
                    tsUser.telephone = context.Request["telephone"];//联系电话
                    bll.Edit(tsUser);
                    return;
                }

                //删除
                if (context.Request["action"] == "delete")
                {
                    UserBLL bll = new UserBLL(context, loginUser);
                    string userId = context.Request["userId"];//用户编号
                    bll.Delete(userId);
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