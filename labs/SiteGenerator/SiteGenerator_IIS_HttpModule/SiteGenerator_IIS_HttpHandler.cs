using System;
using System.Web;
using System.Web.UI;
using System.Text;
using System.IO;
using System.Web.Services.Protocols;
using WSConfig = System.Web.Services.Configuration.WebServicesSection;
using WSProtocol = System.Web.Services.Configuration.WebServiceProtocols;

namespace Owasp.SiteGenerator
{
    public class RemapHandler : IHttpHandlerFactory
    {
        private static string strDefaultSGHttpHandlerPrefix = "[SG_HttpHandler],-,";

        protected RemapHandler()
            : base()
        {    }
        IHttpHandler IHttpHandlerFactory.GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            IHttpHandler handler = null;

            if (context.Request.QueryString != null)
                pathTranslated = getPathTranslatedFromSiteGeneratorGUI(url, pathTranslated);
            // check if it is an .aspx page
            if (".aspx" == Path.GetExtension(pathTranslated))
            {
                context.RewritePath(url, url, context.Request.QueryString.ToString());
                handler = PageParser.GetCompiledPageInstance(url, pathTranslated, context);
            }
            else if (".asmx" == Path.GetExtension(pathTranslated).ToLower())
            {
                WebServiceHandlerFactory wshf = new WebServiceHandlerFactory();
                handler = wshf.GetHandler(context, requestType, url, pathTranslated);                
            }
            else
            {
                ProcessStaticContent(pathTranslated);      // Process page and 
                HttpContext.Current.Response.End();     //  end here
            }

            return handler;
        }

        void IHttpHandlerFactory.ReleaseHandler(IHttpHandler handler)
        {
        }

        string getPathTranslatedFromSiteGeneratorGUI(string requestUrl, string originalPathTranslated)
        {
            utils.Communicator commTalkToFatClient = new utils.Communicator();
            StringBuilder sbQuestion = new StringBuilder(strDefaultSGHttpHandlerPrefix + requestUrl);
            StringBuilder sbAnswer = new StringBuilder();
            sbAnswer.Append(commTalkToFatClient.SendMessage(sbQuestion.ToString()));
            if (sbAnswer.ToString() == sbQuestion.ToString())
            {
                HttpContext.Current.Response.Write("<hr>sbAnswer == sbQuestion<hr>");
                return originalPathTranslated;
            }
            else
            {
                return sbAnswer.ToString();                
            }
        }


