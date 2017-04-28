using System;
namespace Com.ZY.JXKK.Model.Lottery
{
    /// <summary>
    /// 彩票订单
    /// Author:代码生成器
    /// </summary>
    public class TTLotteryOrder
    {
        
        #region 属性定义
        
        
        /// <summary>
        /// 订单号
        /// </summary>
        public string orderId;
        
        /// <summary>
        /// 代理商编号
        /// </summary>
        public string agentId;
        
        /// <summary>
        /// 门店编号
        /// </summary>
        public string siteId;
        
        /// <summary>
        /// 终端编号
        /// </summary>
        public string terminalId;
        
        /// <summary>
        /// 客户编号
        /// </summary>
        public long clientId;
        
        /// <summary>
        /// 客户名称
        /// </summary>
        public string clientName;
        
        /// <summary>
        /// 卡号
        /// </summary>
        public string cardId;
        
        /// <summary>
        /// 游戏编号
        /// </summary>
        public string gameId;
        
        /// <summary>
        /// 彩种
        /// </summary>
        public string lotteryType;
        
        /// <summary>
        /// 玩法
        /// </summary>
        public string playType;
        
        /// <summary>
        /// 期次
        /// </summary>
        public string period;
        
        /// <summary>
        /// 投注串
        /// </summary>
        public string betCodes;
        
        /// <summary>
        /// 倍数
        /// </summary>
        public int multiple;
        
        /// <summary>
        /// 投注金额
        /// </summary>
        public double betFee;
        
        /// <summary>
        /// 投注时间
        /// </summary>
        public string betTime;
        
        /// <summary>
        /// 是否追号
        /// </summary>
        public string isChase;
        
        /// <summary>
        /// 追号订单编号
        /// </summary>
        public string chaseOrderId;
        
        /// <summary>
        /// 订单状态
        /// </summary>
        public string orderStatus;
        
        /// <summary>
        /// 出票/撤销时间
        /// </summary>
        public string orderTime;
        
        /// <summary>
        /// 中奖状态
        /// </summary>
        public string awardResult;
        
        /// <summary>
        /// 中奖金额
        /// </summary>
        public double awardMoney;
        
        /// <summary>
        /// 返奖时间
        /// </summary>
        public string awardTime;
        
        /// <summary>
        /// 结算状态
        /// </summary>
        public string settleStatus;
        
        /// <summary>
        /// 结算时间
        /// </summary>
        public string settleTime;
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime;
        
        /// <summary>
        /// 批处理编号
        /// </summary>
        public string batchId;
        
        #endregion
        
    }
}

