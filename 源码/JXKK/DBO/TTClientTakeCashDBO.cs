using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 客户提现
    /// Author:代码生成器
    /// </summary>
    public class TTClientTakeCashDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加客户提现
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientTakeCash">客户提现</param>
        public virtual void Add(DataAccess data,TTClientTakeCash ttClientTakeCash)
        {
            string strSQL = "insert into TTClientTakeCash (flowId,clientId,clientName,agentId,siteId,lastBalance,fee,balance,handleMode,operatorId,operatorName,createTime,cardId,sourceType,timeStamp,description) values (@flowId,@clientId,@clientName,@agentId,@siteId,@lastBalance,@fee,@balance,@handleMode,@operatorId,@operatorName,To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'),@cardId,@sourceType,@timeStamp,@description)";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", ttClientTakeCash.flowId);//流水号
            param.Add("@clientId", ttClientTakeCash.clientId);//客户编号
            param.Add("@clientName", ttClientTakeCash.clientName);//客户名称
            param.Add("@agentId", ttClientTakeCash.agentId);//代理商编号
            param.Add("@siteId", ttClientTakeCash.siteId);//门店编号
            param.Add("@lastBalance", ttClientTakeCash.lastBalance);//上次余额
            param.Add("@fee", ttClientTakeCash.fee);//发生金额
            param.Add("@balance", ttClientTakeCash.balance);//当前余额
            param.Add("@handleMode", ttClientTakeCash.handleMode);//提现方式
            param.Add("@operatorId", ttClientTakeCash.operatorId);//操作人编号
            param.Add("@operatorName", ttClientTakeCash.operatorName);//操作人名称
            param.Add("@createTime", ttClientTakeCash.createTime);//创建时间
            param.Add("@cardId", ttClientTakeCash.cardId);//卡号
            param.Add("@sourceType", ttClientTakeCash.sourceType);//提现来源
            param.Add("@timeStamp", ttClientTakeCash.timeStamp);//时间戳
            param.Add("@description", ttClientTakeCash.description);//说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加客户提现
        /// </summary>
        /// <param name="ttClientTakeCash">客户提现</param>
        public virtual void Add(TTClientTakeCash ttClientTakeCash)
        {
            try
            {
                db.Open();
                Add(db,ttClientTakeCash);
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
        /// 修改客户提现
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientTakeCash">客户提现</param>
        public virtual void Edit(DataAccess data,TTClientTakeCash ttClientTakeCash)
        {
            string strSQL = "update TTClientTakeCash set clientId=@clientId,clientName=@clientName,agentId=@agentId,siteId=@siteId,lastBalance=@lastBalance,fee=@fee,balance=@balance,handleMode=@handleMode,operatorId=@operatorId,operatorName=@operatorName,createTime=To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'),cardId=@cardId,sourceType=@sourceType,timeStamp=@timeStamp,description=@description where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@clientId", ttClientTakeCash.clientId);//客户编号
            param.Add("@clientName", ttClientTakeCash.clientName);//客户名称
            param.Add("@agentId", ttClientTakeCash.agentId);//代理商编号
            param.Add("@siteId", ttClientTakeCash.siteId);//门店编号
            param.Add("@lastBalance", ttClientTakeCash.lastBalance);//上次余额
            param.Add("@fee", ttClientTakeCash.fee);//发生金额
            param.Add("@balance", ttClientTakeCash.balance);//当前余额
            param.Add("@handleMode", ttClientTakeCash.handleMode);//提现方式
            param.Add("@operatorId", ttClientTakeCash.operatorId);//操作人编号
            param.Add("@operatorName", ttClientTakeCash.operatorName);//操作人名称
            param.Add("@createTime", ttClientTakeCash.createTime);//创建时间
            param.Add("@cardId", ttClientTakeCash.cardId);//卡号
            param.Add("@sourceType", ttClientTakeCash.sourceType);//提现来源
            param.Add("@timeStamp", ttClientTakeCash.timeStamp);//时间戳
            param.Add("@description", ttClientTakeCash.description);//说明
            param.Add("@flowId", ttClientTakeCash.flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改客户提现
        /// </summary>
        /// <param name="ttClientTakeCash">客户提现</param>
        public virtual void Edit(TTClientTakeCash ttClientTakeCash)
        {
            try
            {
                db.Open();
                Edit(db,ttClientTakeCash);
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
        /// 删除客户提现
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="flowId">流水号</param>
        public virtual void Delete(DataAccess data,long flowId)
        {
            string strSQL = "delete from TTClientTakeCash where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除客户提现
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
        /// 获取客户提现
        /// </summary>
        /// <param name="flowId">流水号</param>
        /// <returns>客户提现对象</returns>
        public virtual TTClientTakeCash Get(long flowId)
        {
            TTClientTakeCash ttClientTakeCash=null;
            try
            {
                string strSQL = "select * from TTClientTakeCash where flowId=@flowId";
                Param param = new Param();
                param.Clear();
                param.Add("@flowId", flowId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttClientTakeCash=ReadData(dr);
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
            return ttClientTakeCash;
        }
        
        /// <summary>
        /// 获取列表(客户提现)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>客户提现列表对象</returns>
        public virtual List<TTClientTakeCash> GetList(string strSQL,Param param)
        {
            List<TTClientTakeCash> list = new List<TTClientTakeCash>();
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
        /// 获取列表(客户提现)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>客户提现列表对象</returns>
        public virtual List<TTClientTakeCash> GetList(string field, string value)
        {
            List<TTClientTakeCash> list = new List<TTClientTakeCash>();
            try
            {
                string strSQL = "select * from TTClientTakeCash where " + field + "=@field";
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
        /// 获取DataSet(客户提现)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>客户提现DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTClientTakeCash");
        }
        
        /// <summary>
        /// 是否存在记录(客户提现)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTClientTakeCash where " + field + "=@field";
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
        /// 读取客户提现信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>客户提现对象</returns>
        protected virtual TTClientTakeCash ReadData(ComDataReader dr)
        {
            TTClientTakeCash ttClientTakeCash= new TTClientTakeCash();
            ttClientTakeCash.flowId= long.Parse(dr["flowId"].ToString());//流水号
            ttClientTakeCash.clientId= long.Parse(dr["clientId"].ToString());//客户编号
            ttClientTakeCash.clientName= dr["clientName"].ToString();//客户名称
            ttClientTakeCash.agentId= dr["agentId"].ToString();//代理商编号
            ttClientTakeCash.siteId= dr["siteId"].ToString();//门店编号
            ttClientTakeCash.lastBalance= double.Parse(dr["lastBalance"].ToString());//上次余额
            ttClientTakeCash.fee= double.Parse(dr["fee"].ToString());//发生金额
            ttClientTakeCash.balance= double.Parse(dr["balance"].ToString());//当前余额
            ttClientTakeCash.handleMode= dr["handleMode"].ToString();//提现方式
            ttClientTakeCash.operatorId= dr["operatorId"].ToString();//操作人编号
            ttClientTakeCash.operatorName= dr["operatorName"].ToString();//操作人名称
            if(dr["createTime"]==null)
            {
                ttClientTakeCash.createTime= "";//创建时间
            }
            else
            {
                ttClientTakeCash.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            ttClientTakeCash.cardId= dr["cardId"].ToString();//卡号
            ttClientTakeCash.sourceType= dr["sourceType"].ToString();//提现来源
            ttClientTakeCash.timeStamp= dr["timeStamp"].ToString();//时间戳
            ttClientTakeCash.description= dr["description"].ToString();//说明
            return ttClientTakeCash;
        }
        
        
        #endregion
        
    }
}

