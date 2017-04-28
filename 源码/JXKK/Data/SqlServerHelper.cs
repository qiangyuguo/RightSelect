using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Com.Data
{
    public class SqlServerHelper
    {
        protected DataAccess db = new DataAccess(DataAccess.DBConn);//数据库连接
        public bool Submit_AddOrEdit(string tableName, string pkName, string pkVal, Hashtable ht)
        {
            bool result;
            if (string.IsNullOrEmpty(pkVal))
            {
                result = (this.InsertByHashtable(tableName, ht) > 0);
            }
            else
            {
                result = (this.UpdateByHashtable(tableName, pkName, pkVal, ht) > 0);
            }
            return result;
        }
        public int UpdateByHashtable(string tableName, string pkName, string pkVal, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Update ");
            sb.Append(tableName);
            sb.Append(" Set ");
            bool isFirstValue = true;
            foreach (string key in ht.Keys)
            {
                if (isFirstValue)
                {
                    isFirstValue = false;
                    sb.Append(key);
                    sb.Append("=");
                    sb.Append("@" + key);
                }
                else
                {
                    sb.Append("," + key);
                    sb.Append("=");
                    sb.Append("@" + key);
                }
            }
            sb.Append(" Where ").Append(pkName).Append("=").Append("@" + pkName);
            ht[pkName] = pkVal;
            Param _params = this.GetParameter(ht);
            return this.ExecuteBySql(sb, _params);
        }
        public  int InsertByHashtable(string tableName, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Insert Into ");
            sb.Append(tableName);
            sb.Append("(");
            StringBuilder sp = new StringBuilder();
            StringBuilder sb_prame = new StringBuilder();
            foreach (string key in ht.Keys)
            {
                sb_prame.Append("," + key);
                sp.Append(",@" + key);
            }
            sb.Append(sb_prame.ToString().Substring(1, sb_prame.ToString().Length - 1) + ") Values (");
            sb.Append(sp.ToString().Substring(1, sp.ToString().Length - 1) + ")");
            return this.ExecuteBySql(sb, this.GetParameter(ht));
        }
        public Param GetParameter(Hashtable ht)
        {
            Param _params = new Param();
            int i = 0;
            foreach (string key in ht.Keys)
            {
                _params.Add("@" + key, ht[key]);
                i++;
            }
            return _params;
        }
        public int ExecuteBySql(StringBuilder sql, Param param)
        {
            int num = 0;
            try
            {
                  ComTransaction trans = null;
                   
                    try
                    {
                        db.Open();
                        num = this.db.ExecuteNonQuery(CommandType.Text, sql.ToString(), param);
                        trans.Commit();
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        num = -1;
                       
                    }
                    finally
                    {
                        db.Close();
                    }
                
            }
            catch (Exception e)
            {
                
            }
            return num;
        }
    }
}
