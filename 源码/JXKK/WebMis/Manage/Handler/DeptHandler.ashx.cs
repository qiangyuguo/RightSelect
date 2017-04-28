using System;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Manage;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.Manage.Handler
{
    /// <summary>
    /// 部门
    /// </summary>
    public class DeptHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "Dept");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    DeptBLL bll = new DeptBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    bll.LoadGrid(page, rows);
                    return;
                }

                //加载信息
                if (context.Request["action"] == "load")
                {
                    DeptBLL bll = new DeptBLL(context, loginUser);
                    string deptId = context.Request["deptId"];//部门编号
                    bll.Load(deptId);
                    return;
                }

                //增加
                if (context.Request["action"] == "add")
                {
                    DeptBLL bll = new DeptBLL(context, loginUser);
                    TSDept tsDept = new TSDept();
                    //tsDept.deptId= context.Request["deptId"];//部门编号
                    tsDept.status = context.Request["status"];//使用状态
                    tsDept.deptName = context.Request["deptName"];//部门名称
                    tsDept.telephone = context.Request["telephone"];//联系电话
                    bll.Add(tsDept);
                    return;
                }

                //修改
                if (context.Request["action"] == "edit")
                {
                    DeptBLL bll = new DeptBLL(context, loginUser);
                    TSDept tsDept = new TSDept();
                    tsDept.deptId = context.Request["deptId"];//部门编号
                    tsDept.status = context.Request["status"];//使用状态
                    tsDept.deptName = context.Request["deptName"];//部门名称
                    tsDept.telephone = context.Request["telephone"];//联系电话
                    bll.Edit(tsDept);
                    return;
                }

                //删除
                if (context.Request["action"] == "delete")
                {
                    DeptBLL bll = new DeptBLL(context, loginUser);
                    string deptId = context.Request["deptId"];//部门编号
                    bll.Delete(deptId);
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