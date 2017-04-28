using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理账户明细
    /// Author:开发人员自行扩展
    /// </summary>
    public class TTAgentAccDetailDAO:TTAgentAccDetailDBO
    {
        /// <summary>
        /// 增加代理账户明细
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentAccDetail">代理账户明细</param>
        /// </summary>
        public override void Add(DataAccess data, TTAgentAccDetail ttAgentAccDetail)
        {
            string strSQL = "insert into TTAgentAccDetail (flowId,agentId,agentName,lastBalance,fee,balance,remark) values (SAgentAccDetail_flowId.Nextval,@agentId,@agentName,@lastBalance,@fee,@balance,@remark)";
            Param param = new Param();
            param.Clear();
            //param.Add("@flowId", ttAgentAccDetail.flowId);//流水号
            param.Add("@agentId", ttAgentAccDetail.agentId);//代理商编号
            param.Add("@agentName", ttAgentAccDetail.agentName);//代理商名称
            param.Add("@lastBalance", ttAgentAccDetail.lastBalance);//上次余额
            param.Add("@fee", ttAgentAccDetail.fee);//发生金额
            param.Add("@balance", ttAgentAccDetail.balance);//当前余额
            param.Add("@remark", ttAgentAccDetail.remark);//信息摘要
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }


        /// <summary>
        /// 获取列表(代理商账户明细)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理商账户明细列表对象</returns>
        public List<TTAgentAccDetail> GetTTAgentAccDetailList(string strSQL, Param param)
        {
            List<TTAgentAccDetail> list = new List<TTAgentAccDetail>();
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while (dr.Read())
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
    }
}

