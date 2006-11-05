using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Globalization;

namespace Owasp.SiteGenerator.utils
{
    class cassini
    {
        public static String MakeResponseHeaders(int statusCode, String moreHeaders, int contentLength, bool keepAlive)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("HTTP/1.1 " + statusCode + " " + HttpWorkerRequest.GetStatusDescription(statusCode) + "\r\n");
            sb.Append("Server: SiteGenerator\r\n");
            sb.Append("Date: " + DateTime.Now.ToUniversalTime().ToString("R", DateTimeFormatInfo.InvariantInfo) + "\r\n");
            if (contentLength >= 0)
                sb.Append("Content-Length: " + contentLength + "\r\n");
            if (moreHeaders != null)
                sb.Append(moreHeaders);
            if (!keepAlive)
                sb.Append("Connection: Close\r\n");
            sb.Append("\r\n");
            return sb.ToString();
        }

        public static String MakeContentTypeHeader(String fileName)
        {
            String contentType = null;

            int lastDot = fileName.LastIndexOf('.');

            if (lastDot >= 0)
            {
                switch (fileName.Substring(lastDot))
                {
                    case ".js": contentType = "application/x-javascript"; break;
                    case ".gif": contentType = "image/gif"; break;
                    case ".jpg": contentType = "image/jpeg"; break;
                }
            }

            if (contentType == null)
                return null;

            return "Content-Type: " + contentType + "\r\n";
        }
    }
}
