using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 交易类型
    /// Author:代码生成器
    /// </summary>
    public class TBTradeTypeDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加交易类型
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbTradeType">交易类型</param>
        public virtual void Add(DataAccess data,TBTradeType tbTradeType)
        {
            string strSQL = "insert into TBTradeType (code,name) values (@code,@name)";
            Param param = new Param();
            param.Clear();
            param.Add("@code", tbTradeType.code);//代码
            param.Add("@name", tbTradeType.name);//名称
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加交易类型
        /// </summary>
        /// <param name="tbTradeType">交易类型</param>
        public virtual void Add(TBTradeType tbTradeType)
        {
            try
            {
                db.Open();
                Add(db,tbTradeType);
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
        /// 修改交易类型
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbTradeType">交易类型</param>
        public virtual void Edit(DataAccess data,TBTradeType tbTradeType)
        {
            string strSQL = "update TBTradeType set name=@name where code=@code";
            Param param = new Param();
            param.Clear();
            param.Add("@name", tbTradeType.name);//名称
            param.Add("@code", tbTradeType.code);//代码
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改交易类型
        /// </summary>
        /// <param name="tbTradeType">交易类型</param>
        public virtual void Edit(TBTradeType tbTradeType)
        {
            try
            {
                db.Open();
                Edit(db,tbTradeType);
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
        /// 删除交易类型
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="code">代码</param>
        public virtual void Delete(DataAccess data,string code)
        {
            string strSQL = "delete from TBTradeType where code=@code";
            Param param = new Param();
            param.Clear();
            param.Add("@code", code);//代码
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除交易类型
        /// </summary>
        /// <param name="code">代码</param>
        public virtual void Delete(string code)
        {
            try
            {
                db.Open();
                Delete(db,code);
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
        /// 获取交易类型
        /// </summary>
        /// <param name="code">代码</param>
        /// <returns>交易类型对象</returns>
        public virtual TBTradeType Get(string code)
        {
            TBTradeType tbTradeType=null;
            try
            {
                string strSQL = "select * from TBTradeType where code=@code";
                Param param = new Param();
                param.Clear();
                param.Add("@code", code);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbTradeType=ReadData(dr);
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
            return tbTradeType;
        }
        
        /// <summary>
        /// 获取列表(交易类型)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>交易类型列表对象</returns>
        public virtual List<TBTradeType> GetList(string strSQL,Param param)
        {
            List<TBTradeType> list = new List<TBTradeType>();
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
        /// 获取列表(交易类型)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>交易类型列表对象</returns>
        public virtual List<TBTradeType> GetList(string field, string value)
        {
            List<TBTradeType> list = new List<TBTradeType>();
            try
            {
                string strSQL = "select * from TBTradeType where " + field + "=@field";
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
        /// 获取DataSet(交易类型)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>交易类型DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBTradeType");
        }
        
        /// <summary>
        /// 是否存在记录(交易类型)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBTradeType where " + field + "=@field";
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
        /// 读取交易类型信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>交易类型对象</returns>
        protected virtual TBTradeType ReadData(ComDataReader dr)
        {
            TBTradeType tbTradeType= new TBTradeType();
            tbTradeType.code= dr["code"].ToString();//代码
            tbTradeType.name= dr["name"].ToString();//名称
            return tbTradeType;
        }
        
        
        #endregion
        
    }
}

