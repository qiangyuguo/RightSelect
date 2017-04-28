using Hxxc.Fast3.front.Common;
using Hxxc.Fast3.front.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Hxxc.Fast3.front.WEBAPI.App_Start
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]

    public class WebFilterAttribute:System.Web.Http.Filters.ActionFilterAttribute
    {
        public static LogInfo log;

        private const string CallbackQueryParameter = "callback";
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                base.OnActionExecuting(actionContext);
                log = new LogInfo();

                WebApiMonitor MonLog = new WebApiMonitor();
                MonLog.HttpMethod = actionContext.Request.Method.Method;
                MonLog.ControllerName = actionContext.ControllerContext.RouteData.Values["controller"].ToString() + "/" + actionContext.ControllerContext.RouteData.Values["Action"].ToString();
                MonLog.ActionParams = actionContext.ActionArguments;
                #region 获取ip
                string ip = string.Empty;
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"]))
                    ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
                if (string.IsNullOrEmpty(ip))
                    ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
                MonLog.IP = ip;
                #endregion
                #region 如果参数是实体对象，获取序列化后的数据
                Stream stream = actionContext.Request.Content.ReadAsStreamAsync().Result;
                Encoding encoding = Encoding.UTF8;
                stream.Position = 0;
                string responseData = "";
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    responseData = reader.ReadToEnd().ToString();
                }
                if (!string.IsNullOrWhiteSpace(responseData))
                {
                    MonLog.ActionParams.Add("POSTPARAMS", responseData);
                }
                #endregion
                //log.LogList.Add("Controller:[" + MonLog.ControllerName + "] 请求方式：" + MonLog.HttpMethod + "  IP:" + MonLog.IP + "  入参：" + MonLog.GetCollections(MonLog.ActionParams));
                LogHelp.Monitor.Info("Controller:[" + MonLog.ControllerName + "] 请求方式：" + MonLog.HttpMethod + "  IP:" + MonLog.IP + "  入参：" + MonLog.GetCollections(MonLog.ActionParams));
            }catch(Exception ex)
            {
                LogHelp.Monitor.Info("初始化程序OnActionExecuting异常：" + ex);
            }
            }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            try{
            var callback = string.Empty;

            if (IsJsonp(out callback))
            {
                var jsonBuilder = new StringBuilder(callback);

                jsonBuilder.AppendFormat("({0})", actionExecutedContext.Response.Content.ReadAsStringAsync().Result);

                actionExecutedContext.Response.Content = new StringContent(jsonBuilder.ToString());
                callback = jsonBuilder.ToString();
            }
            else
            {
                var jsonBuilder = new StringBuilder(callback);
                jsonBuilder.AppendFormat("{0}", actionExecutedContext.Response.Content.ReadAsStringAsync().Result);
                actionExecutedContext.Response.Content = new StringContent(jsonBuilder.ToString());
                callback = jsonBuilder.ToString();
            }
            string content = System.Web.HttpContext.Current.Request.QueryString[CallbackQueryParameter];
            //log.LogList.Add("返回记录:" + callback);
            LogHelp.baselog.Info("返回记录:" + callback);
            base.OnActionExecuted(actionExecutedContext);
            }catch(Exception ex)
            {
                LogHelp.Monitor.Info("初始化程序OnActionExecuted异常：" + ex);
            }
        }
        private bool IsJsonp(out string callback)
        {
            callback = System.Web.HttpContext.Current.Request.QueryString[CallbackQueryParameter];

            return !string.IsNullOrEmpty(callback);
        }
    }
}