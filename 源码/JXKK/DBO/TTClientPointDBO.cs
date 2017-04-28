using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 客户积分明细
    /// Author:代码生成器
    /// </summary>
    public class TTClientPointDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加客户积分明细
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientPoint">客户积分明细</param>
        public virtual void Add(DataAccess data,TTClientPoint ttClientPoint)
        {
            string strSQL = "insert into TTClientPoint (flowId,cardId,clientId,clientName,agentId,siteId,lastPoint,point,remainingPoint,changeTime,description,createTime,srcMode,srcFlowId,operatorId,operatorName,gameId,terminalId) values (@flowId,@cardId,@clientId,@clientName,@agentId,@siteId,@lastPoint,@point,@remainingPoint,@changeTime,@description,To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'),@srcMode,@srcFlowId,@operatorId,@operatorName,@gameId,@terminalId)";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", ttClientPoint.flowId);//流水号
            param.Add("@cardId", ttClientPoint.cardId);//卡号
            param.Add("@clientId", ttClientPoint.clientId);//客户编号
            param.Add("@clientName", ttClientPoint.clientName);//客户名称
            param.Add("@agentId", ttClientPoint.agentId);//代理商编号
            param.Add("@siteId", ttClientPoint.siteId);//门店编号
            param.Add("@lastPoint", ttClientPoint.lastPoint);//上次积分
            param.Add("@point", ttClientPoint.point);//发生积分
            param.Add("@remainingPoint", ttClientPoint.remainingPoint);//剩余积分
            param.Add("@changeTime", ttClientPoint.changeTime);//发生时间
            param.Add("@description", ttClientPoint.description);//描述说明
            param.Add("@createTime", ttClientPoint.createTime);//创建时间
            param.Add("@srcMode", ttClientPoint.srcMode);//来源方式
            param.Add("@srcFlowId", ttClientPoint.srcFlowId);//来源流水号
            param.Add("@operatorId", ttClientPoint.operatorId);//操作人编号
            param.Add("@operatorName", ttClientPoint.operatorName);//操作人名称
            param.Add("@gameId", ttClientPoint.gameId);//游戏编号
            param.Add("@terminalId", ttClientPoint.terminalId);//终端编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加客户积分明细
        /// </summary>
        /// <param name="ttClientPoint">客户积分明细</param>
        public virtual void Add(TTClientPoint ttClientPoint)
        {
            try
            {
                db.Open();
                Add(db,ttClientPoint);
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
        /// 修改客户积分明细
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="ttClientPoint">客户积分明细</param>
        public virtual void Edit(DataAccess data,TTClientPoint ttClientPoint)
        {
            string strSQL = "update TTClientPoint set cardId=@cardId,clientId=@clientId,clientName=@clientName,agentId=@agentId,siteId=@siteId,lastPoint=@lastPoint,point=@point,remainingPoint=@remainingPoint,changeTime=@changeTime,description=@description,createTime=To_date(@createTime,'yyyy-mm-dd hh24:mi:ss'),srcMode=@srcMode,srcFlowId=@srcFlowId,operatorId=@operatorId,operatorName=@operatorName,gameId=@gameId,terminalId=@terminalId where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@cardId", ttClientPoint.cardId);//卡号
            param.Add("@clientId", ttClientPoint.clientId);//客户编号
            param.Add("@clientName", ttClientPoint.clientName);//客户名称
            param.Add("@agentId", ttClientPoint.agentId);//代理商编号
            param.Add("@siteId", ttClientPoint.siteId);//门店编号
            param.Add("@lastPoint", ttClientPoint.lastPoint);//上次积分
            param.Add("@point", ttClientPoint.point);//发生积分
            param.Add("@remainingPoint", ttClientPoint.remainingPoint);//剩余积分
            param.Add("@changeTime", ttClientPoint.changeTime);//发生时间
            param.Add("@description", ttClientPoint.description);//描述说明
            param.Add("@createTime", ttClientPoint.createTime);//创建时间
            param.Add("@srcMode", ttClientPoint.srcMode);//来源方式
            param.Add("@srcFlowId", ttClientPoint.srcFlowId);//来源流水号
            param.Add("@operatorId", ttClientPoint.operatorId);//操作人编号
            param.Add("@operatorName", ttClientPoint.operatorName);//操作人名称
            param.Add("@gameId", ttClientPoint.gameId);//游戏编号
            param.Add("@terminalId", ttClientPoint.terminalId);//终端编号
            param.Add("@flowId", ttClientPoint.flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改客户积分明细
        /// </summary>
        /// <param name="ttClientPoint">客户积分明细</param>
        public virtual void Edit(TTClientPoint ttClientPoint)
        {
            try
            {
                db.Open();
                Edit(db,ttClientPoint);
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
        /// 删除客户积分明细
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="flowId">流水号</param>
        public virtual void Delete(DataAccess data,long flowId)
        {
            string strSQL = "delete from TTClientPoint where flowId=@flowId";
            Param param = new Param();
            param.Clear();
            param.Add("@flowId", flowId);//流水号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除客户积分明细
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
        /// 获取客户积分明细
        /// </summary>
        /// <param name="flowId">流水号</param>
        /// <returns>客户积分明细对象</returns>
        public virtual TTClientPoint Get(long flowId)
        {
            TTClientPoint ttClientPoint=null;
            try
            {
                string strSQL = "select * from TTClientPoint where flowId=@flowId";
                Param param = new Param();
                param.Clear();
                param.Add("@flowId", flowId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    ttClientPoint=ReadData(dr);
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
            return ttClientPoint;
        }
        
        /// <summary>
        /// 获取列表(客户积分明细)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>客户积分明细列表对象</returns>
        public virtual List<TTClientPoint> GetList(string strSQL,Param param)
        {
            List<TTClientPoint> list = new List<TTClientPoint>();
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
        /// 获取列表(客户积分明细)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>客户积分明细列表对象</returns>
        public virtual List<TTClientPoint> GetList(string field, string value)
        {
            List<TTClientPoint> list = new List<TTClientPoint>();
            try
            {
                string strSQL = "select * from TTClientPoint where " + field + "=@field";
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
        /// 获取DataSet(客户积分明细)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>客户积分明细DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TTClientPoint");
        }
        
        /// <summary>
        /// 是否存在记录(客户积分明细)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TTClientPoint where " + field + "=@field";
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
        /// 读取客户积分明细信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>客户积分明细对象</returns>
        protected virtual TTClientPoint ReadData(ComDataReader dr)
        {
            TTClientPoint ttClientPoint= new TTClientPoint();
            ttClientPoint.flowId= long.Parse(dr["flowId"].ToString());//流水号
            ttClientPoint.cardId= dr["cardId"].ToString();//卡号
            ttClientPoint.clientId= long.Parse(dr["clientId"].ToString());//客户编号
            ttClientPoint.clientName= dr["clientName"].ToString();//客户名称
            ttClientPoint.agentId= dr["agentId"].ToString();//代理商编号
            ttClientPoint.siteId= dr["siteId"].ToString();//门店编号
            ttClientPoint.lastPoint= long.Parse(dr["lastPoint"].ToString());//上次积分
            ttClientPoint.point= long.Parse(dr["point"].ToString());//发生积分
            ttClientPoint.remainingPoint= long.Parse(dr["remainingPoint"].ToString());//剩余积分
            ttClientPoint.changeTime= dr["changeTime"].ToString();//发生时间
            ttClientPoint.description= dr["description"].ToString();//描述说明
            if(dr["createTime"]==null)
            {
                ttClientPoint.createTime= "";//创建时间
            }
            else
            {
                ttClientPoint.createTime= string.Format("{0:yyyy-MM-dd HH:mm:ss}",dr["createTime"]);//创建时间
            }
            ttClientPoint.srcMode= dr["srcMode"].ToString();//来源方式
            ttClientPoint.srcFlowId= dr["srcFlowId"].ToString();//来源流水号
            ttClientPoint.operatorId= dr["operatorId"].ToString();//操作人编号
            ttClientPoint.operatorName= dr["operatorName"].ToString();//操作人名称
            ttClientPoint.gameId= dr["gameId"].ToString();//游戏编号
            ttClientPoint.terminalId= dr["terminalId"].ToString();//终端编号
            return ttClientPoint;
        }
        
        
        #endregion
        
    }
}

