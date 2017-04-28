using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Agent;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理账户明细
    /// Author:代码生成器
    /// </summary>
    public class TTAgentAccDetailDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加代理账户明细
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentAccDetail">代理账户明细</param>
        /// </summary>
        public void Add(DataAccess data,TTAgentAccDetail ttAgentAccDetail)
        {
            string strSQL = "insert into TTAgentAccDetail (flowId,agentId,agentName,lastBalance,fee,balance,createTime,remark) values (SAgentAccDetail_flowId.Nextval,:agentId,:agentName,:lastBalance,:fee,:balance,To_date(:createTime,'yyyy-mm-dd hh24:mi:ss'),:remark)";
            Param param = new Param();
            param.Clear();
            //param.Add(":flowId", ttAgentAccDetail.flowId);//流水号
            param.Add(":agentId", ttAgentAccDetail.agentId);//代理商编号
            param.Add(":agentName", ttAgentAccDetail.agentName);//代理商名称
            param.Add(":lastBalance", ttAgentAccDetail.lastBalance);//上次余额
            param.Add(":fee", ttAgentAccDetail.fee);//发生金额
            param.Add(":balance", ttAgentAccDetail.balance);//当前余额
            param.Add(":createTime", ttAgentAccDetail.createTime);//创建时间
            param.Add(":remark", ttAgentAccDetail.remark);//信息摘要
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加代理账户明细
        /// <param name="ttAgentAccDetail">代理账户明细</param>
        /// </summary>
        public void Add(TTAgentAccDetail ttAgentAccDetail)
        {
            try
            {
                db.Open();
                Add(db,ttAgentAccDetail);
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
        /// 修改代理账户明细
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentAccDetail">代理账户明细</param>
        /// </summary>
        public void Edit(DataAccess data,TTAgentAccDetail ttAgentAccDetail)
        {
            string strSQL = "update TTAgentAccDetail set agentId=:agentId,agentName=:agentName,lastBalance=:lastBalance,fee=:fee,balance=:balance,createTime=To_date(:createTime,'yyyy-mm-dd hh24:mi:ss'),remark=:remark where flowId=:flowId";
            Param param = new Param();
            param.Clear();
            param.Add(":agentId", ttAgentAccDetail.agentId);//代理商编号
            param.Add(":agentName", ttAgentAccDetail.agentName);//代理商名称
            param.Add(":lastBalance", ttAgentAccDetail.lastBalance);//上次余额
            param.Add(":fee", ttAgentAccDetail.fee);//发生金额
            param.Add(":balance", ttAgentAccDetail.balance);//当前余额
            param.Add(":createTime", ttAgentAccDetail.createTime);//创建时间
            param.Add(":remark", ttAgentAccDetail.remark);//信息摘要
            param.Add(":flowId", ttAgentAccDetail.flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改代理账户明细
        /// <param name="ttAgentAccDetail">代理账户明细</param>
        /// </summary>
        public void Edit(TTAgentAccDetail ttAgentAccDetail)
        {
            try
            {
                db.Open();
                Edit(db,ttAgentAccDetail);
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
        /// 删除代理账户明细
        /// <param name="data">数据库连接</param>
        /// <param name="flowId">流水号</param>
        /// </summary>
        public void Delete(DataAccess data,long flowId)
        {
            string strSQL = "delete from TTAgentAccDetail where flowId=:flowId";
            Param param = new Param();
            param.Clear();
            param.Add(":flowId", flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除代理账户明细
        /// <param name="flowId">流水号</param>
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
        /// 获取代理账户明细
        /// <param name="flowId">流水号</param>
        /// </summary>
        /// <returns>代理账户明细对象</returns>
        public TTAgentAccDetail Get(long flowId)
        {
            TTAgentAccDetail ttAgentAccDetail=null;
            try
            {
                string strSQL = "select * from TTAgentAccDetail where flowId=:flowId";
                Param param = new Param();
                param.Clear();
                param.Add(":flowId", flowId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttAgentAccDetail=ReadData(dr);
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
            return ttAgentAccDetail;
        }
        
        /// <summary>
        /// 获取列表(代理账户明细)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理账户明细列表对象</returns>
        public List<TTAgentAccDetail> GetList(string strSQL,Param param)
        {
            List<TTAgentAccDetail> list = new List<TTAgentAccDetail>();
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
        /// 获取列表(代理账户明细)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>代理账户明细列表对象</returns>
        public List<TTAgentAccDetail> GetList(string field, string value)
        {
            List<TTAgentAccDetail> list = new List<TTAgentAccDetail>();
            try
            {
                string strSQL = "select * from TTAgentAccDetail where " + field + "=:field";
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
        /// 获取DataSet(代理账户明细)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理账户明细DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTAgentAccDetail");
        }
        
        /// <summary>
        /// 是否存在记录(代理账户明细)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTAgentAccDetail where " + field + "=:field";
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
        /// 读取代理账户明细信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>代理账户明细对象</returns>
        private TTAgentAccDetail ReadData(ComDataReader dr)
        {
            TTAgentAccDetail ttAgentAccDetail= new TTAgentAccDetail();
            ttAgentAccDetail.flowId= long.Parse(dr["flowId"].ToString());//流水号
            ttAgentAccDetail.agentId= dr["agentId"].ToString();//代理商编号
            ttAgentAccDetail.agentName= dr["agentName"].ToString();//代理商名称
            ttAgentAccDetail.lastBalance= double.Parse(dr["lastBalance"].ToString());//上次余额
            ttAgentAccDetail.fee= double.Parse(dr["fee"].ToString());//发生金额
            ttAgentAccDetail.balance= double.Parse(dr["balance"].ToString());//当前余额
            if(dr["createTime"]==null)
            {
                ttAgentAccDetail.createTime= "";//创建时间
            }
            else
            {
                ttAgentAccDetail.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            ttAgentAccDetail.remark= dr["remark"].ToString();//信息摘要
            return ttAgentAccDetail;
        }
        
        
        #endregion
        
    }
}

