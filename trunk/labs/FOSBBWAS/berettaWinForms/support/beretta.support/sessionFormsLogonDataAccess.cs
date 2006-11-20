using System;
using System.Configuration;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using beretta.Support;

namespace beretta.Objects
{
	/// <summary>
	/// Data Access clas for Session Forms Logon
	/// </summary>
	public class sessionFormsLogonDataAccess:dataaccess
	{
		static string strConn=ConfigurationSettings.AppSettings["databaseConnection"];

		public sessionFormsLogonDataAccess()
		{
			
		}

		public static void add(int intSessionId, string strLoginPageUrl, string strUsername, string strPassword, string strUsernameFieldName, string strPasswordFieldName, string strSubmitButtonFieldName)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_sessionFormsLogon_add", intSessionId, strLoginPageUrl, strUsername, strPassword, strUsernameFieldName, strPasswordFieldName, strSubmitButtonFieldName);

		}

		
		public static void deleteBySessionId(int intSessionId)
		{

			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_sessionFormsLogon_deleteBySessionId", intSessionId);

		}

		public static DataSet getDetailBySessionId(int intSessionId)
		{
			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_sessionFormsLogon_getDetailBySessionId", intSessionId);

		}



	}
}
