using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Lottery;

namespace Com.ZY.JXKK.DAO.Lottery
{
    /// <summary>
    /// 彩票奖期
    /// Author:代码生成器
    /// </summary>
    public class TBLotteryPeriodDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加彩票奖期
        /// <param name="data">数据库连接</param>
        /// <param name="tbLotteryPeriod">彩票奖期</param>
        /// </summary>
        public void Add(DataAccess data,TBLotteryPeriod tbLotteryPeriod)
        {
            string strSQL = "insert into TBLotteryPeriod (lotteryType,period,startTime,endTime,publishTime,saleStatus,remark) values (:lotteryType,:period,To_date(:startTime,'yyyy-mm-dd hh24:mi:ss'),To_date(:endTime,'yyyy-mm-dd hh24:mi:ss'),To_date(:publishTime,'yyyy-mm-dd hh24:mi:ss'),:saleStatus,:remark)";
            Param param = new Param();
            param.Clear();
            param.Add(":lotteryType", tbLotteryPeriod.lotteryType);//彩种
            param.Add(":period", tbLotteryPeriod.period);//期次
            param.Add(":startTime", tbLotteryPeriod.startTime);//开售时间
            param.Add(":endTime", tbLotteryPeriod.endTime);//截止时间
            param.Add(":publishTime", tbLotteryPeriod.publishTime);//开奖时间
            param.Add(":saleStatus", tbLotteryPeriod.saleStatus);//销售状态
            param.Add(":remark", tbLotteryPeriod.remark);//备注说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加彩票奖期
        /// <param name="tbLotteryPeriod">彩票奖期</param>
        /// </summary>
        public void Add(TBLotteryPeriod tbLotteryPeriod)
        {
            try
            {
                db.Open();
                Add(db,tbLotteryPeriod);
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
        /// 修改彩票奖期
        /// <param name="data">数据库连接</param>
        /// <param name="tbLotteryPeriod">彩票奖期</param>
        /// </summary>
        public void Edit(DataAccess data,TBLotteryPeriod tbLotteryPeriod)
        {
            string strSQL = "update TBLotteryPeriod set period=:period,startTime=To_date(:startTime,'yyyy-mm-dd hh24:mi:ss'),endTime=To_date(:endTime,'yyyy-mm-dd hh24:mi:ss'),publishTime=To_date(:publishTime,'yyyy-mm-dd hh24:mi:ss'),saleStatus=:saleStatus,remark=:remark where lotteryType=:lotteryType";
            Param param = new Param();
            param.Clear();
            param.Add(":period", tbLotteryPeriod.period);//期次
            param.Add(":startTime", tbLotteryPeriod.startTime);//开售时间
            param.Add(":endTime", tbLotteryPeriod.endTime);//截止时间
            param.Add(":publishTime", tbLotteryPeriod.publishTime);//开奖时间
            param.Add(":saleStatus", tbLotteryPeriod.saleStatus);//销售状态
            param.Add(":remark", tbLotteryPeriod.remark);//备注说明
            param.Add(":lotteryType", tbLotteryPeriod.lotteryType);//彩种
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改彩票奖期
        /// <param name="tbLotteryPeriod">彩票奖期</param>
        /// </summary>
        public void Edit(TBLotteryPeriod tbLotteryPeriod)
        {
            try
            {
                db.Open();
                Edit(db,tbLotteryPeriod);
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
        /// 删除彩票奖期
        /// <param name="data">数据库连接</param>
        /// <param name="lotteryType">彩种</param>
        /// </summary>
        public void Delete(DataAccess data,string lotteryType)
        {
            string strSQL = "delete from TBLotteryPeriod where lotteryType=:lotteryType";
            Param param = new Param();
            param.Clear();
            param.Add(":lotteryType", lotteryType);//彩种
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除彩票奖期
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
        /// 获取彩票奖期
        /// <param name="lotteryType">彩种</param>
        /// </summary>
        /// <returns>彩票奖期对象</returns>
        public TBLotteryPeriod Get(string lotteryType)
        {
            TBLotteryPeriod tbLotteryPeriod=null;
            try
            {
                string strSQL = "select * from TBLotteryPeriod where lotteryType=:lotteryType";
                Param param = new Param();
                param.Clear();
                param.Add(":lotteryType", lotteryType);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbLotteryPeriod=ReadData(dr);
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
            return tbLotteryPeriod;
        }
        
        /// <summary>
        /// 获取列表(彩票奖期)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>彩票奖期列表对象</returns>
        public List<TBLotteryPeriod> GetList(string strSQL,Param param)
        {
            List<TBLotteryPeriod> list = new List<TBLotteryPeriod>();
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
        /// 获取列表(彩票奖期)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>彩票奖期列表对象</returns>
        public List<TBLotteryPeriod> GetList(string field, string value)
        {
            List<TBLotteryPeriod> list = new List<TBLotteryPeriod>();
            try
            {
                string strSQL = "select * from TBLotteryPeriod where " + field + "=:field";
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
        /// 获取DataSet(彩票奖期)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>彩票奖期DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBLotteryPeriod");
        }
        
        /// <summary>
        /// 是否存在记录(彩票奖期)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBLotteryPeriod where " + field + "=:field";
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
        /// 读取彩票奖期信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>彩票奖期对象</returns>
        private TBLotteryPeriod ReadData(ComDataReader dr)
        {
            TBLotteryPeriod tbLotteryPeriod= new TBLotteryPeriod();
            tbLotteryPeriod.lotteryType= dr["lotteryType"].ToString();//彩种
            tbLotteryPeriod.period= dr["period"].ToString();//期次
            if(dr["startTime"]==null)
            {
                tbLotteryPeriod.startTime= "";//开售时间
            }
            else
            {
                tbLotteryPeriod.startTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["startTime"]);//开售时间
            }
            if(dr["endTime"]==null)
            {
                tbLotteryPeriod.endTime= "";//截止时间
            }
            else
            {
                tbLotteryPeriod.endTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["endTime"]);//截止时间
            }
            if(dr["publishTime"]==null)
            {
                tbLotteryPeriod.publishTime= "";//开奖时间
            }
            else
            {
                tbLotteryPeriod.publishTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["publishTime"]);//开奖时间
            }
            tbLotteryPeriod.saleStatus= dr["saleStatus"].ToString();//销售状态
            tbLotteryPeriod.remark= dr["remark"].ToString();//备注说明
            return tbLotteryPeriod;
        }
        
        
        #endregion
        
    }
}

