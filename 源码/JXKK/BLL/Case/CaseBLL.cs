using Com.Data;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Case;
using Com.ZY.JXKK.Json;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Com.ZY.JXKK.BLL.Case
{
    public class CaseBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBCaseDAO tbCaseDAO = new TBCaseDAO();

        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public CaseBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        public CaseBLL()
        {

        }

        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows, string tbCaseId, string tbCaseReason, string openDateFrom, string openDateTo, string closeDateFrom, string closeDateTo, string caseState, string caseCarNo, string caseType, int CaseStatus)
        {
            Param param = new Param();
            string strSQL = "SELECT  CaseId,CaseReason,CaseFrom,CasePersonName,CasePersonSex ,CasePersonAge ,CasePersonAddress,CasePersonRepresentative,CasePersonCompanyName ,CasePersonCompanyLegalPerson,CasePersonCompanyLegalRepresentative"
            + " ,CasePersonCompanyLegalAgent,convert(varchar, CaseOpenDate, 111) as CaseOpenDate,convert(varchar, CaseCloseDate, 111)as CaseCloseDate ,CaseFillingDate,CaseExpirationDate,CaseExecutive,StationName ,CaseProcessPersonOne,CaseProcessPersonOneEnforcementNumberOne"
            + " ,CaseProcessPersonTwo,CaseProcessPersonOneEnforcementNumberTwo ,CaseProcessPersonThree ,CaseProcessPersonOneEnforcementNumberThree ,CaseCarNo ,CaseResult ,CaseTypeName  ,CaseStateName  ,CreateUserName,CreateDate from TBCase a where CaseStatus= " + CaseStatus;
            if (!string.IsNullOrEmpty(tbCaseId))
            {
                strSQL += " and a.CaseId =@tbCaseId ";
                param.Add("@tbCaseId", tbCaseId);
            }
            if (!string.IsNullOrEmpty(caseType))
            {
                PunishmentType punishmentType;
                if (Enum.TryParse(caseType, out punishmentType))
                {
                    strSQL += " and a.CaseTypeName=@CaseTypeName";
                    param.Add("@CaseTypeName", Enum.GetName(typeof(PunishmentType), punishmentType));
                }
            }

            if (!string.IsNullOrEmpty(tbCaseReason))
            {
                strSQL += " and a.CaseReason like @tbCaseReason";
                param.Add("@tbCaseReason", "%" + tbCaseReason + "%");
            }

            if (!string.IsNullOrEmpty(openDateFrom) && !string.IsNullOrEmpty(openDateTo))
            {
                strSQL += " and CaseOpenDate between @CaseOpenDateFrom and @CaseOpenTo";
                param.Add("@CaseOpenDateFrom", openDateFrom);
                param.Add("@CaseOpenTo", openDateTo);
            }
            else if (!string.IsNullOrEmpty(openDateFrom) && string.IsNullOrEmpty(openDateTo))
            {
                strSQL += " and CaseOpenDate > @CaseOpenDateFrom";
                param.Add("@CaseOpenDateFrom", openDateFrom);
            }
            else if (string.IsNullOrEmpty(openDateFrom) && !string.IsNullOrEmpty(openDateTo))
            {
                strSQL += " and CaseOpenDate < @CaseOpenTo";
                param.Add("@CaseOpenTo", openDateTo);
            }
            else
            { }


            if (!string.IsNullOrEmpty(closeDateFrom) && !string.IsNullOrEmpty(closeDateTo))
            {
                strSQL += " and CaseCloseDate between @CaseCloseDateFrom and @CaseCloseDateTo";
                param.Add("@CaseCloseDateFrom", closeDateFrom);
                param.Add("@CaseCloseDateTo", closeDateTo);
            }
            else if (!string.IsNullOrEmpty(closeDateFrom) && string.IsNullOrEmpty(closeDateTo))
            {
                strSQL += " and CaseCloseDate > @CaseCloseDateFrom";
                param.Add("@CaseCloseDateFrom", closeDateFrom);
            }
            else if (string.IsNullOrEmpty(closeDateFrom) && !string.IsNullOrEmpty(closeDateTo))
            {
                strSQL += " and CaseCloseDate < @CaseCloseDateTo";
                param.Add("@CaseCloseDateTo", closeDateTo);
            }
            else
            { }

            if (!string.IsNullOrEmpty(caseState))
            {
                strSQL += " and CaseStateName = @CaseStateName ";
                param.Add("@CaseStateName", caseState);
            }
            if (!string.IsNullOrEmpty(caseCarNo))
            {
                strSQL += " and CaseCarNo like @CaseCarNo ";
                param.Add("@CaseCarNo", '%' + caseCarNo + '%');
            }

            string str = commonDao.DataGrid(strSQL, param, page, rows);
            param.Clear();
            WebJson.Write(context, str);
        }
        public void LoadCarGrid(int page, int rows, string stationName, string carNo, string fromDate, string toDate, string axialType)
        {
            Param param = new Param();
            string strSQL = "  select t1.*,cast(round(车辆宽度,2)as numeric(20,2)) 车辆宽度1,cast(round(超宽比例,2)as numeric(20,2)) 超宽比例1,cast(round(超宽宽度,2)as numeric(20,2)) 超宽宽度1,cast(round(车辆重量,2)as numeric(20,2)) 车辆重量1,cast(round(超重重量,2)as numeric(20,2)) 超重重量1,cast(round(超重比例,2)as numeric(20,2)) 超重比例1,cast(round(车辆高度,2)as numeric(20,2)) 车辆高度1,cast(round(超高高度,2)as numeric(20,2)) 超高高度1,cast(round(超高比例,2)as numeric(20,2)) 超高比例1,convert(varchar, 日期时间, 120) as timed,t2.站点名称 from 车辆数据 as t1,主机登记 as t2 where t1.站点编号=t2.主机编号 ";
            if (!string.IsNullOrEmpty(stationName))
            {
                strSQL += " and t2.主机编号 =@stationNo";
                param.Add("@stationNo", stationName);
            }
            if (!string.IsNullOrEmpty(carNo))
            {
                strSQL += " and t1.车牌号码 like @carNo";
                param.Add("@carNo", "%" + carNo + "%");
            }
            if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                strSQL += " and t1.日期时间 between @obj and @obj1";
                param.Add("@obj", fromDate);
                param.Add("@obj1", toDate);
            }
            else if (!string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate))
            {
                strSQL += " and t1.日期时间 > @obj";
                param.Add("@obj", fromDate);
            }
            else if (string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                strSQL += " and t1.日期时间< @obj";
                param.Add("@obj", toDate);
            }
            else
            { }
            if (!string.IsNullOrEmpty(axialType))
            {
                strSQL += " and t1.车辆轴数 = @axialType";
                param.Add("@axialType", axialType);
            }
            string str = commonDao.DataGrid(strSQL, param, page, rows);
            param.Clear();
            WebJson.Write(context, str);
        }
        public void LoadEnforcementGrid(string caseId)
        {
            Param param = new Param();
            string strSQL = " select distinct tbet.statu as typeStatu, ce.*,et.TemplateCode,et.TemplateName,et.Height,et.Width from TBCase_EnforementName ce  join TBCase_EnforcementType tbet on tbet.EnforcementTypeId=ce.EnforcementTypeId left join TBEnforcementTemplate et on ce.EnforcementTemplateId=et.TemplateId where ce.CaseId=@caseId and tbet.CaseId=@caseId and ce.EnforcementTypeId=(select CaseCurrentTypeId from TBCase  where CaseId=@caseId)";
            param.Add("@caseId", caseId);
            string str = commonDao.DataGridTemp(strSQL, param);
            param.Clear();
            WebJson.Write(context, str);
        }
        public void LoadEnforcementGridByTypeId(string caseId,string typeId)
        {
            Param param = new Param();
            string strSQL = " select distinct tbet.statu as typeStatu,ce.*,et.TemplateCode,et.TemplateName,et.Height,et.Width from TBCase_EnforementName ce join TBCase_EnforcementType tbet on tbet.EnforcementTypeId=ce.EnforcementTypeId left join TBEnforcementTemplate et on ce.EnforcementTemplateId=et.TemplateId  where ce.CaseId=@caseId and tbet.CaseId=@caseId and ce.EnforcementTypeId=@typeId   ";
            param.Add("@caseId", caseId);
            param.Add("@typeId", typeId);
            string str = commonDao.DataGridTemp(strSQL, param);
            param.Clear();
            WebJson.Write(context, str);
        }
        public void ReadOnlyTreeLoad(string caseId)
        {
            var caseTypes = new TBCaseDAO().GetCaseEnforcementTemplateHash(caseId);
            List<Tree<TBEnforcementTemplate>> list = new List<Tree<TBEnforcementTemplate>>();
            foreach (var item in caseTypes)
            {
                var template = new Tree<TBEnforcementTemplate>()
                {
                    attributes = new TBEnforcementTemplate() { TemplateCode = item.TemplateCode,TemplateName=item.TemplateName },
                    text = item.TemplateName
                };
                list.Add(template);
            }
            WebJson.ToJson(context, list);
        }

        /// <summary>
        /// 加载指定执法文书名称信息
        /// <param name="siteId">执法文书名称编号</param>
        /// </summary>
        public void Load(string tbCaseId)
        {
            try
            {
                TBCase tbCase = tbCaseDAO.Get(tbCaseId);

                WebJson.ToJson(context, tbCase);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        public void Load(string carNo, string stationName)
        {
            try
            {
                TBCase tbCase = new TBCase();
                tbCase.CaseId = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                tbCase.StationName = stationName;
                tbCase.CaseCarNo = carNo;
                tbCase.CasePersonSex = "男";
                WebJson.ToJson(context, tbCase);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }

        /// <summary>
        /// 增加执法文书名称信息
        /// <param name="tbSite">执法文书名称信息</param>
        /// </summary>
        public void Add(TBCase tbCase)
        {
            //判断名称是否重复
            if (tbCaseDAO.Exist("CaseId", tbCase.CaseId))
            {
                Message.error(context, "案件编号重复请重新输入！");
                return;
            }
            try
            {
                tbCaseDAO.Add(tbCase);
                Message.success(context, "案件增加成功");
                loginSession.Log(tbCase.CaseId + "案件增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "案件增加失败");
                loginSession.Log(e.Message);
            }
        }

        /// <summary>
        /// 修改执法文书名称信息
        /// <param name="tbSite">执法文书名称信息</param>
        /// </summary>
        public void Edit(TBCase tbCase)
        {
            //判断是否帐号重复

            try
            {
                tbCaseDAO.Edit(tbCase);
                Message.success(context, "案件信息修改成功");
                loginSession.Log(tbCase.CaseId + "[" + tbCase.CaseId + "]案件信息修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "案件信息修改失败");
                loginSession.Log(e.Message);
            }
        }

        /// <summary>
        /// 获取执法文书名称信息
        /// <param name="siteId">执法文书名称编号</param>
        /// </summary>
        /// <returns>执法文书名称信息对象</returns>
        public TBCase Get(string tbCaseId)
        {
            TBCase tbCase = new TBCase();
            try
            {
                tbCase = tbCaseDAO.Get(tbCaseId);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
            return tbCase;
        }
        /// <summary>
        /// 删除执法文书名称信息
        /// <param name="siteId">执法文书名称编号</param>
        /// </summary>
        public void Delete(string caseId)
        {
            try
            {
                tbCaseDAO.Delete(caseId);
                Message.success(context, "执法文书信息删除成功");
                loginSession.Log("执法文书名称信息删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "执法文书名称信息删除失败");
                loginSession.Log(e.Message);
            }
        }


        public void LoadTree(string caseId)
        {
            //DataSet ds = tbCaseDAO.GetDataSet("select * from TSModule", null);
            var caseTypes = new TBCaseDAO().GetCaseTypeIdHash(caseId);
            List<Tree<TBEnforcementType>> list = new List<Tree<TBEnforcementType>>();
            //List<Tree<TSModule>> list = new List<Tree<TSModule>>(1);
            //Tree<TSModule> treeNode = new Tree<TSModule>();
            //treeNode.text = "系统平台模块";//节点名称
            //TSModule tsModule = new TSModule();
            //tsModule.moduleId = "0";//模块编号
            //tsModule.moduleCode = "";//模块代码
            //tsModule.moduleName = "";//模块名称
            //tsModule.moduleURL = "";//模块URL
            //tsModule.imgClass = "";//模块图片样式
            //tsModule.parentId = "";//父模块编号（"0"代表无父模块）
            //tsModule.moduleLayer = 0;//模块所属层次
            //tsModule.moduleIndex = 0;//模块索引
            //treeNode.attributes = tsModule;
            //AddNode(treeNode, ds, roleRight);//遍历子模块
            //list.Add(treeNode);
            foreach (var item in caseTypes)
            {
                var caseType = new Tree<TBEnforcementType>()
                {
                    attributes = new TBEnforcementType() { EnforcementTypeId = item.EnforcementTypeId },
                    text = item.EnforcementTypeName
                };
                list.Add(caseType);
            }
            WebJson.ToJson(context, list);

        }
        /// <summary>
        /// 获取DataSet(门店信息)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>门店信息DataSet</returns>
        public DataSet GetDataSet(string strSQL)
        {
            Param param = new Param();
            return tbCaseDAO.GetDataSet(strSQL, param);
        }
    }
}
