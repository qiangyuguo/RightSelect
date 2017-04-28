using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Client
{
    /// <summary>
    /// 客户提现
    /// Author:开发人员自行扩展
    /// </summary>
    public class TTClientTakeCashDAO:TTClientTakeCashDBO
    {
        /// <summary>
        /// 获取客户提现总计
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>客户提现double</returns>
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
        /// 获取客户提现
        /// <param name="flowId">流水号</param>
        /// </summary>
        /// <returns>客户提现对象</returns>
        public override TTClientTakeCash Get(long flowId)
        {
            TTClientTakeCash ttClientTakeCash = null;
            try
            {
                string strSQL = @"select flowid, clientid,  clientname,  a.agentname agentid,  s.sitename siteid, lastbalance, fee, 
                                   balance,  operatorid, operatorname, createtime, cardid, sourcetype, description, timeStamp, p.modename handlemode 
                                   from Ttclienttakecash c,TBAgent a,TBSite s,TBPaymode p
                                   where c.agentid=a.agentid and c.siteid=s.siteid 
                                   and c.handlemode=p.modeid and flowId=@flowId";
                Param param = new Param();
                param.Clear();
                param.Add("@flowId", flowId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttClientTakeCash = ReadData(dr);
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
            return ttClientTakeCash;
        }


        /// <summary>
        /// 获取列表(客户提现)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>客户提现列表对象</returns>
        public List<ClientTakeCashFee> GetClientTakeCashFeeList(string strSQL, Param param)
        {
            List<ClientTakeCashFee> list = new List<ClientTakeCashFee>();
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while (dr.Read())
                {
                    list.Add(FeeReadData(dr));
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
        /// 读取客户提现信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>客户提现对象</returns>
        protected  ClientTakeCashFee FeeReadData(ComDataReader dr)
        {
            ClientTakeCashFee clientTakeCashFee = new ClientTakeCashFee();
            clientTakeCashFee.CreateDate = dr["CreateDate"].ToString();//创建时间
            clientTakeCashFee.SumFee = double.Parse(dr["SumFee"].ToString());//提现金额
            return clientTakeCashFee;
        }
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public DataTable ClientTakeCashDT(string strSQL)
        {
            Param param = new Param();
            DataTable dt = db.ExecuteDataView(CommandType.Text, strSQL, param).Table;
            return dt;
        }

        public int TakeCash(string strSql,Param param)
        {
            db.Open();
            int i=db.ExecuteNonQuery(CommandType.Text,strSql,param);
            db.Close();
            return i;
        }
    }
}

