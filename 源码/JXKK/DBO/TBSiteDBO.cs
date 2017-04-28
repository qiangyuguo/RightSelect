using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 门店信息
    /// Author:代码生成器
    /// </summary>
    public class TBSiteDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加门店信息
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbSite">门店信息</param>
        public virtual void Add(DataAccess data,TBSite tbSite)
        {
            string strSQL = "insert into TBSite (siteId,agentId,siteName,specialArea,address,contact,telephone,auditStatus,status,remark,pointRule) values (@siteId,@agentId,@siteName,@specialArea,@address,@contact,@telephone,@auditStatus,@status,@remark,@pointRule)";
            Param param = new Param();
            param.Clear();
            param.Add("@siteId", tbSite.siteId);//门店编号
            param.Add("@agentId", tbSite.agentId);//代理商编号
            param.Add("@siteName", tbSite.siteName);//门店名称
            param.Add("@specialArea", tbSite.specialArea);//专营面积
            param.Add("@address", tbSite.address);//详细地址
            param.Add("@contact", tbSite.contact);//联系人
            param.Add("@telephone", tbSite.telephone);//手机号码
            param.Add("@auditStatus", tbSite.auditStatus);//审批状态
            param.Add("@status", tbSite.status);//使用状态
            param.Add("@remark", tbSite.remark);//备注说明
            param.Add("@pointRule", tbSite.pointRule);//积分规则
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加门店信息
        /// </summary>
        /// <param name="tbSite">门店信息</param>
        public virtual void Add(TBSite tbSite)
        {
            try
            {
                db.Open();
                Add(db,tbSite);
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
        /// 修改门店信息
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbSite">门店信息</param>
        public virtual void Edit(DataAccess data,TBSite tbSite)
        {
            string strSQL = "update TBSite set agentId=@agentId,siteName=@siteName,specialArea=@specialArea,address=@address,contact=@contact,telephone=@telephone,auditStatus=@auditStatus,status=@status,remark=@remark,pointRule=@pointRule where siteId=@siteId";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", tbSite.agentId);//代理商编号
            param.Add("@siteName", tbSite.siteName);//门店名称
            param.Add("@specialArea", tbSite.specialArea);//专营面积
            param.Add("@address", tbSite.address);//详细地址
            param.Add("@contact", tbSite.contact);//联系人
            param.Add("@telephone", tbSite.telephone);//手机号码
            param.Add("@auditStatus", tbSite.auditStatus);//审批状态
            param.Add("@status", tbSite.status);//使用状态
            param.Add("@remark", tbSite.remark);//备注说明
            param.Add("@pointRule", tbSite.pointRule);//积分规则
            param.Add("@siteId", tbSite.siteId);//门店编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改门店信息
        /// </summary>
        /// <param name="tbSite">门店信息</param>
        public virtual void Edit(TBSite tbSite)
        {
            try
            {
                db.Open();
                Edit(db,tbSite);
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
        /// 删除门店信息
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="siteId">门店编号</param>
        public virtual void Delete(DataAccess data,string siteId)
        {
            string strSQL = "delete from TBSite where siteId=@siteId";
            Param param = new Param();
            param.Clear();
            param.Add("@siteId", siteId);//门店编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除门店信息
        /// </summary>
        /// <param name="siteId">门店编号</param>
        public virtual void Delete(string siteId)
        {
            try
            {
                db.Open();
                Delete(db,siteId);
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
        /// 获取门店信息
        /// </summary>
        /// <param name="siteId">门店编号</param>
        /// <returns>门店信息对象</returns>
        public virtual TBSite Get(string siteId)
        {
            TBSite tbSite=null;
            try
            {
                string strSQL = "select * from TBSite where siteId=@siteId";
                Param param = new Param();
                param.Clear();
                param.Add("@siteId", siteId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbSite=ReadData(dr);
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
            return tbSite;
        }

 

        
        /// <summary>
        /// 获取列表(门店信息)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>门店信息列表对象</returns>
        public virtual List<TBSite> GetList(string strSQL,Param param)
        {
            List<TBSite> list = new List<TBSite>();
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
        /// 获取列表(门店信息)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>门店信息列表对象</returns>
        public virtual List<TBSite> GetList(string field, string value)
        {
            List<TBSite> list = new List<TBSite>();
            try
            {
                string strSQL = "select * from TBSite where " + field + "=@field";
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
        /// 获取DataSet(门店信息)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>门店信息DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBSite");
        }
        
        /// <summary>
        /// 是否存在记录(门店信息)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBSite where " + field + "=@field";
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
        /// 读取门店信息信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>门店信息对象</returns>
        protected virtual TBSite ReadData(ComDataReader dr)
        {
            TBSite tbSite= new TBSite();
            tbSite.siteId= dr["siteId"].ToString();//门店编号
            tbSite.agentId= dr["agentId"].ToString();//代理商编号
            tbSite.siteName= dr["siteName"].ToString();//门店名称
            tbSite.specialArea= double.Parse(dr["specialArea"].ToString());//专营面积
            tbSite.address= dr["address"].ToString();//详细地址
            tbSite.contact= dr["contact"].ToString();//联系人
            tbSite.telephone= dr["telephone"].ToString();//手机号码
            tbSite.auditStatus= dr["auditStatus"].ToString();//审批状态
            tbSite.status= dr["status"].ToString();//使用状态
            tbSite.remark= dr["remark"].ToString();//备注说明
            tbSite.pointRule= int.Parse(dr["pointRule"].ToString());//积分规则
            tbSite.description = dr["description"].ToString();//
            tbSite.picture = dr["picture"].ToString();//门店图片
            tbSite.servicesPhone = dr["servicesPhone"].ToString();//门店图片
            return tbSite;
        }
        
        
        #endregion
        
    }
}

