using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Agent;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.Agent
{
    /// <summary>
    /// 代理账户明细
    /// Author:代码生成器
    /// </summary>
    public class AgentAccDetailBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信
        private CommonDao commonDao = new CommonDao();
        private TTAgentAccDetailDAO ttAgentAccDetailDAO= new TTAgentAccDetailDAO();
      
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public AgentAccDetailBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        /// <summary>
        /// 加载DataGrid
        /// </summary>
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// <param name="agentName">代理商名称</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        public void LoadGrid(int page, int rows, string agentId,string agentName, string startDate, string endDate)
        {
            string strSQL = "select a.* from TTAgentAccDetail a where 1=1";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and a.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(agentName))
                strSQL += " and a.agentName like '%" + agentName + "%'";
            if (!string.IsNullOrEmpty(startDate))
                strSQL += " and a.createTime >= To_date('" + startDate + " 00:00:00','yyyy-mm-dd hh24:mi:ss')";
            if (!string.IsNullOrEmpty(endDate))
                strSQL += " and a.createTime <= To_date('" + endDate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            strSQL += " order by a.agentId,a.createTime desc"; 
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定代理账户明细
        /// <param name="flowId">编号</param>
        /// </summary>
        public void Load(long flowId)
        {
            try
            {
                TTAgentAccDetail ttAgentAccDetail=ttAgentAccDetailDAO.Get(flowId);
                WebJson.ToJson(context, ttAgentAccDetail);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加代理账户明细
        /// <param name="ttAgentAccDetail">代理账户明细</param>
        /// </summary>
        public void Add(TTAgentAccDetail ttAgentAccDetail)
        {
            try
            {
                ttAgentAccDetailDAO.Add(ttAgentAccDetail);
                Message.success(context, "代理账户明细增加成功");
                loginSession.Log("XXXXXX代理账户明细增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理账户明细增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改代理账户明细
        /// <param name="ttAgentAccDetail">代理账户明细</param>
        /// </summary>
        public void Edit(TTAgentAccDetail ttAgentAccDetail)
        {
            try
            {
                ttAgentAccDetailDAO.Edit(ttAgentAccDetail);
                Message.success(context, "代理账户明细修改成功");
                loginSession.Log("XXXXXX代理账户明细修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理账户明细修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除代理账户明细
        /// <param name="flowId">编号</param>
        /// </summary>
        public void Delete(long flowId)
        {
            try
            {
                ttAgentAccDetailDAO.Delete(flowId);
                Message.success(context, "代理账户明细删除成功");
                loginSession.Log("XXXXXX代理账户明细删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "代理账户明细删除失败");
                loginSession.Log(e.Message);
            }
        }
        /// <summary>
        /// 根据条件分组获取代理商账户明细数据
        /// </summary>
        /// <param name="city">市</param>
        /// <param name="county">区县</param>
        /// <param name="siteId">快开厅</param>
        /// <param name="agentId">代理商</param>
        /// <param name="terminalId">终端号</param>
        /// <returns></returns>
        public List<TTAgentAccDetail> GetTTAgentAccDetailList(string city, string county, string siteId, string agentId, string terminalId)
        {
            List<TTAgentAccDetail> ttAgentAccDetailList = new List<TTAgentAccDetail>();
            string strSQL = @"  select aad.* from tbagent a right join (
                                select * from TTAgentAccDetail t where t.agentid in (select agentid from (select max(createtime) createtime,agentid from TTAgentAccDetail  
                                group by substr(createtime,0,10),agentid))
                                and t.createtime in(select createtime from (select max(createtime) createtime,agentid from TTAgentAccDetail  
                                group by substr(createtime,0,10),agentid))
                                order by t.agentid,t.createtime desc) aad
                                on a.agentid=aad.agentid where 1=1 ";
            if (!string.IsNullOrEmpty(agentId))
                strSQL += " and a.agentId='" + agentId + "'";
            if (!string.IsNullOrEmpty(siteId))
                strSQL += " and a.agentid=(select s.agentid from TBSITE s where s.siteid='"+siteId+"')";
            if (!string.IsNullOrEmpty(city) && string.IsNullOrEmpty(county))
                strSQL += " and a.areaId in(select areaid from tbarea start with areaid = '" + city + "'connect by prior areaid = parentid)";
            if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(county))
                strSQL += " and a.areaId='" + county + "'";
            strSQL += @"order by aad.createtime desc,aad.agentid";
            Param param = new Param();
            ttAgentAccDetailList =ttAgentAccDetailDAO.GetTTAgentAccDetailList(strSQL, param);
            return ttAgentAccDetailList;
        }

        public DataSet GetDataSet()
        {
            DataSet ds = new DataSet();
            ds = ttAgentAccDetailDAO.GetDataSet("select * from TTAgentAccDetail", null);
            return ds;
        }
    }
}

