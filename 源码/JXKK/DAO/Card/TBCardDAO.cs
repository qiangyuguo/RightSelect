using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;
using Com.ZY.JXKK.DAO.Agent;

namespace Com.ZY.JXKK.DAO.Card
{
    /// <summary>
    /// 卡片
    /// Author:开发人员自行扩展
    /// </summary>
    public class TBCardDAO : TBCardDBO
    {
        /// <summary>
        /// 根据卡号起始结束获取相应的卡片
        /// </summary>
        /// <param name="startCardId">起始卡号</param>
        /// <param name="endCardId">结束卡号</param>
        /// <param name="operaType">0 发放 1 回收</param>
        /// <returns></returns>
        public List<TBCard> GetListByStartEndCard(string startCardId, string endCardId, int operaType)
        {
            List<TBCard> list = new List<TBCard>();
            try
            {
                string strSQL = "";
                if (operaType == 0)
                    strSQL = "select * from TBCard where cardId>=@startCardId and cardId<=@endCardId and status='" + (int)CardStatus.StayUsed + "' order by cardId ";
                if (operaType == 1)
                    strSQL = "select * from TBCard where cardId>=@startCardId and cardId<=@endCardId and status='" + (int)CardStatus.StayBinding + "' order by cardId ";
                Param param = new Param();
                param.Clear();
                param.Add("@startCardId", startCardId);
                param.Add("@endCardId", endCardId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while (dr.Read())
                {
                    list.Add(ReadData(dr));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
            return list;
        }
        /// <summary>
        /// 修改卡片
        /// <param name="data">数据库连接</param>
        /// <param name="tbCard">卡片</param>
        /// </summary>
        public void GrantEdit(DataAccess data, TBCard tbCard)
        {
            string strSQL = "update TBCard set status=@status,agentId=@agentId,siteId=@siteId where cardId=@cardId";
            Param param = new Param();
            param.Clear();
            param.Add("@status", tbCard.status);//当前状态
            param.Add("@cardId", tbCard.cardId);//卡号
            param.Add("@agentId", tbCard.agentId);//代理商
            param.Add("@siteId", tbCard.siteId);//门店
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        // <summary>
        /// 修改卡片
        /// <param name="data">数据库连接</param>
        /// <param name="tbCard">卡片</param>
        /// </summary>
        public void RecycleEdit(DataAccess data, TBCard tbCard)
        {
            string strSQL = "update TBCard set status=@status,agentId='',siteId='' where cardId=@cardId";
            Param param = new Param();
            param.Clear();
            param.Add("@status", tbCard.status);//当前状态
            param.Add("@cardId", tbCard.cardId);//卡号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        /// <summary>
        /// 事务处理卡片发放
        /// </summary>
        /// <param name="tbCardList"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        public string Grant(List<TBCard> tbCardList, string userId, string userName, string siteId)
        {
            ComTransaction trans = null;
            string cardId = "";
            db.Open();
            foreach (var card in tbCardList)
            {
                try
                {
                    trans = db.BeginTransaction();
                    string agentId = new TBSiteDAO().Get(siteId).agentId;
                    card.status = ((int)CardStatus.StayBinding).ToString();
                    card.agentId = agentId;
                    card.siteId = siteId;
                    GrantEdit(db, card);
                    TBCardLog tbCardLog = new TBCardLog();
                    tbCardLog.cardId = card.cardId;//卡号
                    tbCardLog.operateType = "2";//操作类型
                    tbCardLog.summary = "发放到[代理商编号:" + agentId + ",门店编号:" + siteId + "]";
                    tbCardLog.operateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//操作时间
                    tbCardLog.operatorId = userId;//操作人编号
                    tbCardLog.operatorName = userName;//操作人名称
                    new TBCardLogDAO().Add(db, tbCardLog);
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    cardId = card.cardId;
                    throw e;
                }
            }
            db.Close();
            return cardId;
        }


        /// <summary>
        /// 事务处理卡片回收
        /// </summary>
        /// <param name="tbCardList"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        public string Recycle(List<TBCard> tbCardList, string userId, string userName)
        {
            ComTransaction trans = null;
            string cardId = "";
            db.Open();
            foreach (var card in tbCardList)
            {
                try
                {
                    trans = db.BeginTransaction();
                    card.status = ((int)CardStatus.StayUsed).ToString();
                    RecycleEdit(db, card);
                    TBCardLog tbCardLog = new TBCardLog();
                    tbCardLog.cardId = card.cardId;//卡号
                    tbCardLog.operateType = "2";//操作类型
                    tbCardLog.summary = "回收[代理商编号:" + card.agentId + ",门店编号:" + card.siteId + "]";
                    tbCardLog.operateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//操作时间
                    tbCardLog.operatorId = userId;//操作人编号
                    tbCardLog.operatorName = userName;//操作人名称
                    new TBCardLogDAO().Add(db, tbCardLog);
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    cardId = card.cardId;
                    throw e;
                }
            }
            db.Close();
            return cardId;
        }
        /// <summary>
        /// 修改卡片
        /// <param name="data">数据库连接</param>
        /// <param name="tbCard">卡片</param>
        /// </summary>
        public override void Edit(DataAccess data, TBCard tbCard)
        {
            string strSQL = "update TBCard set status=@status where cardId=@cardId";
            Param param = new Param();
            param.Clear();
            param.Add("@status", tbCard.status);//当前状态
            param.Add("@cardId", tbCard.cardId);//卡号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
    }
}

