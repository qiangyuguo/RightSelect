using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.UKey
{
    /// <summary>
    /// 加密狗日志
    /// Author:开发人员自行扩展
    /// </summary>
    public class TBUKeyLogDAO:TBUKeyLogDBO
    {
        /// <summary>
        /// 增加加密狗日志
        /// <param name="data">数据库连接</param>
        /// <param name="tbUKeyLog">加密狗日志</param>
        /// </summary>
        public override void Add(DataAccess data, TBUKeyLog tbUKeyLog)
        {
            string strSQL = "insert into TBUKeyLog (logId,uKeyId,operateType,summary,operatorId,operatorName) values (SUKeyLog_logId.Nextval,@uKeyId,@operateType,@summary,@operatorId,@operatorName)";
            Param param = new Param();
            param.Clear();
            //param.Add("@logId", tbUKeyLog.logId);//日志编号
            param.Add("@uKeyId", tbUKeyLog.uKeyId);//加密狗编号
            param.Add("@operateType", tbUKeyLog.operateType);//操作类型
            param.Add("@summary", tbUKeyLog.summary);//操作说明
            param.Add("@operatorId", tbUKeyLog.operatorId);//操作人编号
            param.Add("@operatorName", tbUKeyLog.operatorName);//操作人名称
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
    }
}

