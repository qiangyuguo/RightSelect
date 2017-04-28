using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Client;

namespace Com.ZY.JXKK.DAO.Client
{
    /// <summary>
    /// 客户充值
    /// Author:代码生成器
    /// </summary>
    public class TTClientRechargeDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接

        /// <summary>
        /// 获取客户充值总计
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>客户充值double</returns>
        public double GetTotalFee(string strSQL, Param param)
        {
            double totalFee;
            try
            {
                db.Open();
                totalFee =double.Parse(db.ExecuteScalar(CommandType.Text, strSQL, param).ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
           
            return totalFee;
        }

        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加客户充值
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientRecharge">客户充值</param>
        /// </summary>
        public void Add(DataAccess data,TTClientRecharge ttClientRecharge)
        {
            string strSQL = "insert into TTClientRecharge (flowId,clientId,clientName,agentId,siteId,lastBalance,fee,balance,handleMode,operatorId,operatorName,createTime,cardId,sourceType,timeStamp,description) values (:flowId,:clientId,:clientName,:agentId,:siteId,:lastBalance,:fee,:balance,:handleMode,:operatorId,:operatorName,To_date(:createTime,'yyyy-mm-dd hh24:mi:ss'),:cardId,:sourceType,:timeStamp,:description)";
            Param param = new Param();
            param.Clear();
            param.Add(":flowId", ttClientRecharge.flowId);//流水号
            param.Add(":clientId", ttClientRecharge.clientId);//客户编号
            param.Add(":clientName", ttClientRecharge.clientName);//客户名称
            param.Add(":agentId", ttClientRecharge.agentId);//代理商编号
            param.Add(":siteId", ttClientRecharge.siteId);//门店编号
            param.Add(":lastBalance", ttClientRecharge.lastBalance);//上次余额
            param.Add(":fee", ttClientRecharge.fee);//发生金额
            param.Add(":balance", ttClientRecharge.balance);//当前余额
            param.Add(":handleMode", ttClientRecharge.handleMode);//充值方式
            param.Add(":operatorId", ttClientRecharge.operatorId);//操作人编号
            param.Add(":operatorName", ttClientRecharge.operatorName);//操作人名称
            param.Add(":createTime", ttClientRecharge.createTime);//创建时间
            param.Add(":cardId", ttClientRecharge.cardId);//卡号
            param.Add(":sourceType", ttClientRecharge.sourceType);//充值来源
            param.Add(":timeStamp", ttClientRecharge.timeStamp);//时间戳
            param.Add(":description", ttClientRecharge.description);//说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加客户充值
        /// <param name="ttClientRecharge">客户充值</param>
        /// </summary>
        public void Add(TTClientRecharge ttClientRecharge)
        {
            try
            {
                db.Open();
                Add(db,ttClientRecharge);
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
        /// 修改客户充值
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientRecharge">客户充值</param>
        /// </summary>
        public void Edit(DataAccess data,TTClientRecharge ttClientRecharge)
        {
            string strSQL = "update TTClientRecharge set clientId=:clientId,clientName=:clientName,agentId=:agentId,siteId=:siteId,lastBalance=:lastBalance,fee=:fee,balance=:balance,handleMode=:handleMode,operatorId=:operatorId,operatorName=:operatorName,createTime=To_date(:createTime,'yyyy-mm-dd hh24:mi:ss'),cardId=:cardId,sourceType=:sourceType,timeStamp=:timeStamp,description=:description where flowId=:flowId";
            Param param = new Param();
            param.Clear();
            param.Add(":clientId", ttClientRecharge.clientId);//客户编号
            param.Add(":clientName", ttClientRecharge.clientName);//客户名称
            param.Add(":agentId", ttClientRecharge.agentId);//代理商编号
            param.Add(":siteId", ttClientRecharge.siteId);//门店编号
            param.Add(":lastBalance", ttClientRecharge.lastBalance);//上次余额
            param.Add(":fee", ttClientRecharge.fee);//发生金额
            param.Add(":balance", ttClientRecharge.balance);//当前余额
            param.Add(":handleMode", ttClientRecharge.handleMode);//充值方式
            param.Add(":operatorId", ttClientRecharge.operatorId);//操作人编号
            param.Add(":operatorName", ttClientRecharge.operatorName);//操作人名称
            param.Add(":createTime", ttClientRecharge.createTime);//创建时间
            param.Add(":cardId", ttClientRecharge.cardId);//卡号
            param.Add(":sourceType", ttClientRecharge.sourceType);//充值来源
            param.Add(":timeStamp", ttClientRecharge.timeStamp);//时间戳
            param.Add(":description", ttClientRecharge.description);//说明
            param.Add(":flowId", ttClientRecharge.flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改客户充值
        /// <param name="ttClientRecharge">客户充值</param>
        /// </summary>
        public void Edit(TTClientRecharge ttClientRecharge)
        {
            try
            {
                db.Open();
                Edit(db,ttClientRecharge);
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
        /// 删除客户充值
        /// <param name="data">数据库连接</param>
        /// <param name="flowId">流水号</param>
        /// </summary>
        public void Delete(DataAccess data,long flowId)
        {
            string strSQL = "delete from TTClientRecharge where flowId=:flowId";
            Param param = new Param();
            param.Clear();
            param.Add(":flowId", flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除客户充值
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
        /// 获取客户充值
        /// <param name="flowId">流水号</param>
        /// </summary>
        /// <returns>客户充值对象</returns>
        public TTClientRecharge Get(long flowId)
        {
            TTClientRecharge ttClientRecharge=null;
            try
            {
                string strSQL = "select * from TTClientRecharge where flowId=:flowId";
                Param param = new Param();
                param.Clear();
                param.Add(":flowId", flowId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttClientRecharge=ReadData(dr);
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
            return ttClientRecharge;
        }
        
        /// <summary>
        /// 获取列表(客户充值)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>客户充值列表对象</returns>
        public List<TTClientRecharge> GetList(string strSQL,Param param)
        {
            List<TTClientRecharge> list = new List<TTClientRecharge>();
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
        /// 获取列表(客户充值)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>客户充值列表对象</returns>
        public List<TTClientRecharge> GetList(string field, string value)
        {
            List<TTClientRecharge> list = new List<TTClientRecharge>();
            try
            {
                string strSQL = "select * from TTClientRecharge where " + field + "=:field";
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
        /// 获取DataSet(客户充值)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>客户充值DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTClientRecharge");
        }
        
        /// <summary>
        /// 是否存在记录(客户充值)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTClientRecharge where " + field + "=:field";
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
        /// 读取客户充值信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>客户充值对象</returns>
        private TTClientRecharge ReadData(ComDataReader dr)
        {
            TTClientRecharge ttClientRecharge= new TTClientRecharge();
            ttClientRecharge.flowId= long.Parse(dr["flowId"].ToString());//流水号
            ttClientRecharge.clientId= long.Parse(dr["clientId"].ToString());//客户编号
            ttClientRecharge.clientName= dr["clientName"].ToString();//客户名称
            ttClientRecharge.agentId= dr["agentId"].ToString();//代理商编号
            ttClientRecharge.siteId= dr["siteId"].ToString();//门店编号
            ttClientRecharge.lastBalance= double.Parse(dr["lastBalance"].ToString());//上次余额
            ttClientRecharge.fee= double.Parse(dr["fee"].ToString());//发生金额
            ttClientRecharge.balance= double.Parse(dr["balance"].ToString());//当前余额
            ttClientRecharge.handleMode= dr["handleMode"].ToString();//充值方式
            ttClientRecharge.operatorId= dr["operatorId"].ToString();//操作人编号
            ttClientRecharge.operatorName= dr["operatorName"].ToString();//操作人名称
            if(dr["createTime"]==null)
            {
                ttClientRecharge.createTime= "";//创建时间
            }
            else
            {
                ttClientRecharge.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            ttClientRecharge.cardId= dr["cardId"].ToString();//卡号
            ttClientRecharge.sourceType= dr["sourceType"].ToString();//充值来源
            ttClientRecharge.timeStamp= dr["timeStamp"].ToString();//时间戳
            ttClientRecharge.description= dr["description"].ToString();//说明
            return ttClientRecharge;
        }
        
        
        #endregion
        
    }
}

