using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Model.Agent;

namespace Com.ZY.JXKK.WebAction.Agent
{
    /// <summary>
    /// 门店员工
    /// Author:代码生成器
    /// </summary>
    public class StaffHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginAgentUser loginAgentUser = new LoginAgentUser(context, "Staff");
                StaffBLL bll = new StaffBLL(context, loginAgentUser);
                AgentRoleBLL agentRoleBLL = new AgentRoleBLL(context, loginAgentUser);
                if (!loginAgentUser.Pass)//权限验证
                {
                    return;
                }
                string roleType = agentRoleBLL.GetRoleType(loginAgentUser.RoleIds);
                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    if (roleType == "0")
                    {
                        bll.LoadGrid(page, rows, roleType, loginAgentUser.UserId);
                    }
                    else
                    {
                        bll.LoadGrid(page, rows, roleType, bll.Get(loginAgentUser.UserId).siteId);
                    }
                    return;
                }
                //加载门店
                if (context.Request["action"] == "siteListLoad")
                {
                    bll.SiteCombobox(loginAgentUser.UserId, roleType);
                    return;
                }
                //加载角色
                if (context.Request["action"] == "roleListLoad")
                {
                    bll.RoleCombobox();
                    return;
                }
                //加载信息
                if (context.Request["action"] == "load")
                {
                    string staffId = context.Request["staffId"];//员工编号
                    bll.Load(staffId);
                    return;
                }

                //增加
                if (context.Request["action"] == "add")
                {
                    TBStaff tbStaff = new TBStaff();
                    TSAgentUser tsAgentUser = new TSAgentUser();
                    tbStaff.staffId = context.Request["staffId"];//员工编号
                    tbStaff.siteId = context.Request["siteId"];//门店编号
                    tbStaff.staffName = context.Request["staffName"];//员工姓名
                    tbStaff.status = context.Request["status"];//使用状态
                    tbStaff.telephone = context.Request["telephone"];//手机号码
                    tbStaff.IDNumber = context.Request["IDNumber"];//身份证号
                    if (roleType == "0")//角色类型0:代理商 1:门店员工
                    {
                        tbStaff.agentId = loginAgentUser.UserId;
                    }
                    else
                    {
                        tbStaff.agentId = bll.Get(loginAgentUser.UserId).agentId;
                    }
                    tbStaff.address = context.Request["address"];//住址
                    tbStaff.remark = context.Request["remark"];//备注
                    //添加到代理门店用户表
                    tsAgentUser.roleId = context.Request["roleId"];//角色;
                    tsAgentUser.userCode = context.Request["staffCode"];//员工帐号
                    tsAgentUser.userPwd = tsAgentUser.userCode;//帐号密码 默认和帐号一致
                    bll.Add(tbStaff, tsAgentUser);
                    return;
                }

                //修改
                if (context.Request["action"] == "edit")
                {
                    TBStaff tbStaff = new TBStaff();
                    TSAgentUser tsAgentUser = new TSAgentUser();
                    tbStaff.staffId = context.Request["staffId"];//员工编号
                    tbStaff.siteId = context.Request["siteId"];//门店编号
                    tbStaff.staffName = context.Request["staffName"];//员工姓名
                    tbStaff.status = context.Request["status"];//使用状态
                    tbStaff.telephone = context.Request["telephone"];//手机号码
                    tbStaff.IDNumber = context.Request["IDNumber"];//身份证号
                    if (roleType == "0")//角色类型0:代理商 1:门店员工
                    {
                        tbStaff.agentId = loginAgentUser.UserId;
                    }
                    else
                    {
                        tbStaff.agentId = bll.Get(loginAgentUser.UserId).agentId;
                    }
                    tbStaff.address = context.Request["address"];//住址
                    tbStaff.remark = context.Request["remark"];//备注
                    //添加到代理门店用户表
                    tsAgentUser.roleId = context.Request["roleId"];//角色;
                    tsAgentUser.userCode = context.Request["staffCode"];//员工帐号
                    bll.Edit(tbStaff, tsAgentUser);
                    return;
                }

                //删除
                if (context.Request["action"] == "delete")
                {
                    string staffId = context.Request["staffId"];//员工编号
                    bll.Delete(staffId);
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

