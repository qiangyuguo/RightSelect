using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 代理商充值预审
    /// Author:代码生成器
    /// </summary>
    public class TTAgentPreRechgDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加代理商充值预审
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentPreRechg">代理商充值预审</param>
        public virtual void Add(DataAccess data,TTAgentPreRechg ttAgentPreRechg)
        {
            string strSQL = "insert into TTAgentPreRechg (flowId,agentId,agentName,fee,operatorId,operatorName,createTime,handleMode,bankAccountId,bankFlowId,description,auditStatus) values (@flowId,@agentId,@agentName,@fee,@operatorId,@operatorName,To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'),@handleMode,@bankAccountId,@bankFlowId,@description,@auditStatus)";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", ttAgentPreRechg.flowId);//流水号
            param.Add("@agentId", ttAgentPreRechg.agentId);//代理商编号
            param.Add("@agentName", ttAgentPreRechg.agentName);//代理商名称
            param.Add("@fee", ttAgentPreRechg.fee);//发生金额
            param.Add("@operatorId", ttAgentPreRechg.operatorId);//操作人编号
            param.Add("@operatorName", ttAgentPreRechg.operatorName);//操作人名称
            param.Add("@createTime", ttAgentPreRechg.createTime);//创建时间
            param.Add("@handleMode", ttAgentPreRechg.handleMode);//充值方式
            param.Add("@bankAccountId", ttAgentPreRechg.bankAccountId);//银行账号
            param.Add("@bankFlowId", ttAgentPreRechg.bankFlowId);//银行流水号
            param.Add("@description", ttAgentPreRechg.description);//说明
            param.Add("@auditStatus", ttAgentPreRechg.auditStatus);//审核状态
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加代理商充值预审
        /// </summary>
        /// <param name="ttAgentPreRechg">代理商充值预审</param>
        public virtual void Add(TTAgentPreRechg ttAgentPreRechg)
        {
            try
            {
                db.Open();
                Add(db,ttAgentPreRechg);
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
        /// 修改代理商充值预审
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentPreRechg">代理商充值预审</param>
        public virtual void Edit(DataAccess data,TTAgentPreRechg ttAgentPreRechg)
        {
            string strSQL = "update TTAgentPreRechg set agentId=@agentId,agentName=@agentName,fee=@fee,operatorId=@operatorId,operatorName=@operatorName,createTime=To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'),handleMode=@handleMode,bankAccountId=@bankAccountId,bankFlowId=@bankFlowId,description=@description,auditStatus=@auditStatus where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", ttAgentPreRechg.agentId);//代理商编号
            param.Add("@agentName", ttAgentPreRechg.agentName);//代理商名称
            param.Add("@fee", ttAgentPreRechg.fee);//发生金额
            param.Add("@operatorId", ttAgentPreRechg.operatorId);//操作人编号
            param.Add("@operatorName", ttAgentPreRechg.operatorName);//操作人名称
            param.Add("@createTime", ttAgentPreRechg.createTime);//创建时间
            param.Add("@handleMode", ttAgentPreRechg.handleMode);//充值方式
            param.Add("@bankAccountId", ttAgentPreRechg.bankAccountId);//银行账号
            param.Add("@bankFlowId", ttAgentPreRechg.bankFlowId);//银行流水号
            param.Add("@description", ttAgentPreRechg.description);//说明
            param.Add("@auditStatus", ttAgentPreRechg.auditStatus);//审核状态
            param.Add("@flowId", ttAgentPreRechg.flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改代理商充值预审
        /// </summary>
        /// <param name="ttAgentPreRechg">代理商充值预审</param>
        public virtual void Edit(TTAgentPreRechg ttAgentPreRechg)
        {
            try
            {
                db.Open();
                Edit(db,ttAgentPreRechg);
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
        /// 删除代理商充值预审
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="flowId">流水号</param>
        public virtual void Delete(DataAccess data,long flowId)
        {
            string strSQL = "delete from TTAgentPreRechg where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除代理商充值预审
        /// </summary>
        /// <param name="flowId">流水号</param>
        public virtual void Delete(long flowId)
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
        /// 获取代理商充值预审
        /// </summary>
        /// <param name="flowId">流水号</param>
        /// <returns>代理商充值预审对象</returns>
        public virtual TTAgentPreRechg Get(long flowId)
        {
            TTAgentPreRechg ttAgentPreRechg=null;
            try
            {
                string strSQL = "select * from TTAgentPreRechg where flowId=@flowId";
                Param param = new Param();
                param.Clear();
                param.Add("@flowId", flowId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttAgentPreRechg=ReadData(dr);
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
            return ttAgentPreRechg;
        }
        
        /// <summary>
        /// 获取列表(代理商充值预审)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理商充值预审列表对象</returns>
        public virtual List<TTAgentPreRechg> GetList(string strSQL,Param param)
        {
            List<TTAgentPreRechg> list = new List<TTAgentPreRechg>();
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
        /// 获取列表(代理商充值预审)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>代理商充值预审列表对象</returns>
        public virtual List<TTAgentPreRechg> GetList(string field, string value)
        {
            List<TTAgentPreRechg> list = new List<TTAgentPreRechg>();
            try
            {
                string strSQL = "select * from TTAgentPreRechg where " + field + "=@field";
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
        /// 获取DataSet(代理商充值预审)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理商充值预审DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTAgentPreRechg");
        }
        
        /// <summary>
        /// 是否存在记录(代理商充值预审)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTAgentPreRechg where " + field + "=@field";
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
        /// 读取代理商充值预审信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>代理商充值预审对象</returns>
        protected virtual TTAgentPreRechg ReadData(ComDataReader dr)
        {
            TTAgentPreRechg ttAgentPreRechg= new TTAgentPreRechg();
            ttAgentPreRechg.flowId= long.Parse(dr["flowId"].ToString());//流水号
            ttAgentPreRechg.agentId= dr["agentId"].ToString();//代理商编号
            ttAgentPreRechg.agentName= dr["agentName"].ToString();//代理商名称
            ttAgentPreRechg.fee= double.Parse(dr["fee"].ToString());//发生金额
            ttAgentPreRechg.operatorId= dr["operatorId"].ToString();//操作人编号
            ttAgentPreRechg.operatorName= dr["operatorName"].ToString();//操作人名称
            if(dr["createTime"]==null)
            {
                ttAgentPreRechg.createTime= "";//创建时间
            }
            else
            {
                ttAgentPreRechg.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            ttAgentPreRechg.handleMode= dr["handleMode"].ToString();//充值方式
            ttAgentPreRechg.bankAccountId= dr["bankAccountId"].ToString();//银行账号
            ttAgentPreRechg.bankFlowId= dr["bankFlowId"].ToString();//银行流水号
            ttAgentPreRechg.description= dr["description"].ToString();//说明
            ttAgentPreRechg.auditStatus= dr["auditStatus"].ToString();//审核状态
            return ttAgentPreRechg;
        }
        
        
        #endregion
        
    }
}

