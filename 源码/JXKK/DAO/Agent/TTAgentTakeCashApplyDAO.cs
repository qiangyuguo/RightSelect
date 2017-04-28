using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理商提现申请
    /// Author:开发人员自行扩展
    /// </summary>
    public class TTAgentTakeCashApplyDAO:TTAgentTakeCashApplyDBO
    {
        /// <summary>
        /// 增加代理商提现申请
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentTakeCashApply">代理商提现申请</param>
        /// </summary>
        public override void Add(DataAccess data, TTAgentTakeCashApply ttAgentTakeCashApply)
        {
            string strSQL = "insert into TTAgentTakeCashApply (flowId,agentId,agentName,fee,bankAccountId,dealWithStatus,remark) values (SAgentTakeCashApply_flowId.Nextval,@agentId,@agentName,@fee,@bankAccountId,@dealWithStatus,@remark)";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", ttAgentTakeCashApply.agentId);//代理商编号
            param.Add("@agentName", ttAgentTakeCashApply.agentName);//代理商名称
            param.Add("@fee", ttAgentTakeCashApply.fee);//提现金额
            param.Add("@bankAccountId", ttAgentTakeCashApply.bankAccountId);//银行账号
            param.Add("@dealWithStatus", ttAgentTakeCashApply.dealWithStatus);//办理状态
            param.Add("@remark", ttAgentTakeCashApply.remark);//提现说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        /// <summary>
        /// 修改代理商提现申请
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentTakeCashApply">代理商提现申请</param>
        /// </summary>
        public override void Edit(DataAccess data, TTAgentTakeCashApply ttAgentTakeCashApply)
        {
            string strSQL = "update TTAgentTakeCashApply set dealWithStatus=@dealWithStatus,transferAccDate=To_date(@transferAccDate,'yyyy-mm-dd hh24:mi:ss'),operatorId=@operatorId,operatorName=@operatorName,dealWithTime=To_date(@dealWithTime,'yyyy-mm-dd hh24:mi:ss'),opinion=@opinion where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@dealWithStatus", ttAgentTakeCashApply.dealWithStatus);//办理状态
            param.Add("@transferAccDate", ttAgentTakeCashApply.transferAccDate);//转账日期
            param.Add("@operatorId", ttAgentTakeCashApply.operatorId);//办理人编号
            param.Add("@operatorName", ttAgentTakeCashApply.operatorName);//办理人名称
            param.Add("@dealWithTime", ttAgentTakeCashApply.dealWithTime);//办理时间
            param.Add("@opinion", ttAgentTakeCashApply.opinion);//办理意见
            param.Add("@flowId", ttAgentTakeCashApply.flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 修改代理商提现申请
        /// <param name="ttAgentTakeCashApply">代理商提现申请</param>
        /// </summary>
        public void Edit(TTAgentTakeCashApply ttAgentTakeCashApply, TTAgentTakeCash ttAgentTakeCash, TBAgent tbAgent)
        {
            ComTransaction trans = null;
            try
            {
                db.Open();
                trans = db.BeginTransaction();
                //当只有申请通过才进行增加提现明细以及账户明细信息
                if (ttAgentTakeCashApply.dealWithStatus == ((int)DealWithStatus.HaveToDo).ToString())
                {
                    //增加到提现申请明细以及账户明细并修改代理商的余额信息
                    new TTAgentTakeCashDAO().Add(db, ttAgentTakeCash, tbAgent);
                }
                Edit(db, ttAgentTakeCashApply);//修改提现申请状态已经信息
               
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
    }
}

