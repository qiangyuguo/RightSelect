using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Manage;

namespace Com.ZY.JXKK.DAO.Manage
{
    /// <summary>
    /// 角色权限模块
    /// Author:代码生成器
    /// </summary>
    public class TSRightDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接

        /// <summary>
        /// 获取指定角色的权限模块ID哈希表【新增】
        /// </summary>
        /// <param name="roleIds">角色编号(可以多项用逗号分隔)</param>
        /// <returns>模块ID哈希表</returns>
        public Hashtable GetModuleIdHash(string roleIds)
        {
            Hashtable hashModuleId = new Hashtable();
            hashModuleId.Clear();
            string strSQL = " select distinct moduleId from TSRight where roleId in ('" + roleIds.Replace(",", "','") + "')";
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, null);
                while (dr.Read())
                {
                    hashModuleId.Add(dr["moduleId"], dr["moduleId"]);
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
            return hashModuleId;
        }

        /// <summary>
        /// 保存角色权限【新增】
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="moduleIdList">模块编号列表</param>
        public void Save(string roleId, List<string> moduleIdList)
        {
            ComTransaction trans = null;
            try
            {
                db.Open();
                trans = db.BeginTransaction();
                this.Delete(db,roleId);
                foreach (string moduleId in moduleIdList)
                {
                    TSRight tsRight = new TSRight();
                    tsRight.roleId = roleId;
                    tsRight.moduleId = moduleId;
                    this.Add(db, tsRight);
                }
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw e;
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 删除角色权限模块【修改】
        /// <param name="data">数据库连接</param>
        /// <param name="roleId">角色编号</param>
        /// </summary>
        public void Delete(DataAccess data, string roleId)
        {
            string strSQL = "delete from TSRight where roleId=:roleId ";
            Param param = new Param();
            param.Clear();
            param.Add(":roleId", roleId);//角色编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 删除角色权限模块【修改】
        /// <param name="roleId">角色编号</param>
        /// </summary>
        public void Delete(string roleId)
        {
            try
            {
                db.Open();
                Delete(db, roleId);
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

        #region 代码生成器自动生成


        /// <summary>
        /// 增加角色权限模块
        /// <param name="data">数据库连接</param>
        /// <param name="tsRight">角色权限模块</param>
        /// </summary>
        public void Add(DataAccess data, TSRight tsRight)
        {
            string strSQL = "insert into TSRight (roleId,moduleId) values (:roleId,:moduleId)";
            Param param = new Param();
            param.Clear();
            param.Add(":roleId", tsRight.roleId);//角色编号
            param.Add(":moduleId", tsRight.moduleId);//模块编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 增加角色权限模块
        /// <param name="tsRight">角色权限模块</param>
        /// </summary>
        public void Add(TSRight tsRight)
        {
            try
            {
                db.Open();
                Add(db, tsRight);
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
        /// <param name="data">数据库连接</param>
        /// <param name="tsRight">角色权限模块</param>
        /// </summary>
        public void Edit(DataAccess data, TSRight tsRight)
        {
            string strSQL = "update TSRight set  where roleId=:roleId and moduleId=:moduleId";
            Param param = new Param();
            param.Clear();
            param.Add(":roleId", tsRight.roleId);//角色编号
            param.Add(":moduleId", tsRight.moduleId);//模块编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 修改角色权限模块
        /// <param name="tsRight">角色权限模块</param>
        /// </summary>
        public void Edit(TSRight tsRight)
        {
            try
            {
                db.Open();
                Edit(db, tsRight);
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
        /// <param name="roleId">角色编号</param>
        /// <param name="moduleId">模块编号</param>
        /// </summary>
        /// <returns>角色权限模块对象</returns>
        public TSRight Get(string roleId, string moduleId)
        {
            TSRight tsRight = null;
            try
            {
                string strSQL = "select * from TSRight where roleId=:roleId and moduleId=:moduleId";
                Param param = new Param();
                param.Clear();
                param.Add(":roleId", roleId);
                param.Add(":moduleId", moduleId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsRight = ReadData(dr);
                }
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
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>角色权限模块列表对象</returns>
        public List<TSRight> GetList(string strSQL, Param param)
        {
            List<TSRight> list = new List<TSRight>();
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while (dr.Read())
                {
                    list.Add(ReadData(dr));
                }
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
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>角色权限模块列表对象</returns>
        public List<TSRight> GetList(string field, string value)
        {
            List<TSRight> list = new List<TSRight>();
            try
            {
                string strSQL = "select * from TSRight where " + field + "=:field";
                Param param = new Param();
                param.Clear();
                param.Add(":field", value);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while (dr.Read())
                {
                    list.Add(ReadData(dr));
                }
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
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>角色权限模块DataSet</returns>
        public DataSet GetDataSet(string strSQL, Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSRight");
        }

        /// <summary>
        /// 是否存在记录(角色权限模块)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSRight where " + field + "=:field";
                Param param = new Param();
                param.Clear();
                param.Add(":field", value);
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
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>角色权限模块对象</returns>
        private TSRight ReadData(ComDataReader dr)
        {
            TSRight tsRight = new TSRight();
            tsRight.roleId = dr["roleId"].ToString();//角色编号
            tsRight.moduleId = dr["moduleId"].ToString();//模块编号
            return tsRight;
        }


        #endregion
    }
}

