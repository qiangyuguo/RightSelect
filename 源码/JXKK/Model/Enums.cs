using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.ZY.JXKK.Model
{
    /// <summary>
    /// 审核状态
    /// NotAudit = 0 尚未审核
    /// AuditSucces = 1 审核通过
    /// AuditFailure = 2  审核失败
    /// </summary>
    public enum AuditStauts :int{ NotAudit = 0, AuditSucces = 1, AuditFailure = 2};

    /// <summary>
    /// 卡片状态
    /// InStore = 0 在库
    /// StayUsed = 1 待用
    /// StayBinding = 2, 待绑
    /// Binding = 3 绑定
    /// Lost = 4 遗失
    /// Invalid = 5 作废
    /// </summary>
    public enum CardStatus : int { InStore = 0, StayUsed = 1, StayBinding = 2, Binding = 3, Lost = 4, Invalid = 5 }

    /// <summary>
    /// 终端状态
    /// InStore = 0 在库
    /// Used = 1 使用
    /// Stop = 2, 停用
    /// Repair = 3 维修
    /// Invalid = 4 作废
    /// </summary>
    public enum TerminalStatus : int { InStore = 0, Used = 1, Stop = 2, Repair = 3, Invalid = 4 }
    /// <summary>
    /// 加密狗状态
    /// InStore = 0 在库
    /// Draw= 1 已领
    /// Activation = 2, 激活
    /// Repair = 3 维修
    /// Invalid = 4 作废
    /// </summary>
    public enum UKeyStatus : int { InStore = 0, Draw = 1, Activation = 2,Invalid = 4 }

    /// <summary>
    /// 办理状态
    /// ToDo = 0 待办
    /// HaveToDo = 1 已办
    /// Refuse = 2 拒绝
    /// </summary>
    public enum DealWithStatus : int { ToDo = 0, HaveToDo = 1, Refuse = 2 }

    /// <summary>
    /// 彩票订单状态
    /// NoTicket = 0 未出票
    /// Ticket = 1 已出票
    /// Cancel = 2 已撤单
    /// TicketFailure = 3 出票失败
    /// </summary>
    public enum OrderStatus : int { NoTicket = 0, Ticket = 1, Cancel = 2, TicketFailure = 3 }

    /// <summary>
    /// 积分订单状态
    /// Ticket = 0 已投注
    /// Cancel = 1 已撤单
    /// </summary>
    public enum PointOrderStatus : int { Ticket = 0, Cancel = 1 }

    /// <summary>
    /// 彩票中奖结果
    /// NoLottery = 0 未开奖	
    /// NoWinning = 1 未中奖	
    /// SmallAward = 2 小奖	
    /// BigAward=3 大奖
    /// </summary>
    public enum AwardResult : int { NoLottery = 0, NoWinning = 1, SmallAward = 2, BigAward=3 }

    /// <summary>
    /// 积分中奖结果
    /// NoLottery = 0 未开奖	
    /// NoWinning = 1 未中奖	
    /// Winning = 2 中奖
    /// </summary>
    public enum PointAwardResult : int { NoLottery = 0, NoWinning = 1, Winning = 2}

     /// <summary>
    /// 彩票追号状态
    /// JustChase = 0 正在追号
    /// WinningStop = 1 中奖停止
    /// ChaseEnd = 2 追期结束	
    /// ManualStop = 3 手工停止
    /// </summary>
    public enum ChaseStatus : int { JustChase = 0, WinningStop = 1, ChaseEnd = 2, ManualStop = 3 }

    /// <summary>
    /// 用户查询条件列表
    /// CardId=0  卡号
    /// ClientId=1 客户编号
    /// ClientName=2 客户名称
    /// ClinetPhone=3 客户电话
    /// </summary>
    public enum ClientQuery : int {CardId=0,ClientId=1,ClientName=2,ClinetPhone=3 }

    /// <summary>
    /// 投注来源方式
    /// Terminal = 0 游戏终端
    /// App = 1 App 手机APP
    /// </summary>
    public enum SrcType : int { Terminal = 0, App = 1}


    /// <summary>
    /// 积分来源方式
    /// Recharge = 1  疯狂财神
    /// withdraw = 2  提现
    /// lottery = 3  购彩
    ///  prize = 4  中奖
    ///  refund = 5  退款
    /// </summary>
    public enum AllScoreState : int { 疯狂财神 = 1, 购彩赠送 = 2, 疯狂足球 = 3, 疯狂扑克 = 4 }



    public enum PunishmentType : int
    {
        超限处罚一般程序=0,
        超限处罚简易程序=1
    }
    
}
