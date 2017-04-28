using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.ZY.JXKK.Model
{
    /// <summary>
    /// 系统用户
    /// Author:代码生成器
    /// </summary>
    [Serializable]
    [DataContract]
    public class TSUser
    {
        
      
        #region 属性定义


        /// <summary>
        /// 用户编号
        /// </summary>
        [DataMember]
        public string userId;

        /// <summary>
        /// 用户姓名
        /// </summary>
        [DataMember]
        public string userName;

        /// <summary>
        /// 用户帐号
        /// </summary>
        [DataMember]
        public string userCode;

        /// <summary>
        /// 用户密码
        /// </summary>
        [DataMember]
        public string userPwd;

        /// <summary>
        /// 角色编号
        /// </summary>
        [DataMember]
        public string roleIds;

        /// <summary>
        /// 部门编号
        /// </summary>
        [DataMember]
        public string deptId;

        /// <summary>
        /// 使用状态
        /// </summary>
        [DataMember]
        public string status;

        /// <summary>
        /// 职务
        /// </summary>
        [DataMember]
        public string post;

        /// <summary>
        /// 联系电话
        /// </summary>
        [DataMember]
        public string telephone;

        //权限，包括，一级菜单
        [DataMember]
        public List<FirstModuleMenu> FirstModule = new List<FirstModuleMenu>();

        

        #endregion

    }
}

