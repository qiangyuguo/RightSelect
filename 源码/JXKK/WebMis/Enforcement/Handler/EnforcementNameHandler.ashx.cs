using System;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.BLL.Enforcement;

namespace Com.ZY.JXKK.Enforcement.Handler
{
    /// <summary>
    /// 执法文书类型
    /// </summary>
    public class EnforcementNameHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "EnforcementName");
                if (!loginUser.Pass)//权限验证
                    return;

                EnforcementNameBLL bll = new EnforcementNameBLL(context, loginUser);
                if (context.Request["action"] == "gridLoad")
                {
                    //加载DataGrid
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string EnforcementNameId = context.Request["EnforcementNameId"];
                    string EnforcementName = context.Request["EnforcementName"];

                    string EnforcementTypeId = context.Request["EnforcementTypeId"];
                    bll.LoadGrid(page, rows, EnforcementNameId, EnforcementName, EnforcementTypeId);
                }
                else if (context.Request["action"] == "EnforcementTypeListLoad")
                {
                   
                    Combobox com = new Combobox(context, loginUser);
                    com.EnforcementTypeCombobox();
                }
                else if (context.Request["action"] == "TemplateListLoad")
                {
                   
                    Combobox com = new Combobox(context, loginUser);
                    com.EnforcementTemplateCombobox();
                }


                    

                
                else if (context.Request["action"] == "load")
                {
                    //加载信息
                    bll.Load(context.Request["EnforcementNameId"]);
                }
                else if (context.Request["action"] == "add")
                {
                    //增加
                    TBEnforcementName tbEnforcementName = new TBEnforcementName();
                 //   tbEnforcementName.EnforcementNameId = context.Request["EnforcementNameId"];
                    tbEnforcementName.EnforcementName = context.Request["EnforcementName"];
                    tbEnforcementName.EnforcementTypeId = context.Request["EnforcementTypeId"];
                //    tbEnforcementName.FillingTime = context.Request["FillingTime"];
                //    tbEnforcementName.FillingPerson = context.Request["FillPerson"];
                    tbEnforcementName.IsEmpty = context.Request["IsEmpty"];
                    tbEnforcementName.F1 = context.Request["F1"];
                    tbEnforcementName.EnforcementTemplateId = context.Request["EnforcementTemplateId"];
                    
                    bll.Add(tbEnforcementName);
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

                    bll.Edit(tbEnforcementName);
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