using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

namespace Com.ZY.JXKK.Util
{
    public class WebJson
    {
        
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="messageType">消息类型</param>
        /// <param name="message">消息内容</param>
        public static void ToJson(HttpContext context,Object obj)
        {
            context.Response.Clear();
            context.Response.ContentType = "text/html";
            context.Response.Cache.SetNoStore();
            string str = JsonConvert.SerializeObject(obj);
            str = str.Replace("need_to_json_", "");
            context.Response.Write(str);
        }

        public static void Write(HttpContext context, string strRes)
        {
            context.Response.Clear();
            context.Response.ContentType = "text/html";
            context.Response.Cache.SetNoStore();
            context.Response.Write(strRes);
        }
    }
}