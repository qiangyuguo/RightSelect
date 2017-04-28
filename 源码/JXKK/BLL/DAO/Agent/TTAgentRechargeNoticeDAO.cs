using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Agent;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理商充值提醒
    /// Author:代码生成器
    /// </summary>
    public class TTAgentRechargeNoticeDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加代理商充值提醒
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentRechargeNotice">代理商充值提醒</param>
        /// </summary>
        public void Add(DataAccess data,TTAgentRechargeNotice ttAgentRechargeNotice)
        {
            string strSQL = "insert into TTAgentRechargeNotice (flowId,agentId,agentName,fee,bankAccountId,dealWithStatus,transferAccDate,remark) values (SAgentRechargeNotice_flowId.Nextval,:agentId,:agentName,:fee,:bankAccountId,:dealWithStatus,To_date(:transferAccDate,'yyyy-mm-dd hh24:mi:ss'),:remark)";
            Param param = new Param();
            param.Clear();
            param.Add(":agentId", ttAgentRechargeNotice.agentId);//代理商编号
            param.Add(":agentName", ttAgentRechargeNotice.agentName);//代理商名称
            param.Add(":fee", ttAgentRechargeNotice.fee);//提现金额
            param.Add(":bankAccountId", ttAgentRechargeNotice.bankAccountId);//银行账号
            param.Add(":dealWithStatus", ttAgentRechargeNotice.dealWithStatus);//办理状态
            param.Add(":transferAccDate", ttAgentRechargeNotice.transferAccDate);//转账日期
            param.Add(":remark", ttAgentRechargeNotice.remark);//提现说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加代理商充值提醒
        /// <param name="ttAgentRechargeNotice">代理商充值提醒</param>
        /// </summary>
        public void Add(TTAgentRechargeNotice ttAgentRechargeNotice)
        {
            try
            {
                db.Open();
                Add(db,ttAgentRechargeNotice);
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
        /// 修改代理商充值提醒
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentRechargeNotice">代理商充值提醒</param>
        /// </summary>
        public void Edit(DataAccess data,TTAgentRechargeNotice ttAgentRechargeNotice)
        {
            string strSQL = "update TTAgentRechargeNotice set dealWithStatus=:dealWithStatus,operatorId=:operatorId,operatorName=:operatorName,dealWithTime=To_date(:dealWithTime,'yyyy-mm-dd hh24:mi:ss'),opinion=:opinion where flowId=:flowId";
            Param param = new Param();
            param.Clear();
            param.Add(":dealWithStatus", ttAgentRechargeNotice.dealWithStatus);//办理状态
            param.Add(":operatorId", ttAgentRechargeNotice.operatorId);//办理人编号
            param.Add(":operatorName", ttAgentRechargeNotice.operatorName);//办理人名称
            param.Add(":dealWithTime", ttAgentRechargeNotice.dealWithTime);//办理时间
            param.Add(":opinion", ttAgentRechargeNotice.opinion);//办理意见
            param.Add(":flowId", ttAgentRechargeNotice.flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改代理商充值提醒
        /// <param name="ttAgentRechargeNotice">代理商充值提醒</param>
        /// </summary>
        public void Edit(TTAgentRechargeNotice ttAgentRechargeNotice)
        {
            try
            {
                db.Open();
                Edit(db,ttAgentRechargeNotice);
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
        /// 删除代理商充值提醒
        /// <param name="data">数据库连接</param>
        /// <param name="flowId">流水号</param>
        /// </summary>
        public void Delete(DataAccess data,long flowId)
        {
            string strSQL = "delete from TTAgentRechargeNotice where flowId=:flowId";
            Param param = new Param();
            param.Clear();
            param.Add(":flowId", flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除代理商充值提醒
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
        /// 获取代理商充值提醒
        /// <param name="flowId">流水号</param>
        /// </summary>
        /// <returns>代理商充值提醒对象</returns>
        public TTAgentRechargeNotice Get(long flowId)
        {
            TTAgentRechargeNotice ttAgentRechargeNotice=null;
            try
            {
                string strSQL = "select * from TTAgentRechargeNotice where flowId=:flowId";
                Param param = new Param();
                param.Clear();
                param.Add(":flowId", flowId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttAgentRechargeNotice=ReadData(dr);
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
            return ttAgentRechargeNotice;
        }
        
        /// <summary>
        /// 获取列表(代理商充值提醒)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理商充值提醒列表对象</returns>
        public List<TTAgentRechargeNotice> GetList(string strSQL,Param param)
        {
            List<TTAgentRechargeNotice> list = new List<TTAgentRechargeNotice>();
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
        /// 获取列表(代理商充值提醒)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>代理商充值提醒列表对象</returns>
        public List<TTAgentRechargeNotice> GetList(string field, string value)
        {
            List<TTAgentRechargeNotice> list = new List<TTAgentRechargeNotice>();
            try
            {
                string strSQL = "select * from TTAgentRechargeNotice where " + field + "=:field";
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
        /// 获取DataSet(代理商充值提醒)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理商充值提醒DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTAgentRechargeNotice");
        }
        
        /// <summary>
        /// 是否存在记录(代理商充值提醒)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTAgentRechargeNotice where " + field + "=:field";
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
        /// 读取代理商充值提醒信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>代理商充值提醒对象</returns>
        private TTAgentRechargeNotice ReadData(ComDataReader dr)
        {
            TTAgentRechargeNotice ttAgentRechargeNotice= new TTAgentRechargeNotice();
            ttAgentRechargeNotice.flowId= long.Parse(dr["flowId"].ToString());//流水号
            ttAgentRechargeNotice.agentId= dr["agentId"].ToString();//代理商编号
            ttAgentRechargeNotice.agentName= dr["agentName"].ToString();//代理商名称
            ttAgentRechargeNotice.fee= double.Parse(dr["fee"].ToString());//充值金额
            ttAgentRechargeNotice.bankAccountId= dr["bankAccountId"].ToString();//银行账号
            if(dr["transferAccDate"]==null)
            {
                ttAgentRechargeNotice.transferAccDate= "";//转账日期
            }
            else
            {
                ttAgentRechargeNotice.transferAccDate= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["transferAccDate"]);//转账日期
            }
            ttAgentRechargeNotice.remark= dr["remark"].ToString();//充值说明
            if(dr["createTime"]==null)
            {
                ttAgentRechargeNotice.createTime= "";//创建时间
            }
            else
            {
                ttAgentRechargeNotice.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            ttAgentRechargeNotice.dealWithStatus= dr["dealWithStatus"].ToString();//办理状态
            ttAgentRechargeNotice.operatorId= dr["operatorId"].ToString();//办理人编号
            ttAgentRechargeNotice.operatorName= dr["operatorName"].ToString();//办理人名称
            if(dr["dealWithTime"]==null)
            {
                ttAgentRechargeNotice.dealWithTime= "";//办理时间
            }
            else
            {
                ttAgentRechargeNotice.dealWithTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["dealWithTime"]);//办理时间
            }
            ttAgentRechargeNotice.opinion= dr["opinion"].ToString();//办理意见
            return ttAgentRechargeNotice;
        }
        
        
        #endregion
        
    }
}

