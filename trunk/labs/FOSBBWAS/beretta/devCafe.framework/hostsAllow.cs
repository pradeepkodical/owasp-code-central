/* Author: Alex Mackey
 * Date: 25/06/2005
 * Version: 1.0
 * Purpose: hosts allow object
 */

using System;
using System.Data;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for hostsAllow.
	/// </summary>
	public class hostsAllow
	{
		private int mId;
		private string mDescription;
		private string mIp;

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


		public string description
		{
			get
			{
				return mDescription;
			}
			set
			{
				mDescription=value;
			}
		}


		public string ip
		{
			get
			{
				return mIp;
			}
			set
			{
				mIp=value;
			}
		}

		public void add()
		{
			hostsAllowDataAccess.add(mDescription, mIp);
		}

		public void update()
		{
			hostsAllowDataAccess.update(mId, mDescription, mIp);
		}

		public void delete()
		{
			hostsAllowDataAccess.delete(mId);
		}

		public void populate()
		{

			DataSet objDataSet=new DataSet();

			objDataSet=hostsAllowDataAccess.getDetail(mId);

			foreach(DataRow objDataRow in objDataSet.Tables[0].Rows)
			{
				mId=System.Convert.ToInt32(objDataRow["id"]);
				mDescription=System.Convert.ToString(objDataRow["description"]);
				mIp=System.Convert.ToString(objDataRow["ip"]);

			}


		}

		public hostsAllow()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
