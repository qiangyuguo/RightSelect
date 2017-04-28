using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Card;
using Com.ZY.JXKK.Model.Card;

namespace Com.ZY.JXKK.WebAction.Card
{
    /// <summary>
    /// 卡片
    /// Author:代码生成器
    /// </summary>
    public class CardHttp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "CardSearch");
                CardBLL bll = new CardBLL(context, loginUser);
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }

                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    string cardId = context.Request["cardId"];
                    string status = context.Request["status"];
                    string supplierCode = context.Request["supplierCode"];
                    string supplierBatch = context.Request["supplierBatch"];
                    bll.LoadGrid(page, rows, cardId, status, supplierCode, supplierBatch);
                    return;
                }
                if (context.Request["action"] == "ddlStatusListLoad")
                {
                    bll.CardStatusCombobox();
                    return;
                }
                if (context.Request["action"] == "ddlSiteListLoad")
                {
                    bll.SiteCombobox();
                    return;
                }
                //发放
                if (context.Request["action"] == "grent")
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