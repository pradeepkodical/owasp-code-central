using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for layoutDataAccess.
	/// </summary>
	public class layoutDataAccess:dataAccess
	{
		public layoutDataAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public static void add(string strLayoutName, string strLayoutPath)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_layouts_add", strLayoutName, strLayoutPath);
		}

		public static void update(int intId, string strLayoutName, string strLayoutPath)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_layouts_update", intId, strLayoutName, strLayoutPath);
		}

		public static void delete(int intId)
		{
			SqlHelper.ExecuteNonQuery(mStrConn, "FRAMEWORK_layouts_delete", intId);
		}

		public static DataSet getAll()
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_layouts_getAll");
		}

		public static DataSet getDetail(int intId)
		{
			return SqlHelper.ExecuteDataset(mStrConn, "FRAMEWORK_layouts_getDetail", intId);
		}

	}
}
