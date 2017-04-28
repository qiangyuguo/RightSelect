using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.ZY.BLD.Util
{
    public class NOPIHelper
    {
        #region 定义单元格常用到样式的枚举
        public enum Stylexls
        {
            标题,
            头,
            时间,
            数字,
            钱,
            百分比,
            中文大写,
            科学计数法,
            默认
        }
        #endregion

        #region 定义单元格常用到样式
        public static ICellStyle Getcellstyle(IWorkbook wb, Stylexls str)
        {
            ICellStyle cellStyle = wb.CreateCellStyle();
            //定义几种字体  
            //也可以一种字体，写一些公共属性，然后在下面需要时加特殊的  

            //标题
            IFont fontTitle = wb.CreateFont();
            fontTitle.FontHeightInPoints = 16;
            fontTitle.FontName = "宋体";
            fontTitle.IsBold = true;

            //列头
            IFont fontColumnHeader = wb.CreateFont();
            fontColumnHeader.FontHeightInPoints = 12;
            fontColumnHeader.FontName = "宋体";
            fontColumnHeader.IsBold =true;

            //内容
            IFont fontContent = wb.CreateFont();
            fontContent.FontHeightInPoints = 9;
            fontContent.FontName = "宋体";
            //font.Underline = 1;下划线  


            IFont fontcolorblue = wb.CreateFont();
            fontcolorblue.Color = HSSFColor.OliveGreen.Blue.Index;
            fontcolorblue.IsItalic = true;//下划线  
            fontcolorblue.FontName = "宋体";


            ////边框  
            cellStyle.BorderBottom = BorderStyle.Thin;
            cellStyle.BorderLeft = BorderStyle.Thin;
            cellStyle.BorderRight = BorderStyle.Thin;
            cellStyle.BorderTop = BorderStyle.Thin;
            //边框颜色  
            cellStyle.BottomBorderColor = HSSFColor.OliveGreen.Black.Index;
            cellStyle.TopBorderColor = HSSFColor.OliveGreen.Black.Index;
            cellStyle.LeftBorderColor = HSSFColor.OliveGreen.Black.Index;
            cellStyle.RightBorderColor = HSSFColor.OliveGreen.Black.Index;

            //水平对齐  
            cellStyle.Alignment =HorizontalAlignment.Left;

            //垂直对齐  
            cellStyle.VerticalAlignment = VerticalAlignment.Center;

            //自动换行  
            cellStyle.WrapText = true;

            //缩进;当设置为1时，前面留的空白太大了。希旺官网改进。或者是我设置的不对  
            cellStyle.Indention = 0;

            //上面基本都是设共公的设置  
            //下面列出了常用的字段类型  
            switch (str)
            {
                case Stylexls.标题:
                    cellStyle.Alignment = HorizontalAlignment.Center;
                    cellStyle.VerticalAlignment = VerticalAlignment.Center;
                    cellStyle.SetFont(fontTitle);
                    break;
                case Stylexls.头:
                    cellStyle.SetFont(fontColumnHeader);
                    break;
                case Stylexls.时间:
                    IDataFormat datastyle = wb.CreateDataFormat();
                    cellStyle.DataFormat = datastyle.GetFormat("yyyy-MM-dd");
                    cellStyle.SetFont(fontContent);
                    break;
                case Stylexls.数字:
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                    cellStyle.Alignment = HorizontalAlignment.Right;
                    cellStyle.SetFont(fontContent);
                    break;
                case Stylexls.钱:
                    IDataFormat format = wb.CreateDataFormat();
                    cellStyle.DataFormat = format.GetFormat("￥#,##0.00");
                    cellStyle.SetFont(fontContent);
                    break;
                case Stylexls.百分比:
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00%");
                    cellStyle.SetFont(fontContent);
                    break;
                case Stylexls.中文大写:
                    IDataFormat format1 = wb.CreateDataFormat();
                    cellStyle.DataFormat = format1.GetFormat("[DbNum2][$-804]0");
                    cellStyle.SetFont(fontContent);
                    break;
                case Stylexls.科学计数法:
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00E+00");
                    cellStyle.SetFont(fontContent);
                    break;
                case Stylexls.默认:
                    cellStyle.SetFont(fontContent);
                    break;
            }
            return cellStyle;


        }
        #endregion
        /// <summary>
        /// 设置合并单元格的边框
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="sheet"></param>
        /// <param name="region"></param>
        /// <param name="stylexls"></param>
        public static void RegionMethod(IWorkbook workbook, ISheet sheet, CellRangeAddress region, NOPIHelper.Stylexls stylexls)
        {
            for (int k = region.FirstRow; k <= region.LastRow; k++)
            {
                IRow row = sheet.GetRow(k);
                for (int j = region.FirstColumn; j <= region.LastColumn; j++)
                {
                    ICell singleCell = HSSFCellUtil.GetCell(row, (short)j);
                    singleCell.CellStyle = NOPIHelper.Getcellstyle(workbook, stylexls);
                }
            }
        }
    }
}
