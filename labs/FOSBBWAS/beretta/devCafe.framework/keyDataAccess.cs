/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: config data access
 */
 
using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;


namespace devCafe.framework
{
	/// <summary>
	/// Summary description for configDataAccess.
	/// </summary>
	public class keyDataAccess:dataAccess
	{
		public keyDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static string get(string strKeyName)
		{
			return System.Convert.ToString(SqlHelper.ExecuteScalar(mStrConn, "FRAMEWORK_keys_getKey", strKeyName));
		}

		public static void add(string strKeyName, string strKeyValue, string strDescription)
		{
			SqlHelper.ExecuteScalar(mStrConn, "FRAMEWORK_keys_add", strKeyName, strKeyValue, strDescription);
		}

		public static void update(int intId, string strKeyName, string strKeyValue, string strDescription)
		{
			SqlHelper.ExecuteScalar(mStrConn, "FRAMEWORK_keys_update", intId, strKeyName, strKeyValue, strDescription);
		}

		public static void delete(int intId)
		{
			SqlHelper.ExecuteScalar(mStrConn, "FRAMEWORK_keys_delete", intId);
		}

		public static DataSet getAll()
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_keys_getAll");
		}

		public static DataSet getDetail(int intId)
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_keys_getDetail", intId);
		}

		
		
	}
}
