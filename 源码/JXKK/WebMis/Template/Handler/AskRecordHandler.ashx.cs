using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Case;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Com.ZY.JXKK.Template.Handler
{
    /// <summary>
    /// AskRecordHandler 的摘要说明
    /// </summary>
    public class AskRecordHandler :   IHttpHandler, IRequiresSessionState
    {


        public void ProcessRequest(HttpContext context)
        {
            LoginUser loginUser = new LoginUser(context, "TodoCase");
            if (!loginUser.Pass)//权限验证
                return;

            AskRecordBLL bll = new AskRecordBLL(context, loginUser);
            if (context.Request["action"] == "load")
            {
                var caseId = context.Request["caseId"];
                //检查是否有记录: 有,加载记录;无,仅加载车辆,站点信息
                //加载信息
                if (bll.IsExist(caseId))
                {
                    bll.Load(caseId);
                }
                else
                {
                    bll.OnlyLoadCaseCarNoAndStationName(caseId);
                }

            }
            else if (context.Request["action"] == "addOrUpdate")
            {
                bll.AddOrUpdate(context);
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