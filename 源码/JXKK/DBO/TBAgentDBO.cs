using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 代理商信息
    /// Author:代码生成器
    /// </summary>
    public class TBAgentDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加代理商信息
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbAgent">代理商信息</param>
        public virtual void Add(DataAccess data,TBAgent tbAgent)
        {
            string strSQL = "insert into TBAgent (agentId,agentName,rebate,contact,telephone,areaId,address,IDNumber,bankName,bankCardId,auditStatus,clientSumDraw,clientSumRecharge,sumDraw,sumRecharge,warnValue,balanceValue,status,fixedLine,remark) values (@agentId,@agentName,@rebate,@contact,@telephone,@areaId,@address,@IDNumber,@bankName,@bankCardId,@auditStatus,@clientSumDraw,@clientSumRecharge,@sumDraw,@sumRecharge,@warnValue,@balanceValue,@status,@fixedLine,@remark)";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", tbAgent.agentId);//代理商编号
            param.Add("@agentName", tbAgent.agentName);//代理商名称
            param.Add("@rebate", tbAgent.rebate);//返点比例
            param.Add("@contact", tbAgent.contact);//联系人
            param.Add("@telephone", tbAgent.telephone);//手机号码
            param.Add("@areaId", tbAgent.areaId);//区域编号
            param.Add("@address", tbAgent.address);//详细地址
            param.Add("@IDNumber", tbAgent.IDNumber);//身份证号
            param.Add("@bankName", tbAgent.bankName);//开户银行
            param.Add("@bankCardId", tbAgent.bankCardId);//银行卡号
            param.Add("@auditStatus", tbAgent.auditStatus);//审批状态
            param.Add("@clientSumDraw", tbAgent.clientSumDraw);//客户提现总额
            param.Add("@clientSumRecharge", tbAgent.clientSumRecharge);//客户充值总额
            param.Add("@sumDraw", tbAgent.sumDraw);//提现总额
            param.Add("@sumRecharge", tbAgent.sumRecharge);//充值总额
            param.Add("@warnValue", tbAgent.warnValue);//预警金额
            param.Add("@balanceValue", tbAgent.balanceValue);//账户余额
            param.Add("@status", tbAgent.status);//使用状态
            param.Add("@fixedLine", tbAgent.fixedLine);//固定电话
            param.Add("@remark", tbAgent.remark);//备注说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加代理商信息
        /// </summary>
        /// <param name="tbAgent">代理商信息</param>
        public virtual void Add(TBAgent tbAgent)
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
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbAgent">代理商信息</param>
        public virtual void Edit(DataAccess data,TBAgent tbAgent)
        {
            string strSQL = "update TBAgent set agentName=@agentName,rebate=@rebate,contact=@contact,telephone=@telephone,areaId=@areaId,address=@address,IDNumber=@IDNumber,bankName=@bankName,bankCardId=@bankCardId,auditStatus=@auditStatus,clientSumDraw=@clientSumDraw,clientSumRecharge=@clientSumRecharge,sumDraw=@sumDraw,sumRecharge=@sumRecharge,warnValue=@warnValue,balanceValue=@balanceValue,status=@status,fixedLine=@fixedLine,remark=@remark where agentId=@agentId";
            Param param = new Param();
            param.Clear();
            param.Add("@agentName", tbAgent.agentName);//代理商名称
            param.Add("@rebate", tbAgent.rebate);//返点比例
            param.Add("@contact", tbAgent.contact);//联系人
            param.Add("@telephone", tbAgent.telephone);//手机号码
            param.Add("@areaId", tbAgent.areaId);//区域编号
            param.Add("@address", tbAgent.address);//详细地址
            param.Add("@IDNumber", tbAgent.IDNumber);//身份证号
            param.Add("@bankName", tbAgent.bankName);//开户银行
            param.Add("@bankCardId", tbAgent.bankCardId);//银行卡号
            param.Add("@auditStatus", tbAgent.auditStatus);//审批状态
            param.Add("@clientSumDraw", tbAgent.clientSumDraw);//客户提现总额
            param.Add("@clientSumRecharge", tbAgent.clientSumRecharge);//客户充值总额
            param.Add("@sumDraw", tbAgent.sumDraw);//提现总额
            param.Add("@sumRecharge", tbAgent.sumRecharge);//充值总额
            param.Add("@warnValue", tbAgent.warnValue);//预警金额
            param.Add("@balanceValue", tbAgent.balanceValue);//账户余额
            param.Add("@status", tbAgent.status);//使用状态
            param.Add("@fixedLine", tbAgent.fixedLine);//固定电话
            param.Add("@remark", tbAgent.remark);//备注说明
            param.Add("@agentId", tbAgent.agentId);//代理商编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改代理商信息
        /// </summary>
        /// <param name="tbAgent">代理商信息</param>
        public virtual void Edit(TBAgent tbAgent)
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
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="agentId">代理商编号</param>
        public virtual void Delete(DataAccess data,string agentId)
        {
            string strSQL = "delete from TBAgent where agentId=@agentId";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", agentId);//代理商编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除代理商信息
        /// </summary>
        /// <param name="agentId">代理商编号</param>
        public virtual void Delete(string agentId)
        {
            try
            {
                db.Open();
                Delete(db,agentId);
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
        /// 获取代理商信息
        /// </summary>
        /// <param name="agentId">代理商编号</param>
        /// <returns>代理商信息对象</returns>
        public virtual TBAgent Get(string agentId)
        {
            TBAgent tbAgent=null;
            try
            {
                string strSQL = "select * from TBAgent where agentId=@agentId";
                Param param = new Param();
                param.Clear();
                param.Add("@agentId", agentId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbAgent=ReadData(dr);
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
            return tbAgent;
        }
        
        /// <summary>
        /// 获取列表(代理商信息)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理商信息列表对象</returns>
        public virtual List<TBAgent> GetList(string strSQL,Param param)
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
        /// 获取列表(代理商信息)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>代理商信息列表对象</returns>
        public virtual List<TBAgent> GetList(string field, string value)
        {
            List<TBAgent> list = new List<TBAgent>();
            try
            {
                string strSQL = "select * from TBAgent where " + field + "=@field";
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
        /// 获取DataSet(代理商信息)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理商信息DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBAgent");
        }
        
        /// <summary>
        /// 是否存在记录(代理商信息)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBAgent where " + field + "=@field";
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
        /// 读取代理商信息信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>代理商信息对象</returns>
        protected virtual TBAgent ReadData(ComDataReader dr)
        {
            TBAgent tbAgent= new TBAgent();
            tbAgent.agentId= dr["agentId"].ToString();//代理商编号
            tbAgent.agentName= dr["agentName"].ToString();//代理商名称
            tbAgent.rebate= double.Parse(dr["rebate"].ToString());//返点比例
            tbAgent.contact= dr["contact"].ToString();//联系人
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
        
        
        #endregion
        
    }
}

