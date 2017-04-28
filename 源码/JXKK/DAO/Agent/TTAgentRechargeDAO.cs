using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理商充值
    /// Author:开发人员自行扩展
    /// </summary>
    public class TTAgentRechargeDAO:TTAgentRechargeDBO
    {
        /// <summary>
        /// 增加代理商充值
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentRecharge">代理商充值</param>
        /// </summary>
        public override void Add(DataAccess data, TTAgentRecharge ttAgentRecharge)
        {
            string strSQL = "insert into TTAgentRecharge (flowId,agentId,agentName,lastBalance,fee,balance,operatorId,operatorName,handleMode,bankAccountId,bankFlowId,description) values (SAgentRecharge_flowId.Nextval,@agentId,@agentName,@lastBalance,@fee,@balance,@operatorId,@operatorName,@handleMode,@bankAccountId,@bankFlowId,@description)";
            Param param = new Param();
            param.Clear();
            //param.Add("@flowId", ttAgentRecharge.flowId);//流水号
            param.Add("@agentId", ttAgentRecharge.agentId);//代理商编号
            param.Add("@agentName", ttAgentRecharge.agentName);//代理商名称
            param.Add("@lastBalance", ttAgentRecharge.lastBalance);//上次余额
            param.Add("@fee", ttAgentRecharge.fee);//发生金额
            param.Add("@balance", ttAgentRecharge.balance);//当前余额
            param.Add("@operatorId", ttAgentRecharge.operatorId);//操作人编号
            param.Add("@operatorName", ttAgentRecharge.operatorName);//操作人名称
            param.Add("@handleMode", ttAgentRecharge.handleMode);//充值方式
            param.Add("@bankAccountId", ttAgentRecharge.bankAccountId);//银行账号
            param.Add("@bankFlowId", ttAgentRecharge.bankFlowId);//银行流水号
            param.Add("@description", ttAgentRecharge.description);//说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 增加代理商充值
        /// <param name="ttAgentRecharge">代理商充值</param>
        /// </summary>
        public  void Add(TTAgentRecharge ttAgentRecharge,TTAgentPreRechg ttAgentPreRechg)
        {
            ComTransaction trans = null;
            try
            {
                db.Open();
                trans = db.BeginTransaction();

                TBAgentDAO tbAgentDAO = new TBAgentDAO();
                

                TBAgent tbAgent = new TBAgent();
                tbAgent = tbAgentDAO.Get(db, ttAgentRecharge.agentId);//获取代理商信息
                //修改代理商信息表的当前余额
                tbAgent.sumRecharge = tbAgent.sumRecharge + ttAgentRecharge.fee;
                tbAgent.balanceValue = tbAgent.balanceValue + ttAgentRecharge.fee;
                new TBAgentDAO().EditBalance(db, tbAgent);

                
                ttAgentRecharge.agentName = tbAgent.agentName;//代理商名称
                ttAgentRecharge.lastBalance = tbAgent.balanceValue - ttAgentRecharge.fee;//代理商上次余额
                ttAgentRecharge.balance = tbAgent.balanceValue;//代理商当前余额
                Add(db, ttAgentRecharge);

                //添加代理商充值账户明细
                TTAgentAccDetail ttAgentAccDetail = new TTAgentAccDetail();
                ttAgentAccDetail.agentId = ttAgentRecharge.agentId;
                ttAgentAccDetail.agentName = ttAgentRecharge.agentName;
                ttAgentAccDetail.lastBalance = ttAgentRecharge.lastBalance;
                ttAgentAccDetail.fee = ttAgentRecharge.fee;
                ttAgentAccDetail.balance = ttAgentRecharge.balance;
                ttAgentAccDetail.createTime = ttAgentRecharge.createTime;
                ttAgentAccDetail.remark = ttAgentRecharge.description;
                new TTAgentAccDetailDAO().Add(db, ttAgentAccDetail);

                new TTAgentPreRechgDAO().Edit(db, ttAgentPreRechg);//修改状态
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
        /// 获取代理商充值总计
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理商充值double</returns>
        public double GetTotalFee(string strSQL, Param param)
        {
            double totalFee;
            try
            {
                db.Open();
                object obj = db.ExecuteScalar(CommandType.Text, strSQL, param);
                if (obj == DBNull.Value)
                {
                    totalFee = 0;
                }
                else
                {
                    totalFee = double.Parse(obj.ToString());
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

            return totalFee;
        }
    }
}

