using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 积分投注开奖公告
    /// Author:代码生成器
    /// </summary>
    public class TBPNumNoticeDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加积分投注开奖公告
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbPNumNotice">积分投注开奖公告</param>
        public virtual void Add(DataAccess data,TBPNumNotice tbPNumNotice)
        {
            string strSQL = "insert into TBPNumNotice (flowId,gameId,period,startTime,endTime,publishTime,numbers) values (@flowId,@gameId,@period,@startTime,@endTime,@publishTime,@numbers)";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", tbPNumNotice.flowId);//流水号
            param.Add("@gameId", tbPNumNotice.gameId);//游戏编号
            param.Add("@period", tbPNumNotice.period);//期次
            param.Add("@startTime", tbPNumNotice.startTime);//开售时间
            param.Add("@endTime", tbPNumNotice.endTime);//截止时间
            param.Add("@publishTime", tbPNumNotice.publishTime);//开奖时间
            param.Add("@numbers", tbPNumNotice.numbers);//开奖号码
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加积分投注开奖公告
        /// </summary>
        /// <param name="tbPNumNotice">积分投注开奖公告</param>
        public virtual void Add(TBPNumNotice tbPNumNotice)
        {
            try
            {
                db.Open();
                Add(db,tbPNumNotice);
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
        /// 修改积分投注开奖公告
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbPNumNotice">积分投注开奖公告</param>
        public virtual void Edit(DataAccess data,TBPNumNotice tbPNumNotice)
        {
            string strSQL = "update TBPNumNotice set gameId=@gameId,period=@period,startTime=@startTime,endTime=@endTime,publishTime=@publishTime,numbers=@numbers where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@gameId", tbPNumNotice.gameId);//游戏编号
            param.Add("@period", tbPNumNotice.period);//期次
            param.Add("@startTime", tbPNumNotice.startTime);//开售时间
            param.Add("@endTime", tbPNumNotice.endTime);//截止时间
            param.Add("@publishTime", tbPNumNotice.publishTime);//开奖时间
            param.Add("@numbers", tbPNumNotice.numbers);//开奖号码
            param.Add("@flowId", tbPNumNotice.flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改积分投注开奖公告
        /// </summary>
        /// <param name="tbPNumNotice">积分投注开奖公告</param>
        public virtual void Edit(TBPNumNotice tbPNumNotice)
        {
            try
            {
                db.Open();
                Edit(db,tbPNumNotice);
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
        /// 删除积分投注开奖公告
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="flowId">流水号</param>
        public virtual void Delete(DataAccess data,string flowId)
        {
            string strSQL = "delete from TBPNumNotice where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除积分投注开奖公告
        /// </summary>
        /// <param name="flowId">流水号</param>
        public virtual void Delete(string flowId)
        {
            try
            {
                db.Open();
                Delete(db,flowId);
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
        /// 获取积分投注开奖公告
        /// </summary>
        /// <param name="flowId">流水号</param>
        /// <returns>积分投注开奖公告对象</returns>
        public virtual TBPNumNotice Get(string flowId)
        {
            TBPNumNotice tbPNumNotice=null;
            try
            {
                string strSQL = "select * from TBPNumNotice where flowId=@flowId";
                Param param = new Param();
                param.Clear();
                param.Add("@flowId", flowId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbPNumNotice=ReadData(dr);
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
            return tbPNumNotice;
        }
        
        /// <summary>
        /// 获取列表(积分投注开奖公告)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>积分投注开奖公告列表对象</returns>
        public virtual List<TBPNumNotice> GetList(string strSQL,Param param)
        {
            List<TBPNumNotice> list = new List<TBPNumNotice>();
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
        /// 获取列表(积分投注开奖公告)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>积分投注开奖公告列表对象</returns>
        public virtual List<TBPNumNotice> GetList(string field, string value)
        {
            List<TBPNumNotice> list = new List<TBPNumNotice>();
            try
            {
                string strSQL = "select * from TBPNumNotice where " + field + "=@field";
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
        /// 获取DataSet(积分投注开奖公告)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>积分投注开奖公告DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBPNumNotice");
        }
        
        /// <summary>
        /// 是否存在记录(积分投注开奖公告)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBPNumNotice where " + field + "=@field";
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
        /// 读取积分投注开奖公告信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>积分投注开奖公告对象</returns>
        protected virtual TBPNumNotice ReadData(ComDataReader dr)
        {
            TBPNumNotice tbPNumNotice= new TBPNumNotice();
            tbPNumNotice.flowId= dr["flowId"].ToString();//流水号
            tbPNumNotice.gameId= dr["gameId"].ToString();//游戏编号
            tbPNumNotice.period= dr["period"].ToString();//期次
            tbPNumNotice.startTime= dr["startTime"].ToString();//开售时间
            tbPNumNotice.endTime= dr["endTime"].ToString();//截止时间
            tbPNumNotice.publishTime= dr["publishTime"].ToString();//开奖时间
            tbPNumNotice.numbers= dr["numbers"].ToString();//开奖号码
            return tbPNumNotice;
        }
        
        
        #endregion
        
    }
}

