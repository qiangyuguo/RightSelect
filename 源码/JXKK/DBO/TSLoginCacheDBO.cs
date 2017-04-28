using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 收银端登录信息缓存
    /// Author:代码生成器
    /// </summary>
    public class TSLoginCacheDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加收银端登录信息缓存
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsLoginCache">收银端登录信息缓存</param>
        public virtual void Add(DataAccess data,TSLoginCache tsLoginCache)
        {
            string strSQL = "insert into TSLoginCache (staffId,staffName,siteId,siteName,agentId,agentName,validCode,status) values (@staffId,@staffName,@siteId,@siteName,@agentId,@agentName,@validCode,@status)";
            Param param = new Param();
            param.Clear();
            param.Add("@staffId", tsLoginCache.staffId);//员工编号
            param.Add("@staffName", tsLoginCache.staffName);//员工姓名
            param.Add("@siteId", tsLoginCache.siteId);//门店编号
            param.Add("@siteName", tsLoginCache.siteName);//门店名称
            param.Add("@agentId", tsLoginCache.agentId);//代理商编号
            param.Add("@agentName", tsLoginCache.agentName);//代理商名称
            param.Add("@validCode", tsLoginCache.validCode);//登录验证码
            param.Add("@status", tsLoginCache.status);//使用状态
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加收银端登录信息缓存
        /// </summary>
        /// <param name="tsLoginCache">收银端登录信息缓存</param>
        public virtual void Add(TSLoginCache tsLoginCache)
        {
            try
            {
                db.Open();
                Add(db,tsLoginCache);
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
        /// 修改收银端登录信息缓存
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsLoginCache">收银端登录信息缓存</param>
        public virtual void Edit(DataAccess data,TSLoginCache tsLoginCache)
        {
            string strSQL = "update TSLoginCache set staffName=@staffName,siteId=@siteId,siteName=@siteName,agentId=@agentId,agentName=@agentName,validCode=@validCode,status=@status where staffId=@staffId";
            Param param = new Param();
            param.Clear();
            param.Add("@staffName", tsLoginCache.staffName);//员工姓名
            param.Add("@siteId", tsLoginCache.siteId);//门店编号
            param.Add("@siteName", tsLoginCache.siteName);//门店名称
            param.Add("@agentId", tsLoginCache.agentId);//代理商编号
            param.Add("@agentName", tsLoginCache.agentName);//代理商名称
            param.Add("@validCode", tsLoginCache.validCode);//登录验证码
            param.Add("@status", tsLoginCache.status);//使用状态
            param.Add("@staffId", tsLoginCache.staffId);//员工编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改收银端登录信息缓存
        /// </summary>
        /// <param name="tsLoginCache">收银端登录信息缓存</param>
        public virtual void Edit(TSLoginCache tsLoginCache)
        {
            try
            {
                db.Open();
                Edit(db,tsLoginCache);
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
        /// 删除收银端登录信息缓存
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="staffId">员工编号</param>
        public virtual void Delete(DataAccess data,string staffId)
        {
            string strSQL = "delete from TSLoginCache where staffId=@staffId";
            Param param = new Param();
            param.Clear();
            param.Add("@staffId", staffId);//员工编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除收银端登录信息缓存
        /// </summary>
        /// <param name="staffId">员工编号</param>
        public virtual void Delete(string staffId)
        {
            try
            {
                db.Open();
                Delete(db,staffId);
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
        /// 获取收银端登录信息缓存
        /// </summary>
        /// <param name="staffId">员工编号</param>
        /// <returns>收银端登录信息缓存对象</returns>
        public virtual TSLoginCache Get(string staffId)
        {
            TSLoginCache tsLoginCache=null;
            try
            {
                string strSQL = "select * from TSLoginCache where staffId=@staffId";
                Param param = new Param();
                param.Clear();
                param.Add("@staffId", staffId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsLoginCache=ReadData(dr);
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
            return tsLoginCache;
        }
        
        /// <summary>
        /// 获取列表(收银端登录信息缓存)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>收银端登录信息缓存列表对象</returns>
        public virtual List<TSLoginCache> GetList(string strSQL,Param param)
        {
            List<TSLoginCache> list = new List<TSLoginCache>();
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
        /// 获取列表(收银端登录信息缓存)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>收银端登录信息缓存列表对象</returns>
        public virtual List<TSLoginCache> GetList(string field, string value)
        {
            List<TSLoginCache> list = new List<TSLoginCache>();
            try
            {
                string strSQL = "select * from TSLoginCache where " + field + "=@field";
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
        /// 获取DataSet(收银端登录信息缓存)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>收银端登录信息缓存DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSLoginCache");
        }
        
        /// <summary>
        /// 是否存在记录(收银端登录信息缓存)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSLoginCache where " + field + "=@field";
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
        /// 读取收银端登录信息缓存信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>收银端登录信息缓存对象</returns>
        protected virtual TSLoginCache ReadData(ComDataReader dr)
        {
            TSLoginCache tsLoginCache= new TSLoginCache();
            tsLoginCache.staffId= dr["staffId"].ToString();//员工编号
            tsLoginCache.staffName= dr["staffName"].ToString();//员工姓名
            tsLoginCache.siteId= dr["siteId"].ToString();//门店编号
            tsLoginCache.siteName= dr["siteName"].ToString();//门店名称
            tsLoginCache.agentId= dr["agentId"].ToString();//代理商编号
            tsLoginCache.agentName= dr["agentName"].ToString();//代理商名称
            tsLoginCache.validCode= dr["validCode"].ToString();//登录验证码
            tsLoginCache.status= dr["status"].ToString();//使用状态
            return tsLoginCache;
        }
        
        
        #endregion
        
    }
}

