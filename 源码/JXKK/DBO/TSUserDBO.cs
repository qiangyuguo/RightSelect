using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 系统用户
    /// Author:代码生成器
    /// </summary>
    public class TSUserDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加系统用户
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsUser">系统用户</param>
        public virtual void Add(DataAccess data,TSUser tsUser)
        {
            string strSQL = "insert into TSUser (userId,userName,userCode,userPwd,roleIds,deptId,status,post,telephone) values (@userId,@userName,@userCode,@userPwd,@roleIds,@deptId,@status,@post,@telephone)";
            Param param = new Param();
            param.Clear();
            param.Add("@userId", tsUser.userId);//用户编号
            param.Add("@userName", tsUser.userName);//用户姓名
            param.Add("@userCode", tsUser.userCode);//用户帐号
            param.Add("@userPwd", tsUser.userPwd);//用户密码
            param.Add("@roleIds", tsUser.roleIds);//角色编号
            param.Add("@deptId", tsUser.deptId);//部门编号
            param.Add("@status", tsUser.status);//使用状态
            param.Add("@post", tsUser.post);//职务
            param.Add("@telephone", tsUser.telephone);//联系电话
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加系统用户
        /// </summary>
        /// <param name="tsUser">系统用户</param>
        public virtual void Add(TSUser tsUser)
        {
            try
            {
                db.Open();
                Add(db,tsUser);
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
        /// 修改系统用户
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsUser">系统用户</param>
        public virtual void Edit(DataAccess data,TSUser tsUser)
        {
            string strSQL = "update TSUser set userName=@userName,userCode=@userCode,userPwd=@userPwd,roleIds=@roleIds,deptId=@deptId,status=@status,post=@post,telephone=@telephone where userId=@userId";
            Param param = new Param();
            param.Clear();
            param.Add("@userName", tsUser.userName);//用户姓名
            param.Add("@userCode", tsUser.userCode);//用户帐号
            param.Add("@userPwd", tsUser.userPwd);//用户密码
            param.Add("@roleIds", tsUser.roleIds);//角色编号
            param.Add("@deptId", tsUser.deptId);//部门编号
            param.Add("@status", tsUser.status);//使用状态
            param.Add("@post", tsUser.post);//职务
            param.Add("@telephone", tsUser.telephone);//联系电话
            param.Add("@userId", tsUser.userId);//用户编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改系统用户
        /// </summary>
        /// <param name="tsUser">系统用户</param>
        public virtual void Edit(TSUser tsUser)
        {
            try
            {
                db.Open();
                Edit(db,tsUser);
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
        /// 删除系统用户
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="userId">用户编号</param>
        public virtual void Delete(DataAccess data,string userId)
        {
            string strSQL = "delete from TSUser where userId=@userId";
            Param param = new Param();
            param.Clear();
            param.Add("@userId", userId);//用户编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除系统用户
        /// </summary>
        /// <param name="userId">用户编号</param>
        public virtual void Delete(string userId)
        {
            try
            {
                db.Open();
                Delete(db,userId);
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
        /// 获取系统用户
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns>系统用户对象</returns>
        public virtual TSUser Get(string userId)
        {
            TSUser tsUser=null;
            try
            {
                string strSQL = "select * from TSUser where userId=@userId";
                Param param = new Param();
                param.Clear();
                param.Add("@userId", userId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsUser=ReadData(dr);
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
            return tsUser;
        }

        /// <summary>
        /// 获取系统用户
        /// </summary>
        /// <param name="userId">用户登录名</param>
        /// <returns>系统用户对象</returns>
        public virtual TSUser GetTSUser(string USERCODE)
        {
            TSUser tsUser = null;
            try
            {
                string strSQL = "select * from TSUser where USERCODE=@USERCODE";
                Param param = new Param();
                param.Clear();
                param.Add("@USERCODE", USERCODE);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsUser = ReadData(dr);
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
            return tsUser;
        }

        /// <summary>
        /// 获取列表(系统用户)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>系统用户列表对象</returns>
        public virtual List<TSUser> GetList(string strSQL,Param param)
        {
            List<TSUser> list = new List<TSUser>();
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
        /// 获取列表(系统用户)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>系统用户列表对象</returns>
        public virtual List<TSUser> GetList(string field, string value)
        {
            List<TSUser> list = new List<TSUser>();
            try
            {
                string strSQL = "select * from TSUser where " + field + "=@field";
                Param param = new Param();
                param.Clear();
                param.Add("@field", value);
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
        /// 获取DataSet(系统用户)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>系统用户DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSUser");
        }
        
        /// <summary>
        /// 是否存在记录(系统用户)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSUser where " + field + "=@field";
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
        /// 读取系统用户信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>系统用户对象</returns>
        protected virtual TSUser ReadData(ComDataReader dr)
        {
            TSUser tsUser= new TSUser();
            tsUser.userId= dr["userId"].ToString();//用户编号
            tsUser.userName= dr["userName"].ToString();//用户姓名
            tsUser.userCode= dr["userCode"].ToString();//用户帐号
            tsUser.userPwd= dr["userPwd"].ToString();//用户密码
            tsUser.roleIds= dr["roleIds"].ToString();//角色编号
            tsUser.deptId= dr["deptId"].ToString();//部门编号
            tsUser.status= dr["status"].ToString();//使用状态
            tsUser.post= dr["post"].ToString();//职务
            tsUser.telephone= dr["telephone"].ToString();//联系电话
            return tsUser;
        }
        
        
        #endregion
        
    }
}

