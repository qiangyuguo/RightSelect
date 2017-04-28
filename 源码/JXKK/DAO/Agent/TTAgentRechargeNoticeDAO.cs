using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理商充值提醒
    /// Author:开发人员自行扩展
    /// </summary>
    public class TTAgentRechargeNoticeDAO:TTAgentRechargeNoticeDBO
    {
        /// <summary>
        /// 增加代理商充值提醒
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentRechargeNotice">代理商充值提醒</param>
        /// </summary>
        public override void Add(DataAccess data, TTAgentRechargeNotice ttAgentRechargeNotice)
        {
            string strSQL = "insert into TTAgentRechargeNotice (flowId,agentId,agentName,fee,bankAccountId,dealWithStatus,transferAccDate,remark) values (SAgentRechargeNotice_flowId.Nextval,@agentId,@agentName,@fee,@bankAccountId,@dealWithStatus,To_date(@transferAccDate,'yyyy-mm-dd hh24:mi:ss'),@remark)";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", ttAgentRechargeNotice.agentId);//代理商编号
            param.Add("@agentName", ttAgentRechargeNotice.agentName);//代理商名称
            param.Add("@fee", ttAgentRechargeNotice.fee);//提现金额
            param.Add("@bankAccountId", ttAgentRechargeNotice.bankAccountId);//银行账号
            param.Add("@dealWithStatus", ttAgentRechargeNotice.dealWithStatus);//办理状态
            param.Add("@transferAccDate", ttAgentRechargeNotice.transferAccDate);//转账日期
            param.Add("@remark", ttAgentRechargeNotice.remark);//提现说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 修改代理商充值提醒
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentRechargeNotice">代理商充值提醒</param>
        /// </summary>
        public override void Edit(DataAccess data, TTAgentRechargeNotice ttAgentRechargeNotice)
        {
            string strSQL = "update TTAgentRechargeNotice set dealWithStatus=@dealWithStatus,operatorId=@operatorId,operatorName=@operatorName,opinion=@opinion,dealWithTime=To_date(@dealWithTime,'yyyy-mm-dd hh24:mi:ss') where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@dealWithStatus", ttAgentRechargeNotice.dealWithStatus);//办理状态
            param.Add("@operatorId", ttAgentRechargeNotice.operatorId);//办理人编号
            param.Add("@operatorName", ttAgentRechargeNotice.operatorName);//办理人名称
            param.Add("@opinion", ttAgentRechargeNotice.opinion);//办理意见
            param.Add("@dealWithTime", ttAgentRechargeNotice.dealWithTime);//办理时间
            param.Add("@flowId", ttAgentRechargeNotice.flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
    }
}

