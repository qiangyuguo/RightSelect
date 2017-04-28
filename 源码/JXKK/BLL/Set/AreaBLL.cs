using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Set;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.Json;

namespace Com.ZY.JXKK.BLL.Set
{
    /// <summary>
    /// 区域设置
    /// Author:代码生成器
    /// </summary>
    public class AreaBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBAreaDAO tbAreaDAO= new TBAreaDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public AreaBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }

        /// <summary>
        /// 获取指定区域信息
        /// <param name="areaId">区域编号</param>
        /// </summary>
        public TBArea Get(string areaId)
        {
            TBArea tbArea = new TBArea();
            try
            {
                tbArea = tbAreaDAO.Get(areaId);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
            return tbArea;
        }
        /// <summary>
        /// 显示模块树
        /// </summary>
        public void LoadTree()
        {
            DataSet ds = tbAreaDAO.GetDataSet("select * from TBArea",null);
            List<Tree<TBArea>> list = new List<Tree<TBArea>>(1);
            Tree<TBArea> treeNode = new Tree<TBArea>();
            treeNode.text = "系统区域";//节点名称
            TBArea tsArea = new TBArea();
            tsArea.areaId = "0";
            tsArea.areaCode = "";
            tsArea.areaName = "";
            tsArea.parentId = "";
            tsArea.isUse = "1";
            tsArea.areaLayer = 0;
            tsArea.areaIndex = 0;
            treeNode.attributes = tsArea;
            AddNode(treeNode, ds);//遍历子区域
            list.Add(treeNode);
            WebJson.ToJson(context, list);
        }

        /// <summary>
        /// 遍历子模块
        /// </summary>
        /// <param name="parentNode">父模块节点</param>
        /// <param name="ds">模块记录集</param>
        /// <param name="roleRight">角色权限模块</param>
        private void AddNode(Tree<TBArea> parentNode, DataSet ds)
        {
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.RowFilter = "parentId='" + parentNode.attributes.areaId + "'";
            dv.Sort = "areaIndex desc";
            for (int i = 0; i < dv.Count; i++)
            {
                Tree<TBArea> treeNode = new Tree<TBArea>();
                treeNode.text = dv[i]["areaName"].ToString();//节点名称
                TBArea tbArea = new TBArea();
                tbArea.areaId = dv[i]["areaId"].ToString();
                tbArea.areaCode = dv[i]["areaCode"].ToString();
                tbArea.areaName = dv[i]["areaName"].ToString();
                tbArea.isUse = dv[i]["isUse"].ToString();
                tbArea.parentId = dv[i]["parentId"].ToString();
                tbArea.areaLayer = int.Parse(dv[i]["areaLayer"].ToString());
                tbArea.areaIndex = int.Parse(dv[i]["areaIndex"].ToString());
                treeNode.attributes = tbArea;
                AddNode(treeNode, ds);//遍历子模块
                parentNode.children.Add(treeNode);//添加子模块节点
            }
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows)
        {
            string strSQL = "select * from TBArea";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定区域设置
        /// <param name="areaId">区域编号</param>
        /// </summary>
        public void Load(string areaId)
        {
            try
            {
                TBArea tbArea=tbAreaDAO.Get(areaId);
                tbArea.isUse = "1".Equals(tbArea.isUse) ? "on" : "off";
                WebJson.ToJson(context, tbArea);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加区域设置
        /// <param name="tbArea">区域设置</param>
        /// </summary>
        public void Add(TBArea tbArea)
        {
            try
            {
                tbArea.areaId = commonDao.GetMaxNo("TBArea", "", 6);
                tbArea.isUse = tbArea.isUse == null ? "0" : "1";
                tbAreaDAO.Add(tbArea);
                Message.success(context, "区域设置增加成功");
                loginSession.Log("XXXXXX区域设置增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "区域设置增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改区域设置
        /// <param name="tbArea">区域设置</param>
        /// </summary>
        public void Edit(TBArea tbArea)
        {
            try
            {
                tbArea.isUse = tbArea.isUse == null ? "0" : "1";
                tbAreaDAO.Edit(tbArea);
                Message.success(context, "区域设置修改成功");
                loginSession.Log("XXXXXX区域设置修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "区域设置修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除区域设置
        /// <param name="areaId">区域编号</param>
        /// </summary>
        public void Delete(string areaId)
        {
            try
            {
                tbAreaDAO.Delete(areaId);
                Message.success(context, "区域设置删除成功");
                loginSession.Log("XXXXXX区域设置删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "区域设置删除失败");
                loginSession.Log(e.Message);
            }
        }

        /// <summary>
        /// 获取DataSet(区域设置)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>区域设置DataSet</returns>
        public  DataSet GetDataSet(string strSQL)
        {
            Param param = new Param();
            return tbAreaDAO.GetDataSet(strSQL, param);
        }

        
    }
}

