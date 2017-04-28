using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Card;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DAO.Agent;

namespace Com.ZY.JXKK.DAO.Card
{
    /// <summary>
    /// 卡片
    /// Author:代码生成器
    /// </summary>
    public class TBCardDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接

        /// <summary>
        /// 根据卡号起始结束获取相应的卡片
        /// </summary>
        /// <param name="startCardId">起始卡号</param>
        /// <param name="endCardId">结束卡号</param>
        /// <returns></returns>
        public List<TBCard> GetListByStartEndCard(string startCardId, string endCardId)
        {
            List<TBCard> list = new List<TBCard>();
            try
            {
                string strSQL = "select * from TBCard where cardId>=:startCardId and cardId<=:endCardId and status='"+(int)CardStatus.StayUsed+"' order by cardId ";
                Param param = new Param();
                param.Clear();
                param.Add(":startCardId", startCardId);
                param.Add(":endCardId", endCardId);
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
        public void Edit(DataAccess data, TBCard tbCard)
        {
            string strSQL = "update TBCard set status=:status,agentId=:agentId,siteId=:siteId where cardId=:cardId";
            Param param = new Param();
            param.Clear();
            param.Add(":status", tbCard.status);//当前状态
            param.Add(":cardId", tbCard.cardId);//卡号
            param.Add(":agentId", tbCard.agentId);//当前状态
            param.Add(":siteId", tbCard.siteId);//卡号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 事务处理卡片发放
        /// </summary>
        /// <param name="tbCardList"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        public void Grant(List<TBCard> tbCardList, string userId, string userName,string siteId)
        {
            ComTransaction trans = null;
            try
            {
                db.Open();
                trans = db.BeginTransaction();
                string agentId = new TBSiteDAO().Get(siteId).agentId;
                foreach (var card in tbCardList)
                {
                    card.status = ((int)CardStatus.StayBinding).ToString();
                    card.agentId = agentId;
                    card.siteId = siteId;
                    TBCardLog tbCardLog = new TBCardLog();
                    tbCardLog.cardId = card.cardId;//卡号
                    tbCardLog.operateType = "2";//操作类型
                    tbCardLog.summary = "发放到[代理商编号:" + agentId + ",门店编号:" + siteId + "]";
                    tbCardLog.operateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//操作时间
                    tbCardLog.operatorId = userId;//操作人编号
                    tbCardLog.operatorName = userName;//操作人名称
                    Edit(db,card);
                    new TBCardLogDAO().Add(db,tbCardLog);
                }
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw e;
            }
            finally
            {
                db.Close();
            }
        }

        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加卡片
        /// <param name="data">数据库连接</param>
        /// <param name="tbCard">卡片</param>
        /// </summary>
        public void Add(DataAccess data,TBCard tbCard)
        {
            string strSQL = "insert into TBCard (cardId,chipId,cardType,status,validateData,supplierDate,supplierCode,supplierBatch,siteId,agentId) values (:cardId,:chipId,:cardType,:status,:validateData,To_date(:supplierDate,'yyyy-mm-dd hh24:mi:ss'),:supplierCode,:supplierBatch,:siteId,:agentId)";
            Param param = new Param();
            param.Clear();
            param.Add(":cardId", tbCard.cardId);//卡号
            param.Add(":chipId", tbCard.chipId);//芯片序号
            param.Add(":cardType", tbCard.cardType);//卡类型
            param.Add(":status", tbCard.status);//当前状态
            param.Add(":validateData", tbCard.validateData);//验证数据
            param.Add(":supplierDate", tbCard.supplierDate);//出厂时间
            param.Add(":supplierCode", tbCard.supplierCode);//厂家代码
            param.Add(":supplierBatch", tbCard.supplierBatch);//厂家批次号
            param.Add(":siteId", tbCard.siteId);//门店编号
            param.Add(":agentId", tbCard.agentId);//代理商编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加卡片
        /// <param name="tbCard">卡片</param>
        /// </summary>
        public void Add(TBCard tbCard)
        {
            try
            {
                db.Open();
                Add(db,tbCard);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
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
                db.Open();
                Edit(db,tbCard);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
        
        /// <summary>
        /// 删除卡片
        /// <param name="data">数据库连接</param>
        /// <param name="cardId">卡号</param>
        /// </summary>
        public void Delete(DataAccess data,string cardId)
        {
            string strSQL = "delete from TBCard where cardId=:cardId";
            Param param = new Param();
            param.Clear();
            param.Add(":cardId", cardId);//卡号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除卡片
        /// <param name="cardId">卡号</param>
        /// </summary>
        public void Delete(string cardId)
        {
            try
            {
                db.Open();
                Delete(db,cardId);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
        
        /// <summary>
        /// 获取卡片
        /// <param name="cardId">卡号</param>
        /// </summary>
        /// <returns>卡片对象</returns>
        public TBCard Get(string cardId)
        {
            TBCard tbCard=null;
            try
            {
                string strSQL = "select * from TBCard where cardId=:cardId";
                Param param = new Param();
                param.Clear();
                param.Add(":cardId", cardId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbCard=ReadData(dr);
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
            return tbCard;
        }
        
        /// <summary>
        /// 获取列表(卡片)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>卡片列表对象</returns>
        public List<TBCard> GetList(string strSQL,Param param)
        {
            List<TBCard> list = new List<TBCard>();
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while(dr.Read())
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
        /// 获取列表(卡片)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>卡片列表对象</returns>
        public List<TBCard> GetList(string field, string value)
        {
            List<TBCard> list = new List<TBCard>();
            try
            {
                string strSQL = "select * from TBCard where " + field + "=:field";
                Param param = new Param();
                param.Clear();
                param.Add(":field",value);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while(dr.Read())
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
        /// 获取DataSet(卡片)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>卡片DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBCard");
        }
        
        /// <summary>
        /// 是否存在记录(卡片)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBCard where " + field + "=:field";
                Param param = new Param();
                param.Clear();
                param.Add(":field",value);
                db.Open();
                num = int.Parse(db.ExecuteScalar(CommandType.Text, strSQL, param).ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
            return num > 0;
        }
        
        /// <summary>
        /// 读取卡片信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>卡片对象</returns>
        private TBCard ReadData(ComDataReader dr)
        {
            TBCard tbCard= new TBCard();
            tbCard.cardId= dr["cardId"].ToString();//卡号
            tbCard.chipId= dr["chipId"].ToString();//芯片序号
            tbCard.cardType= dr["cardType"].ToString();//卡类型
            tbCard.status= dr["status"].ToString();//当前状态
            tbCard.validateData= dr["validateData"].ToString();//验证数据
            if(dr["supplierDate"]==null)
            {
                tbCard.supplierDate= "";//出厂时间
            }
            else
            {
                tbCard.supplierDate= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["supplierDate"]);//出厂时间
            }
            tbCard.supplierCode= dr["supplierCode"].ToString();//厂家代码
            tbCard.supplierBatch= dr["supplierBatch"].ToString();//厂家批次号
            tbCard.siteId= dr["siteId"].ToString();//门店编号
            tbCard.agentId= dr["agentId"].ToString();//代理商编号
            return tbCard;
        }
        
        
        #endregion
        
    }
}

