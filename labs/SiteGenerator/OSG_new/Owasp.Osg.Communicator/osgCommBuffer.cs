using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;

namespace Owasp.Osg.Communicator
{
    class osgCommBuffer: MarshalByRefObject
    {
      private bool b_request_; 
      private bool b_response_;

      public bool requestIn {
        get {
          return b_request_;
        }
        set {
          b_request_ = value;
        }
      }
      public bool responseReady {
        get {
          return b_response_;
        }
        set {
          b_response_ = value;
        }
      }
      public osgRequest newRequest() {
        return new osgRequest();
      }
      public osgResponse newResponse() {
        return new osgResponse();
      }
         
    }
}
