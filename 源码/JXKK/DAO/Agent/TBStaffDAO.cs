using System;
using System.Data;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Model;
using Com.ZY.JXKK.DBO;
using Com.ZY.JXKK.Util;

namespace Com.ZY.JXKK.DAO.Agent
{
    /// <summary>
    /// 门店员工
    /// Author:开发人员自行扩展
    /// </summary>
    public class TBStaffDAO:TBStaffDBO
    {
        /// <summary>
        /// 事务增加快开厅员工
        /// <param name="tbStaff">快开厅员工</param>
        /// </summary>
        public void AddTrans(TBStaff tbStaff, TSAgentUser tsAgentUser)
        {
            ComTransaction trans = null;
            try
            {
                db.Open();
                trans = db.BeginTransaction();
                Add(db, tbStaff);
                tsAgentUser.userId = tbStaff.staffId;
                tsAgentUser.userPwd = Encrypt.ConvertPwd(tsAgentUser.userId, tsAgentUser.userPwd);
                new TSAgentUserDAO().Add(db, tsAgentUser);
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw e;
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 获取快开厅员工
        /// <param name="staffId">员工编号</param>
        /// </summary>
        /// <returns>快开厅员工对象</returns>
        public TBStaffClon GetClon(string staffId)
        {
            TBStaffClon tbStaffClon = null;
            try
            {
                string strSQL = "select a.*,b.roleId,b.userCode from TBStaff a,TSAgentUser b  where a.staffId=b.userId and b.roleId!='001' and a.staffId=@staffId";
                Param param = new Param();
                param.Clear();
                param.Add("@staffId", staffId);
                db.Open();
                ComDataReader dr = db.ExecuteReader(CommandType.Text, strSQL, param);
                if (dr.Read())
                {
                    tbStaffClon = ReadDataClon(dr);
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
            return tbStaffClon;
        }

        /// <summary>
        /// 读取快开厅员工信息
        /// <param name="dr">记录指针</param>
        /// </summary>
        /// <returns>快开厅员工对象</returns>
        private TBStaffClon ReadDataClon(ComDataReader dr)
        {
            TBStaffClon tbStaffClon = new TBStaffClon();
            tbStaffClon.staffId = dr["staffId"].ToString();//员工编号
            tbStaffClon.siteId = dr["siteId"].ToString();//快开厅编号
            tbStaffClon.agentId = dr["agentId"].ToString();//代理商编号
            tbStaffClon.staffName = dr["staffName"].ToString();//员工姓名
            tbStaffClon.status = dr["status"].ToString();//使用状态
            tbStaffClon.telephone = dr["telephone"].ToString();//手机号码
            tbStaffClon.IDNumber = dr["IDNumber"].ToString();//身份证号
            tbStaffClon.address = dr["address"].ToString();//住址
            tbStaffClon.remark = dr["remark"].ToString();//备注
            tbStaffClon.staffCode = dr["userCode"].ToString();//用户帐号
            tbStaffClon.roleId = dr["roleId"].ToString();//角色
            return tbStaffClon;
        }

        /// <summary>
        /// 事务修改快开厅员工
        /// <param name="tbStaff">快开厅员工</param>
        /// </summary>
        public void EditTrans(TBStaff tbStaff, TSAgentUser tsAgentUser)
        {
            ComTransaction trans = null;
            try
            {
                db.Open();
                trans = db.BeginTransaction();
                Edit(db, tbStaff);
                new TSAgentUserDAO().Edit(db, tsAgentUser, "1");//1为门店员工
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw e;
            }
            finally
            {
                db.Close();
            }
        }

        /// <summary>
        /// 修改快开厅员工
        /// <param name="data">数据库连接</param>
        /// <param name="tbStaff">快开厅员工</param>
        /// </summary>
        public override void Edit(DataAccess data, TBStaff tbStaff)
        {
            string strSQL = "update TBStaff set siteId=@siteId,staffName=@staffName,status=@status,telephone=@telephone,IDNumber=@IDNumber,address=@address,remark=@remark where staffId=@staffId";
            Param param = new Param();
            param.Clear();
            param.Add("@siteId", tbStaff.siteId);//快开厅编号
            param.Add("@staffName", tbStaff.staffName);//员工姓名
            param.Add("@status", tbStaff.status);//使用状态
            param.Add("@telephone", tbStaff.telephone);//手机号码
            param.Add("@IDNumber", tbStaff.IDNumber);//身份证号
            param.Add("@address", tbStaff.address);//住址
            param.Add("@remark", tbStaff.remark);//备注
            param.Add("@staffId", tbStaff.staffId);//员工编号
            data.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        /// <summary>
        /// 删除门店员工
        /// <param name="staffId">员工编号</param>
        /// </summary>
        public void Delete(string staffId,string roleId)
        {
            ComTransaction trans = null;
            try
            {
                db.Open();
                trans = db.BeginTransaction();
                new TSAgentUserDAO().Delete(db, staffId, roleId);
                Delete(db, staffId);
                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
    }
}

