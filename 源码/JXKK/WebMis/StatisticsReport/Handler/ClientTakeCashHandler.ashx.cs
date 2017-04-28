using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Com.ZY.JXKK.BLL;
using Com.ZY.JXKK.BLL.Client;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using Com.ZY.BLD.Util;

namespace Com.ZY.JXKK.StatisticsReport.Handler
{
    /// <summary>
    /// 客户提现报表
    /// </summary>
    public class ClientTakeCashHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            LoginUser loginUser = new LoginUser(context, "ClientTakeCashReport");
            ClientTakeCashBLL bll = new ClientTakeCashBLL(context, loginUser);
            //加载DataGrid
            if (context.Request["action"] == "gridLoad")
            {
                int page = int.Parse(context.Request["page"]);
                int rows = int.Parse(context.Request["rows"]);
                string startDate = context.Request["startDate"];
                string endDate = context.Request["endDate"];
                string agentId = context.Request["agentId"];
                string clientId = context.Request["clientId"];
                bll.ClientTakeCashLoadGrid(page, rows, startDate, endDate, agentId,clientId);
            }
            if (context.Request["action"] == "ToExcel")
            {
                string startDate = context.Request["startDate"];
                string endDate = context.Request["endDate"];
                string agentId = context.Request["agentId"];
                string clientId = context.Request["clientId"];

                DataTable dt = bll.ClientTakeCashReport(startDate, endDate, agentId, clientId);
                object sumObject = dt.Compute("sum(fee)", "TRUE"); 
                context.Response.ContentType = "application/x-excel";
                string fileName = HttpUtility.UrlEncode(startDate + "至" + endDate + "客户提现报表.xls");
                context.Response.AddHeader("Content-Disposition", "attachment; fileName=" + fileName);
                IWorkbook workbook = new HSSFWorkbook();
                //创建表  
                ISheet sheet = workbook.CreateSheet("客户提现报表");
                //设置单元的宽度  
                sheet.SetColumnWidth(0, 15 * 256);
                sheet.SetColumnWidth(1, 20 * 256);
                sheet.SetColumnWidth(2, 15 * 256);
                sheet.SetColumnWidth(3, 20 * 256);
                sheet.SetColumnWidth(4, 15 * 256);
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
                icell1top0.SetCellValue("客户提现报表");
                NOPIHelper.RegionMethod(workbook, sheet, regionTitle, NOPIHelper.Stylexls.标题);
                IRow row1 = sheet.CreateRow(1);
                row1.Height = 20 * 20;
                ICell icell1top1 = row1.CreateCell(0);
                icell1top1.SetCellValue("日期:" + startDate + "至" + endDate + " 代理商编号:" + agentId + " 客户编号:" + clientId + " 提现总额:" + double.Parse(sumObject == DBNull.Value ? "0" : sumObject.ToString()).ToString("￥#,##0.00") + "");
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
                icell2top.SetCellValue("提现金额");

                ICell icell3top = row2.CreateCell(2);
                icell3top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell3top.SetCellValue("提现方式");

                ICell icell4top = row2.CreateCell(3);
                icell4top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell4top.SetCellValue("提现时间");

                ICell icell5top = row2.CreateCell(4);
                icell5top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell5top.SetCellValue("提现单号");

                ICell icell6top = row2.CreateCell(5);
                icell6top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell6top.SetCellValue("代理商");

                ICell icell7top = row2.CreateCell(6);
                icell7top.CellStyle = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.头);
                icell7top.SetCellValue("操作员");
                #endregion

                rowsNum = 3;  //行号
                ICellStyle cellStyleMoney = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.钱);
                ICellStyle cellStyleTime = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.时间);
                ICellStyle cellStyleDefault = NOPIHelper.Getcellstyle(workbook, NOPIHelper.Stylexls.默认);

                foreach (DataRow dr in dt.Rows)
                {
                    /******************写入字段值*********************/
                    row2 = sheet.CreateRow(rowsNum);
                    ICell icel1ClientId = row2.CreateCell(0);
                    icel1ClientId.SetCellValue(dr["ClientId"].ToString());
                    icel1ClientId.CellStyle = cellStyleDefault;

                    ICell icellFee = row2.CreateCell(1);
                    icellFee.SetCellValue(double.Parse(dr["Fee"].ToString()));
                    icellFee.CellStyle = cellStyleMoney;

                    ICell icellHandleMode = row2.CreateCell(2);
                    icellHandleMode.SetCellValue(dr["HandleMode"].ToString());
                    icellHandleMode.CellStyle = cellStyleDefault;

                    ICell icel1CreateTime = row2.CreateCell(3);
                    icel1CreateTime.SetCellValue(dr["CreateTime"].ToString());
                    icel1CreateTime.CellStyle =cellStyleTime;

                    ICell icel1FlowId = row2.CreateCell(4);
                    icel1FlowId.SetCellValue(dr["FlowId"].ToString());
                    icel1FlowId.CellStyle = cellStyleDefault;

                    ICell icel1AgentName = row2.CreateCell(5);
                    icel1AgentName.SetCellValue(dr["AgentId"].ToString());
                    icel1AgentName.CellStyle = cellStyleDefault;

                    ICell icel1OperatorName = row2.CreateCell(6);
                    icel1OperatorName.SetCellValue(dr["operatorname"].ToString());
                    icel1OperatorName.CellStyle = cellStyleDefault;

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