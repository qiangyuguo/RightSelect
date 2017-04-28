using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 门店员工
    /// Author:代码生成器
    /// </summary>
    public class TBStaffDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加门店员工
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbStaff">门店员工</param>
        public virtual void Add(DataAccess data,TBStaff tbStaff)
        {
            string strSQL = "insert into TBStaff (staffId,siteId,agentId,staffName,status,telephone,IDNumber,address,remark) values (@staffId,@siteId,@agentId,@staffName,@status,@telephone,@IDNumber,@address,@remark)";
            Param param = new Param();
            param.Clear();
            param.Add("@staffId", tbStaff.staffId);//员工编号
            param.Add("@siteId", tbStaff.siteId);//门店编号
            param.Add("@agentId", tbStaff.agentId);//代理商编号
            param.Add("@staffName", tbStaff.staffName);//员工姓名
            param.Add("@status", tbStaff.status);//使用状态
            param.Add("@telephone", tbStaff.telephone);//手机号码
            param.Add("@IDNumber", tbStaff.IDNumber);//身份证号
            param.Add("@address", tbStaff.address);//住址
            param.Add("@remark", tbStaff.remark);//备注
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加门店员工
        /// </summary>
        /// <param name="tbStaff">门店员工</param>
        public virtual void Add(TBStaff tbStaff)
        {
            try
            {
                db.Open();
                Add(db,tbStaff);
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
        /// 修改门店员工
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbStaff">门店员工</param>
        public virtual void Edit(DataAccess data,TBStaff tbStaff)
        {
            string strSQL = "update TBStaff set siteId=@siteId,agentId=@agentId,staffName=@staffName,status=@status,telephone=@telephone,IDNumber=@IDNumber,address=@address,remark=@remark where staffId=@staffId";
            Param param = new Param();
            param.Clear();
            param.Add("@siteId", tbStaff.siteId);//门店编号
            param.Add("@agentId", tbStaff.agentId);//代理商编号
            param.Add("@staffName", tbStaff.staffName);//员工姓名
            param.Add("@status", tbStaff.status);//使用状态
            param.Add("@telephone", tbStaff.telephone);//手机号码
            param.Add("@IDNumber", tbStaff.IDNumber);//身份证号
            param.Add("@address", tbStaff.address);//住址
            param.Add("@remark", tbStaff.remark);//备注
            param.Add("@staffId", tbStaff.staffId);//员工编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改门店员工
        /// </summary>
        /// <param name="tbStaff">门店员工</param>
        public virtual void Edit(TBStaff tbStaff)
        {
            try
            {
                db.Open();
                Edit(db,tbStaff);
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
        /// 删除门店员工
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="staffId">员工编号</param>
        public virtual void Delete(DataAccess data,string staffId)
        {
            string strSQL = "delete from TBStaff where staffId=@staffId";
            Param param = new Param();
            param.Clear();
            param.Add("@staffId", staffId);//员工编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除门店员工
        /// </summary>
        /// <param name="staffId">员工编号</param>
        public virtual void Delete(string staffId)
        {
            try
            {
                db.Open();
                Delete(db,staffId);
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
        /// 获取门店员工
        /// </summary>
        /// <param name="staffId">员工编号</param>
        /// <returns>门店员工对象</returns>
        public virtual TBStaff Get(string staffId)
        {
            TBStaff tbStaff=null;
            try
            {
                string strSQL = "select * from TBStaff where staffId=@staffId";
                Param param = new Param();
                param.Clear();
                param.Add("@staffId", staffId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbStaff=ReadData(dr);
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
            return tbStaff;
        }
        
        /// <summary>
        /// 获取列表(门店员工)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>门店员工列表对象</returns>
        public virtual List<TBStaff> GetList(string strSQL,Param param)
        {
            List<TBStaff> list = new List<TBStaff>();
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
        /// 获取列表(门店员工)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>门店员工列表对象</returns>
        public virtual List<TBStaff> GetList(string field, string value)
        {
            List<TBStaff> list = new List<TBStaff>();
            try
            {
                string strSQL = "select * from TBStaff where " + field + "=@field";
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
        /// 获取DataSet(门店员工)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>门店员工DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBStaff");
        }
        
        /// <summary>
        /// 是否存在记录(门店员工)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBStaff where " + field + "=@field";
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
        /// 读取门店员工信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>门店员工对象</returns>
        protected virtual TBStaff ReadData(ComDataReader dr)
        {
            TBStaff tbStaff= new TBStaff();
            tbStaff.staffId= dr["staffId"].ToString();//员工编号
            tbStaff.siteId= dr["siteId"].ToString();//门店编号
            tbStaff.agentId= dr["agentId"].ToString();//代理商编号
            tbStaff.staffName= dr["staffName"].ToString();//员工姓名
            tbStaff.status= dr["status"].ToString();//使用状态
            tbStaff.telephone= dr["telephone"].ToString();//手机号码
            tbStaff.IDNumber= dr["IDNumber"].ToString();//身份证号
            tbStaff.address= dr["address"].ToString();//住址
            tbStaff.remark= dr["remark"].ToString();//备注
            return tbStaff;
        }
        
        
        #endregion
        
    }
}

