using System;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.Model.Agent;

namespace Com.ZY.JXKK.WebAction.Agent
{
    /// <summary>
    /// 快开厅
    /// </summary>
    public class SiteHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "SiteAdd");
                if (!loginUser.Pass)//权限验证
                    return;

                SiteBLL bll = new SiteBLL(context, loginUser);
                if (context.Request["action"] == "gridLoad")
                {
                    //加载DataGrid
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string siteId = context.Request["siteId"];
                    string siteName = context.Request["siteName"];
                    string auditStatus = context.Request["auditStatus"];
                    bll.LoadGrid(page, rows, siteId, siteName, auditStatus);
                }
                else if (context.Request["action"] == "agentListLoad")
                {
                    //加载代理商列表
                    bll.AgentCombobox();
                }
                else if (context.Request["action"] == "auditListLoad")
                {
                    //加载审核状态列表
                    bll.AuditCombobox();
                }
                else if (context.Request["action"] == "load")
                {
                    //加载信息
                    bll.Load(context.Request["siteId"]);
                }
                else if (context.Request["action"] == "add")
                {
                    //增加
                    TBSite tbSite = new TBSite();
                    tbSite.siteId = context.Request["siteId"];
                    tbSite.siteName = context.Request["siteName"];
                    tbSite.agentId = context.Request["agentId"];
                    tbSite.contact = context.Request["contact"];
                    tbSite.address = context.Request["address"];
                    tbSite.telephone = context.Request["telephone"];
                    tbSite.status = "0";
                    tbSite.auditStatus = ((int)AuditStauts.NotAudit).ToString();
                    tbSite.remark = context.Request["remark"];
                    bll.Add(tbSite);
                }
                else if (context.Request["action"] == "edit")
                {
                    //修改
                    TBSite tbSite = new TBSite();
                    tbSite.siteId = context.Request["siteId"];
                    tbSite.siteName = context.Request["siteName"];
                    tbSite.agentId = context.Request["agentId"];
                    tbSite.contact = context.Request["contact"];
                    tbSite.address = context.Request["address"];
                    tbSite.telephone = context.Request["telephone"];
                    tbSite.status = context.Request["status"];
                    tbSite.auditStatus = ((int)AuditStauts.AuditSucces).ToString();
                    tbSite.remark = context.Request["remark"];
                    bll.Edit(tbSite);
                }
                else if (context.Request["action"] == "audit")
                {
                    //审核
                    TBSite tbSite = new TBSite();
                    tbSite.siteId = context.Request["siteId"];
                    tbSite.auditStatus = context.Request["auditStatus"];
                    if (tbSite.auditStatus == ((int)AuditStauts.AuditSucces).ToString())
                        tbSite.status = "1";
                    else
                        tbSite.status = "0";
                    tbSite.remark = context.Request["remark"];
                    bll.Audit(tbSite);
                }
                else if (context.Request["action"] == "delete")
                {
                    //删除
                    string siteId = context.Request["siteId"];
                    bll.Delete(siteId);
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