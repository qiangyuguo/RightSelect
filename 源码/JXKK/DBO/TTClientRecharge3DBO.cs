using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 代理佣金结算
    /// Author:代码生成器
    /// </summary>
    public class TTClientRecharge3DBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加代理佣金结算
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientRecharge3">代理佣金结算</param>
        /// </summary>
        public virtual void Add(DataAccess data,TTClientRecharge3 ttClientRecharge3)
        {
            string strSQL = "insert into TTClientRecharge3 (Column_1) values (@Column_1)";
            Param param = new Param();
            param.Clear();
            param.Add("@Column_1", ttClientRecharge3.Column_1);//Column_1
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加代理佣金结算
        /// <param name="ttClientRecharge3">代理佣金结算</param>
        /// </summary>
        public virtual void Add(TTClientRecharge3 ttClientRecharge3)
        {
            try
            {
                db.Open();
                Add(db,ttClientRecharge3);
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
        /// 修改代理佣金结算
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientRecharge3">代理佣金结算</param>
        /// </summary>
        public virtual void Edit(DataAccess data,TTClientRecharge3 ttClientRecharge3)
        {
            string strSQL = "update TTClientRecharge3 set  where Column_1=@Column_1";
            Param param = new Param();
            param.Clear();
            param.Add("@Column_1", ttClientRecharge3.Column_1);//Column_1
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改代理佣金结算
        /// <param name="ttClientRecharge3">代理佣金结算</param>
        /// </summary>
        public virtual void Edit(TTClientRecharge3 ttClientRecharge3)
        {
            try
            {
                db.Open();
                Edit(db,ttClientRecharge3);
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
        /// 删除代理佣金结算
        /// <param name="data">数据库连接</param>
        /// <param name="Column_1">Column_1</param>
        /// </summary>
        public virtual void Delete(DataAccess data,string Column_1)
        {
            string strSQL = "delete from TTClientRecharge3 where Column_1=@Column_1";
            Param param = new Param();
            param.Clear();
            param.Add("@Column_1", Column_1);//Column_1
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除代理佣金结算
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
        /// 获取代理佣金结算
        /// <param name="Column_1">Column_1</param>
        /// </summary>
        /// <returns>代理佣金结算对象</returns>
        public virtual TTClientRecharge3 Get(string Column_1)
        {
            TTClientRecharge3 ttClientRecharge3=null;
            try
            {
                string strSQL = "select * from TTClientRecharge3 where Column_1=@Column_1";
                Param param = new Param();
                param.Clear();
                param.Add("@Column_1", Column_1);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttClientRecharge3=ReadData(dr);
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
            return ttClientRecharge3;
        }
        
        /// <summary>
        /// 获取列表(代理佣金结算)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理佣金结算列表对象</returns>
        public virtual List<TTClientRecharge3> GetList(string strSQL,Param param)
        {
            List<TTClientRecharge3> list = new List<TTClientRecharge3>();
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
        /// 获取列表(代理佣金结算)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>代理佣金结算列表对象</returns>
        public virtual List<TTClientRecharge3> GetList(string field, string value)
        {
            List<TTClientRecharge3> list = new List<TTClientRecharge3>();
            try
            {
                string strSQL = "select * from TTClientRecharge3 where " + field + "=@field";
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
        /// 获取DataSet(代理佣金结算)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理佣金结算DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTClientRecharge3");
        }
        
        /// <summary>
        /// 是否存在记录(代理佣金结算)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTClientRecharge3 where " + field + "=@field";
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
        /// 读取代理佣金结算信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>代理佣金结算对象</returns>
        protected virtual TTClientRecharge3 ReadData(ComDataReader dr)
        {
            TTClientRecharge3 ttClientRecharge3= new TTClientRecharge3();
            ttClientRecharge3.Column_1= dr["Column_1"].ToString();//Column_1
            return ttClientRecharge3;
        }
        
        
        #endregion
        
    }
}

