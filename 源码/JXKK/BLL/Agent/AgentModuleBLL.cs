using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Agent;
using Com.ZY.JXKK.Model;
using System.Collections;
using Com.ZY.JXKK.Json;

namespace Com.ZY.JXKK.BLL.Agent
{
    /// <summary>
    /// 代理系统功能模块
    /// Author:代码生成器
    /// </summary>
    public class AgentModuleBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TSAgentModuleDAO tsAgentModuleDAO= new TSAgentModuleDAO();

        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public AgentModuleBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        /// <summary>
        /// 显示模块树
        /// </summary>
        public void LoadTree(string roleId)
        {
            DataSet ds = tsAgentModuleDAO.GetDataSet("select * from TSAgentModule",null);
            Hashtable tsAgentRight = new TSAgentRightDAO().GetAgentModuleIdHash(roleId);
            List<Tree<TSAgentModule>> list = new List<Tree<TSAgentModule>>(1);
            Tree<TSAgentModule> treeNode = new Tree<TSAgentModule>();
            treeNode.text = "系统平台模块";//节点名称
            TSAgentModule tsAgentModule = new TSAgentModule();
            tsAgentModule.moduleId = "0";//模块编号
            tsAgentModule.moduleCode = "";//模块代码
            tsAgentModule.moduleName = "";//模块名称
            tsAgentModule.moduleURL = "";//模块URL
            tsAgentModule.imgClass = "";//模块图片样式
            tsAgentModule.parentId = "";//父模块编号（"0"代表无父模块）
            tsAgentModule.moduleLayer = 0;//模块所属层次
            tsAgentModule.moduleIndex = 0;//模块索引
            treeNode.attributes = tsAgentModule;
            AddNode(treeNode, ds, tsAgentRight);//遍历子模块
            list.Add(treeNode);
            WebJson.ToJson(context, list);
        }

        /// <summary>
        /// 遍历子模块
        /// </summary>
        /// <param name="parentNode">父模块节点</param>
        /// <param name="ds">模块记录集</param>
        /// <param name="roleRight">角色权限模块</param>
        private void AddNode(Tree<TSAgentModule> parentNode, DataSet ds, Hashtable roleRight)
        {
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.RowFilter = "parentId='" + parentNode.attributes.moduleId + "'";
            dv.Sort = "moduleIndex desc";
            for (int i = 0; i < dv.Count; i++)
            {
                Tree<TSAgentModule> treeNode = new Tree<TSAgentModule>();
                treeNode.text = dv[i]["moduleName"].ToString();//节点名称
                TSAgentModule tsAgentModule = new TSAgentModule();
                tsAgentModule.moduleId = dv[i]["moduleId"].ToString();//模块编号
                tsAgentModule.moduleCode = dv[i]["moduleCode"].ToString();//模块代码
                tsAgentModule.moduleName = dv[i]["moduleName"].ToString();//模块名称
                tsAgentModule.moduleURL = dv[i]["moduleURL"].ToString();//模块URL
                tsAgentModule.imgClass = dv[i]["imgClass"].ToString();//模块图片样式
                tsAgentModule.parentId = dv[i]["parentId"].ToString();//父模块编号（"0"代表无父模块）
                tsAgentModule.moduleLayer = int.Parse(dv[i]["moduleLayer"].ToString());//模块所属层次
                tsAgentModule.moduleIndex = int.Parse(dv[i]["moduleIndex"].ToString());//模块索引
                treeNode.attributes = tsAgentModule;
                AddNode(treeNode, ds, roleRight);//遍历子模块
                if (treeNode.children.Count == 0)
                    treeNode.need_to_json_checked = roleRight.ContainsKey(tsAgentModule.moduleId);
                parentNode.children.Add(treeNode);//添加子模块节点
            }
        }

        /// <summary>
        /// 加载指定模块信息
        /// </summary>
        /// <param name="moduleId">模块编号</param>
        public void Load(string moduleId)
        {
            try
            {
                TSAgentModule module = tsAgentModuleDAO.Get(moduleId);
                WebJson.ToJson(context, module);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="tsAgentModule">模块对象</param>
        public void Add(TSAgentModule tsAgentModule)
        {
            //检查模块代码是否重复
            if (tsAgentModuleDAO.GetList("moduleCode", tsAgentModule.moduleCode).Count > 0)
            {
                Message.error(context, "模块代码不允许重复");
                return;
            }

            try
            {
                tsAgentModule.moduleId = commonDao.GetMaxNo("TSModule", "", 6);
                tsAgentModuleDAO.Add(tsAgentModule);
                Message.success(context, "模块增加成功");
                loginSession.Log(tsAgentModule.moduleName + "模块增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "模块增加失败");
                loginSession.Log(e.Message);
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="tsAgentModule">模块对象</param>
        public void Edit(TSAgentModule tsAgentModule)
        {
            //检查模块代码是否修改如果修改是否重复
            List<TSAgentModule> list = tsAgentModuleDAO.GetList("ModuleCode", tsAgentModule.moduleCode);
            if (list.Count > 0 && (!tsAgentModule.moduleId.Equals(list[0].moduleId)))
            {
                Message.error(context, "模块代码不允许重复");
                return;
            }

            try
            {
                tsAgentModuleDAO.Edit(tsAgentModule);
                Message.success(context, "模块修改成功");
                loginSession.Log(tsAgentModule.moduleName + "[" + tsAgentModule.moduleId + "]模块修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "模块修改失败");
                loginSession.Log(e.Message);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="moduleId">模块编号</param>
        public void Delete(string moduleId)
        {
            //检查是否存在子模块
            if (tsAgentModuleDAO.GetList("parentId", moduleId).Count > 0)
            {
                Message.error(context, "存在子模块不能删除，请先删除子模块！");
                return;
            }

            try
            {
                tsAgentModuleDAO.Delete(moduleId);
                Message.success(context, "模块删除成功");
                loginSession.Log(moduleId + "编号模块删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "模块删除失败");
                loginSession.Log(e.Message);
            }
        }
    }
}

