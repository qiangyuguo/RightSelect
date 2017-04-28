using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Client
{
    /// <summary>
    /// 客户信息
    /// Author:开发人员自行扩展
    /// </summary>
    public class TBClientDAO:TBClientDBO
    {
        /// <summary>
        /// 根据卡号获取客户信息
        /// <param name="cardId">客户卡号</param>
        /// </summary>
        /// <returns>客户信息对象</returns>
        public TBClient GetByCard(long cardId)
        {
            TBClient tbClient = null;
            try
            {
                string strSQL = "select * from TBClient where status='0' and cardId=@cardId";
                Param param = new Param();
                param.Clear();
                param.Add("@cardId", cardId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbClient = ReadData(dr);
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
            return tbClient;
        }

        /// <summary>
        /// 获取客户充值总计
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>推荐人佣金double</returns>
        public double GetTotalCommiss(string strSQL, Param param)
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
        /// 获取余额积分总计
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>余额积分double</returns>
        public double GetTotalValue(string strSQL, Param param)
        {
            double totalValue;
            try
            {
                db.Open();
                object obj = db.ExecuteScalar(CommandType.Text, strSQL, param);
                if (obj == DBNull.Value)
                {
                    totalValue = 0;
                }
                else
                {
                    totalValue = double.Parse(obj.ToString());
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

            return totalValue;
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public DataTable ClientDT(string strSQL)
        {
            Param param = new Param();
            DataTable dt = db.ExecuteDataView(CommandType.Text, strSQL, param).Table;
            return dt;
        }
    }
}

