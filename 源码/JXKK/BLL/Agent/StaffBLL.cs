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
    /// 快开厅员工
    /// Author:代码生成器
    /// </summary>
    public class StaffBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBStaffDAO tbStaffDAO= new TBStaffDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginAgentUser">登录对象信息</param>
        /// </summary>
        public StaffBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string roleType, string userId, string staffName)
        {
            string strSQL = "select a.*,b.sitename,c.roleId,d.rolename from tbstaff a,tbsite b,tsagentuser c,tsagentrole d where a.siteid=b.siteid and a.staffid=c.userid and c.roleid=d.roleid and c.roleId!='001'";
            if (!string.IsNullOrEmpty(staffName))
                strSQL += " and a.staffName like '%" + staffName + "%'";
            if (roleType == "0")//根据代理商查询员工
            {
                strSQL += " and a.agentId='" + userId + "'";
            }
            else //根据快开厅查询员工
            {
                strSQL += " and a.siteId='" + userId + "'";
            }
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }

        public List<TBStaff> GetList(string roleType, string userId, string staffId)
        {
            string strSQL = "select a.*,b.sitename,c.roleId,d.rolename from tbstaff a,tbsite b,tsagentuser c,tsagentrole d where a.siteid=b.siteid and a.staffid=c.userid and c.roleid=d.roleid and c.roleId!='001'";
            if (!string.IsNullOrEmpty(staffId))
                strSQL += " and a.staffId = '" + staffId + "'";
            if (roleType == "0")//根据代理商查询员工
            {
                strSQL += " and a.agentId='" + userId + "'";
            }
            else //根据快开厅查询员工
            {
                strSQL += " and a.siteId='" + userId + "'";
            }
            strSQL += " order by staffid";
            Param param = new Param();
            List<TBStaff> tbStaffList = tbStaffDAO.GetList(strSQL, param);
            return tbStaffList;
        }
        
        /// <summary>
        /// 加载指定快开厅员工
        /// <param name="staffId">员工编号</param>
        /// </summary>
        public void Load(string staffId)
        {
            try
            {
                TBStaffClon tbStaffClon = tbStaffDAO.GetClon(staffId);
                tbStaffClon.status = "1".Equals(tbStaffClon.status) ? "on" : "off";
                WebJson.ToJson(context, tbStaffClon);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        /// <summary>
        /// 获取指定快开厅员工
        /// <param name="staffId">员工编号</param>
        /// </summary>
        public TBStaff Get(string staffId)
        {
            TBStaff tbStaff = new TBStaff();
            try
            {
                tbStaff = tbStaffDAO.Get(staffId);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
            return tbStaff;
        }
        /// <summary>
        /// 增加快开厅员工
        /// <param name="tbStaff">快开厅员工</param>
        /// </summary>
        public void Add(TBStaff tbStaff,TSAgentUser tsAgentUser)
        {
            TSAgentUserDAO tsAgentUserDAO = new TSAgentUserDAO();
            //判断是否帐号重复
            if (tsAgentUserDAO.Exist("userCode", tsAgentUser.userCode))
            {
                Message.error(context, "用户帐号重复请重新输入！");
                return;
            }
            try
            {
                tbStaff.staffId = commonDao.GetMaxNo("TBStaff", "", 6);
                tbStaff.status = tbStaff.status == null ? "0" : "1";
                tbStaffDAO.AddTrans(tbStaff,tsAgentUser);
                Message.success(context, "快开厅员工增加成功,默认密码为帐号,登录后建议修改!");
                loginSession.Log(tbStaff.staffName+"快开厅员工增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "快开厅员工增加失败");
                loginSession.Log(e.Message);
            }
        }

        /// <summary>
        /// 重置员工密码
        /// </summary>
        /// <param name="staffId"></param>
        /// <param name="roleType"></param>
        public void PawReset(string staffId,string roleType)
        {
            TSAgentUser tsAgentUser = new TSAgentUser();
            string strSQL = "select * from tsAgentUser where userId="+staffId+" and roleId!=001";
            TSAgentUserDAO tsAgentUserDao = new TSAgentUserDAO();
            Param param = new Param();
            tsAgentUser = tsAgentUserDao.GetList(strSQL, param)[0];
            try
            {
                string userPwd = Encrypt.ConvertPwd(tsAgentUser.userId, tsAgentUser.userCode);
                tsAgentUserDao.ChangePwd(tsAgentUser.userId, userPwd, roleType);
                Message.success(context, "员工密码重置成功");
                loginSession.Log(staffId + "员工密码重置成功");
            }
            catch (Exception e)
            {
                Message.error(context, "员工密码重置失败 ");
                loginSession.Log(e.Message);
            }
        }
        /// <summary>
        /// 修改快开厅员工
        /// <param name="tbStaff">快开厅员工</param>
        /// </summary>
        public void Edit(TBStaff tbStaff, TSAgentUser tsAgentUser)
        {
            TSAgentUserDAO tsAgentUserDAO = new TSAgentUserDAO();
            tsAgentUser.userId = tbStaff.staffId;
            //判断是否帐号重复
            List<TSAgentUser> list = tsAgentUserDAO.GetList("userCode", tsAgentUser.userCode);
            if (list.Count > 0 && !tsAgentUser.userId.Equals(list[0].userId))
            {
                Message.error(context, "帐号重复请重新输入！");
                return;
            }
            try
            {
                tbStaff.status = tbStaff.status == null ? "0" : "1";
                tbStaffDAO.EditTrans(tbStaff, tsAgentUser);
                Message.success(context, "快开厅员工修改成功");
                loginSession.Log(tbStaff.staffName+"快开厅员工修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "快开厅员工修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除快开厅员工
        /// <param name="staffId">员工编号</param>
        /// </summary>
        public void Delete(string staffId,string roleId,string loginStaffId)
        {
            if (loginStaffId.Equals(staffId))
            {
                Message.error(context, "不能删除当前登录员工账户！");
                return;
            }
            try
            {
                tbStaffDAO.Delete(staffId, roleId);
                Message.success(context, "快开厅员工删除成功");
                loginSession.Log(staffId+"快开厅员工删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "快开厅员工删除失败");
                loginSession.Log(e.Message);
            }
        }


        

       
    }
}

