using System;
namespace Com.ZY.JXKK.Model
{
    /// <summary>
    /// 追号订单
    /// Author:代码生成器
    /// </summary>
    public class TTChaseOrder
    {
        
        #region 属性定义
        
        
        /// <summary>
        /// 追号订单号
        /// </summary>
        public string chaseOrderId;
        
        /// <summary>
        /// 追号类型
        /// </summary>
        public string chaseType;
        
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
        /// 下单期次
        /// </summary>
        public string period;
        
        /// <summary>
        /// 用户投注串
        /// </summary>
        public string userBetCodes;
        
        /// <summary>
        /// 中心投注串
        /// </summary>
        public string centerBetCodes;
        
        /// <summary>
        /// 投注期数
        /// </summary>
        public int betNum;
        
        /// <summary>
        /// 订单总额
        /// </summary>
        public double chaseTotalFee;
        
        /// <summary>
        /// 追号时间
        /// </summary>
        public string chaseTime;
        
        /// <summary>
        /// 停止条件
        /// </summary>
        public string endCondition;
        
        /// <summary>
        /// 停止参数
        /// </summary>
        public int conditionParam;
        
        /// <summary>
        /// 运行期次
        /// </summary>
        public string usedPeriod;
        
        /// <summary>
        /// 已追期数
        /// </summary>
        public int usedNum;
        
        /// <summary>
        /// 已追金额
        /// </summary>
        public double usedFee;
        
        /// <summary>
        /// 退款期数
        /// </summary>
        public int backNum;
        
        /// <summary>
        /// 退款金额
        /// </summary>
        public double backFee;
        
        /// <summary>
        /// 中奖金额
        /// </summary>
        public double awardMoney;
        
        /// <summary>
        /// 冻结金额
        /// </summary>
        public double frozenFee;
        
        /// <summary>
        /// 追号状态
        /// </summary>
        public string chaseStatus;
        
        /// <summary>
        /// 结束时间
        /// </summary>
        public string overTime;
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime;
        
        /// <summary>
        /// 数据来源方式
        /// </summary>
        public string srcType;
        
        #endregion
        
    }
}

