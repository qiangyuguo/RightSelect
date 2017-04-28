using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 退款明细
    /// Author:代码生成器
    /// </summary>
    public class TTClientRecharge2DBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加退款明细
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientRecharge2">退款明细</param>
        /// </summary>
        public virtual void Add(DataAccess data,TTClientRecharge2 ttClientRecharge2)
        {
            string strSQL = "insert into TTClientRecharge2 (Column_1) values (@Column_1)";
            Param param = new Param();
            param.Clear();
            param.Add("@Column_1", ttClientRecharge2.Column_1);//Column_1
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加退款明细
        /// <param name="ttClientRecharge2">退款明细</param>
        /// </summary>
        public virtual void Add(TTClientRecharge2 ttClientRecharge2)
        {
            try
            {
                db.Open();
                Add(db,ttClientRecharge2);
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
        /// 修改退款明细
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientRecharge2">退款明细</param>
        /// </summary>
        public virtual void Edit(DataAccess data,TTClientRecharge2 ttClientRecharge2)
        {
            string strSQL = "update TTClientRecharge2 set  where Column_1=@Column_1";
            Param param = new Param();
            param.Clear();
            param.Add("@Column_1", ttClientRecharge2.Column_1);//Column_1
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改退款明细
        /// <param name="ttClientRecharge2">退款明细</param>
        /// </summary>
        public virtual void Edit(TTClientRecharge2 ttClientRecharge2)
        {
            try
            {
                db.Open();
                Edit(db,ttClientRecharge2);
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
        /// 删除退款明细
        /// <param name="data">数据库连接</param>
        /// <param name="Column_1">Column_1</param>
        /// </summary>
        public virtual void Delete(DataAccess data,string Column_1)
        {
            string strSQL = "delete from TTClientRecharge2 where Column_1=@Column_1";
            Param param = new Param();
            param.Clear();
            param.Add("@Column_1", Column_1);//Column_1
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除退款明细
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
        /// 获取退款明细
        /// <param name="Column_1">Column_1</param>
        /// </summary>
        /// <returns>退款明细对象</returns>
        public virtual TTClientRecharge2 Get(string Column_1)
        {
            TTClientRecharge2 ttClientRecharge2=null;
            try
            {
                string strSQL = "select * from TTClientRecharge2 where Column_1=@Column_1";
                Param param = new Param();
                param.Clear();
                param.Add("@Column_1", Column_1);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttClientRecharge2=ReadData(dr);
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
            return ttClientRecharge2;
        }
        
        /// <summary>
        /// 获取列表(退款明细)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>退款明细列表对象</returns>
        public virtual List<TTClientRecharge2> GetList(string strSQL,Param param)
        {
            List<TTClientRecharge2> list = new List<TTClientRecharge2>();
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
        /// 获取列表(退款明细)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>退款明细列表对象</returns>
        public virtual List<TTClientRecharge2> GetList(string field, string value)
        {
            List<TTClientRecharge2> list = new List<TTClientRecharge2>();
            try
            {
                string strSQL = "select * from TTClientRecharge2 where " + field + "=@field";
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
        /// 获取DataSet(退款明细)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>退款明细DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTClientRecharge2");
        }
        
        /// <summary>
        /// 是否存在记录(退款明细)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTClientRecharge2 where " + field + "=@field";
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
        /// 读取退款明细信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>退款明细对象</returns>
        protected virtual TTClientRecharge2 ReadData(ComDataReader dr)
        {
            TTClientRecharge2 ttClientRecharge2= new TTClientRecharge2();
            ttClientRecharge2.Column_1= dr["Column_1"].ToString();//Column_1
            return ttClientRecharge2;
        }
        
        
        #endregion
        
    }
}

