using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Terminal;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.Terminal
{
    /// <summary>
    /// 终端
    /// Author:代码生成器
    /// </summary>
    public class TerminalBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBTerminalDAO tbTerminalDAO= new TBTerminalDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public TerminalBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string terminalId, string status, string supplierCode, string supplierBatch, string agentId, string siteId)
        {
            string strSQL = "select s.sitename,a.agentname,c.* from TBTerminal c left join tbsite s on c.siteid=s.siteid left join tbagent a on  c.agentid=a.agentid where 1=1";
            if (!string.IsNullOrEmpty(terminalId))
                strSQL += " and c.terminalId='" + terminalId + "'";
            if (!string.IsNullOrEmpty(status))
                strSQL += " and c.status='" + status + "'";
            if (!string.IsNullOrEmpty(supplierCode))
                strSQL += " and c.supplierCode='" + supplierCode + "'";
            if (!string.IsNullOrEmpty(supplierBatch))
                strSQL += " and c.supplierBatch='" + supplierBatch + "'";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and c.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and c.siteId='" + siteId + "'";
            strSQL += " order by c.terminalId desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }


        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGridOnLine(int page, int rows, string agentId, string siteId,string terminalId, string onlineStatus, int offlineMinutes,string startDate, string endDate)
        {
            string strSQL = @"select * from (select s.sitename,a.agentname,case when ceil(((sysdate - checktime)) * 24 * 60)>"+offlineMinutes+@" then 1 else 0 end as onlinestatus,c.* from TBTerminal c 
                                left join tbsite s on c.siteid=s.siteid
                                left join tbagent a on  c.agentid=a.agentid) t where 1=1";
            if (!string.IsNullOrEmpty(terminalId))
                strSQL += " and t.terminalId='" + terminalId + "'";
            if (!string.IsNullOrEmpty(onlineStatus))
                strSQL += " and t.onlineStatus='" + onlineStatus + "'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and t.checkTime>=to_date('" + startDate + " 00:00:00','yyyy-MM-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and t.checkTime<=to_date('" + endDate + " 23:59:59','yyyy-MM-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and t.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and t.siteId='" + siteId + "'";
            strSQL += " order by t.terminalId desc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定终端
        /// <param name="terminalId">终端编号</param>
        /// </summary>
        public void Load(string terminalId)
        {
            try
            {
                TBTerminal tbTerminal=tbTerminalDAO.Get(terminalId);
                tbTerminal.updateStatus = "1".Equals(tbTerminal.updateStatus) ? "on" : "off";
                WebJson.ToJson(context, tbTerminal);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加终端
        /// <param name="tbTerminal">终端</param>
        /// </summary>
        public void Add(TBTerminal tbTerminal)
        {
            //判断是否帐号重复
            if (tbTerminalDAO.Exist("terminalId", tbTerminal.terminalId))
            {
                Message.error(context, "终端号重复请重新输入！");
                return;
            }
            try
            {
                tbTerminalDAO.Add(tbTerminal);
                Message.success(context, "终端入库成功");
                loginSession.Log(tbTerminal.terminalId + "终端入库成功");
            }
            catch (Exception e)
            {
                Message.error(context, "终端入库失败");
                loginSession.Log(e.Message);
            }
        }
      /// <summary>
        /// 发放终端
      /// </summary>
      /// <param name="startTerminalId"></param>
      /// <param name="endTerminalId"></param>
      /// <param name="terminalNum"></param>
        public void Grant(string siteId, string startTerminalId, string endTerminalId, int terminalNum)
        {
            try
            {
                List<TBTerminal> tbTerminalList = tbTerminalDAO.GetListByStartEndTerminal(startTerminalId, endTerminalId,0);
                //判断起始终端号-结束终端号和数量是否相等
                if (terminalNum != tbTerminalList.Count)
                {
                    Message.error(context, "起始终端号:" + startTerminalId + "至" + endTerminalId + "和数量" + terminalNum + "所对应的数据不相符");
                }
                else
                {
                    //遍历修改终端的状态为发放并且将终端发放的信息保存到终端日志表中
                    tbTerminalDAO.Grant(tbTerminalList, loginSession.GetUserId(), loginSession.GetUserName(), siteId);
                    Message.success(context, "终端发放成功");
                    loginSession.Log("起始终端号:" + startTerminalId + "至" + endTerminalId + "，数量" + terminalNum + "终端发放成功");

                }
            }
            catch (Exception e)
            {
                Message.error(context, "终端发放失败");
                loginSession.Log(e.Message);
            }
        }

        /// <summary>
        /// 回收终端
        /// </summary>
        /// <param name="startTerminalId"></param>
        /// <param name="endTerminalId"></param>
        /// <param name="terminalNum"></param>
        public void Recycle(string startTerminalId, string endTerminalId, int terminalNum)
        {
            try
            {
                List<TBTerminal> tbTerminalList = tbTerminalDAO.GetListByStartEndTerminal(startTerminalId, endTerminalId,1);
                //判断起始终端号-结束终端号和数量是否相等
                if (terminalNum != tbTerminalList.Count)
                {
                    Message.error(context, "起始终端号:" + startTerminalId + "至" + endTerminalId + "和数量" + terminalNum + "所对应的数据不相符");
                }
                else
                {
                    //遍历修改终端的状态为发放并且将终端发放的信息保存到终端日志表中
                    tbTerminalDAO.Recycle(tbTerminalList, loginSession.GetUserId(), loginSession.GetUserName());
                    Message.success(context, "终端回收成功");
                    loginSession.Log("起始终端号:" + startTerminalId + "至" + endTerminalId + "，数量" + terminalNum + "终端回收成功");

                }
            }
            catch (Exception e)
            {
                Message.error(context, "终端回收失败");
                loginSession.Log(e.Message);
            }
        }
        /// <summary>
        /// 修改终端
        /// <param name="tbTerminal">终端</param>
        /// </summary>
        public void Maintence(TBTerminal tbTerminal)
        {
            try
            {
                tbTerminalDAO.Maintence(tbTerminal);
                Message.success(context, "终端操作成功");
                loginSession.Log(tbTerminal.terminalId + "终端操作成功");
            }
            catch (Exception e)
            {
                Message.error(context, "终端操作失败");
                loginSession.Log(e.Message);
            }
        }
        /// <summary>
        /// 修改更新状态
        /// <param name="tbTerminal">终端</param>
        /// </summary>
        public void EditUpdateStatus(TBTerminal tbTerminal)
        {
            try
            {
                tbTerminal.updateStatus = tbTerminal.updateStatus == null ? "0" : "1";
                tbTerminalDAO.EditUpdateStatus(tbTerminal);
                Message.success(context, "终端操作成功");
                loginSession.Log(tbTerminal.terminalId + "终端操作成功");
            }
            catch (Exception e)
            {
                Message.error(context, "终端操作失败");
                loginSession.Log(e.Message);
            }
        }
        /// <summary>
        /// 删除终端
        /// <param name="terminalId">终端编号</param>
        /// </summary>
        public void Delete(string terminalId)
        {
            try
            {
                tbTerminalDAO.Delete(terminalId);
                Message.success(context, "终端删除成功");
                loginSession.Log("XXXXXX终端删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "终端删除失败");
                loginSession.Log(e.Message);
            }
        }
       
    }
}

