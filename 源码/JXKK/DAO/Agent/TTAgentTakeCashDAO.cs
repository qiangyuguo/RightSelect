using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理商提现
    /// Author:开发人员自行扩展
    /// </summary>
    public class TTAgentTakeCashDAO:TTAgentTakeCashDBO
    {
        /// <summary>
        /// 增加代理商提现
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentTakeCash">代理商提现</param>
        /// </summary>
        public override void Add(DataAccess data, TTAgentTakeCash ttAgentTakeCash)
        {
            string strSQL = "insert into TTAgentTakeCash (flowId,agentId,agentName,lastBalance,fee,balance,operatorId,operatorName,handleMode,bankAccountId,bankFlowId,description) values (SAgentTakeCash_flowId.Nextval,@agentId,@agentName,@lastBalance,@fee,@balance,@operatorId,@operatorName,@handleMode,@bankAccountId,@bankFlowId,@description)";
            Param param = new Param();
            param.Clear();
            //param.Add("@flowId", ttAgentTakeCash.flowId);//流水号
            param.Add("@agentId", ttAgentTakeCash.agentId);//代理商编号
            param.Add("@agentName", ttAgentTakeCash.agentName);//代理商名称
            param.Add("@lastBalance", ttAgentTakeCash.lastBalance);//上次余额
            param.Add("@fee", ttAgentTakeCash.fee);//发生金额
            param.Add("@balance", ttAgentTakeCash.balance);//当前余额
            param.Add("@operatorId", ttAgentTakeCash.operatorId);//操作人编号
            param.Add("@operatorName", ttAgentTakeCash.operatorName);//操作人名称
            param.Add("@handleMode", ttAgentTakeCash.handleMode);//提现方式
            param.Add("@bankAccountId", ttAgentTakeCash.bankAccountId);//银行账号
            param.Add("@bankFlowId", ttAgentTakeCash.bankFlowId);//银行流水号
            param.Add("@description", ttAgentTakeCash.description);//说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }


        /// <summary>
        /// 增加代理商充值
        /// <param name="ttAgentRecharge">代理商充值</param>
        /// </summary>
        public void Add(DataAccess db, TTAgentTakeCash ttAgentTakeCash, TBAgent tbAgent)
        {
            try
            {
                //修改代理商信息表的当前余额
                tbAgent.sumDraw = tbAgent.sumDraw + ttAgentTakeCash.fee;
                tbAgent.balanceValue =tbAgent.balanceValue-ttAgentTakeCash.fee;
                new TBAgentDAO().EditBalance(db, tbAgent);

                ttAgentTakeCash.agentName = tbAgent.agentName;//代理商名称
                ttAgentTakeCash.lastBalance = tbAgent.balanceValue + ttAgentTakeCash.fee;//代理商上次余额
                ttAgentTakeCash.balance = tbAgent.balanceValue;//代理商当前余额
                Add(db, ttAgentTakeCash);
                //添加代理商提现账户明细
                TTAgentAccDetailDAO ttAgentAccDetailDAO = new TTAgentAccDetailDAO();
                TTAgentAccDetail ttAgentAccDetail = new TTAgentAccDetail();
                ttAgentAccDetail.agentId = ttAgentTakeCash.agentId;
                ttAgentAccDetail.agentName = ttAgentTakeCash.agentName;
                ttAgentAccDetail.lastBalance = ttAgentTakeCash.lastBalance;
                ttAgentAccDetail.fee = 0 - ttAgentTakeCash.fee;
                ttAgentAccDetail.balance = ttAgentTakeCash.balance;
                ttAgentAccDetail.createTime = ttAgentTakeCash.createTime;
                ttAgentAccDetail.remark = ttAgentTakeCash.description;
                new TTAgentAccDetailDAO().Add(db, ttAgentAccDetail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

