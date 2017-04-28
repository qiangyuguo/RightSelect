using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.ZY.JXKK.Model
{
    /// <summary>
    /// 销售统计信息
    /// </summary>
    public class SaleInvoice
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string saleDate;

        /// <summary>
        /// 预付款余额
        /// </summary>
        public double advanceBalance;

        /// <summary>
        /// 销售金额
        /// </summary>
        public double saleAmount;

        /// <summary>
        /// 佣金金额
        /// </summary>
        public double commissionAmount;

        /// <summary>
        /// 中奖金额
        /// </summary>
        public double awardAmount;

        /// <summary>
        /// 提现金额
        /// </summary>
        public double takeCashAmount;

        /// <summary>
        /// 退款金额
        /// </summary>
        public double refundAmount;

    }
}
