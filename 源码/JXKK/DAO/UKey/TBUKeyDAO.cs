using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;
using Com.ZY.JXKK.DAO.Agent;

namespace Com.ZY.JXKK.DAO.UKey
{
    /// <summary>
    /// UKey信息
    /// Author:开发人员自行扩展
    /// </summary>
    public class TBUKeyDAO : TBUKeyDBO
    {
        /// <summary>
        /// 激活
        /// </summary>
        /// <param name="uKeyId"></param>
        public void Activation(string uKeyId, string rowSiteId,string userId, string userName)
        {
            ComTransaction trans = null;
            try
            {
                Param param = null;
                List<TBUKey> ukeyList = GetList("select * from TBUKey where siteId=" + rowSiteId + " and status='" + (int)UKeyStatus.Activation + "' and ukeyId!='" + uKeyId + "'", param);
                TBUKey tbUKeyAc = Get(uKeyId);

                db.Open();
                trans = db.BeginTransaction();
                //讲已经激活的修改为已领并记录日志
                foreach (var tbUKey in ukeyList)
                {
                    tbUKey.status = ((int)UKeyStatus.Draw).ToString();
                    Edit(db, tbUKey);
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
                tbUKeyAc.status = ((int)UKeyStatus.Activation).ToString();
                Edit(db, tbUKeyAc);
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
        public List<TBUKey> GetListByStartEndUKey(string startUKeyId, string endUKeyId,int operaType)
        {
            List<TBUKey> list = new List<TBUKey>();
            try
            {
                string strSQL = "";
                if(operaType==0)
                 strSQL = "select * from TBUKey where UkeyId>=@startUKeyId and UkeyId<=@endUKeyId and status='" + (int)UKeyStatus.InStore + "' order by ukeyId ";
                if (operaType ==1)
                    strSQL = "select * from TBUKey where UkeyId>=@startUKeyId and UkeyId<=@endUKeyId and status in('" + (int)UKeyStatus.Draw + "','" + (int)UKeyStatus.Activation + "') order by ukeyId ";
                Param param = new Param();
                param.Clear();
                param.Add("@startUKeyId", startUKeyId);
                param.Add("@endUKeyId", endUKeyId);
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
                    Edit(db, uKey);
                    TBUKeyLog tbUKeyLog = new TBUKeyLog();
                    tbUKeyLog.uKeyId = uKey.uKeyId;//终端号
                    tbUKeyLog.operateType = "1";//操作类型
                    tbUKeyLog.summary = "发放到[代理商编号:" + agentId + ",门店编号:" + siteId + "]";
                    tbUKeyLog.operateTime = DateTime.Now.ToString();//操作时间
                    tbUKeyLog.operatorId = userId;//操作人编号
                    tbUKeyLog.operatorName = userName;//操作人名称

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
        /// 事务处理终端回收
        /// </summary>
        /// <param name="tbTBUKeyList"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        public void Recycle(List<TBUKey> tbTBUKeyList, string userId, string userName)
        {
            ComTransaction trans = null;
            try
            {
                db.Open();
                trans = db.BeginTransaction();
                foreach (var uKey in tbTBUKeyList)
                {
                    uKey.status = ((int)UKeyStatus.InStore).ToString();
                    RecycleEdit(db, uKey);
                    TBUKeyLog tbUKeyLog = new TBUKeyLog();
                    tbUKeyLog.uKeyId = uKey.uKeyId;//终端号
                    tbUKeyLog.operateType = "1";//操作类型
                    tbUKeyLog.summary = "发放到[代理商编号:" + uKey.agentId + ",门店编号:" + uKey.siteId + "]";
                    tbUKeyLog.operateTime = DateTime.Now.ToString();//操作时间
                    tbUKeyLog.operatorId = userId;//操作人编号
                    tbUKeyLog.operatorName = userName;//操作人名称

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
        public override void Edit(DataAccess data, TBUKey tbUKey)
        {
            string strSQL = "update TBUKey set status=@status,siteId=@siteId,agentId=@agentId where uKeyId=@uKeyId ";
            Param param = new Param();
            param.Clear();
            param.Add("@status", tbUKey.status);//当前状态
            param.Add("@siteId", tbUKey.siteId);//快开厅
            param.Add("@agentId", tbUKey.agentId);//代理商
            param.Add("@uKeyId", tbUKey.uKeyId);//加密狗编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 回收UKey信息
        /// <param name="data">数据库连接</param>
        /// <param name="tbUKey">UKey信息</param>
        /// </summary>
        public void RecycleEdit(DataAccess data, TBUKey tbUKey)
        {
            string strSQL = "update TBUKey set status=@status,siteId='',agentId='' where uKeyId=@uKeyId ";
            Param param = new Param();
            param.Clear();
            param.Add("@status", tbUKey.status);//当前状态
            param.Add("@uKeyId", tbUKey.uKeyId);//加密狗编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        /// <summary>
        /// UKey作废
        /// <param name="tbUKey">UKey信息</param>
        /// </summary>
        public void Invalid(string tbUKeyId)
        {
            try
            {
                db.Open();
                string strSQL = "update TBUKey set status=@status where uKeyId=@uKeyId ";
                Param param = new Param();
                param.Clear();
                param.Add("@status", (int)UKeyStatus.Invalid);//当前状态
                param.Add("@uKeyId", tbUKeyId);//加密狗编号
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
    }
}

