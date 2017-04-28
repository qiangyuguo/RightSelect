using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
namespace Com.ZY.JXKK.Util
{
    public class Message
    {
        public int total = 0;//总记录数
        public List<string> rows = new List<string>();//记录信息
        public int messageType = 0;// 消息类型【0:成功消息或无消息,1:错误消息,2:权限异常】
        public string message = "";// 消息内容

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="messageType">消息类型</param>
        /// <param name="message">消息内容</param>
        private static void send(HttpContext context, int messageType, string message)
        {
            Message msg = new Message();
            msg.messageType = messageType;
            msg.message = message;
            WebJson.ToJson(context,msg);
        }

        /// <summary>
        /// 提示成功消息
        /// </summary>
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="msg">消息内容</param>
        public static void success(HttpContext context, string msg)
        {
            send(context, 0, msg);
        }


        /// <summary>
        /// 提示异常消息
        /// </summary>
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="msg">消息内容</param>
        public static void error(HttpContext context, string msg)
        {
            send(context, 1, msg);
        }

        /// <summary>
        /// 提示权限异常消息
        /// </summary>
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="msg">消息内容</param>
        public static void right(HttpContext context, string msg)
        {
            //System.Threading.Thread.Sleep(60);
            send(context, 2, msg);
        }
    }
}