using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 积分投注
    /// Author:代码生成器
    /// </summary>
    public class TTPointOrderDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加积分投注
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttPointOrder">积分投注</param>
        public virtual void Add(DataAccess data,TTPointOrder ttPointOrder)
        {
            string strSQL = "insert into TTPointOrder (orderId,agentId,siteId,terminalId,clientId,clientName,cardId,gameId,period,betCodes,betPoint,betTime,orderStatus,orderTime,awardResult,awardPoint,awardTime,createTime,srcType) values (@orderId,@agentId,@siteId,@terminalId,@clientId,@clientName,@cardId,@gameId,@period,@betCodes,@betPoint,@betTime,@orderStatus,@orderTime,@awardResult,@awardPoint,@awardTime,To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'),@srcType)";
            Param param = new Param();
            param.Clear();
            param.Add("@orderId", ttPointOrder.orderId);//订单号
            param.Add("@agentId", ttPointOrder.agentId);//代理商编号
            param.Add("@siteId", ttPointOrder.siteId);//门店编号
            param.Add("@terminalId", ttPointOrder.terminalId);//终端编号
            param.Add("@clientId", ttPointOrder.clientId);//客户编号
            param.Add("@clientName", ttPointOrder.clientName);//客户名称
            param.Add("@cardId", ttPointOrder.cardId);//卡号
            param.Add("@gameId", ttPointOrder.gameId);//游戏编号
            param.Add("@period", ttPointOrder.period);//期次
            param.Add("@betCodes", ttPointOrder.betCodes);//投注串
            param.Add("@betPoint", ttPointOrder.betPoint);//投注积分
            param.Add("@betTime", ttPointOrder.betTime);//投注时间
            param.Add("@orderStatus", ttPointOrder.orderStatus);//订单状态
            param.Add("@orderTime", ttPointOrder.orderTime);//撤销时间
            param.Add("@awardResult", ttPointOrder.awardResult);//中奖状态
            param.Add("@awardPoint", ttPointOrder.awardPoint);//中奖积分
            param.Add("@awardTime", ttPointOrder.awardTime);//返奖时间
            param.Add("@createTime", ttPointOrder.createTime);//创建时间
            param.Add("@srcType", ttPointOrder.srcType);//数据来源方式
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加积分投注
        /// </summary>
        /// <param name="ttPointOrder">积分投注</param>
        public virtual void Add(TTPointOrder ttPointOrder)
        {
            try
            {
                db.Open();
                Add(db,ttPointOrder);
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
        /// 修改积分投注
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttPointOrder">积分投注</param>
        public virtual void Edit(DataAccess data,TTPointOrder ttPointOrder)
        {
            string strSQL = "update TTPointOrder set agentId=@agentId,siteId=@siteId,terminalId=@terminalId,clientId=@clientId,clientName=@clientName,cardId=@cardId,gameId=@gameId,period=@period,betCodes=@betCodes,betPoint=@betPoint,betTime=@betTime,orderStatus=@orderStatus,orderTime=@orderTime,awardResult=@awardResult,awardPoint=@awardPoint,awardTime=@awardTime,createTime=To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'),srcType=@srcType where orderId=@orderId";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", ttPointOrder.agentId);//代理商编号
            param.Add("@siteId", ttPointOrder.siteId);//门店编号
            param.Add("@terminalId", ttPointOrder.terminalId);//终端编号
            param.Add("@clientId", ttPointOrder.clientId);//客户编号
            param.Add("@clientName", ttPointOrder.clientName);//客户名称
            param.Add("@cardId", ttPointOrder.cardId);//卡号
            param.Add("@gameId", ttPointOrder.gameId);//游戏编号
            param.Add("@period", ttPointOrder.period);//期次
            param.Add("@betCodes", ttPointOrder.betCodes);//投注串
            param.Add("@betPoint", ttPointOrder.betPoint);//投注积分
            param.Add("@betTime", ttPointOrder.betTime);//投注时间
            param.Add("@orderStatus", ttPointOrder.orderStatus);//订单状态
            param.Add("@orderTime", ttPointOrder.orderTime);//撤销时间
            param.Add("@awardResult", ttPointOrder.awardResult);//中奖状态
            param.Add("@awardPoint", ttPointOrder.awardPoint);//中奖积分
            param.Add("@awardTime", ttPointOrder.awardTime);//返奖时间
            param.Add("@createTime", ttPointOrder.createTime);//创建时间
            param.Add("@srcType", ttPointOrder.srcType);//数据来源方式
            param.Add("@orderId", ttPointOrder.orderId);//订单号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改积分投注
        /// </summary>
        /// <param name="ttPointOrder">积分投注</param>
        public virtual void Edit(TTPointOrder ttPointOrder)
        {
            try
            {
                db.Open();
                Edit(db,ttPointOrder);
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
        /// 删除积分投注
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="orderId">订单号</param>
        public virtual void Delete(DataAccess data,string orderId)
        {
            string strSQL = "delete from TTPointOrder where orderId=@orderId";
            Param param = new Param();
            param.Clear();
            param.Add("@orderId", orderId);//订单号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除积分投注
        /// </summary>
        /// <param name="orderId">订单号</param>
        public virtual void Delete(string orderId)
        {
            try
            {
                db.Open();
                Delete(db,orderId);
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
        /// 获取积分投注
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <returns>积分投注对象</returns>
        public virtual TTPointOrder Get(string orderId)
        {
            TTPointOrder ttPointOrder=null;
            try
            {
                string strSQL = "select * from TTPointOrder where orderId=@orderId";
                Param param = new Param();
                param.Clear();
                param.Add("@orderId", orderId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttPointOrder=ReadData(dr);
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
            return ttPointOrder;
        }
        
        /// <summary>
        /// 获取列表(积分投注)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>积分投注列表对象</returns>
        public virtual List<TTPointOrder> GetList(string strSQL,Param param)
        {
            List<TTPointOrder> list = new List<TTPointOrder>();
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
        /// 获取列表(积分投注)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>积分投注列表对象</returns>
        public virtual List<TTPointOrder> GetList(string field, string value)
        {
            List<TTPointOrder> list = new List<TTPointOrder>();
            try
            {
                string strSQL = "select * from TTPointOrder where " + field + "=@field";
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
        /// 获取DataSet(积分投注)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>积分投注DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTPointOrder");
        }
        
        /// <summary>
        /// 是否存在记录(积分投注)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTPointOrder where " + field + "=@field";
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
        /// 读取积分投注信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>积分投注对象</returns>
        protected virtual TTPointOrder ReadData(ComDataReader dr)
        {
            TTPointOrder ttPointOrder= new TTPointOrder();
            ttPointOrder.orderId= dr["orderId"].ToString();//订单号
            ttPointOrder.agentId= dr["agentId"].ToString();//代理商编号
            ttPointOrder.siteId= dr["siteId"].ToString();//门店编号
            ttPointOrder.terminalId= dr["terminalId"].ToString();//终端编号
            ttPointOrder.clientId= long.Parse(dr["clientId"].ToString());//客户编号
            ttPointOrder.clientName= dr["clientName"].ToString();//客户名称
            ttPointOrder.cardId= dr["cardId"].ToString();//卡号
            ttPointOrder.gameId= dr["gameId"].ToString();//游戏编号
            ttPointOrder.period= dr["period"].ToString();//期次
            ttPointOrder.betCodes= dr["betCodes"].ToString();//投注串
            ttPointOrder.betPoint= long.Parse(dr["betPoint"].ToString());//投注积分
            ttPointOrder.betTime= dr["betTime"].ToString();//投注时间
            ttPointOrder.orderStatus= dr["orderStatus"].ToString();//订单状态
            ttPointOrder.orderTime= dr["orderTime"].ToString();//撤销时间
            ttPointOrder.awardResult= dr["awardResult"].ToString();//中奖状态
            ttPointOrder.awardPoint= long.Parse(dr["awardPoint"].ToString());//中奖积分
            ttPointOrder.awardTime= dr["awardTime"].ToString();//返奖时间
            if(dr["createTime"]==null)
            {
                ttPointOrder.createTime= "";//创建时间
            }
            else
            {
                ttPointOrder.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            ttPointOrder.srcType= dr["srcType"].ToString();//数据来源方式
            return ttPointOrder;
        }
        
        
        #endregion
        
    }
}

