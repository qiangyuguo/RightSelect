using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Client;

namespace Com.ZY.JXKK.DAO.Client
{
    /// <summary>
    /// 客户账户明细
    /// Author:代码生成器
    /// </summary>
    public class TTClientAccDetailDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加客户账户明细
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientAccDetail">客户账户明细</param>
        /// </summary>
        public void Add(DataAccess data,TTClientAccDetail ttClientAccDetail)
        {
            string strSQL = "insert into TTClientAccDetail (flowId,clientId,clientName,agentId,siteId,fee,balance,createTime,cardId,remark) values (:flowId,:clientId,:clientName,:agentId,:siteId,:fee,:balance,To_date(:createTime,'yyyy-mm-dd hh24:mi:ss'),:cardId,:remark)";
            Param param = new Param();
            param.Clear();
            param.Add(":flowId", ttClientAccDetail.flowId);//编号
            param.Add(":clientId", ttClientAccDetail.clientId);//客户编号
            param.Add(":clientName", ttClientAccDetail.clientName);//客户名称
            param.Add(":agentId", ttClientAccDetail.agentId);//代理商编号
            param.Add(":siteId", ttClientAccDetail.siteId);//快开厅编号
            param.Add(":fee", ttClientAccDetail.fee);//发生金额
            param.Add(":balance", ttClientAccDetail.balance);//当前余额
            param.Add(":createTime", ttClientAccDetail.createTime);//创建时间
            param.Add(":cardId", ttClientAccDetail.cardId);//卡号
            param.Add(":remark", ttClientAccDetail.remark);//备注说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加客户账户明细
        /// <param name="ttClientAccDetail">客户账户明细</param>
        /// </summary>
        public void Add(TTClientAccDetail ttClientAccDetail)
        {
            try
            {
                db.Open();
                Add(db,ttClientAccDetail);
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
        /// 修改客户账户明细
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientAccDetail">客户账户明细</param>
        /// </summary>
        public void Edit(DataAccess data,TTClientAccDetail ttClientAccDetail)
        {
            string strSQL = "update TTClientAccDetail set clientId=:clientId,clientName=:clientName,agentId=:agentId,siteId=:siteId,fee=:fee,balance=:balance,createTime=To_date(:createTime,'yyyy-mm-dd hh24:mi:ss'),cardId=:cardId,remark=:remark where flowId=:flowId";
            Param param = new Param();
            param.Clear();
            param.Add(":clientId", ttClientAccDetail.clientId);//客户编号
            param.Add(":clientName", ttClientAccDetail.clientName);//客户名称
            param.Add(":agentId", ttClientAccDetail.agentId);//代理商编号
            param.Add(":siteId", ttClientAccDetail.siteId);//快开厅编号
            param.Add(":fee", ttClientAccDetail.fee);//发生金额
            param.Add(":balance", ttClientAccDetail.balance);//当前余额
            param.Add(":createTime", ttClientAccDetail.createTime);//创建时间
            param.Add(":cardId", ttClientAccDetail.cardId);//卡号
            param.Add(":remark", ttClientAccDetail.remark);//备注说明
            param.Add(":flowId", ttClientAccDetail.flowId);//编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改客户账户明细
        /// <param name="ttClientAccDetail">客户账户明细</param>
        /// </summary>
        public void Edit(TTClientAccDetail ttClientAccDetail)
        {
            try
            {
                db.Open();
                Edit(db,ttClientAccDetail);
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
        /// 删除客户账户明细
        /// <param name="data">数据库连接</param>
        /// <param name="flowId">编号</param>
        /// </summary>
        public void Delete(DataAccess data,long flowId)
        {
            string strSQL = "delete from TTClientAccDetail where flowId=:flowId";
            Param param = new Param();
            param.Clear();
            param.Add(":flowId", flowId);//编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除客户账户明细
        /// <param name="flowId">编号</param>
        /// </summary>
        public void Delete(long flowId)
        {
            try
            {
                db.Open();
                Delete(db,flowId);
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
        /// 获取客户账户明细
        /// <param name="flowId">编号</param>
        /// </summary>
        /// <returns>客户账户明细对象</returns>
        public TTClientAccDetail Get(long flowId)
        {
            TTClientAccDetail ttClientAccDetail=null;
            try
            {
                string strSQL = "select * from TTClientAccDetail where flowId=:flowId";
                Param param = new Param();
                param.Clear();
                param.Add(":flowId", flowId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttClientAccDetail=ReadData(dr);
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
            return ttClientAccDetail;
        }
        
        /// <summary>
        /// 获取列表(客户账户明细)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>客户账户明细列表对象</returns>
        public List<TTClientAccDetail> GetList(string strSQL,Param param)
        {
            List<TTClientAccDetail> list = new List<TTClientAccDetail>();
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
        /// 获取列表(客户账户明细)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>客户账户明细列表对象</returns>
        public List<TTClientAccDetail> GetList(string field, string value)
        {
            List<TTClientAccDetail> list = new List<TTClientAccDetail>();
            try
            {
                string strSQL = "select * from TTClientAccDetail where " + field + "=:field";
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
        /// 获取DataSet(客户账户明细)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>客户账户明细DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTClientAccDetail");
        }
        
        /// <summary>
        /// 是否存在记录(客户账户明细)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTClientAccDetail where " + field + "=:field";
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
        /// 读取客户账户明细信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>客户账户明细对象</returns>
        private TTClientAccDetail ReadData(ComDataReader dr)
        {
            TTClientAccDetail ttClientAccDetail= new TTClientAccDetail();
            ttClientAccDetail.flowId= long.Parse(dr["flowId"].ToString());//编号
            ttClientAccDetail.cardId = dr["cardId"].ToString();//卡号
            ttClientAccDetail.clientId= long.Parse(dr["clientId"].ToString());//客户编号
            ttClientAccDetail.clientName= dr["clientName"].ToString();//客户名称
            ttClientAccDetail.agentId= dr["agentId"].ToString();//代理商编号
            ttClientAccDetail.siteId= dr["siteId"].ToString();//快开厅编号
            ttClientAccDetail.lastBalance = double.Parse(dr["lastBalance"].ToString());//上次余额
            ttClientAccDetail.fee= double.Parse(dr["fee"].ToString());//发生金额
            ttClientAccDetail.balance= double.Parse(dr["balance"].ToString());//当前余额
            if (dr["changeTime"] == null)
            {
                ttClientAccDetail.changeTime = "";//发生时间
            }
            else
            {
                ttClientAccDetail.changeTime = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dr["changeTime"]);//发生时间
            }
            ttClientAccDetail.srcMode = dr["srcMode"].ToString();//来源方式
            if(dr["createTime"]==null)
            {
                ttClientAccDetail.createTime= "";//创建时间
            }
            else
            {
                ttClientAccDetail.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            
            ttClientAccDetail.remark= dr["remark"].ToString();//备注说明
            return ttClientAccDetail;
        }
        
        
        #endregion
        
    }
}

