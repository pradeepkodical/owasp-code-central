/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: user data access
 */

using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for userDataAccess.
	/// </summary>
	public class userDataAccess:dataAccess
	{
		public userDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static int login(string strUsername, string strPassword)
		{
			int intId=0;
			DataSet objDataSet=new DataSet();
			objDataSet=SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_users_login", strUsername, strPassword);

			if (objDataSet.Tables[0].Rows.Count==0)
			{
				userDataAccess.incrementFailedLogin(strUsername);

				return 0;
			}
			else
			{
				intId=System.Convert.ToInt32(objDataSet.Tables[0].Rows[0].ItemArray[0]);

				return intId;
			}

				
		}


		


		public static int add(string strUsername, string strEmail, string strFirstName, string strLastName, string strOrganisation, int intType, int intIsActive)
		{
			return System.Convert.ToInt32(SqlHelper.ExecuteScalar(mStrConn, "FRAMEWORK_users_insert", strUsername, strEmail, strFirstName, strLastName, strOrganisation, intType, intIsActive));
		}


		public static void update(int intUserId, string strUsername, string strEmail, string strFirstName, string strLastName, string strOrganisation, int intType, int intIsActive)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_users_update", intUserId, strUsername, strEmail, strFirstName, strLastName, strOrganisation, intType, intIsActive);
		}

		public static void updatePassword(int intUserId, string strPassword)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_users_updatePassword", intUserId, strPassword);
		}


		public static void delete(int intUserId)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_users_delete", intUserId);
		}


		public static void incrementFailedLogin(string strUsername)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_users_incrementFailedLogin", strUsername);
		}

		public static DataSet getAll()
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_users_getAll");
		}

		public static DataSet getDetail(int intId)
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_users_getDetail", intId);

		}



		public static DataSet userProjects_getForLogin(string strProjectName, int intUserId)
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_userProjects_getForLogin", strProjectName, intUserId);

		}


	}
}
