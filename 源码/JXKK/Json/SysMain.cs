using System;
using System.Data;
using System.Collections.Generic;

namespace Com.ZY.JXKK.Json
{
    /// <summary>
    /// 系统主界面
    /// </summary>
    public class SysMain
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string deptName = "";

        /// <summary>
        /// 用户名称
        /// </summary>
        public string userName = "";

        /// <summary>
        /// 系统菜单
        /// </summary>
        public List<MenuItem> sysMenu = new List<MenuItem>();

        public SysMain()
        {
            sysMenu.Clear();
        }
    }
}