using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.ZY.JXKK.Model
{
    public class LotteryOrderSale
    {
        /// <summary>
        /// 投注日期
        /// </summary>
        public string BetDate;
        /// <summary>
        /// 销售总额
        /// </summary>
        public double SumBetFee;
        /// <summary>
        /// 中奖金额
        /// </summary>
        public double SumAwardMoney;
        /// <summary>
        /// 中奖状态
        /// </summary>
        public string AwardResult;
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderStatus;

    }
}
