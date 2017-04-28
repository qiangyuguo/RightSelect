using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model.Agent;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 代理系统功能模块
    /// Author:代码生成器
    /// </summary>
    public class TSAgentModuleDAO
    {
        private DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        
        #region 代码生成器自动生成
        
        
        /// <summary>
        /// 增加代理系统功能模块
        /// <param name="data">数据库连接</param>
        /// <param name="tsAgentModule">代理系统功能模块</param>
        /// </summary>
        public void Add(DataAccess data,TSAgentModule tsAgentModule)
        {
            string strSQL = "insert into TSAgentModule (moduleId,moduleCode,moduleName,moduleURL,imgClass,parentId,moduleLayer,moduleIndex) values (:moduleId,:moduleCode,:moduleName,:moduleURL,:imgClass,:parentId,:moduleLayer,:moduleIndex)";
            Param param = new Param();
            param.Clear();
            param.Add(":moduleId", tsAgentModule.moduleId);//模块编号
            param.Add(":moduleCode", tsAgentModule.moduleCode);//模块代码
            param.Add(":moduleName", tsAgentModule.moduleName);//模块名称
            param.Add(":moduleURL", tsAgentModule.moduleURL);//模块路径
            param.Add(":imgClass", tsAgentModule.imgClass);//图片样式
            param.Add(":parentId", tsAgentModule.parentId);//父模块编号
            param.Add(":moduleLayer", tsAgentModule.moduleLayer);//模块层次
            param.Add(":moduleIndex", tsAgentModule.moduleIndex);//排列顺序
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 增加代理系统功能模块
        /// <param name="tsAgentModule">代理系统功能模块</param>
        /// </summary>
        public void Add(TSAgentModule tsAgentModule)
        {
            try
            {
                db.Open();
                Add(db,tsAgentModule);
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
        /// 修改代理系统功能模块
        /// <param name="data">数据库连接</param>
        /// <param name="tsAgentModule">代理系统功能模块</param>
        /// </summary>
        public void Edit(DataAccess data,TSAgentModule tsAgentModule)
        {
            string strSQL = "update TSAgentModule set moduleCode=:moduleCode,moduleName=:moduleName,moduleURL=:moduleURL,imgClass=:imgClass,parentId=:parentId,moduleLayer=:moduleLayer,moduleIndex=:moduleIndex where moduleId=:moduleId";
            Param param = new Param();
            param.Clear();
            param.Add(":moduleCode", tsAgentModule.moduleCode);//模块代码
            param.Add(":moduleName", tsAgentModule.moduleName);//模块名称
            param.Add(":moduleURL", tsAgentModule.moduleURL);//模块路径
            param.Add(":imgClass", tsAgentModule.imgClass);//图片样式
            param.Add(":parentId", tsAgentModule.parentId);//父模块编号
            param.Add(":moduleLayer", tsAgentModule.moduleLayer);//模块层次
            param.Add(":moduleIndex", tsAgentModule.moduleIndex);//排列顺序
            param.Add(":moduleId", tsAgentModule.moduleId);//模块编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 修改代理系统功能模块
        /// <param name="tsAgentModule">代理系统功能模块</param>
        /// </summary>
        public void Edit(TSAgentModule tsAgentModule)
        {
            try
            {
                db.Open();
                Edit(db,tsAgentModule);
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
        /// 删除代理系统功能模块
        /// <param name="data">数据库连接</param>
        /// <param name="moduleId">模块编号</param>
        /// </summary>
        public void Delete(DataAccess data,string moduleId)
        {
            string strSQL = "delete from TSAgentModule where moduleId=:moduleId";
            Param param = new Param();
            param.Clear();
            param.Add(":moduleId", moduleId);//模块编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
        
        /// <summary>
        /// 删除代理系统功能模块
        /// <param name="moduleId">模块编号</param>
        /// </summary>
        public void Delete(string moduleId)
        {
            try
            {
                db.Open();
                Delete(db,moduleId);
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
        /// 获取代理系统功能模块
        /// <param name="moduleId">模块编号</param>
        /// </summary>
        /// <returns>代理系统功能模块对象</returns>
        public TSAgentModule Get(string moduleId)
        {
            TSAgentModule tsAgentModule=null;
            try
            {
                string strSQL = "select * from TSAgentModule where moduleId=:moduleId";
                Param param = new Param();
                param.Clear();
                param.Add(":moduleId", moduleId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tsAgentModule=ReadData(dr);
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
            return tsAgentModule;
        }
        
        /// <summary>
        /// 获取列表(代理系统功能模块)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理系统功能模块列表对象</returns>
        public List<TSAgentModule> GetList(string strSQL,Param param)
        {
            List<TSAgentModule> list = new List<TSAgentModule>();
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
        /// 获取列表(代理系统功能模块)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>代理系统功能模块列表对象</returns>
        public List<TSAgentModule> GetList(string field, string value)
        {
            List<TSAgentModule> list = new List<TSAgentModule>();
            try
            {
                string strSQL = "select * from TSAgentModule where " + field + "=:field";
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
        /// 获取DataSet(代理系统功能模块)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>代理系统功能模块DataSet</returns>
        public DataSet GetDataSet(string strSQL,Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TSAgentModule");
        }
        
        /// <summary>
        /// 是否存在记录(代理系统功能模块)
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// </summary>
        /// <returns>是否存在</returns>
        public bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TSAgentModule where " + field + "=:field";
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
        /// 读取代理系统功能模块信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>代理系统功能模块对象</returns>
        private TSAgentModule ReadData(ComDataReader dr)
        {
            TSAgentModule tsAgentModule= new TSAgentModule();
            tsAgentModule.moduleId= dr["moduleId"].ToString();//模块编号
            tsAgentModule.moduleCode= dr["moduleCode"].ToString();//模块代码
            tsAgentModule.moduleName= dr["moduleName"].ToString();//模块名称
            tsAgentModule.moduleURL= dr["moduleURL"].ToString();//模块路径
            tsAgentModule.imgClass= dr["imgClass"].ToString();//图片样式
            tsAgentModule.parentId= dr["parentId"].ToString();//父模块编号
            tsAgentModule.moduleLayer= int.Parse(dr["moduleLayer"].ToString());//模块层次
            tsAgentModule.moduleIndex= int.Parse(dr["moduleIndex"].ToString());//排列顺序
            return tsAgentModule;
        }
        
        
        #endregion
        
    }
}

