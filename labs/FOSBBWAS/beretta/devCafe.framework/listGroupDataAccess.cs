/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: list group data access
 */

using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for listGroupDataAccess.
	/// </summary>
	public class listGroupDataAccess:dataAccess
	{
		public listGroupDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void add(string strListGroupName)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_listGroup_add", strListGroupName);
		}

		public static void update(int intId, string strListGroupName)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_listGroup_update", intId, strListGroupName);
		}

		public static void delete(int intId)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_listGroup_delete", intId);
		}

		public static DataSet getAll()
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_listGroup_getAll");
		}

		public static DataSet getDetail(int intId)
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_listGroup_getDetail", intId);
		}


	}
}
