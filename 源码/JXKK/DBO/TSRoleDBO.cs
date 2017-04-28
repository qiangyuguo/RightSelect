using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 系统角色
    /// Author:代码生成器
    /// </summary>
    public class TSRoleDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加系统角色
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsRole">系统角色</param>
        public virtual void Add(DataAccess data,TSRole tsRole)
        {
            string strSQL = "insert into TSRole (roleId,roleName,status) values (@roleId,@roleName,@status)";
            Param param = new Param();
            param.Clear();
            param.Add("@roleId", tsRole.roleId);//角色编号
            param.Add("@roleName", tsRole.roleName);//角色名称
            param.Add("@status", tsRole.status);//使用状态
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加系统角色
        /// </summary>
        /// <param name="tsRole">系统角色</param>
        public virtual void Add(TSRole tsRole)
        {
            try
            {
                db.Open();
                Add(db,tsRole);
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
        /// 修改系统角色
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsRole">系统角色</param>
        public virtual void Edit(DataAccess data,TSRole tsRole)
        {
            string strSQL = "update TSRole set roleName=@roleName,status=@status where roleId=@roleId";
            Param param = new Param();
            param.Clear();
            param.Add("@roleName", tsRole.roleName);//角色名称
            param.Add("@status", tsRole.status);//使用状态
            param.Add("@roleId", tsRole.roleId);//角色编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改系统角色
        /// </summary>
        /// <param name="tsRole">系统角色</param>
        public virtual void Edit(TSRole tsRole)
        {
            try
            {
                db.Open();
                Edit(db,tsRole);
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
        /// 删除系统角色
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="roleId">角色编号</param>
        public virtual void Delete(DataAccess data,string roleId)
        {
            string strSQL = "delete from TSRole where roleId=@roleId";
            Param param = new Param();
            param.Clear();
            param.Add("@roleId", roleId);//角色编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除系统角色
        /// </summary>
        /// <param name="roleId">角色编号</param>
        public virtual void Delete(string roleId)
        {
            try
            {
                db.Open();
                Delete(db,roleId);
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
        /// 获取系统角色
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns>系统角色对象</returns>
        public virtual TSRole Get(string roleId)
        {
            TSRole tsRole=null;
            try
            {
                string strSQL = "select * from TSRole where roleId=@roleId";
                Param param = new Param();
                param.Clear();
                param.Add("@roleId", roleId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsRole=ReadData(dr);
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
            return tsRole;
        }
        
        /// <summary>
        /// 获取列表(系统角色)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>系统角色列表对象</returns>
        public virtual List<TSRole> GetList(string strSQL,Param param)
        {
            List<TSRole> list = new List<TSRole>();
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
        /// 获取列表(系统角色)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>系统角色列表对象</returns>
        public virtual List<TSRole> GetList(string field, string value)
        {
            List<TSRole> list = new List<TSRole>();
            try
            {
                string strSQL = "select * from TSRole where " + field + "=@field";
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
        /// 获取DataSet(系统角色)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>系统角色DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSRole");
        }
        
        /// <summary>
        /// 是否存在记录(系统角色)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSRole where " + field + "=@field";
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
        /// 读取系统角色信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>系统角色对象</returns>
        protected virtual TSRole ReadData(ComDataReader dr)
        {
            TSRole tsRole= new TSRole();
            tsRole.roleId= dr["roleId"].ToString();//角色编号
            tsRole.roleName= dr["roleName"].ToString();//角色名称
            tsRole.status= dr["status"].ToString();//使用状态
            return tsRole;
        }
        
        
        #endregion
        
    }
}

