using System;
namespace Com.ZY.JXKK.Model
{
    /// <summary>
    /// 客户账户明细
    /// Author:代码生成器
    /// </summary>
    public class TTClientAccDetail
    {
        
        #region 属性定义
        
        
        /// <summary>
        /// 流水号
        /// </summary>
        public long flowId;
        
        /// <summary>
        /// 卡号
        /// </summary>
        public string cardId;
        
        /// <summary>
        /// 客户编号
        /// </summary>
        public long clientId;
        
        /// <summary>
        /// 客户名称
        /// </summary>
        public string clientName;
        
        /// <summary>
        /// 代理商编号
        /// </summary>
        public string agentId;
        
        /// <summary>
        /// 门店编号
        /// </summary>
        public string siteId;
        
        /// <summary>
        /// 上次余额
        /// </summary>
        public double lastBalance;
        
        /// <summary>
        /// 发生金额
        /// </summary>
        public double fee;
        
        /// <summary>
        /// 当前余额
        /// </summary>
        public double balance;
        
        /// <summary>
        /// 信息摘要
        /// </summary>
        public string remark;
        
        /// <summary>
        /// 发生时间
        /// </summary>
        public string changeTime;
        
        /// <summary>
        /// 来源方式
        /// </summary>
        public string srcMode;
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime;
        
        #endregion
        
    }
}

