using System;
using System.Configuration;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using beretta.Support;

namespace beretta.Objects
{
	/// <summary>
	/// Data Access Class for Signatures
	/// </summary>
	public class signaturesDataAccess:dataaccess
	{
		 


		public signaturesDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void add(string strSignatureName, string strSignatureValue, string strSignatureOperator,  string strSignatureDescription, string strSignatureMessage, int intSignatureOrder, int intSignatureType, int intSignatureMessageType)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_signatures_add", strSignatureName, strSignatureValue, strSignatureOperator, strSignatureDescription, strSignatureMessage, intSignatureOrder.ToString(), intSignatureType.ToString(), intSignatureMessageType);

		}

		public static void update(int intId, string strSignatureName, string strSignatureValue, string strSignatureOperator,  string strSignatureDescription, string strSignatureMessage, int intSignatureOrder, int intSignatureType, int intSignatureMessageType)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_signatures_update", intId.ToString(), strSignatureName, strSignatureValue, strSignatureOperator, strSignatureDescription, strSignatureMessage, intSignatureOrder.ToString(), intSignatureType.ToString(), intSignatureMessageType);

		}

		public static void delete(int intId)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_signatures_delete", intId.ToString());
			
		}

		public static DataSet getAll()
		{
			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_signatures_getAll");

		
		}

		public static DataSet getDetail(int intId)
		{

			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_signatures_getDetail", intId.ToString());

		}

		public static void deleteAllSessionSignaturesForSession(int intId, int intUrlId)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_sessionSignatures_deleteAllForSession", intId.ToString(), intUrlId);
		

		}

		
		public static void addSessionSignature(int intSessionId, int intSignatureId, int intUrlId, int intSessionOrder)
		{
			SqlHelper.ExecuteNonQuery(strConnection, "WEBSCANNER_sessionSignatures_add", intSessionId.ToString(), intSignatureId.ToString(), intUrlId.ToString(), intSessionOrder);
		
			
		}

		public static DataSet getAllForManageSessionScreen(int intSessionId,  int intUrlId)
		{

			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_signatures_getAllForManageSessionScreen", intSessionId.ToString(), intUrlId.ToString());

		

		}

		public static DataSet getSelectedForManageSessionScreen(int intSessionId, int intUrlId)
		{

			return SqlHelper.ExecuteDataset(strConnection, "WEBSCANNER_signatures_getSelectedForManageSessionScreen", intSessionId.ToString(), intUrlId.ToString());

			

		}


		
	}
}
