/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: security class, handles login, permissions etc
 */

using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for security.
	/// </summary>
	public class security:dataAccess
	{
		public security()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Returns 0 if failed login, user id if not
		/// </summary>
		/// <param name="strUsername">Username</param>
		/// <param name="strPassword">Password</param>
		/// <returns></returns>
		public static int login(string strUsername, string strPassword)
		{

			string strTmpPassword="" + strPassword;

			strTmpPassword="" + encryption.hashMD5(strTmpPassword + settings.get("entropyValue"));
			
			

			return userDataAccess.login(strUsername, strTmpPassword);

			//TO DO Log stuff

		}

		public static DataSet getAllHostsAllow()
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_hostsAllow_getAll");
		}


		
	
	}
}
