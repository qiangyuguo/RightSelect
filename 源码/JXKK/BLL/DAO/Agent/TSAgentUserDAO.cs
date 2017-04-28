using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Agent;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理快开厅用户
    /// Author:代码生成器
    /// </summary>
    public class TSAgentUserDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接

        /// <summary>
        /// 修改密码【增加】
        /// <param name="userId">用户编号</param>
        /// <param name="password">待修改密码</param>
        /// </summary>
        public void ChangePwd(string userId, string password)
        {
            string strSQL = "update TSAgentUser set userPwd=:userPwd where userId=:userId";
            Param param = new Param();
            param.Clear();
            param.Add(":userPwd", password);//用户密码
            param.Add(":userId", userId);//用户编号

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
        public void Edit(DataAccess data, TSAgentUser tsAgentUser,string type)
        {
            string strSQL = "update TSAgentUser set roleId=:roleId,userCode=:userCode where userId=:userId";
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
            param.Add(":roleId", tsAgentUser.roleId);//角色编号
            param.Add(":userId", tsAgentUser.userId);//关联用户编号
            param.Add(":userCode", tsAgentUser.userCode);//用户帐号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        /// <summary>
        /// 修改代理快开厅用户
        /// <param name="tsAgentUser">代理快开厅用户</param>
        /// </summary>
        public void Edit(TSAgentUser tsAgentUser,string type)
        {
            try
            {
                db.Open();
                Edit(db, tsAgentUser,type);
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
        public void Delete(DataAccess data, string userId,string roleId)
        {
            string strSQL = "delete from TSAgentUser where userId=:userId and roleId=:roleId";
            Param param = new Param();
            param.Clear();
            param.Add(":userId", userId);//用户帐号
            param.Add(":roleId", roleId);//用户角色
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

        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加代理快开厅用户
        /// <param name="data">数据库连接</param>
        /// <param name="tsAgentUser">代理快开厅用户</param>
        /// </summary>
        public void Add(DataAccess data,TSAgentUser tsAgentUser)
        {
            string strSQL = "insert into TSAgentUser (userCode,userPwd,roleId,userId) values (:userCode,:userPwd,:roleId,:userId)";
            Param param = new Param();
            param.Clear();
            param.Add(":userCode", tsAgentUser.userCode);//用户帐号
            param.Add(":userPwd", tsAgentUser.userPwd);//用户密码
            param.Add(":roleId", tsAgentUser.roleId);//角色编号
            param.Add(":userId", tsAgentUser.userId);//关联用户编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加代理快开厅用户
        /// <param name="tsAgentUser">代理快开厅用户</param>
        /// </summary>
        public void Add(TSAgentUser tsAgentUser)
        {
            try
            {
                db.Open();
                Add(db,tsAgentUser);
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
        /// 获取代理快开厅用户
        /// <param name="userCode">用户帐号</param>
        /// </summary>
        /// <returns>代理快开厅用户对象</returns>
        public TSAgentUser Get(string userId)
        {
            TSAgentUser tsAgentUser=null;
            try
            {
                string strSQL = "select * from TSAgentUser where userId=:userId";
                Param param = new Param();
                param.Clear();
                param.Add(":userId", userId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsAgentUser=ReadData(dr);
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
            return tsAgentUser;
        }
        
        /// <summary>
        /// 获取列表(代理快开厅用户)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理快开厅用户列表对象</returns>
        public List<TSAgentUser> GetList(string strSQL,Param param)
        {
            List<TSAgentUser> list = new List<TSAgentUser>();
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
        /// 获取列表(代理快开厅用户)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>代理快开厅用户列表对象</returns>
        public List<TSAgentUser> GetList(string field, string value)
        {
            List<TSAgentUser> list = new List<TSAgentUser>();
            try
            {
                string strSQL = "select * from TSAgentUser where " + field + "=:field";
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
        /// 获取DataSet(代理快开厅用户)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理快开厅用户DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSAgentUser");
        }

        /// <summary>
        /// 是否存在记录(代理快开厅用户)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSAgentUser where " + field + "=:field";
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
        /// 读取代理快开厅用户信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>代理快开厅用户对象</returns>
        private TSAgentUser ReadData(ComDataReader dr)
        {
            TSAgentUser tsAgentUser= new TSAgentUser();
            tsAgentUser.userCode= dr["userCode"].ToString();//用户帐号
            tsAgentUser.userPwd= dr["userPwd"].ToString();//用户密码
            tsAgentUser.roleId= dr["roleId"].ToString();//角色编号
            tsAgentUser.userId= dr["userId"].ToString();//关联用户编号
            return tsAgentUser;
        }
        
        
        #endregion
        
    }
}

