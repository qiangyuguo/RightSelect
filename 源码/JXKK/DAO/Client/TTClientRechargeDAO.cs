using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Client
{
    /// <summary>
    /// 客户充值
    /// Author:开发人员自行扩展
    /// </summary>
    public class TTClientRechargeDAO:TTClientRechargeDBO
    {
        /// <summary>
        /// 获取客户充值总计
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>客户充值double</returns>
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

        /// <summary>
        /// 获取客户充值
        /// <param name="flowId">流水号</param>
        /// </summary>
        /// <returns>客户充值对象</returns>
        public override TTClientRecharge Get(long flowId)
        {
            TTClientRecharge ttClientRecharge = null;
            try
            {
                string strSQL = @"select flowid, clientid,  clientname,  a.agentname agentid,  s.sitename siteid, lastbalance, fee, 
                                   balance,  operatorid, operatorname, createtime, cardid, sourcetype,timeStamp, description,  p.modename handlemode 
                                   from TTClientRecharge c,TBAgent a,TBSite s,TBPaymode p
                                   where c.agentid=a.agentid and c.siteid=s.siteid 
                                   and c.handlemode=p.modeid and flowId=@flowId";
                Param param = new Param();
                param.Clear();
                param.Add("@flowId", flowId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttClientRecharge = ReadData(dr);
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
            return ttClientRecharge;
        }
    }
}

