using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Client;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using Com.ZY.BLD.Util;
using System.Data;
using System.Web.SessionState;
using NPOI.HSSF.Util;
using Com.ZY.JXKK.BLL.Agent;

namespace Com.ZY.JXKK.StatisticsReport.Handler
{
    /// <summary>
    /// 客户信息报表
    /// </summary>
    public class ClientHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            LoginUser loginUser = new LoginUser(context, "ClientReport");
            ClientBLL bll = new ClientBLL(context, loginUser);

            if (context.Request["action"] == "agentListLoad")
            {
                Combobox com = new Combobox(context, loginUser);
                com.AgentCombobox();
            }
            if (context.Request["action"] == "siteListLoad")
            {
                string agentId = context.Request["agentId"];
                Combobox com = new Combobox(context, loginUser);
                com.SiteByAgentCombobox(agentId);
            }
            //加载DataGrid
            if (context.Request["action"] == "gridLoad")
            {
                int page = int.Parse(context.Request["page"]);
                int rows = int.Parse(context.Request["rows"]);
                string startDate = context.Request["startDate"];
                string endDate = context.Request["endDate"];
                string agentId = context.Request["agentId"];
                string siteId = context.Request["siteId"];
                string status = context.Request["status"];
                bll.ClientLoadGrid(page, rows, startDate, endDate, agentId,siteId, status);
            }
            if (context.Request["action"] == "ToExcel")
            {
                AgentBLL  agentBLL=new AgentBLL(context,loginUser);
                SiteBLL siteBLL = new SiteBLL(context, loginUser);
                string startDate = context.Request["startDate"];
                string endDate = context.Request["endDate"];
                string agentId = context.Request["agentId"];
                string siteId = context.Request["siteId"];
                string status = context.Request["status"];
                var agentName = "";
                var siteName = "";
                var usedStatus="全部";
                if (!string.IsNullOrEmpty(agentId))
                    agentName= agentBLL.Get(agentId).agentName;
                if (!string.IsNullOrEmpty(siteId))
                    siteName = siteBLL.Get(siteId).siteName;
                if(!string.IsNullOrEmpty(status))
                {
                    if(status=="0")
                        usedStatus="激活";
                    else if(status=="1")
                        usedStatus="封存";
                }
                    
                DataTable dt = bll.ClientReport(startDate, endDate,agentId, siteId, status);
                context.Response.ContentType = "application/x-excel";
                string fileName = HttpUtility.UrlEncode(startDate + "至" + endDate + "客户信息报表.xls");
                context.Response.AddHeader("Content-Disposition", "attachment; fileName=" + fileName);
                IWorkbook workbook = new HSSFWorkbook();
                //创建表  
                ISheet sheet = workbook.CreateSheet("客户信息报表");
                //设置单元的宽度  
                sheet.SetColumnWidth(0, 15 * 256);
                sheet.SetColumnWidth(1, 15 * 256);
                sheet.SetColumnWidth(2, 15 * 256);
                sheet.SetColumnWidth(3, 20 * 256);
                sheet.SetColumnWidth(4, 20 * 256);
                sheet.SetColumnWidth(5, 20 * 256);
                sheet.SetColumnWidth(6, 15 * 256);
                #region 合并单元格
                CellRangeAddress regionTitle = new CellRangeAddress(0, 0, 0, 6);
                sheet.AddMergedRegion(regionTitle);
                CellRangeAddress regionDate = new CellRangeAddress(1, 1, 0, 6);
                sheet.AddMergedRegion(regionDate);

                //CellRangeAddress（）该方法的参数次序是：开始行号，结束行号，开始列号，结束列号。

                IRow row0 = sheet.CreateRow(0);
                row0.Height = 20 * 20;
                ICell icell1top0 = row0.CreateCell(0);
                icell1top0.SetCellValue("客户信息报表");
                NOPIHelper.RegionMethod(workbook, sheet, regionTitle, NOPIHelper.Stylexls.标题);
                IRow row1 = sheet.CreateRow(1);
                row1.Height = 20 * 20;
                ICell icell1top1 = row1.CreateCell(0);
                icell1top1.SetCellValue("日期:" + startDate + "至" + endDate + " 代理商:" + agentName + " 执法文书类型:" + siteName + " 使用状态:" + usedStatus + "");
                NOPIHelper.RegionMethod(workbook, sheet, regionDate, NOPIHelper.Stylexls.头);
                #endregion
                #region 设置表头
                int rowsNum = 2;  //行号
                IRow row2 = sheet.CreateRow(rowsNum);
                row2.Height = 20 * 20;

                ICell icell1top = row2.CreateCell(0);
                icell1top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell1top.SetCellValue("客户编号");

                ICell icell2top = row2.CreateCell(1);
                icell2top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell2top.SetCellValue("客户名称");

                ICell icell3top = row2.CreateCell(2);
                icell3top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell3top.SetCellValue("执法文书类型");

                ICell icell4top = row2.CreateCell(3);
                icell4top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell4top.SetCellValue("卡号");

                ICell icell5top = row2.CreateCell(4);
                icell5top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell5top.SetCellValue("账户余额");

                ICell icell6top = row2.CreateCell(5);
                icell6top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell6top.SetCellValue("冻结金额");

                ICell icell7top = row2.CreateCell(6);
                icell7top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell7top.SetCellValue("使用状态");
                #endregion

                rowsNum = 3;  //行号
                ICellStyle cellStyleMoney =NOPIHelper.Getcellstyle(workbook,NOPIHelper.Stylexls.钱);
                ICellStyle cellStyleDefault = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.默认);

                foreach (DataRow dr in dt.Rows)
                {
                    /******************写入字段值*********************/
                    row2 = sheet.CreateRow(rowsNum);
                    ICell icel1ClientId = row2.CreateCell(0);
                    icel1ClientId.SetCellValue(dr["ClientId"].ToString());
                    icel1ClientId.CellStyle = cellStyleDefault;

                    ICell icellClientName = row2.CreateCell(1);
                    icellClientName.SetCellValue(dr["ClientName"].ToString());
                    icellClientName.CellStyle = cellStyleDefault;

                    ICell icellSiteName = row2.CreateCell(2);
                    icellSiteName.SetCellValue(dr["SiteName"].ToString());
                    icellSiteName.CellStyle = cellStyleDefault;

                    ICell icel1CardId = row2.CreateCell(3);
                    icel1CardId.SetCellValue(dr["CardId"].ToString());
                    icel1CardId.CellStyle = cellStyleDefault;

                    ICell icel1Balance = row2.CreateCell(4);
                    icel1Balance.SetCellValue(double.Parse(dr["Balance"].ToString()));
                    icel1Balance.CellStyle = cellStyleMoney; 

                    ICell icel1LockFee = row2.CreateCell(5);
                    icel1LockFee.SetCellValue(double.Parse(dr["LockFee"].ToString()));
                    icel1LockFee.CellStyle = cellStyleMoney; 

                    ICell icel1Status = row2.CreateCell(6);
                    icel1Status.SetCellValue((dr["Status"].ToString()=="0"?"激活":"封存"));
                    icel1Status.CellStyle = cellStyleDefault;

                    rowsNum++;
                }
                workbook.Write(context.Response.OutputStream);  //输出到流中
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}