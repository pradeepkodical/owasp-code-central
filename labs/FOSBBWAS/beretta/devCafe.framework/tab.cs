/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: tab object
 */

using System;
using System.Data;


namespace devCafe.framework
{
	/// <summary>
	/// Summary description for tab.
	/// </summary>
	public class tab
	{
		private int mId;
		private string mPageName;
		private int mLayoutId;
		private string mAllowedRoles;

		public int id
		{
			get
			{
				return mId;
			}
			set
			{
				mId=value;
			}
		}

		public string pageName
		{
			get
			{
				return mPageName;
			}
			set
			{
				mPageName=value;
			}
		}

		public int layoutId
		{
			get
			{
				return mLayoutId;
			}
			set
			{
				mLayoutId=value;
			}
		}

		public string allowedRoles
		{
			get
			{
				return mAllowedRoles;
			}
			set
			{
				mAllowedRoles=value;
			}
		}


		public void add()
		{
			tabDataAccess.add(mPageName, mLayoutId, mAllowedRoles);
		}

		public void update()
		{
			tabDataAccess.update(mId, mPageName, mLayoutId, mAllowedRoles);
		}

		public void delete()
		{
			tabDataAccess.delete(mId);
		}

		public void populate()
		{
			DataSet objDataSet=new DataSet();

			objDataSet=tabDataAccess.getDetail(mId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				mId=System.Convert.ToInt32(objDataRow["id"]);
				mPageName=System.Convert.ToString(objDataRow["pageName"]);
				mLayoutId=System.Convert.ToInt32(objDataRow["layoutId"]);
				mAllowedRoles=System.Convert.ToString(objDataRow["allowedRoles"]);

			}


		}

		public tab()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		
	}
}
