using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;
using System.Collections;

namespace Com.ZY.JXKK.DAO.Manage
{
    /// <summary>
    /// 角色权限模块
    /// Author:开发人员自行扩展
    /// </summary>
    public class TSRightDAO:TSRightDBO
    {
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
                this.Delete(db, roleId);
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
            string strSQL = "delete from TSRight where roleId=@roleId ";
            Param param = new Param();
            param.Clear();
            param.Add("@roleId", roleId);//角色编号
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
    }
}

