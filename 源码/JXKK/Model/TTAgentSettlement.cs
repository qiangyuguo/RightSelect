using System;
namespace Com.ZY.JXKK.Model
{
    /// <summary>
    /// 代理佣金结算
    /// Author:代码生成器
    /// </summary>
    public class TTAgentSettlement
    {
        
        #region 属性定义
        
        
        /// <summary>
        /// 结算流水号
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
        /// 结算起始日期
        /// </summary>
        public string startDate;
        
        /// <summary>
        /// 结算结束日期
        /// </summary>
        public string endDate;
        
        /// <summary>
        /// 销售总额
        /// </summary>
        public double saleFee;
        
        /// <summary>
        /// 返点比例
        /// </summary>
        public double rebate;
        
        /// <summary>
        /// 佣金金额
        /// </summary>
        public double commissionFee;
        
        /// <summary>
        /// 支付状态
        /// </summary>
        public string payStatus;
        
        /// <summary>
        /// 支付方式
        /// </summary>
        public string modeId;
        
        /// <summary>
        /// 结算时间
        /// </summary>
        public string settlementTime;
        
        /// <summary>
        /// 结算人编号
        /// </summary>
        public string settlementId;
        
        /// <summary>
        /// 结算人名称
        /// </summary>
        public string settlementName;
        
        /// <summary>
        /// 支付时间
        /// </summary>
        public string payTime;
        
        /// <summary>
        /// 支付人编号
        /// </summary>
        public string cashierId;
        
        /// <summary>
        /// 支付人名称
        /// </summary>
        public string cashierName;
        
        #endregion
        
    }
}

