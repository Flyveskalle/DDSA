using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DDSA.Backend.Business;


namespace DDSA.Web.Webservices.Dashboard
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    
    
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            string result = context.Request.QueryString["result"];

            int stop = 1;
            if(!string.IsNullOrEmpty(result))
            {
                new NewsletterManager().SaveNewsletter(result, DateTime.Now);
            }
            

            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}