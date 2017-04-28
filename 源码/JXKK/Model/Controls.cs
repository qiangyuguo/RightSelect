using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Com.ZY.JXKK.Model
{
    [Serializable]
    [DataContract]
    public  class Controls
    {
        //按钮名称
        [DataMember]
        public string ControlName { get; set; }
        //按钮编号唯一标识按钮
        [DataMember]
        public string ControlId { get; set; }
        //按钮Code
        [DataMember]
        public string ControlCode { get; set; }
    }
}
