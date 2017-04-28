using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Json;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Manage;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.Manage
{
    /// <summary>
    /// 系统功能模块
    /// Author:代码生成器
    /// </summary>
    public class ModuleBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TSModuleDAO tsModuleDAO= new TSModuleDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public ModuleBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }

        /// <summary>
        /// 显示模块树
        /// </summary>
        public void LoadTree(string roleId)
        {
            DataSet ds = tsModuleDAO.GetDataSet("select * from TSModule", null);
            Hashtable roleRight = new TSRightDAO().GetModuleIdHash(roleId);
            List<Tree<TSModule>> list = new List<Tree<TSModule>>(1);
            Tree<TSModule> treeNode = new Tree<TSModule>();
            treeNode.text = "系统平台模块";//节点名称
            TSModule tsModule = new TSModule();
            tsModule.moduleId = "0";//模块编号
            tsModule.moduleCode = "";//模块代码
            tsModule.moduleName = "";//模块名称
            tsModule.moduleURL = "";//模块URL
            tsModule.imgClass = "";//模块图片样式
            tsModule.parentId = "";//父模块编号（"0"代表无父模块）
            tsModule.moduleLayer = 0;//模块所属层次
            tsModule.moduleIndex = 0;//模块索引
            treeNode.attributes = tsModule;
            AddNode(treeNode, ds, roleRight);//遍历子模块
            list.Add(treeNode);
            WebJson.ToJson(context, list);
        }

        /// <summary>
        /// 遍历子模块
        /// </summary>
        /// <param name="parentNode">父模块节点</param>
        /// <param name="ds">模块记录集</param>
        /// <param name="roleRight">角色权限模块</param>
        private void AddNode(Tree<TSModule> parentNode, DataSet ds, Hashtable roleRight)
        {
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.RowFilter = "parentId='" + parentNode.attributes.moduleId + "'";
            dv.Sort = "moduleIndex desc";
            for (int i = 0; i < dv.Count; i++)
            {
                Tree<TSModule> treeNode = new Tree<TSModule>();
                treeNode.text = dv[i]["moduleName"].ToString();//节点名称
                TSModule tsModule = new TSModule();
                tsModule.moduleId = dv[i]["moduleId"].ToString();//模块编号
                tsModule.moduleCode = dv[i]["moduleCode"].ToString();//模块代码
                tsModule.moduleName = dv[i]["moduleName"].ToString();//模块名称
                tsModule.moduleURL = dv[i]["moduleURL"].ToString();//模块URL
                tsModule.imgClass = dv[i]["imgClass"].ToString();//模块图片样式
                tsModule.parentId = dv[i]["parentId"].ToString();//父模块编号（"0"代表无父模块）
                tsModule.moduleLayer = int.Parse(dv[i]["moduleLayer"].ToString());//模块所属层次
                tsModule.moduleIndex = int.Parse(dv[i]["moduleIndex"].ToString());//模块索引
                treeNode.attributes = tsModule;
                AddNode(treeNode, ds, roleRight);//遍历子模块
                if (treeNode.children.Count == 0)
                    treeNode.need_to_json_checked = roleRight.ContainsKey(tsModule.moduleId);
                parentNode.children.Add(treeNode);//添加子模块节点
            }
        }
        
        /// <summary>
        /// 加载指定系统功能模块
        /// <param name="moduleId">模块编号</param>
        /// </summary>
        public void Load(string moduleId)
        {
            try
            {
                TSModule tsModule=tsModuleDAO.Get(moduleId);
                WebJson.ToJson(context, tsModule);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }

        /// <summary>
        /// 增加系统功能模块
        /// <param name="tsModule">系统功能模块</param>
        /// </summary>
        public void Add(TSModule tsModule)
        {
            //检查模块代码是否重复
            if (tsModuleDAO.Exist("moduleCode", tsModule.moduleCode))
            {
                Message.error(context, "按钮模板名称不允许重复");
                return;
            }

            try
            {
                tsModule.moduleId = commonDao.GetMaxNo("TSModule", "", 6);
                tsModuleDAO.Add(tsModule);
                Message.success(context, "模块增加成功");
                loginSession.Log(tsModule.moduleName + "模块增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "模块增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改系统功能模块
        /// <param name="tsModule">系统功能模块</param>
        /// </summary>
        public void Edit(TSModule tsModule)
        {
            //检查模块代码是否修改如果修改是否重复
            List<TSModule> list = tsModuleDAO.GetList("ModuleCode", tsModule.moduleCode);
            if (list.Count > 0 && (!tsModule.moduleId.Equals(list[0].moduleId)))
            {
                Message.error(context, "按钮模板名称不允许重复");
                return;
            }

            try
            {
                tsModuleDAO.Edit(tsModule);
                Message.success(context, "模块修改成功");
                loginSession.Log(tsModule.moduleName + "[" + tsModule.moduleId + "]模块修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "模块修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除系统功能模块
        /// <param name="moduleId">模块编号</param>
        /// </summary>
        public void Delete(string moduleId)
        {
            //检查是否存在子模块
            if (tsModuleDAO.GetList("parentId", moduleId).Count > 0)
            {
                Message.error(context, "存在子模块不能删除，请先删除子模块！");
                return;
            }

            try
            {
                tsModuleDAO.Delete(moduleId);
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

