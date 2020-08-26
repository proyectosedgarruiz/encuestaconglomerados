using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WSEncuestaConglomerado
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
                      
          
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;

        }

        protected void Application_Error(Object sender, EventArgs ea)
        {
            string uriFormat = "\r\n\r\nURI: {0}\r\n\r\n";
            string exceptionFormat = "{0}: \"{1}\"\r\n{2}\r\n\r\n";
            StringBuilder message = new StringBuilder();
            if (Request != null)
            {
                message.AppendFormat(uriFormat, Request.Path);
            }
            if (Server != null)
            {
                Exception e;
                for (e = Server.GetLastError(); e != null; e = e.InnerException)
                {
                    message.AppendFormat(exceptionFormat, e.GetType().Name, e.Message, e.StackTrace);
                }
            }
            // En este caso, escribimos en nuestro log
            //Log.Error("** API ERROR Sin controlar la excepción **\n" + message.ToString());
            //Server.ClearError(); // descomentar esto para cancelar el error
        }
    }
}
