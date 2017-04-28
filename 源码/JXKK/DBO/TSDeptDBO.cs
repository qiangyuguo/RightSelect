using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 部门
    /// Author:代码生成器
    /// </summary>
    public class TSDeptDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加部门
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsDept">部门</param>
        public virtual void Add(DataAccess data,TSDept tsDept)
        {
            string strSQL = "insert into TSDept (deptId,status,deptName,telephone) values (@deptId,@status,@deptName,@telephone)";
            Param param = new Param();
            param.Clear();
            param.Add("@deptId", tsDept.deptId);//部门编号
            param.Add("@status", tsDept.status);//使用状态
            param.Add("@deptName", tsDept.deptName);//部门名称
            param.Add("@telephone", tsDept.telephone);//联系电话
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加部门
        /// </summary>
        /// <param name="tsDept">部门</param>
        public virtual void Add(TSDept tsDept)
        {
            try
            {
                db.Open();
                Add(db,tsDept);
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
        /// 修改部门
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsDept">部门</param>
        public virtual void Edit(DataAccess data,TSDept tsDept)
        {
            string strSQL = "update TSDept set status=@status,deptName=@deptName,telephone=@telephone where deptId=@deptId";
            Param param = new Param();
            param.Clear();
            param.Add("@status", tsDept.status);//使用状态
            param.Add("@deptName", tsDept.deptName);//部门名称
            param.Add("@telephone", tsDept.telephone);//联系电话
            param.Add("@deptId", tsDept.deptId);//部门编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="tsDept">部门</param>
        public virtual void Edit(TSDept tsDept)
        {
            try
            {
                db.Open();
                Edit(db,tsDept);
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
        /// 删除部门
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="deptId">部门编号</param>
        public virtual void Delete(DataAccess data,string deptId)
        {
            string strSQL = "delete from TSDept where deptId=@deptId";
            Param param = new Param();
            param.Clear();
            param.Add("@deptId", deptId);//部门编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="deptId">部门编号</param>
        public virtual void Delete(string deptId)
        {
            try
            {
                db.Open();
                Delete(db,deptId);
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
        /// 获取部门
        /// </summary>
        /// <param name="deptId">部门编号</param>
        /// <returns>部门对象</returns>
        public virtual TSDept Get(string deptId)
        {
            TSDept tsDept=null;
            try
            {
                string strSQL = "select * from TSDept where deptId=@deptId";
                Param param = new Param();
                param.Clear();
                param.Add("@deptId", deptId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsDept=ReadData(dr);
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
            return tsDept;
        }
        
        /// <summary>
        /// 获取列表(部门)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>部门列表对象</returns>
        public virtual List<TSDept> GetList(string strSQL,Param param)
        {
            List<TSDept> list = new List<TSDept>();
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
        /// 获取列表(部门)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>部门列表对象</returns>
        public virtual List<TSDept> GetList(string field, string value)
        {
            List<TSDept> list = new List<TSDept>();
            try
            {
                string strSQL = "select * from TSDept where " + field + "=@field";
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
        /// 获取DataSet(部门)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>部门DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSDept");
        }
        
        /// <summary>
        /// 是否存在记录(部门)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSDept where " + field + "=@field";
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
        /// 读取部门信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>部门对象</returns>
        protected virtual TSDept ReadData(ComDataReader dr)
        {
            TSDept tsDept= new TSDept();
            tsDept.deptId= dr["deptId"].ToString();//部门编号
            tsDept.status= dr["status"].ToString();//使用状态
            tsDept.deptName= dr["deptName"].ToString();//部门名称
            tsDept.telephone= dr["telephone"].ToString();//联系电话
            return tsDept;
        }
        
        
        #endregion
        
    }
}

