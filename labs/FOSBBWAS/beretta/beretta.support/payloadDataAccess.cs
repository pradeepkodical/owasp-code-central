using System;
using System.Configuration;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using beretta.Support;


namespace beretta.Objects
{
	/// <summary>
	/// Data Access Class for Payloads
	/// </summary>
	public class payloadDataAccess:beretta.Support.dataaccess
	{
	
		

		public payloadDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		
		public static void delete(int intId)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_payload_delete", intId.ToString());
		}

		public static int add(string strPayloadName, string strPayloadData, string strDescription, int intPayloadOrder, int intPayloadType)
		{

			return Convert.ToInt32(SqlHelper.ExecuteScalar(strConnection, "WEBSCANNER_payload_add", strPayloadName, strPayloadData, strDescription, intPayloadOrder.ToString(), intPayloadType.ToString()));
			

		}

		public static void update(int intId, string strPayloadName, string strPayloadData, string strDescription, int intPayloadOrder, int intPayloadType)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_payload_update", intId.ToString(), strPayloadName, strPayloadData, strDescription, intPayloadOrder.ToString(), intPayloadType.ToString());


		}

		public static DataSet getDetail(int intId)
		{

			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_payload_getDetail", intId.ToString());

		}

		public static DataSet getAll()
		{

			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_payload_getAll");

		}

		public static DataSet getAllByType(int intType)
		{

			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_payload_getAllByType", intType);

		}

		public static DataSet getAllByTypeAndUrl(int intType, int intUrlId)
		{

			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_payload_getAllByTypeAndUrl", intType, intUrlId);

		}


		public static DataSet getAllForManageSessionScreen(int intSessionId,  int intUrlId)
		{

			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_payload_getAllForManageSessionScreen", intSessionId.ToString(), intUrlId.ToString());

		

		}

		public static DataSet getSelectedForManageSessionScreen(int intSessionId, int intUrlId)
		{

			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_payload_getSelectedForManageSessionScreen", intSessionId.ToString(), intUrlId.ToString());

			

		}

		public static DataSet getSelectedForManageSessionScreenByType(int intSessionId, int intUrlId, int intType)
		{
			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_payload_getSelectedForManageSessionScreenByType", intSessionId.ToString(), intUrlId.ToString(), intType);
		}

		public static DataSet getAutoPayloads(int intSessionId)
		{
			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_payload_getAutoPayloads", intSessionId.ToString());
		}

		public static DataSet getSelectedForManageSessionScreenExcludeFormElement(int intSessionId, int intUrlId)
		{
			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_payload_getSelectedForManageSessionScreenExcludeFormElement", intSessionId.ToString(), intUrlId.ToString());
		}


		public static void deleteAllSessionPayloadsForSession(int intId, int intUrlId)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_sessionPayloads_deleteAllForSession", intId.ToString(), intUrlId);
		

		}

		
		public static void addSessionPayload(int intSessionId, int intPayloadId, int intUrlId, int intSessionOrder)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_sessionPayloads_add", intSessionId.ToString(), intPayloadId.ToString(), intUrlId.ToString(), intSessionOrder);
		
			
		}


	}
}
