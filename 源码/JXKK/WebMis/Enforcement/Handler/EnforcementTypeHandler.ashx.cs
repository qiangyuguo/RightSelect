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
    public class EnforcementTypeHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "EnforcementType");
                if (!loginUser.Pass)//权限验证
                    return;

                EnforcementTypeBLL bll = new EnforcementTypeBLL(context, loginUser);
                if (context.Request["action"] == "gridLoad")
                {
                    //加载DataGrid
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string EnforcementTypeId = context.Request["EnforcementTypeId"];
                    string EnforcementTypeName = context.Request["EnforcementTypeName"];
                    string PunishmentTypeId = context.Request["PunishmentTypeId"];

                    bll.LoadGrid(page, rows, EnforcementTypeId, EnforcementTypeName, PunishmentTypeId);
                }
                
                
                else if (context.Request["action"] == "load")
                {
                    //加载信息
                    bll.Load(context.Request["EnforcementTypeId"]);
                }
                else if (context.Request["action"] == "PunishmentTypeListLoad")
                {
                    //夹在所属处罚类型
                    
                    Combobox com = new Combobox(context, loginUser);
                    com.PunishmentTypeCombobox();
                }


                else if (context.Request["action"] == "add")
                {
                    //增加
                    TBEnforcementType tbEnforcementType = new TBEnforcementType();
                    tbEnforcementType.EnforcementTypeId = context.Request["EnforcementTypeId"];
                    tbEnforcementType.EnforcementTypeName = context.Request["EnforcementTypeName"];
                    tbEnforcementType.PunishmentType = context.Request["PunishmentType"];
                    bll.Add(tbEnforcementType);
                }
                else if (context.Request["action"] == "edit")
                {
                    //修改
                    TBEnforcementType tbEnforcementType = new TBEnforcementType();
                    tbEnforcementType.EnforcementTypeId = context.Request["EnforcementTypeId"];
                    tbEnforcementType.EnforcementTypeName = context.Request["EnforcementTypeName"];
                    tbEnforcementType.PunishmentType = context.Request["PunishmentType"];
                    bll.Edit(tbEnforcementType);
                }
                
                else if (context.Request["action"] == "delete")
                {
                    //删除
                    string siteId = context.Request["EnforcementTypeId"];
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