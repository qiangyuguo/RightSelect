using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 客户账户明细
    /// Author:代码生成器
    /// </summary>
    public class TTClientAccDetailDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加客户账户明细
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientAccDetail">客户账户明细</param>
        public virtual void Add(DataAccess data,TTClientAccDetail ttClientAccDetail)
        {
            string strSQL = "insert into TTClientAccDetail (flowId,cardId,clientId,clientName,agentId,siteId,lastBalance,fee,balance,remark,changeTime,srcMode,createTime) values (@flowId,@cardId,@clientId,@clientName,@agentId,@siteId,@lastBalance,@fee,@balance,@remark,@changeTime,@srcMode,To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'))";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", ttClientAccDetail.flowId);//流水号
            param.Add("@cardId", ttClientAccDetail.cardId);//卡号
            param.Add("@clientId", ttClientAccDetail.clientId);//客户编号
            param.Add("@clientName", ttClientAccDetail.clientName);//客户名称
            param.Add("@agentId", ttClientAccDetail.agentId);//代理商编号
            param.Add("@siteId", ttClientAccDetail.siteId);//门店编号
            param.Add("@lastBalance", ttClientAccDetail.lastBalance);//上次余额
            param.Add("@fee", ttClientAccDetail.fee);//发生金额
            param.Add("@balance", ttClientAccDetail.balance);//当前余额
            param.Add("@remark", ttClientAccDetail.remark);//信息摘要
            param.Add("@changeTime", ttClientAccDetail.changeTime);//发生时间
            param.Add("@srcMode", ttClientAccDetail.srcMode);//来源方式
            param.Add("@createTime", ttClientAccDetail.createTime);//创建时间
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加客户账户明细
        /// </summary>
        /// <param name="ttClientAccDetail">客户账户明细</param>
        public virtual void Add(TTClientAccDetail ttClientAccDetail)
        {
            try
            {
                db.Open();
                Add(db,ttClientAccDetail);
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
        /// 修改客户账户明细
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientAccDetail">客户账户明细</param>
        public virtual void Edit(DataAccess data,TTClientAccDetail ttClientAccDetail)
        {
            string strSQL = "update TTClientAccDetail set cardId=@cardId,clientId=@clientId,clientName=@clientName,agentId=@agentId,siteId=@siteId,lastBalance=@lastBalance,fee=@fee,balance=@balance,remark=@remark,changeTime=@changeTime,srcMode=@srcMode,createTime=To_date(@createTime,'yyyy-mm-dd hh24:mi:ss') where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@cardId", ttClientAccDetail.cardId);//卡号
            param.Add("@clientId", ttClientAccDetail.clientId);//客户编号
            param.Add("@clientName", ttClientAccDetail.clientName);//客户名称
            param.Add("@agentId", ttClientAccDetail.agentId);//代理商编号
            param.Add("@siteId", ttClientAccDetail.siteId);//门店编号
            param.Add("@lastBalance", ttClientAccDetail.lastBalance);//上次余额
            param.Add("@fee", ttClientAccDetail.fee);//发生金额
            param.Add("@balance", ttClientAccDetail.balance);//当前余额
            param.Add("@remark", ttClientAccDetail.remark);//信息摘要
            param.Add("@changeTime", ttClientAccDetail.changeTime);//发生时间
            param.Add("@srcMode", ttClientAccDetail.srcMode);//来源方式
            param.Add("@createTime", ttClientAccDetail.createTime);//创建时间
            param.Add("@flowId", ttClientAccDetail.flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改客户账户明细
        /// </summary>
        /// <param name="ttClientAccDetail">客户账户明细</param>
        public virtual void Edit(TTClientAccDetail ttClientAccDetail)
        {
            try
            {
                db.Open();
                Edit(db,ttClientAccDetail);
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
        /// 删除客户账户明细
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="flowId">流水号</param>
        public virtual void Delete(DataAccess data,long flowId)
        {
            string strSQL = "delete from TTClientAccDetail where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除客户账户明细
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
        /// 获取客户账户明细
        /// </summary>
        /// <param name="flowId">流水号</param>
        /// <returns>客户账户明细对象</returns>
        public virtual TTClientAccDetail Get(long flowId)
        {
            TTClientAccDetail ttClientAccDetail=null;
            try
            {
                string strSQL = "select * from TTClientAccDetail where flowId=@flowId";
                Param param = new Param();
                param.Clear();
                param.Add("@flowId", flowId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttClientAccDetail=ReadData(dr);
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
            return ttClientAccDetail;
        }
        
        /// <summary>
        /// 获取列表(客户账户明细)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>客户账户明细列表对象</returns>
        public virtual List<TTClientAccDetail> GetList(string strSQL,Param param)
        {
            List<TTClientAccDetail> list = new List<TTClientAccDetail>();
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
        /// 获取列表(客户账户明细)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>客户账户明细列表对象</returns>
        public virtual List<TTClientAccDetail> GetList(string field, string value)
        {
            List<TTClientAccDetail> list = new List<TTClientAccDetail>();
            try
            {
                string strSQL = "select * from TTClientAccDetail where " + field + "=@field";
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
        /// 获取DataSet(客户账户明细)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>客户账户明细DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTClientAccDetail");
        }
        
        /// <summary>
        /// 是否存在记录(客户账户明细)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTClientAccDetail where " + field + "=@field";
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
        /// 读取客户账户明细信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>客户账户明细对象</returns>
        protected virtual TTClientAccDetail ReadData(ComDataReader dr)
        {
            TTClientAccDetail ttClientAccDetail= new TTClientAccDetail();
            ttClientAccDetail.flowId= long.Parse(dr["flowId"].ToString());//流水号
            ttClientAccDetail.cardId= dr["cardId"].ToString();//卡号
            ttClientAccDetail.clientId= long.Parse(dr["clientId"].ToString());//客户编号
            ttClientAccDetail.clientName= dr["clientName"].ToString();//客户名称
            ttClientAccDetail.agentId= dr["agentId"].ToString();//代理商编号
            ttClientAccDetail.siteId= dr["siteId"].ToString();//门店编号
            ttClientAccDetail.lastBalance= double.Parse(dr["lastBalance"].ToString());//上次余额
            ttClientAccDetail.fee= double.Parse(dr["fee"].ToString());//发生金额
            ttClientAccDetail.balance= double.Parse(dr["balance"].ToString());//当前余额
            ttClientAccDetail.remark= dr["remark"].ToString();//信息摘要
            ttClientAccDetail.changeTime= dr["changeTime"].ToString();//发生时间
            ttClientAccDetail.srcMode= dr["srcMode"].ToString();//来源方式
            if(dr["createTime"]==null)
            {
                ttClientAccDetail.createTime= "";//创建时间
            }
            else
            {
                ttClientAccDetail.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            return ttClientAccDetail;
        }
        
        
        #endregion
        
    }
}

