using System;
using System.Configuration;

namespace beretta.Objects
{
	/// <summary>
	/// Summary description for support.
	/// </summary>
	public class support
	{
		public support()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string getSiteRoot()
		{

			return System.Configuration.ConfigurationSettings.AppSettings.Get("siteRoot");
		}




	}
}
