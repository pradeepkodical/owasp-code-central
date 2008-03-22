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
  /* Purpose: This class sends a single request from the 
	 * browser to the controller via a remote buffer 
	 * object. It then posts back the controller's
	 * response to the browser. Minimal parsing is done. 
	 * 
	 * Precondition: The controller is running so comm-
	 * unication with it can occur and a response can 
	 * be received. 
	 * 
	 * Postcondition: The correct content is sent to the
	 * broswer for display to the user. 
	 * 
	 * Author: ADL 
	 * Original Date: March 2008
	 * Modifications:
	 */ 

		private osgCommBuffer commBuffer_ = null;

    protected osgHttpHandler() : base() {
			// class is re-instantiated for every request so
			// each time needs to grab a new buffer object
			initBuffer();
    }

    public void ProcessRequest(HttpContext context) {
	    if (commBuffer_ == null) {
			  context.Response.Write("Remote object not instantiated<br>");
			  context.Response.End();
		  }			
		  // send to buffer
			osgRequest request = loadRequest(context.Request);
			// notify controller of request. Get response.
			osgResponse response  = commBuffer_.controlResponse(request);									
			// verify response from controller
			if( response != null ) {
		    // post response (????) to broswer
		    context.Response.Write(response.PhysicalFileLocation);
			  context.Response.End();
			}
    }

    private osgRequest loadRequest(HttpRequest request) {
			// This will all change so no comments currently
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
      get { return true; }
    }

		private void initBuffer() {		
			commBuffer_ = null;
      // register a http channel
      HttpChannel channel = new HttpChannel(9003);
      ChannelServices.RegisterChannel(channel, false);
			// TODO: Change this. It only works for channels commuinicating on local machine
			string url = "http://" + System.Environment.MachineName.ToString() + ":9000/commBuffer";
      // get a copy of the buffer
      object obj = Activator.GetObject(typeof(osgCommBuffer), url);
			//cast to local type
      commBuffer_ = (osgCommBuffer)obj;				  
		}

		protected void testMe(string msg) {
			HttpContext.Current.Response.Write(msg);
			HttpContext.Current.Response.End();
		}
  }
}
