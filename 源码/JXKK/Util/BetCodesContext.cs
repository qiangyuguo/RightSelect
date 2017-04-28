using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.ZY.JXKK.Util
{
    public class BetCodesContext
    {
        public static string GetBetCodes(string betCodes, bool isChase)
        {
            //分号";"分隔投注 冒号": "分隔投注串:玩法:投注方式:倍数
            //追号订单没有倍数
            //首先split(';')得到投注了多少串
            //逐一对每个串进行解析
            string strBetCodes = "";
            string[] betCodesArry = betCodes.Split(';');
            for (int i = 0; i < betCodesArry.Length; i++)
            {
                string[] arryCode = betCodesArry[i].Split(':');
                if (arryCode.Length < 3)
                {
                    strBetCodes += betCodesArry[i];
                }
                else
                {
                    strBetCodes += "投注串:" + arryCode[0] + "; 玩法:" + GetPM(arryCode[1]) + "; 投注方式:" + GetBM(arryCode[2]) + "";
                    if (isChase == false)
                        strBetCodes += "; 倍数:" + arryCode[3] + "";
                }
                strBetCodes += " \r\n";
            }
            return strBetCodes;
        }
        /// <summary>
        /// 得到玩法
        /// </summary>
        /// <param name="pm"></param>
        /// <returns></returns>
        public static string GetPM(string PM)
        {
            string strPM = "";
            if (PM == "1")
                strPM = "一星";
            if (PM == "2")
                strPM = "两星";
            if (PM == "3")
                strPM = "三星";
            if (PM == "4")
                strPM = "四星";
            if (PM == "5")
                strPM = "五星";
            if (PM == "6")
                strPM = "二星复选";
            if (PM == "7")
                strPM = "三星复选";
            if (PM == "8")
                strPM = "四星复选";
            if (PM == "9")
                strPM = "五星复选";
            if (PM == "10")
                strPM = "二星组选";
            if (PM == "11")
                strPM = "大小单双";
            if (PM == "12")
                strPM = "五星通选";
            if (PM == "13")
                strPM = "任选一";
            if (PM == "14")
                strPM = "任选二";
            if (PM == "15")
                strPM = "三星组选3";
            if (PM == "16")
                strPM = "三星组选6";

            return strPM;
        }
        /// <summary>
        /// 得到投注方式
        /// </summary>
        /// <param name="castType"></param>
        /// <returns></returns>
        public static string GetBM(string castType)
        {
            string strCastType = "";
            if (castType == "1")
                strCastType = "单式";
            if (castType == "2")
                strCastType = "复式";
            if (castType == "3")
                strCastType = "包号";
            if (castType == "4")
                strCastType = "和值";
            if (castType == "5")
                strCastType = "胆拖";
            return strCastType;
        }
    }
}
