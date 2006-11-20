/* Author: Alex Mackey
 * Date: 26/06/2005
 * Version: 1.0
 * Purpose: list item data access
 */

using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for listItemsDataAccess.
	/// </summary>
	public class listItemsDataAccess:dataAccess
	{
		public listItemsDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void add(string strListItemName, int intListItemOrder, int intIsDefault, int intGroupId)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_listItems_add", strListItemName, intListItemOrder, intIsDefault, intGroupId);
		}


		public static void update(int intId, string strListItemName, int intListItemOrder, int intIsDefault, int intGroupId)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_listItems_update", intId, strListItemName, intListItemOrder, intIsDefault, intGroupId);
		}

		public static void delete(int intId)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_listItems_delete", intId);
		}

		public static void updateOrder(int intId, int intOrderId)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_listItems_updateOrder", intId, intOrderId);
		}

		public static DataSet getAll()
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_listItems_getAll");
		}

		public static DataSet getDetail(int intId)
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_listItems_getDetail", intId);
		}

		public static DataSet getAllForGroup(int intGroupId)
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_listItems_getAllForGroup", intGroupId);
		}

		public static DataSet getAllForGroupByName(string strGroupName)
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_listItems_getAllForGroupByName", strGroupName);
		}

		

		
	}
}
