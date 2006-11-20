/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: module data access 
 */

using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for moduleDataAccess.
	/// </summary>
	public class moduleDataAccess:dataAccess
	{
		public moduleDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public static void addModuleToPage(int intTabId, int intModuleId, int intOrder)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_moduleDefinitions_addModuleToPage", intTabId, intModuleId, intOrder);
		}

		public static void removeModuleFromPage(int intId)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_moduleDefinitions_removeModuleFromPage", intId);
		}

		public static void add(string strSrc, string strDescription)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_moduleDefinitions_add", strSrc, strDescription);
		}

		public static void update(int intId, string strSrc, string strDescription)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_moduleDefinitions_update", intId, strSrc, strDescription);
		}

		public static void delete(int intId)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_moduleDefinitions_delete", intId);
		}

		public static DataSet getAll()
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_moduleDefinitions_getAll");
		}

		public static DataSet getDetail(int intId)
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_moduleDefinitions_getDetail", intId);
		}



	}
}
