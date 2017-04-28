using System;
using System.Collections.Generic;

namespace Com.ZY.JXKK.Json
{
    /// <summary>
    /// 菜单项
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// 菜单编号
        /// </summary>
        public string id;

        /// <summary>
        /// 菜单标题
        /// </summary>
        public string title;

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string icon;

        /// <summary>
        ///  模块路径
        /// </summary>
        public string url;

        /// <summary>
        /// 子菜单
        /// </summary>
        public List<MenuItem> subMenuItemList = new List<MenuItem>();

    }
}
