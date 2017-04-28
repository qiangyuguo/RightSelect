using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 文书类型管理
    /// 
    /// </summary>
    public class TBEnforcementTypeDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加门店信息
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbSite">门店信息</param>
        public virtual void Add(DataAccess data, TBEnforcementType tbEnforcementType)
        {
            string strSQL = "insert into TBEnforcementType  (EnforcementTypeId,EnforcementTypeName,PunishmentType) values(@EnforcementTypeId,@EnforcementTypeName,@PunishmentType)";
            Param param = new Param();
            param.Clear();
            param.Add("@EnforcementTypeId", tbEnforcementType.EnforcementTypeId);//文书类型编号
            param.Add("@EnforcementTypeName", tbEnforcementType.EnforcementTypeName);//文书类型名称
            param.Add("@PunishmentType", tbEnforcementType.PunishmentType);//文书处罚类型
            
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加文书处罚类型
        /// </summary>
        /// <param name="tbSite">门店信息</param>
        public virtual void Add(TBEnforcementType tbEnforcementType)
        {
            try
            {
                db.Open();
                Add(db, tbEnforcementType);
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
        /// 修改门店信息
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbSite">门店信息</param>
        public virtual void Edit(DataAccess data, TBEnforcementType tbEnforcementType)
        {
            string strSQL = "update TBEnforcementType set EnforcementTypeName=@EnforcementTypeName  , PunishmentType=@PunishmentType  where EnforcementTypeId=@EnforcementTypeId";
            Param param = new Param();
            param.Clear();
            param.Add("@EnforcementTypeId", tbEnforcementType.EnforcementTypeId);//代理商编号
            param.Add("@EnforcementTypeName", tbEnforcementType.EnforcementTypeName);//门店名称
            param.Add("@PunishmentType", tbEnforcementType.PunishmentType);//门店名称

            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改门店信息
        /// </summary>
        /// <param name="tbSite">门店信息</param>
        public virtual void Edit(TBEnforcementType tbEnforcementType)
        {
            try
            {
                db.Open();
                Edit(db, tbEnforcementType);
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
        /// 删除门店信息
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="siteId">门店编号</param>
        public virtual void Delete(DataAccess data, string EnforcementTypeId)
        {
            string strSQL = "delete from TBEnforcementType where statu=1 and  EnforcementTypeId=@EnforcementTypeId";
            Param param = new Param();
            param.Clear();
            param.Add("@EnforcementTypeId", EnforcementTypeId);//门店编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除门店信息
        /// </summary>
        /// <param name="siteId">门店编号</param>
        public virtual void Delete(string EnforcementTypeId)
        {
            try
            {
                db.Open();
                Delete(db, EnforcementTypeId);
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
        /// 获取门店信息
        /// </summary>
        /// <param name="siteId">门店编号</param>
        /// <returns>门店信息对象</returns>
        public virtual TBEnforcementType Get(string EnforcementTypeId)
        {
            TBEnforcementType tbSite = null;
            try
            {
                string strSQL = "select * from tbEnforcementType where statu=1 and  EnforcementTypeId=@EnforcementTypeId";
                Param param = new Param();
                param.Clear();
                param.Add("@EnforcementTypeId", EnforcementTypeId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbSite=ReadData(dr);
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
            return tbSite;
        }

 

        
        /// <summary>
        /// 获取列表(门店信息)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>门店信息列表对象</returns>
        public virtual List<TBEnforcementType> GetList(string strSQL, Param param)
        {
            List<TBEnforcementType> list = new List<TBEnforcementType>();
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
        /// 获取列表(门店信息)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>门店信息列表对象</returns>
        public virtual List<TBEnforcementType> GetList(string field, string value)
        {
            List<TBEnforcementType> list = new List<TBEnforcementType>();
            try
            {
                string strSQL = "select * from TBEnforcementType where statu=1 and  " + field + "=@field";
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
        /// 获取DataSet(门店信息)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>门店信息DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBEnforcementType");
        }
        
        /// <summary>
        /// 是否存在记录(门店信息)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBEnforcementType where statu=1 and  " + field + "=@field";
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
        /// 读取执法文书类型信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>门店信息对象</returns>
        protected virtual TBEnforcementType ReadData(ComDataReader dr)
        {
            TBEnforcementType tbEnforcementType = new TBEnforcementType();
            tbEnforcementType.EnforcementTypeId = dr["ENFORCEMENTTYPEID"].ToString();//
            tbEnforcementType.EnforcementTypeName = dr["ENFORCEMENTTYPENAME"].ToString();
            tbEnforcementType.F1 = dr["F1"].ToString();
            tbEnforcementType.F2 = dr["F2"].ToString();
            tbEnforcementType.CreateDate = dr["CREATEDATE"].ToString();//
            tbEnforcementType.PunishmentType = dr["PUNISHMENTTYPE"].ToString();//


            return tbEnforcementType;
        }
        
        
        #endregion
        
    }
}

