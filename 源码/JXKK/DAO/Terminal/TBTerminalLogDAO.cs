using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Terminal
{
    /// <summary>
    /// 终端日志
    /// Author:开发人员自行扩展
    /// </summary>
    public class TBTerminalLogDAO:TBTerminalLogDBO
    {
        /// <summary>
        /// 增加终端日志
        /// <param name="data">数据库连接</param>
        /// <param name="tbTerminalLog">终端日志</param>
        /// </summary>
        public override void Add(DataAccess data, TBTerminalLog tbTerminalLog)
        {
            string strSQL = "insert into TBTerminalLog (logId,terminalId,operateType,summary,operateTime,operatorId,operatorName) values (STerminalLog_logId.Nextval,@terminalId,@operateType,@summary,To_date(@operateTime,'yyyy-mm-dd hh24:mi:ss'),@operatorId,@operatorName)";
            Param param = new Param();
            param.Clear();
            //param.Add("@logId", tbTerminalLog.logId);//日志编号
            param.Add("@terminalId", tbTerminalLog.terminalId);//终端编号
            param.Add("@operateType", tbTerminalLog.operateType);//操作类型
            param.Add("@summary", tbTerminalLog.summary);//操作说明
            param.Add("@operateTime", tbTerminalLog.operateTime);//操作时间
            param.Add("@operatorId", tbTerminalLog.operatorId);//操作人编号
            param.Add("@operatorName", tbTerminalLog.operatorName);//操作人名称
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
    }
}

