using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Card;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.Card
{
    /// <summary>
    /// 卡片
    /// Author:代码生成器
    /// </summary>
    public class CardBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBCardDAO tbCardDAO = new TBCardDAO();
        private TBCardLogDAO tbCardLogDAO = new TBCardLogDAO();
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public CardBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows,string cardId, string status, string supplierCode, string supplierBatch,string agentId,string siteId)
        {
            string strSQL = "select s.sitename,a.agentname,c.* from TBCard c left join tbsite s on c.siteid=s.siteid left join tbagent a on  c.agentid=a.agentid where 1=1 ";
            if (!string.IsNullOrEmpty(cardId))
                strSQL += " and c.cardId='"+cardId+"'";
            if (!string.IsNullOrEmpty(status))
                strSQL += " and c.status='" + status + "'";
            if (!string.IsNullOrEmpty(supplierCode))
                strSQL += " and c.supplierCode='" + supplierCode + "'";
            if (!string.IsNullOrEmpty(supplierBatch))
                strSQL += " and c.supplierBatch='" + supplierBatch + "'";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and c.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and c.siteId='" + siteId + "'";
            strSQL += " order by c.cardId";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定卡片
        /// <param name="cardId">卡号</param>
        /// </summary>
        public void Load(string cardId)
        {
            try
            {
                TBCard tbCard=tbCardDAO.Get(cardId);
                WebJson.ToJson(context, tbCard);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 发放卡片
        /// <param name="tbCard">卡片</param>
        /// </summary>
        public void Grant(string startCardId, string endCardId, int cardNum,string siteId)
        {
            try
            {
                List<TBCard> tbCardList = tbCardDAO.GetListByStartEndCard(startCardId, endCardId,0);
                //判断起始卡号-结束卡号和数量是否相等
                if (cardNum != tbCardList.Count)
                {
                    Message.error(context, "起始卡号:" + startCardId + "至" + endCardId + "和数量" + cardNum + "所对应的卡片不相符");
                }
                else
                {
                    //遍历修改卡片的状态为待绑并且将卡片发放的信息保存到卡片日志表中
                    string cardId = tbCardDAO.Grant(tbCardList, loginSession.GetUserId(), loginSession.GetUserName(), siteId);
                    if (cardId != "")
                        Message.success(context, "卡片发放部分成功至:" + cardId);
                    Message.success(context, "卡片发放成功");
                    loginSession.Log("起始卡号:" + startCardId + "至" + endCardId + "，数量" + cardNum + "卡片发放成功");
                }
            }
            catch (Exception e)
            {
                Message.error(context, "卡片发放失败");
                loginSession.Log(e.Message);
            }
        }


        /// <summary>
        /// 回收卡片
        /// <param name="tbCard">卡片</param>
        /// </summary>
        public void Recycle(string startCardId, string endCardId, int cardNum)
        {
            try
            {
                List<TBCard> tbCardList = tbCardDAO.GetListByStartEndCard(startCardId, endCardId,1);
                //判断起始卡号-结束卡号和数量是否相等
                if (cardNum != tbCardList.Count)
                {
                    Message.error(context, "起始卡号:" + startCardId + "至" + endCardId + "和数量" + cardNum + "所对应的卡片不相符");
                }
                else
                {
                    //遍历修改卡片的状态为待用并且将卡片回收的信息保存到卡片日志表中
                    string cardId = tbCardDAO.Recycle(tbCardList, loginSession.GetUserId(), loginSession.GetUserName());
                    if (cardId != "")
                        Message.success(context, "卡片回收部分成功至:" + cardId);
                    Message.success(context, "卡片回收成功");
                    loginSession.Log("起始卡号:" + startCardId + "至" + endCardId + "，数量" + cardNum + "卡片回收成功");
                }
            }
            catch (Exception e)
            {
                Message.error(context, "卡片回收失败");
                loginSession.Log(e.Message);
            }
        }
        /// <summary>
        /// 修改卡片
        /// <param name="tbCard">卡片</param>
        /// </summary>
        public void Edit(TBCard tbCard)
        {
            try
            {
                tbCardDAO.Edit(tbCard);
                Message.success(context, "卡片操作成功");
                loginSession.Log(tbCard.cardId+"卡片操作成功");
            }
            catch (Exception e)
            {
                Message.error(context, "卡片操作失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除卡片
        /// <param name="cardId">卡号</param>
        /// </summary>
        public void Delete(string cardId)
        {
            try
            {
                tbCardDAO.Delete(cardId);
                Message.success(context, "卡片删除成功");
                loginSession.Log("XXXXXX卡片删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "卡片删除失败");
                loginSession.Log(e.Message);
            }
        }

       
       
    }
}

