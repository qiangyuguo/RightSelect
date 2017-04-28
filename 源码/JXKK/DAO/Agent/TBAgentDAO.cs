using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;
using Com.ZY.JXKK.Util;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理商信息
    /// Author:开发人员自行扩展
    /// </summary>
    public class TBAgentDAO:TBAgentDBO
    {
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
                new TSAgentUserDAO().Add(db, tsAgentUser);
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
        /// 审核修改审核状态
        /// </summary>
        /// <param name="tbAgent"></param>
        public void Audit(TBAgent tbAgent)
        {
            string strSQL = "update TBAgent set auditStatus=@auditStatus,remark=@remark,status=@status where agentId =@agentId";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", tbAgent.agentId);
            param.Add("@auditStatus", tbAgent.auditStatus);
            param.Add("@status", tbAgent.status);
            param.Add("@remark", tbAgent.remark);
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
        public void EditBalance(DataAccess data, TBAgent tbAgent)
        {
            string strSQL = "update TBAgent set balanceValue=@balanceValue,sumRecharge=@sumRecharge,sumDraw=@sumDraw where agentId =@agentId";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", tbAgent.agentId);
            param.Add("@balanceValue", tbAgent.balanceValue);
            param.Add("@sumRecharge", tbAgent.sumRecharge);
            param.Add("@sumDraw", tbAgent.sumDraw);
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 读取代理商信息信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>代理商信息对象</returns>
        private TBAgentClon ReadDataClon(ComDataReader dr)
        {
            TBAgentClon tbAgent = new TBAgentClon();
            tbAgent.agentId = dr["agentId"].ToString();//代理商编号
            tbAgent.agentName = dr["agentName"].ToString();//代理商名称
            tbAgent.rebate = double.Parse(dr["rebate"].ToString());//返点比例
            tbAgent.contact = dr["contact"].ToString();//联系人
            tbAgent.agentUserCode = dr["userCode"].ToString();//用户帐号
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

        public TBAgentClon Get(DataAccess data, string agentId)
        {
            TBAgentClon tbAgent = null;
            string strSQL = "select a.*,t.usercode from TBAgent a,TSAgentUser t where a.agentid=t.userid and t.roleid='001' and agentId=@agentId";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", agentId);
            ComDataReader dr = data.ExecuteReader(CommandType.Text, strSQL, param);
            if (dr.Read())
            {
                tbAgent = ReadDataClon(dr);
            }
            dr.Close();
            return tbAgent;
        }

        /// <summary>
        /// 获取代理商信息
        /// <param name="agentId">代理商编号</param>
        /// </summary>
        /// <returns>代理商信息对象</returns>
        public TBAgentClon GetClon(string agentId)
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
        /// 增加代理商信息
        /// <param name="data">数据库连接</param>
        /// <param name="tbAgent">代理商信息</param>
        /// </summary>
        public override void Add(DataAccess data, TBAgent tbAgent)
        {
            //添加系统用户信息记录
            string strSQL = "insert into TBAgent";
            strSQL += "(agentId, agentName,rebate,warnValue, contact, telephone, areaId, address,IDNumber,bankCardId,bankName,status,fixedLine,remark) values ";
            strSQL += "(@agentId,@agentName,@rebate,@warnValue, :contact, :telephone, :areaId, :address,@IDNumber,@bankCardId,@bankName,@status,@fixedLine,@remark)";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", tbAgent.agentId);
            param.Add("@agentName", tbAgent.agentName);
            param.Add("@rebate", tbAgent.rebate);
            param.Add("@warnValue", tbAgent.warnValue);
            param.Add("@contact", tbAgent.contact);
            param.Add("@telephone", tbAgent.telephone);
            param.Add("@areaId", tbAgent.areaId);
            param.Add("@address", tbAgent.address);
            param.Add("@IDNumber", tbAgent.IDNumber);
            param.Add("@bankCardId", tbAgent.bankCardId);
            param.Add("@bankName", tbAgent.bankName);
            param.Add("@warnValue", tbAgent.warnValue);
            param.Add("@status", "0");
            param.Add("@fixedLine", tbAgent.fixedLine);
            param.Add("@remark", tbAgent.remark);
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 修改代理商信息
        /// <param name="data">数据库连接</param>
        /// <param name="tbAgent">代理商信息</param>
        /// </summary>
        public override void Edit(DataAccess data, TBAgent tbAgent)
        {
            string strSQL = "update TBAgent set agentName=@agentName,rebate=@rebate, contact=@contact, telephone=@telephone, areaId=@areaId, address=@address,IDNumber=@IDNumber, ";
            strSQL += " bankCardId=@bankCardId,bankName=@bankName,warnValue=@warnValue,status=@status,auditStatus=@auditStatus,fixedLine=@fixedLine,remark=@remark where agentId =@agentId";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", tbAgent.agentId);
            param.Add("@agentName", tbAgent.agentName);
            param.Add("@rebate", tbAgent.rebate);
            param.Add("@contact", tbAgent.contact);
            param.Add("@telephone", tbAgent.telephone);
            param.Add("@areaId", tbAgent.areaId);
            param.Add("@address", tbAgent.address);
            param.Add("@IDNumber", tbAgent.IDNumber);
            param.Add("@bankCardId", tbAgent.bankCardId);
            param.Add("@bankName", tbAgent.bankName);
            param.Add("@warnValue", tbAgent.warnValue);
            param.Add("@status", tbAgent.status);
            param.Add("@auditStatus", tbAgent.auditStatus);
            param.Add("@fixedLine", tbAgent.fixedLine);
            param.Add("@remark", tbAgent.remark);
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 删除代理商信息
        /// <param name="agentId">代理商编号</param>
        /// </summary>
        public override void Delete(string agentId)
        {
            ComTransaction trans = null;
            try
            {
                db.Open();
                trans = db.BeginTransaction();
                new TSAgentUserDAO().Delete(db, agentId, "001");
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
        /// <summary>
        /// 获取代理商的预存款余额
        /// </summary>
        /// <param name="agentId"></param>
        /// <param name="siteId"></param>
        /// <param name="city"></param>
        /// <param name="county"></param>
        /// <returns></returns>
        public double GetAdvanceBalance(string agentId, string siteId, string city, string county)
        {
            double advanceBalance = 0;
            string strSQL = @"select sum(t.balancevalue) from (select distinct a.agentid,a.balancevalue from TBSite s,TBAgent a where s.agentId=a.agentId ";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and a.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and s.siteId='" + siteId + "'";
            if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(county))
                strSQL += " and a.areaId='" + city + "'";
            if (!string.IsNullOrEmpty(county))
                strSQL += " and a.areaId='" + county + "'";
            strSQL += " ) t";
            try
            {
                db.Open();
                Param param = new Param();
                object obj = db.ExecuteScalar(CommandType.Text, strSQL, param);
                if (obj == DBNull.Value)
                {
                    advanceBalance = 0;
                }
                else
                {
                    advanceBalance = double.Parse(obj.ToString());
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
            return advanceBalance;
        }
    }
}

