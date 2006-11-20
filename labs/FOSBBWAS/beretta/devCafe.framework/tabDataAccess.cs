/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: tab data access
 */

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;


namespace devCafe.framework
{
	/// <summary>
	/// Summary description for tabDataAccess.
	/// </summary>
	public class tabDataAccess:dataAccess
	{
		public tabDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public static void add(string strPageName, int intLayoutId, string strAllowedRoles)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_tabs_add", strPageName, intLayoutId, strAllowedRoles);

		}

		public static void update(int intId, string strPageName, int intLayoutId, string strAllowedRoles)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_tabs_update", intId, strPageName, intLayoutId, strAllowedRoles);
		}

		public static void delete(int intId)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_tabs_delete", intId);
		}


		public static DataSet getAll()
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_tabs_getAll");
			
		}

		public static DataSet getDetail(int intId)
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_tabs_getDetail", intId);
			
		}

		public static SqlDataReader getAllModulesForTab(int intTabId)
		{
			return SqlHelper.ExecuteReader(mStrConn, "FRAMEWORK_tabs_getAllModulesForTab", intTabId);
			
		}

		public static DataSet getAllModulesForTabDataSet(int intTabId)
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_tabs_getAllModulesForTab", intTabId);
			
		}

		public static string getLayoutPathForTab(int intTabId)
		{
			SqlDataReader objReader=SqlHelper.ExecuteReader(mStrConn, "FRAMEWORK_tabs_getLayoutPathForTab", intTabId);

			objReader.Read();

			return objReader.GetValue(0).ToString();

		}

		public static string getRolesForTab(int intTabId)
		{
	
			DataSet objDataSet=new DataSet();

			objDataSet=SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_tabs_getRolesForTab", intTabId);

			return objDataSet.Tables[0].Rows[0].ItemArray[0].ToString();
		}

	}
}
