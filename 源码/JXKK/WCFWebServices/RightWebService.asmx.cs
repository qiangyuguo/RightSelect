using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.DAO.Manage;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.Util;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;

namespace WCFWebServices
{
    /// <summary>
    /// RightWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    [XmlInclude(typeof(APIResult))]
    [XmlInclude(typeof(TSUser))]
    [XmlInclude(typeof(FirstModuleMenu))]
    [XmlInclude(typeof(SecondModuleMenu))]
    [XmlInclude(typeof(Controls))]
    public class RightWebService : System.Web.Services.WebService
    {
        RightMenuBLL rightMenu = new RightMenuBLL();


        [WebMethod(Description = "用户登录接口")]
        public Model.APIResult GetLoginUserInfo(string strUserCode, string strPassward)
        {

            Model.APIResult result = new Model.APIResult();
            try
            {
                //获取用户信息
                List<TSUser> tsUserList = new TSUserDAO().GetList("userCode", strUserCode);
                if (tsUserList.Count != 1)
                {
                    result.Data = null;
                    result.Message = "没有查询到用户的登录信息!";
                    result.Result = 101;
                }

                TSUser tsUser = tsUserList[0];
                if (!tsUser.userPwd.Equals(Encrypt.ConvertPwd(tsUser.userId, strPassward)))
                {
                    result.Data = null;
                    result.Message = "用户名与密码不匹配！";
                    result.Result = 102;

                }
                else if (!"1".Equals(tsUser.status))
                {
                    result.Data = null;
                    result.Message = "该用户帐号已停用!";
                    result.Result = 103;
                }

                //获取部门信息
                TSDept tsDept = new TSDeptDAO().Get(tsUser.deptId);
                if (tsDept == null)
                {
                    result.Data = null;
                    result.Message = "该用户所属部门不存在!";
                    result.Result = 104;

                }
                else if (!"1".Equals(tsDept.status))
                {
                    result.Data = null;
                    result.Message = "该用户所属部门已停用!";
                    result.Result = 105;

                }

                GetModuleInfo(tsUser);

                result.Data = tsUser;
                result.Message = "获取用户信息成功!";
                result.Result = 100;

            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Message = "获取用户信息失败：" + ex.Message;
                result.Result = 0;
            }
            return result;
        }

        private void GetModuleInfo(TSUser tsUser)
        {
            try
            {
                List<FirstModuleMenu> firstList = rightMenu.GetFirstMenuByModuleId(tsUser.roleIds);
                if (firstList != null && firstList.Count > 0)
                {
                    for (int i = 0; i < firstList.Count; i++)
                    {
                        FirstModuleMenu info = firstList[i];
                        if (info != null)
                        {
                            List<SecondModuleMenu> sencondlist = rightMenu.GetSencondMenuByModuleId(tsUser.roleIds, info.ModuleId);
                            if (sencondlist != null && sencondlist.Count > 0)
                            {
                                for (int j = 0; j < sencondlist.Count; j++)
                                {
                                    SecondModuleMenu sendModuleMenu = sencondlist[j];
                                    if (sendModuleMenu != null)
                                    {
                                        List<Controls> controlList = rightMenu.GetButtonListByModuleId(tsUser.roleIds, sendModuleMenu.ModuleId);
                                        sendModuleMenu.ControlsList = controlList;

                                    }
                                }
                            }
                            info.SendModuleMenuList = sencondlist;

                        }
                    }
                    tsUser.FirstModule = firstList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
