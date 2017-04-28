using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.ZY.JXKK.Model;
using Com.Data;
using System.Data;
using System.Collections;

namespace Com.ZY.JXKK.DBO
{ /// <summary>
    /// 案件名称管理
    /// 
    /// </summary>
    public class TBCaseDBO
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接


        /// <summary>
        /// 新增文案类型
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tbCase"></param>
        public virtual void Add(DataAccess data, TBCase tbCase)
        {
            string strSQL = "insert into TBCase (CaseId,CaseReason, CaseFrom, CasePersonName, CasePersonAddress,"
            + " CasePersonAge, CasePersonSex, CasePersonRepresentative,CasePersonCompanyName,CasePersonCompanyLegalPerson,CasePersonCompanyLegalRepresentative,CasePersonCompanyLegalAgent, CaseOpenDate, CaseCloseDate,"
            + " CaseFillingDate, CaseExecutive, StationName, CaseProcessPersonOne, CaseProcessPersonOneEnforcementNumberOne, CaseProcessPersonTwo,"
            + " CaseProcessPersonOneEnforcementNumberTwo, CaseProcessPersonThree, CaseProcessPersonOneEnforcementNumberThree,CaseCarNo,"
            + " CaseResult, CaseTypeName, CaseStateName,CaseStatus,CreateUserName, CreateDate) values(@CaseId,@CaseReason,@CaseFrom,@CasePersonName,@CasePersonAddress,"
            + "@CasePersonAge,@CasePersonSex,@CasePersonRepresentative,@CasePersonCompanyName,@CasePersonCompanyLegalPerson,@CasePersonCompanyLegalRepresentative,@CasePersonCompanyLegalAgent,@CaseOpenDate,@CaseCloseDate,"
            + "@CaseFillingDate,@CaseExecutive,@StationName,@CaseProcessPersonOne,@CaseProcessPersonOneEnforcementNumberOne,@CaseProcessPersonTwo,"
            + "@CaseProcessPersonOneEnforcementNumberTwo,@CaseProcessPersonThree,@CaseProcessPersonOneEnforcementNumberThree,@CaseCarNo,"
            + "@CaseResult,@CaseTypeName,@CaseStateName,@CaseStatus,@CreateUserName,@CreateDate)";
            Param param = new Param();
            param.Clear();
            param.Add("@CaseId", tbCase.CaseId);//文书类型编号
            param.Add("@CaseReason", tbCase.CaseReason);//文书类型名称
            param.Add("@CaseFrom", tbCase.CaseFrom);
            param.Add("@CasePersonName", tbCase.CasePersonName);
            param.Add("@CasePersonAddress", tbCase.CasePersonAddress);
            param.Add("@CasePersonAge", tbCase.CasePersonAge);
            param.Add("@CasePersonSex", tbCase.CasePersonSex);
            param.Add("@CasePersonRepresentative", tbCase.CasePersonRepresentative);
            param.Add("@CasePersonCompanyName", tbCase.CasePersonCompanyName);
            param.Add("@CasePersonCompanyLegalPerson", tbCase.CasePersonCompanyLegalPerson);
            param.Add("@CasePersonCompanyLegalRepresentative", tbCase.CasePersonCompanyLegalRepresentative);
            param.Add("@CasePersonCompanyLegalAgent", tbCase.CasePersonCompanyLegalAgent);
            param.Add("@CaseOpenDate", tbCase.CaseOpenDate);
            param.Add("@CaseCloseDate", tbCase.CaseCloseDate);
            param.Add("@CaseFillingDate", tbCase.CaseFillingDate);
            param.Add("@CaseExecutive", tbCase.CaseExecutive);
            param.Add("@StationName", tbCase.StationName);
            param.Add("@CaseProcessPersonOne", tbCase.CaseProcessPersonOne);
            param.Add("@CaseProcessPersonOneEnforcementNumberOne", tbCase.CaseProcessPersonOneEnforcementNumberOne);
            param.Add("@CaseProcessPersonTwo", tbCase.CaseProcessPersonTwo);
            param.Add("@CaseProcessPersonOneEnforcementNumberTwo", tbCase.CaseProcessPersonOneEnforcementNumberTwo);
            param.Add("@CaseProcessPersonThree", tbCase.CaseProcessPersonThree);
            param.Add("@CaseProcessPersonOneEnforcementNumberThree", tbCase.CaseProcessPersonOneEnforcementNumberThree);
            param.Add("@CaseCarNo", tbCase.CaseCarNo);
            param.Add("@CaseResult", tbCase.CaseResult);
            //param.Add("@CaseTypeName", tbCase.CaseTypeName);
            param.Add("@CaseStateName", tbCase.CaseStateName);
            param.Add("@CaseStatus", 0);
            param.Add("@CreateDate", tbCase.CreateDate);
            param.Add("@CreateUserName", tbCase.CreateUserName);
            PunishmentType punishmentType;
            if (Enum.TryParse(tbCase.CaseTypeName, out punishmentType))
            {
                //tbCase.CaseTypeName = Enum.GetName(typeof(PunishmentType), punishmentType);
                param.Add("@CaseTypeName",Enum.GetName(typeof(PunishmentType), punishmentType));
            }
            param.Add("@PunishmentType",tbCase.CaseTypeName);
            //添加文书类型，文书名称配置副本

            strSQL += @"declare @i int,@typeCount int,@j int,@nameCount int
select [EnforcementTypeId]
      ,[EnforcementTypeName]
      ,[F1]
      ,[F2]
      ,[CreateDate]
      ,[PunishmentType]
      ,[Statu] into #t from TBEnforcementType where [PunishmentType]=@PunishmentType order by createdate desc
select * from #t
set @i=1
set @typeCount=(select count(*) from #t)
while @i<=@typeCount
   begin
   insert into TBCase_EnforcementType (Id,CaseId,[EnforcementTypeId],[EnforcementTypeName],[F1],[F2],[CreateDate],[PunishmentType],[Statu]) 
   select top 1 NEWID(),@CaseId, [EnforcementTypeId],[EnforcementTypeName],[F1],[F2],[CreateDate],[PunishmentType],[Statu] from #t
   delete top (1) from #t 
   set @i=@i+1
end
DROP TABLE #t
select [EnforcementNameId]
      ,[EnforcementTypeId]
      ,[EnforcementName]
      ,[IsEmpty]
      ,[FillingPerson]
      ,[FillingTime]
      ,[F1]
      ,[CreateDate]
      ,[Statu]
      ,[EnforcementTemplateId] into #t1 from(select * from TBEnForcementName where [EnforcementTypeId] in (select [EnforcementTypeId] from TBEnforcementType where [PunishmentType]=@PunishmentType) ) t   order by createdate desc
select * from #t1
set @j=1
set @nameCount=(select count(*) from #t1)
while @j<=@nameCount
   begin
   insert into TBCase_EnforementName (Id,CaseId,[EnforcementNameId]
      ,[EnforcementTypeId]
      ,[EnforcementName]
      ,[IsEmpty]
      ,[FillingPerson]
      ,[FillingTime]
      ,[F1]
      ,[CreateDate]
      ,[Statu]
      ,[EnforcementTemplateId]) 
   select top 1 NEWID(),@CaseId, [EnforcementNameId]
      ,[EnforcementTypeId]
      ,[EnforcementName]
      ,[IsEmpty]
      ,[FillingPerson]
      ,[FillingTime]
      ,[F1]
      ,[CreateDate]
      ,[Statu]
      ,[EnforcementTemplateId] from #t1
   delete top (1) from #t1 
   set @j=@j+1
end
DROP TABLE #t1
update TBCase set CaseCurrentTypeId=(select top 1 EnforcementTypeId from TBCase_EnforcementType where caseId=@CaseId  order by [EnforcementTypeId]),
CaseStateName=(select top 1 EnforcementTypeName from TBCase_EnforcementType where caseId=@CaseId  order by [EnforcementTypeId]) where caseId=@CaseId 
update TBCase_EnforcementType set statu=2 where EnforcementTypeId=(select top 1 EnforcementTypeId from TBCase_EnforcementType where caseId=@CaseId  order by [EnforcementTypeId]) and caseId=@CaseId";
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
            param.Clear();
        }
        public bool CheckCaseState(string caseId,string nameId,string typeId)
        {
            DataAccess db = new DataAccess(DataAccess.DBConn);
            ComCommand acmd = new ComCommand("CheckCaseState", db.DbConnection);
            acmd.CommandType = System.Data.CommandType.StoredProcedure;
            acmd.Parameters.Add("caseId", caseId);
            acmd.Parameters.Add("nameId", nameId);
            acmd.Parameters.Add("typeId", typeId);
            try
            {
                db.Open();
               int count= acmd.ExecuteNonQuery();
                acmd.Dispose();
                if (count>0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
            return false;
        }

        /// <summary>
        /// 新增文案类型
        /// </summary>
        /// <param name="tbEnforcementName">门店信息</param>
        public virtual void Add(TBCase tbCase)
        {
            try
            {
                db.Open();
                Add(db, tbCase);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 修改门店信息
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="tbSite">门店信息</param>
        public virtual void Edit(DataAccess data, TBCase tbCase)
        {
            string strSQL = "update TBCase set CaseReason=@CaseReason, CaseFrom=@CaseFrom,CasePersonName=@CasePersonName, CasePersonAddress=@CasePersonAddress,"
            + " CasePersonAge=@CasePersonAge, CasePersonSex=@CasePersonSex, CasePersonRepresentative=@CasePersonRepresentative,CasePersonCompanyName=@CasePersonCompanyName,"
            + "CasePersonCompanyLegalPerson=@CasePersonCompanyLegalPerson,CasePersonCompanyLegalRepresentative=@CasePersonCompanyLegalRepresentative,CasePersonCompanyLegalAgent=@CasePersonCompanyLegalAgent,CaseOpenDate=@CaseOpenDate, CaseCloseDate=@CaseCloseDate,"
            + " CaseFillingDate=@CaseFillingDate, CaseExecutive=@CaseExecutive,CaseProcessPersonOne=@CaseProcessPersonOne, CaseProcessPersonOneEnforcementNumberOne=@CaseProcessPersonOneEnforcementNumberOne, CaseProcessPersonTwo=@CaseProcessPersonTwo,"
            + " CaseProcessPersonOneEnforcementNumberTwo=@CaseProcessPersonOneEnforcementNumberTwo, CaseProcessPersonThree=@CaseProcessPersonThree, CaseProcessPersonOneEnforcementNumberThree=@CaseProcessPersonOneEnforcementNumberThree where CaseId=@CaseId";
            Param param = new Param();
            param.Clear();
            param.Add("@CaseId", tbCase.CaseId);//文书类型编号
            param.Add("@CaseReason", tbCase.CaseReason);//文书类型名称
            param.Add("@CaseFrom", tbCase.CaseFrom);
            param.Add("@CasePersonName", tbCase.CasePersonName);
            param.Add("@CasePersonAddress", tbCase.CasePersonAddress);
            param.Add("@CasePersonAge", tbCase.CasePersonAge);
            param.Add("@CasePersonSex", tbCase.CasePersonSex);
            param.Add("@CasePersonRepresentative", tbCase.CasePersonRepresentative);
            param.Add("@CasePersonCompanyName", tbCase.CasePersonCompanyName);
            param.Add("@CasePersonCompanyLegalPerson", tbCase.CasePersonCompanyLegalPerson);
            param.Add("@CasePersonCompanyLegalRepresentative", tbCase.CasePersonCompanyLegalRepresentative);
            param.Add("@CasePersonCompanyLegalAgent", tbCase.CasePersonCompanyLegalAgent);
            param.Add("@CaseOpenDate", tbCase.CaseOpenDate);
            param.Add("@CaseCloseDate", tbCase.CaseCloseDate);
            param.Add("@CaseFillingDate", tbCase.CaseFillingDate);
            param.Add("@CaseExecutive", tbCase.CaseExecutive);
            //param.Add("@StationName", tbCase.StationName);
            param.Add("@CaseProcessPersonOne", tbCase.CaseProcessPersonOne);
            param.Add("@CaseProcessPersonOneEnforcementNumberOne", tbCase.CaseProcessPersonOneEnforcementNumberOne);
            param.Add("@CaseProcessPersonTwo", tbCase.CaseProcessPersonTwo);
            param.Add("@CaseProcessPersonOneEnforcementNumberTwo", tbCase.CaseProcessPersonOneEnforcementNumberTwo);
            param.Add("@CaseProcessPersonThree", tbCase.CaseProcessPersonThree);
            param.Add("@CaseProcessPersonOneEnforcementNumberThree", tbCase.CaseProcessPersonOneEnforcementNumberThree);
            //param.Add("@CaseCarNo", tbCase.CaseCarNo);
            //param.Add("@CaseResult", tbCase.CaseResult);
            //param.Add("@CaseTypeName", tbCase.CaseTypeName);
            //param.Add("@CaseStateName", tbCase.CaseStateName);
            //param.Add("@CreateDate", tbCase.CreateDate);
            //param.Add("@CreateUserName", tbCase.CreateUserName);
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
            param.Clear();
        }

        /// <summary>
        /// 修改门店信息
        /// </summary>
        /// <param name="tbSite">门店信息</param>
        public virtual void Edit(TBCase tbCase)
        {
            try
            {
                db.Open();
                Edit(db, tbCase);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 删除文书编号
        /// </summary>
        /// <param name="data">数据库连接</param>
        /// <param name="caseId">文书名称编号</param>
        public virtual void Delete(DataAccess data, string caseId)
        {
            string strSQL = "update TBCase set CaseStatus=@CaseStatus where caseId=@caseId";
            Param param = new Param();
            param.Clear();
            param.Add("@caseId", caseId);//删除信息
            param.Add("@CaseStatus", 2);//删除信息
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 删除文书编号
        /// </summary>
        /// <param name="caseId">文书名称编号</param>
        public virtual void Delete(string caseId)
        {
            try
            {
                db.Open();
                Delete(db, caseId);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 文书名称信息
        /// </summary>
        /// <param name="siteId">门店编号</param>
        /// <returns>门店信息对象</returns>
        public virtual TBCase Get(string caseId)
        {
            TBCase tbCase = null;
            try
            {
                string strSQL = string.Format(@"SELECT  CaseId,CaseReason,CaseFrom,CasePersonName,CasePersonSex ,CasePersonAge ,CasePersonAddress,CasePersonRepresentative,CasePersonCompanyName ,CasePersonCompanyLegalPerson,CasePersonCompanyLegalRepresentative"
            + " ,CasePersonCompanyLegalAgent,convert(varchar, CaseOpenDate, 111) as CaseOpenDate,convert(varchar, CaseCloseDate, 111)as CaseCloseDate ,CaseFillingDate,CaseExpirationDate,CaseExecutive,StationName ,CaseProcessPersonOne,CaseProcessPersonOneEnforcementNumberOne"
            + " ,CaseProcessPersonTwo,CaseProcessPersonOneEnforcementNumberTwo ,CaseProcessPersonThree ,CaseProcessPersonOneEnforcementNumberThree ,CaseCarNo ,CaseResult ,CaseTypeName  ,CaseStateName  ,CreateUserName,CreateDate from TBCase a  where  a.CaseId=@CaseId");
                Param param = new Param();
                param.Clear();
                param.Add("@CaseId", caseId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbCase = ReadData(dr);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
            return tbCase;
        }




        /// <summary>
        /// 获取列表(门店信息)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>门店信息列表对象</returns>
        public virtual List<TBCase> GetList(string strSQL, Param param)
        {
            List<TBCase> list = new List<TBCase>();
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while (dr.Read())
                {
                    list.Add(ReadData(dr));
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
            return list;
        }

        /// <summary>
        /// 获取列表(门店信息)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>门店信息列表对象</returns>
        public virtual List<TBCase> GetList(string field, string value)
        {
            List<TBCase> list = new List<TBCase>();
            try
            {
                string strSQL = "select * from TBCase where " + field + "=@field";
                Param param = new Param();
                param.Clear();
                param.Add("@field", value);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while (dr.Read())
                {
                    list.Add(ReadData(dr));
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
            return list;
        }
        public List<TBEnforcementType> GetCaseTypeIdHash(string caseId)
        {
            List<TBEnforcementType> hashCaseTypeId = new List<TBEnforcementType>();
            hashCaseTypeId.Clear();
            string strSQL = " select *   from TBCase_EnforcementType where  CaseId=@caseId";
            Param param = new Param();
            param.Clear();
            param.Add("@caseId", caseId);
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL,param);
                while (dr.Read())
                {
                    var item = new TBEnforcementType()
                    {
                       EnforcementTypeId= dr["EnforcementTypeId"].ToString(),
                       EnforcementTypeName = dr["EnforcementTypeName"].ToString()
                    };
                    hashCaseTypeId.Add(item);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                param.Clear();
                db.Close();
            }
            return hashCaseTypeId;
        }
        public List<TBEnforcementTemplate> GetCaseEnforcementTemplateHash(string caseId)
        {
            List<TBEnforcementTemplate> hashCaseEnforcementTemplate = new List<TBEnforcementTemplate>();
            hashCaseEnforcementTemplate.Clear();
            string strSQL = @"  select * from [dbo].[TBEnforcementTemplate] where TemplateId in 
                            (select en.EnforcementTemplateId from  [dbo].[TBCase_EnforementName] en 
                             join [dbo].[TBCase_EnforcementType] et on et.EnforcementTypeId=en.EnforcementTypeId
                             where en.CaseId=@caseId and et.CaseId=@caseId  and en.Statu=2
                            ) ";
            Param param = new Param();
            param.Clear();
            param.Add("@caseId", caseId);
            try
            {
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                while (dr.Read())
                {
                    var item = new TBEnforcementTemplate()
                    {
                        TemplateCode = dr["TemplateCode"].ToString(),
                        TemplateName = dr["TemplateName"].ToString()
                    };
                    hashCaseEnforcementTemplate.Add(item);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                param.Clear();
                db.Close();
            }
            return hashCaseEnforcementTemplate;
        }

        /// <summary>
        /// 获取DataSet(门店信息)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <returns>门店信息DataSet</returns>
        public virtual DataSet GetDataSet(string strSQL, Param param)
        {
            DataSet ds = new DataSet();
            return db.ExecuteDataset(CommandType.Text, strSQL, param, ds, "TBCase");
        }

        /// <summary>
        /// 是否存在记录(门店信息)
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>是否存在</returns>
        public virtual bool Exist(string field, string value)
        {
            int num = 0;
            try
            {
                string strSQL = "select count(*) from TBCase where " + field + "=@field";
                Param param = new Param();
                param.Clear();
                param.Add("@field", value);
                db.Open();
                num = int.Parse(db.ExecuteScalar(CommandType.Text, strSQL, param).ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
            return num > 0;
        }

        /// <summary>
        /// 读取执法文书类型信息
        /// </summary>
        /// <param name="dr">记录指针</param>
        /// <returns>门店信息对象</returns>
        protected virtual TBCase ReadData(ComDataReader dr)
        {
            TBCase tbCase = new TBCase();
            tbCase.CaseId = dr["CaseId"].ToString();//
            tbCase.CaseReason = dr["CaseReason"].ToString();
            tbCase.CaseFrom = dr["CaseFrom"].ToString();
            tbCase.CasePersonName = dr["CasePersonName"].ToString();
            tbCase.CasePersonSex = dr["CasePersonSex"].ToString();//
            tbCase.CasePersonAge = dr["CasePersonAge"].ToString();//
            tbCase.CasePersonAddress = dr["CasePersonAddress"].ToString();//
            tbCase.CasePersonRepresentative = dr["CasePersonRepresentative"].ToString();//
            tbCase.CasePersonCompanyName = dr["CasePersonCompanyName"].ToString();//
            tbCase.CasePersonCompanyLegalPerson = dr["CasePersonCompanyLegalPerson"].ToString();//
            tbCase.CasePersonCompanyLegalAgent = dr["CasePersonCompanyLegalAgent"].ToString();//
            tbCase.CasePersonCompanyLegalRepresentative = dr["CasePersonCompanyLegalRepresentative"].ToString();//
            //tbCase.CaseOpenDate = dr["CaseOpenDate"].ToString();//
            if (dr["CaseOpenDate"] == null)
            {
                tbCase.CaseOpenDate = "";//转账日期
            }
            else
            {
                tbCase.CaseOpenDate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dr["CaseOpenDate"]);//转账日期
            }
            tbCase.CaseCloseDate = dr["CaseCloseDate"].ToString();//
            tbCase.CaseFillingDate = dr["CaseFillingDate"].ToString();//
            tbCase.CaseExpirationDate = dr["CaseExpirationDate"].ToString();//
            tbCase.CaseExecutive = dr["CaseExecutive"].ToString();//
            tbCase.StationName = dr["StationName"].ToString();//
            tbCase.CaseProcessPersonOne = dr["CaseProcessPersonOne"].ToString();//
            tbCase.CaseProcessPersonOneEnforcementNumberOne = dr["CaseProcessPersonOneEnforcementNumberOne"].ToString();//
            tbCase.CaseProcessPersonTwo = dr["CaseProcessPersonTwo"].ToString();//
            tbCase.CaseProcessPersonOneEnforcementNumberTwo = dr["CaseProcessPersonOneEnforcementNumberTwo"].ToString();//
            tbCase.CaseProcessPersonThree = dr["CaseProcessPersonThree"].ToString();//
            tbCase.CaseProcessPersonOneEnforcementNumberThree = dr["CaseProcessPersonOneEnforcementNumberThree"].ToString();//
            tbCase.CaseCarNo = dr["CaseCarNo"].ToString();//
            tbCase.CaseResult = dr["CaseResult"].ToString();//
            tbCase.CaseTypeName = dr["CaseTypeName"].ToString();//
            tbCase.CaseStateName = dr["CaseStateName"].ToString();//
            tbCase.CreateDate = dr["CreateDate"].ToString();//
            tbCase.CreateUserName = dr["CreateUserName"].ToString();//
            return tbCase;
        }

        public bool ChangeCaseStatus(string caseId,string typeId,string nameId)
        {

            return false;
        }


    }
}
