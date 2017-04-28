using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 最大值表
    /// Author:代码生成器
    /// </summary>
    public class TSMaxDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加最大值表
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsMax">最大值表</param>
        public virtual void Add(DataAccess data,TSMax tsMax)
        {
            string strSQL = "insert into TSMax (tabName,codex,userValue,remark) values (@tabName,@codex,@userValue,@remark)";
            Param param = new Param();
            param.Clear();
            param.Add("@tabName", tsMax.tabName);//表名
            param.Add("@codex", tsMax.codex);//规则
            param.Add("@userValue", tsMax.userValue);//流水值
            param.Add("@remark", tsMax.remark);//备注
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加最大值表
        /// </summary>
        /// <param name="tsMax">最大值表</param>
        public virtual void Add(TSMax tsMax)
        {
            try
            {
                db.Open();
                Add(db,tsMax);
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
        /// 修改最大值表
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsMax">最大值表</param>
        public virtual void Edit(DataAccess data,TSMax tsMax)
        {
            string strSQL = "update TSMax set codex=@codex,userValue=@userValue,remark=@remark where tabName=@tabName";
            Param param = new Param();
            param.Clear();
            param.Add("@codex", tsMax.codex);//规则
            param.Add("@userValue", tsMax.userValue);//流水值
            param.Add("@remark", tsMax.remark);//备注
            param.Add("@tabName", tsMax.tabName);//表名
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改最大值表
        /// </summary>
        /// <param name="tsMax">最大值表</param>
        public virtual void Edit(TSMax tsMax)
        {
            try
            {
                db.Open();
                Edit(db,tsMax);
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
        /// 删除最大值表
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tabName">表名</param>
        public virtual void Delete(DataAccess data,string tabName)
        {
            string strSQL = "delete from TSMax where tabName=@tabName";
            Param param = new Param();
            param.Clear();
            param.Add("@tabName", tabName);//表名
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除最大值表
        /// </summary>
        /// <param name="tabName">表名</param>
        public virtual void Delete(string tabName)
        {
            try
            {
                db.Open();
                Delete(db,tabName);
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
        /// 获取最大值表
        /// </summary>
        /// <param name="tabName">表名</param>
        /// <returns>最大值表对象</returns>
        public virtual TSMax Get(string tabName)
        {
            TSMax tsMax=null;
            try
            {
                string strSQL = "select * from TSMax where tabName=@tabName";
                Param param = new Param();
                param.Clear();
                param.Add("@tabName", tabName);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsMax=ReadData(dr);
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
            return tsMax;
        }
        
        /// <summary>
        /// 获取列表(最大值表)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>最大值表列表对象</returns>
        public virtual List<TSMax> GetList(string strSQL,Param param)
        {
            List<TSMax> list = new List<TSMax>();
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
        /// 获取列表(最大值表)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>最大值表列表对象</returns>
        public virtual List<TSMax> GetList(string field, string value)
        {
            List<TSMax> list = new List<TSMax>();
            try
            {
                string strSQL = "select * from TSMax where " + field + "=@field";
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
        /// 获取DataSet(最大值表)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>最大值表DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSMax");
        }
        
        /// <summary>
        /// 是否存在记录(最大值表)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSMax where " + field + "=@field";
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
        /// 读取最大值表信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>最大值表对象</returns>
        protected virtual TSMax ReadData(ComDataReader dr)
        {
            TSMax tsMax= new TSMax();
            tsMax.tabName= dr["tabName"].ToString();//表名
            tsMax.codex= dr["codex"].ToString();//规则
            tsMax.userValue= long.Parse(dr["userValue"].ToString());//流水值
            tsMax.remark= dr["remark"].ToString();//备注
            return tsMax;
        }
        
        
        #endregion
        
    }
}

