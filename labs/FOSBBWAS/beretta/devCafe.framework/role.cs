/* Author: Alex Mackey
 * Date: 28/06/2005
 * Version: 1.0
 * Purpose: role object
 */


using System;
using System.Data;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for role.
	/// </summary>
	public class role
	{
		private int mId;
		private string mRoleName;

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

		public string roleName
		{
			get
			{
				return mRoleName;
			}
			set
			{
				mRoleName=value;
			}
		}

		
		public role()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void add()
		{
			rolesDataAccess.add(mRoleName);
		}

		public void update()
		{
			rolesDataAccess.update(mId, mRoleName);
		}

		public void delete()
		{
			rolesDataAccess.delete(mId);
		}

		public void populate()
		{
			DataSet objDataSet=new DataSet();

			objDataSet=rolesDataAccess.getDetail(mId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				mId=System.Convert.ToInt32(objDataRow["id"]);
				mRoleName=System.Convert.ToString(objDataRow["roleName"]);
			}

		}
	}
}
