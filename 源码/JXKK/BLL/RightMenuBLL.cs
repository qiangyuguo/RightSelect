using Com.ZY.JXKK.DBO;
using Com.ZY.JXKK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.ZY.JXKK.BLL
{
    public  class  RightMenuBLL
    {

        TSUserDBO tsUserDBO = new TSUserDBO();
        TSModuleDBO tsModuleDBO = new TSModuleDBO();

        //获取一级节点
        public List<FirstModuleMenu> GetFirstMenuByModuleId(string roleId)
        {
            List<FirstModuleMenu> firstModuleMenuList = new List<FirstModuleMenu>();
            try
            {
                //按钮列表
                List<TSModule> tsModule = tsModuleDBO.GetFirstTSModule(roleId);
                for (int j = 0; j < tsModule.Count; j++)
                {
                    FirstModuleMenu firstModuleMenu = new FirstModuleMenu()
                    {

                        ModuleCode = tsModule[j].moduleCode,
                        ModuleId = tsModule[j].moduleId,
                        ModuleName = tsModule[j].moduleName,
                    };
                    firstModuleMenuList.Add(firstModuleMenu);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return firstModuleMenuList;
        }



        //获取二级节点
        public List<SecondModuleMenu> GetSencondMenuByModuleId(string roleId, string ModuleId)
        {
            List<SecondModuleMenu> SendModuleMenu = new List<SecondModuleMenu>();
            try
            {

                //按钮列表
                List<TSModule> tsModule = tsModuleDBO.GetTSModuleButton(roleId, ModuleId);
                for (int j = 0; j < tsModule.Count; j++)
                {
                    SecondModuleMenu sencondMenu = new SecondModuleMenu()
                    {

                        ModuleCode = tsModule[j].moduleCode,
                        ModuleId = tsModule[j].moduleId,
                        ModuleName = tsModule[j].moduleName,
                    };
                    SendModuleMenu.Add(sencondMenu);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return SendModuleMenu;
        }

        //获取按钮
        public List<Controls> GetButtonListByModuleId(string roleId, string ModuleId)
        {
            List<Controls> list = new List<Controls>();
            try
            {
                //按钮列表
                List<TSModule> tsModuleButton = tsModuleDBO.GetTSModuleButton(roleId, ModuleId);
                for (int j = 0; j < tsModuleButton.Count; j++)
                {
                    Controls control = new Controls()
                    {
                        ControlCode = tsModuleButton[j].moduleCode,
                        ControlId = tsModuleButton[j].moduleId,
                        ControlName = tsModuleButton[j].moduleName,
                    };
                    list.Add(control);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }
    }
}
