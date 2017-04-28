using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.ZY.JXKK.Model;
using Com.Data;
using System.Data;

namespace Com.ZY.JXKK.DBO
{ /// <summary>
    /// 案件名称管理
    /// 
    /// </summary>
    public class TBEnforcementNameDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接

       
         /// <summary>
         /// 新增文案类型
         /// </summary>
         /// <param name="data"></param>
         /// <param name="tbEnforcementName"></param>
        public virtual void Add(DataAccess data, TBEnforcementName tbEnforcementName)
        {
            string strSQL = "insert into TBEnForcementName (EnforcementNameId,EnforcementTypeId,EnforcementName,IsEmpty,EnforcementTemplateId)  values(@EnforcementNameId,@EnforcementTypeId,@EnforcementName,@IsEmpty,@EnforcementTemplateId)";
            Param param = new Param();
            param.Clear();
            param.Add("@EnforcementNameId", tbEnforcementName.EnforcementNameId);//文书类型编号
            param.Add("@EnforcementTypeId", tbEnforcementName.EnforcementTypeId);//文书类型名称
            param.Add("@EnforcementName", tbEnforcementName.EnforcementName);
            param.Add("@IsEmpty", tbEnforcementName.IsEmpty);
            param.Add("@EnforcementTemplateId", tbEnforcementName.EnforcementTemplateId);
            
            //param.Add("@FillingPerson", tbEnforcementName.FillingPerson);
            //param.Add("@FillingTime", tbEnforcementName.FillingTime);
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 新增文案类型
        /// </summary>
        /// <param name="tbEnforcementName">门店信息</param>
        public virtual void Add(TBEnforcementName tbEnforcementName)
        {
            try
            {
                db.Open();
                Add(db, tbEnforcementName);
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
        public virtual void Edit(DataAccess data, TBEnforcementName tbEnforcementName)
        {
            string strSQL = "update TBEnForcementName set EnforcementName=@EnforcementName,IsEmpty=@IsEmpty  where EnforcementNameId=@EnforcementNameId";
            Param param = new Param();
            param.Clear();
            param.Add("@EnforcementName", tbEnforcementName.EnforcementName);
            param.Add("@IsEmpty", tbEnforcementName.IsEmpty);
            //param.Add("@FillingPerson", tbEnforcementName.FillingPerson);
            //param.Add("@FillingTime", tbEnforcementName.FillingTime);
            param.Add("@EnforcementNameId", tbEnforcementName.EnforcementNameId);
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 修改门店信息
        /// </summary>
        /// <param name="tbSite">门店信息</param>
        public virtual void Edit(TBEnforcementName tbEnforcementName)
        {
            try
            {
                db.Open();
                Edit(db, tbEnforcementName);
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
        /// 删除文书编号
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="EnforcementNameId">文书名称编号</param>
        public virtual void Delete(DataAccess data, string EnforcementNameId)
        {
            string strSQL = "delete from TBEnForcementName where EnforcementNameId=@EnforcementNameId";
            Param param = new Param();
            param.Clear();
            param.Add("@EnforcementNameId", EnforcementNameId);//删除信息
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 删除文书编号
        /// </summary>
        /// <param name="EnforcementNameId">文书名称编号</param>
        public virtual void Delete(string EnforcementNameId)
        {
            try
            {
                db.Open();
                Delete(db, EnforcementNameId);
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
        /// 文书名称信息
        /// </summary>
        /// <param name="siteId">门店编号</param>
        /// <returns>门店信息对象</returns>
        public virtual TBEnforcementName Get(string EnforcementNameId)
        {
            TBEnforcementName tbSite = null;
            try
            {
                string strSQL = string.Format(@"select n.EnforcementName,n.IsEmpty,n.F1,
t.EnforcementTypeName from TBEnforcementName n ,TBEnforcementType t 
 where  n.statu=1 and t.statu=1 and   t.EnforcementTypeId=n.EnforcementTypeId
  and n.EnforcementNameId=@EnforcementNameId");
                Param param = new Param();
                param.Clear();
                param.Add("@EnforcementNameId", EnforcementNameId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbSite = ReadData(dr);
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
        public virtual List<TBEnforcementName> GetList(string strSQL, Param param)
        {
            List<TBEnforcementName> list = new List<TBEnforcementName>();
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while (dr.Read())
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
        public virtual List<TBEnforcementName> GetList(string field, string value)
        {
            List<TBEnforcementName> list = new List<TBEnforcementName>();
            try
            {
                string strSQL = "select * from TBEnforcementName where  statu=1 and  " + field + "=@field";
                Param param = new Param();
                param.Clear();
                param.Add("@field", value);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while (dr.Read())
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
        public virtual DataSet GetDataSet(string strSQL, Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBEnForcementName");
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
                string strSQL = "select count(*) from TBEnForcementName where statu=1 and  " + field + "=@field";
                Param param = new Param();
                param.Clear();
                param.Add("@field", value);
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
        protected virtual TBEnforcementName ReadData(ComDataReader dr)
        {
            TBEnforcementName tbEnforcementName = new TBEnforcementName();
            tbEnforcementName.EnforcementNameId = dr["EnforcementNameId"].ToString();//
            tbEnforcementName.EnforcementTypeId = dr["EnforcementTypeId"].ToString();
            tbEnforcementName.F1 = dr["F1"].ToString();
            tbEnforcementName.EnforcementName = dr["EnforcementName"].ToString();//
            tbEnforcementName.IsEmpty = dr["IsEmpty"].ToString();//
            return tbEnforcementName;
        }


        

    }
}
