using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Lottery;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using Com.ZY.BLD.Util;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.BLL.Set;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.StatisticsReport.Handler
{
    /// <summary>
    ///销售统计报表
    /// </summary>
    public class SalesInvoiceSummaryHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            LoginUser loginUser = new LoginUser(context, "SalesInvoiceSummaryReport");
            LotteryOrderBLL bll = new LotteryOrderBLL(context, loginUser);
            //加载DataGrid
            if (context.Request["action"] == "gridLoad")
            {
                int page = int.Parse(context.Request["page"]);
                int rows = int.Parse(context.Request["rows"]);
                string startDate = context.Request["startDate"];
                string endDate = context.Request["endDate"];
                string city = context.Request["cityId"];
                string county = context.Request["countyId"];
                string siteId = context.Request["siteId"];
                string agentId = context.Request["agentId"];
                string terminalId = context.Request["terminalId"];
                bll.SalesInvoiceSummaryLoadGrid(page, rows, startDate, endDate, city, county, siteId,agentId,terminalId);
            }
            //获取销售总计
            if (context.Request["action"] == "totalSale")
            {
                string startDate = context.Request["startDate"];
                string endDate = context.Request["endDate"];
                string city = context.Request["cityId"];
                string county = context.Request["countyId"];
                string siteId = context.Request["siteId"];
                string agentId = context.Request["agentId"];
                string terminalId = context.Request["terminalId"];
                DataTable dt = bll.GetCommissionTotalSale(startDate, endDate, city, county, siteId, agentId, terminalId);
                DataRow dr = dt.Rows[0];
                context.Response.Write("{\"totalSumbetfee\":" + dr["totalSumbetfee"] + ",\"totalCommissionFee\":" + dr["totalCommissionFee"] + ",\"totalAwardAmount\":" + dr["totalAwardAmount"] + ",\"totalSumTakeCashFee\":" + dr["totalSumTakeCashFee"] + ",\"totalRefundAmount\":" + dr["totalRefundAmount"] + "}");
            }
            //加载市
            if (context.Request["action"] == "cityListLoad")
            {
                Combobox com = new Combobox(context, loginUser);
                com.CityCombobox();
            }
            //加载区县
            if (context.Request["action"] == "countyListLoad")
            {
                string cityId = context.Request["cityId"];
                Combobox com = new Combobox(context, loginUser);
                com.CountyCombobox(cityId);
            }
            //加载执法文书类型
            if (context.Request["action"] == "siteListLoad")
            {
                Combobox com = new Combobox(context, loginUser);
                string cityId = context.Request["cityId"];
                string countyId = context.Request["countyId"];
                com.SiteByAreaCombobox(cityId, countyId);
            }
            if (context.Request["action"] == "ToExcel")
            {
                string startDate = context.Request["startDate"];
                string endDate = context.Request["endDate"];
                string city = context.Request["cityId"];
                string county = context.Request["countyId"];
                string siteId = context.Request["siteId"];
                string agentId = context.Request["agentId"];
                string terminalId = context.Request["terminalId"];
                AgentAccDetailBLL agentAccDetailBLL = new AgentAccDetailBLL(context, loginUser);
                DataTable dt = bll.SalesInvoiceSummaryReport(startDate, endDate, city, county, siteId, agentId,terminalId);
                //获取预存款余额
                List<TTAgentAccDetail> balanceList = agentAccDetailBLL.GetTTAgentAccDetailList(city, county, siteId, agentId, terminalId);
                int dtRowsCount = dt.Rows.Count+5;
                context.Response.ContentType = "application/x-excel";
                string fileName = HttpUtility.UrlEncode(startDate + "至" + endDate + "销售统计报表.xls");
                context.Response.AddHeader("Content-Disposition", "attachment; fileName=" + fileName);
                IWorkbook workbook = new HSSFWorkbook();
                //创建表  
                ISheet sheet = workbook.CreateSheet("销售统计报表");
                //设置单元的宽度  
                sheet.SetColumnWidth(0, 20 * 256);
                sheet.SetColumnWidth(1, 20 * 256);
                sheet.SetColumnWidth(2, 20 * 256);
                sheet.SetColumnWidth(3, 20 * 256);
                sheet.SetColumnWidth(4, 20 * 256);
                sheet.SetColumnWidth(5, 20 * 256);
                sheet.SetColumnWidth(6, 20 * 256);
                #region 合并单元格
                CellRangeAddress regionTitle = new CellRangeAddress(0, 0, 0, 6);
                sheet.AddMergedRegion(regionTitle);
                CellRangeAddress regionDate = new CellRangeAddress(1, 1, 0, 6);
                sheet.AddMergedRegion(regionDate);

                CellRangeAddress regionSearch = new CellRangeAddress(2, 2, 0, 6);
                sheet.AddMergedRegion(regionSearch);

                //CellRangeAddress（）该方法的参数次序是：开始行号，结束行号，开始列号，结束列号。

                IRow row0 = sheet.CreateRow(0);
                row0.Height = 20 * 20;
                ICell icell1top0 = row0.CreateCell(0);
                icell1top0.SetCellValue("销售统计报表");
                NOPIHelper.RegionMethod(workbook, sheet, regionTitle, NOPIHelper.Stylexls.标题);
                IRow row1 = sheet.CreateRow(1);
                row1.Height = 20 * 20;
                ICell icell1top1 = row1.CreateCell(0);
                icell1top1.SetCellValue("日期:" + startDate + "至" + endDate + "");
                NOPIHelper.RegionMethod(workbook, sheet, regionDate, NOPIHelper.Stylexls.头);

                IRow row2 = sheet.CreateRow(2);
                row2.Height = 20 * 20;
                ICell icell1top2 = row2.CreateCell(0);

                var cityName = "";
                var countyName = "";
                var agentName = "";
                var siteName = "";
                AgentBLL agentBLL = new AgentBLL(context, loginUser);
                SiteBLL siteBLL = new SiteBLL(context, loginUser);
                AreaBLL areaBLL = new AreaBLL(context, loginUser);
                if (!string.IsNullOrEmpty(agentId))
                {
                    var agent=agentBLL.Get(agentId);
                    if(agent!=null)
                        agentName = agent.agentName;
                }
                if (!string.IsNullOrEmpty(siteId))
                    siteName = siteBLL.Get(siteId).siteName;
                if (!string.IsNullOrEmpty(city))
                    cityName = areaBLL.Get(city).areaName;
                if (!string.IsNullOrEmpty(county))
                    countyName = areaBLL.Get(county).areaName;

                icell1top2.SetCellValue("市:" + cityName + " 区县:" + countyName + " 执法文书类型:" + siteName + " 代理商编号:" + agentName + " 终端号:" + terminalId + "");//搜索条件
                NOPIHelper.RegionMethod(workbook, sheet, regionSearch, NOPIHelper.Stylexls.头);
                #endregion
                #region 设置表头
                int rowsNum = 3;  //行号
                IRow row3 = sheet.CreateRow(rowsNum);
                row3.Height = 20 * 20;

                ICell icell1top = row3.CreateCell(0);
                icell1top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell1top.SetCellValue("时间");

                ICell icell2top = row3.CreateCell(1);
                icell2top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell2top.SetCellValue("预存款金额");

                ICell icell3top = row3.CreateCell(2);
                icell3top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell3top.SetCellValue("销售总额");

                ICell icell4top = row3.CreateCell(3);
                icell4top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell4top.SetCellValue("佣金金额");

                ICell icell5top = row3.CreateCell(4);
                icell5top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell5top.SetCellValue("中奖金额");

                ICell icell6top = row3.CreateCell(5);
                icell6top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell6top.SetCellValue("提现金额");

                ICell icell7top = row3.CreateCell(6);
                icell7top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell7top.SetCellValue("退款金额");

                #endregion

                #region 合计
                 rowsNum = 4;  //行号
                IRow row4 = sheet.CreateRow(rowsNum);
                row4.Height = 20 * 20;
                ICell icell1Total = row4.CreateCell(0);
                icell1Total.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell1Total.SetCellValue("合计");

                ICell icell2Total = row4.CreateCell(1);
                icell2Total.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell2Total.SetCellValue("");

                ICell icell3Total = row4.CreateCell(2);
                icell3Total.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.钱);
                icell3Total.SetCellFormula("SUM(C6:C" + dtRowsCount + ")");

                ICell icell4Total = row4.CreateCell(3);
                icell4Total.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.钱);
                icell4Total.SetCellFormula("SUM(D6:D" + dtRowsCount + ")");

                ICell icell5Total = row4.CreateCell(4);
                icell5Total.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.钱);
                icell5Total.SetCellFormula("SUM(E6:E" + dtRowsCount + ")");

                ICell icell6Total = row4.CreateCell(5);
                icell6Total.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.钱);
                icell6Total.SetCellFormula("SUM(F6:F" + dtRowsCount + ")");

                ICell icell7Total = row4.CreateCell(6);
                icell7Total.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.钱);
                icell7Total.SetCellFormula("SUM(G6:G" + dtRowsCount + ")");
                #endregion

                ICellStyle cellStyleMoney = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.钱);
                ICellStyle cellStyleTime = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.时间);
                ICellStyle cellStyleDefault = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.默认);
                rowsNum = 5;
                foreach (DataRow dr in dt.Rows)
                {
                    /******************写入字段值*********************/
                    row4 = sheet.CreateRow(rowsNum);
                    ICell icel1DateDay = row4.CreateCell(0);
                    icel1DateDay.SetCellValue(dr["dateday"].ToString());
                    icel1DateDay.CellStyle =cellStyleTime;

                    var balanceGroupList = balanceList.Where(c => DateTime.Parse(c.createTime.Substring(0, 10)) <= DateTime.Parse(dr["dateday"].ToString()))
                                       .OrderByDescending(x => x.createTime).GroupBy(x => x.agentId)//必须排序
                                       .Select(g => new { g, count = g.Count() })
                                       .SelectMany(t => t.g.Select(b => b)
                                       .Zip(Enumerable.Range(1, t.count), (j, i) =>
                                           new { j.balance, j.createTime, rn = i }));
                    var advanceBalance = balanceGroupList.Where(c => c.rn == 1).Sum(c => c.balance);

                    ICell icellAdvanceBalance = row4.CreateCell(1);
                    icellAdvanceBalance.SetCellValue(advanceBalance);
                    icellAdvanceBalance.CellStyle = cellStyleMoney;

                    ICell icellSumBetFee = row4.CreateCell(2);
                    icellSumBetFee.SetCellValue(double.Parse(dr["sumBetFee"].ToString()));
                    icellSumBetFee.CellStyle = cellStyleMoney;

                    ICell icel1CommissionFee = row4.CreateCell(3);
                    icel1CommissionFee.SetCellValue(double.Parse(dr["commissionFee"].ToString()));
                    icel1CommissionFee.CellStyle = cellStyleMoney;

                    ICell icel1AwardAmount = row4.CreateCell(4);
                    icel1AwardAmount.SetCellValue(double.Parse(dr["awardAmount"].ToString()));
                    icel1AwardAmount.CellStyle = cellStyleMoney;

                    ICell icel1SumTakeCashFee = row4.CreateCell(5);
                    icel1SumTakeCashFee.SetCellValue(double.Parse(dr["sumTakeCashFee"].ToString()));
                    icel1SumTakeCashFee.CellStyle = cellStyleMoney;

                    ICell icel1RefundAmount = row4.CreateCell(6);
                    icel1RefundAmount.SetCellValue(double.Parse(dr["refundAmount"].ToString()));
                    icel1RefundAmount.CellStyle = cellStyleMoney;

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