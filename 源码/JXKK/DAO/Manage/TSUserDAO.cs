using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Manage
{
    /// <summary>
    /// 系统用户
    /// Author:开发人员自行扩展
    /// </summary>
    public class TSUserDAO:TSUserDBO
    {
        /// <summary>
        /// 修改密码【增加】
        /// <param name="userId">用户编号</param>
        /// <param name="password">待修改密码</param>
        /// </summary>
        public void ChangePwd(string userId, string password)
        {
            string strSQL = "update TSUser set userPwd=@userPwd where userId=@userId";
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
        /// 修改系统用户【修改】
        /// <param name="data">数据库连接</param>
        /// <param name="tsUser">系统用户</param>
        /// </summary>
        public override void Edit(DataAccess data, TSUser tsUser)
        {
            string strSQL = "update TSUser set userName=@userName,userCode=@userCode,roleIds=@roleIds,deptId=@deptId,status=@status,post=@post,telephone=@telephone where userId=@userId";
            Param param = new Param();
            param.Clear();
            param.Add("@userName", tsUser.userName);//用户姓名
            param.Add("@userCode", tsUser.userCode);//用户帐号
            //param.Add("@userPwd", tsUser.userPwd);//用户密码
            param.Add("@roleIds", tsUser.roleIds);//角色编号
            param.Add("@deptId", tsUser.deptId);//部门编号
            param.Add("@status", tsUser.status);//使用状态
            param.Add("@post", tsUser.post);//职务
            param.Add("@telephone", tsUser.telephone);//联系电话
            param.Add("@userId", tsUser.userId);//用户编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
    }
}

