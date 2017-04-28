using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Com.Data
{
    /// <summary>
    /// 数据加解密 20160514
    /// </summary>
    public class DataSecurity
    {
        /// <summary>
        /// 3DES加密
        /// </summary>
        /// <param name="encryptString">明文</param>
        /// <returns>密文</returns>
        public static string DES3Encrypt(string encryptString)
        {
            string[] strKeys = { "56028641", "87993761", "qwertyui" };
            for (int i = 0; i < 3; i++)
            {
                encryptString = DesEncrypt(encryptString, strKeys[i]);
            }
            return encryptString;
        }

        /// <summary>
        /// 3DES解密
        /// </summary>
        /// <param name="decryptString">密文</param>
        /// <returns>明文</returns>
        public static string DES3Decrypt(string decryptString)
        {
            string[] strKeys = { "56028641", "87993761", "qwertyui" };
            for (int i = 2; i >= 0; i--)
            {
                decryptString = DesDecrypt(decryptString, strKeys[i]);
            }
            return decryptString;
        }

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="pToEncrypt">明文</param>
        /// <param name="sKey">密匙</param>
        /// <returns>密文</returns>
        public static string DesEncrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="pToDecrypt">密文</param>
        /// <param name="sKey">密匙</param>
        /// <returns>明文</returns>
        public static string DesDecrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }

        /// <summary>
        /// MD5_16加密
        /// </summary>
        /// <param name="decryptString">明文</param>
        /// <returns>16字节的密文</returns>
        public static string MD5_16(string decryptString) //加密，不可逆
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string str = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(decryptString)), 4, 8);
            //BitConverter.ToString()得到的字符串形式为2个一对，对与对之间加个“-”符号，如，“7F-2C-4A”。 
            //md5.ComputeHash(UTF8Encoding.Default.GetBytes(t16.Text.Trim()))，计算哈希值。 
            //4表示初始位置，8表示有8个对，每个对都是2位，故有16位（32位为16对），即就是从第4对开始连续取8对。 
            str = str.Replace("-", "");
            return str;
        }

        /// <summary>
        /// MD5_32加密
        /// </summary>
        /// <param name="decryptString">明文</param>
        /// <returns>32字节的密文</returns>
        public static string MD5_32(string decryptString) //加密，不可逆
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string str = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(decryptString)));
            //BitConverter.ToString()得到的字符串形式为2个一对，对与对之间加个“-”符号，如，“7F-2C-4A”。 
            //md5.ComputeHash(UTF8Encoding.Default.GetBytes(t16.Text.Trim()))，计算哈希值。 
            //4表示初始位置，8表示有8个对，每个对都是2位，故有16位（32位为16对），即就是从第4对开始连续取8对。 
            str = str.Replace("-", "");
            return str;
        }


        private static byte[] HCDES(byte[] Key, byte[] Data)
        {

            //创建一个DES算法的加密类
            DESCryptoServiceProvider MyServiceProvider = new DESCryptoServiceProvider();
            MyServiceProvider.Mode = CipherMode.CBC;
            MyServiceProvider.Padding = PaddingMode.None;
            //从DES算法的加密类对象的CreateEncryptor方法,创建一个加密转换接口对象
            //第一个参数的含义是：对称算法的机密密钥(长度为64位,也就是8个字节)
            // 可以人工输入,也可以随机生成方法是：MyServiceProvider.GenerateKey();
            //第二个参数的含义是：对称算法的初始化向量(长度为64位,也就是8个字节)
            // 可以人工输入,也可以随机生成方法是：MyServiceProvider.GenerateIV()

            //
            ICryptoTransform MyTransform = MyServiceProvider.CreateEncryptor(Key, new byte[8]);

            //CryptoStream对象的作用是将数据流连接到加密转换的流
            MemoryStream ms = new MemoryStream();
            CryptoStream MyCryptoStream = new CryptoStream(ms, MyTransform, CryptoStreamMode.Write);
            //将字节数组中的数据写入到加密流中


            MyCryptoStream.Write(Data, 0, Data.Length);
            //关闭加密流对象
            byte[] bEncRet = new byte[8];
            // Array.Copy(ms.GetBuffer(), bEncRet, ms.Length);
            bEncRet = ms.ToArray(); // MyCryptoStream关闭之前ms.Length 为8， 关闭之后为16

            MyCryptoStream.FlushFinalBlock();
            MyCryptoStream.Close();
            byte[] bTmp = ms.ToArray();
            ms.Close();


            // return bEncRet;
            return bTmp;// 
        }


        /// <summary>
        /// MAC认证
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MAC_CBC(string str)
        {
            int iGroup = 0;
            byte[] bKey = { 0x34, 0x04, 0x05, 0x19, 0x81, 0x11, 0x03, 0xEF };

            byte[] bIV = { 0x13, 0x95, 0x60, 0x28, 0x64, 0x1B, 0xCD, 0xEF };

            byte[] bTmpBuf1 = new byte[8];
            byte[] bTmpBuf2 = new byte[8];
            byte[] MacData = Encoding.Default.GetBytes(str);

            Array.Copy(bIV, bTmpBuf1, 8);

            if ((MacData.Length % 8 == 0))
                iGroup = MacData.Length / 8;
            else
                iGroup = MacData.Length / 8 + 1;

            int i = 0;
            int j = 0;

            for (i = 0; i < iGroup; i++)
            {
                Array.Copy(MacData, 8 * i, bTmpBuf2, 0, 8);
                for (j = 0; j < 8; j++)
                    bTmpBuf1[j] = (byte)(bTmpBuf1[j] ^ bTmpBuf2[j]);
                bTmpBuf2 = HCDES(bKey, bTmpBuf1);
                Array.Copy(bTmpBuf2, bTmpBuf1, 8);
            }

            string strOut = "";
            for (int index = 0; index < bTmpBuf2.Length; index++)
            {
                strOut += string.Format("{0:X2}", bTmpBuf2[index]);
                if (index == 1 || index == 3 || index == 5)
                    strOut += "-";
            }
            return strOut;
        }
    }
}
