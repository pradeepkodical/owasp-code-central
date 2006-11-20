using System;
using System.Configuration;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using beretta.Support;

namespace beretta.Objects
{
	/// <summary>
	/// Data Access Class for Raw Logon class
	/// </summary>
	public class sessionRawLogonDataAccess:dataaccess
	{
		static string strConn=ConfigurationSettings.AppSettings["databaseConnection"];

		public sessionRawLogonDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void add(int intSessionId, string strLoginPageUrl, string strRawSubmission)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_sessionRawLogon_add", intSessionId, strLoginPageUrl, strRawSubmission);

		}


		public static void deleteBySessionId(int intSessionId)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_sessionRawLogon_deleteBySessionId", intSessionId);

		}

		public static DataSet getDetailBySessionId(int intSessionId)
		{

			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_sessionRawLogon_getDetailBySessionId", intSessionId);
		}



		
	}
}
