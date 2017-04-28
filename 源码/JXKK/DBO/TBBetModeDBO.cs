using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 投注方式
    /// Author:代码生成器
    /// </summary>
    public class TBBetModeDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加投注方式
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbBetMode">投注方式</param>
        public virtual void Add(DataAccess data,TBBetMode tbBetMode)
        {
            string strSQL = "insert into TBBetMode (code,name) values (@code,@name)";
            Param param = new Param();
            param.Clear();
            param.Add("@code", tbBetMode.code);//代码
            param.Add("@name", tbBetMode.name);//名称
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加投注方式
        /// </summary>
        /// <param name="tbBetMode">投注方式</param>
        public virtual void Add(TBBetMode tbBetMode)
        {
            try
            {
                db.Open();
                Add(db,tbBetMode);
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
        /// 修改投注方式
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbBetMode">投注方式</param>
        public virtual void Edit(DataAccess data,TBBetMode tbBetMode)
        {
            string strSQL = "update TBBetMode set name=@name where code=@code";
            Param param = new Param();
            param.Clear();
            param.Add("@name", tbBetMode.name);//名称
            param.Add("@code", tbBetMode.code);//代码
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改投注方式
        /// </summary>
        /// <param name="tbBetMode">投注方式</param>
        public virtual void Edit(TBBetMode tbBetMode)
        {
            try
            {
                db.Open();
                Edit(db,tbBetMode);
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
        /// 删除投注方式
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="code">代码</param>
        public virtual void Delete(DataAccess data,string code)
        {
            string strSQL = "delete from TBBetMode where code=@code";
            Param param = new Param();
            param.Clear();
            param.Add("@code", code);//代码
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除投注方式
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
        /// 获取投注方式
        /// </summary>
        /// <param name="code">代码</param>
        /// <returns>投注方式对象</returns>
        public virtual TBBetMode Get(string code)
        {
            TBBetMode tbBetMode=null;
            try
            {
                string strSQL = "select * from TBBetMode where code=@code";
                Param param = new Param();
                param.Clear();
                param.Add("@code", code);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbBetMode=ReadData(dr);
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
            return tbBetMode;
        }
        
        /// <summary>
        /// 获取列表(投注方式)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>投注方式列表对象</returns>
        public virtual List<TBBetMode> GetList(string strSQL,Param param)
        {
            List<TBBetMode> list = new List<TBBetMode>();
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
        /// 获取列表(投注方式)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>投注方式列表对象</returns>
        public virtual List<TBBetMode> GetList(string field, string value)
        {
            List<TBBetMode> list = new List<TBBetMode>();
            try
            {
                string strSQL = "select * from TBBetMode where " + field + "=@field";
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
        /// 获取DataSet(投注方式)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>投注方式DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBBetMode");
        }
        
        /// <summary>
        /// 是否存在记录(投注方式)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBBetMode where " + field + "=@field";
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
        /// 读取投注方式信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>投注方式对象</returns>
        protected virtual TBBetMode ReadData(ComDataReader dr)
        {
            TBBetMode tbBetMode= new TBBetMode();
            tbBetMode.code= dr["code"].ToString();//代码
            tbBetMode.name= dr["name"].ToString();//名称
            return tbBetMode;
        }
        
        
        #endregion
        
    }
}

