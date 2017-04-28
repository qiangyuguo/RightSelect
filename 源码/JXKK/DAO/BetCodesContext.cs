using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.ZY.JXKK.DAO.Set;

namespace Com.ZY.JXKK.DAO
{
    public class BetCodesContext
    {
        public static string GetBetCodes(string gameId, string betCodes, bool isChase)
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

                if (arryCode.Length < 3) //投注内容长度小于3直接显示
                {
                    if (gameId == "7")//疯狂足球积分投注
                        strBetCodes += GetFootball(betCodesArry[i]);
                    else
                        strBetCodes += betCodesArry[i];
                }
                else
                {
                    if (gameId == "4") //疯狂扑克
                    {
                        strBetCodes += GetPoker(arryCode[0]) + "; 玩法:" + GetPM(arryCode[1]) + "; 投注方式:" + GetBM(arryCode[2]) + "";
                    }
                    else//非疯狂扑克
                    {
                        if (gameId == "5" || gameId == "6" || gameId == "8" || gameId == "9")//疯狂骰盅彩票、积分;疯狂足球彩票
                            strBetCodes += "投注串:" + arryCode[0] + "; 玩法:" + GetPM(("2-" + arryCode[2]).Trim()) + "; 投注方式:" + GetBM(("2-" + arryCode[1]).Trim()) + "";
                        else //其他游戏主要针对时时彩游戏
                            strBetCodes += "投注串:" + arryCode[0] + "; 玩法:" + GetPM(arryCode[1]) + "; 投注方式:" + GetBM(arryCode[2]) + "";
                    }
                    if (isChase == false) //是否追号
                        strBetCodes += "; 倍数:" + arryCode[3] + "";

                }
                strBetCodes += " \r\n";
            }
            return strBetCodes;
        }
        /// <summary>
        /// 得到疯狂扑克的投注串对应的花色
        /// </summary>
        /// <param name="poker"></param>
        /// <returns></returns>
        public static string GetPoker(string poker)
        {
            string strPoker = "";
            if (poker == "1")
                strPoker = "红桃";
            else if (poker == "2")
                strPoker = "黑桃";
            else if (poker == "3")
                strPoker = "梅花";
            else if (poker == "4")
                strPoker = "方块";
            else if (poker == "5")
                strPoker = "皇冠";
            return strPoker;
        }
        /// <summary>
        /// 得到足球对应的值
        /// </summary>
        /// <param name="football"></param>
        /// <returns></returns>
        public static string GetFootball(string football)
        {
            string strFootball = "";
            if (football == "1")
                strFootball = "胜";
            else if (football == "2")
                strFootball = "平";
            else if (football == "3")
                strFootball = "负";
            return strFootball;
        }
        
        /// <summary>
        /// 得到玩法
        /// </summary>
        /// <param name="pm"></param>
        /// <returns></returns>
        public static string GetPM(string PM)
        {
             return new TBPlayModeDAO().Get(PM).name;
        }
        /// <summary>
        /// 得到投注方式
        /// </summary>
        /// <param name="castType"></param>
        /// <returns></returns>
        public static string GetBM(string BM)
        {
            return new TBBetModeDAO().Get(BM).name;
        }
    }
}
