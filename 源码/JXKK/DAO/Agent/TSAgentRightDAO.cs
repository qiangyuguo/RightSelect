using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;
using System.Collections;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理系统权限模块
    /// Author:开发人员自行扩展
    /// </summary>
    public class TSAgentRightDAO:TSAgentRightDBO
    {
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
            string strSQL = "insert into TSAgentRight (roleId, moduleid) values(@roleId,@moduleid)";
            Param param = new Param();
            param.Clear();
            param.Add("@roleId", roleId);
            param.Add("@moduleid", moduleId);
            db.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 删除机构权限
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns>无</returns>
        private void Delete(string roleId)
        {
            string strSQL = "delete from TSAgentRight where roleId =@roleId";
            Param param = new Param();
            param.Clear();
            param.Add("@roleId", roleId);
            db.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

    }
}

