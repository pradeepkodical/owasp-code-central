using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml;
using System.Runtime.Remoting;
using System.IO;
using Owasp.Osg.Communication;

namespace Owasp.Osg.HttpHandler
{
  public class osgHttpHandler : IHttpHandler 
  {
    private const string config_path = "osgWebhandler.config";

    protected osgHttpHandler() : base() 
    {
      loadRemoteConfig(); //Load the remote info from the config fil
    }
    
    private bool loadRemoteConfig() 
    {
      bool success = true;
      try
      {
        RemotingConfiguration.Configure(config_path, false);
      }
      catch
      {
        success = false;
      }
      return success;
    }

    public void ProcessRequest(HttpContext context)
    {
      osgRequest request = loadRequest(context.Request);
      //osgResponse response = null; 
      //Instantiate remote object 
      
      //wait for remoteAnswer(ref request);
      //postResponse(response);
    }

    private osgRequest loadRequest(HttpRequest request)
    {
      osgRequest osg_request = new osgRequest();
      osg_request.RequestURI = "default.html";
      osg_request.RequestMethod = request.HttpMethod.ToString();
      switch(osg_request.RequestMethod) {
        case "POST":
          osg_request.RequestURI = request.Form.ToString();
          break;
        case "GET":
          osg_request.RequestURI = request.QueryString.ToString();
          break;
        //if not POST or GET do nothing
       }
      return osg_request; 
    }
    
    public bool IsReusable 
    {
      get {
        return true;
      }
    }
  }
}
