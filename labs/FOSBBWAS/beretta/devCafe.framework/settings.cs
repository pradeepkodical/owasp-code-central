/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: common settings for application
 */

using System;
using System.Configuration;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class settings
	{
		
		public static string connectionString=System.Configuration.ConfigurationSettings.AppSettings.Get("databaseConnection");
		public static string siteRoot=System.Configuration.ConfigurationSettings.AppSettings.Get("siteRoot");
		public static string rootUploadDir=keyDataAccess.get("rootUploadDir");

		public settings()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static string get(string strKeyName)
		{
			return keyDataAccess.get(strKeyName);

		}

	}
}
