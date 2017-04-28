using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.BLL;

namespace Com.ZY.JXKK.WebMis.Reports
{
    public partial class AgentRechargeRT : System.Web.UI.Page
    {
        HttpContext context = null;
        LoginUser loginSession = new LoginUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BandingReports("","","");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string agentName = this.tbAgentName.Text;
            string startDate = this.txtStartDate.Text;
            string endDate = this.txtEndDate.Text;
            BandingReports(agentName, startDate, endDate);
        }

        private void BandingReports(string agentName,string startDate, string endDate)
        {
            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("startDate", startDate);
            parameters[1] = new ReportParameter("endDate", endDate);
            AgentRechargeBLL bll = new AgentRechargeBLL(context, loginSession);
            System.Data.DataSet ds = new DataSet();
            ds = bll.GetDataSet(agentName, startDate,endDate);
            this.ReportViewer1.Reset();
            this.ReportViewer1.LocalReport.ReportPath = @"Reports\AgentRecharge.rdlc";
            this.ReportViewer1.LocalReport.DisplayName = "代理商充值";
            this.ReportViewer1.LocalReport.SetParameters(parameters);

            ReportDataSource rds = new ReportDataSource("AgentRechargeDataSet", ds.Tables[0]);
            this.ReportViewer1.LocalReport.DataSources.Add(rds);
            this.ReportViewer1.LocalReport.Refresh();
        }
    }
}