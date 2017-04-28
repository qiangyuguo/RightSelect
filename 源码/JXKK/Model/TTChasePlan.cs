using System;
namespace Com.ZY.JXKK.Model
{
    /// <summary>
    /// 追号计划
    /// Author:代码生成器
    /// </summary>
    public class TTChasePlan
    {
        
        #region 属性定义
        
        
        /// <summary>
        /// 订单号
        /// </summary>
        public string orderId;
        
        /// <summary>
        /// 追号订单编号
        /// </summary>
        public string chaseOrderId;
        
        /// <summary>
        /// 期次
        /// </summary>
        public string period;
        
        /// <summary>
        /// 倍数
        /// </summary>
        public int multiple;
        
        /// <summary>
        /// 投注金额
        /// </summary>
        public double betFee;
        
        /// <summary>
        /// 累计投注金额
        /// </summary>
        public double sumPayFee;
        
        /// <summary>
        /// 可中奖金额
        /// </summary>
        public string awardFee;
        
        /// <summary>
        /// 盈利金额
        /// </summary>
        public string winFee;
        
        /// <summary>
        /// 盈利率
        /// </summary>
        public string winRate;
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime;
        
        #endregion
        
    }
}

