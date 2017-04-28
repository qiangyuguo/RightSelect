using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Lottery;

namespace Com.ZY.JXKK.DAO.Lottery
{
    /// <summary>
    /// 彩票订单
    /// Author:代码生成器
    /// </summary>
    public class TTLotteryOrderDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加彩票订单
        /// <param name="data">数据库连接</param>
        /// <param name="ttLotteryOrder">彩票订单</param>
        /// </summary>
        public void Add(DataAccess data,TTLotteryOrder ttLotteryOrder)
        {
            string strSQL = "insert into TTLotteryOrder (orderId,agentId,siteId,terminalId,clientId,clientName,cardId,gameId,lotteryType,playType,period,betCodes,multiple,betFee,betTime,isChase,chaseOrderId,orderStatus,orderTime,awardResult,awardMoney,awardTime,settleStatus,settleTime,createTime,batchId) values (:orderId,:agentId,:siteId,:terminalId,:clientId,:clientName,:cardId,:gameId,:lotteryType,:playType,:period,:betCodes,:multiple,:betFee,:betTime,:isChase,:chaseOrderId,:orderStatus,:orderTime,:awardResult,:awardMoney,:awardTime,:settleStatus,:settleTime,To_date(:createTime,'yyyy-mm-dd hh24:mi:ss'),:batchId)";
            Param param = new Param();
            param.Clear();
            param.Add(":orderId", ttLotteryOrder.orderId);//订单号
            param.Add(":agentId", ttLotteryOrder.agentId);//代理商编号
            param.Add(":siteId", ttLotteryOrder.siteId);//门店编号
            param.Add(":terminalId", ttLotteryOrder.terminalId);//终端编号
            param.Add(":clientId", ttLotteryOrder.clientId);//客户编号
            param.Add(":clientName", ttLotteryOrder.clientName);//客户名称
            param.Add(":cardId", ttLotteryOrder.cardId);//卡号
            param.Add(":gameId", ttLotteryOrder.gameId);//游戏编号
            param.Add(":lotteryType", ttLotteryOrder.lotteryType);//彩种
            param.Add(":playType", ttLotteryOrder.playType);//玩法
            param.Add(":period", ttLotteryOrder.period);//期次
            param.Add(":betCodes", ttLotteryOrder.betCodes);//投注串
            param.Add(":multiple", ttLotteryOrder.multiple);//倍数
            param.Add(":betFee", ttLotteryOrder.betFee);//投注金额
            param.Add(":betTime", ttLotteryOrder.betTime);//投注时间
            param.Add(":isChase", ttLotteryOrder.isChase);//是否追号
            param.Add(":chaseOrderId", ttLotteryOrder.chaseOrderId);//追号订单编号
            param.Add(":orderStatus", ttLotteryOrder.orderStatus);//订单状态
            param.Add(":orderTime", ttLotteryOrder.orderTime);//出票/撤销时间
            param.Add(":awardResult", ttLotteryOrder.awardResult);//中奖状态
            param.Add(":awardMoney", ttLotteryOrder.awardMoney);//中奖金额
            param.Add(":awardTime", ttLotteryOrder.awardTime);//返奖时间
            param.Add(":settleStatus", ttLotteryOrder.settleStatus);//结算状态
            param.Add(":settleTime", ttLotteryOrder.settleTime);//结算时间
            param.Add(":createTime", ttLotteryOrder.createTime);//创建时间
            param.Add(":batchId", ttLotteryOrder.batchId);//批处理编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加彩票订单
        /// <param name="ttLotteryOrder">彩票订单</param>
        /// </summary>
        public void Add(TTLotteryOrder ttLotteryOrder)
        {
            try
            {
                db.Open();
                Add(db,ttLotteryOrder);
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
        /// 修改彩票订单
        /// <param name="data">数据库连接</param>
        /// <param name="ttLotteryOrder">彩票订单</param>
        /// </summary>
        public void Edit(DataAccess data,TTLotteryOrder ttLotteryOrder)
        {
            string strSQL = "update TTLotteryOrder set agentId=:agentId,siteId=:siteId,terminalId=:terminalId,clientId=:clientId,clientName=:clientName,cardId=:cardId,gameId=:gameId,lotteryType=:lotteryType,playType=:playType,period=:period,betCodes=:betCodes,multiple=:multiple,betFee=:betFee,betTime=:betTime,isChase=:isChase,chaseOrderId=:chaseOrderId,orderStatus=:orderStatus,orderTime=:orderTime,awardResult=:awardResult,awardMoney=:awardMoney,awardTime=:awardTime,settleStatus=:settleStatus,settleTime=:settleTime,createTime=To_date(:createTime,'yyyy-mm-dd hh24:mi:ss'),batchId=:batchId where orderId=:orderId";
            Param param = new Param();
            param.Clear();
            param.Add(":agentId", ttLotteryOrder.agentId);//代理商编号
            param.Add(":siteId", ttLotteryOrder.siteId);//门店编号
            param.Add(":terminalId", ttLotteryOrder.terminalId);//终端编号
            param.Add(":clientId", ttLotteryOrder.clientId);//客户编号
            param.Add(":clientName", ttLotteryOrder.clientName);//客户名称
            param.Add(":cardId", ttLotteryOrder.cardId);//卡号
            param.Add(":gameId", ttLotteryOrder.gameId);//游戏编号
            param.Add(":lotteryType", ttLotteryOrder.lotteryType);//彩种
            param.Add(":playType", ttLotteryOrder.playType);//玩法
            param.Add(":period", ttLotteryOrder.period);//期次
            param.Add(":betCodes", ttLotteryOrder.betCodes);//投注串
            param.Add(":multiple", ttLotteryOrder.multiple);//倍数
            param.Add(":betFee", ttLotteryOrder.betFee);//投注金额
            param.Add(":betTime", ttLotteryOrder.betTime);//投注时间
            param.Add(":isChase", ttLotteryOrder.isChase);//是否追号
            param.Add(":chaseOrderId", ttLotteryOrder.chaseOrderId);//追号订单编号
            param.Add(":orderStatus", ttLotteryOrder.orderStatus);//订单状态
            param.Add(":orderTime", ttLotteryOrder.orderTime);//出票/撤销时间
            param.Add(":awardResult", ttLotteryOrder.awardResult);//中奖状态
            param.Add(":awardMoney", ttLotteryOrder.awardMoney);//中奖金额
            param.Add(":awardTime", ttLotteryOrder.awardTime);//返奖时间
            param.Add(":settleStatus", ttLotteryOrder.settleStatus);//结算状态
            param.Add(":settleTime", ttLotteryOrder.settleTime);//结算时间
            param.Add(":createTime", ttLotteryOrder.createTime);//创建时间
            param.Add(":batchId", ttLotteryOrder.batchId);//批处理编号
            param.Add(":orderId", ttLotteryOrder.orderId);//订单号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改彩票订单
        /// <param name="ttLotteryOrder">彩票订单</param>
        /// </summary>
        public void Edit(TTLotteryOrder ttLotteryOrder)
        {
            try
            {
                db.Open();
                Edit(db,ttLotteryOrder);
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
        /// 删除彩票订单
        /// <param name="data">数据库连接</param>
        /// <param name="orderId">订单号</param>
        /// </summary>
        public void Delete(DataAccess data,string orderId)
        {
            string strSQL = "delete from TTLotteryOrder where orderId=:orderId";
            Param param = new Param();
            param.Clear();
            param.Add(":orderId", orderId);//订单号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除彩票订单
        /// <param name="orderId">订单号</param>
        /// </summary>
        public void Delete(string orderId)
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
        /// 获取彩票订单
        /// <param name="orderId">订单号</param>
        /// </summary>
        /// <returns>彩票订单对象</returns>
        public TTLotteryOrder Get(string orderId)
        {
            TTLotteryOrder ttLotteryOrder=null;
            try
            {
                string strSQL = "select * from TTLotteryOrder where orderId=:orderId";
                Param param = new Param();
                param.Clear();
                param.Add(":orderId", orderId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttLotteryOrder=ReadData(dr);
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
            return ttLotteryOrder;
        }
        
        /// <summary>
        /// 获取列表(彩票订单)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>彩票订单列表对象</returns>
        public List<TTLotteryOrder> GetList(string strSQL,Param param)
        {
            List<TTLotteryOrder> list = new List<TTLotteryOrder>();
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
        /// 获取列表(彩票订单)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>彩票订单列表对象</returns>
        public List<TTLotteryOrder> GetList(string field, string value)
        {
            List<TTLotteryOrder> list = new List<TTLotteryOrder>();
            try
            {
                string strSQL = "select * from TTLotteryOrder where " + field + "=:field";
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
        /// 获取DataSet(彩票订单)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>彩票订单DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTLotteryOrder");
        }
        
        /// <summary>
        /// 是否存在记录(彩票订单)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTLotteryOrder where " + field + "=:field";
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
        /// 读取彩票订单信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>彩票订单对象</returns>
        private TTLotteryOrder ReadData(ComDataReader dr)
        {
            TTLotteryOrder ttLotteryOrder= new TTLotteryOrder();
            ttLotteryOrder.orderId= dr["orderId"].ToString();//订单号
            ttLotteryOrder.agentId= dr["agentId"].ToString();//代理商编号
            ttLotteryOrder.siteId= dr["siteId"].ToString();//门店编号
            ttLotteryOrder.terminalId= dr["terminalId"].ToString();//终端编号
            ttLotteryOrder.clientId= long.Parse(dr["clientId"].ToString());//客户编号
            ttLotteryOrder.clientName= dr["clientName"].ToString();//客户名称
            ttLotteryOrder.cardId= dr["cardId"].ToString();//卡号
            ttLotteryOrder.gameId= dr["gameId"].ToString();//游戏编号
            ttLotteryOrder.lotteryType= dr["lotteryType"].ToString();//彩种
            ttLotteryOrder.playType= dr["playType"].ToString();//玩法
            ttLotteryOrder.period= dr["period"].ToString();//期次
            ttLotteryOrder.betCodes= dr["betCodes"].ToString();//投注串
            ttLotteryOrder.multiple= int.Parse(dr["multiple"].ToString());//倍数
            ttLotteryOrder.betFee= double.Parse(dr["betFee"].ToString());//投注金额
            ttLotteryOrder.betTime= dr["betTime"].ToString();//投注时间
            ttLotteryOrder.isChase= dr["isChase"].ToString();//是否追号
            ttLotteryOrder.chaseOrderId= dr["chaseOrderId"].ToString();//追号订单编号
            ttLotteryOrder.orderStatus= dr["orderStatus"].ToString();//订单状态
            ttLotteryOrder.orderTime= dr["orderTime"].ToString();//出票/撤销时间
            ttLotteryOrder.awardResult= dr["awardResult"].ToString();//中奖状态
            ttLotteryOrder.awardMoney= double.Parse(dr["awardMoney"].ToString());//中奖金额
            ttLotteryOrder.awardTime= dr["awardTime"].ToString();//返奖时间
            ttLotteryOrder.settleStatus= dr["settleStatus"].ToString();//结算状态
            ttLotteryOrder.settleTime= dr["settleTime"].ToString();//结算时间
            if(dr["createTime"]==null)
            {
                ttLotteryOrder.createTime= "";//创建时间
            }
            else
            {
                ttLotteryOrder.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            ttLotteryOrder.batchId= dr["batchId"].ToString();//批处理编号
            return ttLotteryOrder;
        }
        
        
        #endregion
        
    }
}

