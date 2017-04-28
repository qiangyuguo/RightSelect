using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    [DataContract]
    public class APIResult
    {
        
        /// <summary>
        /// 结果类型
        /// </summary>
        [DataMember]
        public int Result { get; set; }
        /// <summary>
        /// 结果描述
        /// </summary>
        [DataMember]
        public string Message { get; set; }
     
        [DataMember]
        public object Data { get; set; }
        
           
    }
}
