﻿using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DAO.Manage;
using Com.ZY.JXKK.Json;

namespace Com.ZY.JXKK.BLL
{
    /// <summary>
    /// 主界面
    /// </summary>
    public class MainBll
    {
        private System.Web.HttpContext context;//HTTP请求上下文
        private LoginUser loginUser;//登录用户对象信息
        private TSModuleDAO tsModuleDAO = new TSModuleDAO();

        public MainBll(System.Web.HttpContext context, LoginUser loginUser)
        {
            this.context = context;
            this.loginUser = loginUser;
        }

        /// <summary>
        /// 加载主界面信息【部门名称、用户名称、菜单】
        /// </summary>
        /// <param name="context"></param>
        /// <param name="loginUser">登录用户信息</param>
        public void LoadMain()
        {
            SysMain main = new SysMain();
            DataView dv = new DataView();
            Hashtable moduleRight = new Hashtable();
            //获取所有模块，后面加 where moduleurl is not null 是为看只获取权限页面
            DataSet ds = tsModuleDAO.GetDataSet("select * from TSModule where moduleurl is not null and isEnable=1", null);
            //获取用户拥有的模块
            Hashtable roleRight = new TSRightDAO().GetModuleIdHash(loginUser.RoleIds);

            //获取一级模块列表
            dv.Table = ds.Tables[0];
            dv.RowFilter = "parentId='0'";
            dv.Sort = "moduleIndex desc"; 
            for (int i = 0; i < dv.Count; i++)
            {
                MenuItem item = new MenuItem();
                item.id = dv[i]["moduleId"].ToString();
                item.title = dv[i]["moduleName"].ToString();
                item.icon = dv[i]["imgClass"].ToString();
                item.url = dv[i]["moduleURL"].ToString();
                if (GetSubMenu(dv[i]["moduleId"].ToString(), item, ds, roleRight, moduleRight))
                {
                    main.sysMenu.Add(item);
                    moduleRight.Add(dv[i]["moduleCode"].ToString(), dv[i]["moduleName"].ToString());
                }
            }
            main.deptName = loginUser.DeptName;
            main.userName = loginUser.UserName;
            loginUser.SetRight(context, moduleRight);
            WebJson.ToJson(context, main);
            loginUser.Log("登录系统");
        }

        private bool GetSubMenu(string moduleId, MenuItem parentItem, DataSet ds, Hashtable roleRight, Hashtable moduleRight)
        {
            bool bResult = false;
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.RowFilter = "parentId='" + moduleId + "'";
            dv.Sort = "moduleIndex desc";
            for (int i = 0; i < dv.Count; i++)
            {
                MenuItem item = new MenuItem();
                item.id = dv[i]["moduleId"].ToString();
                item.title = dv[i]["moduleName"].ToString();
                item.icon = dv[i]["imgClass"].ToString();
                item.url = dv[i]["moduleURL"].ToString();
                if (roleRight.ContainsKey(item.id))
                {
                    parentItem.subMenuItemList.Add(item);
                    moduleRight.Add(dv[i]["moduleCode"].ToString(), dv[i]["moduleName"].ToString());
                    bResult = true;
                }
            }
            return bResult;
        }

        /// <summary>
        /// 修改当前用户密码
        /// </summary>
        /// <param name="oldPwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        public void ChangePwd(string oldPwd, string newPwd)
        {
            TSUserDAO tsUserDao = new TSUserDAO();
            TSUser user = tsUserDao.Get(loginUser.UserId);
            if (user.userPwd.Equals(Encrypt.ConvertPwd(user.userId,oldPwd)) == false)
            {
                Message.error(context, "旧密码输入错误");
                return;
            }

            user.userPwd = Encrypt.ConvertPwd(user.userId, newPwd);
            try
            {
                tsUserDao.ChangePwd(user.userId,user.userPwd);
                Message.success(context, "密码修改成功");
                loginUser.Log("密码修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "密码修改失败");
                loginUser.Log("密码修改失败，错误：" + e.Message);
            }
        }
    }
}
