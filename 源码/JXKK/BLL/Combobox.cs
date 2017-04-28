using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.ZY.JXKK.Util;
using System.Web;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Set;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DAO.Agent;
using System.Data;

namespace Com.ZY.JXKK.BLL
{
    /// <summary>
    /// 下拉列表类
    /// </summary>
    public class Combobox
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();

        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public Combobox(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        /// <summary>
        /// 获取代理商下拉列表
        /// </summary>
        public void AgentCombobox()
        {
            WebJson.Write(context, commonDao.Combobox("select agentName name,agentId id from TBAgent where status='1' and auditStatus='" + (int)AuditStauts.AuditSucces + "'", null));
        }


        /// <summary>
        /// 获取文书类型下拉列表
        /// </summary>
        public void EnforcementTypeCombobox()
        {
            WebJson.Write(context, commonDao.Combobox("select   EnforcementTypeName name ,EnforcementTypeId id   from dbo.TBEnforcementType where statu=1  ", null));
        }

          /// <summary>
        /// 获取文书类型下拉列表
        /// </summary>
        public void EnforcementTemplateCombobox()
        {
            WebJson.Write(context, commonDao.Combobox("select p.TemplateName name,  p.TemplateId id   from  dbo.TBEnforcementTemplate P  where p.statu=1 ", null));
        }


        


        /// <summary>
        /// 根据条件获取门店下拉列表
        /// </summary>
        /// <param name="userId">关联用户编号</param>
        /// <param name="roleId">角色编号</param>
        public void SiteByRoleCombobox(string userId, string roleType)
        {
            if (roleType == "0")
            {
                WebJson.Write(context, commonDao.Combobox("select SiteName name,SiteId id from TBSite where status='1' and agentId='" + userId + "'", null));
            }
            else
            {
                string siteId = new TBStaffDAO().Get(userId).siteId;
                WebJson.Write(context, commonDao.Combobox("select SiteName name,SiteId id from TBSite where status='1' and siteId='" + siteId + "'", null));
            }
        }
        /// <summary>
        /// 获取所有门店下拉列表
        /// </summary>
        public void SiteAllCombobox()
        {
            WebJson.Write(context, commonDao.Combobox("select siteName name,siteId id from TBSite where status='1' and auditStatus='" + (int)AuditStauts.AuditSucces + "'", null));
        }
        /// <summary>
        /// 根据代理商获取门店下拉列表
        /// </summary>
        /// <param name="userId">关联用户编号</param>
        /// <param name="roleId">代理商编号</param>
        public void SiteByAgentCombobox(string agentId)
        {

            WebJson.Write(context, commonDao.Combobox("select SiteName name,SiteId id from TBSite where status='1' and agentId='" + agentId + "'", null));
        }
        /// <summary>
        /// 根据市区县获取快开厅
        /// </summary>
        /// <param name="city"></param>
        /// <param name="county"></param>
        public void SiteByAreaCombobox(string city, string county)
        {
            if (!string.IsNullOrEmpty(county))
                WebJson.Write(context, commonDao.Combobox("SELECT s.siteName name,s.siteId id FROM tbSite s,TBAgent a where s.agentid=a.agentid and a.areaid='" + county + "'", null));
            else if (!string.IsNullOrEmpty(city) && string.IsNullOrEmpty(county))
                WebJson.Write(context, commonDao.Combobox("SELECT s.siteName name,s.siteId id FROM tbSite s,TBAgent a where s.agentid=a.agentid and a.areaid in (select areaid from TBAREA t where t.parentid='" + city + "')", null));
            else
                WebJson.Write(context, commonDao.Combobox("SELECT s.siteName name,s.siteId id FROM tbSite s,TBAgent a where s.agentid=a.agentid ", null));
        }
        /// <summary>
        /// 客户查询条件
        /// </summary>
        public void ClientQueryCombobox()
        {
            WebJson.Write(context, commonDao.Combobox(EnumSelectListHelper.CreatSelectListByEnum(typeof(ClientQuery))));
        }

        /// <summary>
        /// 客户查询游戏类型
        /// </summary>
        public void ScoreStaCombobox()
        {
            WebJson.Write(context, commonDao.Combobox("select gamename  name,gameid  id from tbgame where typecode='1'", null));
        }
        /// <summary>
        /// 获取区域下拉列表
        /// </summary>
        /// <param name="orgId">机构编号</param>
        public void AreaCombobox()
        {
            WebJson.Write(context, new TBAreaDAO().AreaCombobox("select * from tbarea t where isuse='1' order by parentid asc,areaindex desc", null));
        }
        /// <summary>
        /// 获取审核状态下拉列表
        /// </summary>
        public void AuditCombobox()
        {
            WebJson.Write(context, commonDao.Combobox(EnumSelectListHelper.CreatSelectListByEnum(typeof(AuditStauts))));
        }
        /// <summary>
        /// 获取充值方式下拉列表
        /// </summary>
        public void HandleModeCombobox()
        {
            WebJson.Write(context, commonDao.Combobox("select modename name, modeid id from TBPaymode", null));
        }
        /// <summary>
        /// 获取角色下拉列表
        /// </summary>
        public void RoleCombobox()
        {
            WebJson.Write(context, commonDao.Combobox("select roleName name,roleId id from TSRole where status='1'", null));
        }
        /// <summary>
        /// 获取代理商角色下拉列表
        /// </summary>
        public void AgentRoleCombobox()
        {
            WebJson.Write(context, commonDao.Combobox("select roleName name,roleId id from TSAgentRole where status='1'", null));
        }
        /// <summary>
        /// 获取代理商门店角色下拉列表
        /// </summary>
        /// <param name="roleType">角色编号</param>
        public void SiteAgentRoleCombobox()
        {
            WebJson.Write(context, commonDao.Combobox("select RoleName name,roleId id from TSAgentRole where type='1'", null));
        }
        /// <summary>
        /// 绑定处理状态
        /// </summary>
        public void DealWSCombobox()
        {
            WebJson.Write(context, commonDao.Combobox(EnumSelectListHelper.CreatSelectListByEnum(typeof(DealWithStatus))));
        }
        /// <summary>
        /// 获取卡片状态下拉列表
        /// </summary>
        public void CardStatusCombobox()
        {
            WebJson.Write(context, commonDao.Combobox(EnumSelectListHelper.CreatSelectListByEnum(typeof(CardStatus))));
        }

        /// <summary>
        /// 获取快开卡片状态下拉列表
        /// </summary>
        public void AgentCardStatusCombobox()
        {
            DataTable dt = EnumSelectListHelper.CreatSelectListByEnum(typeof(CardStatus));
            DataView dv = new DataView(dt);
            dv.RowFilter = "value not in (" + (int)CardStatus.InStore + "," + (int)CardStatus.StayUsed + ")";
            DataTable dt_New = dv.ToTable();
            WebJson.Write(context, commonDao.Combobox(dt_New));
        }
        /// <summary>
        /// 获取追号状态下拉列表
        /// </summary>
        public void ChaseStatusCombobox()
        {
            WebJson.Write(context, commonDao.Combobox(EnumSelectListHelper.CreatSelectListByEnum(typeof(ChaseStatus))));
        }
        /// <summary>
        /// 获取订单状态下拉列表
        /// </summary>
        public void OrderStatusCombobox()
        {
            WebJson.Write(context, commonDao.Combobox(EnumSelectListHelper.CreatSelectListByEnum(typeof(OrderStatus))));
        }
        /// <summary>
        /// 获取积分订单状态下拉列表
        /// </summary>
        public void PointOrderStatusCombobox()
        {
            WebJson.Write(context, commonDao.Combobox(EnumSelectListHelper.CreatSelectListByEnum(typeof(PointOrderStatus))));
        }
        /// <summary>
        /// 获取中奖结果下拉列表
        /// </summary>
        public void AwardResultCombobox()
        {
            WebJson.Write(context, commonDao.Combobox(EnumSelectListHelper.CreatSelectListByEnum(typeof(AwardResult))));
        }

        /// <summary>
        /// 获取积分中奖结果下拉列表
        /// </summary>
        public void PointAwardResultCombobox()
        {
            WebJson.Write(context, commonDao.Combobox(EnumSelectListHelper.CreatSelectListByEnum(typeof(PointAwardResult))));
        }
        /// <summary>
        /// 获取代理商中奖状态下拉列表
        /// </summary>
        public void WinnerLotteryCombobox()
        {
            DataTable dt = EnumSelectListHelper.CreatSelectListByEnum(typeof(AwardResult));
            DataView dv = new DataView(dt);
            dv.RowFilter = "value in (" + ((int)AwardResult.SmallAward).ToString() + "," + ((int)AwardResult.BigAward).ToString() + ")";
            DataTable dt_New = dv.ToTable();
            WebJson.Write(context, commonDao.Combobox(dt_New));
        }
        /// <summary>
        /// 获取部门下拉列表
        /// </summary>
        /// <param name="orgId">机构编号</param>
        public void DeptCombobox()
        {
            WebJson.Write(context, commonDao.Combobox("select deptName name,deptId id from TSDept where status='1'", null));
        }
        /// <summary>
        /// 获取用户下拉列表
        /// </summary>
        /// <param name="deptId">部门编号</param>
        public void UserCombobox(string deptId)
        {
            WebJson.Write(context, commonDao.Combobox("select userName name,userId id from TSUser where status='1' and deptId='" + deptId + "'", null));
        }
        /// <summary>
        /// 获取市拉列表
        /// </summary>
        /// <param name="userId">关联用户编号</param>
        /// <param name="roleId">角色编号</param>
        public void CityCombobox()
        {

            WebJson.Write(context, commonDao.Combobox("select t.areaname name,t.areaid id from tbarea t where t.parentid=0", null));
        }

        /// <summary>
        /// 获取区县下拉列表
        /// </summary>
        /// <param name="city">市</param>
        public void CountyCombobox(string city)
        {
            if (!string.IsNullOrEmpty(city))
                WebJson.Write(context, commonDao.Combobox("select t.areaname name,t.areaid id from tbarea t where t.parentid='" + city + "'", null));
            else
                WebJson.Write(context, commonDao.Combobox("select t.areaname name,t.areaid id from tbarea t where t.parentid!=0", null));
        }

        /// <summary>
        /// 彩种下拉列表
        /// </summary>
        public void LotteryTypeCombobox()
        {
            WebJson.Write(context, commonDao.Combobox("select LotteryTypeName name,LotteryType id from TBLottery", null));
        }

        /// <summary>
        /// 游戏下拉列表
        /// </summary>
        public void GameCombobox()
        {
            WebJson.Write(context, commonDao.Combobox("select gameName name,gameId id from TBGame", null));
        }
        /// <summary>
        ///积分游戏下拉列表
        /// </summary>
        public void PointGameCombobox(string typeCode)
        {
            WebJson.Write(context, commonDao.Combobox("select gamename name,gameid id from TBGame where typeCode in（" + typeCode + "） ", null));
        }

        /// <summary>
        /// 获取加密狗状态下拉列表
        /// </summary>
        public void UKeyStatusCombobox()
        {
            WebJson.Write(context, commonDao.Combobox(EnumSelectListHelper.CreatSelectListByEnum(typeof(UKeyStatus))));
        }
        /// <summary>
        /// 获取代理商加密狗状态下拉列表
        /// </summary>
        public void AgentUKeyStatusCombobox()
        {
            DataTable dt = EnumSelectListHelper.CreatSelectListByEnum(typeof(UKeyStatus));
            DataView dv = new DataView(dt);
            dv.RowFilter = "value not in (" + ((int)UKeyStatus.InStore).ToString() + ")";
            DataTable dt_New = dv.ToTable();
            WebJson.Write(context, commonDao.Combobox(dt_New));
        }

        /// <summary>
        /// 获取终端状态下拉列表
        /// </summary>
        public void TerminalStatusCombobox()
        {
            WebJson.Write(context, commonDao.Combobox(EnumSelectListHelper.CreatSelectListByEnum(typeof(TerminalStatus))));
        }
        /// <summary>
        /// 获取代理商终端维护状态
        /// </summary>
        public void AgentTerminalStatusCombobox()
        {
            DataTable dt = EnumSelectListHelper.CreatSelectListByEnum(typeof(TerminalStatus));
            DataView dv = new DataView(dt);
            dv.RowFilter = "value not in (" + ((int)TerminalStatus.InStore).ToString() + ")";
            DataTable dt_New = dv.ToTable();
            WebJson.Write(context, commonDao.Combobox(dt_New));
        }

        /// <summary>
        /// 投注来源方式下拉列表
        /// </summary>
        public void SrcTypeCombobox()
        {
            WebJson.Write(context, commonDao.Combobox(EnumSelectListHelper.CreatSelectListByEnum(typeof(SrcType))));
        }

        /// <summary>
        /// 处罚类型
        /// </summary>
        public void PunishmentTypeCombobox()
        {
            WebJson.Write(context, commonDao.Combobox(EnumSelectListHelper.CreatSelectListByEnum(typeof(PunishmentType))));
        }
        /// <summary>
        /// 站点名称
        /// </summary>
        /// <param name="typeCode"></param>
        public void StationCombobox()
        {
            WebJson.Write(context, commonDao.Combobox("SELECT [站点名称] name ,[主机编号] id FROM [主机登记]", null));
        }
    }
}
