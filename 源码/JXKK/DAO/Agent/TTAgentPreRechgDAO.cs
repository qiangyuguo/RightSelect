using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理商充值预审
    /// Author:开发人员自行扩展
    /// </summary>
    public class TTAgentPreRechgDAO:TTAgentPreRechgDBO
    {

        /// <summary>
        /// 增加代理商充值预审
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentPreRechg">代理商充值预审</param>
        public override void Add(DataAccess data, TTAgentPreRechg ttAgentPreRechg)
        {
            string strSQL = "insert into TTAgentPreRechg (flowId,agentId,agentName,fee,operatorId,operatorName,handleMode,bankAccountId,bankFlowId,description) values (SAgentRecharge_flowId.Nextval,@agentId,@agentName,@fee,@operatorId,@operatorName,@handleMode,@bankAccountId,@bankFlowId,@description)";
            Param param = new Param();
            param.Clear();
            //param.Add("@flowId", ttAgentPreRechg.flowId);//流水号
            param.Add("@agentId", ttAgentPreRechg.agentId);//代理商编号
            param.Add("@agentName", ttAgentPreRechg.agentName);//代理商名称
            param.Add("@fee", ttAgentPreRechg.fee);//发生金额
            param.Add("@operatorId", ttAgentPreRechg.operatorId);//操作人编号
            param.Add("@operatorName", ttAgentPreRechg.operatorName);//操作人名称
            param.Add("@handleMode", ttAgentPreRechg.handleMode);//充值方式
            param.Add("@bankAccountId", ttAgentPreRechg.bankAccountId);//银行账号
            param.Add("@bankFlowId", ttAgentPreRechg.bankFlowId);//银行流水号
            param.Add("@description", ttAgentPreRechg.description);//说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 修改代理商充值预审
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentPreRechg">代理商充值预审</param>
        public override void Edit(DataAccess data, TTAgentPreRechg ttAgentPreRechg)
        {
            string strSQL = "update TTAgentPreRechg set auditStatus=@auditStatus where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@auditStatus", ttAgentPreRechg.auditStatus);//审核状态
            param.Add("@flowId", ttAgentPreRechg.flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
    }
}

