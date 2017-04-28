using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 彩种类型
    /// Author:代码生成器
    /// </summary>
    public class TBLotteryDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加彩种类型
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbLottery">彩种类型</param>
        public virtual void Add(DataAccess data,TBLottery tbLottery)
        {
            string strSQL = "insert into TBLottery (LotteryType,LotteryTypeName,isUse) values (@LotteryType,@LotteryTypeName,@isUse)";
            Param param = new Param();
            param.Clear();
            param.Add("@LotteryType", tbLottery.LotteryType);//彩种编号
            param.Add("@LotteryTypeName", tbLottery.LotteryTypeName);//彩种名称
            param.Add("@isUse", tbLottery.isUse);//使用状态
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加彩种类型
        /// </summary>
        /// <param name="tbLottery">彩种类型</param>
        public virtual void Add(TBLottery tbLottery)
        {
            try
            {
                db.Open();
                Add(db,tbLottery);
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
        /// 修改彩种类型
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbLottery">彩种类型</param>
        public virtual void Edit(DataAccess data,TBLottery tbLottery)
        {
            string strSQL = "update TBLottery set LotteryTypeName=@LotteryTypeName,isUse=@isUse where LotteryType=@LotteryType";
            Param param = new Param();
            param.Clear();
            param.Add("@LotteryTypeName", tbLottery.LotteryTypeName);//彩种名称
            param.Add("@isUse", tbLottery.isUse);//使用状态
            param.Add("@LotteryType", tbLottery.LotteryType);//彩种编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改彩种类型
        /// </summary>
        /// <param name="tbLottery">彩种类型</param>
        public virtual void Edit(TBLottery tbLottery)
        {
            try
            {
                db.Open();
                Edit(db,tbLottery);
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
        /// 删除彩种类型
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="LotteryType">彩种编号</param>
        public virtual void Delete(DataAccess data,string LotteryType)
        {
            string strSQL = "delete from TBLottery where LotteryType=@LotteryType";
            Param param = new Param();
            param.Clear();
            param.Add("@LotteryType", LotteryType);//彩种编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除彩种类型
        /// </summary>
        /// <param name="LotteryType">彩种编号</param>
        public virtual void Delete(string LotteryType)
        {
            try
            {
                db.Open();
                Delete(db,LotteryType);
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
        /// 获取彩种类型
        /// </summary>
        /// <param name="LotteryType">彩种编号</param>
        /// <returns>彩种类型对象</returns>
        public virtual TBLottery Get(string LotteryType)
        {
            TBLottery tbLottery=null;
            try
            {
                string strSQL = "select * from TBLottery where LotteryType=@LotteryType";
                Param param = new Param();
                param.Clear();
                param.Add("@LotteryType", LotteryType);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbLottery=ReadData(dr);
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
            return tbLottery;
        }
        
        /// <summary>
        /// 获取列表(彩种类型)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>彩种类型列表对象</returns>
        public virtual List<TBLottery> GetList(string strSQL,Param param)
        {
            List<TBLottery> list = new List<TBLottery>();
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
        /// 获取列表(彩种类型)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>彩种类型列表对象</returns>
        public virtual List<TBLottery> GetList(string field, string value)
        {
            List<TBLottery> list = new List<TBLottery>();
            try
            {
                string strSQL = "select * from TBLottery where " + field + "=@field";
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
        /// 获取DataSet(彩种类型)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>彩种类型DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBLottery");
        }
        
        /// <summary>
        /// 是否存在记录(彩种类型)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBLottery where " + field + "=@field";
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
        /// 读取彩种类型信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>彩种类型对象</returns>
        protected virtual TBLottery ReadData(ComDataReader dr)
        {
            TBLottery tbLottery= new TBLottery();
            tbLottery.LotteryType= dr["LotteryType"].ToString();//彩种编号
            tbLottery.LotteryTypeName= dr["LotteryTypeName"].ToString();//彩种名称
            tbLottery.isUse= dr["isUse"].ToString();//使用状态
            return tbLottery;
        }
        
        
        #endregion
        
    }
}

