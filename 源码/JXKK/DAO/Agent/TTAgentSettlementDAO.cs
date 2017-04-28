using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理佣金结算
    /// Author:开发人员自行扩展
    /// </summary>
    public class TTAgentSettlementDAO : TTAgentSettlementDBO
    {
        /// <summary>
        /// 获取列表(代理佣金结算)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理佣金结算列表对象</returns>
        public List<TTAgentSettlement> GetAgentSettlementList(string strSQL, Param param)
        {
            List<TTAgentSettlement> list = new List<TTAgentSettlement>();
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while (dr.Read())
                {
                    list.Add(ReadAgentSettlementData(dr));
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
        /// 获取佣金列表
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理佣金列表对象</returns>
        public List<Commission> GetCommissionList(string strSQL, Param param)
        {
            List<Commission> list = new List<Commission>();
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while (dr.Read())
                {
                    list.Add(ReadCommissionData(dr));
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
        /// 读取代理佣金结算信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>代理佣金结算对象</returns>
        public TTAgentSettlement ReadAgentSettlementData(ComDataReader dr)
        {
            TTAgentSettlement ttAgentSettlement = new TTAgentSettlement();
            ttAgentSettlement.agentId = dr["agentId"].ToString();//代理商编号
            ttAgentSettlement.agentName = dr["agentName"].ToString();//代理商名称
            ttAgentSettlement.startDate = dr["startDate"].ToString();//结算起始日期
            ttAgentSettlement.endDate = dr["endDate"].ToString();//结算结束日期
            ttAgentSettlement.saleFee = double.Parse(dr["saleFee"].ToString());//销售总额
            ttAgentSettlement.rebate = double.Parse(dr["rebate"].ToString());//返点比例
            ttAgentSettlement.commissionFee = double.Parse(dr["commissionFee"].ToString());//佣金金额
            return ttAgentSettlement;
        }

        /// <summary>
        /// 读取代理佣金结算信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>代理佣金结算对象</returns>
        public Commission ReadCommissionData(ComDataReader dr)
        {
            Commission commission = new Commission();
            commission.commissionDate = dr["commissionDate"].ToString();//日期
            commission.commissionFee =double.Parse(dr["commissionFee"].ToString());//佣金
            return commission;
        }

        public void AddList(List<TTAgentSettlement> agentSettlementList, string startDate, string endDate,string userId,string userName)
        {
            ComTransaction trans = null;
            try
            {
                db.Open();
                trans = db.BeginTransaction();
                foreach (var agentSettlement in agentSettlementList)
                {
                    TTAgentSettlement ttAgentSettlement = new TTAgentSettlement();
                    ttAgentSettlement.agentId = agentSettlement.agentId;
                    ttAgentSettlement.agentName = agentSettlement.agentName;
                    ttAgentSettlement.startDate = agentSettlement.startDate;
                    ttAgentSettlement.endDate = agentSettlement.endDate;
                    ttAgentSettlement.saleFee = agentSettlement.saleFee;
                    ttAgentSettlement.rebate = agentSettlement.rebate;
                    ttAgentSettlement.commissionFee = agentSettlement.commissionFee;
                    ttAgentSettlement.settlementId = userId;
                    ttAgentSettlement.settlementName = userName;
                    this.Add(db, ttAgentSettlement);
                }
                //根据时间更改订单的状态
                string strSQL = @"update TTLotteryOrder set settleStatus='1',settleTime=sysdate" +
                                        " where bettime>='" + startDate + " 00:00:00' " +
                                        " and bettime<='" + endDate + " 23:59:59' " +
                                        " and orderstatus='" + (int)OrderStatus.Ticket + "' " +
                                        " and settleStatus='0'";
                Param param = new Param();
                db.ExecuteNonQuery(CommandType.Text, strSQL, param);
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

        /// <summary>
        /// 增加代理佣金结算
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentSettlement">代理佣金结算</param>
        /// </summary>
        public override void Add(DataAccess data, TTAgentSettlement ttAgentSettlement)
        {
            string strSQL = "insert into TTAgentSettlement (flowId,agentId,agentName,startDate,endDate,saleFee,rebate,commissionFee,settlementId,settlementName) values (SAgentSettlement_flowId.Nextval,@agentId,@agentName,@startDate,@endDate,@saleFee,@rebate,@commissionFee,@settlementId,@settlementName)";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", ttAgentSettlement.agentId);//代理商编号
            param.Add("@agentName", ttAgentSettlement.agentName);//代理商名称
            param.Add("@startDate", ttAgentSettlement.startDate);//结算起始日期
            param.Add("@endDate", ttAgentSettlement.endDate);//结算结束日期
            param.Add("@saleFee", ttAgentSettlement.saleFee);//销售总额
            param.Add("@rebate", ttAgentSettlement.rebate);//返点比例
            param.Add("@commissionFee", ttAgentSettlement.commissionFee);//佣金金额
            param.Add("@settlementId", ttAgentSettlement.settlementId);//结算人编号
            param.Add("@settlementName", ttAgentSettlement.settlementName);//结算人名称
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 代理佣金支付
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentSettlement">代理佣金结算</param>
        /// </summary>
        public override void Edit(DataAccess data, TTAgentSettlement ttAgentSettlement)
        {
            string strSQL = "update TTAgentSettlement set payStatus=@payStatus,modeId=@modeId,payTime=sysdate,cashierId=@cashierId,cashierName=@cashierName where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@payStatus", ttAgentSettlement.payStatus);//支付状态
            param.Add("@modeId", ttAgentSettlement.modeId);//支付方式
            param.Add("@cashierId", ttAgentSettlement.cashierId);//支付人编号
            param.Add("@cashierName", ttAgentSettlement.cashierName);//支付人名称
            param.Add("@flowId", ttAgentSettlement.flowId);//结算流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
    }
}

