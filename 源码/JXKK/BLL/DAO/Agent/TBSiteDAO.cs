using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Agent;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 快开厅信息
    /// Author:代码生成器
    /// </summary>
    public class TBSiteDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        #region 新增代码

        /// <summary>
        /// 增加快开厅信息
        /// <param name="data">数据库连接</param>
        /// <param name="tbSite">快开厅信息</param>
        /// </summary>
        public void Add(DataAccess data, TBSite tbSite)
        {
            string strSQL = "insert into TBSite (siteId,agentId,siteName,address,contact,telephone,auditStatus,status,remark) values (:siteId,:agentId,:siteName,:address,:contact,:telephone,:auditStatus,:status,:remark)";
            Param param = new Param();
            param.Clear();
            param.Add(":siteId", tbSite.siteId);//快开厅编号
            param.Add(":agentId", tbSite.agentId);//代理商编号
            param.Add(":siteName", tbSite.siteName);//快开厅名称
            param.Add(":address", tbSite.address);//详细地址
            param.Add(":contact", tbSite.contact);//联系人
            param.Add(":telephone", tbSite.telephone);//手机号码
            param.Add(":auditStatus", tbSite.auditStatus);//审批状态
            param.Add(":status", "0");//使用状态
            param.Add(":remark", tbSite.remark);//备注说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        /// <summary>
        /// 审核修改审核状态
        /// </summary>
        /// <param name="tbSite"></param>
        public void Audit(TBSite tbSite)
        {
            string strSQL = "update TBSite set auditStatus=:auditStatus,remark=:remark,status=:status where siteId =:siteId";
            Param param = new Param();
            param.Clear();
            param.Add(":siteId", tbSite.siteId);
            param.Add(":auditStatus", tbSite.auditStatus);
            param.Add(":status", tbSite.status);
            param.Add(":remark", tbSite.remark);
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
        /// 修改快开厅信息
        /// <param name="data">数据库连接</param>
        /// <param name="tbSite">快开厅信息</param>
        /// </summary>
        public void Edit(DataAccess data, TBSite tbSite)
        {
            string strSQL = "update TBSite set agentId=:agentId,siteName=:siteName,address=:address,contact=:contact,telephone=:telephone,status=:status,auditStatus=:auditStatus,remark=:remark where siteId=:siteId";
            Param param = new Param();
            param.Clear();
            param.Add(":agentId", tbSite.agentId);//代理商编号
            param.Add(":siteName", tbSite.siteName);//快开厅名称
            param.Add(":address", tbSite.address);//详细地址
            param.Add(":contact", tbSite.contact);//联系人
            param.Add(":telephone", tbSite.telephone);//手机号码
            param.Add(":status", tbSite.status);//使用状态
            param.Add(":auditStatus", tbSite.auditStatus);//审核状态
            param.Add(":remark", tbSite.remark);//备注说明
            param.Add(":siteId", tbSite.siteId);//快开厅编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        #endregion

        #region 代码生成器自动生成
        /// <summary>
        /// 增加快开厅信息
        /// <param name="tbSite">快开厅信息</param>
        /// </summary>
        public void Add(TBSite tbSite)
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
        /// 修改快开厅信息
        /// <param name="tbSite">快开厅信息</param>
        /// </summary>
        public void Edit(TBSite tbSite)
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
        /// 删除快开厅信息
        /// <param name="data">数据库连接</param>
        /// <param name="siteId">快开厅编号</param>
        /// </summary>
        public void Delete(DataAccess data,string siteId)
        {
            string strSQL = "delete from TBSite where siteId=:siteId";
            Param param = new Param();
            param.Clear();
            param.Add(":siteId", siteId);//快开厅编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除快开厅信息
        /// <param name="siteId">快开厅编号</param>
        /// </summary>
        public void Delete(string siteId)
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
        /// 获取快开厅信息
        /// <param name="siteId">快开厅编号</param>
        /// </summary>
        /// <returns>快开厅信息对象</returns>
        public TBSite Get(string siteId)
        {
            TBSite tbSite=null;
            try
            {
                string strSQL = "select * from TBSite where siteId=:siteId";
                Param param = new Param();
                param.Clear();
                param.Add(":siteId", siteId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbSite=ReadData(dr);
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
            return tbSite;
        }
        
        /// <summary>
        /// 获取列表(快开厅信息)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>快开厅信息列表对象</returns>
        public List<TBSite> GetList(string strSQL,Param param)
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
        /// 获取列表(快开厅信息)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>快开厅信息列表对象</returns>
        public List<TBSite> GetList(string field, string value)
        {
            List<TBSite> list = new List<TBSite>();
            try
            {
                string strSQL = "select * from TBSite where " + field + "=:field";
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
        /// 获取DataSet(快开厅信息)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>快开厅信息DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBSite");
        }
        
        /// <summary>
        /// 是否存在记录(快开厅信息)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBSite where " + field + "=:field";
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
        /// 读取快开厅信息信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>快开厅信息对象</returns>
        private TBSite ReadData(ComDataReader dr)
        {
            TBSite tbSite= new TBSite();
            tbSite.siteId= dr["siteId"].ToString();//快开厅编号
            tbSite.agentId= dr["agentId"].ToString();//代理商编号
            tbSite.siteName= dr["siteName"].ToString();//快开厅名称
            tbSite.address= dr["address"].ToString();//详细地址
            tbSite.contact= dr["contact"].ToString();//联系人
            tbSite.telephone= dr["telephone"].ToString();//手机号码
            tbSite.auditStatus= dr["auditStatus"].ToString();//审批状态
            tbSite.status= dr["status"].ToString();//使用状态
            tbSite.remark= dr["remark"].ToString();//备注说明
            tbSite.specialArea = double.Parse(dr["specialArea"].ToString());//专营面积
            return tbSite;
        }
        
        
        #endregion

    }
}

