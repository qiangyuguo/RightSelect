using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 角色权限模块
    /// Author:代码生成器
    /// </summary>
    public class TSRightDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加角色权限模块
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsRight">角色权限模块</param>
        public virtual void Add(DataAccess data,TSRight tsRight)
        {
            string strSQL = "insert into TSRight (roleId,moduleId) values (@roleId,@moduleId)";
            Param param = new Param();
            param.Clear();
            param.Add("@roleId", tsRight.roleId);//角色编号
            param.Add("@moduleId", tsRight.moduleId);//模块编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加角色权限模块
        /// </summary>
        /// <param name="tsRight">角色权限模块</param>
        public virtual void Add(TSRight tsRight)
        {
            try
            {
                db.Open();
                Add(db,tsRight);
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
        /// 修改角色权限模块
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsRight">角色权限模块</param>
        public virtual void Edit(DataAccess data,TSRight tsRight)
        {
            string strSQL = "update TSRight set  where roleId=@roleId and moduleId=@moduleId";
            Param param = new Param();
            param.Clear();
            param.Add("@roleId", tsRight.roleId);//角色编号
            param.Add("@moduleId", tsRight.moduleId);//模块编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改角色权限模块
        /// </summary>
        /// <param name="tsRight">角色权限模块</param>
        public virtual void Edit(TSRight tsRight)
        {
            try
            {
                db.Open();
                Edit(db,tsRight);
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
        /// 删除角色权限模块
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="roleId">角色编号</param>
        /// <param name="moduleId">模块编号</param>
        public virtual void Delete(DataAccess data,string roleId,string moduleId)
        {
            string strSQL = "delete from TSRight where roleId=@roleId and moduleId=@moduleId";
            Param param = new Param();
            param.Clear();
            param.Add("@roleId", roleId);//角色编号
            param.Add("@moduleId", moduleId);//模块编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除角色权限模块
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="moduleId">模块编号</param>
        public virtual void Delete(string roleId,string moduleId)
        {
            try
            {
                db.Open();
                Delete(db,roleId,moduleId);
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
        /// 获取角色权限模块
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="moduleId">模块编号</param>
        /// <returns>角色权限模块对象</returns>
        public virtual TSRight Get(string roleId,string moduleId)
        {
            TSRight tsRight=null;
            try
            {
                string strSQL = "select * from TSRight where roleId=@roleId and moduleId=@moduleId";
                Param param = new Param();
                param.Clear();
                param.Add("@roleId", roleId);
                param.Add("@moduleId", moduleId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsRight=ReadData(dr);
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
            return tsRight;
        }
        
        /// <summary>
        /// 获取列表(角色权限模块)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>角色权限模块列表对象</returns>
        public virtual List<TSRight> GetList(string strSQL,Param param)
        {
            List<TSRight> list = new List<TSRight>();
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
        /// 获取列表(角色权限模块)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>角色权限模块列表对象</returns>
        public virtual List<TSRight> GetList(string field, string value)
        {
            List<TSRight> list = new List<TSRight>();
            try
            {
                string strSQL = "select * from TSRight where " + field + "=@field";
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
        /// 获取DataSet(角色权限模块)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>角色权限模块DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSRight");
        }
        
        /// <summary>
        /// 是否存在记录(角色权限模块)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSRight where " + field + "=@field";
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
        /// 读取角色权限模块信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>角色权限模块对象</returns>
        protected virtual TSRight ReadData(ComDataReader dr)
        {
            TSRight tsRight= new TSRight();
            tsRight.roleId= dr["roleId"].ToString();//角色编号
            tsRight.moduleId= dr["moduleId"].ToString();//模块编号
            return tsRight;
        }
        
        
        #endregion
        
    }
}

