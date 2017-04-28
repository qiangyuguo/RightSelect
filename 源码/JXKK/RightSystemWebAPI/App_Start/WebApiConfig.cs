using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Hxxc.Fast3.front.WEBAPI.App_Start;
using System.Web.Routing;
using System.Web.Http.WebHost;
using System.Web.SessionState;
using System.Web;
using System.Reflection;

namespace Hxxc.Fast3.front.WEBAPI
{

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //config.Routes.MapHttpRoute(
            //    name: "DefaultAreaApi",
            //    routeTemplate: "{area}/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //    );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { controller = "UserInfo", action = "GetUserInfo", id = RouteParameter.Optional }
            );
            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            // config.EnableSystemDiagnosticsTracing();

            //RouteTable.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "{controller}/{action}/{id}",
            //    defaults: new { controller = "UserInfo", action = "GetUserInfo", id = RouteParameter.Optional }
            //).RouteHandler = new SessionStateRouteHandler();
        }

    }

    public class SessionableControllerHandler : HttpControllerHandler, IRequiresSessionState
    {
        public SessionableControllerHandler(RouteData routeData)
            : base(routeData)
        { }
    }
    public class SessionStateRouteHandler : IRouteHandler
    {
        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            return new SessionableControllerHandler(requestContext.RouteData);
        }
    }
}
