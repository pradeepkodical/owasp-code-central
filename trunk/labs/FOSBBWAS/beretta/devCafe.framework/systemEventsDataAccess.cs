/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: system events data access
 */

using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for systemEventsDataAccess.
	/// </summary>
	public class systemEventsDataAccess:dataAccess
	{
		public systemEventsDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static DataSet getAll()
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_systemEvents_getAll");

		}

		public static DataSet getAllEventTypes()
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_events_getAll");

		}

		

		public static void add(int intEventType, string strMessage, int intUserId, string strIp)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_systemEvents_add", intEventType, strMessage, intUserId, strIp);
		}
		

	}
}
