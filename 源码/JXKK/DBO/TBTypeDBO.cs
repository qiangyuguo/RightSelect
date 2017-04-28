using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 类型设置
    /// Author:代码生成器
    /// </summary>
    public class TBTypeDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加类型设置
        /// <param name="data">数据库连接</param>
        /// <param name="tbType">类型设置</param>
        /// </summary>
        public virtual void Add(DataAccess data,TBType tbType)
        {
            string strSQL = "insert into TBType (tableName,typeCode,typeName,isUse) values (@tableName,@typeCode,@typeName,@isUse)";
            Param param = new Param();
            param.Clear();
            param.Add("@tableName", tbType.tableName);//使用表名
            param.Add("@typeCode", tbType.typeCode);//类型编号
            param.Add("@typeName", tbType.typeName);//类型名称
            param.Add("@isUse", tbType.isUse);//使用状态
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加类型设置
        /// <param name="tbType">类型设置</param>
        /// </summary>
        public virtual void Add(TBType tbType)
        {
            try
            {
                db.Open();
                Add(db,tbType);
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
        /// 修改类型设置
        /// <param name="data">数据库连接</param>
        /// <param name="tbType">类型设置</param>
        /// </summary>
        public virtual void Edit(DataAccess data,TBType tbType)
        {
            string strSQL = "update TBType set typeName=@typeName,isUse=@isUse where typeCode=@typeCode and tableName=@tableName";
            Param param = new Param();
            param.Clear();
            param.Add("@typeName", tbType.typeName);//类型名称
            param.Add("@isUse", tbType.isUse);//使用状态
            param.Add("@typeCode", tbType.typeCode);//类型编号
            param.Add("@tableName", tbType.tableName);//使用表名
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改类型设置
        /// <param name="tbType">类型设置</param>
        /// </summary>
        public virtual void Edit(TBType tbType)
        {
            try
            {
                db.Open();
                Edit(db,tbType);
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
        /// 删除类型设置
        /// <param name="data">数据库连接</param>
        /// <param name="typeCode">类型编号</param>
        /// <param name="tableName">使用表名</param>
        /// </summary>
        public virtual void Delete(DataAccess data,string typeCode,string tableName)
        {
            string strSQL = "delete from TBType where typeCode=@typeCode and tableName=@tableName";
            Param param = new Param();
            param.Clear();
            param.Add("@typeCode", typeCode);//类型编号
            param.Add("@tableName", tableName);//使用表名
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除类型设置
        /// <param name="typeCode">类型编号</param>
        /// <param name="tableName">使用表名</param>
        /// </summary>
        public virtual void Delete(string typeCode,string tableName)
        {
            try
            {
                db.Open();
                Delete(db,typeCode,tableName);
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
        /// 获取类型设置
        /// <param name="typeCode">类型编号</param>
        /// <param name="tableName">使用表名</param>
        /// </summary>
        /// <returns>类型设置对象</returns>
        public virtual TBType Get(string typeCode,string tableName)
        {
            TBType tbType=null;
            try
            {
                string strSQL = "select * from TBType where typeCode=@typeCode and tableName=@tableName";
                Param param = new Param();
                param.Clear();
                param.Add("@typeCode", typeCode);
                param.Add("@tableName", tableName);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbType=ReadData(dr);
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
            return tbType;
        }
        
        /// <summary>
        /// 获取列表(类型设置)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>类型设置列表对象</returns>
        public virtual List<TBType> GetList(string strSQL,Param param)
        {
            List<TBType> list = new List<TBType>();
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
        /// 获取列表(类型设置)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>类型设置列表对象</returns>
        public virtual List<TBType> GetList(string field, string value)
        {
            List<TBType> list = new List<TBType>();
            try
            {
                string strSQL = "select * from TBType where " + field + "=@field";
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
        /// 获取DataSet(类型设置)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>类型设置DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBType");
        }
        
        /// <summary>
        /// 是否存在记录(类型设置)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBType where " + field + "=@field";
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
        /// 读取类型设置信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>类型设置对象</returns>
        protected virtual TBType ReadData(ComDataReader dr)
        {
            TBType tbType= new TBType();
            tbType.tableName= dr["tableName"].ToString();//使用表名
            tbType.typeCode= dr["typeCode"].ToString();//类型编号
            tbType.typeName= dr["typeName"].ToString();//类型名称
            tbType.isUse= dr["isUse"].ToString();//使用状态
            return tbType;
        }
        
        
        #endregion
        
    }
}

