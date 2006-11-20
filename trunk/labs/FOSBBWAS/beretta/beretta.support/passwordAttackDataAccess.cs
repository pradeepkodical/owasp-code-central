#region Imported Libraries

using System;
using System.Configuration;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using beretta.Objects;

#endregion

namespace beretta.Modules.PasswordAttack
{
	/// <summary>
	/// Summary description for bruteForce.
	/// </summary>
	public class passwordAttackDataAccess 
	{
		private static string strConn = ConfigurationSettings.AppSettings["databaseConnection"];


		public passwordAttackDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public static void add(string strDescription, string strUrl, string strFormSubmission, string strSuccessSignature, string strSignatureOperator, int intSignatureType, string strMatches, int intStatus)
		{
			SqlHelper.ExecuteNonQuery(strConn, "WEBSCANNER_passwordAttackConfig_insert", strDescription, strUrl, strFormSubmission, strSuccessSignature, strSignatureOperator, intSignatureType.ToString(), strMatches, intStatus);


		}


		public static void update(int intId, string strDescription, string strUrl, string strFormSubmission, string strSuccessSignature, string strSignatureOperator, int intSignatureType, string strMatches, int intStatus)
		{
			SqlHelper.ExecuteNonQuery(strConn, "WEBSCANNER_passwordAttackConfig_update", intId.ToString(), strDescription, strUrl, strFormSubmission, strSuccessSignature, strSignatureOperator, intSignatureType.ToString(), strMatches, intStatus);


		}

		public static void delete(int intId)
		{
			SqlHelper.ExecuteNonQuery(strConn, "WEBSCANNER_passwordAttackConfig_delete", intId.ToString());

		}

		public static DataSet getAllConfig()
		{
			return SqlHelper.ExecuteDataset(strConn, "WEBSCANNER_passwordAttackConfig_getAll");


		}

		public static DataSet getAllById(int intId)
		{
			return SqlHelper.ExecuteDataset(strConn, "WEBSCANNER_passwordAttackConfig_getAllById", intId.ToString());


		}


		public static DataSet getAllPasswords()
		{
			return SqlHelper.ExecuteDataset(strConn, "WEBSCANNER_passwordAttackPasswords_getAll");


		}

		public static DataSet getAllUsernames()
		{
			return SqlHelper.ExecuteDataset(strConn, "WEBSCANNER_passwordAttackUsernames_getAll");


		}

		public static int getTotalUsernames()
		{
			int intCount = 0;

			DataSet tmpDataSet = new DataSet();
			tmpDataSet = SqlHelper.ExecuteDataset(strConn, "WEBSCANNER_passwordAttackUsernames_getCount");

			intCount = Convert.ToInt32(tmpDataSet.Tables[0].Rows[0].ItemArray[0]);
			return intCount;

		}

		public static int getTotalPasswords()
		{
			int intCount = 0;

			DataSet tmpDataSet = new DataSet();
			tmpDataSet = SqlHelper.ExecuteDataset(strConn, "WEBSCANNER_passwordAttackPasswords_getCount");

			intCount = Convert.ToInt32(tmpDataSet.Tables[0].Rows[0].ItemArray[0]);
			return intCount;
		}

		public static void updateMatches(int intId, string strMatch)
		{
			SqlHelper.ExecuteNonQuery(strConn, "WEBSCANNER_passwordAttackConfig_updateMatches", intId, strMatch);
		}

		public static DataSet getAll()
		{
			throw new NotImplementedException();
		}
	}
}