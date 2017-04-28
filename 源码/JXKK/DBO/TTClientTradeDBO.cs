using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 客户账户交易
    /// Author:代码生成器
    /// </summary>
    public class TTClientTradeDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加客户账户交易
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientTrade">客户账户交易</param>
        public virtual void Add(DataAccess data,TTClientTrade ttClientTrade)
        {
            string strSQL = "insert into TTClientTrade (tradeId,cardId,clientId,clientName,agentId,siteId,tradeType,fee,remark,changeTime,createTime) values (@tradeId,@cardId,@clientId,@clientName,@agentId,@siteId,@tradeType,@fee,@remark,@changeTime,To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'))";
            Param param = new Param();
            param.Clear();
            param.Add("@tradeId", ttClientTrade.tradeId);//交易流水
            param.Add("@cardId", ttClientTrade.cardId);//卡号
            param.Add("@clientId", ttClientTrade.clientId);//客户编号
            param.Add("@clientName", ttClientTrade.clientName);//客户名称
            param.Add("@agentId", ttClientTrade.agentId);//代理商编号
            param.Add("@siteId", ttClientTrade.siteId);//门店编号
            param.Add("@tradeType", ttClientTrade.tradeType);//交易类型
            param.Add("@fee", ttClientTrade.fee);//发生金额
            param.Add("@remark", ttClientTrade.remark);//信息摘要
            param.Add("@changeTime", ttClientTrade.changeTime);//发生时间
            param.Add("@createTime", ttClientTrade.createTime);//创建时间
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加客户账户交易
        /// </summary>
        /// <param name="ttClientTrade">客户账户交易</param>
        public virtual void Add(TTClientTrade ttClientTrade)
        {
            try
            {
                db.Open();
                Add(db,ttClientTrade);
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
        /// 修改客户账户交易
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientTrade">客户账户交易</param>
        public virtual void Edit(DataAccess data,TTClientTrade ttClientTrade)
        {
            string strSQL = "update TTClientTrade set cardId=@cardId,clientId=@clientId,clientName=@clientName,agentId=@agentId,siteId=@siteId,tradeType=@tradeType,fee=@fee,remark=@remark,changeTime=@changeTime,createTime=To_date(@createTime,'yyyy-mm-dd hh24:mi:ss') where tradeId=@tradeId";
            Param param = new Param();
            param.Clear();
            param.Add("@cardId", ttClientTrade.cardId);//卡号
            param.Add("@clientId", ttClientTrade.clientId);//客户编号
            param.Add("@clientName", ttClientTrade.clientName);//客户名称
            param.Add("@agentId", ttClientTrade.agentId);//代理商编号
            param.Add("@siteId", ttClientTrade.siteId);//门店编号
            param.Add("@tradeType", ttClientTrade.tradeType);//交易类型
            param.Add("@fee", ttClientTrade.fee);//发生金额
            param.Add("@remark", ttClientTrade.remark);//信息摘要
            param.Add("@changeTime", ttClientTrade.changeTime);//发生时间
            param.Add("@createTime", ttClientTrade.createTime);//创建时间
            param.Add("@tradeId", ttClientTrade.tradeId);//交易流水
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改客户账户交易
        /// </summary>
        /// <param name="ttClientTrade">客户账户交易</param>
        public virtual void Edit(TTClientTrade ttClientTrade)
        {
            try
            {
                db.Open();
                Edit(db,ttClientTrade);
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
        /// 删除客户账户交易
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tradeId">交易流水</param>
        public virtual void Delete(DataAccess data,string tradeId)
        {
            string strSQL = "delete from TTClientTrade where tradeId=@tradeId";
            Param param = new Param();
            param.Clear();
            param.Add("@tradeId", tradeId);//交易流水
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除客户账户交易
        /// </summary>
        /// <param name="tradeId">交易流水</param>
        public virtual void Delete(string tradeId)
        {
            try
            {
                db.Open();
                Delete(db,tradeId);
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
        /// 获取客户账户交易
        /// </summary>
        /// <param name="tradeId">交易流水</param>
        /// <returns>客户账户交易对象</returns>
        public virtual TTClientTrade Get(string tradeId)
        {
            TTClientTrade ttClientTrade=null;
            try
            {
                string strSQL = "select * from TTClientTrade where tradeId=@tradeId";
                Param param = new Param();
                param.Clear();
                param.Add("@tradeId", tradeId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttClientTrade=ReadData(dr);
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
            return ttClientTrade;
        }
        
        /// <summary>
        /// 获取列表(客户账户交易)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>客户账户交易列表对象</returns>
        public virtual List<TTClientTrade> GetList(string strSQL,Param param)
        {
            List<TTClientTrade> list = new List<TTClientTrade>();
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
        /// 获取列表(客户账户交易)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>客户账户交易列表对象</returns>
        public virtual List<TTClientTrade> GetList(string field, string value)
        {
            List<TTClientTrade> list = new List<TTClientTrade>();
            try
            {
                string strSQL = "select * from TTClientTrade where " + field + "=@field";
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
        /// 获取DataSet(客户账户交易)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>客户账户交易DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTClientTrade");
        }
        
        /// <summary>
        /// 是否存在记录(客户账户交易)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTClientTrade where " + field + "=@field";
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
        /// 读取客户账户交易信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>客户账户交易对象</returns>
        protected virtual TTClientTrade ReadData(ComDataReader dr)
        {
            TTClientTrade ttClientTrade= new TTClientTrade();
            ttClientTrade.tradeId= dr["tradeId"].ToString();//交易流水
            ttClientTrade.cardId= dr["cardId"].ToString();//卡号
            ttClientTrade.clientId= long.Parse(dr["clientId"].ToString());//客户编号
            ttClientTrade.clientName= dr["clientName"].ToString();//客户名称
            ttClientTrade.agentId= dr["agentId"].ToString();//代理商编号
            ttClientTrade.siteId= dr["siteId"].ToString();//门店编号
            ttClientTrade.tradeType= dr["tradeType"].ToString();//交易类型
            ttClientTrade.fee= double.Parse(dr["fee"].ToString());//发生金额
            ttClientTrade.remark= dr["remark"].ToString();//信息摘要
            ttClientTrade.changeTime= dr["changeTime"].ToString();//发生时间
            if(dr["createTime"]==null)
            {
                ttClientTrade.createTime= "";//创建时间
            }
            else
            {
                ttClientTrade.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            return ttClientTrade;
        }
        
        
        #endregion
        
    }
}

