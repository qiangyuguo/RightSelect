using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 门店信息
    /// Author:开发人员自行扩展
    /// </summary>
    public class TBSiteDAO:TBSiteDBO
    {
       

        /// <summary>
        /// 审核修改审核状态
        /// </summary>
        /// <param name="tbSite"></param>
        public void Audit(TBSite tbSite)
        {
            string strSQL = "update TBSite set auditStatus=@auditStatus,remark=@remark,status=@status where siteId =@siteId";
            Param param = new Param();
            param.Clear();
            param.Add("@siteId", tbSite.siteId);
            param.Add("@auditStatus", tbSite.auditStatus);
            param.Add("@status", tbSite.status);
            param.Add("@remark", tbSite.remark);
            try
            {
                db.Open();
                db.ExecuteNonQuery(CommandType.Text, strSQL, param);
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
        /// 增加快开厅信息
        /// <param name="data">数据库连接</param>
        /// <param name="tbSite">快开厅信息</param>
        /// </summary>
        public override void Add(DataAccess data, TBSite tbSite)
        {
            string strSQL = "insert into TBSite (siteId,agentId,siteName,address,contact,pointRule,telephone,auditStatus,status,specialArea,remark) values (@siteId,@agentId,@siteName,@address,@contact,@pointRule,@telephone,@auditStatus,@status,@specialArea,@remark)";
            Param param = new Param();
            param.Clear();
            param.Add("@siteId", tbSite.siteId);//快开厅编号
            param.Add("@agentId", tbSite.agentId);//代理商编号
            param.Add("@siteName", tbSite.siteName);//快开厅名称
            param.Add("@address", tbSite.address);//详细地址
            param.Add("@contact", tbSite.contact);//联系人
            param.Add("@pointRule", tbSite.pointRule);//积分/元
            param.Add("@telephone", tbSite.telephone);//手机号码
            param.Add("@auditStatus", tbSite.auditStatus);//审批状态
            param.Add("@status", "0");//使用状态
            param.Add("@specialArea", tbSite.specialArea);//专营面积
            param.Add("@remark", tbSite.remark);//备注说明
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 修改快开厅信息
        /// <param name="data">数据库连接</param>
        /// <param name="tbSite">快开厅信息</param>
        /// </summary>
        public override void Edit(DataAccess data, TBSite tbSite)
        {
            string strSQL = "update TBSite set siteName=@siteName,address=@address,contact=@contact,pointRule=@pointRule,telephone=@telephone,status=@status,auditStatus=@auditStatus,specialArea=@specialArea,remark=@remark where siteId=@siteId";
            Param param = new Param();
            param.Clear();
            param.Add("@siteName", tbSite.siteName);//快开厅名称
            param.Add("@address", tbSite.address);//详细地址
            param.Add("@contact", tbSite.contact);//联系人
            param.Add("@pointRule", tbSite.pointRule);//积分/元
            param.Add("@telephone", tbSite.telephone);//手机号码
            param.Add("@status", tbSite.status);//使用状态
            param.Add("@auditStatus", tbSite.auditStatus);//审核状态
            param.Add("@remark", tbSite.remark);//备注说明
            param.Add("@siteId", tbSite.siteId);//快开厅编号
            param.Add("@specialArea", tbSite.specialArea);//专营面积
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }
    }
}

