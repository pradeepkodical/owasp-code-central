using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.IO;
using Owasp.Osg.Communicator;

namespace Owasp.Osg.HttpHandler
{
  public class osgHttpHandler : IHttpHandler {

		osgCommBuffer commBuffer_ = null;

    protected osgHttpHandler() : base() {
			initBuffer();
    }

		private void initBuffer() {		
			commBuffer_ = null;
      // register a http channel
      HttpChannel channel = new HttpChannel(9003);
      ChannelServices.RegisterChannel(channel, false);
      // get a copy of the buffer
      object obj = Activator.GetObject(typeof(osgCommBuffer), "http://abbylaptop:9000/commBuffer");
			//cast to local type
      commBuffer_ = (osgCommBuffer)obj;				  
		}

    public void ProcessRequest(HttpContext context) {
	    if (commBuffer_ == null) {
			  context.Response.Write("Remote object not instantiated<br>");
			  context.Response.End();
		  }			
		  // send to buffer
			osgRequest request = loadRequest(context.Request);
			// wait for controller to respond
			osgResponse response  = commBuffer_.controlResponse(request);									
		  // post response (????) to broswer
		  context.Response.Write(response.PhysicalFileLocation);
			context.Response.End();
    }

    private osgRequest loadRequest(HttpRequest request) {
      osgRequest osgRequest = new osgRequest();
      osgRequest.RequestURI = "default.html";
      osgRequest.RequestMethod = request.HttpMethod.ToString();
      switch(osgRequest.RequestMethod) {
        case "POST":
          osgRequest.RequestURI = request.Url.ToString();
          break;
        case "GET":
          osgRequest.RequestURI = request.Url.ToString();
          break;
       }
      return osgRequest; 
    }
    
    public bool IsReusable {
      get {
        return true;
      }
    }

		protected void testMe(string msg) {
			HttpContext.Current.Response.Write(msg);
			HttpContext.Current.Response.End();
		}
  }
}
