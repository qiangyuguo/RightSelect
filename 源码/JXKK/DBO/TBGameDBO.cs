using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 游戏类型
    /// Author:代码生成器
    /// </summary>
    public class TBGameDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加游戏类型
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbGame">游戏类型</param>
        public virtual void Add(DataAccess data,TBGame tbGame)
        {
            string strSQL = "insert into TBGame (gameId,gameName,isUse,typeCode) values (@gameId,@gameName,@isUse,@typeCode)";
            Param param = new Param();
            param.Clear();
            param.Add("@gameId", tbGame.gameId);//游戏编号
            param.Add("@gameName", tbGame.gameName);//游戏名称
            param.Add("@isUse", tbGame.isUse);//使用状态
            param.Add("@typeCode", tbGame.typeCode);//类型分类
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加游戏类型
        /// </summary>
        /// <param name="tbGame">游戏类型</param>
        public virtual void Add(TBGame tbGame)
        {
            try
            {
                db.Open();
                Add(db,tbGame);
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
        /// 修改游戏类型
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbGame">游戏类型</param>
        public virtual void Edit(DataAccess data,TBGame tbGame)
        {
            string strSQL = "update TBGame set gameName=@gameName,isUse=@isUse,typeCode=@typeCode where gameId=@gameId";
            Param param = new Param();
            param.Clear();
            param.Add("@gameName", tbGame.gameName);//游戏名称
            param.Add("@isUse", tbGame.isUse);//使用状态
            param.Add("@typeCode", tbGame.typeCode);//类型分类
            param.Add("@gameId", tbGame.gameId);//游戏编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改游戏类型
        /// </summary>
        /// <param name="tbGame">游戏类型</param>
        public virtual void Edit(TBGame tbGame)
        {
            try
            {
                db.Open();
                Edit(db,tbGame);
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
        /// 删除游戏类型
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="gameId">游戏编号</param>
        public virtual void Delete(DataAccess data,string gameId)
        {
            string strSQL = "delete from TBGame where gameId=@gameId";
            Param param = new Param();
            param.Clear();
            param.Add("@gameId", gameId);//游戏编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除游戏类型
        /// </summary>
        /// <param name="gameId">游戏编号</param>
        public virtual void Delete(string gameId)
        {
            try
            {
                db.Open();
                Delete(db,gameId);
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
        /// 获取游戏类型
        /// </summary>
        /// <param name="gameId">游戏编号</param>
        /// <returns>游戏类型对象</returns>
        public virtual TBGame Get(string gameId)
        {
            TBGame tbGame=null;
            try
            {
                string strSQL = "select * from TBGame where gameId=@gameId";
                Param param = new Param();
                param.Clear();
                param.Add("@gameId", gameId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbGame=ReadData(dr);
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
            return tbGame;
        }
        
        /// <summary>
        /// 获取列表(游戏类型)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>游戏类型列表对象</returns>
        public virtual List<TBGame> GetList(string strSQL,Param param)
        {
            List<TBGame> list = new List<TBGame>();
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
        /// 获取列表(游戏类型)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>游戏类型列表对象</returns>
        public virtual List<TBGame> GetList(string field, string value)
        {
            List<TBGame> list = new List<TBGame>();
            try
            {
                string strSQL = "select * from TBGame where " + field + "=@field";
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
        /// 获取DataSet(游戏类型)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>游戏类型DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBGame");
        }
        
        /// <summary>
        /// 是否存在记录(游戏类型)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBGame where " + field + "=@field";
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
        /// 读取游戏类型信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>游戏类型对象</returns>
        protected virtual TBGame ReadData(ComDataReader dr)
        {
            TBGame tbGame= new TBGame();
            tbGame.gameId= dr["gameId"].ToString();//游戏编号
            tbGame.gameName= dr["gameName"].ToString();//游戏名称
            tbGame.isUse= dr["isUse"].ToString();//使用状态
            tbGame.typeCode= dr["typeCode"].ToString();//类型分类
            return tbGame;
        }
        
        
        #endregion
        
    }
}

