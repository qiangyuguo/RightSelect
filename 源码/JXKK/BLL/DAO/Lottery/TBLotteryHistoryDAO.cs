using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Lottery;

namespace Com.ZY.JXKK.DAO.Lottery
{
    /// <summary>
    /// 开奖历史
    /// Author:代码生成器
    /// </summary>
    public class TBLotteryHistoryDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加开奖历史
        /// <param name="data">数据库连接</param>
        /// <param name="tbLotteryHistory">开奖历史</param>
        /// </summary>
        public void Add(DataAccess data,TBLotteryHistory tbLotteryHistory)
        {
            string strSQL = "insert into TBLotteryHistory (lotteryType,period,startTime,endTime,publishTime,saleStatus,numbers,remark) values (:lotteryType,:period,To_date(:startTime,'yyyy-mm-dd hh24:mi:ss'),To_date(:endTime,'yyyy-mm-dd hh24:mi:ss'),To_date(:publishTime,'yyyy-mm-dd hh24:mi:ss'),:saleStatus,:numbers,:remark)";
            Param param = new Param();
            param.Clear();
            param.Add(":lotteryType", tbLotteryHistory.lotteryType);//彩种
            param.Add(":period", tbLotteryHistory.period);//期次
            param.Add(":startTime", tbLotteryHistory.startTime);//开售时间
            param.Add(":endTime", tbLotteryHistory.endTime);//截止时间
            param.Add(":publishTime", tbLotteryHistory.publishTime);//开奖时间
            param.Add(":saleStatus", tbLotteryHistory.saleStatus);//销售状态
            param.Add(":numbers", tbLotteryHistory.numbers);//开奖号码
            param.Add(":remark", tbLotteryHistory.remark);//备注说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加开奖历史
        /// <param name="tbLotteryHistory">开奖历史</param>
        /// </summary>
        public void Add(TBLotteryHistory tbLotteryHistory)
        {
            try
            {
                db.Open();
                Add(db,tbLotteryHistory);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
        
        /// <summary>
        /// 修改开奖历史
        /// <param name="data">数据库连接</param>
        /// <param name="tbLotteryHistory">开奖历史</param>
        /// </summary>
        public void Edit(DataAccess data,TBLotteryHistory tbLotteryHistory)
        {
            string strSQL = "update TBLotteryHistory set period=:period,startTime=To_date(:startTime,'yyyy-mm-dd hh24:mi:ss'),endTime=To_date(:endTime,'yyyy-mm-dd hh24:mi:ss'),publishTime=To_date(:publishTime,'yyyy-mm-dd hh24:mi:ss'),saleStatus=:saleStatus,numbers=:numbers,remark=:remark where lotteryType=:lotteryType";
            Param param = new Param();
            param.Clear();
            param.Add(":period", tbLotteryHistory.period);//期次
            param.Add(":startTime", tbLotteryHistory.startTime);//开售时间
            param.Add(":endTime", tbLotteryHistory.endTime);//截止时间
            param.Add(":publishTime", tbLotteryHistory.publishTime);//开奖时间
            param.Add(":saleStatus", tbLotteryHistory.saleStatus);//销售状态
            param.Add(":numbers", tbLotteryHistory.numbers);//开奖号码
            param.Add(":remark", tbLotteryHistory.remark);//备注说明
            param.Add(":lotteryType", tbLotteryHistory.lotteryType);//彩种
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改开奖历史
        /// <param name="tbLotteryHistory">开奖历史</param>
        /// </summary>
        public void Edit(TBLotteryHistory tbLotteryHistory)
        {
            try
            {
                db.Open();
                Edit(db,tbLotteryHistory);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
        
        /// <summary>
        /// 删除开奖历史
        /// <param name="data">数据库连接</param>
        /// <param name="lotteryType">彩种</param>
        /// </summary>
        public void Delete(DataAccess data,string lotteryType)
        {
            string strSQL = "delete from TBLotteryHistory where lotteryType=:lotteryType";
            Param param = new Param();
            param.Clear();
            param.Add(":lotteryType", lotteryType);//彩种
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除开奖历史
        /// <param name="lotteryType">彩种</param>
        /// </summary>
        public void Delete(string lotteryType)
        {
            try
            {
                db.Open();
                Delete(db,lotteryType);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
        
        /// <summary>
        /// 获取开奖历史
        /// <param name="lotteryType">彩种</param>
        /// </summary>
        /// <returns>开奖历史对象</returns>
        public TBLotteryHistory Get(string lotteryType)
        {
            TBLotteryHistory tbLotteryHistory=null;
            try
            {
                string strSQL = "select * from TBLotteryHistory where lotteryType=:lotteryType";
                Param param = new Param();
                param.Clear();
                param.Add(":lotteryType", lotteryType);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbLotteryHistory=ReadData(dr);
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
            return tbLotteryHistory;
        }
        
        /// <summary>
        /// 获取列表(开奖历史)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>开奖历史列表对象</returns>
        public List<TBLotteryHistory> GetList(string strSQL,Param param)
        {
            List<TBLotteryHistory> list = new List<TBLotteryHistory>();
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while(dr.Read())
                {
                    list.Add(ReadData(dr));
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
            return list;
        }
        
        /// <summary>
        /// 获取列表(开奖历史)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>开奖历史列表对象</returns>
        public List<TBLotteryHistory> GetList(string field, string value)
        {
            List<TBLotteryHistory> list = new List<TBLotteryHistory>();
            try
            {
                string strSQL = "select * from TBLotteryHistory where " + field + "=:field";
                Param param = new Param();
                param.Clear();
                param.Add(":field",value);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while(dr.Read())
                {
                    list.Add(ReadData(dr));
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
            return list;
        }
        
        /// <summary>
        /// 获取DataSet(开奖历史)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>开奖历史DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBLotteryHistory");
        }
        
        /// <summary>
        /// 是否存在记录(开奖历史)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBLotteryHistory where " + field + "=:field";
                Param param = new Param();
                param.Clear();
                param.Add(":field",value);
                db.Open();
                num = int.Parse(db.ExecuteScalar(CommandType.Text, strSQL, param).ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
            return num > 0;
        }
        
        /// <summary>
        /// 读取开奖历史信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>开奖历史对象</returns>
        private TBLotteryHistory ReadData(ComDataReader dr)
        {
            TBLotteryHistory tbLotteryHistory= new TBLotteryHistory();
            tbLotteryHistory.lotteryType= dr["lotteryType"].ToString();//彩种
            tbLotteryHistory.period= dr["period"].ToString();//期次
            if(dr["startTime"]==null)
            {
                tbLotteryHistory.startTime= "";//开售时间
            }
            else
            {
                tbLotteryHistory.startTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["startTime"]);//开售时间
            }
            if(dr["endTime"]==null)
            {
                tbLotteryHistory.endTime= "";//截止时间
            }
            else
            {
                tbLotteryHistory.endTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["endTime"]);//截止时间
            }
            if(dr["publishTime"]==null)
            {
                tbLotteryHistory.publishTime= "";//开奖时间
            }
            else
            {
                tbLotteryHistory.publishTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["publishTime"]);//开奖时间
            }
            tbLotteryHistory.saleStatus= dr["saleStatus"].ToString();//销售状态
            tbLotteryHistory.numbers= dr["numbers"].ToString();//开奖号码
            tbLotteryHistory.remark= dr["remark"].ToString();//备注说明
            return tbLotteryHistory;
        }
        
        
        #endregion
        
    }
}

