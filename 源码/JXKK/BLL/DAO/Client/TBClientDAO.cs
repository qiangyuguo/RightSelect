using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Client;

namespace Com.ZY.JXKK.DAO.Client
{
    /// <summary>
    /// 客户信息
    /// Author:代码生成器
    /// </summary>
    public class TBClientDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加客户信息
        /// <param name="data">数据库连接</param>
        /// <param name="tbClient">客户信息</param>
        /// </summary>
        public void Add(DataAccess data,TBClient tbClient)
        {
            string strSQL = "insert into TBClient (clientId,agentId,siteId,balance,lockFee,status,points,sumRecharge,sumTakeCash,sumConsume,sumReturnAward,sumBigAward,createTime,operatorName,operatorId,cardId,clientName,IDNumber,telephone,password,refererCardId,remark) values (:clientId,:agentId,:siteId,:balance,:lockFee,:status,:points,:sumRecharge,:sumTakeCash,:sumConsume,:sumReturnAward,:sumBigAward,To_date(:createTime,'yyyy-mm-dd hh24:mi:ss'),:operatorName,:operatorId,:cardId,:clientName,:IDNumber,:telephone,:password,:refererCardId,:remark)";
            Param param = new Param();
            param.Clear();
            param.Add(":clientId", tbClient.clientId);//客户编号
            param.Add(":agentId", tbClient.agentId);//代理商编号
            param.Add(":siteId", tbClient.siteId);//快开厅编号
            param.Add(":balance", tbClient.balance);//账户余额
            param.Add(":lockFee", tbClient.lockFee);//冻结金额
            param.Add(":status", tbClient.status);//使用状态
            param.Add(":points", tbClient.points);//客户积分
            param.Add(":sumRecharge", tbClient.sumRecharge);//充值总额
            param.Add(":sumTakeCash", tbClient.sumTakeCash);//提现总额
            param.Add(":sumConsume", tbClient.sumConsume);//消费总额
            param.Add(":sumReturnAward", tbClient.sumReturnAward);//返奖总额
            param.Add(":sumBigAward", tbClient.sumBigAward);//大奖总额
            param.Add(":createTime", tbClient.createTime);//创建时间
            param.Add(":operatorName", tbClient.operatorName);//操作人名称
            param.Add(":operatorId", tbClient.operatorId);//操作人编号
            param.Add(":cardId", tbClient.cardId);//卡号
            param.Add(":clientName", tbClient.clientName);//姓名
            param.Add(":IDNumber", tbClient.IDNumber);//身份证号码
            param.Add(":telephone", tbClient.telephone);//手机号
            param.Add(":password", tbClient.password);//密码
            param.Add(":refererCardId", tbClient.refererCardId);//推荐人卡号
            param.Add(":remark", tbClient.remark);//备注说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加客户信息
        /// <param name="tbClient">客户信息</param>
        /// </summary>
        public void Add(TBClient tbClient)
        {
            try
            {
                db.Open();
                Add(db,tbClient);
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
        /// 修改客户信息
        /// <param name="data">数据库连接</param>
        /// <param name="tbClient">客户信息</param>
        /// </summary>
        public void Edit(DataAccess data,TBClient tbClient)
        {
            string strSQL = "update TBClient set agentId=:agentId,siteId=:siteId,balance=:balance,lockFee=:lockFee,status=:status,points=:points,sumRecharge=:sumRecharge,sumTakeCash=:sumTakeCash,sumConsume=:sumConsume,sumReturnAward=:sumReturnAward,sumBigAward=:sumBigAward,createTime=To_date(:createTime,'yyyy-mm-dd hh24:mi:ss'),operatorName=:operatorName,operatorId=:operatorId,cardId=:cardId,clientName=:clientName,IDNumber=:IDNumber,telephone=:telephone,password=:password,refererCardId=:refererCardId,remark=:remark where clientId=:clientId";
            Param param = new Param();
            param.Clear();
            param.Add(":agentId", tbClient.agentId);//代理商编号
            param.Add(":siteId", tbClient.siteId);//快开厅编号
            param.Add(":balance", tbClient.balance);//账户余额
            param.Add(":lockFee", tbClient.lockFee);//冻结金额
            param.Add(":status", tbClient.status);//使用状态
            param.Add(":points", tbClient.points);//客户积分
            param.Add(":sumRecharge", tbClient.sumRecharge);//充值总额
            param.Add(":sumTakeCash", tbClient.sumTakeCash);//提现总额
            param.Add(":sumConsume", tbClient.sumConsume);//消费总额
            param.Add(":sumReturnAward", tbClient.sumReturnAward);//返奖总额
            param.Add(":sumBigAward", tbClient.sumBigAward);//大奖总额
            param.Add(":createTime", tbClient.createTime);//创建时间
            param.Add(":operatorName", tbClient.operatorName);//操作人名称
            param.Add(":operatorId", tbClient.operatorId);//操作人编号
            param.Add(":cardId", tbClient.cardId);//卡号
            param.Add(":clientName", tbClient.clientName);//姓名
            param.Add(":IDNumber", tbClient.IDNumber);//身份证号码
            param.Add(":telephone", tbClient.telephone);//手机号
            param.Add(":password", tbClient.password);//密码
            param.Add(":refererCardId", tbClient.refererCardId);//推荐人卡号
            param.Add(":remark", tbClient.remark);//备注说明
            param.Add(":clientId", tbClient.clientId);//客户编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改客户信息
        /// <param name="tbClient">客户信息</param>
        /// </summary>
        public void Edit(TBClient tbClient)
        {
            try
            {
                db.Open();
                Edit(db,tbClient);
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
        /// 删除客户信息
        /// <param name="data">数据库连接</param>
        /// <param name="clientId">客户编号</param>
        /// </summary>
        public void Delete(DataAccess data,string clientId)
        {
            string strSQL = "delete from TBClient where clientId=:clientId";
            Param param = new Param();
            param.Clear();
            param.Add(":clientId", clientId);//客户编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除客户信息
        /// <param name="clientId">客户编号</param>
        /// </summary>
        public void Delete(string clientId)
        {
            try
            {
                db.Open();
                Delete(db,clientId);
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
        /// 获取客户信息
        /// <param name="clientId">客户编号</param>
        /// </summary>
        /// <returns>客户信息对象</returns>
        public TBClient Get(string clientId)
        {
            TBClient tbClient=null;
            try
            {
                string strSQL = "select * from TBClient where clientId=:clientId";
                Param param = new Param();
                param.Clear();
                param.Add(":clientId", clientId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbClient=ReadData(dr);
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
            return tbClient;
        }
        
        /// <summary>
        /// 获取列表(客户信息)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>客户信息列表对象</returns>
        public List<TBClient> GetList(string strSQL,Param param)
        {
            List<TBClient> list = new List<TBClient>();
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
        /// 获取列表(客户信息)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>客户信息列表对象</returns>
        public List<TBClient> GetList(string field, string value)
        {
            List<TBClient> list = new List<TBClient>();
            try
            {
                string strSQL = "select * from TBClient where " + field + "=:field";
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
        /// 获取DataSet(客户信息)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>客户信息DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBClient");
        }
        
        /// <summary>
        /// 是否存在记录(客户信息)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBClient where " + field + "=:field";
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
        /// 读取客户信息信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>客户信息对象</returns>
        private TBClient ReadData(ComDataReader dr)
        {
            TBClient tbClient= new TBClient();
            tbClient.clientId= long.Parse(dr["clientId"].ToString());//客户编号
            tbClient.agentId= dr["agentId"].ToString();//代理商编号
            tbClient.siteId= dr["siteId"].ToString();//快开厅编号
            tbClient.balance= double.Parse(dr["balance"].ToString());//账户余额
            tbClient.lockFee= double.Parse(dr["lockFee"].ToString());//冻结金额
            tbClient.status= dr["status"].ToString();//使用状态
            tbClient.points= long.Parse(dr["points"].ToString());//客户积分
            tbClient.sumRecharge= double.Parse(dr["sumRecharge"].ToString());//充值总额
            tbClient.sumTakeCash= double.Parse(dr["sumTakeCash"].ToString());//提现总额
            tbClient.sumConsume= double.Parse(dr["sumConsume"].ToString());//消费总额
            tbClient.sumReturnAward= double.Parse(dr["sumReturnAward"].ToString());//返奖总额
            tbClient.sumBigAward= double.Parse(dr["sumBigAward"].ToString());//大奖总额
            if(dr["createTime"]==null)
            {
                tbClient.createTime= "";//创建时间
            }
            else
            {
                tbClient.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            tbClient.operatorName= dr["operatorName"].ToString();//操作人名称
            tbClient.operatorId= dr["operatorId"].ToString();//操作人编号
            tbClient.cardId= dr["cardId"].ToString();//卡号
            tbClient.clientName= dr["clientName"].ToString();//姓名
            tbClient.IDNumber= dr["IDNumber"].ToString();//身份证号码
            tbClient.telephone= dr["telephone"].ToString();//手机号
            tbClient.password= dr["password"].ToString();//密码
            tbClient.refererCardId= dr["refererCardId"].ToString();//推荐人卡号
            tbClient.remark= dr["remark"].ToString();//备注说明
            return tbClient;
        }
        
        
        #endregion
        
    }
}

