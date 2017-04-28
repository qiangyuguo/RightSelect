using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 付款方式表
    /// Author:代码生成器
    /// </summary>
    public class TBPayModeDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加付款方式表
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbPayMode">付款方式表</param>
        public virtual void Add(DataAccess data,TBPayMode tbPayMode)
        {
            string strSQL = "insert into TBPayMode (modeId,modeName,isUse) values (@modeId,@modeName,@isUse)";
            Param param = new Param();
            param.Clear();
            param.Add("@modeId", tbPayMode.modeId);//付款方式编号
            param.Add("@modeName", tbPayMode.modeName);//付款方式名称
            param.Add("@isUse", tbPayMode.isUse);//使用状态
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加付款方式表
        /// </summary>
        /// <param name="tbPayMode">付款方式表</param>
        public virtual void Add(TBPayMode tbPayMode)
        {
            try
            {
                db.Open();
                Add(db,tbPayMode);
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
        /// 修改付款方式表
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbPayMode">付款方式表</param>
        public virtual void Edit(DataAccess data,TBPayMode tbPayMode)
        {
            string strSQL = "update TBPayMode set modeName=@modeName,isUse=@isUse where modeId=@modeId";
            Param param = new Param();
            param.Clear();
            param.Add("@modeName", tbPayMode.modeName);//付款方式名称
            param.Add("@isUse", tbPayMode.isUse);//使用状态
            param.Add("@modeId", tbPayMode.modeId);//付款方式编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改付款方式表
        /// </summary>
        /// <param name="tbPayMode">付款方式表</param>
        public virtual void Edit(TBPayMode tbPayMode)
        {
            try
            {
                db.Open();
                Edit(db,tbPayMode);
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
        /// 删除付款方式表
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="modeId">付款方式编号</param>
        public virtual void Delete(DataAccess data,string modeId)
        {
            string strSQL = "delete from TBPayMode where modeId=@modeId";
            Param param = new Param();
            param.Clear();
            param.Add("@modeId", modeId);//付款方式编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除付款方式表
        /// </summary>
        /// <param name="modeId">付款方式编号</param>
        public virtual void Delete(string modeId)
        {
            try
            {
                db.Open();
                Delete(db,modeId);
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
        /// 获取付款方式表
        /// </summary>
        /// <param name="modeId">付款方式编号</param>
        /// <returns>付款方式表对象</returns>
        public virtual TBPayMode Get(string modeId)
        {
            TBPayMode tbPayMode=null;
            try
            {
                string strSQL = "select * from TBPayMode where modeId=@modeId";
                Param param = new Param();
                param.Clear();
                param.Add("@modeId", modeId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbPayMode=ReadData(dr);
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
            return tbPayMode;
        }
        
        /// <summary>
        /// 获取列表(付款方式表)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>付款方式表列表对象</returns>
        public virtual List<TBPayMode> GetList(string strSQL,Param param)
        {
            List<TBPayMode> list = new List<TBPayMode>();
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
        /// 获取列表(付款方式表)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>付款方式表列表对象</returns>
        public virtual List<TBPayMode> GetList(string field, string value)
        {
            List<TBPayMode> list = new List<TBPayMode>();
            try
            {
                string strSQL = "select * from TBPayMode where " + field + "=@field";
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
        /// 获取DataSet(付款方式表)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>付款方式表DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBPayMode");
        }
        
        /// <summary>
        /// 是否存在记录(付款方式表)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBPayMode where " + field + "=@field";
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
        /// 读取付款方式表信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>付款方式表对象</returns>
        protected virtual TBPayMode ReadData(ComDataReader dr)
        {
            TBPayMode tbPayMode= new TBPayMode();
            tbPayMode.modeId= dr["modeId"].ToString();//付款方式编号
            tbPayMode.modeName= dr["modeName"].ToString();//付款方式名称
            tbPayMode.isUse= dr["isUse"].ToString();//使用状态
            return tbPayMode;
        }
        
        
        #endregion
        
    }
}

