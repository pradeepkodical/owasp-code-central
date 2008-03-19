using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;

namespace Owasp.Osg.Communicator
{
	// delegate for the control to set response functionality
	public delegate osgResponse delResponse(osgRequest request);

  public class osgCommBuffer: MarshalByRefObject
  {
    private bool b_request_; 
    private static bool b_response_;
		private static delResponse delRespond_;

    public osgCommBuffer() {
      b_request_ = false;
      b_response_ = false;
    }

		public static delResponse delRespond {
			get { return delRespond_; }
			set { delRespond_ = value; }
		}

		public osgResponse controlResponse(osgRequest request) {
			if( request != null )
		    return delRespond_(request);
			return null;
		}

    public bool requestIn {
      get { return b_request_; }
      set { b_request_ = value; }
    }

    public static bool responseReady {
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
