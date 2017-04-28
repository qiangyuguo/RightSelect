using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Com.ZY.JXKK.Model
{
    //一级菜单对象
    [Serializable]
    [DataContract]
    public  class FirstModuleMenu
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
        //二级菜单对象
        [DataMember]
        public List<SecondModuleMenu> SendModuleMenuList = new List<SecondModuleMenu>();
    }
}
