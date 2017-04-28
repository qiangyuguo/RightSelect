<%@ WebHandler Language="C#" Class="Com.ZY.JXKK.WebAction.Set.TypeHttp" %>

using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.BLL.Set;
using Com.ZY.JXKK.Model.Set;

namespace Com.ZY.JXKK.WebAction.Set
{
    /// <summary>
    /// 类型设置
    /// Author:代码生成器
    /// </summary>
    public class TypeHttp: IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                LoginUser loginUser = new LoginUser(context, "Type");
                if (!loginUser.Pass)//权限验证
                {
                    return;
                }
                
                //加载DataGrid
                if (context.Request["action"] == "gridLoad")
                {
                    TypeBLL bll = new TypeBLL(context, loginUser);
                    int page = int.Parse(context.Request["page"]);
                    int rows = int.Parse(context.Request["rows"]);
                    bll.LoadGrid(page, rows);
                    return;
                }
                
                //加载信息
                if (context.Request["action"] == "load")
                {
                    TypeBLL bll = new TypeBLL(context, loginUser);
                    string typeCode=context.Request["typeCode"];//类型编号
                    string tableName=context.Request["tableName"];//使用表名
                    bll.Load(typeCode,tableName);
                    return;
                }
                
                //增加
                if (context.Request["action"] == "add")
                {
                    TypeBLL bll = new TypeBLL(context, loginUser);
                    TBType tbType= new TBType();
                    tbType.typeCode= context.Request["typeCode"];//类型编号
                    tbType.tableName= context.Request["tableName"];//使用表名
                    tbType.typeName= context.Request["typeName"];//类型名称
                    tbType.isUse= context.Request["isUse"];//使用状态
                    bll.Add(tbType);
                    return;
                }
                
                //修改
                if (context.Request["action"] == "edit")
                {
                    TypeBLL bll = new TypeBLL(context, loginUser);
                    TBType tbType= new TBType();
                    tbType.typeCode= context.Request["typeCode"];//类型编号
                    tbType.tableName= context.Request["tableName"];//使用表名
                    tbType.typeName= context.Request["typeName"];//类型名称
                    tbType.isUse= context.Request["isUse"];//使用状态
                    bll.Edit(tbType);
                    return;
                }
                
                //删除
                if (context.Request["action"] == "delete")
                {
                    TypeBLL bll = new TypeBLL(context, loginUser);
                    string typeCode=context.Request["typeCode"];//类型编号
                    string tableName=context.Request["tableName"];//使用表名
                    bll.Delete(typeCode,tableName);
                    return;
                }
                
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}

