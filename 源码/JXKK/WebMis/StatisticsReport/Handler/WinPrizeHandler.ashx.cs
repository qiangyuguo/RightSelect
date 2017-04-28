using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Lottery;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using Com.ZY.BLD.Util;
using Com.ZY.JXKK.BLL.Agent;
using Com.ZY.JXKK.BLL.Set;

namespace Com.ZY.JXKK.StatisticsReport.Handler
{
    /// <summary>
    /// 中奖数据报表
    /// </summary>
    public class WinPrizeHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            LoginUser loginUser = new LoginUser(context, "WinPrizeReport");
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
                string terminalId = context.Request["terminalId"];
                string lotteryType = context.Request["lotteryType"];
                string gameId = context.Request["gameId"];
                bll.WinPrizeDataLoadGrid(page, rows, startDate, endDate, city, county, siteId, terminalId, lotteryType, gameId);
            }
            if (context.Request["action"] == "totalFee")
            {
                string startDate = context.Request["startDate"];
                string endDate = context.Request["endDate"];
                string city = context.Request["cityId"];
                string county = context.Request["countyId"];
                string siteId = context.Request["siteId"];
                string terminalId = context.Request["terminalId"];
                string lotteryType = context.Request["lotteryType"];
                string gameId = context.Request["gameId"];
                context.Response.Write(bll.GetTotalWinPrize(startDate, endDate, city, county, siteId, terminalId, lotteryType, gameId));
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
            //加载彩种
            if (context.Request["action"] == "lotteryTypeListLoad")
            {
                Combobox com = new Combobox(context, loginUser);
                com.LotteryTypeCombobox();
            }
            //加载游戏
            if (context.Request["action"] == "gameListLoad")
            {
                Combobox com = new Combobox(context, loginUser);
                com.GameCombobox();
            }
            if (context.Request["action"] == "ToExcel")
            {
                string startDate = context.Request["startDate"];
                string endDate = context.Request["endDate"];
                string city = context.Request["cityId"];
                string county = context.Request["countyId"];
                string siteId = context.Request["siteId"];
                string terminalId = context.Request["terminalId"];
                string lotteryType = context.Request["lotteryType"];
                string gameId = context.Request["gameId"];

                DataTable dt = bll.WinPrizeDataReport (startDate, endDate, city, county, siteId, terminalId, lotteryType, gameId);
                object sumObject = dt.Compute("sum(awardmoney)", "TRUE");
                context.Response.ContentType = "application/x-excel";
                string fileName = HttpUtility.UrlEncode(startDate + "至" + endDate + "中奖数据报表.xls");
                context.Response.AddHeader("Content-Disposition", "attachment; fileName=" + fileName);
                IWorkbook workbook = new HSSFWorkbook();
                //创建表  
                ISheet sheet = workbook.CreateSheet("中奖数据报表");
                //设置单元的宽度  
                sheet.SetColumnWidth(0, 10 * 256);
                sheet.SetColumnWidth(1, 10 * 256);
                sheet.SetColumnWidth(2, 15 * 256);
                sheet.SetColumnWidth(3, 10 * 256);
                sheet.SetColumnWidth(4, 13 * 256);
                sheet.SetColumnWidth(5, 10 * 256);
                sheet.SetColumnWidth(6, 10 * 256);
                sheet.SetColumnWidth(7, 13 * 256);
                sheet.SetColumnWidth(8, 20 * 256);
                sheet.SetColumnWidth(9, 30 * 256);
                sheet.SetColumnWidth(10, 15 * 256);
                #region 合并单元格
                CellRangeAddress regionTitle = new CellRangeAddress(0, 0, 0, 10);
                sheet.AddMergedRegion(regionTitle);
                CellRangeAddress regionDate = new CellRangeAddress(1, 1, 0, 10);
                sheet.AddMergedRegion(regionDate);

                CellRangeAddress regionSearch = new CellRangeAddress(2, 2, 0, 10);
                sheet.AddMergedRegion(regionSearch);

                //CellRangeAddress（）该方法的参数次序是：开始行号，结束行号，开始列号，结束列号。

                IRow row0 = sheet.CreateRow(0);
                row0.Height = 20 * 20;
                ICell icell1top0 = row0.CreateCell(0);
                icell1top0.SetCellValue("中奖数据报表");
                NOPIHelper.RegionMethod(workbook, sheet, regionTitle, NOPIHelper.Stylexls.标题);
                IRow row1 = sheet.CreateRow(1);
                row1.Height = 20 * 20;
                ICell icell1top1 = row1.CreateCell(0);
                icell1top1.SetCellValue("日期:" + startDate + "至" + endDate + " 中奖总额:" + double.Parse(sumObject == DBNull.Value ? "0" : sumObject.ToString()).ToString("￥#,##0.00") + "");
                NOPIHelper.RegionMethod(workbook, sheet, regionDate, NOPIHelper.Stylexls.头);

                IRow row2 = sheet.CreateRow(2);
                row2.Height = 20 * 20;
                ICell icell1top2 = row2.CreateCell(0);

                var cityName = "";
                var countyName = "";
                var siteName = "";
                var lotteryName = "";
                var gameName = "";
                SiteBLL siteBLL = new SiteBLL(context, loginUser);
                AreaBLL areaBLL = new AreaBLL(context, loginUser);
                LotteryBLL lotteryBLL = new LotteryBLL(context, loginUser);
                GameBLL gameBLL = new GameBLL(context, loginUser);
                if (!string.IsNullOrEmpty(siteId))
                    siteName = siteBLL.Get(siteId).siteName;
                if (!string.IsNullOrEmpty(city))
                    cityName = areaBLL.Get(city).areaName;
                if (!string.IsNullOrEmpty(county))
                    countyName = areaBLL.Get(county).areaName;
                if (!string.IsNullOrEmpty(lotteryType))
                    lotteryName = lotteryBLL.Get(lotteryType).LotteryTypeName;
                if (!string.IsNullOrEmpty(gameId))
                    gameName = gameBLL.Get(gameId).gameName;

                icell1top2.SetCellValue("市:" + cityName + " 区县:" + countyName + " 执法文书类型:" + siteName + " 终端号:" + terminalId + " 彩种:" + lotteryName + " 游戏:" + gameName + "");//搜索条件
                NOPIHelper.RegionMethod(workbook, sheet, regionSearch, NOPIHelper.Stylexls.头);
                #endregion
                #region 设置表头
                int rowsNum = 3;  //行号
                IRow row3 = sheet.CreateRow(rowsNum);
                row3.Height = 20 * 20;

                ICell icell1top = row3.CreateCell(0);
                icell1top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell1top.SetCellValue("市");

                ICell icell2top = row3.CreateCell(1);
                icell2top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell2top.SetCellValue("区(县)");

                ICell icell3top = row3.CreateCell(2);
                icell3top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell3top.SetCellValue("执法文书类型名称");

                ICell icell4top = row3.CreateCell(3);
                icell4top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell4top.SetCellValue("终端号");

                ICell icell5top = row3.CreateCell(4);
                icell5top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell5top.SetCellValue("客户编号");

                ICell icell6top = row3.CreateCell(5);
                icell6top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell6top.SetCellValue("彩种");

                ICell icell7top = row3.CreateCell(6);
                icell7top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell7top.SetCellValue("游戏");

                ICell icell8top = row3.CreateCell(7);
                icell8top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell8top.SetCellValue("期次");

                ICell icell9top = row3.CreateCell(8);
                icell9top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell9top.SetCellValue("交易时间");

                ICell icell10top = row3.CreateCell(9);
                icell10top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell10top.SetCellValue("订单号");

                ICell icell11top = row3.CreateCell(10);
                icell11top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell11top.SetCellValue("中奖金额");

                #endregion

                rowsNum = 4;  //行号
                ICellStyle cellStyleMoney = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.钱);
                ICellStyle cellStyleTime = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.时间);
                ICellStyle cellStyleDefault = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.默认);

                foreach (DataRow dr in dt.Rows)
                {
                    /******************写入字段值*********************/
                    row3 = sheet.CreateRow(rowsNum);
                    ICell icel1City = row3.CreateCell(0);
                    icel1City.SetCellValue(dr["city"].ToString());
                    icel1City.CellStyle = cellStyleDefault;

                    ICell icellCounty = row3.CreateCell(1);
                    icellCounty.SetCellValue(dr["county"].ToString());
                    icellCounty.CellStyle = cellStyleDefault;

                    ICell icellSiteName = row3.CreateCell(2);
                    icellSiteName.SetCellValue(dr["siteName"].ToString());
                    icellSiteName.CellStyle = cellStyleDefault;

                    ICell icel1TerminalId = row3.CreateCell(3);
                    icel1TerminalId.SetCellValue(dr["terminalId"].ToString());
                    icel1TerminalId.CellStyle = cellStyleDefault;

                    ICell icel1ClientId = row3.CreateCell(4);
                    icel1ClientId.SetCellValue(dr["clientId"].ToString());
                    icel1ClientId.CellStyle = cellStyleDefault;

                    ICell icel1LotteryType = row3.CreateCell(5);
                    icel1LotteryType.SetCellValue(dr["lotteryType"].ToString());
                    icel1LotteryType.CellStyle = cellStyleDefault;

                    ICell icel1GameId = row3.CreateCell(6);
                    icel1GameId.SetCellValue(dr["gameId"].ToString());
                    icel1GameId.CellStyle = cellStyleDefault;

                    ICell icel1Period = row3.CreateCell(7);
                    icel1Period.SetCellValue(dr["period"].ToString());
                    icel1Period.CellStyle = cellStyleDefault;

                    ICell icel1AwardTime = row3.CreateCell(8);
                    icel1AwardTime.SetCellValue(dr["awardtime"].ToString());
                    icel1AwardTime.CellStyle = cellStyleTime;

                    ICell icel1OrderId = row3.CreateCell(9);
                    icel1OrderId.SetCellValue(dr["orderid"].ToString());
                    icel1OrderId.CellStyle = cellStyleDefault;

                    ICell icel1AwardMoney = row3.CreateCell(10);
                    icel1AwardMoney.SetCellValue(double.Parse(dr["awardmoney"].ToString()));
                    icel1AwardMoney.CellStyle = cellStyleMoney;

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