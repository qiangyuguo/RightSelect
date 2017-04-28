using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 开奖公告
    /// Author:代码生成器
    /// </summary>
    public class TBNumNoticeDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加开奖公告
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbNumNotice">开奖公告</param>
        public virtual void Add(DataAccess data,TBNumNotice tbNumNotice)
        {
            string strSQL = "insert into TBNumNotice (flowId,gameId,lotteryType,period,startTime,endTime,publishTime,numbers) values (@flowId,@gameId,@lotteryType,@period,@startTime,@endTime,@publishTime,@numbers)";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", tbNumNotice.flowId);//流水号
            param.Add("@gameId", tbNumNotice.gameId);//游戏编号
            param.Add("@lotteryType", tbNumNotice.lotteryType);//彩种
            param.Add("@period", tbNumNotice.period);//期次
            param.Add("@startTime", tbNumNotice.startTime);//开售时间
            param.Add("@endTime", tbNumNotice.endTime);//截止时间
            param.Add("@publishTime", tbNumNotice.publishTime);//开奖时间
            param.Add("@numbers", tbNumNotice.numbers);//开奖号码
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加开奖公告
        /// </summary>
        /// <param name="tbNumNotice">开奖公告</param>
        public virtual void Add(TBNumNotice tbNumNotice)
        {
            try
            {
                db.Open();
                Add(db,tbNumNotice);
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
        /// 修改开奖公告
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbNumNotice">开奖公告</param>
        public virtual void Edit(DataAccess data,TBNumNotice tbNumNotice)
        {
            string strSQL = "update TBNumNotice set lotteryType=@lotteryType,period=@period,startTime=@startTime,endTime=@endTime,publishTime=@publishTime,numbers=@numbers where flowId=@flowId and gameId=@gameId";
            Param param = new Param();
            param.Clear();
            param.Add("@lotteryType", tbNumNotice.lotteryType);//彩种
            param.Add("@period", tbNumNotice.period);//期次
            param.Add("@startTime", tbNumNotice.startTime);//开售时间
            param.Add("@endTime", tbNumNotice.endTime);//截止时间
            param.Add("@publishTime", tbNumNotice.publishTime);//开奖时间
            param.Add("@numbers", tbNumNotice.numbers);//开奖号码
            param.Add("@flowId", tbNumNotice.flowId);//流水号
            param.Add("@gameId", tbNumNotice.gameId);//游戏编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改开奖公告
        /// </summary>
        /// <param name="tbNumNotice">开奖公告</param>
        public virtual void Edit(TBNumNotice tbNumNotice)
        {
            try
            {
                db.Open();
                Edit(db,tbNumNotice);
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
        /// 删除开奖公告
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="flowId">流水号</param>
        /// <param name="gameId">游戏编号</param>
        public virtual void Delete(DataAccess data,string flowId,string gameId)
        {
            string strSQL = "delete from TBNumNotice where flowId=@flowId and gameId=@gameId";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", flowId);//流水号
            param.Add("@gameId", gameId);//游戏编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除开奖公告
        /// </summary>
        /// <param name="flowId">流水号</param>
        /// <param name="gameId">游戏编号</param>
        public virtual void Delete(string flowId,string gameId)
        {
            try
            {
                db.Open();
                Delete(db,flowId,gameId);
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
        /// 获取开奖公告
        /// </summary>
        /// <param name="flowId">流水号</param>
        /// <param name="gameId">游戏编号</param>
        /// <returns>开奖公告对象</returns>
        public virtual TBNumNotice Get(string flowId,string gameId)
        {
            TBNumNotice tbNumNotice=null;
            try
            {
                string strSQL = "select * from TBNumNotice where flowId=@flowId and gameId=@gameId";
                Param param = new Param();
                param.Clear();
                param.Add("@flowId", flowId);
                param.Add("@gameId", gameId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbNumNotice=ReadData(dr);
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
            return tbNumNotice;
        }
        
        /// <summary>
        /// 获取列表(开奖公告)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>开奖公告列表对象</returns>
        public virtual List<TBNumNotice> GetList(string strSQL,Param param)
        {
            List<TBNumNotice> list = new List<TBNumNotice>();
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
        /// 获取列表(开奖公告)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>开奖公告列表对象</returns>
        public virtual List<TBNumNotice> GetList(string field, string value)
        {
            List<TBNumNotice> list = new List<TBNumNotice>();
            try
            {
                string strSQL = "select * from TBNumNotice where " + field + "=@field";
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
        /// 获取DataSet(开奖公告)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>开奖公告DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBNumNotice");
        }
        
        /// <summary>
        /// 是否存在记录(开奖公告)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBNumNotice where " + field + "=@field";
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
        /// 读取开奖公告信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>开奖公告对象</returns>
        protected virtual TBNumNotice ReadData(ComDataReader dr)
        {
            TBNumNotice tbNumNotice= new TBNumNotice();
            tbNumNotice.flowId= dr["flowId"].ToString();//流水号
            tbNumNotice.gameId= dr["gameId"].ToString();//游戏编号
            tbNumNotice.lotteryType= dr["lotteryType"].ToString();//彩种
            tbNumNotice.period= dr["period"].ToString();//期次
            tbNumNotice.startTime= dr["startTime"].ToString();//开售时间
            tbNumNotice.endTime= dr["endTime"].ToString();//截止时间
            tbNumNotice.publishTime= dr["publishTime"].ToString();//开奖时间
            tbNumNotice.numbers= dr["numbers"].ToString();//开奖号码
            return tbNumNotice;
        }
        
        
        #endregion
        
    }
}

