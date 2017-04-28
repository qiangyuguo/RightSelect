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
    public class CaseHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "AddCase");
                if (!loginUser.Pass)//权限验证
                    return;

                CaseBLL bll = new CaseBLL(context, loginUser);
                if (context.Request["action"] == "carGridLoad")
                {
                    //加载DataGrid
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string stationName = context.Request["stationName"];
                    string carNo = context.Request["carNo"];
                    string fromDate = context.Request["fromDate"];
                    string toDate = context.Request["toDate"];
                    string axialType = context.Request["axialType"];
                    bll.LoadCarGrid(page, rows, stationName, carNo,fromDate,toDate,axialType);
                }
                else if (context.Request["action"] == "stationListLoad")
                {

                    Combobox com = new Combobox(context, loginUser);
                    com.StationCombobox();
                }
                else if (context.Request["action"] == "load")
                {
                    var carNo = context.Request["carNo"];
                    var stationName = context.Request["stationName"];
                    //加载信息
                    bll.Load(carNo,stationName);
                }
                else if (context.Request["action"] == "add")
                {
                    //增加
                    TBCase tbCase = new TBCase();
                    tbCase.CaseId = context.Request["CaseId"];//
                    tbCase.CaseReason = context.Request["CaseReason"];
                    tbCase.CaseFrom = context.Request["CaseFrom"];
                    tbCase.CasePersonName = context.Request["CasePersonName"];
                    tbCase.CasePersonSex = context.Request["CasePersonSex"];//
                    tbCase.CasePersonAge = context.Request["CasePersonAge"];//
                    tbCase.CasePersonAddress = context.Request["CasePersonAddress"];//
                    tbCase.CasePersonRepresentative = context.Request["CasePersonRepresentative"];//
                    tbCase.CasePersonCompanyName = context.Request["CasePersonCompanyName"];//
                    tbCase.CasePersonCompanyLegalPerson = context.Request["CasePersonCompanyLegalPerson"];//
                    tbCase.CasePersonCompanyLegalRepresentative = context.Request["CasePersonCompanyLegalRepresentative"];//
                    tbCase.CasePersonCompanyLegalAgent = context.Request["CasePersonCompanyLegalAgent"];//
                    tbCase.CaseOpenDate = context.Request["CaseOpenDate"];//
                    tbCase.CaseCloseDate = context.Request["CaseCloseDate"];//
                    tbCase.CaseFillingDate = context.Request["CaseFillingDate"];//
                    tbCase.CaseExpirationDate = context.Request["CaseExpirationDate"];//
                    tbCase.CaseExecutive = context.Request["CaseExecutive"];//
                    tbCase.StationName = context.Request["StationName"];//
                    tbCase.CaseProcessPersonOne = context.Request["CaseProcessPersonOne"];//
                    tbCase.CaseProcessPersonOneEnforcementNumberOne = context.Request["CaseProcessPersonOneEnforcementNumberOne"];//
                    tbCase.CaseProcessPersonTwo = context.Request["CaseProcessPersonTwo"];//
                    tbCase.CaseProcessPersonOneEnforcementNumberTwo = context.Request["CaseProcessPersonOneEnforcementNumberTwo"];//
                    tbCase.CaseProcessPersonThree = context.Request["CaseProcessPersonThree"];//
                    tbCase.CaseProcessPersonOneEnforcementNumberThree = context.Request["CaseProcessPersonOneEnforcementNumberThree"];//
                    tbCase.CaseCarNo = context.Request["CaseCarNo"];
                    tbCase.CaseResult = context.Request["CaseResult"];//
                    //tbCase.CaseTypeName = context.Request["caseType"];//
                    
                    tbCase.CaseTypeName = context.Request["caseType"];
                    tbCase.CaseStateName = "立案";//
                    tbCase.CreateDate = DateTime.Now.ToString();//
                    tbCase.CreateUserName = loginUser.UserName;//
                    bll.Add(tbCase);
                }
                else if (context.Request["action"] == "edit")
                {
                    //修改
                    TBEnforcementName tbEnforcementName = new TBEnforcementName();
                    tbEnforcementName.EnforcementNameId = context.Request["EnforcementNameId"];
                    tbEnforcementName.EnforcementName = context.Request["EnforcementName"];
                    tbEnforcementName.EnforcementTypeId = context.Request["EnforcementTypeId"];
                    tbEnforcementName.FillingTime = context.Request["FillingTime"];
                    tbEnforcementName.FillingPerson = context.Request["FillingPerson"];
                    tbEnforcementName.IsEmpty = context.Request["IsEmpty"];
                    tbEnforcementName.F1 = context.Request["F1"];

                   // bll.Edit(tbEnforcementName);
                }

                else if (context.Request["action"] == "delete")
                {
                    //删除
                    string EnforcementNameId = context.Request["EnforcementNameId"];
                    bll.Delete(EnforcementNameId);
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