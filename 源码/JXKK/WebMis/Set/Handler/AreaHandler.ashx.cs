using System;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL.Set;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.Set.Handler
{
    /// <summary>
    /// 区域
    /// </summary>
    public class AreaHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "Area");
                if (!loginUser.Pass)//权限验证
                    return;

                AreaBLL bll = new AreaBLL(context, loginUser);
                if (context.Request["action"] == "treeLoad")
                {//加载树
                    bll.LoadTree();
                }
                else if (context.Request["action"] == "load")
                {//加载信息
                    bll.Load(context.Request["areaId"]);
                }
                else if (context.Request["action"] == "add")
                {//增加
                    TBArea area = new TBArea();
                    area.areaCode = context.Request.Form["areaCode"];
                    area.areaName = context.Request.Form["areaName"];
                    area.isUse = context.Request.Form["isUse"];
                    area.parentId = context.Request.Form["parentId"];
                    area.areaLayer = int.Parse(context.Request.Form["areaLayer"]);
                    area.areaIndex = int.Parse(context.Request.Form["areaIndex"]);
                    bll.Add(area);
                }
                else if (context.Request["action"] == "edit")
                {//修改
                    TBArea area = new TBArea();
                    area.areaId = context.Request["areaId"];
                    area.areaCode = context.Request.Form["areaCode"];
                    area.areaName = context.Request.Form["areaName"];
                    area.parentId = context.Request.Form["parentId"];
                    area.isUse = context.Request.Form["isUse"];
                    area.areaIndex = int.Parse(context.Request.Form["areaIndex"]);
                    bll.Edit(area);
                }
                else if (context.Request["action"] == "delete")
                {//删除
                    string areaId = context.Request["areaId"];
                    bll.Delete(areaId);
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