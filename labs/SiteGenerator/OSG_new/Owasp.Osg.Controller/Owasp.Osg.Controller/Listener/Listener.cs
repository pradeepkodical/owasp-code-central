using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using Owasp.Osg.Communicator;


namespace Owasp.Osg.Controller.Communicator 
{
  public class Listener {	
	/* Purpose: This class hosts the comm buffer for
	 * remote access. Also defines the response start
	 * point via the method controlResponse().
	 * 
	 * Precondition: Specified http port should not
	 * be in use for anyother purpose. 
	 * 
	 * Postcondition: OSG httphandler should be able
	 * to access a remote comm buffer object. 
	 * 
	 * Author: ADL
	 * Date: March 2008
	 * Modifications:
	 */

		public void Begin() {
			// open a channel to listen for webRequests
			registerChannel();
      // set web response handler in osgCommBuffer
			osgCommBuffer.delRespond = new delResponse(controlResponse);
		}

		private osgResponse controlResponse(osgRequest webRequest) { 
			osgResponse response = new osgResponse(); 
			// get response(???) for web request here...ParseRequest webParser(webRequest);
			response.PhysicalFileLocation = "<strong>Hello from Controller.</strong>";
			return response;
		}

		private void registerChannel() {
			// set typefilterlevel to higher security
			SoapServerFormatterSinkProvider serverFormatter = new SoapServerFormatterSinkProvider();
			serverFormatter.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
			// setup dictionary with values
			Hashtable ht = new Hashtable();
			ht["name"] = "ServerChannel";
			ht["port"] = 9000;
			// create and register the channel 
			HttpChannel channel = new HttpChannel(ht, null, serverFormatter);
			ChannelServices.RegisterChannel(channel, false);
			// register a wellknown type in singleton mode
			string identifier = "commBuffer";
			WellKnownObjectMode mode = WellKnownObjectMode.Singleton;
			WellKnownServiceTypeEntry entry = new WellKnownServiceTypeEntry(typeof(osgCommBuffer),
					identifier, mode);
			 RemotingConfiguration.RegisterWellKnownServiceType(entry);
	  }
	}
}