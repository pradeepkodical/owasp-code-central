using System;
using System.Configuration;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using beretta.Support;

namespace beretta.Objects
{
	/// <summary>
	/// Data Access Class for Session 
	/// </summary>
	public class sessionDataAccess:dataaccess
	{


		public sessionDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static int add(string strSessionName, string strSessionDescription, string strApplicationBaseUrl, int intAuthenticationType, int intUseAutoScan, int intUserAgent)
		{
			return Convert.ToInt32(SqlHelper.ExecuteScalar(strConnection, "WEBSCANNER_sessions_add", strSessionName, strSessionDescription, strApplicationBaseUrl, intAuthenticationType, intUseAutoScan, intUserAgent));

			

		}

		public static void update(int intId, string strSessionName, string strSessionDescription,  string strApplicationBaseUrl, int intAuthenticationType, int intUseAutoScan, int intUserAgent)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_sessions_update", intId.ToString(), strSessionName, strSessionDescription, strApplicationBaseUrl, intAuthenticationType, intUseAutoScan, intUserAgent);

			

		}
	
		public static void delete(int intId)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_sessions_delete", intId.ToString());

		

		}

		

		public static DataSet getDetail(int intId)
		{

			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_sessions_getDetail", intId.ToString());

		}

		public static DataSet getAll()
		{

			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_sessions_getAll");

		

		}
	}
}
