using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Com.ZY.JXKK.Model
{
    //二级菜单对象，一个二级菜单包含多个控件

    [Serializable]
    [DataContract]
    public  class SecondModuleMenu
    {
        //菜单编号 主键唯一标识
        [DataMember]
        public string ModuleId { get; set; }
        //菜单Code
        [DataMember]
        public string ModuleCode { get; set; }
        //菜单名称
        [DataMember]
        public string ModuleName { get; set; }
        //菜单所包拥有的按钮列表
        [DataMember]
        public List<Controls> ControlsList = new List<Controls>();
    }
}
