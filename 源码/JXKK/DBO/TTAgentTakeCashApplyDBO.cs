using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 代理商提现申请
    /// Author:代码生成器
    /// </summary>
    public class TTAgentTakeCashApplyDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加代理商提现申请
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentTakeCashApply">代理商提现申请</param>
        public virtual void Add(DataAccess data,TTAgentTakeCashApply ttAgentTakeCashApply)
        {
            string strSQL = "insert into TTAgentTakeCashApply (flowId,agentId,agentName,fee,bankAccountId,remark,createTime,dealWithStatus,transferAccDate,operatorId,operatorName,dealWithTime,opinion) values (@flowId,@agentId,@agentName,@fee,@bankAccountId,@remark,To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'),@dealWithStatus,To_date(@transferAccDate,'yyyy-mm-dd hh24:mi:ss'),@operatorId,@operatorName,To_date(@dealWithTime,'yyyy-mm-dd hh24:mi:ss'),@opinion)";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", ttAgentTakeCashApply.flowId);//流水号
            param.Add("@agentId", ttAgentTakeCashApply.agentId);//代理商编号
            param.Add("@agentName", ttAgentTakeCashApply.agentName);//代理商名称
            param.Add("@fee", ttAgentTakeCashApply.fee);//提现金额
            param.Add("@bankAccountId", ttAgentTakeCashApply.bankAccountId);//银行账号
            param.Add("@remark", ttAgentTakeCashApply.remark);//提现说明
            param.Add("@createTime", ttAgentTakeCashApply.createTime);//创建时间
            param.Add("@dealWithStatus", ttAgentTakeCashApply.dealWithStatus);//办理状态
            param.Add("@transferAccDate", ttAgentTakeCashApply.transferAccDate);//转账日期
            param.Add("@operatorId", ttAgentTakeCashApply.operatorId);//办理人编号
            param.Add("@operatorName", ttAgentTakeCashApply.operatorName);//办理人名称
            param.Add("@dealWithTime", ttAgentTakeCashApply.dealWithTime);//办理时间
            param.Add("@opinion", ttAgentTakeCashApply.opinion);//办理意见
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加代理商提现申请
        /// </summary>
        /// <param name="ttAgentTakeCashApply">代理商提现申请</param>
        public virtual void Add(TTAgentTakeCashApply ttAgentTakeCashApply)
        {
            try
            {
                db.Open();
                Add(db,ttAgentTakeCashApply);
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
        /// 修改代理商提现申请
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttAgentTakeCashApply">代理商提现申请</param>
        public virtual void Edit(DataAccess data,TTAgentTakeCashApply ttAgentTakeCashApply)
        {
            string strSQL = "update TTAgentTakeCashApply set agentId=@agentId,agentName=@agentName,fee=@fee,bankAccountId=@bankAccountId,remark=@remark,createTime=To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'),dealWithStatus=@dealWithStatus,transferAccDate=To_date(@transferAccDate,'yyyy-mm-dd hh24:mi:ss'),operatorId=@operatorId,operatorName=@operatorName,dealWithTime=To_date(@dealWithTime,'yyyy-mm-dd hh24:mi:ss'),opinion=@opinion where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@agentId", ttAgentTakeCashApply.agentId);//代理商编号
            param.Add("@agentName", ttAgentTakeCashApply.agentName);//代理商名称
            param.Add("@fee", ttAgentTakeCashApply.fee);//提现金额
            param.Add("@bankAccountId", ttAgentTakeCashApply.bankAccountId);//银行账号
            param.Add("@remark", ttAgentTakeCashApply.remark);//提现说明
            param.Add("@createTime", ttAgentTakeCashApply.createTime);//创建时间
            param.Add("@dealWithStatus", ttAgentTakeCashApply.dealWithStatus);//办理状态
            param.Add("@transferAccDate", ttAgentTakeCashApply.transferAccDate);//转账日期
            param.Add("@operatorId", ttAgentTakeCashApply.operatorId);//办理人编号
            param.Add("@operatorName", ttAgentTakeCashApply.operatorName);//办理人名称
            param.Add("@dealWithTime", ttAgentTakeCashApply.dealWithTime);//办理时间
            param.Add("@opinion", ttAgentTakeCashApply.opinion);//办理意见
            param.Add("@flowId", ttAgentTakeCashApply.flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改代理商提现申请
        /// </summary>
        /// <param name="ttAgentTakeCashApply">代理商提现申请</param>
        public virtual void Edit(TTAgentTakeCashApply ttAgentTakeCashApply)
        {
            try
            {
                db.Open();
                Edit(db,ttAgentTakeCashApply);
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
        /// 删除代理商提现申请
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="flowId">流水号</param>
        public virtual void Delete(DataAccess data,long flowId)
        {
            string strSQL = "delete from TTAgentTakeCashApply where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除代理商提现申请
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
        /// 获取代理商提现申请
        /// </summary>
        /// <param name="flowId">流水号</param>
        /// <returns>代理商提现申请对象</returns>
        public virtual TTAgentTakeCashApply Get(long flowId)
        {
            TTAgentTakeCashApply ttAgentTakeCashApply=null;
            try
            {
                string strSQL = "select * from TTAgentTakeCashApply where flowId=@flowId";
                Param param = new Param();
                param.Clear();
                param.Add("@flowId", flowId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttAgentTakeCashApply=ReadData(dr);
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
            return ttAgentTakeCashApply;
        }
        
        /// <summary>
        /// 获取列表(代理商提现申请)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理商提现申请列表对象</returns>
        public virtual List<TTAgentTakeCashApply> GetList(string strSQL,Param param)
        {
            List<TTAgentTakeCashApply> list = new List<TTAgentTakeCashApply>();
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
        /// 获取列表(代理商提现申请)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>代理商提现申请列表对象</returns>
        public virtual List<TTAgentTakeCashApply> GetList(string field, string value)
        {
            List<TTAgentTakeCashApply> list = new List<TTAgentTakeCashApply>();
            try
            {
                string strSQL = "select * from TTAgentTakeCashApply where " + field + "=@field";
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
        /// 获取DataSet(代理商提现申请)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>代理商提现申请DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTAgentTakeCashApply");
        }
        
        /// <summary>
        /// 是否存在记录(代理商提现申请)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTAgentTakeCashApply where " + field + "=@field";
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
        /// 读取代理商提现申请信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>代理商提现申请对象</returns>
        protected virtual TTAgentTakeCashApply ReadData(ComDataReader dr)
        {
            TTAgentTakeCashApply ttAgentTakeCashApply= new TTAgentTakeCashApply();
            ttAgentTakeCashApply.flowId= long.Parse(dr["flowId"].ToString());//流水号
            ttAgentTakeCashApply.agentId= dr["agentId"].ToString();//代理商编号
            ttAgentTakeCashApply.agentName= dr["agentName"].ToString();//代理商名称
            ttAgentTakeCashApply.fee= double.Parse(dr["fee"].ToString());//提现金额
            ttAgentTakeCashApply.bankAccountId= dr["bankAccountId"].ToString();//银行账号
            ttAgentTakeCashApply.remark= dr["remark"].ToString();//提现说明
            if(dr["createTime"]==null)
            {
                ttAgentTakeCashApply.createTime= "";//创建时间
            }
            else
            {
                ttAgentTakeCashApply.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            ttAgentTakeCashApply.dealWithStatus= dr["dealWithStatus"].ToString();//办理状态
            if(dr["transferAccDate"]==null)
            {
                ttAgentTakeCashApply.transferAccDate= "";//转账日期
            }
            else
            {
                ttAgentTakeCashApply.transferAccDate= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["transferAccDate"]);//转账日期
            }
            ttAgentTakeCashApply.operatorId= dr["operatorId"].ToString();//办理人编号
            ttAgentTakeCashApply.operatorName= dr["operatorName"].ToString();//办理人名称
            if(dr["dealWithTime"]==null)
            {
                ttAgentTakeCashApply.dealWithTime= "";//办理时间
            }
            else
            {
                ttAgentTakeCashApply.dealWithTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["dealWithTime"]);//办理时间
            }
            ttAgentTakeCashApply.opinion= dr["opinion"].ToString();//办理意见
            return ttAgentTakeCashApply;
        }
        
        
        #endregion
        
    }
}

