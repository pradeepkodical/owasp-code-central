using System;
using System.Collections.Generic;
using System.Text;

namespace Owasp.Osg.Communicator
{
	[Serializable]
  // The httpmodule sends this
  public class osgRequest {

    private string URI_;         //URI request
    private string method_;      //method type
    private Guid guid_;          //transaction id

    public osgRequest() {
      //initialize class variables
      guid_ = Guid.NewGuid(); 
      URI_ = String.Empty;
      method_ = String.Empty;
    }

    /* This will hold the URI that was requested */
    public string RequestURI {
      get { return URI_; }
      set { URI_ = value; }
    }
    /* This holds the value from HttpRequest.Method, letting us know if it is a post, get, etc..*/
    public string RequestMethod {
      get {
        return method_;
      }
      set {
        method_ = value;
      }
    }
    /* This will hold a unique transaction ID, a GUID , the HTTPModule needs
        to keep track of valid transaction IDs so it can handle multiple requests*/
    public string transactionId {
      get {
        return guid_.ToString();
      }      
    }
}

}

