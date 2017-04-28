using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// 加密 yexh(2016-05-02)
/// </summary>
namespace Com.ZY.JXKK.Util
{
    public class Encrypt
    {
        /// <summary>
        /// 登录密码转换
        /// </summary>
        /// <param name="userId">用户编号(主键)</param>
        /// <param name="password">密码明文</param>
        /// <returns></returns>
        public static string ConvertPwd(string userId, string password)
        {
            return Encrypt.BitConvert(Encrypt.MD5(userId + Encrypt.BitConvert(Encrypt.MD5(password))));
        }

        /// <summary>
        /// MD5加密（不可逆）
        /// </summary>
        /// <param name="decrypt">待加密数据</param>
        /// <returns>加密后数据</returns>
        public static byte[] MD5(string decrypt)
        {
            byte[] buffer = Encoding.GetEncoding("GBK").GetBytes(decrypt);
            return new MD5CryptoServiceProvider().ComputeHash(buffer);
        }

        /// <summary>
        /// 把字节数组转换成字节表示的字符串
        /// </summary>
        /// <param name="src">待转换的字节数组</param>
        /// <returns>转换后的字节表示的字符串</returns>
        public static string BitConvert(byte[] src)
        {
            return BitConverter.ToString(src).Replace("-", "");
        }

    }
}
