using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.UKey;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.UKey
{
    /// <summary>
    /// UKey信息
    /// Author:代码生成器
    /// </summary>
    public class UKeyBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBUKeyDAO tbUKeyDAO= new TBUKeyDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginUser">登录对象信息</param>
        /// </summary>
        public UKeyBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string uKeyId, string status, string siteName, string agentName,string agentId)
        {
            string strSQL = "select s.sitename,a.agentname,c.* from TBUKey c left join tbsite s on c.siteid=s.siteid left join tbagent a on  c.agentid=a.agentid where 1=1";
            if (!string.IsNullOrEmpty(uKeyId))
                strSQL += " and c.uKeyId='"+uKeyId+"'";
            if (!string.IsNullOrEmpty(status))
                strSQL += " and c.status='" + status + "'";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and c.agentId ='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteName))
                strSQL += " and s.siteName like '%" + siteName + "%'";
            if (!string.IsNullOrEmpty(agentName))
                strSQL += " and a.agentName like '%" + agentName + "%'";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定UKey信息
        /// <param name="uKeyId">加密狗编号</param>
        /// </summary>
        public void Load(string uKeyId)
        {
            try
            {
                TBUKey tbUKey=tbUKeyDAO.Get(uKeyId);
                WebJson.ToJson(context, tbUKey);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
       
        /// <summary>
        /// 发放加密狗
        /// </summary>
        /// <param name="startUKeyId"></param>
        /// <param name="endUKeyId"></param>
        /// <param name="uKeyNum"></param>
        public void Grant(string siteId, string startUKeyId, string endUKeyId, int uKeyNum)
        {
            try
            {
                List<TBUKey> tbUKeyList = tbUKeyDAO.GetListByStartEndUKey(startUKeyId, endUKeyId,0);
                //判断起始加密狗号-结束加密狗号和数量是否相等
                if (uKeyNum != tbUKeyList.Count)
                {
                    Message.error(context, "起始号:" + startUKeyId + "至" + endUKeyId + "和数量" + uKeyNum + "所对应的数据不相符");
                }
                else
                {
                    //遍历修改终端的状态为发放并且将终端发放的信息保存到终端日志表中
                    tbUKeyDAO.Grant(tbUKeyList, loginSession.GetUserId(), loginSession.GetUserName(), siteId);
                    Message.success(context, "加密狗发放成功");
                    loginSession.Log("起始号:" + startUKeyId + "至" + endUKeyId + "，数量" + uKeyNum + "加密狗发放成功");

                }
            }
            catch (Exception e)
            {
                Message.error(context, "加密狗发放失败");
                loginSession.Log(e.Message);
            }
        }

        /// <summary>
        /// 回收加密狗
        /// </summary>
        /// <param name="startUKeyId"></param>
        /// <param name="endUKeyId"></param>
        /// <param name="uKeyNum"></param>
        public void Recycle(string startUKeyId, string endUKeyId, int uKeyNum)
        {
            try
            {
                List<TBUKey> tbUKeyList = tbUKeyDAO.GetListByStartEndUKey(startUKeyId, endUKeyId,1);
                //判断起始加密狗号-结束加密狗号和数量是否相等
                if (uKeyNum != tbUKeyList.Count)
                {
                    Message.error(context, "起始号:" + startUKeyId + "至" + endUKeyId + "和数量" + uKeyNum + "所对应的数据不相符");
                }
                else
                {
                    //遍历修改终端的状态为发放并且将终端发放的信息保存到终端日志表中
                    tbUKeyDAO.Recycle(tbUKeyList, loginSession.GetUserId(), loginSession.GetUserName());
                    Message.success(context, "加密狗回收成功");
                    loginSession.Log("起始号:" + startUKeyId + "至" + endUKeyId + "，数量" + uKeyNum + "加密狗回收成功");

                }
            }
            catch (Exception e)
            {
                Message.error(context, "加密狗发放失败");
                loginSession.Log(e.Message);
            }
        }
        /// <summary>
        /// 加密狗激活
        /// </summary>
        /// <param name="ukeyId"></param>
        public void Activation(string uKeyId, string rowSiteId)
        {
            try
            {
                tbUKeyDAO.Activation(uKeyId, rowSiteId,loginSession.GetUserId(), loginSession.GetUserName());
                Message.success(context, "加密狗激活成功");
                loginSession.Log(uKeyId + "加密狗激活成功");
            }
            catch (Exception e)
            {
                Message.error(context, "加密狗激活失败");
                loginSession.Log(e.Message);
            }
        }
        /// <summary>
        /// 加密狗作废
        /// </summary>
        /// <param name="ukeyId"></param>
        public void Invalid(string uKeyId)
        {
            try
            {
                tbUKeyDAO.Invalid(uKeyId);
                Message.success(context, "加密狗作废成功");
                loginSession.Log(uKeyId + "加密狗作废成功");
            }
            catch (Exception e)
            {
                Message.error(context, "加密狗作废失败");
                loginSession.Log(e.Message);
            }
        }
       
        
    }
}

