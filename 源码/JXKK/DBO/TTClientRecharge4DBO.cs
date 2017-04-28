using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 推荐人佣金结算
    /// Author:代码生成器
    /// </summary>
    public class TTClientRecharge4DBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加推荐人佣金结算
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientRecharge4">推荐人佣金结算</param>
        /// </summary>
        public virtual void Add(DataAccess data,TTClientRecharge4 ttClientRecharge4)
        {
            string strSQL = "insert into TTClientRecharge4 (Column_1) values (@Column_1)";
            Param param = new Param();
            param.Clear();
            param.Add("@Column_1", ttClientRecharge4.Column_1);//Column_1
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加推荐人佣金结算
        /// <param name="ttClientRecharge4">推荐人佣金结算</param>
        /// </summary>
        public virtual void Add(TTClientRecharge4 ttClientRecharge4)
        {
            try
            {
                db.Open();
                Add(db,ttClientRecharge4);
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
        /// 修改推荐人佣金结算
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientRecharge4">推荐人佣金结算</param>
        /// </summary>
        public virtual void Edit(DataAccess data,TTClientRecharge4 ttClientRecharge4)
        {
            string strSQL = "update TTClientRecharge4 set  where Column_1=@Column_1";
            Param param = new Param();
            param.Clear();
            param.Add("@Column_1", ttClientRecharge4.Column_1);//Column_1
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改推荐人佣金结算
        /// <param name="ttClientRecharge4">推荐人佣金结算</param>
        /// </summary>
        public virtual void Edit(TTClientRecharge4 ttClientRecharge4)
        {
            try
            {
                db.Open();
                Edit(db,ttClientRecharge4);
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
        /// 删除推荐人佣金结算
        /// <param name="data">数据库连接</param>
        /// <param name="Column_1">Column_1</param>
        /// </summary>
        public virtual void Delete(DataAccess data,string Column_1)
        {
            string strSQL = "delete from TTClientRecharge4 where Column_1=@Column_1";
            Param param = new Param();
            param.Clear();
            param.Add("@Column_1", Column_1);//Column_1
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除推荐人佣金结算
        /// <param name="Column_1">Column_1</param>
        /// </summary>
        public virtual void Delete(string Column_1)
        {
            try
            {
                db.Open();
                Delete(db,Column_1);
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
        /// 获取推荐人佣金结算
        /// <param name="Column_1">Column_1</param>
        /// </summary>
        /// <returns>推荐人佣金结算对象</returns>
        public virtual TTClientRecharge4 Get(string Column_1)
        {
            TTClientRecharge4 ttClientRecharge4=null;
            try
            {
                string strSQL = "select * from TTClientRecharge4 where Column_1=@Column_1";
                Param param = new Param();
                param.Clear();
                param.Add("@Column_1", Column_1);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttClientRecharge4=ReadData(dr);
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
            return ttClientRecharge4;
        }
        
        /// <summary>
        /// 获取列表(推荐人佣金结算)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>推荐人佣金结算列表对象</returns>
        public virtual List<TTClientRecharge4> GetList(string strSQL,Param param)
        {
            List<TTClientRecharge4> list = new List<TTClientRecharge4>();
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
        /// 获取列表(推荐人佣金结算)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>推荐人佣金结算列表对象</returns>
        public virtual List<TTClientRecharge4> GetList(string field, string value)
        {
            List<TTClientRecharge4> list = new List<TTClientRecharge4>();
            try
            {
                string strSQL = "select * from TTClientRecharge4 where " + field + "=@field";
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
        /// 获取DataSet(推荐人佣金结算)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>推荐人佣金结算DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTClientRecharge4");
        }
        
        /// <summary>
        /// 是否存在记录(推荐人佣金结算)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTClientRecharge4 where " + field + "=@field";
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
        /// 读取推荐人佣金结算信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>推荐人佣金结算对象</returns>
        protected virtual TTClientRecharge4 ReadData(ComDataReader dr)
        {
            TTClientRecharge4 ttClientRecharge4= new TTClientRecharge4();
            ttClientRecharge4.Column_1= dr["Column_1"].ToString();//Column_1
            return ttClientRecharge4;
        }
        
        
        #endregion
        
    }
}

