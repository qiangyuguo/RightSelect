using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.DBO
{
    /// <summary>
    /// 系统功能模块
    /// Author:代码生成器
    /// </summary>
    public class TSModuleDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接

        #region 代码生成器自动生成


        /// <summary>
        /// 增加系统功能模块
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsModule">系统功能模块</param>
        public virtual void Add(DataAccess data, TSModule tsModule)
        {
            string strSQL = "insert into TSModule (moduleId,moduleCode,moduleName,moduleURL,imgClass,parentId,moduleLayer,moduleIndex) values (@moduleId,@moduleCode,@moduleName,@moduleURL,@imgClass,@parentId,@moduleLayer,@moduleIndex)";
            Param param = new Param();
            param.Clear();
            param.Add("@moduleId", tsModule.moduleId);//模块编号
            param.Add("@moduleCode", tsModule.moduleCode);//模块代码
            param.Add("@moduleName", tsModule.moduleName);//模块名称
            param.Add("@moduleURL", tsModule.moduleURL);//模块路径
            param.Add("@imgClass", tsModule.imgClass);//图片样式
            param.Add("@parentId", tsModule.parentId);//父模块编号
            param.Add("@moduleLayer", tsModule.moduleLayer);//模块层次
            param.Add("@moduleIndex", tsModule.moduleIndex);//排列顺序
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 增加系统功能模块
        /// </summary>
        /// <param name="tsModule">系统功能模块</param>
        public virtual void Add(TSModule tsModule)
        {
            try
            {
                db.Open();
                Add(db, tsModule);
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
        /// 修改系统功能模块
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tsModule">系统功能模块</param>
        public virtual void Edit(DataAccess data, TSModule tsModule)
        {
            string strSQL = "update TSModule set moduleCode=@moduleCode,moduleName=@moduleName,moduleURL=@moduleURL,imgClass=@imgClass,parentId=@parentId,moduleLayer=@moduleLayer,moduleIndex=@moduleIndex where moduleId=@moduleId";
            Param param = new Param();
            param.Clear();
            param.Add("@moduleCode", tsModule.moduleCode);//模块代码
            param.Add("@moduleName", tsModule.moduleName);//模块名称
            param.Add("@moduleURL", tsModule.moduleURL);//模块路径
            param.Add("@imgClass", tsModule.imgClass);//图片样式
            param.Add("@parentId", tsModule.parentId);//父模块编号
            param.Add("@moduleLayer", tsModule.moduleLayer);//模块层次
            param.Add("@moduleIndex", tsModule.moduleIndex);//排列顺序
            param.Add("@moduleId", tsModule.moduleId);//模块编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 修改系统功能模块
        /// </summary>
        /// <param name="tsModule">系统功能模块</param>
        public virtual void Edit(TSModule tsModule)
        {
            try
            {
                db.Open();
                Edit(db, tsModule);
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
        /// 删除系统功能模块
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="moduleId">模块编号</param>
        public virtual void Delete(DataAccess data, string moduleId)
        {
            string strSQL = "delete from TSModule where moduleId=@moduleId";
            Param param = new Param();
            param.Clear();
            param.Add("@moduleId", moduleId);//模块编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 删除系统功能模块
        /// </summary>
        /// <param name="moduleId">模块编号</param>
        public virtual void Delete(string moduleId)
        {
            try
            {
                db.Open();
                Delete(db, moduleId);
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
        /// 获取系统功能模块
        /// </summary>
        /// <param name="moduleId">模块编号</param>
        /// <returns>系统功能模块对象</returns>
        public virtual TSModule Get(string moduleId)
        {
            TSModule tsModule = null;
            try
            {
                string strSQL = "select * from TSModule where moduleId=@moduleId";
                Param param = new Param();
                param.Clear();
                param.Add("@moduleId", moduleId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsModule = ReadData(dr);
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
            return tsModule;
        }

        public virtual List<TSModule> GetFirstTSModule(string roleID)
        {
            try
            {
                string strSQL = @"select b.* from tsright a
inner join tsModule b on a.MODULEID = b.MODULEID
where a.ROLEID =@roleID and ParentId=0";
                Param param = new Param();
                param.Clear();
                param.Add("@roleID", roleID);
                return GetList(strSQL, param);
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
        public virtual List<TSModule> GetSecondTSModule(string moduleId)
        {
            try
            {
                string strSQL = @"select b.* from tsright a
inner join tsModule b on a.MODULEID = b.MODULEID
where a.ROLEID =@roleID where ParentId=@moduleId";
                Param param = new Param();
                param.Clear();
                param.Add("@moduleId", moduleId);
                return GetList(strSQL, param);
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
        


        public virtual List<TSModule> GetTSModuleButton(string roleID, string ModuleId)
        {
            try
            {
                string strSQL = @"select b.*   from tsright a
inner join tsModule b on a.MODULEID = b.MODULEID
where a.ROLEID =@roleID and   b.PARENTID=@ModuleId ";
                Param param = new Param();
                param.Clear();
                param.Add("@roleID", roleID);
                param.Add("@ModuleId", ModuleId);
                return GetList(strSQL, param);
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
        /// 获取列表(系统功能模块)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>系统功能模块列表对象</returns>
        public virtual List<TSModule> GetList(string strSQL, Param param)
        {
            List<TSModule> list = new List<TSModule>();
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
        /// 获取列表(系统功能模块)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>系统功能模块列表对象</returns>
        public virtual List<TSModule> GetList(string field, string value)
        {
            List<TSModule> list = new List<TSModule>();
            try
            {
                string strSQL = "select * from TSModule where " + field + "=@field";
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
        /// 获取DataSet(系统功能模块)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>系统功能模块DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL, Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSModule");
        }

        /// <summary>
        /// 是否存在记录(系统功能模块)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSModule where " + field + "=@field";
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
        /// 读取系统功能模块信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>系统功能模块对象</returns>
        protected virtual TSModule ReadData(ComDataReader dr)
        {
            TSModule tsModule = new TSModule();
            tsModule.moduleId = dr["moduleId"].ToString();//模块编号
            if (dr["moduleCode"] != null)
            {
                tsModule.moduleCode = dr["moduleCode"].ToString();//模块代码
            }
            if (dr["moduleName"] != null)
            {
                tsModule.moduleName = dr["moduleName"].ToString();//模块名称
            }
            if (dr["moduleURL"] != null)
            {
                tsModule.moduleURL = dr["moduleURL"].ToString();//模块路径
            }
            if (dr["imgClass"] != null)
            {
                tsModule.imgClass = dr["imgClass"].ToString();//图片样式
            }
            if (dr["parentId"] != null)
            {
                tsModule.parentId = dr["parentId"].ToString();//父模块编号
            }
            if (dr["moduleLayer"] != null)
            {
                tsModule.moduleLayer = int.Parse(dr["moduleLayer"].ToString());//模块层次
            }
            if (dr["moduleIndex"] != null)
            {
                tsModule.moduleIndex= int.Parse(dr["moduleIndex"].ToString());//排列顺序
        }
            return tsModule;
        }
        
        
        #endregion
        
    }
}

