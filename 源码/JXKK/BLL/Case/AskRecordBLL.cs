using Com.Data;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.Util;
using JXKK.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Com.ZY.JXKK.BLL.Case
{
    public class AskRecordBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        //private CommonDao commonDao = new CommonDao();
        protected DataAccess db = new DataAccess(DataAccess.DBConn);
        public AskRecordBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        public bool IsExist(string caseId)
        {
            Param param = new Param();
            string strSQL = " select count(*) from TB_Cgs_AskNote12 where CaseId=@caseId ";
            param.Add("@caseId", caseId);
            try
            {
                db.Open();
                object str = db.ExecuteScalar(CommandType.Text, strSQL, param);
                int count;
                if (int.TryParse(str.ToString(), out count))
                {
                    if (count > 0)
                    {
                        return true;
                    }
                }
               
            }
            catch
            {

            }
            finally
            {
                db.Close();
            }
            return false;
        }
        public void Load(string caseId)
        {
            Cgs_AskNote12 chufa = null;
            Param param = new Param();
            string strSQL = " select top 1 * from TB_Cgs_AskNote12 where CaseId=@caseId ";
            param.Add("@caseId", caseId);
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    chufa = ReadData(dr);
                }
                WebJson.ToJson(context, chufa);
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                db.Close();
            }
            // string str = db.DataGridTemp(strSQL, param);
           

        }
        public void OnlyLoadCaseCarNoAndStationName(string caseId)
        {
            Cgs_AskNote12 chufa = null;
            Param param = new Param();
            string strSQL = " select top 1 * from TBCase where CaseId=@caseId ";
            param.Add("@caseId", caseId);
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    chufa = ReadDataOnlyCaseCarNoAndStationName(dr);
                }
                WebJson.ToJson(context, chufa);
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                db.Close();
            }
            // string str = db.DataGridTemp(strSQL, param);
            
        }
        public Cgs_AskNote12 ReadData(ComDataReader dr)
        {
            Cgs_AskNote12 askNote12 = new Cgs_AskNote12();

            ReadEntity(dr, askNote12);

            return askNote12;
        }

        private static void ReadEntity(ComDataReader dr, Cgs_AskNote12 askNote12)
        {
            askNote12.canid = dr["canid"].ToString();
            askNote12.CaseId = dr["CaseId"].ToString();
            askNote12.cantime1 = dr["cantime1"].ToString();
            askNote12.cantime2 = dr["cantime2"].ToString();
            askNote12.canAddress = dr["canAddress"].ToString();
            askNote12.canaskman = dr["canaskman"].ToString();
            askNote12.canaskmanComp = dr["canaskmanComp"].ToString();
            askNote12.canaskmanbook1 = dr["canaskmanbook1"].ToString();
            askNote12.canaskmanbook2 = dr["canaskmanbook2"].ToString();
            askNote12.canrecodman = dr["canrecodman"].ToString();
            askNote12.canrecodmanComp = dr["canrecodmanComp"].ToString();
            askNote12.canrecodmanbook1 = dr["canrecodmanbook1"].ToString();
            askNote12.canrecodmanbook2 = dr["canrecodmanbook2"].ToString();
            askNote12.canaskedman = dr["canaskedman"].ToString();
            askNote12.canaskedmansex = dr["canaskedmansex"].ToString();
            askNote12.canaskedmanold = dr["canaskedmanold"].ToString();
            askNote12.canaskedmanrelation = dr["canaskedmanrelation"].ToString();
            askNote12.canaskedmancomp = dr["canaskedmancomp"].ToString();
            askNote12.canaskedmantele = dr["canaskedmantele"].ToString();
            askNote12.canaskedmanhome = dr["canaskedmanhome"].ToString();
            askNote12.canaskedmanzip = dr["canaskedmanzip"].ToString();
            askNote12.canmycomp = dr["canmycomp"].ToString();
            askNote12.canmyname = dr["canmyname"].ToString();
            askNote12.canmybook1 = dr["canmybook1"].ToString();
            askNote12.canmybook2 = dr["canmybook2"].ToString();
            askNote12.canhe = dr["canhe"].ToString();
            askNote12.canhename = dr["canhename"].ToString();
            askNote12.canhebook1 = dr["canhebook1"].ToString();
            askNote12.canhebook2 = dr["canhebook2"].ToString();
            askNote12.cananser1 = dr["cananser1"].ToString();
            askNote12.canmycarno = dr["canmycarno"].ToString();
            askNote12.canmycarkind = dr["canmycarkind"].ToString();
            askNote12.canmycarnum = dr["canmycarnum"].ToString();
            askNote12.cansign1 = dr["cansign1"].ToString();
            askNote12.cansign2 = dr["cansign2"].ToString();
            askNote12.cancargoods = dr["cancargoods"].ToString();
            askNote12.cancarfrom = dr["cancarfrom"].ToString();
            askNote12.cancarto = dr["cancarto"].ToString();
            askNote12.cancarlong = dr["cancarlong"].ToString();
            askNote12.cancarweight1 = dr["cancarweight1"].ToString();
            askNote12.cancarweight2 = dr["cancarweight2"].ToString();
            askNote12.cancardesc = dr["cancardesc"].ToString();
            askNote12.canreview1 = dr["canreview1"].ToString();
            askNote12.canreview2 = dr["canreview2"].ToString();
            askNote12.cananser2 = dr["cananser2"].ToString();
            askNote12.canyou = dr["canyou"].ToString();
            askNote12.cananser3 = dr["cananser3"].ToString();
            askNote12.cananser4 = dr["cananser4"].ToString();
            askNote12.cananser5 = dr["cananser5"].ToString();
            askNote12.candsign1 = dr["candsign1"].ToString();
            askNote12.candsign2 = dr["candsign2"].ToString();
            askNote12.canasksign = dr["canasksign"].ToString();
            askNote12.canrecordsign = dr["canrecordsign"].ToString();
            askNote12.canwenshunum = dr["canwenshunum"].ToString();
            askNote12.CreateDate1 = dr["CreateDate1"].ToString();
            askNote12.CreateUserId1 = dr["CreateUserId1"].ToString();
            askNote12.CreateUserName1 = dr["CreateUserName1"].ToString();
            askNote12.ModifyDate1 = dr["ModifyDate1"].ToString();
            askNote12.ModifyUserId1 = dr["ModifyUserId1"].ToString();
            askNote12.ModifyUserName1 = dr["ModifyUserName1"].ToString();
        }
        public Cgs_AskNote12 ReadDataOnlyCaseCarNoAndStationName(ComDataReader dr)
        {
            Cgs_AskNote12 chufa = new Cgs_AskNote12();
            ReadEntity(dr, chufa);
            return chufa;
        }
        public void AddOrUpdate(HttpContext context)
        {
            SqlServerHelper helper = new SqlServerHelper();
            var pkValue = context.Request["jdid"];
            var ht = ControlBindHelper.GetWebControlsValue(context,16);
            if (string.IsNullOrEmpty(pkValue))
            {
                ht["jdid"] = Guid.NewGuid().ToString();
                if (helper.InsertByHashtable("TB_Cgs_AskNote12", ht) > 0)
                {
                    Message.success(context, "询问笔录增加成功");
                }
                else
                {
                    Message.success(context, "询问笔录增加失败");
                }
            }
            else
            {
                if (helper.UpdateByHashtable("TB_Cgs_AskNote12", "jdid", pkValue, ht) > 0)
                {
                    Message.success(context, "询问笔录修改成功");
                }
                else
                {
                    Message.success(context, "询问笔录修改失败");
                }
            }

        }

    }
}
