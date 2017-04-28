using Com.Data;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DBO;
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
    public class chufashu01BLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        //private CommonDao commonDao = new CommonDao();
        protected DataAccess db = new DataAccess(DataAccess.DBConn);
        TBCaseDBO caseDBO = new TBCaseDBO();
        public chufashu01BLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        public bool IsExist(string caseId)
        {
            Param param = new Param();
            string strSQL = " select count(*) from TB_Chufajuedingshu31 where CaseId=@caseId ";
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
            chufashu01 chufa = null;
            Param param = new Param();
            string strSQL = " select top 1 * from TB_Chufajuedingshu31 where CaseId=@caseId ";
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
            chufashu01 chufa = null;
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
        public chufashu01 ReadData(ComDataReader dr)
        {
            chufashu01 chufa = new chufashu01();
            chufa.addman = dr["addman"].ToString();
            chufa.addtime = dr["addtime"].ToString();
            chufa.CaseCarNo = dr["CaseCarNo"].ToString();
            chufa.CaseId = dr["CaseId"].ToString();
            chufa.chufazi = dr["chufazi"].ToString();
            chufa.dangshiren = dr["dangshiren"].ToString();
            chufa.dangshirenyu = dr["dangshirenyu"].ToString();
            chufa.dihao = dr["dihao"].ToString();
            chufa.dizhi = dr["dizhi"].ToString();
            chufa.fakuan = dr["fakuan"].ToString();
            chufa.firststr = dr["firststr"].ToString();
            chufa.gongli = dr["gongli"].ToString();
            chufa.guiding = dr["guiding"].ToString();
            chufa.infodate = dr["infodate"].ToString();
            chufa.jdid = dr["jdid"].ToString();
            chufa.jiance = dr["jiance"].ToString();
            chufa.jiaona = dr["jiaona"].ToString();
            chufa.shenpiren = dr["shenpiren"].ToString();
            chufa.shenpishijian = dr["shenpishijian"].ToString();
            chufa.StationName = dr["StationName"].ToString();
            return chufa;
        }
        public chufashu01 ReadDataOnlyCaseCarNoAndStationName(ComDataReader dr)
        {
            chufashu01 chufa = new chufashu01();
            chufa.CaseId = dr["CaseId"].ToString();
            chufa.CaseCarNo = dr["CaseCarNo"].ToString();
            chufa.StationName = dr["StationName"].ToString();
            return chufa;
        }
        public void AddOrUpdate(HttpContext context)
        {
            SqlServerHelper helper = new SqlServerHelper();
            var pkValue = context.Request["jdid"];
            var caseId = context.Request["CaseId"];
            var typeId = context.Request["typeId"];
            var nameId = context.Request["nameId"];
            var ht = ControlBindHelper.GetWebControlsValue(context, 16, 3);
            if (string.IsNullOrEmpty(pkValue))
            {
                ht["jdid"] = Guid.NewGuid().ToString();
                if (helper.InsertByHashtable("TB_Chufajuedingshu31", ht) > 0)
                {
                    if (caseDBO.CheckCaseState(caseId, nameId, typeId))
                    {
                        Message.success(context, "交通行政处罚决定书增加成功");

                    }
                }
                else
                {
                    Message.success(context, "交通行政处罚决定书增加失败");
                }
            }
            else
            {
                if (helper.UpdateByHashtable("TB_Chufajuedingshu31", "jdid", pkValue, ht) > 0)
                {
                    Message.success(context, "交通行政处罚决定书修改成功");
                }
                else
                {
                    Message.success(context, "交通行政处罚决定书修改失败");
                }
            }

        }

    }
}
