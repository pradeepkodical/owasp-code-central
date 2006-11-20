/* Author: Alex Mackey
 * Date: 28/06/2005
 * Version: 1.0
 * Purpose: role data access
 */


using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for rolesDataAccess.
	/// </summary>
	public class rolesDataAccess:dataAccess
	{
		public rolesDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		

		public static void addUserRole(int intUserId, int intRoleId)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_userRoles_add", intUserId, intRoleId);
		}

		public static void deleteUserRole(int intId)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_userRoles_delete", intId);
		}

		public static DataSet getAllForUser(int intUserId)
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_userRoles_getAllForUser", intUserId);
		}

		public static void add(string strRoleName)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_roles_add", strRoleName);
		}

		public static void update(int intId, string strRoleName)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_roles_update", intId, strRoleName);
		}


		public static void delete(int intId)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_roles_delete", intId);

		}


		public static DataSet getAll()
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_roles_getAll");

		}


		public static DataSet getDetail(int intId)
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_roles_getDetail", intId);
		}

	}
}
