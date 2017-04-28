using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理门店用户
    /// Author:开发人员自行扩展
    /// </summary>
    public class TSAgentUserDAO:TSAgentUserDBO
    {
        /// <summary>
        /// 获取代理门店用户
        /// <param name="userId">用户帐号</param>
        /// </summary>
        /// <returns>代理门店用户对象</returns>
        public  TSAgentUser Get(string userId,string roleId)
        {
            TSAgentUser tsAgentUser = null;
            try
            {
                string strSQL = "select * from TSAgentUser where userId=@userId and roleId=@roleId";
                Param param = new Param();
                param.Clear();
                param.Add("@userId", userId);
                param.Add("@roleId", roleId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsAgentUser = ReadData(dr);
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
            return tsAgentUser;
        }

        /// <summary>
        /// 修改密码【增加】
        /// <param name="userId">用户编号</param>
        /// <param name="password">待修改密码</param>
        /// </summary>
        public void ChangePwd(string userId, string password,string type)
        {
            string strSQL = "update TSAgentUser set userPwd=@userPwd where userId=@userId ";
            if (type == "0")
            {
                strSQL += "  and roleId='001'";
            }
            else
            {
                strSQL += "  and roleId!='001'";
            }
            Param param = new Param();
            param.Clear();
            param.Add("@userPwd", password);//用户密码
            param.Add("@userId", userId);//用户编号

            try
            {
                db.Open();
                db.ExecuteNonQuery(CommandType.Text, strSQL, param);
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
        /// 修改代理快开厅用户
        /// <param name="data">数据库连接</param>
        /// <param name="tsAgentUser">代理快开厅用户</param>
        /// </summary>
        public void Edit(DataAccess data, TSAgentUser tsAgentUser, string type)
        {
            string strSQL = "update TSAgentUser set roleId=@roleId,userCode=@userCode where userId=@userId";
            if (type == "0")
            {
                strSQL += "  and roleId='001'";
            }
            else
            {
                strSQL += "  and roleId!='001'";
            }
            Param param = new Param();
            param.Clear();
            param.Add("@roleId", tsAgentUser.roleId);//角色编号
            param.Add("@userId", tsAgentUser.userId);//关联用户编号
            param.Add("@userCode", tsAgentUser.userCode);//用户帐号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 修改代理快开厅用户
        /// <param name="tsAgentUser">代理快开厅用户</param>
        /// </summary>
        public void Edit(TSAgentUser tsAgentUser, string type)
        {
            try
            {
                db.Open();
                Edit(db, tsAgentUser, type);
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
        /// 删除代理快开厅用户
        /// <param name="data">数据库连接</param>
        /// <param name="userCode">用户帐号</param>
        /// </summary>
        public void Delete(DataAccess data, string userId, string roleId)
        {
            string strSQL = "delete from TSAgentUser where userId=@userId and roleId =@roleId";
            Param param = new Param();
            param.Clear();
            param.Add("@userId", userId);//用户帐号
            param.Add("@roleId", roleId);//用户角色
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 删除代理快开厅用户
        /// <param name="userCode">用户帐号</param>
        /// </summary>
        public void Delete(string userId, string roleId)
        {
            try
            {
                db.Open();
                Delete(db, userId, roleId);
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

