using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;
using Com.ZY.JXKK.DAO.Agent;

namespace Com.ZY.JXKK.DAO.Terminal
{
    /// <summary>
    /// 终端
    /// Author:开发人员自行扩展
    /// </summary>
    public class TBTerminalDAO : TBTerminalDBO
    {
        /// <summary>
        /// 根据终端号起始结束获取相应的终端
        /// </summary>
        /// <param name="startCardId">起始终端</param>
        /// <param name="endCardId">结束终端</param>
        /// <param name="operaType">0 发放 1 回收</param>
        /// <returns></returns>
        public List<TBTerminal> GetListByStartEndTerminal(string startTerminalId, string endTerminalId, int operaType)
        {
            List<TBTerminal> list = new List<TBTerminal>();
            try
            {
                string strSQL="";
                if(operaType==0)
                    strSQL = "select * from TBTerminal where terminalId>=@startTerminalId and terminalId<=@endTerminalId and status='" + (int)TerminalStatus.InStore + "' order by terminalId ";
               if(operaType==1)
                   strSQL = "select * from TBTerminal where terminalId>=@startTerminalId and terminalId<=@endTerminalId and status not in('" + (int)TerminalStatus.InStore + "','" + (int)TerminalStatus.Invalid + "') order by terminalId ";
                Param param = new Param();
                param.Clear();
                param.Add("@startTerminalId", startTerminalId);
                param.Add("@endTerminalId", endTerminalId);
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
        /// 增加终端
        /// <param name="data">数据库连接</param>
        /// <param name="tbTerminal">终端</param>
        /// </summary>
        public override void Add(DataAccess data, TBTerminal tbTerminal)
        {
            string strSQL = "insert into TBTerminal (terminalId,status,terminalType,supplierDate,supplierCode,supplierBatch) values (@terminalId,@status,@terminalType,To_date(@supplierDate,'yyyy-mm-dd hh24:mi:ss'),@supplierCode,@supplierBatch)";
            Param param = new Param();
            param.Clear();
            param.Add("@terminalId", tbTerminal.terminalId);//终端编号
            param.Add("@status", tbTerminal.status);//当前状态
            param.Add("@terminalType", tbTerminal.terminalType);//终端类型
            param.Add("@supplierDate", tbTerminal.supplierDate);//出厂时间
            param.Add("@supplierCode", tbTerminal.supplierCode);//厂家代码
            param.Add("@supplierBatch", tbTerminal.supplierBatch);//厂家批次号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }


        /// <summary>
        /// 事务处理终端发放
        /// </summary>
        /// <param name="tbTBTerminalList"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        public void Grant(List<TBTerminal> tbTBTerminalList, string userId, string userName, string siteId)
        {
            ComTransaction trans = null;
            try
            {
                db.Open();
                trans = db.BeginTransaction();
                string agentId = new TBSiteDAO().Get(siteId).agentId;
                foreach (var terminal in tbTBTerminalList)
                {
                    terminal.status = ((int)TerminalStatus.Used).ToString();
                    terminal.agentId = agentId;
                    terminal.siteId = siteId;
                    Edit(db, terminal);

                    TBTerminalLog tbTerminalLog = new TBTerminalLog();
                    tbTerminalLog.terminalId = terminal.terminalId;//终端号
                    tbTerminalLog.operateType = "1";//操作类型
                    tbTerminalLog.summary = "发放到[代理商编号:" + agentId + ",门店编号:" + siteId + "]";
                    tbTerminalLog.operateTime = DateTime.Now.ToString();//操作时间
                    tbTerminalLog.operatorId = userId;//操作人编号
                    tbTerminalLog.operatorName = userName;//操作人名称

                    new TBTerminalLogDAO().Add(db, tbTerminalLog);
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
        /// <param name="tbTBTerminalList"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        public void Recycle(List<TBTerminal> tbTBTerminalList, string userId, string userName)
        {
            ComTransaction trans = null;
            try
            {
                db.Open();
                trans = db.BeginTransaction();
                foreach (var terminal in tbTBTerminalList)
                {
                    terminal.status = ((int)TerminalStatus.InStore).ToString();
                    RecycleEdit(db, terminal);
                    TBTerminalLog tbTerminalLog = new TBTerminalLog();
                    tbTerminalLog.terminalId = terminal.terminalId;//终端号
                    tbTerminalLog.operateType = "1";//操作类型
                    tbTerminalLog.summary = "回收[代理商编号:" + terminal.agentId + ",门店编号:" + terminal.siteId + "]";
                    tbTerminalLog.operateTime = DateTime.Now.ToString();//操作时间
                    tbTerminalLog.operatorId = userId;//操作人编号
                    tbTerminalLog.operatorName = userName;//操作人名称

                    new TBTerminalLogDAO().Add(db, tbTerminalLog);
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
        /// 修改终端
        /// <param name="data">数据库连接</param>
        /// <param name="tbTerminal">终端</param>
        /// </summary>
        public override void Edit(DataAccess data, TBTerminal tbTerminal)
        {
            string strSQL = "update TBTerminal set status=@status,siteId=@siteId,agentId=@agentId where terminalId=@terminalId";
            Param param = new Param();
            param.Clear();
            param.Add("@status", tbTerminal.status);//当前状态
            param.Add("@siteId", tbTerminal.siteId);//门店编号
            param.Add("@agentId", tbTerminal.agentId);//代理商编号
            param.Add("@terminalId", tbTerminal.terminalId);//终端编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 修改终端
        /// <param name="data">数据库连接</param>
        /// <param name="tbTerminal">终端</param>
        /// </summary>
        public void RecycleEdit(DataAccess data, TBTerminal tbTerminal)
        {
            string strSQL = "update TBTerminal set status=@status,siteId='',agentId='' where terminalId=@terminalId";
            Param param = new Param();
            param.Clear();
            param.Add("@status", tbTerminal.status);//当前状态
            param.Add("@terminalId", tbTerminal.terminalId);//终端编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 终端维护
        /// <param name="tbTerminal">终端</param>
        /// </summary>
        public void Maintence(TBTerminal tbTerminal)
        {
            try
            {
                db.Open();
                string strSQL = "update TBTerminal set status=@status where terminalId=@terminalId";
                Param param = new Param();
                param.Clear();
                param.Add("@status", tbTerminal.status);//状态
                param.Add("@terminalId", tbTerminal.terminalId);//终端编号
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
        /// 终端更新状态
        /// <param name="tbTerminal">终端</param>
        /// </summary>
        public void EditUpdateStatus(TBTerminal tbTerminal)
        {
            try
            {
                db.Open();
                string strSQL = "update TBTerminal set updateStatus=@updateStatus where terminalId=@terminalId";
                Param param = new Param();
                param.Clear();
                param.Add("@updateStatus", tbTerminal.updateStatus);//更新状态
                param.Add("@terminalId", tbTerminal.terminalId);//终端编号
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

