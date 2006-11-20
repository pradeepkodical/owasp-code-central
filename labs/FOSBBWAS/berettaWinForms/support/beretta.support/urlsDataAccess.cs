using System;
using System.Data;
using System.Configuration;
using beretta.Support;
using Microsoft.ApplicationBlocks.Data;

namespace beretta.Objects
{
	/// <summary>
	/// Data Access Class for URLS
	/// </summary>
	public class urlsDataAccess:dataaccess
	{

		private static string strConn=ConfigurationSettings.AppSettings["databaseConnection"];


		public urlsDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public static int add(int intSessionId, string strUrl, string strDescription, int intSessionOrder)
		{
			return Convert.ToInt32(SqlHelper.ExecuteScalar(strConnection, "WEBSCANNER_urls_add", intSessionId.ToString(), strUrl, strDescription, intSessionOrder));

		}

		public static void update(int intId, int intSessionId, string strUrl, string strDescription, int intSessionOrder)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_urls_update", intId.ToString(), intSessionId.ToString(), strUrl, strDescription, intSessionOrder);
			
		}


		public static void delete(int intId)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_urls_delete", intId.ToString());
			
		}

		public static void updateOrder(int intId, int intOrder)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_urls_updateOrder", intId.ToString(), intOrder);
			
		}


		public static int getCountForSession(int intId)
		{
			return System.Convert.ToInt32(SqlHelper.ExecuteScalar(strConnection, "WEBSCANNER_urls_getCountForSession", intId.ToString()));
			
		}
		


		public static DataSet getDetail(int intId)
		{
			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_urls_getDetail", intId.ToString());
			
		}

		public static DataSet getAllForSession(int intSessionId)
		{
			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_urls_getAllForSession", intSessionId.ToString());
			
		}

	}
}
