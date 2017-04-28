using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Case;
using Com.ZY.JXKK.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Com.ZY.JXKK.Case.Handler
{
    /// <summary>
    /// ProcessCaseHandler 的摘要说明
    /// </summary>
    public class ProcessCaseHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "TodoCase");
                if (!loginUser.Pass)//权限验证
                    return;

                CaseBLL bll = new CaseBLL(context, loginUser);
                if (context.Request["action"] == "caseGridLoad")
                {
                    //加载DataGrid
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string tbCaseId = context.Request["tbCaseId"];
                    string tbCaseReason = context.Request["tbCaseReason"];
                    string openDateFrom = context.Request["openDateFrom"];
                    string openDateTo = context.Request["openDateTo"];
                    string closeDateFrom = context.Request["closeDateFrom"];
                    string closeDateTo = context.Request["closeDateTo"];
                    string caseState = context.Request["caseState"];
                    string caseCarNo = context.Request["caseCarNo"];
                    string caseType = context.Request["caseType"];
                    bll.LoadGrid(page, rows, tbCaseId, tbCaseReason, openDateFrom, openDateTo, closeDateFrom, closeDateTo, caseState, caseCarNo, caseType, 1);
                }
                else if (context.Request["action"] == "stationListLoad")
                {

                    Combobox com = new Combobox(context, loginUser);
                    com.StationCombobox();
                }
                else if (context.Request["action"] == "treeLoad")
                {
                    var caseId = context.Request["caseId"];
                    bll.LoadTree(caseId);
                }
                else if (context.Request["action"] == "load")
                {
                    var caseId = context.Request["caseId"];
                    //加载信息
                    bll.Load(caseId);
                }
                else if (context.Request["action"] == "enforcementNameGridLoad")
                {
                    var caseId = context.Request["caseId"];
                    var typeId = context.Request["typeId"];
                    if (!string.IsNullOrEmpty(typeId)&&!string.IsNullOrEmpty(caseId))
                    {
                        bll.LoadEnforcementGridByTypeId(caseId,typeId);
                    }
                    else if (!string.IsNullOrEmpty(caseId))
                    {
                        bll.LoadEnforcementGrid(caseId);
                    }
                }
                else if (context.Request["action"] == "readOnlyTreeLoad")
                {
                    var caseId = context.Request["caseId"];
                    bll.ReadOnlyTreeLoad(caseId);
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