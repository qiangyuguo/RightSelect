using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 代理佣金结算
    /// Author:代码生成器
    /// </summary>
    public class TTAgentSettlementDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加代理佣金结算
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentSettlement">代理佣金结算</param>
        public virtual void Add(DataAccess data,TTAgentSettlement ttAgentSettlement)
        {
            string strSQL = "insert into TTAgentSettlement (flowId,agentId,agentName,startDate,endDate,saleFee,rebate,commissionFee,payStatus,modeId,settlementTime,settlementId,settlementName,payTime,cashierId,cashierName) values (@flowId,@agentId,@agentName,@startDate,@endDate,@saleFee,@rebate,@commissionFee,@payStatus,@modeId,To_date(@settlementTime,'yyyy-mm-dd hh24:mi:ss'),@settlementId,@settlementName,To_date(@payTime,'yyyy-mm-dd hh24:mi:ss'),@cashierId,@cashierName)";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", ttAgentSettlement.flowId);//结算流水号
            param.Add("@agentId", ttAgentSettlement.agentId);//代理商编号
            param.Add("@agentName", ttAgentSettlement.agentName);//代理商名称
            param.Add("@startDate", ttAgentSettlement.startDate);//结算起始日期
            param.Add("@endDate", ttAgentSettlement.endDate);//结算结束日期
            param.Add("@saleFee", ttAgentSettlement.saleFee);//销售总额
            param.Add("@rebate", ttAgentSettlement.rebate);//返点比例
            param.Add("@commissionFee", ttAgentSettlement.commissionFee);//佣金金额
            param.Add("@payStatus", ttAgentSettlement.payStatus);//支付状态
            param.Add("@modeId", ttAgentSettlement.modeId);//支付方式
            param.Add("@settlementTime", ttAgentSettlement.settlementTime);//结算时间
            param.Add("@settlementId", ttAgentSettlement.settlementId);//结算人编号
            param.Add("@settlementName", ttAgentSettlement.settlementName);//结算人名称
            param.Add("@payTime", ttAgentSettlement.payTime);//支付时间
            param.Add("@cashierId", ttAgentSettlement.cashierId);//支付人编号
            param.Add("@cashierName", ttAgentSettlement.cashierName);//支付人名称
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加代理佣金结算
        /// </summary>
        /// <param name="ttAgentSettlement">代理佣金结算</param>
        public virtual void Add(TTAgentSettlement ttAgentSettlement)
        {
            try
            {
                db.Open();
                Add(db,ttAgentSettlement);
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
        /// 修改代理佣金结算
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentSettlement">代理佣金结算</param>
        public virtual void Edit(DataAccess data,TTAgentSettlement ttAgentSettlement)
        {
            string strSQL = "update TTAgentSettlement set agentId=@agentId,agentName=@agentName,startDate=@startDate,endDate=@endDate,saleFee=@saleFee,rebate=@rebate,commissionFee=@commissionFee,payStatus=@payStatus,modeId=@modeId,settlementTime=To_date(@settlementTime,'yyyy-mm-dd hh24:mi:ss'),settlementId=@settlementId,settlementName=@settlementName,payTime=To_date(@payTime,'yyyy-mm-dd hh24:mi:ss'),cashierId=@cashierId,cashierName=@cashierName where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", ttAgentSettlement.agentId);//代理商编号
            param.Add("@agentName", ttAgentSettlement.agentName);//代理商名称
            param.Add("@startDate", ttAgentSettlement.startDate);//结算起始日期
            param.Add("@endDate", ttAgentSettlement.endDate);//结算结束日期
            param.Add("@saleFee", ttAgentSettlement.saleFee);//销售总额
            param.Add("@rebate", ttAgentSettlement.rebate);//返点比例
            param.Add("@commissionFee", ttAgentSettlement.commissionFee);//佣金金额
            param.Add("@payStatus", ttAgentSettlement.payStatus);//支付状态
            param.Add("@modeId", ttAgentSettlement.modeId);//支付方式
            param.Add("@settlementTime", ttAgentSettlement.settlementTime);//结算时间
            param.Add("@settlementId", ttAgentSettlement.settlementId);//结算人编号
            param.Add("@settlementName", ttAgentSettlement.settlementName);//结算人名称
            param.Add("@payTime", ttAgentSettlement.payTime);//支付时间
            param.Add("@cashierId", ttAgentSettlement.cashierId);//支付人编号
            param.Add("@cashierName", ttAgentSettlement.cashierName);//支付人名称
            param.Add("@flowId", ttAgentSettlement.flowId);//结算流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改代理佣金结算
        /// </summary>
        /// <param name="ttAgentSettlement">代理佣金结算</param>
        public virtual void Edit(TTAgentSettlement ttAgentSettlement)
        {
            try
            {
                db.Open();
                Edit(db,ttAgentSettlement);
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
        /// 删除代理佣金结算
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="flowId">结算流水号</param>
        public virtual void Delete(DataAccess data,long flowId)
        {
            string strSQL = "delete from TTAgentSettlement where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", flowId);//结算流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除代理佣金结算
        /// </summary>
        /// <param name="flowId">结算流水号</param>
        public virtual void Delete(long flowId)
        {
            try
            {
                db.Open();
                Delete(db,flowId);
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
        /// 获取代理佣金结算
        /// </summary>
        /// <param name="flowId">结算流水号</param>
        /// <returns>代理佣金结算对象</returns>
        public virtual TTAgentSettlement Get(long flowId)
        {
            TTAgentSettlement ttAgentSettlement=null;
            try
            {
                string strSQL = "select * from TTAgentSettlement where flowId=@flowId";
                Param param = new Param();
                param.Clear();
                param.Add("@flowId", flowId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttAgentSettlement=ReadData(dr);
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
            return ttAgentSettlement;
        }
        
        /// <summary>
        /// 获取列表(代理佣金结算)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理佣金结算列表对象</returns>
        public virtual List<TTAgentSettlement> GetList(string strSQL,Param param)
        {
            List<TTAgentSettlement> list = new List<TTAgentSettlement>();
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
        /// 获取列表(代理佣金结算)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>代理佣金结算列表对象</returns>
        public virtual List<TTAgentSettlement> GetList(string field, string value)
        {
            List<TTAgentSettlement> list = new List<TTAgentSettlement>();
            try
            {
                string strSQL = "select * from TTAgentSettlement where " + field + "=@field";
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
        /// 获取DataSet(代理佣金结算)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理佣金结算DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTAgentSettlement");
        }
        
        /// <summary>
        /// 是否存在记录(代理佣金结算)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTAgentSettlement where " + field + "=@field";
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
        /// 读取代理佣金结算信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>代理佣金结算对象</returns>
        protected virtual TTAgentSettlement ReadData(ComDataReader dr)
        {
            TTAgentSettlement ttAgentSettlement= new TTAgentSettlement();
            ttAgentSettlement.flowId= long.Parse(dr["flowId"].ToString());//结算流水号
            ttAgentSettlement.agentId= dr["agentId"].ToString();//代理商编号
            ttAgentSettlement.agentName= dr["agentName"].ToString();//代理商名称
            ttAgentSettlement.startDate= dr["startDate"].ToString();//结算起始日期
            ttAgentSettlement.endDate= dr["endDate"].ToString();//结算结束日期
            ttAgentSettlement.saleFee= double.Parse(dr["saleFee"].ToString());//销售总额
            ttAgentSettlement.rebate= double.Parse(dr["rebate"].ToString());//返点比例
            ttAgentSettlement.commissionFee= double.Parse(dr["commissionFee"].ToString());//佣金金额
            ttAgentSettlement.payStatus= dr["payStatus"].ToString();//支付状态
            ttAgentSettlement.modeId= dr["modeId"].ToString();//支付方式
            if(dr["settlementTime"]==null)
            {
                ttAgentSettlement.settlementTime= "";//结算时间
            }
            else
            {
                ttAgentSettlement.settlementTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["settlementTime"]);//结算时间
            }
            ttAgentSettlement.settlementId= dr["settlementId"].ToString();//结算人编号
            ttAgentSettlement.settlementName= dr["settlementName"].ToString();//结算人名称
            if(dr["payTime"]==null)
            {
                ttAgentSettlement.payTime= "";//支付时间
            }
            else
            {
                ttAgentSettlement.payTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["payTime"]);//支付时间
            }
            ttAgentSettlement.cashierId= dr["cashierId"].ToString();//支付人编号
            ttAgentSettlement.cashierName= dr["cashierName"].ToString();//支付人名称
            return ttAgentSettlement;
        }
        
        
        #endregion
        
    }
}

