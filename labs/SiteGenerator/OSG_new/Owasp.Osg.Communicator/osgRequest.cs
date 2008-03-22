using System;
using System.Collections.Generic;
using System.Text;

namespace Owasp.Osg.Communicator
{
	[Serializable]
  public class osgRequest {
  /* Purpose: Encapsulates a request from
	 * the web to the controller. 
	 *
	 * Preconditions: The user had made a request.
	 * The controller is running to take this 
	 * request. 
	 * 
	 * Postconditions: Contians all neccessary data that
	 * the contorller needs to get requested content
	 * for user.
	 * 
	 * Author: ADL
	 * Date: March 2008
	 * Modifications:
	 */

    private string URI_;         //URI request
    private string method_;      //method type
    private Guid guid_;          //transaction id

    public osgRequest() {
      //initialize transaction ID
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
      get { return method_; }
      set { method_ = value; }
    }
    /*unique transaction ID */
    public string transactionId {
      get { return guid_.ToString(); }
    }
  }
}

