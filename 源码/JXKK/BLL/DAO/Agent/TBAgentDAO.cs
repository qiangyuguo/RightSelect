using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Agent;
using Com.ZY.JXKK.Util;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理商信息
    /// Author:代码生成器
    /// </summary>
    public class TBAgentDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接

        #region 新增代码


        /// <summary>
        /// 事务增加代理商信息并添加代理商用户
        /// <param name="tbAgent">代理商信息</param>
        /// <param name="tbAgent">代理商用户信息</param>
        /// </summary>
        public void AddTrans(TBAgent tbAgent, TSAgentUser tsAgentUser)
        {
            ComTransaction trans = null;
            try
            {
                db.Open();
                trans = db.BeginTransaction();
                Add(db, tbAgent);
                tsAgentUser.userId = tbAgent.agentId;
                tsAgentUser.userPwd = Encrypt.ConvertPwd(tsAgentUser.userId, tsAgentUser.userPwd);
                new TSAgentUserDAO().Add(db,tsAgentUser);
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
        /// <summary>
        /// 增加代理商信息
        /// <param name="data">数据库连接</param>
        /// <param name="tbAgent">代理商信息</param>
        /// </summary>
        public void Add(DataAccess data, TBAgent tbAgent)
        {
            //添加系统用户信息记录
            string strSQL = "insert into TBAgent";
            strSQL += "(agentId, agentName,rebate,warnValue, contact, telephone, areaId, address,IDNumber,bankCardId,bankName,status,fixedLine,remark) values ";
            strSQL += "(:agentId,:agentName,:rebate,:warnValue, :contact, :telephone, :areaId, :address,:IDNumber,:bankCardId,:bankName,:status,:fixedLine,:remark)";
            Param param = new Param();
            param.Clear();
            param.Add(":agentId", tbAgent.agentId);
            param.Add(":agentName", tbAgent.agentName);
            param.Add(":rebate", tbAgent.rebate);
            param.Add(":warnValue", tbAgent.warnValue);
            param.Add(":contact", tbAgent.contact);
            param.Add(":telephone", tbAgent.telephone);
            param.Add(":areaId", tbAgent.areaId);
            param.Add(":address", tbAgent.address);
            param.Add(":IDNumber", tbAgent.IDNumber);
            param.Add(":bankCardId", tbAgent.bankCardId);
            param.Add(":bankName", tbAgent.bankName);
            param.Add(":warnValue", tbAgent.warnValue);
            param.Add(":status", "0");
            param.Add(":fixedLine", tbAgent.fixedLine);
            param.Add(":remark", tbAgent.remark);
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 修改代理商信息
        /// <param name="data">数据库连接</param>
        /// <param name="tbAgent">代理商信息</param>
        /// </summary>
        public void Edit(DataAccess data, TBAgent tbAgent)
        {
            string strSQL = "update TBAgent set agentName=:agentName,rebate=:rebate, contact=:contact, telephone=:telephone, areaId=:areaId, address=:address,IDNumber=:IDNumber, ";
            strSQL += " bankCardId=:bankCardId,bankName=:bankName,warnValue=:warnValue,status=:status,auditStatus=:auditStatus,fixedLine=:fixedLine,remark=:remark where agentId =:agentId";
            Param param = new Param();
            param.Clear();
            param.Add(":agentId", tbAgent.agentId);
            param.Add(":agentName", tbAgent.agentName);
            param.Add(":rebate", tbAgent.rebate);
            param.Add(":contact", tbAgent.contact);
            param.Add(":telephone", tbAgent.telephone);
            param.Add(":areaId", tbAgent.areaId);
            param.Add(":address", tbAgent.address);
            param.Add(":IDNumber", tbAgent.IDNumber);
            param.Add(":bankCardId", tbAgent.bankCardId);
            param.Add(":bankName", tbAgent.bankName);
            param.Add(":warnValue", tbAgent.warnValue);
            param.Add(":status", tbAgent.status);
            param.Add(":auditStatus", tbAgent.auditStatus);
            param.Add(":fixedLine", tbAgent.fixedLine);
            param.Add(":remark", tbAgent.remark);
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        /// <summary>
        /// 审核修改审核状态
        /// </summary>
        /// <param name="tbAgent"></param>
        public void Audit(TBAgent tbAgent)
        {
            string strSQL = "update TBAgent set auditStatus=:auditStatus,remark=:remark,status=:status where agentId =:agentId";
            Param param = new Param();
            param.Clear();
            param.Add(":agentId", tbAgent.agentId);
            param.Add(":auditStatus", tbAgent.auditStatus);
            param.Add(":status", tbAgent.status);
            param.Add(":remark", tbAgent.remark);
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
        /// 修改余额以及充值总额
        /// </summary>
        /// <param name="tbAgent"></param>
        public void EditBalance(DataAccess data,TBAgent tbAgent)
        {
            string strSQL = "update TBAgent set balanceValue=:balanceValue,sumRecharge=:sumRecharge,sumDraw=:sumDraw where agentId =:agentId";
            Param param = new Param();
            param.Clear();
            param.Add(":agentId", tbAgent.agentId);
            param.Add(":balanceValue", tbAgent.balanceValue);
            param.Add(":sumRecharge", tbAgent.sumRecharge);
            param.Add(":sumDraw", tbAgent.sumDraw);
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 删除代理商信息
        /// <param name="agentId">代理商编号</param>
        /// </summary>
        public void Delete(string agentId)
        {
            ComTransaction trans = null;
            try
            {
                db.Open();
                trans = db.BeginTransaction();
                new TSAgentUserDAO().Delete(db,agentId, "001");
                Delete(db, agentId);
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
        #endregion
        
        #region 代码生成器自动生成
        
 
        
        /// <summary>
        /// 增加代理商信息
        /// <param name="tbAgent">代理商信息</param>
        /// </summary>
        public void Add(TBAgent tbAgent)
        {
            try
            {
                db.Open();
                Add(db,tbAgent);
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
        /// 修改代理商信息
        /// <param name="tbAgent">代理商信息</param>
        /// </summary>
        public void Edit(TBAgent tbAgent)
        {
            try
            {
                db.Open();
                Edit(db,tbAgent);
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
        /// 删除代理商信息
        /// <param name="data">数据库连接</param>
        /// <param name="agentId">代理商编号</param>
        /// </summary>
        public void Delete(DataAccess data,string agentId)
        {
            string strSQL = "delete from TBAgent where agentId=:agentId";
            Param param = new Param();
            param.Clear();
            param.Add(":agentId", agentId);//代理商编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        public TBAgentClon Get(DataAccess data, string agentId)
        {
            TBAgentClon tbAgent = null;
            string strSQL = "select a.*,t.usercode from TBAgent a,TSAgentUser t where a.agentid=t.userid and t.roleid='001' and agentId=:agentId";
            Param param = new Param();
            param.Clear();
            param.Add(":agentId", agentId);
            ComDataReader dr = data.ExecuteReader(CommandType.Text, strSQL, param);
            if (dr.Read())
            {
                tbAgent = ReadDataClon(dr);
            }
            return tbAgent;
        }
        /// <summary>
        /// 获取代理商信息
        /// <param name="agentId">代理商编号</param>
        /// </summary>
        /// <returns>代理商信息对象</returns>
        public TBAgentClon Get(string agentId)
        {
            TBAgentClon tbAgent = null;
            try
            {
                
                db.Open();
                tbAgent = Get(db, agentId);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
            return tbAgent;
        }
        
        /// <summary>
        /// 获取列表(代理商信息)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理商信息列表对象</returns>
        public List<TBAgent> GetList(string strSQL,Param param)
        {
            List<TBAgent> list = new List<TBAgent>();
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
        /// 获取列表(代理商信息)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>代理商信息列表对象</returns>
        public List<TBAgent> GetList(string field, string value)
        {
            List<TBAgent> list = new List<TBAgent>();
            try
            {
                string strSQL = "select * from TBAgent where " + field + "=:field";
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
        /// 获取DataSet(代理商信息)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理商信息DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBAgent");
        }
        
        /// <summary>
        /// 是否存在记录(代理商信息)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBAgent where " + field + "=:field";
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
        /// 读取代理商信息信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>代理商信息对象</returns>
        private TBAgentClon ReadDataClon(ComDataReader dr)
        {
            TBAgentClon tbAgent = new TBAgentClon();
            tbAgent.agentId= dr["agentId"].ToString();//代理商编号
            tbAgent.agentName= dr["agentName"].ToString();//代理商名称
            tbAgent.rebate= double.Parse(dr["rebate"].ToString());//返点比例
            tbAgent.contact= dr["contact"].ToString();//联系人
            tbAgent.agentUserCode = dr["userCode"].ToString();//用户帐号
            tbAgent.telephone= dr["telephone"].ToString();//手机号码
            tbAgent.areaId= dr["areaId"].ToString();//区域编号
            tbAgent.address= dr["address"].ToString();//详细地址
            tbAgent.IDNumber= dr["IDNumber"].ToString();//身份证号
            tbAgent.bankName= dr["bankName"].ToString();//开户银行
            tbAgent.bankCardId= dr["bankCardId"].ToString();//银行卡号
            tbAgent.auditStatus= dr["auditStatus"].ToString();//审批状态
            tbAgent.clientSumDraw= double.Parse(dr["clientSumDraw"].ToString());//客户提现总额
            tbAgent.clientSumRecharge= double.Parse(dr["clientSumRecharge"].ToString());//客户充值总额
            tbAgent.sumDraw= double.Parse(dr["sumDraw"].ToString());//提现总额
            tbAgent.sumRecharge= double.Parse(dr["sumRecharge"].ToString());//充值总额
            tbAgent.warnValue= double.Parse(dr["warnValue"].ToString());//预警金额
            tbAgent.balanceValue= double.Parse(dr["balanceValue"].ToString());//账户余额
            tbAgent.status= dr["status"].ToString();//使用状态
            tbAgent.fixedLine= dr["fixedLine"].ToString();//固定电话
            tbAgent.remark= dr["remark"].ToString();//备注说明
            return tbAgent;
        }

        /// <summary>
        /// 读取代理商信息信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>代理商信息对象</returns>
        private TBAgent ReadData(ComDataReader dr)
        {
            TBAgent tbAgent = new TBAgent();
            tbAgent.agentId = dr["agentId"].ToString();//代理商编号
            tbAgent.agentName = dr["agentName"].ToString();//代理商名称
            tbAgent.rebate = double.Parse(dr["rebate"].ToString());//返点比例
            tbAgent.contact = dr["contact"].ToString();//联系人
            tbAgent.telephone = dr["telephone"].ToString();//手机号码
            tbAgent.areaId = dr["areaId"].ToString();//区域编号
            tbAgent.address = dr["address"].ToString();//详细地址
            tbAgent.IDNumber = dr["IDNumber"].ToString();//身份证号
            tbAgent.bankName = dr["bankName"].ToString();//开户银行
            tbAgent.bankCardId = dr["bankCardId"].ToString();//银行卡号
            tbAgent.auditStatus = dr["auditStatus"].ToString();//审批状态
            tbAgent.clientSumDraw = double.Parse(dr["clientSumDraw"].ToString());//客户提现总额
            tbAgent.clientSumRecharge = double.Parse(dr["clientSumRecharge"].ToString());//客户充值总额
            tbAgent.sumDraw = double.Parse(dr["sumDraw"].ToString());//提现总额
            tbAgent.sumRecharge = double.Parse(dr["sumRecharge"].ToString());//充值总额
            tbAgent.warnValue = double.Parse(dr["warnValue"].ToString());//预警金额
            tbAgent.balanceValue = double.Parse(dr["balanceValue"].ToString());//账户余额
            tbAgent.status = dr["status"].ToString();//使用状态
            tbAgent.fixedLine = dr["fixedLine"].ToString();//固定电话
            tbAgent.remark = dr["remark"].ToString();//备注说明
            return tbAgent;
        }
        #endregion


    }
}

