using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.ZY.JXKK.Model
{
    /// <summary>
    /// 文书，名称
    /// Author:代码生成器
    /// </summary>
    public class TBEnforcementName
    {

        #region 属性定义
        /// <summary>
        /// 执行文书类型编号
        /// </summary>
        public string EnforcementNameId { get; set; }

        /// <summary>
        /// 执行文书类型名称
        /// </summary>
        public string EnforcementTypeId { get; set; }

        public string EnforcementName { get; set; }
        public string IsEmpty { get; set; }
        public string FillingPerson { get; set; }

        public string FillingTime { get; set; }
        public string F1 { get; set; }
        public string statu{get;set;}

        public string EnforcementTemplateId { get; set; }

        #endregion

    }
}
