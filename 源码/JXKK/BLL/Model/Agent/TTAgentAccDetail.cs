using System;
namespace Com.ZY.JXKK.Model.Agent
{
    /// <summary>
    /// 代理账户明细
    /// Author:代码生成器
    /// </summary>
    public class TTAgentAccDetail
    {
        
        #region 属性定义
        
        
        /// <summary>
        /// 流水号
        /// </summary>
        public long flowId;
        
        /// <summary>
        /// 代理商编号
        /// </summary>
        public string agentId;
        
        /// <summary>
        /// 代理商名称
        /// </summary>
        public string agentName;
        
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
        /// 创建时间
        /// </summary>
        public string createTime;
        
        /// <summary>
        /// 信息摘要
        /// </summary>
        public string remark;
        
        #endregion
        
    }
}

