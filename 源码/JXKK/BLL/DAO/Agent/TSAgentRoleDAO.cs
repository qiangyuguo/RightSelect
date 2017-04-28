using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Agent;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理系统角色
    /// Author:代码生成器
    /// </summary>
    public class TSAgentRoleDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加代理系统角色
        /// <param name="data">数据库连接</param>
        /// <param name="tsAgentRole">代理系统角色</param>
        /// </summary>
        public void Add(DataAccess data,TSAgentRole tsAgentRole)
        {
            string strSQL = "insert into TSAgentRole (roleId,roleName,status,type) values (:roleId,:roleName,:status,:type)";
            Param param = new Param();
            param.Clear();
            param.Add(":roleId", tsAgentRole.roleId);//角色编号
            param.Add(":roleName", tsAgentRole.roleName);//角色名称
            param.Add(":status", tsAgentRole.status);//使用状态
            param.Add(":type", tsAgentRole.type);//类型
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加代理系统角色
        /// <param name="tsAgentRole">代理系统角色</param>
        /// </summary>
        public void Add(TSAgentRole tsAgentRole)
        {
            try
            {
                db.Open();
                Add(db,tsAgentRole);
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
        /// 修改代理系统角色
        /// <param name="data">数据库连接</param>
        /// <param name="tsAgentRole">代理系统角色</param>
        /// </summary>
        public void Edit(DataAccess data,TSAgentRole tsAgentRole)
        {
            string strSQL = "update TSAgentRole set roleName=:roleName,status=:status,type=:type where roleId=:roleId";
            Param param = new Param();
            param.Clear();
            param.Add(":roleName", tsAgentRole.roleName);//角色名称
            param.Add(":status", tsAgentRole.status);//使用状态
            param.Add(":type", tsAgentRole.type);//类型
            param.Add(":roleId", tsAgentRole.roleId);//角色编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改代理系统角色
        /// <param name="tsAgentRole">代理系统角色</param>
        /// </summary>
        public void Edit(TSAgentRole tsAgentRole)
        {
            try
            {
                db.Open();
                Edit(db,tsAgentRole);
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
        /// 删除代理系统角色
        /// <param name="data">数据库连接</param>
        /// <param name="roleId">角色编号</param>
        /// </summary>
        public void Delete(DataAccess data,string roleId)
        {
            string strSQL = "delete from TSAgentRole where roleId=:roleId";
            Param param = new Param();
            param.Clear();
            param.Add(":roleId", roleId);//角色编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除代理系统角色
        /// <param name="roleId">角色编号</param>
        /// </summary>
        public void Delete(string roleId)
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
        /// 获取代理系统角色
        /// <param name="roleId">角色编号</param>
        /// </summary>
        /// <returns>代理系统角色对象</returns>
        public TSAgentRole Get(string roleId)
        {
            TSAgentRole tsAgentRole=null;
            try
            {
                string strSQL = "select * from TSAgentRole where roleId=:roleId";
                Param param = new Param();
                param.Clear();
                param.Add(":roleId", roleId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsAgentRole=ReadData(dr);
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
            return tsAgentRole;
        }
        
        /// <summary>
        /// 获取列表(代理系统角色)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理系统角色列表对象</returns>
        public List<TSAgentRole> GetList(string strSQL,Param param)
        {
            List<TSAgentRole> list = new List<TSAgentRole>();
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
        /// 获取列表(代理系统角色)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>代理系统角色列表对象</returns>
        public List<TSAgentRole> GetList(string field, string value)
        {
            List<TSAgentRole> list = new List<TSAgentRole>();
            try
            {
                string strSQL = "select * from TSAgentRole where " + field + "=:field";
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
        /// 获取DataSet(代理系统角色)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理系统角色DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSAgentRole");
        }
        
        /// <summary>
        /// 是否存在记录(代理系统角色)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSAgentRole where " + field + "=:field";
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
        /// 读取代理系统角色信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>代理系统角色对象</returns>
        private TSAgentRole ReadData(ComDataReader dr)
        {
            TSAgentRole tsAgentRole= new TSAgentRole();
            tsAgentRole.roleId= dr["roleId"].ToString();//角色编号
            tsAgentRole.roleName= dr["roleName"].ToString();//角色名称
            tsAgentRole.status= dr["status"].ToString();//使用状态
            tsAgentRole.type= dr["type"].ToString();//类型
            return tsAgentRole;
        }
        
        
        #endregion
        
    }
}

