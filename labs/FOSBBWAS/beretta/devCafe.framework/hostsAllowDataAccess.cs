/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: hosts allow data access
 */

using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for hostsAllowDataAccess.
	/// </summary>
	public class hostsAllowDataAccess:dataAccess
	{
		public hostsAllowDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void add(string strDescription, string strIp)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_hostsAllow_add", strDescription, strIp);
		}

		public static void update(int intId, string strDescription, string strIp)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_hostsAllow_update", intId, strDescription, strIp);
		}

		public static void delete(int intId)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_hostsAllow_delete", intId);
		}

		public static DataSet getAll()
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_hostsAllow_getAll");
		}

		public static DataSet getDetail(int intId)
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_hostsAllow_getDetail", intId);
		}
	}
}
