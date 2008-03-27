using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;

namespace Owasp.Osg.Communicator
{
	// delegate type for the control to set response functionality
	public delegate osgResponse delResponse(osgRequest request);

  public class osgCommBuffer: MarshalByRefObject {
  /* Purpose: Buffer for back and forth communication
	 * between web and controller. 
	 * 
	 * Precondition: This class object should be hosted 
	 * to be accessed remotely. 
	 * 
	 * Postcondition: None.
	 * 
	 * Author: ADL
	 * Date: March 2008
	 * Modifications:
	 */ 
    private bool b_request_; 
    private bool b_response_;
		private static delResponse delRespond_;

    public osgCommBuffer() {
      b_request_ = false;
      b_response_ = false;
    }

	/* access to controller response */
	public static delResponse delRespond {
		get { return delRespond_; }
		set { delRespond_ = value; }
	}

	/* "gateway" method to controller to handle requests */
	public osgResponse controlResponse(osgRequest request) {
		requestIn = true;
		if( request != null ) {
			responseReady = true;
	    return delRespond_(request);
		}
		return null;
	}

    public bool requestIn {
      get { return b_request_; }
      set { b_request_ = value; }
    }

    public bool responseReady {
      get { return b_response_; }
      set { b_response_ = value; }
    }

		public override object InitializeLifetimeService() {
			//override 5min remote lease time to 30sec
      ILease lease = (ILease) base.InitializeLifetimeService();
      lease.InitialLeaseTime = new TimeSpan(0, 0, 30);
      return lease;
    }
  }
}
