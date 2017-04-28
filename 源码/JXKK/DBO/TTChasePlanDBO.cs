using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 追号计划
    /// Author:代码生成器
    /// </summary>
    public class TTChasePlanDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加追号计划
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttChasePlan">追号计划</param>
        public virtual void Add(DataAccess data,TTChasePlan ttChasePlan)
        {
            string strSQL = "insert into TTChasePlan (orderId,chaseOrderId,period,multiple,betFee,sumPayFee,awardFee,winFee,winRate,createTime) values (@orderId,@chaseOrderId,@period,@multiple,@betFee,@sumPayFee,@awardFee,@winFee,@winRate,To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'))";
            Param param = new Param();
            param.Clear();
            param.Add("@orderId", ttChasePlan.orderId);//订单号
            param.Add("@chaseOrderId", ttChasePlan.chaseOrderId);//追号订单编号
            param.Add("@period", ttChasePlan.period);//期次
            param.Add("@multiple", ttChasePlan.multiple);//倍数
            param.Add("@betFee", ttChasePlan.betFee);//投注金额
            param.Add("@sumPayFee", ttChasePlan.sumPayFee);//累计投注金额
            param.Add("@awardFee", ttChasePlan.awardFee);//可中奖金额
            param.Add("@winFee", ttChasePlan.winFee);//盈利金额
            param.Add("@winRate", ttChasePlan.winRate);//盈利率
            param.Add("@createTime", ttChasePlan.createTime);//创建时间
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加追号计划
        /// </summary>
        /// <param name="ttChasePlan">追号计划</param>
        public virtual void Add(TTChasePlan ttChasePlan)
        {
            try
            {
                db.Open();
                Add(db,ttChasePlan);
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
        /// 修改追号计划
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttChasePlan">追号计划</param>
        public virtual void Edit(DataAccess data,TTChasePlan ttChasePlan)
        {
            string strSQL = "update TTChasePlan set chaseOrderId=@chaseOrderId,period=@period,multiple=@multiple,betFee=@betFee,sumPayFee=@sumPayFee,awardFee=@awardFee,winFee=@winFee,winRate=@winRate,createTime=To_date(@createTime,'yyyy-mm-dd hh24:mi:ss') where orderId=@orderId";
            Param param = new Param();
            param.Clear();
            param.Add("@chaseOrderId", ttChasePlan.chaseOrderId);//追号订单编号
            param.Add("@period", ttChasePlan.period);//期次
            param.Add("@multiple", ttChasePlan.multiple);//倍数
            param.Add("@betFee", ttChasePlan.betFee);//投注金额
            param.Add("@sumPayFee", ttChasePlan.sumPayFee);//累计投注金额
            param.Add("@awardFee", ttChasePlan.awardFee);//可中奖金额
            param.Add("@winFee", ttChasePlan.winFee);//盈利金额
            param.Add("@winRate", ttChasePlan.winRate);//盈利率
            param.Add("@createTime", ttChasePlan.createTime);//创建时间
            param.Add("@orderId", ttChasePlan.orderId);//订单号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改追号计划
        /// </summary>
        /// <param name="ttChasePlan">追号计划</param>
        public virtual void Edit(TTChasePlan ttChasePlan)
        {
            try
            {
                db.Open();
                Edit(db,ttChasePlan);
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
        /// 删除追号计划
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="orderId">订单号</param>
        public virtual void Delete(DataAccess data,string orderId)
        {
            string strSQL = "delete from TTChasePlan where orderId=@orderId";
            Param param = new Param();
            param.Clear();
            param.Add("@orderId", orderId);//订单号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除追号计划
        /// </summary>
        /// <param name="orderId">订单号</param>
        public virtual void Delete(string orderId)
        {
            try
            {
                db.Open();
                Delete(db,orderId);
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
        /// 获取追号计划
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <returns>追号计划对象</returns>
        public virtual TTChasePlan Get(string orderId)
        {
            TTChasePlan ttChasePlan=null;
            try
            {
                string strSQL = "select * from TTChasePlan where orderId=@orderId";
                Param param = new Param();
                param.Clear();
                param.Add("@orderId", orderId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttChasePlan=ReadData(dr);
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
            return ttChasePlan;
        }
        
        /// <summary>
        /// 获取列表(追号计划)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>追号计划列表对象</returns>
        public virtual List<TTChasePlan> GetList(string strSQL,Param param)
        {
            List<TTChasePlan> list = new List<TTChasePlan>();
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while(dr.Read())
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
        
        /// <summary>
        /// 获取列表(追号计划)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>追号计划列表对象</returns>
        public virtual List<TTChasePlan> GetList(string field, string value)
        {
            List<TTChasePlan> list = new List<TTChasePlan>();
            try
            {
                string strSQL = "select * from TTChasePlan where " + field + "=@field";
                Param param = new Param();
                param.Clear();
                param.Add("@field",value);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while(dr.Read())
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
        
        /// <summary>
        /// 获取DataSet(追号计划)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>追号计划DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTChasePlan");
        }
        
        /// <summary>
        /// 是否存在记录(追号计划)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTChasePlan where " + field + "=@field";
                Param param = new Param();
                param.Clear();
                param.Add("@field",value);
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
        /// 读取追号计划信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>追号计划对象</returns>
        protected virtual TTChasePlan ReadData(ComDataReader dr)
        {
            TTChasePlan ttChasePlan= new TTChasePlan();
            ttChasePlan.orderId= dr["orderId"].ToString();//订单号
            ttChasePlan.chaseOrderId= dr["chaseOrderId"].ToString();//追号订单编号
            ttChasePlan.period= dr["period"].ToString();//期次
            ttChasePlan.multiple= int.Parse(dr["multiple"].ToString());//倍数
            ttChasePlan.betFee= double.Parse(dr["betFee"].ToString());//投注金额
            ttChasePlan.sumPayFee= double.Parse(dr["sumPayFee"].ToString());//累计投注金额
            ttChasePlan.awardFee= dr["awardFee"].ToString();//可中奖金额
            ttChasePlan.winFee= dr["winFee"].ToString();//盈利金额
            ttChasePlan.winRate= dr["winRate"].ToString();//盈利率
            if(dr["createTime"]==null)
            {
                ttChasePlan.createTime= "";//创建时间
            }
            else
            {
                ttChasePlan.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            return ttChasePlan;
        }
        
        
        #endregion
        
    }
}

