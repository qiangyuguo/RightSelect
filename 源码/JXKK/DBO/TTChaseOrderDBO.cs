using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 追号订单
    /// Author:代码生成器
    /// </summary>
    public class TTChaseOrderDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加追号订单
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttChaseOrder">追号订单</param>
        public virtual void Add(DataAccess data,TTChaseOrder ttChaseOrder)
        {
            string strSQL = "insert into TTChaseOrder (chaseOrderId,chaseType,agentId,siteId,terminalId,clientId,clientName,cardId,gameId,lotteryType,period,userBetCodes,centerBetCodes,betNum,chaseTotalFee,chaseTime,endCondition,conditionParam,usedPeriod,usedNum,usedFee,backNum,backFee,awardMoney,frozenFee,chaseStatus,overTime,createTime,srcType) values (@chaseOrderId,@chaseType,@agentId,@siteId,@terminalId,@clientId,@clientName,@cardId,@gameId,@lotteryType,@period,@userBetCodes,@centerBetCodes,@betNum,@chaseTotalFee,@chaseTime,@endCondition,@conditionParam,@usedPeriod,@usedNum,@usedFee,@backNum,@backFee,@awardMoney,@frozenFee,@chaseStatus,@overTime,To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'),@srcType)";
            Param param = new Param();
            param.Clear();
            param.Add("@chaseOrderId", ttChaseOrder.chaseOrderId);//追号订单号
            param.Add("@chaseType", ttChaseOrder.chaseType);//追号类型
            param.Add("@agentId", ttChaseOrder.agentId);//代理商编号
            param.Add("@siteId", ttChaseOrder.siteId);//门店编号
            param.Add("@terminalId", ttChaseOrder.terminalId);//终端编号
            param.Add("@clientId", ttChaseOrder.clientId);//客户编号
            param.Add("@clientName", ttChaseOrder.clientName);//客户名称
            param.Add("@cardId", ttChaseOrder.cardId);//卡号
            param.Add("@gameId", ttChaseOrder.gameId);//游戏编号
            param.Add("@lotteryType", ttChaseOrder.lotteryType);//彩种
            param.Add("@period", ttChaseOrder.period);//下单期次
            param.Add("@userBetCodes", ttChaseOrder.userBetCodes);//用户投注串
            param.Add("@centerBetCodes", ttChaseOrder.centerBetCodes);//中心投注串
            param.Add("@betNum", ttChaseOrder.betNum);//投注期数
            param.Add("@chaseTotalFee", ttChaseOrder.chaseTotalFee);//订单总额
            param.Add("@chaseTime", ttChaseOrder.chaseTime);//追号时间
            param.Add("@endCondition", ttChaseOrder.endCondition);//停止条件
            param.Add("@conditionParam", ttChaseOrder.conditionParam);//停止参数
            param.Add("@usedPeriod", ttChaseOrder.usedPeriod);//运行期次
            param.Add("@usedNum", ttChaseOrder.usedNum);//已追期数
            param.Add("@usedFee", ttChaseOrder.usedFee);//已追金额
            param.Add("@backNum", ttChaseOrder.backNum);//退款期数
            param.Add("@backFee", ttChaseOrder.backFee);//退款金额
            param.Add("@awardMoney", ttChaseOrder.awardMoney);//中奖金额
            param.Add("@frozenFee", ttChaseOrder.frozenFee);//冻结金额
            param.Add("@chaseStatus", ttChaseOrder.chaseStatus);//追号状态
            param.Add("@overTime", ttChaseOrder.overTime);//结束时间
            param.Add("@createTime", ttChaseOrder.createTime);//创建时间
            param.Add("@srcType", ttChaseOrder.srcType);//数据来源方式
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加追号订单
        /// </summary>
        /// <param name="ttChaseOrder">追号订单</param>
        public virtual void Add(TTChaseOrder ttChaseOrder)
        {
            try
            {
                db.Open();
                Add(db,ttChaseOrder);
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
        /// 修改追号订单
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttChaseOrder">追号订单</param>
        public virtual void Edit(DataAccess data,TTChaseOrder ttChaseOrder)
        {
            string strSQL = "update TTChaseOrder set chaseType=@chaseType,agentId=@agentId,siteId=@siteId,terminalId=@terminalId,clientId=@clientId,clientName=@clientName,cardId=@cardId,gameId=@gameId,lotteryType=@lotteryType,period=@period,userBetCodes=@userBetCodes,centerBetCodes=@centerBetCodes,betNum=@betNum,chaseTotalFee=@chaseTotalFee,chaseTime=@chaseTime,endCondition=@endCondition,conditionParam=@conditionParam,usedPeriod=@usedPeriod,usedNum=@usedNum,usedFee=@usedFee,backNum=@backNum,backFee=@backFee,awardMoney=@awardMoney,frozenFee=@frozenFee,chaseStatus=@chaseStatus,overTime=@overTime,createTime=To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'),srcType=@srcType where chaseOrderId=@chaseOrderId";
            Param param = new Param();
            param.Clear();
            param.Add("@chaseType", ttChaseOrder.chaseType);//追号类型
            param.Add("@agentId", ttChaseOrder.agentId);//代理商编号
            param.Add("@siteId", ttChaseOrder.siteId);//门店编号
            param.Add("@terminalId", ttChaseOrder.terminalId);//终端编号
            param.Add("@clientId", ttChaseOrder.clientId);//客户编号
            param.Add("@clientName", ttChaseOrder.clientName);//客户名称
            param.Add("@cardId", ttChaseOrder.cardId);//卡号
            param.Add("@gameId", ttChaseOrder.gameId);//游戏编号
            param.Add("@lotteryType", ttChaseOrder.lotteryType);//彩种
            param.Add("@period", ttChaseOrder.period);//下单期次
            param.Add("@userBetCodes", ttChaseOrder.userBetCodes);//用户投注串
            param.Add("@centerBetCodes", ttChaseOrder.centerBetCodes);//中心投注串
            param.Add("@betNum", ttChaseOrder.betNum);//投注期数
            param.Add("@chaseTotalFee", ttChaseOrder.chaseTotalFee);//订单总额
            param.Add("@chaseTime", ttChaseOrder.chaseTime);//追号时间
            param.Add("@endCondition", ttChaseOrder.endCondition);//停止条件
            param.Add("@conditionParam", ttChaseOrder.conditionParam);//停止参数
            param.Add("@usedPeriod", ttChaseOrder.usedPeriod);//运行期次
            param.Add("@usedNum", ttChaseOrder.usedNum);//已追期数
            param.Add("@usedFee", ttChaseOrder.usedFee);//已追金额
            param.Add("@backNum", ttChaseOrder.backNum);//退款期数
            param.Add("@backFee", ttChaseOrder.backFee);//退款金额
            param.Add("@awardMoney", ttChaseOrder.awardMoney);//中奖金额
            param.Add("@frozenFee", ttChaseOrder.frozenFee);//冻结金额
            param.Add("@chaseStatus", ttChaseOrder.chaseStatus);//追号状态
            param.Add("@overTime", ttChaseOrder.overTime);//结束时间
            param.Add("@createTime", ttChaseOrder.createTime);//创建时间
            param.Add("@srcType", ttChaseOrder.srcType);//数据来源方式
            param.Add("@chaseOrderId", ttChaseOrder.chaseOrderId);//追号订单号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改追号订单
        /// </summary>
        /// <param name="ttChaseOrder">追号订单</param>
        public virtual void Edit(TTChaseOrder ttChaseOrder)
        {
            try
            {
                db.Open();
                Edit(db,ttChaseOrder);
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
        /// 删除追号订单
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="chaseOrderId">追号订单号</param>
        public virtual void Delete(DataAccess data,string chaseOrderId)
        {
            string strSQL = "delete from TTChaseOrder where chaseOrderId=@chaseOrderId";
            Param param = new Param();
            param.Clear();
            param.Add("@chaseOrderId", chaseOrderId);//追号订单号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除追号订单
        /// </summary>
        /// <param name="chaseOrderId">追号订单号</param>
        public virtual void Delete(string chaseOrderId)
        {
            try
            {
                db.Open();
                Delete(db,chaseOrderId);
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
        /// 获取追号订单
        /// </summary>
        /// <param name="chaseOrderId">追号订单号</param>
        /// <returns>追号订单对象</returns>
        public virtual TTChaseOrder Get(string chaseOrderId)
        {
            TTChaseOrder ttChaseOrder=null;
            try
            {
                string strSQL = "select * from TTChaseOrder where chaseOrderId=@chaseOrderId";
                Param param = new Param();
                param.Clear();
                param.Add("@chaseOrderId", chaseOrderId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttChaseOrder=ReadData(dr);
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
            return ttChaseOrder;
        }
        
        /// <summary>
        /// 获取列表(追号订单)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>追号订单列表对象</returns>
        public virtual List<TTChaseOrder> GetList(string strSQL,Param param)
        {
            List<TTChaseOrder> list = new List<TTChaseOrder>();
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
        /// 获取列表(追号订单)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>追号订单列表对象</returns>
        public virtual List<TTChaseOrder> GetList(string field, string value)
        {
            List<TTChaseOrder> list = new List<TTChaseOrder>();
            try
            {
                string strSQL = "select * from TTChaseOrder where " + field + "=@field";
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
        /// 获取DataSet(追号订单)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>追号订单DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTChaseOrder");
        }
        
        /// <summary>
        /// 是否存在记录(追号订单)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTChaseOrder where " + field + "=@field";
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
        /// 读取追号订单信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>追号订单对象</returns>
        protected virtual TTChaseOrder ReadData(ComDataReader dr)
        {
            TTChaseOrder ttChaseOrder= new TTChaseOrder();
            ttChaseOrder.chaseOrderId= dr["chaseOrderId"].ToString();//追号订单号
            ttChaseOrder.chaseType= dr["chaseType"].ToString();//追号类型
            ttChaseOrder.agentId= dr["agentId"].ToString();//代理商编号
            ttChaseOrder.siteId= dr["siteId"].ToString();//门店编号
            ttChaseOrder.terminalId= dr["terminalId"].ToString();//终端编号
            ttChaseOrder.clientId= long.Parse(dr["clientId"].ToString());//客户编号
            ttChaseOrder.clientName= dr["clientName"].ToString();//客户名称
            ttChaseOrder.cardId= dr["cardId"].ToString();//卡号
            ttChaseOrder.gameId= dr["gameId"].ToString();//游戏编号
            ttChaseOrder.lotteryType= dr["lotteryType"].ToString();//彩种
            ttChaseOrder.period= dr["period"].ToString();//下单期次
            ttChaseOrder.userBetCodes= dr["userBetCodes"].ToString();//用户投注串
            ttChaseOrder.centerBetCodes= dr["centerBetCodes"].ToString();//中心投注串
            ttChaseOrder.betNum= int.Parse(dr["betNum"].ToString());//投注期数
            ttChaseOrder.chaseTotalFee= double.Parse(dr["chaseTotalFee"].ToString());//订单总额
            ttChaseOrder.chaseTime= dr["chaseTime"].ToString();//追号时间
            ttChaseOrder.endCondition= dr["endCondition"].ToString();//停止条件
            ttChaseOrder.conditionParam= int.Parse(dr["conditionParam"].ToString());//停止参数
            ttChaseOrder.usedPeriod= dr["usedPeriod"].ToString();//运行期次
            ttChaseOrder.usedNum= int.Parse(dr["usedNum"].ToString());//已追期数
            ttChaseOrder.usedFee= double.Parse(dr["usedFee"].ToString());//已追金额
            ttChaseOrder.backNum= int.Parse(dr["backNum"].ToString());//退款期数
            ttChaseOrder.backFee= double.Parse(dr["backFee"].ToString());//退款金额
            ttChaseOrder.awardMoney= double.Parse(dr["awardMoney"].ToString());//中奖金额
            ttChaseOrder.frozenFee= double.Parse(dr["frozenFee"].ToString());//冻结金额
            ttChaseOrder.chaseStatus= dr["chaseStatus"].ToString();//追号状态
            ttChaseOrder.overTime= dr["overTime"].ToString();//结束时间
            if(dr["createTime"]==null)
            {
                ttChaseOrder.createTime= "";//创建时间
            }
            else
            {
                ttChaseOrder.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            ttChaseOrder.srcType= dr["srcType"].ToString();//数据来源方式
            return ttChaseOrder;
        }
        
        
        #endregion
        
    }
}

