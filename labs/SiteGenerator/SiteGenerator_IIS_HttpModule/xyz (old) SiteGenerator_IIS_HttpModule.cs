using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Owasp.SiteGenerator;
using System.Runtime.InteropServices;

namespace Owasp.SiteGenerator
{
    public class IIS_HttpModule : IHttpModule
    {
        private static string strDefaultSharedMemoryName = "SM_Client";
        private static IntPtr smdtToUse;
        public IIS_HttpModule()
        {
            //
            // TODO: Add constructor logic here
            // 
        }

        public void Init(HttpApplication application)
        {
            application.BeginRequest += (new EventHandler(HttpModule_BeginRequest_Handler));
            application.PostAcquireRequestState += new EventHandler(HttpModule_PostAcquireRequestState_Handler);            
        }        

        public void Dispose()
        {
        }
        
        static public void HttpModule_BeginRequest_Handler(object sender, EventArgs e)
        {            
            SharedMemoryForDotNet.smdt_test();
            smdtToUse = SharedMemoryForDotNet.smdt_Create(strDefaultSharedMemoryName);
            SharedMemoryForDotNet.smdt_send(smdtToUse, "This is a message from Asp.Net II");
            StringBuilder sbQuestion = new StringBuilder("/Main.aspx");
            //StringBuilder sbAnswer = new StringBuilder();
            StringBuilder sbAnswer = SharedMemoryForDotNet.smdt_sendAsQuestion(smdtToUse, sbQuestion);
            
            HttpContext.Current.Server.Transfer(sbAnswer.ToString(),true);
            //smdtToUse = SharedMemoryForDotNet.smdt_Create(strDefaultSharedMemoryName);
            HttpContext.Current.Response.Write("<hr> Answer = " +sbAnswer.ToString());            
            HttpContext.Current.Response.Write("<hr> From Http Module.. <hr> Not ending");            

//            SharedMemoryForDotNet.smdt_send(smdtToUse, "This is a test from HttpModule");
        }

        static public void HttpModule_PostAcquireRequestState_Handler(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Write("<hr> in HttpModule_PostAcquireRequestState_Handler<hr>");
            HttpContext.Current.Session.Add("test", "Test Value");
            HttpContext.Current.Response.Write(HttpContext.Current.Session["test"].ToString());            
        }
        
    }
}
