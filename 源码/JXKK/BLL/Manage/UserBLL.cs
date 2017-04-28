using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Manage;
using Com.ZY.JXKK.Model;
using System.Text;

namespace Com.ZY.JXKK.BLL.Manage
{
    /// <summary>
    /// 系统用户
    /// Author:代码生成器
    /// </summary>
    public class UserBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TSUserDAO tsUserDAO= new TSUserDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public UserBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }

        /// <summary>
        /// 加载DataGrid
        /// </summary>
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// <param name="orgId">机构编号</param>
        /// <param name="deptId">部门编号</param>
        /// <param name="userName">用户名称</param>
        public void LoadGrid(int page, int rows, string deptId, string userName)
        {
            string strSQL = " select TOP (100) PERCENT  a.*,b.deptName from TSUser a ,TSDept b";
            strSQL += " where a.deptId=b.deptId and b.status='1' ";
            if (deptId != null && !"".Equals(deptId))
                strSQL += " and b.deptId = '" + deptId + "' ";
            if (userName != null && !"".Equals(userName))
                strSQL += " and a.userName = '" + userName + "' ";
            strSQL += " order by a.userId asc";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定系统用户
        /// <param name="userId">用户编号</param>
        /// </summary>
        public void Load(string userId)
        {
            try
            {
                TSUser tsUser=tsUserDAO.Get(userId);
                tsUser.status = "1".Equals(tsUser.status) ? "on" : "off";
                tsUser.roleIds = "'" + tsUser.roleIds.Replace(",","','") + "'";
                List<TSRole> listRole = new TSRoleDAO().GetList("select * from TSRole where status='1' and roleId in (" + tsUser.roleIds + ")", new Param());
                tsUser.roleIds = "";
                foreach (TSRole tsRole in listRole)
                {
                    if(string.IsNullOrWhiteSpace(tsUser.roleIds))
                        tsUser.roleIds = tsRole.roleId;
                    else
                        tsUser.roleIds += "," + tsRole.roleId;
                }
                WebJson.ToJson(context, tsUser);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        
        /// <summary>
        /// 增加系统用户
        /// <param name="tsUser">系统用户</param>
        /// </summary>
        public void Add(TSUser tsUser)
        {
            //判断是否帐号重复
            if (tsUserDAO.Exist("userCode", tsUser.userCode))
            {
                Message.error(context, "帐号重复请重新输入！");
                return;
            }

            try
            {
                tsUser.userId = commonDao.GetMaxNo("TSUser", "", 6);
                tsUser.userPwd = Encrypt.ConvertPwd(tsUser.userId,tsUser.userPwd);
                tsUser.status = tsUser.status == null ? "0" : "1";
                tsUserDAO.Add(tsUser);
                Message.success(context, "用户增加成功");
                loginSession.Log(tsUser.userName + "用户增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "用户增加失败");
                loginSession.Log(e.Message);
            }
        }
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userId"></param>
        public void PwdReset(string userId)
        {
            TSUser tsUser = tsUserDAO.Get(userId);
            try
            {
                string password = Encrypt.ConvertPwd(tsUser.userId, tsUser.userCode);
                tsUserDAO.ChangePwd(tsUser.userId, password);
                Message.success(context, "用户密码重置成功");
                loginSession.Log(tsUser.userName + "[" + tsUser.userId + "]用户密码重置成功");
            }
            catch (Exception e)
            {
                Message.error(context, "用户修改失败");
                loginSession.Log(e.Message);
            }
        }
        /// <summary>
        /// 修改系统用户
        /// <param name="tsUser">系统用户</param>
        /// </summary>
        public void Edit(TSUser tsUser)
        {
            //判断是否帐号重复
            List<TSUser> list = tsUserDAO.GetList("userCode", tsUser.userCode);
            if (list.Count > 0 && !tsUser.userId.Equals(list[0].userId))
            {
                Message.error(context, "帐号重复请重新输入！");
                return;
            }

            try
            {
                tsUser.status = tsUser.status == null ? "0" : "1";
                tsUserDAO.Edit(tsUser);
                Message.success(context, "用户修改成功");
                loginSession.Log(tsUser.userName + "[" + tsUser.userId + "]用户修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "用户修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除系统用户
        /// <param name="userId">用户编号</param>
        /// </summary>
        public void Delete(string userId,string loginUser)
        {
            if (userId.Equals(loginUser))
            {
                Message.error(context, "不能删除当前登录用户！");
                return;
            }
            try
            {
                tsUserDAO.Delete(userId);
                Message.success(context, "用户删除成功");
                loginSession.Log(userId + "编号用户删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "用户删除失败");
                loginSession.Log(e.Message);
            }
        }

    }
}

