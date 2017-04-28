using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 彩票玩法
    /// Author:代码生成器
    /// </summary>
    public class TBPlayModeDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加彩票玩法
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbPlayMode">彩票玩法</param>
        public virtual void Add(DataAccess data,TBPlayMode tbPlayMode)
        {
            string strSQL = "insert into TBPlayMode (code,name) values (@code,@name)";
            Param param = new Param();
            param.Clear();
            param.Add("@code", tbPlayMode.code);//玩法代码
            param.Add("@name", tbPlayMode.name);//玩法名称
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加彩票玩法
        /// </summary>
        /// <param name="tbPlayMode">彩票玩法</param>
        public virtual void Add(TBPlayMode tbPlayMode)
        {
            try
            {
                db.Open();
                Add(db,tbPlayMode);
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
        /// 修改彩票玩法
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbPlayMode">彩票玩法</param>
        public virtual void Edit(DataAccess data,TBPlayMode tbPlayMode)
        {
            string strSQL = "update TBPlayMode set name=@name where code=@code";
            Param param = new Param();
            param.Clear();
            param.Add("@name", tbPlayMode.name);//玩法名称
            param.Add("@code", tbPlayMode.code);//玩法代码
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改彩票玩法
        /// </summary>
        /// <param name="tbPlayMode">彩票玩法</param>
        public virtual void Edit(TBPlayMode tbPlayMode)
        {
            try
            {
                db.Open();
                Edit(db,tbPlayMode);
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
        /// 删除彩票玩法
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="code">玩法代码</param>
        public virtual void Delete(DataAccess data,string code)
        {
            string strSQL = "delete from TBPlayMode where code=@code";
            Param param = new Param();
            param.Clear();
            param.Add("@code", code);//玩法代码
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除彩票玩法
        /// </summary>
        /// <param name="code">玩法代码</param>
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
        /// 获取彩票玩法
        /// </summary>
        /// <param name="code">玩法代码</param>
        /// <returns>彩票玩法对象</returns>
        public virtual TBPlayMode Get(string code)
        {
            TBPlayMode tbPlayMode=null;
            try
            {
                string strSQL = "select * from TBPlayMode where code=@code";
                Param param = new Param();
                param.Clear();
                param.Add("@code", code);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbPlayMode=ReadData(dr);
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
            return tbPlayMode;
        }
        
        /// <summary>
        /// 获取列表(彩票玩法)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>彩票玩法列表对象</returns>
        public virtual List<TBPlayMode> GetList(string strSQL,Param param)
        {
            List<TBPlayMode> list = new List<TBPlayMode>();
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
        /// 获取列表(彩票玩法)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>彩票玩法列表对象</returns>
        public virtual List<TBPlayMode> GetList(string field, string value)
        {
            List<TBPlayMode> list = new List<TBPlayMode>();
            try
            {
                string strSQL = "select * from TBPlayMode where " + field + "=@field";
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
        /// 获取DataSet(彩票玩法)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>彩票玩法DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBPlayMode");
        }
        
        /// <summary>
        /// 是否存在记录(彩票玩法)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBPlayMode where " + field + "=@field";
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
        /// 读取彩票玩法信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>彩票玩法对象</returns>
        protected virtual TBPlayMode ReadData(ComDataReader dr)
        {
            TBPlayMode tbPlayMode= new TBPlayMode();
            tbPlayMode.code= dr["code"].ToString();//玩法代码
            tbPlayMode.name= dr["name"].ToString();//玩法名称
            return tbPlayMode;
        }
        
        
        #endregion
        
    }
}

