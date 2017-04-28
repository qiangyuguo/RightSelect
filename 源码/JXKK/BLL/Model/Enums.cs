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
    public enum UKeyStatus : int { InStore = 0, Draw = 1, Activation = 2, Repair = 3, Invalid = 4 }

    /// <summary>
    /// 加密狗状态
    /// Draw= 0 已领
    /// Activation = 1 激活
    /// </summary>
    public enum AgentUKeyStatus : int { Draw = 1, Activation = 2 }

    /// <summary>
    /// 充值方式
    /// Transfer=0 转账
    /// Cash=1 现金
    /// </summary>
    public enum HandleMode : int { Transfer = 0, Cash = 1 }

    /// <summary>
    /// 办理状态
    /// ToDo = 0 待办
    /// HaveToDo = 1 已办
    /// Refuse = 2 拒绝
    /// </summary>
    public enum DealWithStatus : int { ToDo = 0, HaveToDo = 1, Refuse = 2 }
}
