using System;
namespace Com.ZY.JXKK.Model.Agent
{
    /// <summary>
    /// 代理商提现
    /// Author:代码生成器
    /// </summary>
    public class TTAgentTakeCash
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
        /// 操作人编号
        /// </summary>
        public string operatorId;
        
        /// <summary>
        /// 操作人名称
        /// </summary>
        public string operatorName;
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime;
        
        /// <summary>
        /// 提现方式
        /// </summary>
        public string handleMode;
        
        /// <summary>
        /// 银行账号
        /// </summary>
        public string bankAccountId;
        
        /// <summary>
        /// 银行流水号
        /// </summary>
        public string bankFlowId;
        
        /// <summary>
        /// 说明
        /// </summary>
        public string description;
        
        #endregion
        
    }
}

