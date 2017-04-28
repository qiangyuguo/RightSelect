using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Card;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.Model.Card;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.WebAction.Card
{
    /// <summary>
    /// 卡片
    /// Author:代码生成器
    /// </summary>
    public class CardGrantHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "CardGrant");
                CardBLL bll = new CardBLL(context, loginUser);
                SiteBLL siteBll = new SiteBLL(context, loginUser);
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string siteId = context.Request["siteId"];
                    string siteName = context.Request["siteName"];
                    siteBll.LoadGrid(page, rows, siteId, siteName, ((int)AuditStauts.AuditSucces).ToString());
                    return;
                }
                if (context.Request["action"] == "load")
                {
                    //加载信息
                    siteBll.Load(context.Request["siteId"]);
                }
                //发放
                if (context.Request["action"] == "add")
                {
                    string siteId = context.Request["siteId"];//快开厅编号
                    string startCardId = context.Request["startCardId"];//起始卡号
                    string endCardId = context.Request["endCardId"];//结束卡号
                    int cardNum = int.Parse(context.Request["cardNum"]);//卡片数量
                    bll.Grant(startCardId, endCardId, cardNum, siteId);
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