using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 接口服务账号
    /// Author:代码生成器
    /// </summary>
    public class TSConnectDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加接口服务账号
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsConnect">接口服务账号</param>
        public virtual void Add(DataAccess data,TSConnect tsConnect)
        {
            string strSQL = "insert into TSConnect (ConncetId,Token) values (@ConncetId,@Token)";
            Param param = new Param();
            param.Clear();
            param.Add("@ConncetId", tsConnect.ConncetId);//连接端编号
            param.Add("@Token", tsConnect.Token);//口令
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加接口服务账号
        /// </summary>
        /// <param name="tsConnect">接口服务账号</param>
        public virtual void Add(TSConnect tsConnect)
        {
            try
            {
                db.Open();
                Add(db,tsConnect);
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
        /// 修改接口服务账号
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsConnect">接口服务账号</param>
        public virtual void Edit(DataAccess data,TSConnect tsConnect)
        {
            string strSQL = "update TSConnect set Token=@Token where ConncetId=@ConncetId";
            Param param = new Param();
            param.Clear();
            param.Add("@Token", tsConnect.Token);//口令
            param.Add("@ConncetId", tsConnect.ConncetId);//连接端编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改接口服务账号
        /// </summary>
        /// <param name="tsConnect">接口服务账号</param>
        public virtual void Edit(TSConnect tsConnect)
        {
            try
            {
                db.Open();
                Edit(db,tsConnect);
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
        /// 删除接口服务账号
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ConncetId">连接端编号</param>
        public virtual void Delete(DataAccess data,string ConncetId)
        {
            string strSQL = "delete from TSConnect where ConncetId=@ConncetId";
            Param param = new Param();
            param.Clear();
            param.Add("@ConncetId", ConncetId);//连接端编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除接口服务账号
        /// </summary>
        /// <param name="ConncetId">连接端编号</param>
        public virtual void Delete(string ConncetId)
        {
            try
            {
                db.Open();
                Delete(db,ConncetId);
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
        /// 获取接口服务账号
        /// </summary>
        /// <param name="ConncetId">连接端编号</param>
        /// <returns>接口服务账号对象</returns>
        public virtual TSConnect Get(string ConncetId)
        {
            TSConnect tsConnect=null;
            try
            {
                string strSQL = "select * from TSConnect where ConncetId=@ConncetId";
                Param param = new Param();
                param.Clear();
                param.Add("@ConncetId", ConncetId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsConnect=ReadData(dr);
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
            return tsConnect;
        }
        
        /// <summary>
        /// 获取列表(接口服务账号)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>接口服务账号列表对象</returns>
        public virtual List<TSConnect> GetList(string strSQL,Param param)
        {
            List<TSConnect> list = new List<TSConnect>();
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
        /// 获取列表(接口服务账号)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>接口服务账号列表对象</returns>
        public virtual List<TSConnect> GetList(string field, string value)
        {
            List<TSConnect> list = new List<TSConnect>();
            try
            {
                string strSQL = "select * from TSConnect where " + field + "=@field";
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
        /// 获取DataSet(接口服务账号)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>接口服务账号DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSConnect");
        }
        
        /// <summary>
        /// 是否存在记录(接口服务账号)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSConnect where " + field + "=@field";
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
        /// 读取接口服务账号信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>接口服务账号对象</returns>
        protected virtual TSConnect ReadData(ComDataReader dr)
        {
            TSConnect tsConnect= new TSConnect();
            tsConnect.ConncetId= dr["ConncetId"].ToString();//连接端编号
            tsConnect.Token= dr["Token"].ToString();//口令
            return tsConnect;
        }
        
        
        #endregion
        
    }
}

