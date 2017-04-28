using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 代理商充值
    /// Author:代码生成器
    /// </summary>
    public class TTAgentRechargeDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加代理商充值
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentRecharge">代理商充值</param>
        public virtual void Add(DataAccess data,TTAgentRecharge ttAgentRecharge)
        {
            string strSQL = "insert into TTAgentRecharge (flowId,agentId,agentName,lastBalance,fee,balance,operatorId,operatorName,createTime,handleMode,bankAccountId,bankFlowId,description) values (@flowId,@agentId,@agentName,@lastBalance,@fee,@balance,@operatorId,@operatorName,To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'),@handleMode,@bankAccountId,@bankFlowId,@description)";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", ttAgentRecharge.flowId);//流水号
            param.Add("@agentId", ttAgentRecharge.agentId);//代理商编号
            param.Add("@agentName", ttAgentRecharge.agentName);//代理商名称
            param.Add("@lastBalance", ttAgentRecharge.lastBalance);//上次余额
            param.Add("@fee", ttAgentRecharge.fee);//发生金额
            param.Add("@balance", ttAgentRecharge.balance);//当前余额
            param.Add("@operatorId", ttAgentRecharge.operatorId);//操作人编号
            param.Add("@operatorName", ttAgentRecharge.operatorName);//操作人名称
            param.Add("@createTime", ttAgentRecharge.createTime);//创建时间
            param.Add("@handleMode", ttAgentRecharge.handleMode);//充值方式
            param.Add("@bankAccountId", ttAgentRecharge.bankAccountId);//银行账号
            param.Add("@bankFlowId", ttAgentRecharge.bankFlowId);//银行流水号
            param.Add("@description", ttAgentRecharge.description);//说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加代理商充值
        /// </summary>
        /// <param name="ttAgentRecharge">代理商充值</param>
        public virtual void Add(TTAgentRecharge ttAgentRecharge)
        {
            try
            {
                db.Open();
                Add(db,ttAgentRecharge);
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
        /// 修改代理商充值
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentRecharge">代理商充值</param>
        public virtual void Edit(DataAccess data,TTAgentRecharge ttAgentRecharge)
        {
            string strSQL = "update TTAgentRecharge set agentId=@agentId,agentName=@agentName,lastBalance=@lastBalance,fee=@fee,balance=@balance,operatorId=@operatorId,operatorName=@operatorName,createTime=To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'),handleMode=@handleMode,bankAccountId=@bankAccountId,bankFlowId=@bankFlowId,description=@description where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", ttAgentRecharge.agentId);//代理商编号
            param.Add("@agentName", ttAgentRecharge.agentName);//代理商名称
            param.Add("@lastBalance", ttAgentRecharge.lastBalance);//上次余额
            param.Add("@fee", ttAgentRecharge.fee);//发生金额
            param.Add("@balance", ttAgentRecharge.balance);//当前余额
            param.Add("@operatorId", ttAgentRecharge.operatorId);//操作人编号
            param.Add("@operatorName", ttAgentRecharge.operatorName);//操作人名称
            param.Add("@createTime", ttAgentRecharge.createTime);//创建时间
            param.Add("@handleMode", ttAgentRecharge.handleMode);//充值方式
            param.Add("@bankAccountId", ttAgentRecharge.bankAccountId);//银行账号
            param.Add("@bankFlowId", ttAgentRecharge.bankFlowId);//银行流水号
            param.Add("@description", ttAgentRecharge.description);//说明
            param.Add("@flowId", ttAgentRecharge.flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改代理商充值
        /// </summary>
        /// <param name="ttAgentRecharge">代理商充值</param>
        public virtual void Edit(TTAgentRecharge ttAgentRecharge)
        {
            try
            {
                db.Open();
                Edit(db,ttAgentRecharge);
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
        /// 删除代理商充值
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="flowId">流水号</param>
        public virtual void Delete(DataAccess data,long flowId)
        {
            string strSQL = "delete from TTAgentRecharge where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除代理商充值
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
        /// 获取代理商充值
        /// </summary>
        /// <param name="flowId">流水号</param>
        /// <returns>代理商充值对象</returns>
        public virtual TTAgentRecharge Get(long flowId)
        {
            TTAgentRecharge ttAgentRecharge=null;
            try
            {
                string strSQL = "select * from TTAgentRecharge where flowId=@flowId";
                Param param = new Param();
                param.Clear();
                param.Add("@flowId", flowId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttAgentRecharge=ReadData(dr);
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
            return ttAgentRecharge;
        }
        
        /// <summary>
        /// 获取列表(代理商充值)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理商充值列表对象</returns>
        public virtual List<TTAgentRecharge> GetList(string strSQL,Param param)
        {
            List<TTAgentRecharge> list = new List<TTAgentRecharge>();
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
        /// 获取列表(代理商充值)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>代理商充值列表对象</returns>
        public virtual List<TTAgentRecharge> GetList(string field, string value)
        {
            List<TTAgentRecharge> list = new List<TTAgentRecharge>();
            try
            {
                string strSQL = "select * from TTAgentRecharge where " + field + "=@field";
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
        /// 获取DataSet(代理商充值)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理商充值DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTAgentRecharge");
        }
        
        /// <summary>
        /// 是否存在记录(代理商充值)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTAgentRecharge where " + field + "=@field";
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
        /// 读取代理商充值信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>代理商充值对象</returns>
        protected virtual TTAgentRecharge ReadData(ComDataReader dr)
        {
            TTAgentRecharge ttAgentRecharge= new TTAgentRecharge();
            ttAgentRecharge.flowId= long.Parse(dr["flowId"].ToString());//流水号
            ttAgentRecharge.agentId= dr["agentId"].ToString();//代理商编号
            ttAgentRecharge.agentName= dr["agentName"].ToString();//代理商名称
            ttAgentRecharge.lastBalance= double.Parse(dr["lastBalance"].ToString());//上次余额
            ttAgentRecharge.fee= double.Parse(dr["fee"].ToString());//发生金额
            ttAgentRecharge.balance= double.Parse(dr["balance"].ToString());//当前余额
            ttAgentRecharge.operatorId= dr["operatorId"].ToString();//操作人编号
            ttAgentRecharge.operatorName= dr["operatorName"].ToString();//操作人名称
            if(dr["createTime"]==null)
            {
                ttAgentRecharge.createTime= "";//创建时间
            }
            else
            {
                ttAgentRecharge.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            ttAgentRecharge.handleMode= dr["handleMode"].ToString();//充值方式
            ttAgentRecharge.bankAccountId= dr["bankAccountId"].ToString();//银行账号
            ttAgentRecharge.bankFlowId= dr["bankFlowId"].ToString();//银行流水号
            ttAgentRecharge.description= dr["description"].ToString();//说明
            return ttAgentRecharge;
        }
        
        
        #endregion
        
    }
}

