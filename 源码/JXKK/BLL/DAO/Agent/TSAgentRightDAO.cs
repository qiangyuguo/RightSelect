using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Agent;
using System.Collections;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理系统权限模块
    /// Author:代码生成器
    /// </summary>
    public class TSAgentRightDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加代理系统权限模块
        /// <param name="data">数据库连接</param>
        /// <param name="tsAgentRight">代理系统权限模块</param>
        /// </summary>
        public void Add(DataAccess data,TSAgentRight tsAgentRight)
        {
            string strSQL = "insert into TSAgentRight (roleId,moduleId) values (:roleId,:moduleId)";
            Param param = new Param();
            param.Clear();
            param.Add(":roleId", tsAgentRight.roleId);//角色编号
            param.Add(":moduleId", tsAgentRight.moduleId);//模块编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加代理系统权限模块
        /// <param name="tsAgentRight">代理系统权限模块</param>
        /// </summary>
        public void Add(TSAgentRight tsAgentRight)
        {
            try
            {
                db.Open();
                Add(db,tsAgentRight);
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
        /// 修改代理系统权限模块
        /// <param name="data">数据库连接</param>
        /// <param name="tsAgentRight">代理系统权限模块</param>
        /// </summary>
        public void Edit(DataAccess data,TSAgentRight tsAgentRight)
        {
            string strSQL = "update TSAgentRight set  where roleId=:roleId and moduleId=:moduleId";
            Param param = new Param();
            param.Clear();
            param.Add(":roleId", tsAgentRight.roleId);//角色编号
            param.Add(":moduleId", tsAgentRight.moduleId);//模块编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改代理系统权限模块
        /// <param name="tsAgentRight">代理系统权限模块</param>
        /// </summary>
        public void Edit(TSAgentRight tsAgentRight)
        {
            try
            {
                db.Open();
                Edit(db,tsAgentRight);
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
        /// 删除代理系统权限模块
        /// <param name="data">数据库连接</param>
        /// <param name="roleId">角色编号</param>
        /// <param name="moduleId">模块编号</param>
        /// </summary>
        public void Delete(DataAccess data,string roleId,string moduleId)
        {
            string strSQL = "delete from TSAgentRight where roleId=:roleId and moduleId=:moduleId";
            Param param = new Param();
            param.Clear();
            param.Add(":roleId", roleId);//角色编号
            param.Add(":moduleId", moduleId);//模块编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除代理系统权限模块
        /// <param name="roleId">角色编号</param>
        /// <param name="moduleId">模块编号</param>
        /// </summary>
        public void Delete(string roleId,string moduleId)
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
        /// 获取代理系统权限模块
        /// <param name="roleId">角色编号</param>
        /// <param name="moduleId">模块编号</param>
        /// </summary>
        /// <returns>代理系统权限模块对象</returns>
        public TSAgentRight Get(string roleId,string moduleId)
        {
            TSAgentRight tsAgentRight=null;
            try
            {
                string strSQL = "select * from TSAgentRight where roleId=:roleId and moduleId=:moduleId";
                Param param = new Param();
                param.Clear();
                param.Add(":roleId", roleId);
                param.Add(":moduleId", moduleId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsAgentRight=ReadData(dr);
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
            return tsAgentRight;
        }
        
        /// <summary>
        /// 获取列表(代理系统权限模块)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理系统权限模块列表对象</returns>
        public List<TSAgentRight> GetList(string strSQL,Param param)
        {
            List<TSAgentRight> list = new List<TSAgentRight>();
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while(dr.Read())
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
        /// 获取列表(代理系统权限模块)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>代理系统权限模块列表对象</returns>
        public List<TSAgentRight> GetList(string field, string value)
        {
            List<TSAgentRight> list = new List<TSAgentRight>();
            try
            {
                string strSQL = "select * from TSAgentRight where " + field + "=:field";
                Param param = new Param();
                param.Clear();
                param.Add(":field",value);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while(dr.Read())
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
        /// 获取DataSet(代理系统权限模块)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理系统权限模块DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSAgentRight");
        }
        
        /// <summary>
        /// 是否存在记录(代理系统权限模块)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSAgentRight where " + field + "=:field";
                Param param = new Param();
                param.Clear();
                param.Add(":field",value);
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
        /// 读取代理系统权限模块信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>代理系统权限模块对象</returns>
        private TSAgentRight ReadData(ComDataReader dr)
        {
            TSAgentRight tsAgentRight= new TSAgentRight();
            tsAgentRight.roleId= dr["roleId"].ToString();//角色编号
            tsAgentRight.moduleId= dr["moduleId"].ToString();//模块编号
            return tsAgentRight;
        }
        
        
        #endregion

        #region 新增代码
        /// <summary>
        /// 获取指定角色的权限模块ID哈希表
        /// </summary>
        /// <param name="roleIds">角色编号(可以多项用逗号分隔)</param>
        /// <returns>模块ID哈希表</returns>
        public Hashtable GetAgentModuleIdHash(string roleIds)
        {
            Hashtable hashModuleId = new Hashtable();
            hashModuleId.Clear();
            string strSQL = " select distinct moduleId from TSAgentRight where roleId in ('" + roleIds.Replace(",", "','") + "')";
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
        /// 保存角色权限
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
                this.Delete(roleId);
                foreach (string moduleId in moduleIdList)
                {
                    this.Add(roleId, moduleId);
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
        /// 增加角色权限
        /// </summary>
        /// <param name="roleId">机构编号</param>
        /// <param name="moduleId">模块编号</param>
        /// <returns>无</returns>
        private void Add(string roleId, string moduleId)
        {
            //添加角色权限记录
            string strSQL = "insert into TSAgentRight (roleId, moduleid) values(:roleId,:moduleid)";
            Param param = new Param();
            param.Clear();
            param.Add(":roleId", roleId);
            param.Add(":moduleid", moduleId);
            db.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 删除机构权限
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns>无</returns>
        private void Delete(string roleId)
        {
            string strSQL = "delete from TSAgentRight where roleId =:roleId";
            Param param = new Param();
            param.Clear();
            param.Add(":roleId", roleId);
            db.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        #endregion
    }
}

