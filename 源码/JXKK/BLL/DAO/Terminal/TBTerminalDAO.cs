using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Terminal;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DAO.Agent;

namespace Com.ZY.JXKK.DAO.Terminal
{
    /// <summary>
    /// 终端
    /// Author:代码生成器
    /// </summary>
    public class TBTerminalDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接

        /// <summary>
        /// 根据终端号起始结束获取相应的终端
        /// </summary>
        /// <param name="startCardId">起始终端</param>
        /// <param name="endCardId">结束终端</param>
        /// <returns></returns>
        public List<TBTerminal> GetListByStartEndTerminal(string startTerminalId, string endTerminalId)
        {
            List<TBTerminal> list = new List<TBTerminal>();
            try
            {
                string strSQL = "select * from TBTerminal where terminalId>=:startTerminalId and terminalId<=:endTerminalId and status='"+(int)TerminalStatus.InStore+"' order by terminalId ";
                Param param = new Param();
                param.Clear();
                param.Add(":startTerminalId", startTerminalId);
                param.Add(":endTerminalId", endTerminalId);
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
        public void Add(DataAccess data, TBTerminal tbTerminal)
        {
            string strSQL = "insert into TBTerminal (terminalId,status,terminalType,supplierDate,supplierCode,supplierBatch) values (:terminalId,:status,:terminalType,To_date(:supplierDate,'yyyy-mm-dd hh24:mi:ss'),:supplierCode,:supplierBatch)";
            Param param = new Param();
            param.Clear();
            param.Add(":terminalId", tbTerminal.terminalId);//终端编号
            param.Add(":status", tbTerminal.status);//当前状态
            param.Add(":terminalType", tbTerminal.terminalType);//终端类型
            param.Add(":supplierDate", tbTerminal.supplierDate);//出厂时间
            param.Add(":supplierCode", tbTerminal.supplierCode);//厂家代码
            param.Add(":supplierBatch", tbTerminal.supplierBatch);//厂家批次号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }


        /// <summary>
        /// 事务处理终端发放
        /// </summary>
        /// <param name="tbTBTerminalList"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        public void Grant(List<TBTerminal> tbTBTerminalList, string userId, string userName,string siteId)
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
                    terminal.siteId =siteId;
                    TBTerminalLog tbTerminalLog = new TBTerminalLog();
                    tbTerminalLog.terminalId = terminal.terminalId;//终端号
                    tbTerminalLog.operateType = "1";//操作类型
                    tbTerminalLog.summary = "发放到[代理商编号:" + agentId + ",门店编号:" + siteId + "]";
                    tbTerminalLog.operateTime = DateTime.Now.ToString();//操作时间
                    tbTerminalLog.operatorId = userId;//操作人编号
                    tbTerminalLog.operatorName = userName;//操作人名称
                    Edit(db,terminal);
                    new TBTerminalLogDAO().Add(db,tbTerminalLog);
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
        public void Edit(DataAccess data, TBTerminal tbTerminal)
        {
            string strSQL = "update TBTerminal set status=:status,siteId=:siteId,agentId=:agentId where terminalId=:terminalId";
            Param param = new Param();
            param.Clear();
            param.Add(":status", tbTerminal.status);//当前状态
            param.Add(":siteId", tbTerminal.siteId);//门店编号
            param.Add(":agentId", tbTerminal.agentId);//代理商编号
            param.Add(":terminalId", tbTerminal.terminalId);//终端编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        #region 代码生成器自动生成
        
        /// <summary>
        /// 增加终端
        /// <param name="tbTerminal">终端</param>
        /// </summary>
        public void Add(TBTerminal tbTerminal)
        {
            try
            {
                db.Open();
                Add(db,tbTerminal);
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
        /// 修改终端
        /// <param name="tbTerminal">终端</param>
        /// </summary>
        public void Edit(TBTerminal tbTerminal)
        {
            try
            {
                db.Open();
                Edit(db,tbTerminal);
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
        /// 删除终端
        /// <param name="data">数据库连接</param>
        /// <param name="terminalId">终端编号</param>
        /// </summary>
        public void Delete(DataAccess data,string terminalId)
        {
            string strSQL = "delete from TBTerminal where terminalId=:terminalId";
            Param param = new Param();
            param.Clear();
            param.Add(":terminalId", terminalId);//终端编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除终端
        /// <param name="terminalId">终端编号</param>
        /// </summary>
        public void Delete(string terminalId)
        {
            try
            {
                db.Open();
                Delete(db,terminalId);
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
        /// 获取终端
        /// <param name="terminalId">终端编号</param>
        /// </summary>
        /// <returns>终端对象</returns>
        public TBTerminal Get(string terminalId)
        {
            TBTerminal tbTerminal=null;
            try
            {
                string strSQL = "select * from TBTerminal where terminalId=:terminalId";
                Param param = new Param();
                param.Clear();
                param.Add(":terminalId", terminalId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbTerminal=ReadData(dr);
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
            return tbTerminal;
        }
        
        /// <summary>
        /// 获取列表(终端)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>终端列表对象</returns>
        public List<TBTerminal> GetList(string strSQL,Param param)
        {
            List<TBTerminal> list = new List<TBTerminal>();
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
        /// 获取列表(终端)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>终端列表对象</returns>
        public List<TBTerminal> GetList(string field, string value)
        {
            List<TBTerminal> list = new List<TBTerminal>();
            try
            {
                string strSQL = "select * from TBTerminal where " + field + "=:field";
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
        /// 获取DataSet(终端)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>终端DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBTerminal");
        }
        
        /// <summary>
        /// 是否存在记录(终端)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBTerminal where " + field + "=:field";
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
        /// 读取终端信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>终端对象</returns>
        private TBTerminal ReadData(ComDataReader dr)
        {
            TBTerminal tbTerminal= new TBTerminal();
            tbTerminal.terminalId= dr["terminalId"].ToString();//终端编号
            tbTerminal.status= dr["status"].ToString();//当前状态
            tbTerminal.terminalType= dr["terminalType"].ToString();//终端类型
            if(dr["supplierDate"]==null)
            {
                tbTerminal.supplierDate= "";//出厂时间
            }
            else
            {
                tbTerminal.supplierDate= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["supplierDate"]);//出厂时间
            }
            tbTerminal.supplierCode= dr["supplierCode"].ToString();//厂家代码
            tbTerminal.supplierBatch= dr["supplierBatch"].ToString();//厂家批次号
            tbTerminal.siteId= dr["siteId"].ToString();//门店编号
            tbTerminal.agentId= dr["agentId"].ToString();//代理商编号
            return tbTerminal;
        }
        
        
        #endregion
        
    }
}

