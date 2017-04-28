using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 代理门店用户
    /// Author:代码生成器
    /// </summary>
    public class TSAgentUserDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加代理门店用户
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsAgentUser">代理门店用户</param>
        public virtual void Add(DataAccess data,TSAgentUser tsAgentUser)
        {
            string strSQL = "insert into TSAgentUser (userCode,userPwd,roleId,userId) values (@userCode,@userPwd,@roleId,@userId)";
            Param param = new Param();
            param.Clear();
            param.Add("@userCode", tsAgentUser.userCode);//用户帐号
            param.Add("@userPwd", tsAgentUser.userPwd);//用户密码
            param.Add("@roleId", tsAgentUser.roleId);//角色编号
            param.Add("@userId", tsAgentUser.userId);//关联用户编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加代理门店用户
        /// </summary>
        /// <param name="tsAgentUser">代理门店用户</param>
        public virtual void Add(TSAgentUser tsAgentUser)
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
        /// 修改代理门店用户
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsAgentUser">代理门店用户</param>
        public virtual void Edit(DataAccess data,TSAgentUser tsAgentUser)
        {
            string strSQL = "update TSAgentUser set userPwd=@userPwd,roleId=@roleId,userId=@userId where userCode=@userCode";
            Param param = new Param();
            param.Clear();
            param.Add("@userPwd", tsAgentUser.userPwd);//用户密码
            param.Add("@roleId", tsAgentUser.roleId);//角色编号
            param.Add("@userId", tsAgentUser.userId);//关联用户编号
            param.Add("@userCode", tsAgentUser.userCode);//用户帐号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改代理门店用户
        /// </summary>
        /// <param name="tsAgentUser">代理门店用户</param>
        public virtual void Edit(TSAgentUser tsAgentUser)
        {
            try
            {
                db.Open();
                Edit(db,tsAgentUser);
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
        /// 删除代理门店用户
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="userCode">用户帐号</param>
        public virtual void Delete(DataAccess data,string userCode)
        {
            string strSQL = "delete from TSAgentUser where userCode=@userCode";
            Param param = new Param();
            param.Clear();
            param.Add("@userCode", userCode);//用户帐号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除代理门店用户
        /// </summary>
        /// <param name="userCode">用户帐号</param>
        public virtual void Delete(string userCode)
        {
            try
            {
                db.Open();
                Delete(db,userCode);
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
        /// 获取代理门店用户
        /// </summary>
        /// <param name="userCode">用户帐号</param>
        /// <returns>代理门店用户对象</returns>
        public virtual TSAgentUser Get(string userCode)
        {
            TSAgentUser tsAgentUser=null;
            try
            {
                string strSQL = "select * from TSAgentUser where userCode=@userCode";
                Param param = new Param();
                param.Clear();
                param.Add("@userCode", userCode);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsAgentUser=ReadData(dr);
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
        /// 获取列表(代理门店用户)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理门店用户列表对象</returns>
        public virtual List<TSAgentUser> GetList(string strSQL,Param param)
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
        /// 获取列表(代理门店用户)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>代理门店用户列表对象</returns>
        public virtual List<TSAgentUser> GetList(string field, string value)
        {
            List<TSAgentUser> list = new List<TSAgentUser>();
            try
            {
                string strSQL = "select * from TSAgentUser where " + field + "=@field";
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
        /// 获取DataSet(代理门店用户)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理门店用户DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSAgentUser");
        }
        
        /// <summary>
        /// 是否存在记录(代理门店用户)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSAgentUser where " + field + "=@field";
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
        /// 读取代理门店用户信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>代理门店用户对象</returns>
        protected virtual TSAgentUser ReadData(ComDataReader dr)
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

