using System;
using System.Collections.Generic;
using System.Text;

namespace Owasp.Osg.Communicator
{   [Serializable]
    public class osgResponse
    {
      private Guid guid_;
      private string fileLocation_;
      private string templateLocation_;

      /* Holds the transactionID received from the osgRequest object */
      public string transactionID {
        get { return guid_.ToString(); }
      }

      /* Specifies the physical file location, if needed */
      public string PhysicalFileLocation {
        get { return fileLocation_; }
        set { fileLocation_ = value; }
      }

      /* Holds the template location */
      public string DisplayTemplateLocation {
          get { return templateLocation_; }
          set { templateLocation_ = value; }
      }

      /* This holds an object that implements the IExploit interface */
      /*
       * public ***** Exploit {
       // TODO: implement
      }
      */
    }
}
