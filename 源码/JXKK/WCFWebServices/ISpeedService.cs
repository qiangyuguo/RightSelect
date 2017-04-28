using Com.ZY.JXKK.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFWebServices
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ISpeedService”。
    [ServiceContract]
    public interface ISpeedService
    {
        [OperationContract]
        APIResult GetLoginUserInfo(string strUserName, string strPassward);
    }
}
