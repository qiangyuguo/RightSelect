using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Manage
{
    /// <summary>
    /// 系统功能模块
    /// Author:开发人员自行扩展
    /// </summary>
    public class TSModuleDAO:TSModuleDBO
    {
        /// <summary>
        /// 修改系统功能模块【修改】
        /// <param name="data">数据库连接</param>
        /// <param name="tsModule">系统功能模块</param>
        /// </summary>
        public override void Edit(DataAccess data, TSModule tsModule)
        {
            string strSQL = "update TSModule set moduleCode=@moduleCode,moduleName=@moduleName,moduleURL=@moduleURL,imgClass=@imgClass,moduleIndex=@moduleIndex where moduleId=@moduleId";
            Param param = new Param();
            param.Clear();
            param.Add("@moduleCode", tsModule.moduleCode);//模块代码
            param.Add("@moduleName", tsModule.moduleName);//模块名称
            param.Add("@moduleURL", tsModule.moduleURL);//模块路径
            param.Add("@imgClass", tsModule.imgClass);//图片样式
            //param.Add("@parentId", tsModule.parentId);//父模块编号
            //param.Add("@moduleLayer", tsModule.moduleLayer);//模块层次
            param.Add("@moduleIndex", tsModule.moduleIndex);//排列顺序
            param.Add("@moduleId", tsModule.moduleId);//模块编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
    }
}

