using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.UKey;
using Com.ZY.JXKK.DAO.Agent;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DAO.UKey
{
    /// <summary>
    /// UKey信息
    /// Author:代码生成器
    /// </summary>
    public class TBUKeyDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接

        /// <summary>
        /// 激活
        /// </summary>
        /// <param name="uKeyId"></param>
        public void Activation(string uKeyId,string userId,string userName)
        {
            ComTransaction trans = null;
            try
            {
                Param param = null;
                List<TBUKey> ukeyList = GetList("select * from TBUKey where status='" + (int)UKeyStatus.Activation + "' and ukeyId!='" + uKeyId + "'", param);
                TBUKey tbUKeyAc = Get(uKeyId);

                db.Open();
                trans = db.BeginTransaction();
                //讲已经激活的修改为已领并记录日志
                foreach (var tbUKey in ukeyList)
                {
                    tbUKey.status = ((int)UKeyStatus.Draw).ToString();
                    Edit(db,tbUKey);
                    TBUKeyLog tbUKeyLog = new TBUKeyLog();
                    tbUKeyLog.uKeyId = tbUKey.uKeyId;//终端号
                    tbUKeyLog.operateType = "1";//操作类型
                    tbUKeyLog.summary = "发放到[代理商编号:" + tbUKey.agentId + ",门店编号:" + tbUKey.siteId + "]";
                    tbUKeyLog.operateTime = DateTime.Now.ToString();//操作时间
                    tbUKeyLog.operatorId = userId;//操作人编号
                    tbUKeyLog.operatorName = userName;//操作人名称
                    new TBUKeyLogDAO().Add(db, tbUKeyLog);
                }
                //激活
                tbUKeyAc.status=((int)UKeyStatus.Activation).ToString();
                Edit(db,tbUKeyAc);
                TBUKeyLog tbUKeyLogA = new TBUKeyLog();
                tbUKeyLogA.uKeyId = tbUKeyAc.uKeyId;//终端号
                tbUKeyLogA.operateType = "1";//操作类型
                tbUKeyLogA.summary = "发放到[代理商编号:" + tbUKeyAc.agentId + ",门店编号:" + tbUKeyAc.siteId + "]";
                tbUKeyLogA.operateTime = DateTime.Now.ToString();//操作时间
                tbUKeyLogA.operatorId = userId;//操作人编号
                tbUKeyLogA.operatorName = userName;//操作人名称
                new TBUKeyLogDAO().Add(db, tbUKeyLogA);
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
        /// 根据加密狗号起始结束获取相应数据
        /// </summary>
        /// <param name="startCardId">起始号</param>
        /// <param name="endCardId">结束号</param>
        /// <returns></returns>
        public List<TBUKey> GetListByStartEndUKey(string startUKeyId, string endUKeyId)
        {
            List<TBUKey> list = new List<TBUKey>();
            try
            {
                string strSQL = "select * from TBUKey where UkeyId>=:startUKeyId and UkeyId<=:endUKeyId and status='" + (int)UKeyStatus.InStore + "' order by terminalId ";
                Param param = new Param();
                param.Clear();
                param.Add(":startUKeyId", startUKeyId);
                param.Add(":endUKeyId", endUKeyId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while (dr.Read())
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
        /// 事务处理终端发放
        /// </summary>
        /// <param name="tbTBUKeyList"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        public void Grant(List<TBUKey> tbTBUKeyList, string userId, string userName, string siteId)
        {
            ComTransaction trans = null;
            try
            {
                db.Open();
                trans = db.BeginTransaction();
                string agentId = new TBSiteDAO().Get(siteId).agentId;
                foreach (var uKey in tbTBUKeyList)
                {
                    uKey.status = ((int)UKeyStatus.Draw).ToString();
                    uKey.agentId = agentId;
                    uKey.siteId = siteId;
                    TBUKeyLog tbUKeyLog = new TBUKeyLog();
                    tbUKeyLog.uKeyId = uKey.uKeyId;//终端号
                    tbUKeyLog.operateType = "1";//操作类型
                    tbUKeyLog.summary = "发放到[代理商编号:" + agentId + ",门店编号:" + siteId + "]";
                    tbUKeyLog.operateTime = DateTime.Now.ToString();//操作时间
                    tbUKeyLog.operatorId = userId;//操作人编号
                    tbUKeyLog.operatorName = userName;//操作人名称
                    Edit(db, uKey);
                    new TBUKeyLogDAO().Add(db, tbUKeyLog);
                }
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
        /// 修改UKey信息
        /// <param name="data">数据库连接</param>
        /// <param name="tbUKey">UKey信息</param>
        /// </summary>
        public void Edit(DataAccess data, TBUKey tbUKey)
        {
            string strSQL = "update TBUKey set status=:status where uKeyId=:uKeyId";
            Param param = new Param();
            param.Clear();
            param.Add(":status", tbUKey.status);//当前状态
            param.Add(":uKeyId", tbUKey.uKeyId);//加密狗编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加UKey信息
        /// <param name="data">数据库连接</param>
        /// <param name="tbUKey">UKey信息</param>
        /// </summary>
        public void Add(DataAccess data,TBUKey tbUKey)
        {
            string strSQL = "insert into TBUKey (uKeyId,chipId,data,status,siteId,agentId) values (:uKeyId,:chipId,:data,:status,:siteId,:agentId)";
            Param param = new Param();
            param.Clear();
            param.Add(":uKeyId", tbUKey.uKeyId);//加密狗编号
            param.Add(":chipId", tbUKey.chipId);//内置编号
            param.Add(":data", tbUKey.data);//加密数据
            param.Add(":status", tbUKey.status);//当前状态
            param.Add(":siteId", tbUKey.siteId);//门店编号
            param.Add(":agentId", tbUKey.agentId);//代理商编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加UKey信息
        /// <param name="tbUKey">UKey信息</param>
        /// </summary>
        public void Add(TBUKey tbUKey)
        {
            try
            {
                db.Open();
                Add(db,tbUKey);
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
        /// 修改UKey信息
        /// <param name="tbUKey">UKey信息</param>
        /// </summary>
        public void Edit(TBUKey tbUKey)
        {
            try
            {
                db.Open();
                Edit(db,tbUKey);
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
        /// 删除UKey信息
        /// <param name="data">数据库连接</param>
        /// <param name="uKeyId">加密狗编号</param>
        /// </summary>
        public void Delete(DataAccess data,string uKeyId)
        {
            string strSQL = "delete from TBUKey where uKeyId=:uKeyId";
            Param param = new Param();
            param.Clear();
            param.Add(":uKeyId", uKeyId);//加密狗编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除UKey信息
        /// <param name="uKeyId">加密狗编号</param>
        /// </summary>
        public void Delete(string uKeyId)
        {
            try
            {
                db.Open();
                Delete(db,uKeyId);
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
        /// 获取UKey信息
        /// <param name="uKeyId">加密狗编号</param>
        /// </summary>
        /// <returns>UKey信息对象</returns>
        public TBUKey Get(string uKeyId)
        {
            TBUKey tbUKey=null;
            try
            {
                string strSQL = "select * from TBUKey where uKeyId=:uKeyId";
                Param param = new Param();
                param.Clear();
                param.Add(":uKeyId", uKeyId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbUKey=ReadData(dr);
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
            return tbUKey;
        }
        
        /// <summary>
        /// 获取列表(UKey信息)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>UKey信息列表对象</returns>
        public List<TBUKey> GetList(string strSQL,Param param)
        {
            List<TBUKey> list = new List<TBUKey>();
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
        /// 获取列表(UKey信息)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>UKey信息列表对象</returns>
        public List<TBUKey> GetList(string field, string value)
        {
            List<TBUKey> list = new List<TBUKey>();
            try
            {
                string strSQL = "select * from TBUKey where " + field + "=:field";
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
        /// 获取DataSet(UKey信息)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>UKey信息DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBUKey");
        }
        
        /// <summary>
        /// 是否存在记录(UKey信息)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBUKey where " + field + "=:field";
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
        /// 读取UKey信息信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>UKey信息对象</returns>
        private TBUKey ReadData(ComDataReader dr)
        {
            TBUKey tbUKey= new TBUKey();
            tbUKey.uKeyId= dr["uKeyId"].ToString();//加密狗编号
            tbUKey.chipId= dr["chipId"].ToString();//内置编号
            tbUKey.data= dr["data"].ToString();//加密数据
            tbUKey.status= dr["status"].ToString();//当前状态
            tbUKey.siteId= dr["siteId"].ToString();//门店编号
            tbUKey.agentId= dr["agentId"].ToString();//代理商编号
            return tbUKey;
        }
        
        
        #endregion
        
    }
}

