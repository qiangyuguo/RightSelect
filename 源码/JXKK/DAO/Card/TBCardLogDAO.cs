using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Card
{
    /// <summary>
    /// 卡片日志
    /// Author:开发人员自行扩展
    /// </summary>
    public class TBCardLogDAO:TBCardLogDBO
    {
        /// <summary>
        /// 增加卡片日志
        /// <param name="data">数据库连接</param>
        /// <param name="tbCardLog">卡片日志</param>
        /// </summary>
        public override void Add(DataAccess data, TBCardLog tbCardLog)
        {
            string strSQL = "insert into TBCardLog (logId,cardId,operateType,summary,operateTime,operatorId,operatorName) values (SCardLog_logId.Nextval,@cardId,@operateType,@summary,To_date(@operateTime,'yyyy-mm-dd hh24:mi:ss'),@operatorId,@operatorName)";
            Param param = new Param();
            param.Clear();
            //param.Add("@logId", tbCardLog.logId);//日志编号
            param.Add("@cardId", tbCardLog.cardId);//卡号
            param.Add("@operateType", tbCardLog.operateType);//操作类型
            param.Add("@summary", tbCardLog.summary);//操作说明
            param.Add("@operateTime", tbCardLog.operateTime);//操作时间
            param.Add("@operatorId", tbCardLog.operatorId);//操作人编号
            param.Add("@operatorName", tbCardLog.operatorName);//操作人名称
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
    }
}

