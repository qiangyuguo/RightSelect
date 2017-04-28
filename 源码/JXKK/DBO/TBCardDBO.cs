using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 卡片
    /// Author:代码生成器
    /// </summary>
    public class TBCardDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加卡片
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbCard">卡片</param>
        public virtual void Add(DataAccess data,TBCard tbCard)
        {
            string strSQL = "insert into TBCard (cardId,chipId,cardType,status,validateData,supplierDate,supplierCode,supplierBatch,siteId,agentId,createDate) values (@cardId,@chipId,@cardType,@status,@validateData,@supplierDate,@supplierCode,@supplierBatch,@siteId,@agentId,To_date(@createDate,'yyyy-mm-dd hh24:mi:ss'))";
            Param param = new Param();
            param.Clear();
            param.Add("@cardId", tbCard.cardId);//卡号
            param.Add("@chipId", tbCard.chipId);//芯片序号
            param.Add("@cardType", tbCard.cardType);//卡类型
            param.Add("@status", tbCard.status);//当前状态
            param.Add("@validateData", tbCard.validateData);//验证数据
            param.Add("@supplierDate", tbCard.supplierDate);//出厂日期
            param.Add("@supplierCode", tbCard.supplierCode);//厂家代码
            param.Add("@supplierBatch", tbCard.supplierBatch);//厂家批次号
            param.Add("@siteId", tbCard.siteId);//门店编号
            param.Add("@agentId", tbCard.agentId);//代理商编号
            param.Add("@createDate", tbCard.createDate);//创建时间
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加卡片
        /// </summary>
        /// <param name="tbCard">卡片</param>
        public virtual void Add(TBCard tbCard)
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
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbCard">卡片</param>
        public virtual void Edit(DataAccess data,TBCard tbCard)
        {
            string strSQL = "update TBCard set chipId=@chipId,cardType=@cardType,status=@status,validateData=@validateData,supplierDate=@supplierDate,supplierCode=@supplierCode,supplierBatch=@supplierBatch,siteId=@siteId,agentId=@agentId,createDate=To_date(@createDate,'yyyy-mm-dd hh24:mi:ss') where cardId=@cardId";
            Param param = new Param();
            param.Clear();
            param.Add("@chipId", tbCard.chipId);//芯片序号
            param.Add("@cardType", tbCard.cardType);//卡类型
            param.Add("@status", tbCard.status);//当前状态
            param.Add("@validateData", tbCard.validateData);//验证数据
            param.Add("@supplierDate", tbCard.supplierDate);//出厂日期
            param.Add("@supplierCode", tbCard.supplierCode);//厂家代码
            param.Add("@supplierBatch", tbCard.supplierBatch);//厂家批次号
            param.Add("@siteId", tbCard.siteId);//门店编号
            param.Add("@agentId", tbCard.agentId);//代理商编号
            param.Add("@createDate", tbCard.createDate);//创建时间
            param.Add("@cardId", tbCard.cardId);//卡号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改卡片
        /// </summary>
        /// <param name="tbCard">卡片</param>
        public virtual void Edit(TBCard tbCard)
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
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="cardId">卡号</param>
        public virtual void Delete(DataAccess data,string cardId)
        {
            string strSQL = "delete from TBCard where cardId=@cardId";
            Param param = new Param();
            param.Clear();
            param.Add("@cardId", cardId);//卡号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除卡片
        /// </summary>
        /// <param name="cardId">卡号</param>
        public virtual void Delete(string cardId)
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
        /// </summary>
        /// <param name="cardId">卡号</param>
        /// <returns>卡片对象</returns>
        public virtual TBCard Get(string cardId)
        {
            TBCard tbCard=null;
            try
            {
                string strSQL = "select * from TBCard where cardId=@cardId";
                Param param = new Param();
                param.Clear();
                param.Add("@cardId", cardId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbCard=ReadData(dr);
                }
                dr.Close();
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
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>卡片列表对象</returns>
        public virtual List<TBCard> GetList(string strSQL,Param param)
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
                dr.Close();
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
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>卡片列表对象</returns>
        public virtual List<TBCard> GetList(string field, string value)
        {
            List<TBCard> list = new List<TBCard>();
            try
            {
                string strSQL = "select * from TBCard where " + field + "=@field";
                Param param = new Param();
                param.Clear();
                param.Add("@field",value);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while(dr.Read())
                {
                    list.Add(ReadData(dr));
                }
                dr.Close();
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
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>卡片DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBCard");
        }
        
        /// <summary>
        /// 是否存在记录(卡片)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBCard where " + field + "=@field";
                Param param = new Param();
                param.Clear();
                param.Add("@field",value);
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
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>卡片对象</returns>
        protected virtual TBCard ReadData(ComDataReader dr)
        {
            TBCard tbCard= new TBCard();
            tbCard.cardId= dr["cardId"].ToString();//卡号
            tbCard.chipId= dr["chipId"].ToString();//芯片序号
            tbCard.cardType= dr["cardType"].ToString();//卡类型
            tbCard.status= dr["status"].ToString();//当前状态
            tbCard.validateData= dr["validateData"].ToString();//验证数据
            tbCard.supplierDate= dr["supplierDate"].ToString();//出厂日期
            tbCard.supplierCode= dr["supplierCode"].ToString();//厂家代码
            tbCard.supplierBatch= dr["supplierBatch"].ToString();//厂家批次号
            tbCard.siteId= dr["siteId"].ToString();//门店编号
            tbCard.agentId= dr["agentId"].ToString();//代理商编号
            if(dr["createDate"]==null)
            {
                tbCard.createDate= "";//创建时间
            }
            else
            {
                tbCard.createDate= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createDate"]);//创建时间
            }
            return tbCard;
        }
        
        
        #endregion
        
    }
}

