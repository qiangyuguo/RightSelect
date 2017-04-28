using System;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.BLL.Case;

namespace Com.ZY.JXKK.Case.Handler
{
    /// <summary>
    /// 执法文书类型
    /// </summary>
    public class TodoCaseHandler : IHttpHandler, IRequiresSessionState
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
                    bll.LoadGrid(page, rows, tbCaseId, tbCaseReason, openDateFrom, openDateTo, closeDateFrom, closeDateTo, caseState, caseCarNo, caseType,0);
                }
                else if (context.Request["action"] == "stationListLoad")
                {

                    Combobox com = new Combobox(context, loginUser);
                    com.StationCombobox();
                }
                else if (context.Request["action"] == "load")
                {
                    var caseId = context.Request["caseId"];
                    //加载信息
                    bll.Load(caseId);
                }
                else if (context.Request["action"] == "edit")
                {
                    //修改
                    TBCase tbCase = new TBCase();
                    tbCase.CaseId = context.Request["CaseId"].ToString();//
                    tbCase.CaseReason = context.Request["CaseReason"].ToString();
                    tbCase.CaseFrom = context.Request["CaseFrom"].ToString();
                    tbCase.CasePersonName = context.Request["CasePersonName"].ToString();
                    tbCase.CasePersonSex = context.Request["CasePersonSex"].ToString();//
                    tbCase.CasePersonAge = context.Request["CasePersonAge"].ToString();//
                    tbCase.CasePersonAddress = context.Request["CasePersonAddress"].ToString();//
                    tbCase.CasePersonRepresentative = context.Request["CasePersonRepresentative"].ToString();//
                    tbCase.CasePersonCompanyName = context.Request["CasePersonCompanyName"].ToString();//
                    tbCase.CasePersonCompanyLegalPerson = context.Request["CasePersonCompanyLegalPerson"].ToString();//
                    tbCase.CasePersonCompanyLegalRepresentative = context.Request["CasePersonCompanyLegalRepresentative"].ToString();//
                    tbCase.CasePersonCompanyLegalAgent = context.Request["CasePersonCompanyLegalAgent"].ToString();//
                    tbCase.CaseOpenDate = context.Request["CaseOpenDate"].ToString();//
                    tbCase.CaseCloseDate = context.Request["CaseCloseDate"].ToString();//
                    tbCase.CaseFillingDate = context.Request["CaseFillingDate"].ToString();//
                    tbCase.CaseExpirationDate = context.Request["CaseExpirationDate"].ToString();//
                    tbCase.CaseExecutive = context.Request["CaseExecutive"].ToString();//
                    //tbCase.StationName = context.Request["StationName"].ToString();//
                    tbCase.CaseProcessPersonOne = context.Request["CaseProcessPersonOne"].ToString();//
                    tbCase.CaseProcessPersonOneEnforcementNumberOne = context.Request["CaseProcessPersonOneEnforcementNumberOne"].ToString();//
                    tbCase.CaseProcessPersonTwo = context.Request["CaseProcessPersonTwo"].ToString();//
                    tbCase.CaseProcessPersonOneEnforcementNumberTwo = context.Request["CaseProcessPersonOneEnforcementNumberTwo"].ToString();//
                    tbCase.CaseProcessPersonThree = context.Request["CaseProcessPersonThree"].ToString();//
                    tbCase.CaseProcessPersonOneEnforcementNumberThree = context.Request["CaseProcessPersonOneEnforcementNumberThree"].ToString();//
                   // tbCase.CaseCarNo = context.Request["CaseCarNo"].ToString();
                    //tbCase.CaseResult = context.Request["CaseResult"].ToString();//
                    //tbCase.CaseTypeName = context.Request["caseType"].ToString();//
                    //tbCase.CaseStateName = "立案";//
                    //tbCase.CreateDate = DateTime.Now.ToString();//
                    //tbCase.CreateUserName = loginUser.UserName;//
                    bll.Edit(tbCase);
                    // bll.Edit(tbEnforcementName);
                }

                else if (context.Request["action"] == "delete")
                {
                    //删除
                    string caseId = context.Request["caseId"];
                    bll.Delete(caseId);
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