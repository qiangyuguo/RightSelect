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
    public partial class AgentAccountRT : System.Web.UI.Page
    {
        HttpContext context = null;
        LoginUser loginSession = new LoginUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BandingReports("");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string agentName = this.tbAgentName.Text;
            BandingReports(agentName);
        }

        private void BandingReports(string agentName)
        {
            AgentBLL bll = new AgentBLL(context, loginSession);
            System.Data.DataSet ds = new DataSet();
            ds = bll.GetDataSet(agentName);
            this.ReportViewer1.Reset();
            this.ReportViewer1.LocalReport.ReportPath = @"Reports\AgentAccount.rdlc";
            this.ReportViewer1.LocalReport.DisplayName = "代理商账户";
            ReportDataSource rds = new ReportDataSource("AgentDataSet", ds.Tables[0]);
            this.ReportViewer1.LocalReport.DataSources.Add(rds);
            this.ReportViewer1.LocalReport.Refresh();
        }
    }
}