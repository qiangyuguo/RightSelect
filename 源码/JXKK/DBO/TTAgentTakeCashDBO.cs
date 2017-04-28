using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 代理商提现
    /// Author:代码生成器
    /// </summary>
    public class TTAgentTakeCashDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加代理商提现
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentTakeCash">代理商提现</param>
        public virtual void Add(DataAccess data,TTAgentTakeCash ttAgentTakeCash)
        {
            string strSQL = "insert into TTAgentTakeCash (flowId,agentId,agentName,lastBalance,fee,balance,operatorId,operatorName,createTime,handleMode,bankAccountId,bankFlowId,description) values (@flowId,@agentId,@agentName,@lastBalance,@fee,@balance,@operatorId,@operatorName,To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'),@handleMode,@bankAccountId,@bankFlowId,@description)";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", ttAgentTakeCash.flowId);//流水号
            param.Add("@agentId", ttAgentTakeCash.agentId);//代理商编号
            param.Add("@agentName", ttAgentTakeCash.agentName);//代理商名称
            param.Add("@lastBalance", ttAgentTakeCash.lastBalance);//上次余额
            param.Add("@fee", ttAgentTakeCash.fee);//发生金额
            param.Add("@balance", ttAgentTakeCash.balance);//当前余额
            param.Add("@operatorId", ttAgentTakeCash.operatorId);//操作人编号
            param.Add("@operatorName", ttAgentTakeCash.operatorName);//操作人名称
            param.Add("@createTime", ttAgentTakeCash.createTime);//创建时间
            param.Add("@handleMode", ttAgentTakeCash.handleMode);//提现方式
            param.Add("@bankAccountId", ttAgentTakeCash.bankAccountId);//银行账号
            param.Add("@bankFlowId", ttAgentTakeCash.bankFlowId);//银行流水号
            param.Add("@description", ttAgentTakeCash.description);//说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加代理商提现
        /// </summary>
        /// <param name="ttAgentTakeCash">代理商提现</param>
        public virtual void Add(TTAgentTakeCash ttAgentTakeCash)
        {
            try
            {
                db.Open();
                Add(db,ttAgentTakeCash);
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
        /// 修改代理商提现
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentTakeCash">代理商提现</param>
        public virtual void Edit(DataAccess data,TTAgentTakeCash ttAgentTakeCash)
        {
            string strSQL = "update TTAgentTakeCash set agentId=@agentId,agentName=@agentName,lastBalance=@lastBalance,fee=@fee,balance=@balance,operatorId=@operatorId,operatorName=@operatorName,createTime=To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'),handleMode=@handleMode,bankAccountId=@bankAccountId,bankFlowId=@bankFlowId,description=@description where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", ttAgentTakeCash.agentId);//代理商编号
            param.Add("@agentName", ttAgentTakeCash.agentName);//代理商名称
            param.Add("@lastBalance", ttAgentTakeCash.lastBalance);//上次余额
            param.Add("@fee", ttAgentTakeCash.fee);//发生金额
            param.Add("@balance", ttAgentTakeCash.balance);//当前余额
            param.Add("@operatorId", ttAgentTakeCash.operatorId);//操作人编号
            param.Add("@operatorName", ttAgentTakeCash.operatorName);//操作人名称
            param.Add("@createTime", ttAgentTakeCash.createTime);//创建时间
            param.Add("@handleMode", ttAgentTakeCash.handleMode);//提现方式
            param.Add("@bankAccountId", ttAgentTakeCash.bankAccountId);//银行账号
            param.Add("@bankFlowId", ttAgentTakeCash.bankFlowId);//银行流水号
            param.Add("@description", ttAgentTakeCash.description);//说明
            param.Add("@flowId", ttAgentTakeCash.flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改代理商提现
        /// </summary>
        /// <param name="ttAgentTakeCash">代理商提现</param>
        public virtual void Edit(TTAgentTakeCash ttAgentTakeCash)
        {
            try
            {
                db.Open();
                Edit(db,ttAgentTakeCash);
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
        /// 删除代理商提现
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="flowId">流水号</param>
        public virtual void Delete(DataAccess data,long flowId)
        {
            string strSQL = "delete from TTAgentTakeCash where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除代理商提现
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
        /// 获取代理商提现
        /// </summary>
        /// <param name="flowId">流水号</param>
        /// <returns>代理商提现对象</returns>
        public virtual TTAgentTakeCash Get(long flowId)
        {
            TTAgentTakeCash ttAgentTakeCash=null;
            try
            {
                string strSQL = "select * from TTAgentTakeCash where flowId=@flowId";
                Param param = new Param();
                param.Clear();
                param.Add("@flowId", flowId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttAgentTakeCash=ReadData(dr);
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
            return ttAgentTakeCash;
        }
        
        /// <summary>
        /// 获取列表(代理商提现)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理商提现列表对象</returns>
        public virtual List<TTAgentTakeCash> GetList(string strSQL,Param param)
        {
            List<TTAgentTakeCash> list = new List<TTAgentTakeCash>();
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
        /// 获取列表(代理商提现)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>代理商提现列表对象</returns>
        public virtual List<TTAgentTakeCash> GetList(string field, string value)
        {
            List<TTAgentTakeCash> list = new List<TTAgentTakeCash>();
            try
            {
                string strSQL = "select * from TTAgentTakeCash where " + field + "=@field";
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
        /// 获取DataSet(代理商提现)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理商提现DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTAgentTakeCash");
        }
        
        /// <summary>
        /// 是否存在记录(代理商提现)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTAgentTakeCash where " + field + "=@field";
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
        /// 读取代理商提现信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>代理商提现对象</returns>
        protected virtual TTAgentTakeCash ReadData(ComDataReader dr)
        {
            TTAgentTakeCash ttAgentTakeCash= new TTAgentTakeCash();
            ttAgentTakeCash.flowId= long.Parse(dr["flowId"].ToString());//流水号
            ttAgentTakeCash.agentId= dr["agentId"].ToString();//代理商编号
            ttAgentTakeCash.agentName= dr["agentName"].ToString();//代理商名称
            ttAgentTakeCash.lastBalance= double.Parse(dr["lastBalance"].ToString());//上次余额
            ttAgentTakeCash.fee= double.Parse(dr["fee"].ToString());//发生金额
            ttAgentTakeCash.balance= double.Parse(dr["balance"].ToString());//当前余额
            ttAgentTakeCash.operatorId= dr["operatorId"].ToString();//操作人编号
            ttAgentTakeCash.operatorName= dr["operatorName"].ToString();//操作人名称
            if(dr["createTime"]==null)
            {
                ttAgentTakeCash.createTime= "";//创建时间
            }
            else
            {
                ttAgentTakeCash.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            ttAgentTakeCash.handleMode= dr["handleMode"].ToString();//提现方式
            ttAgentTakeCash.bankAccountId= dr["bankAccountId"].ToString();//银行账号
            ttAgentTakeCash.bankFlowId= dr["bankFlowId"].ToString();//银行流水号
            ttAgentTakeCash.description= dr["description"].ToString();//说明
            return ttAgentTakeCash;
        }
        
        
        #endregion
        
    }
}