        void ProcessStaticContent(string strStaticContentToProcess)
        {
            if (!File.Exists(strStaticContentToProcess))
            {
                HttpContext.Current.Response.StatusCode = 404;
                HttpContext.Current.Response.Write("....File Not Found: " + strStaticContentToProcess + "<hr>");
                return;
            }
            switch (Path.GetExtension(strStaticContentToProcess))
            {
                case ".swf":
                case ".jpg":
                case ".gif":
                case ".png":
                    {
                        try
                        {
                            using (FileStream fsImage = new FileStream(strStaticContentToProcess, FileMode.Open, FileAccess.Read))
                            {                                                           
                                FileStream fs = new FileStream(strStaticContentToProcess, FileMode.Open, FileAccess.Read, FileShare.Read);
                                int len = (int)fs.Length;
                                byte[] fileBytes = new byte[len];
                                int bytesRead = fs.Read(fileBytes, 0, len);
                                switch (Path.GetExtension(strStaticContentToProcess))
                                {
                                    case ".swf":
                                        HttpContext.Current.Response.ContentType = "application/x-shockwave-flash";
                                        break;
                                    case ".jpg":
                                        HttpContext.Current.Response.ContentType = "image/jpg";
                                        break;
                                    case ".gif":
                                        HttpContext.Current.Response.ContentType = "image/gif";
                                        break;
                                    case ".png":
                                        HttpContext.Current.Response.ContentType = "image/png";
                                        break;
                                }                                
                                HttpContext.Current.Response.OutputStream.Write(fileBytes, 0, bytesRead);
                            }
                        }
                        catch (Exception ex)
                        {
                            HttpContext.Current.Response.Write("Error in Swf/Gif/Jpg handler of ProcessStaticContent: '" + ex.Message + "<hr>");
                        }
                        break;
                    }



                case ".swf2":
                    {
                        try
                        {
                            using (FileStream fsImage = new FileStream(strStaticContentToProcess, FileMode.Open, FileAccess.Read))
                            {
                                bool keepAlive = true;
                                FileStream fs = new FileStream(strStaticContentToProcess, FileMode.Open, FileAccess.Read, FileShare.Read);
                                int len = (int)fs.Length;
                                byte[] fileBytes = new byte[len];
                                int bytesRead = fs.Read(fileBytes, 0, len);

                                String headers = utils.cassini.MakeResponseHeaders(200, utils.cassini.MakeContentTypeHeader(strStaticContentToProcess), bytesRead, keepAlive);                                
                                HttpContext.Current.Response.ContentType = "application/x-shockwave-flash";
                                HttpContext.Current.Response.OutputStream.Write(fileBytes, 0, bytesRead);
                            }
                        }
                        catch (Exception ex)
                        {
                            HttpContext.Current.Response.Write("Error in Swf handler of ProcessStaticContent: '" + ex.Message +"<hr>");
                        }      
                        break;
                    }

                case ".jpg2":
                case ".gif2":
                    {                            
                        try
                        {
                            using (FileStream fsImage = new FileStream(strStaticContentToProcess, FileMode.Open, FileAccess.Read))
                            {
                                bool keepAlive = true;
                                FileStream fs = new FileStream(strStaticContentToProcess, FileMode.Open, FileAccess.Read, FileShare.Read);
                                int len = (int)fs.Length;
                                byte[] fileBytes = new byte[len];
                                int bytesRead = fs.Read(fileBytes, 0, len);

                                String headers = utils.cassini.MakeResponseHeaders(200, utils.cassini.MakeContentTypeHeader(strStaticContentToProcess), bytesRead, keepAlive);
                                HttpContext.Current.Response.ContentType = "image/gif";
                                HttpContext.Current.Response.OutputStream.Write(fileBytes, 0, bytesRead);
                            }
                        }
                        catch  (Exception ex)
                        {
                            HttpContext.Current.Response.Write("Error in Gif/Jpg handler of ProcessStaticContent: '" + ex.Message + "<hr>");
                        }                        
                        break;
                    }
                case ".css":
                    {
                        HttpContext.Current.Response.AddHeader("Content-Type", "text/css; charset=iso-8859-1");
                        HttpContext.Current.Response.Write(utils.files.GetFileContent(strStaticContentToProcess));// use this to show the file's contents
                        break;
                    }
                case ".asmx":
                    {
                        HttpContext.Current.Response.AddHeader("Content-Type", "text/xml; charset=iso-8859-1");
                        HttpContext.Current.Response.Write(utils.files.GetFileContent(strStaticContentToProcess));// use this to show the file's contents
                        break;
                    }
                case ".htm":
                case ".html":
                case ".xml":
                case ".txt":
                case ".js":
                    {
                        HttpContext.Current.Response.Write(utils.files.GetFileContent(strStaticContentToProcess));// use this to show the file's contents
                        break;
                    }
                default:
                    {
                        HttpContext.Current.Response.StatusCode = 404;
                        HttpContext.Current.Response.Write("Extension '" + Path.GetExtension(strStaticContentToProcess) + "' is currently not Handled by SiteGenerator  <hr> ");
                        break;
                    }
            }
        }

        /// <summary>
        /// As the name implies tries to guess the protocol for the web service request.  
        /// 
        /// Pulled from http://www.koders.com/csharp/fid311872F519ECB44D593C9AF71C1FFEC56CC77802.aspx
        /// </summary>
        /// <param name="context">Context of the request</param>
        /// <param name="verb">Action for the request</param>
        /// <returns></returns>
        private static WSProtocol GuessProtocol(HttpContext context, string verb)
        {
            if (context.Request.PathInfo == null || context.Request.PathInfo == "")
            {
                if (context.Request.RequestType == "GET")
                    return WSProtocol.Documentation;
                else
                    return WSProtocol.HttpSoap;
            }
            else
            {
                if (context.Request.RequestType == "GET")
                    return WSProtocol.HttpGet;
                else
                    return WSProtocol.HttpPost;
            }
        }
    }
}