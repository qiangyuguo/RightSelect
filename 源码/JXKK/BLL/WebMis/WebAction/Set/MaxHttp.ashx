<%@ WebHandler Language="C#" Class="Com.ZY.JXKK.WebAction.Set.MaxHttp" %>

using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL.Set;
using Com.ZY.JXKK.Model.Set;

namespace Com.ZY.JXKK.WebAction.Set
{
    /// <summary>
    /// 最大值表
    /// Author:代码生成器
    /// </summary>
    public class MaxHttp: IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "Max");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }
                
                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    MaxBLL bll = new MaxBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    bll.LoadGrid(page, rows);
                    return;
                }
                
                //加载信息
                if (context.Request["action"] == "load")
                {
                    MaxBLL bll = new MaxBLL(context, loginUser);
                    string tabName=context.Request["tabName"];//表名
                    bll.Load(tabName);
                    return;
                }
                
                //增加
                if (context.Request["action"] == "add")
                {
                    MaxBLL bll = new MaxBLL(context, loginUser);
                    TSMax tsMax= new TSMax();
                    tsMax.tabName= context.Request["tabName"];//表名
                    tsMax.codex= context.Request["codex"];//规则
                    tsMax.userValue= long.Parse(context.Request["userValue"]);//流水值
                    tsMax.remark= context.Request["remark"];//备注
                    bll.Add(tsMax);
                    return;
                }
                
                //修改
                if (context.Request["action"] == "edit")
                {
                    MaxBLL bll = new MaxBLL(context, loginUser);
                    TSMax tsMax= new TSMax();
                    tsMax.tabName= context.Request["tabName"];//表名
                    tsMax.codex= context.Request["codex"];//规则
                    tsMax.userValue= long.Parse(context.Request["userValue"]);//流水值
                    tsMax.remark= context.Request["remark"];//备注
                    bll.Edit(tsMax);
                    return;
                }
                
                //删除
                if (context.Request["action"] == "delete")
                {
                    MaxBLL bll = new MaxBLL(context, loginUser);
                    string tabName=context.Request["tabName"];//表名
                    bll.Delete(tabName);
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

