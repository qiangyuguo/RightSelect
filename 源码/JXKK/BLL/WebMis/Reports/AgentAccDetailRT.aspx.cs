using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Agent;
using System.Net;
using System.IO;
using System.Text;

namespace Com.ZY.JXKK.WebMis.Reports
{
    public partial class AgentAccDetailRT : System.Web.UI.Page
    {
        LoginUser loginSession = new LoginUser();
        HttpContext context = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
            {
                AgentAccDetailBLL bll = new AgentAccDetailBLL(context, loginSession);
                System.Data.DataSet ds = new DataSet();
                ds = bll.GetDataSet();
                this.ReportViewer1.Reset();
                this.ReportViewer1.LocalReport.ReportPath = @"Reports\AgentAccDetail.rdlc";
                this.ReportViewer1.LocalReport.DisplayName = "代理商账户明细";
                ReportDataSource rds = new ReportDataSource("AgentAccDetailDataSet", ds.Tables[0]);
                this.ReportViewer1.LocalReport.DataSources.Add(rds);
                this.ReportViewer1.LocalReport.Refresh();
            }

        }

        public void Test()
        {
            string strResult = "";
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://p.geiqian.com/ajax/BaseInfo.ashx?method=getLog&lm=1");
                myRequest.Method = "get";
                myRequest.ContentType = "application/Json";
                try
                { 
                    HttpWebResponse HttpWResp = (HttpWebResponse)myRequest.GetResponse();
                    Stream myStream = HttpWResp.GetResponseStream();
                    StreamReader sr = new StreamReader(myStream, Encoding.GetEncoding("gb2312"));
                    StringBuilder strBuilder = new StringBuilder();
                    while (-1 != sr.Peek())
                    {
                        strBuilder.Append(sr.ReadLine());
                    }
                    strResult = strBuilder.ToString();
                }
                catch (Exception e)
                {

                    strResult = "错误：" + e.Message;
                }
            }
            catch (Exception e)
            {
                strResult = "错误：" + e.Message;
            }
            
        }
    }
}