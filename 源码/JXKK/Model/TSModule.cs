using System;
using System.Collections.Generic;

namespace Com.ZY.JXKK.Model
{
    /// <summary>
    /// 系统功能模块
    /// Author:代码生成器
    /// </summary>
    public class TSModule
    {
        
        #region 属性定义
        
        
        /// <summary>
        /// 模块编号
        /// </summary>
        public string moduleId;
        
        /// <summary>
        /// 模块代码
        /// </summary>
        public string moduleCode;
        
        /// <summary>
        /// 模块名称
        /// </summary>
        public string moduleName;
        
        /// <summary>
        /// 模块路径
        /// </summary>
        public string moduleURL;
        
        /// <summary>
        /// 图片样式
        /// </summary>
        public string imgClass;
        
        /// <summary>
        /// 父模块编号
        /// </summary>
        public string parentId;
        
        /// <summary>
        /// 模块层次
        /// </summary>
        public int moduleLayer;
        
        /// <summary>
        /// 排列顺序
        /// </summary>
        public int moduleIndex;

        /// <summary>
        ///根据用户在权限系统设置的菜单，以及菜单的按钮是否可用（即：菜单，是否隐藏，按钮是否隐藏）
        /// </summary>
        public string ISENABLE;


        public List<Controls> ControlName=new List<Controls>();
        #endregion

    }
}

